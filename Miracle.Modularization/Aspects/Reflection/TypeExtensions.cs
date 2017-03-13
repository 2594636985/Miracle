using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Miracle.Modularization.Aspects.Reflection
{
    public static class TypeExtensions
    {
        public static bool IsDelegate(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            return typeof(Delegate).IsAssignableFrom(type);
        }


        public static bool IsVoid(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            return (type == typeof(void));
        }


        /// <summary>
        ///  获得当前类型的方法信息
        /// </summary>
        /// <param name="type"></param>
        /// <param name="methodName"></param>
        /// <param name="bindingFlags"></param>
        /// <param name="parameterTypes"></param>
        /// <returns></returns>
        public static MethodInfo GetMethod(this Type type, string methodName, BindingFlags bindingFlags, params Type[] parameterTypes)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            if (methodName == null)
                throw new ArgumentNullException("methodName");

            if (parameterTypes == null)
                throw new ArgumentNullException("parameterTypes");

            var methodInfo = type.GetMethod(methodName, bindingFlags, null, parameterTypes, null);

            if (methodInfo == null)
                throw new MissingMethodException("在类型{0}上找不到方法{1}".FormatEx(type, methodName));

            return methodInfo;
        }

        public static ConstructorInfo GetConstructor(this Type type, BindingFlags bindingFlags, params Type[] parameterTypes)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            if (parameterTypes == null)
                throw new ArgumentNullException("parameterTypes");

            var constructorInfo = type.GetConstructor(bindingFlags, null, parameterTypes, null);

            if (constructorInfo == null)
                throw new MissingMethodException("类型{0}的构造器".FormatEx(type.Name));

            return constructorInfo;
        }


        public static Type MapGenericType(this Type type, Type[] genericTypes)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            if (genericTypes == null)
                throw new ArgumentNullException("genericTypes");

            if (!type.IsGenericParameter && !type.ContainsGenericParameters)
                return type;

            if (type.IsGenericParameter)
                return genericTypes[type.GenericParameterPosition];

            if (type.IsArray)
            {
                var elementType = type.GetElementType();
                var newElementType = elementType.MapGenericType(genericTypes);
                var rank = type.GetArrayRank();

                return (rank > 1) ? newElementType.MakeArrayType(rank) : newElementType.MakeArrayType();
            }

            if (type.IsByRef)
            {
                var elementType = type.GetElementType();
                var newElementType = elementType.MapGenericType(genericTypes);

                return newElementType.MakeByRefType();
            }

            if (type.IsPointer)
            {
                var elementType = type.GetElementType();
                var newElementType = elementType.MapGenericType(genericTypes);

                return newElementType.MakePointerType();
            }

            var genericTypeDefinition = type.IsGenericTypeDefinition ? type : type.GetGenericTypeDefinition();
            var genericArguments = type.MapGenericArguments(genericTypes);

            return genericTypeDefinition.MakeGenericType(genericArguments);
        }

        private static Type[] MapGenericArguments(this Type type, Type[] genericTypes)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            var genericArguments = type.GetGenericArguments();

            return Array.ConvertAll(genericArguments, t => t.MapGenericType(genericTypes));
        }
    }
}
