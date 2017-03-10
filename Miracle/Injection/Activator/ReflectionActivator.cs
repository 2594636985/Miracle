using Miracle.Injection.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Injection.Activator
{
    public class ReflectionActivator : IActivator
    {
        public Type Type { private set; get; }

        public ReflectionActivator(Type type)
        {
            this.Type = type;
        }

        public object ActivateInstance(IContainer container)
        {
            ConstructorInjector constructorInjector = container.GetConstructor(this.Type);
            object instance = constructorInjector.Construct();

            container.Inject(instance);

            return instance;
        }
    }
}
