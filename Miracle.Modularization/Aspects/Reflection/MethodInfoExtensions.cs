using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Miracle.Modularization.Aspects.Reflection
{
    public static class MethodInfoExtensions
    {

        public static MethodInfo MapGenericMethod(this MethodInfo methodInfo, Type[] genericTypes)
        {
            if (methodInfo == null)
                throw new ArgumentNullException("methodInfo");

            if (genericTypes == null)
                throw new ArgumentNullException("genericTypes");

            return methodInfo.IsGenericMethodDefinition ? methodInfo.MakeGenericMethod(genericTypes) : methodInfo;
        }

    
        public static Type MapGenericReturnType(this MethodInfo methodInfo, Type[] genericTypes)
        {
            if (methodInfo == null)
                throw new ArgumentNullException("methodInfo");

            var returnType = methodInfo.ReturnType;

            return returnType.MapGenericType(genericTypes);
        }
    }
}
