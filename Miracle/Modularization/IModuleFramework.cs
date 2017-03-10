using Miracle.Modularization.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization
{
    public interface IModuleFramework
    {
        /// <summary>
        /// 根据模块名获得相应的模块
        /// </summary>
        /// <param name="moduleName"></param>
        /// <returns></returns>
        IModule GetModule(string moduleName);

        void Authenticate(IModuleSecurity validation);

        void Logout();

        bool Exist(string moduleName);

        List<IModule> GetExtModules();

        List<IModule> GetModules();

    }
}
