using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization.Data
{
    public static class DbExtension
    {
        public static DbContext GetDbContextEx(this IModule module)
        {
            return new DbContext(module.ConnectionString);
        }
    }
}
