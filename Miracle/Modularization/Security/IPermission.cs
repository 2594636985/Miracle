using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization.Security
{
    public interface IPermission
    {
        string ModuleName { get; }
    }
}
