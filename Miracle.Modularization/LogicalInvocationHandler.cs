using Miracle.Modularization.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Miracle.Modularization
{

    /// <summary>
    /// 业务总的入口处，可以处理异常信息
    /// </summary>
    public class LogicalInvocationHandler : IInvocationHandler
    {
        public object Invoke(object target, MethodInfo methodInfo, object[] parameters)
        {
            return methodInfo.Invoke(target, parameters);
        }

    }
}
