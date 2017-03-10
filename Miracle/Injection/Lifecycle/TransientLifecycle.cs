using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Injection.Lifecycle
{
    public class TransientLifecycle : ILifecycle
    {
        public object InitializeInstance(Func<object> newInstanceResolver)
        {
            return newInstanceResolver();
        }
    }
}
