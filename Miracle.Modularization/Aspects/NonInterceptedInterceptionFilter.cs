using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Miracle.Modularization.Aspects
{
    /// <summary>
    /// 没有任何过滤器
    /// </summary>
    public sealed class NonInterceptedInterceptionFilter : IInterceptionFilter
    {
        private const string DestructorMethodName = "Finalize";

        public bool AcceptEvent(EventInfo eventInfo)
        {
            return !eventInfo.IsDefined(typeof(NonInterceptedAttribute), false);
        }

        public bool AcceptProperty(PropertyInfo propertyInfo)
        {
            return !propertyInfo.IsDefined(typeof(NonInterceptedAttribute), false);
        }

        public bool AcceptMethod(MethodInfo methodInfo)
        {
            if (methodInfo.IsDefined(typeof(NonInterceptedAttribute), false))
                return false;

         
            if (methodInfo.DeclaringType != typeof(object))
                return true;

            return !String.Equals(methodInfo.Name, DestructorMethodName);
        }

    }
}
