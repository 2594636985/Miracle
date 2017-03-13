using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Miracle.Modularization.Aspects.Reflection.Emit
{
    public interface ITypeBuilder
    {
        void AddCustomAttribute(ConstructorInfo constructorInfo, params object[] arguments);

        void AddInterface(Type interfaceType);

        void BuildConstructor(ConstructorInfo constructorInfo);

        bool IsConcreteEvent(EventInfo eventInfo);

        void BuildEvent(EventInfo eventInfo);

        bool IsConcreteProperty(PropertyInfo propertyInfo);

        void BuildProperty(PropertyInfo propertyInfo);

        bool IsConcreteMethod(MethodInfo methodInfo);

        void BuildMethod(MethodInfo methodInfo);

        Type CreateType();
    }
}
