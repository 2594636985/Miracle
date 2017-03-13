using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Miracle.Modularization.Aspects
{
    public interface IInterceptionFilter
    {
        bool AcceptEvent(EventInfo eventInfo);

        bool AcceptProperty(PropertyInfo propertyInfo);

        bool AcceptMethod(MethodInfo methodInfo);
    }
}
