using Miracle.Modularization;
using Miracle.Modularization.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modulation.MainModule.Code
{
    using Modularization.Data;
    public class ModuleSecurity : ModuleSecurityBase
    {
        public IModule Module { private set; get; }

        public ModuleSecurity(IModule module)
        {
            this.Module = module;
        }

        public override List<IPermission> Validate()
        {
            List<IPermission> permissions = new List<IPermission>();
            using (DbContext db = this.Module.GetDbContextEx())
            {

            }

            return permissions;
        }
    }
}
