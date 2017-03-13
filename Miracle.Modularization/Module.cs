using Miracle.Modularization.Migration;
using Miracle.Injection;
using Miracle.Modularization.Mapping;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Miracle.Modularization
{
    /// <summary>
    /// 模块类
    /// </summary>
    public partial class Module : IModule
    {
        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName { private set; get; }

        /// <summary>
        /// 模块应用名
        /// </summary>
        public string AppName { private set; get; }

        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectionString { private set; get; }

        /// <summary>
        /// 模块类型
        /// </summary>
        public ModuleType ModuleType { private set; get; }

        /// <summary>
        /// 模块的版本号
        /// </summary>
        public Version Version { private set; get; }

        /// <summary>
        /// 模块所在的位置
        /// </summary>
        public string ModuleLocation { private set; get; }

        /// <summary>
        /// 主程序集的名称
        /// </summary>
        public string MainAssemblyName { set; get; }

        /// <summary>
        /// 模块内核
        /// </summary>
        public IModuleFramework ModuleFramework { private set; get; }

        /// <summary>
        /// 模块配置信息
        /// </summary>
        public ModuleXml ModuleXml { private set; get; }

        public List<Link> Links { private set; get; }

        /// <summary>
        /// 安装完事件
        /// </summary>
        public event Action<Module> OnInstalled;


        public Module(ModuleXml moduleXml, ModuleFramework moduleFramework)
        {
            this.ModuleFramework = moduleFramework;
            this.ModuleXml = moduleXml;
            this.ModuleType = (ModuleType)Enum.Parse(typeof(ModuleType), this.ModuleXml.ModuleType, true);
            this.ConnectionString = this.ModuleXml.ConnectionString ?? moduleFramework.ModuleInformation.ConnectionString;
            this.ModuleName = this.ModuleXml.ModuleName;
            this.AppName = this.ModuleXml.AppName;
            this.Version = this.ModuleXml.ModuleVersion;
            this.MainAssemblyName = this.ModuleXml.MainAssemblyName;
            this.Links = this.GetLinks(this.ModuleXml);
            this.ModuleLocation = Path.GetDirectoryName(this.ModuleXml.XmlLocation);
        }

        private List<Link> GetLinks(ModuleXml moduleXml)
        {
            List<Link> links = new List<Link>();

            foreach (ModuleMenu mm in moduleXml.ModuleMenus)
            {
                Link link = new Link();
                link.AppName = mm.AppName;
                link.ModuleName = moduleXml.ModuleName;
                link.ViewPageLocation = mm.ViewPageLocation;

                links.Add(link);
            }

            return links;

        }

    }
}
