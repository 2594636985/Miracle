using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace Miracle.Modularization.Aspects.Reflection.Emit
{
    public static class TypeBuilderExtensions
    {
        public static Type[] DefineGenericParameters(this TypeBuilder typeBuilder, Type[] genericTypes)
        {
            if (typeBuilder == null)
                throw new ArgumentNullException("typeBuilder");

            if (genericTypes == null)
                throw new ArgumentNullException("genericTypes");

            if (genericTypes.Length == 0)
                return Type.EmptyTypes;

            var genericParameterNames = Array.ConvertAll(genericTypes, t => t.Name);
            var genericParameterBuilders = typeBuilder.DefineGenericParameters(genericParameterNames);

            foreach (var genericParameterBuilder in genericParameterBuilders)
            {
                var genericType = genericTypes[genericParameterBuilder.GenericParameterPosition];

                // Set generic parameter attributes.
                genericParameterBuilder.SetGenericParameterAttributes(genericType.GenericParameterAttributes);

                // Set generic parameter constraints.
                var constraints = genericType.GetGenericParameterConstraints();

                if (constraints.Length == 0)
                    continue;

                var interfaceConstraints = new List<Type>();

                foreach (var constraint in constraints)
                {
                    if (constraint.IsInterface)
                        interfaceConstraints.Add(constraint);
                    else
                        genericParameterBuilder.SetBaseTypeConstraint(constraint);
                }

                genericParameterBuilder.SetInterfaceConstraints(interfaceConstraints.ToArray());
            }

            return Array.ConvertAll(genericParameterBuilders, b => (Type)b);
        }

        public static MethodBuilder DefineMethod(this TypeBuilder typeBuilder, MethodInfo methodInfo, bool isExplicit, bool isOverride)
        {
            if (typeBuilder == null)
                throw new ArgumentNullException("typeBuilder");

            if (methodInfo == null)
                throw new ArgumentNullException("methodInfo");

            var methodAttributes = methodInfo.Attributes & (MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.ReservedMask);

            if (isExplicit)
                methodAttributes |= MethodAttributes.Private;
            else
                methodAttributes |= methodInfo.Attributes & MethodAttributes.MemberAccessMask;

            if (isOverride)
            {
                methodAttributes |= MethodAttributes.Virtual;

                var declaringType = methodInfo.DeclaringType;

                if (declaringType.IsInterface)
                    methodAttributes |= MethodAttributes.NewSlot;
                else
                    methodAttributes |= MethodAttributes.ReuseSlot;
            }

            var methodName = isExplicit ? methodInfo.GetFullName() : methodInfo.Name;

            return typeBuilder.DefineMethod(methodName, methodAttributes, methodInfo.CallingConvention);
        }

        public static ConstructorBuilder DefineConstructor(this TypeBuilder typeBuilder, MethodAttributes methodAttributes, CallingConventions callingConvention, Type[] parameterTypes, string[] parameterNames)
        {
            if (typeBuilder == null)
                throw new ArgumentNullException("typeBuilder");

            if (parameterTypes == null)
                throw new ArgumentNullException("parameterTypes");

            if (parameterNames == null)
                throw new ArgumentNullException("parameterNames");

            if (parameterTypes.Length != parameterNames.Length)
                throw new ArgumentException("传入的参数类型和名字必须要相等");

            var constructorBuilder = typeBuilder.DefineConstructor(methodAttributes, callingConvention, parameterTypes);

            constructorBuilder.DefineParameters(parameterNames);

            return constructorBuilder;
        }

        public static ConstructorBuilder DefineConstructor(this TypeBuilder typeBuilder, ConstructorInfo constructorInfo, IEnumerable<Type> additionalParameterTypes, IEnumerable<string> additionalParameterNames)
        {
            if (typeBuilder == null)
                throw new ArgumentNullException("typeBuilder");

            if (constructorInfo == null)
                throw new ArgumentNullException("constructorInfo");

            if (additionalParameterTypes == null)
                throw new ArgumentNullException("additionalParameterTypes");

            if (additionalParameterNames == null)
                throw new ArgumentNullException("additionalParameterNames");

            var methodAttributes = MethodAttributes.Public |
                                   constructorInfo.Attributes & (MethodAttributes.HideBySig |
                                                                 MethodAttributes.SpecialName |
                                                                 MethodAttributes.ReservedMask);
            var parameterTypes = new List<Type>();

            parameterTypes.AddRange(additionalParameterTypes);

            var parentParameterTypes = constructorInfo.GetParameterTypes();

            parameterTypes.AddRange(parentParameterTypes);

            var constructorBuilder = typeBuilder.DefineConstructor(methodAttributes, constructorInfo.CallingConvention, parameterTypes.ToArray());

            constructorBuilder.DefineParameters(constructorInfo, additionalParameterNames);

            return constructorBuilder;
        }

        private static void DefineParameters(this ConstructorBuilder constructorBuilder, ConstructorInfo constructorInfo, IEnumerable<string> additionalParameterNames)
        {
            var position = 1;

            foreach (var additionalParameterName in additionalParameterNames)
            {
                constructorBuilder.DefineParameter(position++, ParameterAttributes.None, additionalParameterName);
            }

            var parameterInfos = constructorInfo.GetParameters();

            foreach (var parameterInfo in parameterInfos)
            {
                constructorBuilder.DefineParameter(parameterInfo.Position + position, parameterInfo.Attributes, parameterInfo.Name);
            }
        }

        public static void DefineEvent(this TypeBuilder typeBuilder, EventInfo eventInfo, bool isExplicit, Func<MethodInfo, bool, MethodBuilder> methodBuilderFactory)
        {
            if (typeBuilder == null)
                throw new ArgumentNullException("typeBuilder");

            if (eventInfo == null)
                throw new ArgumentNullException("eventInfo");

            if (methodBuilderFactory == null)
                throw new ArgumentNullException("methodBuilderFactory");

            var eventName = isExplicit ? eventInfo.GetFullName() : eventInfo.Name;

            var eventBuilder = typeBuilder.DefineEvent(
                eventName,
                eventInfo.Attributes,
                eventInfo.EventHandlerType);

            var addMethodInfo = eventInfo.GetAddMethod();
            var addMethodBuilder = methodBuilderFactory(addMethodInfo, isExplicit);

            eventBuilder.SetAddOnMethod(addMethodBuilder);

            var removeMethodInfo = eventInfo.GetRemoveMethod(true);
            var removeMethodBuilder = methodBuilderFactory(removeMethodInfo, isExplicit);

            eventBuilder.SetRemoveOnMethod(removeMethodBuilder);

            var raiseMethodInfo = eventInfo.GetRaiseMethod(true);

            if (raiseMethodInfo != null)
            {
                var methodBuilder = methodBuilderFactory(raiseMethodInfo, isExplicit);

                eventBuilder.SetRaiseMethod(methodBuilder);
            }

            var otherMethodInfos = eventInfo.GetOtherMethods(true);

            if (otherMethodInfos != null)
            {
                foreach (var otherMethodInfo in otherMethodInfos)
                {
                    var methodBuilder = methodBuilderFactory(otherMethodInfo, isExplicit);

                    eventBuilder.AddOtherMethod(methodBuilder);
                }
            }
        }

        private static void DefineParameters(this ConstructorBuilder constructorBuilder, IEnumerable<string> parameterNames)
        {
            var position = 1;

            foreach (var parameterName in parameterNames)
            {
                constructorBuilder.DefineParameter(position++, ParameterAttributes.None, parameterName);
            }
        }

        public static void DefineProperty(this TypeBuilder typeBuilder, PropertyInfo propertyInfo, bool isExplicit, Func<MethodInfo, bool, MethodBuilder> methodBuilderFactory)
        {
            if (typeBuilder == null)
                throw new ArgumentNullException("typeBuilder");

            if (propertyInfo == null)
                throw new ArgumentNullException("propertyInfo");

            if (methodBuilderFactory == null)
                throw new ArgumentNullException("methodBuilderFactory");

            // Define property.
            var propertyName = isExplicit ? propertyInfo.GetFullName() : propertyInfo.Name;
            var parameterTypes = propertyInfo.GetIndexParameterTypes();

            var propertyBuilder = typeBuilder.DefineProperty(
                propertyName,
                propertyInfo.Attributes,
                CallingConventions.HasThis,
                propertyInfo.PropertyType,
                null,
                null,
                parameterTypes,
                null,
                null);

            // Build property get method.
            var getMethodInfo = propertyInfo.GetGetMethod(true);

            if (getMethodInfo != null)
            {
                var methodBuilder = methodBuilderFactory(getMethodInfo, isExplicit);

                propertyBuilder.SetGetMethod(methodBuilder);
            }

            // Build property set method.
            var setMethodInfo = propertyInfo.GetSetMethod(true);

            if (setMethodInfo != null)
            {
                var methodBuilder = methodBuilderFactory(setMethodInfo, isExplicit);

                propertyBuilder.SetSetMethod(methodBuilder);
            }
        }


        public static void SetCustomAttribute(this TypeBuilder typeBuilder, ConstructorInfo constructorInfo, object[] arguments)
        {
            if (typeBuilder == null)
                throw new ArgumentNullException("typeBuilder");

            if (constructorInfo == null)
                throw new ArgumentNullException("constructorInfo");

            if (arguments == null)
                throw new ArgumentNullException("arguments");

            var customAttributeBuilder = new CustomAttributeBuilder(constructorInfo, arguments);

            typeBuilder.SetCustomAttribute(customAttributeBuilder);
        }


    }
}
