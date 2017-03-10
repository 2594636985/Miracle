using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization
{
    public class Session : ConcurrentDictionary<string, object>
    {
        public Session()
        {
            
        }
    }
}
