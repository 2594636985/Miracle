using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Miracle
{
    public static partial class MiracleExtension
    {
        public static List<Type> GetTypesEx(this Assembly assembly, Type type)
        {
            return assembly.GetExportedTypes().Where(t => type.IsAssignableFrom(t) && type != t).ToList();
        }

        public static List<Type> GetTypesByAttributeEx(this Assembly assembly, Type attributeType)
        {
            List<Type> attributeTypes = new List<Type>();
            Type[] exportedTypes = assembly.GetExportedTypes();

            foreach (Type type in exportedTypes)
            {
                object[] attributes = type.GetCustomAttributes(attributeType, true);
                if (attributes != null && attributes.Length > 0)
                {
                    attributeTypes.Add(type);
                }
            }

            return attributeTypes;
        }



        public static List<MethodInfo> GetMethodInfoByAttributeEx(this Type type, Type attributeType)
        {
            List<MethodInfo> methodInfos = new List<MethodInfo>();
            MethodInfo[] methodInfoArr = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);

            foreach (MethodInfo methodInfo in methodInfoArr)
            {
                object[] attributes = methodInfo.GetCustomAttributes(attributeType, true);
                if (attributes != null && attributes.Length > 0)
                {
                    methodInfos.Add(methodInfo);
                }
            }

            return methodInfos;
        }

        public static TAttribute GetCustomAttributeEx<TAttribute>(this PropertyInfo propertyInfo)
        {
            object[] attributes = propertyInfo.GetCustomAttributes(typeof(TAttribute), true);

            if (attributes != null && attributes.Length > 0)
                return (TAttribute)attributes[0];

            return default(TAttribute);
        }


        public static TAttribute GetCustomAttributeEx<TAttribute>(this Type type)
        {
            object[] attributes = type.GetCustomAttributes(typeof(TAttribute), true);

            if (attributes != null && attributes.Length > 0)
                return (TAttribute)attributes[0];

            return default(TAttribute);
        }

        public static TAttribute GetCustomAttributeEx<TAttribute>(this MethodInfo methodInfo)
        {
            object[] attributes = methodInfo.GetCustomAttributes(typeof(TAttribute), true);

            if (attributes != null && attributes.Length > 0)
                return (TAttribute)attributes[0];

            return default(TAttribute);
        }

        public static TAttribute GetCustomAttributeEx<TAttribute>(this ConstructorInfo constructorInfo)
        {
            object[] attributes = constructorInfo.GetCustomAttributes(typeof(TAttribute), true);

            if (attributes != null && attributes.Length > 0)
                return (TAttribute)attributes[0];

            return default(TAttribute);
        }

        public static TAttribute GetCustomAttributeEx<TAttribute>(this ParameterInfo parameterInfo)
        {
            object[] attributes = parameterInfo.GetCustomAttributes(typeof(TAttribute), true);

            if (attributes != null && attributes.Length > 0)
                return (TAttribute)attributes[0];

            return default(TAttribute);
        }
    }
}
