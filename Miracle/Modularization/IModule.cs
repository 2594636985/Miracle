using Miracle.Modularization.Data;
using Miracle.Modularization.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization
{
    public interface IModule
    {
        /// <summary>
        /// 模块名称
        /// </summary>
        string ModuleName { get; }

        /// <summary>
        /// 应用名
        /// </summary>
        string AppName { get; }

        /// <summary>
        /// 连接字符串
        /// </summary>

        string ConnectionString { get; }

        /// <summary>
        /// 模块类型
        /// </summary>
        ModuleType ModuleType { get; }

        /// <summary>
        /// 模块版本
        /// </summary>
        Version Version { get; }

        /// <summary>
        /// 所在位置
        /// </summary>
        string ModuleLocation { get; }

        string MainAssemblyName { get; }

        /// <summary>
        /// 模块内核
        /// </summary>
        IModuleFramework ModuleFramework { get; }


        List<Link> Links { get; }

        DbContext GetDbContext();

        IWindowShell GetWindowShell();

        INavigation GetNavigation();

        IService GetService(string typeName);

        IService GetService(Type serviceType);

        TService GetService<TService>() where TService : IService;


    }
}
