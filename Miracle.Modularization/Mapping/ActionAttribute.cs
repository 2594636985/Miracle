using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization.Mapping
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class ActionAttribute : Attribute
    {
        public string ActionName { set; get; }
    }
}
