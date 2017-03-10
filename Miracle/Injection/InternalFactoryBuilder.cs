
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Injection
{
    using Lifecycle;

    public class InternalFactoryBuilder
    {
        public InternalFactory InternalFactory { private set; get; }

        public InternalFactoryBuilder(InternalFactory internalFactory)
        {
            this.InternalFactory = internalFactory;
        }

        public InternalFactoryBuilder TransientLifecycle()
        {
            this.InternalFactory.Lifecycle = new TransientLifecycle();
            return this;
        }
        public InternalFactoryBuilder SingletonLifecycle()
        {
            this.InternalFactory.Lifecycle = new SingletonLifecycle();
            return this;
        }

    }
}
