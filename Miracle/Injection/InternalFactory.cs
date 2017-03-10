using Miracle.Injection.Factory;
using Miracle.Injection.Lifecycle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Injection
{
    public class InternalFactory
    {
        public IActivator Activator { set; get; }

        public ILifecycle Lifecycle { set; get; }

        public object NewInstance(IContainer container)
        {
            if (this.Lifecycle == null)
                this.Lifecycle = new TransientLifecycle();

            return this.Lifecycle.InitializeInstance(() =>
            {
                return this.Activator.ActivateInstance(container);
            });
        }
    }
}
