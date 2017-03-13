using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Miracle.Modularization.Aspects.Definitions
{
    public sealed class DelegateProxyDefinition : ProxyDefinitionBase
    {
        private const string DelegateMethodName = "Invoke";

        public DelegateProxyDefinition(Type declaringType, IEnumerable<Type> interfaceTypes)
            : base(declaringType, typeof(object), interfaceTypes)
        {
        }

        #region IProxyDefinition Members

        public override IEnumerable<Type> ImplementedInterfaces
        {
            get { return AdditionalInterfaces; }
        }

        public override void AcceptVisitor(IProxyDefinitionVisitor proxyDefinitionVisitor)
        {
            base.AcceptVisitor(proxyDefinitionVisitor);

            var methodInfo = DeclaringType.GetMethod(DelegateMethodName, BindingFlags.Public | BindingFlags.Instance);

            proxyDefinitionVisitor.VisitMethod(methodInfo);
            proxyDefinitionVisitor.VisitMembers(ParentType);
        }

        public override object UnwrapProxy(object proxy)
        {
            if (proxy == null)
                throw new ArgumentNullException("proxy");

            var delegateProxy = proxy as Delegate;

            if (delegateProxy == null)
                throw new InvalidOperationException("无效的代理类型");

            var target = delegateProxy.Target;

            if (target == null)
                throw new InvalidOperationException("无效的代理类型");

            return target;
        }

        public override object CreateProxy(Type type, object[] arguments)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            if (arguments == null)
                throw new ArgumentNullException("arguments");

            var target = Activator.CreateInstance(type, arguments);

            return Delegate.CreateDelegate(DeclaringType, target, DelegateMethodName);
        }

        #endregion
    }
}
