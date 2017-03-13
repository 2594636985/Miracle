using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization
{
    public class ModuleSetupInformation
    {
        public string ConnectionString { set; get; }

        public string AddInName { set; get; }

        public string StartModuleName { set; get; }

        public string AppLocation { set; get; }
    }
}
