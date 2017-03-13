using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization.Aspects
{

    /// <summary>
    /// 代理工厂类
    /// </summary>
    public interface IProxyFactory
    {
        IProxyTemplate GetProxyTemplate(Type declaringType, IEnumerable<Type> interfaceTypes);
    }
}
