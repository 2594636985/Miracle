using Miracle.Modularization.Aspects.Reflection.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace Miracle.Modularization.Aspects
{
    using Reflection;
    using Reflection.Emit;

    /// <summary>
    /// 代理类型生成类
    /// </summary>
    public sealed class ProxyTypeBuilder : ITypeBuilder
    {
        private static readonly MethodInfo InvocationHandlerInvokeMethodInfo = typeof(IInvocationHandler).GetMethod("Invoke", BindingFlags.Public | BindingFlags.Instance, typeof(object), typeof(MethodInfo), typeof(object[]));
        private readonly ITypeRepository _typeRepository;
        private readonly Type _parentType;
        private readonly TypeBuilder _typeBuilder;
        private readonly FieldInfo _invocationHandlerFieldInfo;
        private readonly HashSet<Type> _interfaceTypes;

        public ProxyTypeBuilder(ITypeRepository typeRepository, Type parentType)
        {
            if (typeRepository == null)
                throw new ArgumentNullException("typeRepository");

            if (parentType == null)
                throw new ArgumentNullException("parentType");

            if (parentType.IsSealed)
                throw new ArgumentException("父类型不能是一个Sealed类型", "parentType");

            if (parentType.IsGenericTypeDefinition)
                throw new ArgumentException("父类型不能是一个泛型", "parentType");

            _typeRepository = typeRepository;
            _parentType = parentType;

            _typeBuilder = typeRepository.DefineType("Proxy", parentType);
            _invocationHandlerFieldInfo = _typeBuilder.DefineField("_invocationHandler", typeof(IInvocationHandler), FieldAttributes.Private | FieldAttributes.InitOnly);
            _interfaceTypes = new HashSet<Type>();
        }


        private MethodBuilder BuildInterceptedMethod(MethodInfo methodInfo, bool isExplicit)
        {
            var isOverride = IsOverrideMember(methodInfo);

            //if (isOverride && !methodInfo.CanOverride())
            //    throw new InvalidOperationException("方法{0}是不能重写的".FormatEx(methodInfo.Name));

            var methodBuilder = _typeBuilder.DefineMethod(methodInfo, isExplicit, isOverride);

            var genericParameterTypes = methodBuilder.DefineGenericParameters(methodInfo);

            methodBuilder.DefineParameters(methodInfo, genericParameterTypes);

            if (isExplicit && isOverride)
                _typeBuilder.DefineMethodOverride(methodBuilder, methodInfo);

            var ilGenerator = methodBuilder.GetILGenerator();

            var parameterTypes = methodInfo.MapGenericParameterTypes(genericParameterTypes);
            var parametersLocalBuilder = ilGenerator.NewArray(typeof(object), parameterTypes.Length);

            LoadArguments(ilGenerator, parameterTypes, parametersLocalBuilder);

            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ldfld, _invocationHandlerFieldInfo);

            ilGenerator.Emit(OpCodes.Ldarg_0);

            var methodInfoConstructorInfo = GetMethodInfoConstructor(methodInfo, genericParameterTypes);

            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(isOverride ? OpCodes.Ldc_I4_1 : OpCodes.Ldc_I4_0);
            ilGenerator.Emit(OpCodes.Newobj, methodInfoConstructorInfo);

            ilGenerator.Emit(OpCodes.Ldloc, parametersLocalBuilder);

            ilGenerator.EmitCall(InvocationHandlerInvokeMethodInfo);

            RestoreByReferenceArguments(ilGenerator, parameterTypes, parametersLocalBuilder);

            var returnType = methodInfo.MapGenericReturnType(genericParameterTypes);

            if (returnType.IsVoid())
                ilGenerator.Emit(OpCodes.Pop);
            else
                ilGenerator.EmitUnbox(returnType);

            ilGenerator.Emit(OpCodes.Ret);

            return methodBuilder;
        }


        private ConstructorInfo GetMethodInfoConstructor(MethodInfo methodInfo, Type[] genericParameterTypes)
        {
            var type = _typeRepository.GetType(methodInfo);
            var constructorInfo = type.GetConstructor(BindingFlags.Public | BindingFlags.Instance, typeof(object), typeof(bool));

            if (!type.IsGenericTypeDefinition)
                return constructorInfo;

            var genericType = type.MakeGenericType(genericParameterTypes);

            return TypeBuilder.GetConstructor(genericType, constructorInfo);
        }


        private static void LoadArguments(ILGenerator ilGenerator, IList<Type> parameterTypes, LocalBuilder parametersLocalBuilder)
        {
            for (var index = 0; index < parameterTypes.Count; index++)
            {
                var parameterType = parameterTypes[index];

                ilGenerator.Emit(OpCodes.Ldloc, parametersLocalBuilder);
                ilGenerator.EmitLoadValue(index);
                ilGenerator.EmitLoadArgument(index + 1);

                if (parameterType.IsByRef)
                {
                    var elementType = parameterType.GetElementType();

                    ilGenerator.EmitLoadIndirect(parameterType);
                    ilGenerator.EmitBox(elementType);
                }
                else
                {
                    ilGenerator.EmitBox(parameterType);
                }

                ilGenerator.Emit(OpCodes.Stelem_Ref);
            }
        }


        private static void RestoreByReferenceArguments(ILGenerator ilGenerator, IList<Type> parameterTypes, LocalBuilder parametersLocalBuilder)
        {
            for (var index = 0; index < parameterTypes.Count; index++)
            {
                var argumentType = parameterTypes[index];

                if (!argumentType.IsByRef)
                    continue;

                var elementType = argumentType.GetElementType();

                ilGenerator.EmitLoadArgument(index + 1);
                ilGenerator.Emit(OpCodes.Ldloc, parametersLocalBuilder);
                ilGenerator.EmitLoadValue(index);
                ilGenerator.Emit(OpCodes.Ldelem_Ref);

                ilGenerator.EmitUnbox(elementType);
                ilGenerator.EmitStoreIndirect(argumentType);
            }
        }


        private bool IsOverrideMember(MemberInfo memberInfo)
        {
            var declaringType = memberInfo.DeclaringType;

            if (declaringType.IsInterface)
                return _interfaceTypes.Contains(declaringType);

            return declaringType.IsAssignableFrom(_parentType);
        }


        private bool IsExplicitMember(MemberInfo memberInfo)
        {
            var declaringType = memberInfo.DeclaringType;

            return declaringType.IsInterface && _interfaceTypes.Contains(declaringType);
        }

        #region ITypeBuilder Members

        public void AddCustomAttribute(ConstructorInfo constructorInfo, params object[] arguments)
        {
            if (constructorInfo == null)
                throw new ArgumentNullException("constructorInfo");

            if (arguments == null)
                throw new ArgumentNullException("arguments");

            _typeBuilder.SetCustomAttribute(constructorInfo, arguments);
        }

        public void AddInterface(Type interfaceType)
        {
            if (interfaceType == null)
                throw new ArgumentNullException("interfaceType");

            if (!interfaceType.IsInterface)
                throw new ArgumentException("类型{0}不是一个接口".FormatEx(interfaceType), "interfaceType");

            if (interfaceType.IsGenericTypeDefinition)
                throw new ArgumentException("接口类型{0}不能是一个泛型".FormatEx(interfaceType), "interfaceType");

            _typeBuilder.AddInterfaceImplementation(interfaceType);

            _interfaceTypes.Add(interfaceType);
        }

        /// <summary>
        /// 动态生成一个构造函数
        /// </summary>
        /// <param name="constructorInfo"></param>
        public void BuildConstructor(ConstructorInfo constructorInfo)
        {
            if (constructorInfo == null)
                throw new ArgumentNullException("constructorInfo");

            var constructorBuilder = _typeBuilder.DefineConstructor(constructorInfo, new[] { typeof(IInvocationHandler) }, new[] { "invocationHandler" });

            var ilGenerator = constructorBuilder.GetILGenerator();
            var parameterInfos = constructorInfo.GetParameters();

            ilGenerator.Emit(OpCodes.Ldarg_0);

            ilGenerator.EmitLoadArguments(2, parameterInfos.Length);

            ilGenerator.Emit(OpCodes.Call, constructorInfo);

            var invocationHandlerNotNullLabel = ilGenerator.DefineLabel();

            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.Emit(OpCodes.Brtrue, invocationHandlerNotNullLabel);
            ilGenerator.ThrowException(typeof(ArgumentNullException), "invocationHandler");
            ilGenerator.MarkLabel(invocationHandlerNotNullLabel);

            ilGenerator.Emit(OpCodes.Ldarg_0);

            ilGenerator.Emit(OpCodes.Ldarg_1);

            ilGenerator.Emit(OpCodes.Stfld, _invocationHandlerFieldInfo);

            ilGenerator.Emit(OpCodes.Ret);
        }

        public bool IsConcreteEvent(EventInfo eventInfo)
        {
            if (eventInfo == null)
                throw new ArgumentNullException("eventInfo");

            var methodInfos = eventInfo.GetAccessorMethods();

            return methodInfos.All(IsConcreteMethod);
        }

        public void BuildEvent(EventInfo eventInfo)
        {
            if (eventInfo == null)
                throw new ArgumentNullException("eventInfo");

            var isExplicit = IsExplicitMember(eventInfo);

            _typeBuilder.DefineEvent(eventInfo, isExplicit, BuildInterceptedMethod);
        }

        public bool IsConcreteProperty(PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
                throw new ArgumentNullException("propertyInfo");

            var methodInfos = propertyInfo.GetAccessorMethods();

            return methodInfos.All(IsConcreteMethod);
        }

        public void BuildProperty(PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
                throw new ArgumentNullException("propertyInfo");

            var isExplicit = IsExplicitMember(propertyInfo);

            _typeBuilder.DefineProperty(propertyInfo, isExplicit, BuildInterceptedMethod);
        }

        public bool IsConcreteMethod(MethodInfo methodInfo)
        {
            if (methodInfo == null)
                throw new ArgumentNullException("methodInfo");

            return !methodInfo.IsAbstract && IsOverrideMember(methodInfo);
        }

        public void BuildMethod(MethodInfo methodInfo)
        {
            if (methodInfo == null)
                throw new ArgumentNullException("methodInfo");

            var isExplicit = IsExplicitMember(methodInfo);

            BuildInterceptedMethod(methodInfo, isExplicit);
        }

        public Type CreateType()
        {
            return _typeBuilder.CreateType();
        }

        #endregion
    }
}
