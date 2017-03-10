
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Injection
{
    using Lifecycle;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
    public class InjectionScopeAttribute : Attribute
    {
        public InjectionScope Value { set; get; }
    }

}
