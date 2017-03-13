using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Miracle.Modularization
{
    public class AssemblyInfo : ICloneable
    {
        public string Name { set; get; }
        public string Location { set; get; }
        public Version Version { set; get; }
        public object Clone()
        {
            return new AssemblyInfo()
            {
                Name = this.Name,
                Location = this.Location,
                Version = this.Version
            };
        }
    }
}
