using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace Miracle.Modularization.Aspects.Reflection.Emit
{
    public interface ITypeRepository
    {
        TypeBuilder DefineType(string typeName, Type parentType);

        Type GetType(MethodInfo methodInfo);
    }
}
