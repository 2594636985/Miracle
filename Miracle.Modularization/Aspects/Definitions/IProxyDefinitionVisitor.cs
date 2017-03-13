using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Miracle.Modularization.Aspects.Definitions
{
    public interface IProxyDefinitionVisitor
    {
        void VisitInterface(Type interfaceType);
     
        void VisitConstructor(ConstructorInfo constructorInfo);
      
        void VisitEvent(EventInfo eventInfo);

        void VisitProperty(PropertyInfo propertyInfo);

        void VisitMethod(MethodInfo methodInfo);
    }
}
