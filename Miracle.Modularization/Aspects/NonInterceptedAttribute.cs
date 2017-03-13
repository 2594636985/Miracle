using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization.Aspects
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Event | AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public sealed class NonInterceptedAttribute : Attribute
    {

    }
}
