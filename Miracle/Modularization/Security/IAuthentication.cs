using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization.Security
{
    public interface IAuthentication
    {
        string Name { get; }

        bool IsValidated { get; }

        List<IPermission> Permissions { get; }

        void Authenticate(IModuleSecurity validation);

        void Logout();
    }
}
