using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Injection
{
    /// <summary>
    /// Ioc异常类
    /// </summary>
    public class InjectionException : Exception
    {
        public InjectionException(string message)
            : base(message)
        {

        }
    }
}
