using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Miracle
{
    public static partial class MiracleExtension
    {
        public static bool IsNullOrEmptyEx(this ICollection array)
        {
            return array == null || array.Count == 0;
        }

    }
}
