using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Miracle.Modularization.Aspects.Reflection.Emit
{
    public interface ITypeFactory
    {
        Type CreateType(MethodInfo methodInfo);
    }
}
