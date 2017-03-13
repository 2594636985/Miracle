using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Miracle.Modularization.Aspects.Reflection
{
    public static class MethodBaseExtensions
    {

        public static bool IsFromObject(this MethodBase methodBase)
        {
            return methodBase.DeclaringType == typeof(object);
        }

        /// <summary>
        /// 判断方法是否可以重写
        /// </summary>
        /// <param name="methodBase"></param>
        /// <returns></returns>
        public static bool CanOverride(this MethodBase methodBase)
        {
            if (methodBase == null)
                throw new ArgumentNullException("methodBase");

            if (!methodBase.IsVirtual || methodBase.IsFinal)
                return false;

            var declaringType = methodBase.DeclaringType;

            return !declaringType.IsSealed;
        }

        /// <summary>
        /// 获得方法的全名称
        /// </summary>
        /// <param name="methodBase"></param>
        /// <returns></returns>
        public static string GetFullName(this MethodBase methodBase)
        {
            if (methodBase == null)
                throw new ArgumentNullException("methodBase");

            var fullName = new StringBuilder();

            fullName.Append(methodBase.DeclaringType);
            fullName.Append(Type.Delimiter);
            fullName.Append(methodBase.Name);

            return fullName.ToString();
        }

        /// <summary>
        /// 返回方法的参数类型
        /// </summary>
        /// <param name="methodBase"></param>
        /// <returns></returns>
        public static Type[] GetParameterTypes(this MethodBase methodBase)
        {
            if (methodBase == null)
                throw new ArgumentNullException("methodBase");

            var parameterInfos = methodBase.GetParameters();

            return Array.ConvertAll(parameterInfos, p => p.ParameterType);
        }

        public static Type[] MapGenericParameterTypes(this MethodBase methodBase, Type[] genericTypes)
        {
            if (methodBase == null)
                throw new ArgumentNullException("methodBase");

            var parameterInfos = methodBase.GetParameters();

            return Array.ConvertAll(parameterInfos, p => p.ParameterType.MapGenericType(genericTypes));
        }
    }
}
