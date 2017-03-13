using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Miracle.Modularization
{
    public static class ModuleExtension
    {
        //public static Uri GetViewModuleUriEx(this Module module, string uriString)
        //{

        //    if (Path.IsPathRooted(uriString))
        //    {
        //        return new Uri(module.StartType, UriKind.Absolute);
        //    }
        //    else
        //    {
        //        string mUriString = uriString.StartsWith("/") ? uriString.TrimStart('/') : "Views/{0}".FormatEx(uriString);
        //        return new Uri("/{0};component/{1}".FormatEx(module.ModuleAssembly.GetName().Name, mUriString), UriKind.Relative);
        //    }

        //}
    }
}
