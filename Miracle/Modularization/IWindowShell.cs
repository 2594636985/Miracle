using Miracle.Modularization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization
{
    public interface IWindowShell
    {
        IModule Module { set; get; }
    }
}
