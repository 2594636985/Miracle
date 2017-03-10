using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Injection
{
    public class ParameterInjector
    {
        public InternalFactory InternalFactory { private set; get; }
        public IContainer Container { private set; get; }

        public ParameterInjector(IContainer container, InternalFactory internalFactory)
        {
            this.Container = container;
            this.InternalFactory = internalFactory;
        }

        public object inject()
        {
            return this.InternalFactory.NewInstance(this.Container);
        }
    }
}
