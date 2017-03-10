using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Injection
{
    /// <summary>
    /// 注入器
    /// </summary>
    public interface IInjector
    {
        IContainer Container { get; }
        void Inject(Object instance);
    }
}
