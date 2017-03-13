using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization.Aspects.Definitions
{
    public sealed class InterfaceProxyDefinition : ProxyDefinitionBase
    {
        public InterfaceProxyDefinition(Type declaringType, IEnumerable<Type> interfaceTypes)
            : base(declaringType, typeof(object), interfaceTypes)
        {
        }

        public override IEnumerable<Type> ImplementedInterfaces
        {
            get { return DeclaringInterfaces.Concat(AdditionalInterfaces); }
        }

        public override void AcceptVisitor(IProxyDefinitionVisitor proxyDefinitionVisitor)
        {
            base.AcceptVisitor(proxyDefinitionVisitor);

            proxyDefinitionVisitor.VisitInterfaces(DeclaringInterfaces);

            proxyDefinitionVisitor.VisitMembers(ParentType);
        }

        public override object UnwrapProxy(object proxy)
        {
            if (proxy == null)
                throw new ArgumentNullException("proxy");

            return proxy;
        }

        public override object CreateProxy(Type type, object[] arguments)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            if (arguments == null)
                throw new ArgumentNullException("arguments");

            return Activator.CreateInstance(type, arguments);
        }

    }
}
