using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace Miracle.Modularization.Aspects.Reflection.Emit
{
    public static class MethodBuilderExtensions
    {
        public static void DefineParameters(this MethodBuilder methodBuilder, MethodInfo methodInfo)
        {
            if (methodBuilder == null)
                throw new ArgumentNullException("methodBuilder");

            var genericParameterTypes = methodBuilder.DefineGenericParameters(methodInfo);

            methodBuilder.DefineParameters(methodInfo, genericParameterTypes);
        }


        public static void DefineParameters(this MethodBuilder methodBuilder, MethodInfo methodInfo, Type[] genericTypes)
        {
            if (methodBuilder == null)
                throw new ArgumentNullException("methodBuilder");

            if (methodInfo == null)
                throw new ArgumentNullException("methodInfo");

            var parameterTypes = methodInfo.MapGenericParameterTypes(genericTypes);
            var returnType = methodInfo.MapGenericReturnType(genericTypes);

            methodBuilder.SetReturnType(returnType);
            methodBuilder.SetParameters(parameterTypes);

            var parameterInfos = methodInfo.GetParameters();

            foreach (var parameterInfo in parameterInfos)
            {
                methodBuilder.DefineParameter(parameterInfo.Position + 1, parameterInfo.Attributes, parameterInfo.Name);
            }
        }


        public static Type[] DefineGenericParameters(this MethodBuilder methodBuilder, MethodBase methodBase)
        {
            if (methodBuilder == null)
                throw new ArgumentNullException("methodBuilder");

            if (methodBase == null)
                throw new ArgumentNullException("methodBase");

            if (!methodBase.IsGenericMethodDefinition)
                return Type.EmptyTypes;

            var genericParameterTypes = methodBase.GetGenericArguments();
            var genericParameterNames = Array.ConvertAll(genericParameterTypes, t => t.Name);
            var genericParameterBuilders = methodBuilder.DefineGenericParameters(genericParameterNames);

            foreach (var genericParameterBuilder in genericParameterBuilders)
            {
                var genericParameterType = genericParameterTypes[genericParameterBuilder.GenericParameterPosition];

                genericParameterBuilder.SetGenericParameterAttributes(genericParameterType.GenericParameterAttributes);

                var genericParameterConstraints = genericParameterType.GetGenericParameterConstraints();
                var baseTypeConstraint = genericParameterConstraints.FirstOrDefault(t => t.IsClass);

                if (baseTypeConstraint != null)
                    genericParameterBuilder.SetBaseTypeConstraint(baseTypeConstraint);

                var interfaceConstraints = genericParameterConstraints.Where(t => t.IsInterface).ToArray();

                genericParameterBuilder.SetInterfaceConstraints(interfaceConstraints);
            }

            return Array.ConvertAll(genericParameterBuilders, b => (Type)b);
        }
    }
}
