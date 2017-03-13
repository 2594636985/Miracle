using Miracle.Injection;
using Miracle.Modularization.Aspects;
using Miracle.Modularization.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization
{
    public partial class Module : IModule
    {
        private ProxyFactory _proxyFactory = new ProxyFactory();
        public IWindowShell GetWindowShell()
        {
            Type windowShellType = this.DependencyTypes.SingleOrDefault(t => typeof(IWindowShell).IsAssignableFrom(t));

            IWindowShell windowShell = Activator.CreateInstance(windowShellType) as IWindowShell;

            windowShell.Module = this;

            return windowShell;
        }

        public INavigation GetNavigation()
        {
            Type navigationType = this.DependencyTypes.SingleOrDefault(t => typeof(IWindowShell).IsAssignableFrom(t));

            INavigation navigation = Activator.CreateInstance(navigationType) as INavigation;

            return navigation;
        }

        public IService GetService(string typeName)
        {
            Type sType = this.DependencyTypes.SingleOrDefault(t => t.Name == typeName);

            ServiceBase serviceBase = this._proxyFactory.CreateProxy(sType, new LogicalInvocationHandler()) as ServiceBase;

            serviceBase.Module = this;

            return serviceBase;
        }

        public IService GetService(Type serviceType)
        {
            return this.GetService(serviceType.Name);
        }

        public TService GetService<TService>() where TService : IService
        {
            return (TService)this.GetService(typeof(TService));
        }


        public Data.DbContext GetDbContext()
        {
            return new Data.DbContext(this.ConnectionString);
        }

    }
}
