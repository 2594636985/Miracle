using Miracle.Modularization.Aspects.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Miracle.Modularization.Aspects
{
    public class ProxyTemplate : IProxyTemplate
    {
        private readonly IProxyDefinition _proxyDefinition;
        private readonly Type _implementationType;
        private readonly ICollection<EventInfo> _eventInfos;
        private readonly ICollection<PropertyInfo> _propertyInfos;
        private readonly ICollection<MethodInfo> _methodInfos;
        public ProxyTemplate(IProxyDefinition proxyDefinition, Type implementationType, ICollection<EventInfo> eventInfos, ICollection<PropertyInfo> propertyInfos, ICollection<MethodInfo> methodInfos)
        {
            if (proxyDefinition == null)
                throw new ArgumentNullException("proxyDefinition");

            if (implementationType == null)
                throw new ArgumentNullException("implementationType");

            if (eventInfos == null)
                throw new ArgumentNullException("eventInfos");

            if (propertyInfos == null)
                throw new ArgumentNullException("propertyInfos");

            if (methodInfos == null)
                throw new ArgumentNullException("methodInfos");

            _proxyDefinition = proxyDefinition;
            _implementationType = implementationType;
            _eventInfos = eventInfos;
            _propertyInfos = propertyInfos;
            _methodInfos = methodInfos;
        }

        #region IProxyTemplate Members

        public Type DeclaringType
        {
            get { return _proxyDefinition.DeclaringType; }
        }

        public Type ParentType
        {
            get { return _proxyDefinition.ParentType; }
        }

        public Type ImplementationType
        {
            get { return _implementationType; }
        }

        public IEnumerable<Type> ImplementedInterfaces
        {
            get { return _proxyDefinition.ImplementedInterfaces; }
        }

        public IEnumerable<EventInfo> InterceptedEvents
        {
            get { return _eventInfos; }
        }

        public IEnumerable<PropertyInfo> InterceptedProperties
        {
            get { return _propertyInfos; }
        }

        public IEnumerable<MethodInfo> InterceptedMethods
        {
            get { return _methodInfos; }
        }

        public object AdaptProxy(Type interfaceType, object proxy)
        {
            if (interfaceType == null)
                throw new ArgumentNullException("interfaceType");

            if (!interfaceType.IsInterface)
                throw new ArgumentException("类型{0}不是一个接口".FormatEx(interfaceType), "interfaceType");

            var instance = _proxyDefinition.UnwrapProxy(proxy);
            var instanceType = instance.GetType();

            if ((instanceType != _implementationType) || !interfaceType.IsAssignableFrom(instanceType))
                throw new InvalidOperationException("这个接口类型不合适代理");

            return instance;
        }

        public object CreateProxy(IInvocationHandler invocationHandler, params object[] arguments)
        {
            if (invocationHandler == null)
                throw new ArgumentNullException("invocationHandler");

            if (arguments == null)
                throw new ArgumentNullException("arguments");

            var constructorArguments = new List<object> { invocationHandler };

            constructorArguments.AddRange(arguments);

            return _proxyDefinition.CreateProxy(_implementationType, constructorArguments.ToArray());
        }

        #endregion
    }


    public sealed class ProxyTemplate<T> : IProxyTemplate<T> where T : class
    {
        private readonly IProxyTemplate _proxyTemplate;
        public ProxyTemplate(IProxyTemplate proxyTemplate)
        {
            if (proxyTemplate == null)
                throw new ArgumentNullException("proxyTemplate");

            _proxyTemplate = proxyTemplate;
        }

        #region IProxyTemplate Members

        public Type DeclaringType
        {
            get { return _proxyTemplate.DeclaringType; }
        }

        public Type ParentType
        {
            get { return _proxyTemplate.ParentType; }
        }

        public Type ImplementationType
        {
            get { return _proxyTemplate.ImplementationType; }
        }

        public IEnumerable<Type> ImplementedInterfaces
        {
            get { return _proxyTemplate.ImplementedInterfaces; }
        }

        public IEnumerable<EventInfo> InterceptedEvents
        {
            get { return _proxyTemplate.InterceptedEvents; }
        }

        public IEnumerable<PropertyInfo> InterceptedProperties
        {
            get { return _proxyTemplate.InterceptedProperties; }
        }

        public IEnumerable<MethodInfo> InterceptedMethods
        {
            get { return _proxyTemplate.InterceptedMethods; }
        }

        public object AdaptProxy(Type interfaceType, object proxy)
        {
            return _proxyTemplate.AdaptProxy(interfaceType, proxy);
        }

        object IProxyTemplate.CreateProxy(IInvocationHandler invocationHandler, params object[] arguments)
        {
            return _proxyTemplate.CreateProxy(invocationHandler, arguments);
        }

        #endregion

        #region IProxyTemplate<T> Members

        public T CreateProxy(IInvocationHandler invocationHandler, params object[] arguments)
        {
            return (T)_proxyTemplate.CreateProxy(invocationHandler, arguments);
        }

        #endregion
    }
}
