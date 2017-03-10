using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization
{
    /// <summary>
    /// 用于表示依赖项
    /// </summary>
    public interface IDependency
    {

    }

    /// <summary>
    /// 用于表示注入依赖项
    /// </summary>
    public interface IInjectionDependency : IDependency
    {

    }
}
