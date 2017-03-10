using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Injection.Factory
{
    public interface IActivator
    {
        object ActivateInstance(IContainer container);
    }
}
