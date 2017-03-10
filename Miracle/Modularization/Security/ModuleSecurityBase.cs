using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization.Security
{
    public abstract class ModuleSecurityBase : IModuleSecurity
    {
        public string Username { set; get; }

        public string Password { set; get; }

        public abstract List<IPermission> Validate();
    }
}
