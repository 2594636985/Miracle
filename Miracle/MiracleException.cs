using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle
{
    public class MiracleException : Exception
    {
        public MiracleException(string message)
            : base(message)
        {

        }
    }
}
