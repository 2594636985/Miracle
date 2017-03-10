using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Injection.Factory
{
    public class InstanceActivator : IActivator
    {
        private readonly object _instance;

        public InstanceActivator(object instance)
        {
            this._instance = instance;
        }

        public object ActivateInstance(IContainer container)
        {
            return this._instance;
        }
    }
}
