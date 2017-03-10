using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Injection.Lifecycle
{
    public interface ILifecycle
    {
        object InitializeInstance(Func<object> newInstanceResolver);
    }
}
