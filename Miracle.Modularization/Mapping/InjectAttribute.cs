using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization.Mapping
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class InjectAttribute : Attribute
    {

    }
}
