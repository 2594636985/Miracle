using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization.Security
{
    public interface IModuleSecurity
    {
        string Username { set; get; }

        string Password { set; get; }

        List<IPermission> Validate();
    }
}
