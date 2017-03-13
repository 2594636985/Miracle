using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization.Aspects.Definitions
{
    public interface IProxyDefinition
    {
        Type DeclaringType { get; }

        Type ParentType { get; }
       
        IEnumerable<Type> ImplementedInterfaces { get; }

        void AcceptVisitor(IProxyDefinitionVisitor proxyDefinitionVisitor);
     
        object UnwrapProxy(object proxy);

        object CreateProxy(Type type, object[] arguments);
    }
}
