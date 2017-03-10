using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Injection.Lifecycle
{
    public class SingletonLifecycle : ILifecycle
    {
        private readonly object _lock = new object();
        private object _instance;
        public object InitializeInstance(Func<object> newInstanceResolver)
        {
            lock (_lock)
            {
                if (this._instance == null)
                {
                    this._instance = newInstanceResolver();
                }

                return this._instance;
            }
        }
    }
}
