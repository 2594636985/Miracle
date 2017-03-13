
using System.IO;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.ObjectModel;

namespace Miracle.Modularization
{
    using Modules;
    using Miracle.Modularization.Security;

    public class ModuleFramework : IModuleFramework
    {
        public ModuleSetupInformation ModuleInformation { private set; get; }

        public IAuthentication Authentication { private set; get; }
        /// <summary>
        /// 模块集合
        /// </summary>
        public List<Module> Modules { private set; get; }

        static ModuleFramework()
        {
            AssemblyLocator.Initialize();
        }

        public ModuleFramework(ModuleSetupInformation moduleSetupInformation)
        {
            this.ModuleInformation = moduleSetupInformation;
            this.Modules = new List<Module>();
            this.Authentication = new Authentication();
        }

        public void SetupExtensional()
        {

            List<ModuleXml> loadModuleXmls = this.LoadModuleXml();

            if (loadModuleXmls == null || loadModuleXmls.Count <= 0)
                throw new InvalidDataException("没有找到存在的模块");

            foreach (ModuleXml moduleXml in loadModuleXmls)
            {
                if (this.Exist(moduleXml.ModuleName))
                    throw new InvalidDataException("存在相同的模块名{0}".FormatEx(moduleXml.ModuleName));

                Module module = new Module(moduleXml, this);

                module.Install();

                this.Modules.Add(module);
            }
        }
        /// <summary>
        /// 加载存在的所有模块
        /// </summary>
        /// <returns></returns>
        private List<ModuleXml> LoadModuleXml()
        {
            List<ModuleXml> loadModuleXmls = new List<ModuleXml>();

            string[] xmlLocations = Directory.GetFiles(this.ModuleInformation.AppLocation, "Module.Xml", SearchOption.AllDirectories);

            foreach (string xmlLocation in xmlLocations)
            {
                ModuleXml moduleXml = new ModuleXml(xmlLocation);

                moduleXml.Initialize();

                loadModuleXmls.Add(moduleXml);
            }
            return loadModuleXmls;
        }

        /// <summary>
        /// 激活模块功能
        /// </summary>
        public void Activate()
        {
            foreach (Module module in this.Modules)
            {
                module.Activate();
            }
        }

        public TAction GetAction<TAction>()
        {
            return default(TAction);
        }

        public IModule GetModule(string moduleName)
        {
            if (string.IsNullOrWhiteSpace(moduleName))
                throw new ArgumentNullException("moduleName");

            return this.Modules.SingleOrDefault(m => m.ModuleName.EqualsIgnoreCaseEx(moduleName));
        }

        public ActionInvocation NewActionInvocation(string moduleName)
        {
            Module module = this.GetModule(moduleName) as Module;

            if (module != null)
                return new ActionInvocation(module);

            return null;
        }

        public List<Tuple<string, string, string>> GetEnabledActionInformation()
        {
            List<Tuple<string, string, string>> enabledActionInformactions = new List<Tuple<string, string, string>>();
            foreach (Module module in this.Modules)
            {
                if (module.Installed && module.Activated)
                {
                    List<ActionInformation> moudleActionInformations = module.GetAllActionInformation();

                    foreach (ActionInformation actionInformation in moudleActionInformations)
                    {
                        enabledActionInformactions.Add(new Tuple<string, string, string>(module.ModuleName, actionInformation.ControllerName, actionInformation.ActionName));
                    }
                }
            }

            return enabledActionInformactions;
        }

        public void Authenticate(IModuleSecurity validation)
        {
            this.Authentication.Authenticate(validation);
        }

        public void Logout()
        {
            this.Authentication.Logout();
        }


        public bool Exist(string moduleName)
        {
            return this.Modules.Any(m => m.ModuleName == moduleName);
        }


        public List<IModule> GetExtModules()
        {
            return this.Modules.Where(m => m.ModuleType == ModuleType.Extensional).Select(m => m as IModule).ToList();
        }

        public List<IModule> GetModules()
        {
            return this.Modules.Select(m => m as IModule).ToList();
        }
    }
}
