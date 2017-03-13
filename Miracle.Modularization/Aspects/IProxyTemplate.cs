using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Miracle.Modularization.Aspects
{
    /// <summary>
    /// 代理模板类
    /// </summary>
    public interface IProxyTemplate
    {
        Type DeclaringType { get; }

        Type ParentType { get; }

        Type ImplementationType { get; }

        IEnumerable<Type> ImplementedInterfaces { get; }

        IEnumerable<EventInfo> InterceptedEvents { get; }

        IEnumerable<PropertyInfo> InterceptedProperties { get; }

        IEnumerable<MethodInfo> InterceptedMethods { get; }

        object AdaptProxy(Type interfaceType, object proxy);

        object CreateProxy(IInvocationHandler invocationHandler, params object[] arguments);
    }

    /// <summary>
    /// 泛型代理模板类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IProxyTemplate<out T> : IProxyTemplate where T : class
    {
        new T CreateProxy(IInvocationHandler invocationHandler, params object[] arguments);
    }
}
