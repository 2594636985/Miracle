using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization
{
    public interface INavigation
    {
        event Action<INavigation> OnMenuPageClicked;

        Type IndexType { get; }
    }
}
