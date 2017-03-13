
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Miracle.Modularization.Modules
{
    static class AssemblyLocator
    {
        private static Dictionary<string, AssemblyInfo> moduleAssemblies = new Dictionary<string, AssemblyInfo>();
        private static Dictionary<string, Assembly> assemblies = new Dictionary<string, Assembly>();
        private static bool initialized;

        public static void Initialize()
        {
            lock (assemblies)
            {
                if (initialized)
                    return;
                initialized = true;
                AppDomain.CurrentDomain.AssemblyLoad += CurrentDomain_AssemblyLoad;
                AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            }
        }

        public static void AddAssebmlyInfo(AssemblyInfo assemblyInfo)
        {
            if (moduleAssemblies.ContainsKey(assemblyInfo.Name))
            {
                if (moduleAssemblies[assemblyInfo.Name].Version < assemblyInfo.Version)
                {
                    moduleAssemblies[assemblyInfo.Name] = assemblyInfo;
                }
            }
            else
            {
                moduleAssemblies.Add(assemblyInfo.Name, assemblyInfo);
            }
        }

        public static void AddRangeAssebmlyInfo(List<AssemblyInfo> assemblyInfos)
        {
            foreach (AssemblyInfo assemblyInfo in assemblyInfos)
            {
                AddAssebmlyInfo(assemblyInfo);
            }
        }

        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            lock (assemblies)
            {
                Assembly assembly = null;
                AssemblyInfo assemblyInfo = null;
                if (assemblies.TryGetValue(args.Name, out assembly))
                    return assembly;
                else if (moduleAssemblies.TryGetValue(args.Name.GetAssemblyFullNameEx(), out assemblyInfo))
                    return Assembly.LoadFrom(assemblyInfo.Location);
                else
                    return assembly;
            }
        }

        static void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {
            Assembly assembly = args.LoadedAssembly;
            lock (assemblies)
            {
                if (!assemblies.ContainsKey(assembly.FullName))
                    assemblies.Add(assembly.FullName, assembly);
            }
        }


    }

}
