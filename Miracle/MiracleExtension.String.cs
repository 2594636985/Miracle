using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Miracle
{
    public static partial class MiracleExtension
    {
        public static bool EqualsIgnoreCaseEx(this string str1, string str2)
        {
            return string.Compare(str1, str2, true) == 0;
        }

        public static string FormatEx(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        public static string GetAssemblyFullNameEx(this string assemblyName)
        {
            return assemblyName.EndsWith(".dll", StringComparison.CurrentCultureIgnoreCase) ? assemblyName : assemblyName + ".dll";
        }

        public static bool IsNullOrEmptyEx(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static string TrimEndEx(this string value, string mark)
        {
            if (!value.IsNullOrEmptyEx() && !mark.IsNullOrEmptyEx() && value.EndsWith(mark, StringComparison.CurrentCultureIgnoreCase))
            {
                int index = value.IndexOf(mark, StringComparison.CurrentCultureIgnoreCase);
                return value.Substring(0, index);
            }

            return value;
        }


        public static Version ToVersionEx(this string fileLocation)
        {
            if (!File.Exists(fileLocation))
                throw new FileNotFoundException("没有找到{0}文件".FormatEx(fileLocation));

            return new Version(FileVersionInfo.GetVersionInfo(fileLocation).FileVersion);
        }


        public static string ToMD5Ex(string value)
        {
            MD5CryptoServiceProvider provider;
            provider = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            StringBuilder builder = new StringBuilder();

            bytes = provider.ComputeHash(bytes);

            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2").ToLower());
            }
            return builder.ToString();
        }
    }
}
