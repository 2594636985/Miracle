using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace Miracle.Modularization.Aspects.Reflection.Emit
{
    public sealed class MethodInfoTypeFactory : ITypeFactory
    {
        private static readonly MethodInfo MethodBaseGetMethodFromHandleMethodInfo = typeof(MethodBase).GetMethod("GetMethodFromHandle", BindingFlags.Public | BindingFlags.Static, typeof(RuntimeMethodHandle), typeof(RuntimeTypeHandle));
        private static readonly ConstructorInfo MethodInfoBaseConstructorInfo = typeof(MethodInfoBase).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, typeof(object), typeof(MethodInfo), typeof(bool));
        private static readonly MethodInfo MethodInfoBaseInvokeBaseMethodInfo = typeof(MethodInfoBase).GetMethod("InvokeBase", BindingFlags.NonPublic | BindingFlags.Instance, typeof(object), typeof(object[]));
        private static readonly MethodInfo MethodInfoBaseInvokeVirtualMethodInfo = typeof(MethodInfoBase).GetMethod("InvokeVirtual", BindingFlags.NonPublic | BindingFlags.Instance, typeof(object), typeof(object[]));
        private readonly ITypeRepository _typeRepository;

        public MethodInfoTypeFactory(ITypeRepository typeRepository)
        {
            if (typeRepository == null)
                throw new ArgumentNullException("typeRepository");

            _typeRepository = typeRepository;
        }

        private static void BuildTypeInitializer(TypeBuilder typeBuilder, MethodInfo methodInfo, Type[] genericParameterTypes, FieldInfo methodFieldInfo)
        {
            var typeInitializer = typeBuilder.DefineConstructor(MethodAttributes.Private | MethodAttributes.Static | MethodAttributes.SpecialName, CallingConventions.Standard, null);

            var ilGenerator = typeInitializer.GetILGenerator();

            var targetMethodInfo = methodInfo.MapGenericMethod(genericParameterTypes);
            var declaringType = targetMethodInfo.DeclaringType;

            ilGenerator.Emit(OpCodes.Ldtoken, targetMethodInfo);
            ilGenerator.Emit(OpCodes.Ldtoken, declaringType);
            ilGenerator.EmitCall(MethodBaseGetMethodFromHandleMethodInfo);

            ilGenerator.Emit(OpCodes.Castclass, typeof(MethodInfo));
            ilGenerator.Emit(OpCodes.Stsfld, methodFieldInfo);

            ilGenerator.Emit(OpCodes.Ret);
        }

     
        private static void BuildConstructor(TypeBuilder typeBuilder, FieldInfo methodFieldInfo)
        {
            var constructorBuilder = typeBuilder.DefineConstructor( MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.SpecialName,  MethodInfoBaseConstructorInfo.CallingConvention,
                new[] { typeof(object), typeof(bool) },
                new[] { "source", "isOverride" });

            var ilGenerator = constructorBuilder.GetILGenerator();

            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.Emit(OpCodes.Ldsfld, methodFieldInfo);
            ilGenerator.Emit(OpCodes.Ldarg_2);
            ilGenerator.Emit(OpCodes.Call, MethodInfoBaseConstructorInfo);
            ilGenerator.Emit(OpCodes.Ret);
        }

        private static void BuildInvokeMethod(TypeBuilder typeBuilder, MethodInfo methodInfo, Type[] genericParameterTypes, bool isVirtual)
        {
            var invokeMethodInfo = isVirtual ? MethodInfoBaseInvokeVirtualMethodInfo : MethodInfoBaseInvokeBaseMethodInfo;

            // Define method.
            var methodBuilder = typeBuilder.DefineMethod(invokeMethodInfo, false, true);

            methodBuilder.DefineParameters(invokeMethodInfo);

            // Implement method.
            var ilGenerator = methodBuilder.GetILGenerator();

            // Load target object.
            ilGenerator.Emit(OpCodes.Ldarg_1);

            // Load parameter values.
            var parameterTypes = methodInfo.MapGenericParameterTypes(genericParameterTypes);
            var parameterValueLocalBuilders = new LocalBuilder[parameterTypes.Length];

            LoadParameterValues(ilGenerator, 2, parameterTypes, parameterValueLocalBuilders);

            // Call target method.
            var targetMethodInfo = methodInfo.MapGenericMethod(genericParameterTypes);

            ilGenerator.Emit(isVirtual ? OpCodes.Callvirt : OpCodes.Call, targetMethodInfo);

            // Restore by reference parameter values.
            RestoreByReferenceParameterValues(ilGenerator, 2, parameterTypes, parameterValueLocalBuilders);

            // Handle return value.
            var returnType = methodInfo.MapGenericReturnType(genericParameterTypes);

            if (returnType.IsVoid())
                ilGenerator.Emit(OpCodes.Ldnull);
            else
                ilGenerator.EmitBox(returnType);

            ilGenerator.Emit(OpCodes.Ret);
        }

       
        private static void LoadParameterValues(ILGenerator ilGenerator, int argumentIndex, IList<Type> parameterTypes, IList<LocalBuilder> parameterValueLocalBuilders)
        {
            for (var index = 0; index < parameterTypes.Count; index++)
            {
                var parameterType = parameterTypes[index];

                ilGenerator.EmitLoadArgument(argumentIndex);
                ilGenerator.EmitLoadValue(index);
                ilGenerator.Emit(OpCodes.Ldelem_Ref);

                if (parameterType.IsByRef)
                {
                    var elementType = parameterType.GetElementType();
                    var parameterLocalBuilder = ilGenerator.DeclareLocal(elementType);

                    ilGenerator.EmitUnbox(elementType);
                    ilGenerator.Emit(OpCodes.Stloc, parameterLocalBuilder);
                    ilGenerator.Emit(OpCodes.Ldloca, parameterLocalBuilder);

                    parameterValueLocalBuilders[index] = parameterLocalBuilder;
                }
                else
                {
                    ilGenerator.EmitUnbox(parameterType);
                }
            }
        }

       
        private static void RestoreByReferenceParameterValues(ILGenerator ilGenerator, int argumentIndex, IList<Type> parameterTypes, IList<LocalBuilder> parameterValueLocalBuilders)
        {
            for (var index = 0; index < parameterTypes.Count; index++)
            {
                var parameterType = parameterTypes[index];

                if (!parameterType.IsByRef)
                    continue;

                var parameterLocalBuilder = parameterValueLocalBuilders[index];
                var elementType = parameterType.GetElementType();

                ilGenerator.EmitLoadArgument(argumentIndex);
                ilGenerator.EmitLoadValue(index);
                ilGenerator.Emit(OpCodes.Ldloc, parameterLocalBuilder);
                ilGenerator.EmitBox(elementType);
                ilGenerator.Emit(OpCodes.Stelem_Ref);
            }
        }

        #region ITypeFactory Members

        public Type CreateType(MethodInfo methodInfo)
        {
            if (methodInfo == null)
                throw new ArgumentNullException("methodInfo");

            var typeBuilder = _typeRepository.DefineType("MethodInfo", typeof(MethodInfoBase));

            // Define generic parameters.
            var genericParameterTypes = typeBuilder.DefineGenericParameters(methodInfo.GetGenericArguments());

            var methodFieldInfo = typeBuilder.DefineField(
                "TargetMethod",
                typeof(MethodInfo),
                FieldAttributes.Private | FieldAttributes.Static | FieldAttributes.InitOnly);

            BuildTypeInitializer(typeBuilder, methodInfo, genericParameterTypes, methodFieldInfo);

            BuildConstructor(typeBuilder, methodFieldInfo);

            if (!methodInfo.IsAbstract && methodInfo.CanOverride())
                BuildInvokeMethod(typeBuilder, methodInfo, genericParameterTypes, false);

            BuildInvokeMethod(typeBuilder, methodInfo, genericParameterTypes, true);

            return typeBuilder.CreateType();
        }

        #endregion
    }
}
