using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization.Services
{
    using Data;
    using Injection;

    public abstract class ServiceBase : IService
    {
        [Inject]
        public IModule Module { set; get; }

        public DbContext GetDbContext()
        {
            return new DbContext(this.Module.ConnectionString);
        }
    }
}
