using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Injection
{
    /// <summary>
    /// 存在服务的注册容器
    /// </summary>
    public interface IContainer
    {
        void Inject(object instance);

        InternalFactory GetFactory(Identity identity);

        InternalFactory GetFactory(Type type);

        List<IInjector> GetInjectors(Type type);

        ConstructorInjector GetConstructor(Type type);

        object GetInstance(Type type);
    }
}
