using Miracle.Injection;
using Miracle.Modularization.Mapping;
using Miracle.Modularization.Migration;
using Miracle.Modularization.Modules;
using Miracle.Modularization.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Miracle.Modularization
{
    public partial class Module : IModule
    {
        /// <summary>
        /// 模块容器
        /// </summary>
        public IContainer Container { private set; get; }

        /// <summary>
        /// 模块所有的依赖类型集
        /// </summary>
        public List<Type> DependencyTypes { private set; get; }

        /// <summary>
        /// 获得一个值确定是否安装了
        /// </summary>

        public bool Installed { private set; get; }

        /// <summary>
        /// 获得一个值确定是否激活过
        /// </summary>
        public bool Activated { private set; get; }

        /// <summary>
        /// 模块对应的程序集
        /// </summary>
        public Assembly MainAssembly { private set; get; }

        public DataInitializer DataInitializer { private set; get; }


        #region 安装功能部分

        /// <summary>
        /// 装安模块
        /// </summary>
        public void Install()
        {
            if (!this.Installed)
            {
                this.SetupMainAssembly();
                this.SetupDependencyAssembly();

                this.Installed = true;

                if (this.OnInstalled != null)
                    this.OnInstalled(this);
            }
        }

        /// <summary>
        /// 设置依赖的程序集信息
        /// </summary>
        private void SetupDependencyAssembly()
        {
            string dependencyLocation = Path.Combine(this.ModuleLocation, "Libs");

            if (Directory.Exists(dependencyLocation))
            {
                string[] dllLocations = Directory.GetFiles(dependencyLocation);

                foreach (string dllLocation in dllLocations)
                {
                    AssemblyInfo assemblyInfo = new AssemblyInfo();
                    assemblyInfo.Location = dllLocation;
                    assemblyInfo.Name = Path.GetFileName(dllLocation).GetAssemblyFullNameEx();
                    assemblyInfo.Version = new Version(FileVersionInfo.GetVersionInfo(dllLocation).FileVersion);

                    AssemblyLocator.AddAssebmlyInfo(assemblyInfo);
                }
            }
        }
        /// <summary>
        /// 设置主模块程序集信息
        /// </summary>
        private void SetupMainAssembly()
        {
            AssemblyInfo mainAssemblyInfo = new AssemblyInfo();

            mainAssemblyInfo.Name = this.ModuleXml.MainAssemblyName.GetAssemblyFullNameEx();
            mainAssemblyInfo.Location = Path.Combine(this.ModuleLocation, mainAssemblyInfo.Name);
            mainAssemblyInfo.Version = this.ModuleXml.ModuleVersion;

            AssemblyLocator.AddAssebmlyInfo(mainAssemblyInfo);
        }

        #endregion


        #region 激活部分

        /// <summary>
        /// 激活模块
        /// </summary>
        public void Activate()
        {
            if (!this.Activated)
            {
                this.ActivateMainAssembly();
                this.ActivateDependencyTypes();
                this.ActivateDataInitializer();

                this.Activated = true;
            }
        }

        /// <summary>
        /// 激活主模块
        /// </summary>

        private void ActivateMainAssembly()
        {
            this.MainAssembly = Assembly.Load(this.ModuleXml.MainAssemblyName);
        }

        /// <summary>
        /// 激活需要的类型数据
        /// </summary>
        private void ActivateDependencyTypes()
        {
            this.DependencyTypes = this.MainAssembly.GetTypesEx(typeof(IDependency));
        }

        private void ActivateDataInitializer()
        {
            Type dataMigrationType = this.DependencyTypes.FirstOrDefault(t => typeof(IDataMigration).IsAssignableFrom(t));

            if (dataMigrationType != null)
            {
                IDataMigration dataMigration = Activator.CreateInstance(dataMigrationType) as IDataMigration;

                this.DataInitializer = new DataInitializer(this, dataMigration);

                this.DataInitializer.Initialize();
            }

        }

        #endregion
    }
}
