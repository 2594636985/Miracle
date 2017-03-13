using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization.Security
{
    public class Authentication : IAuthentication
    {
        public bool IsValidated { private set; get; }

        public string Name { private set; get; }

        public List<IPermission> Permissions { private set; get; }

        public void Authenticate(IModuleSecurity validation)
        {
            this.Name = validation.Username;
            this.Permissions = validation.Validate();
        }


        public void Logout()
        {
            this.IsValidated = false;
            this.Name = string.Empty;
            this.Permissions.Clear();
        }
    }
}
