using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Miracle.Modulation.MainModule
{
    public static class ConstantStatic
    {
        public static string RootLocation
        {
            get
            {
                return Path.GetDirectoryName(typeof(ConstantStatic).Assembly.Location);
            }
        }
    }
}
