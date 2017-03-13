using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Miracle.Modularization.Aspects
{
    public interface IInvocationHandler
    {
        object Invoke(object target, MethodInfo methodInfo, object[] parameters);
    }
}
