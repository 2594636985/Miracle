using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Miracle.Modularization.Aspects.Reflection
{
    public static class PropertyInfoExtensions
    {
        public static bool CanOverride(this PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
                throw new ArgumentNullException("propertyInfo");

            var methodInfos = propertyInfo.GetAccessorMethods();

            return methodInfos.All(m => m.CanOverride());
        }

      
        public static IEnumerable<MethodInfo> GetAccessorMethods(this PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
                throw new ArgumentNullException("propertyInfo");

            var methodInfos = new List<MethodInfo>();

            var getMethodInfo = propertyInfo.GetGetMethod(true);

            if (getMethodInfo != null)
                methodInfos.Add(getMethodInfo);

            var setMethodInfo = propertyInfo.GetSetMethod(true);

            if (setMethodInfo != null)
                methodInfos.Add(setMethodInfo);

            return methodInfos;
        }

      
        public static string GetFullName(this PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
                throw new ArgumentNullException("propertyInfo");

            var fullName = new StringBuilder();

            fullName.Append(propertyInfo.DeclaringType);
            fullName.Append(Type.Delimiter);
            fullName.Append(propertyInfo.Name);

            return fullName.ToString();
        }

        public static Type[] GetIndexParameterTypes(this PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
                throw new ArgumentNullException("propertyInfo");

            var indexParameterInfos = propertyInfo.GetIndexParameters();

            return Array.ConvertAll(indexParameterInfos, p => p.ParameterType);
        }
    }
}
