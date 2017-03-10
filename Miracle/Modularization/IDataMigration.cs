using Miracle.Modularization.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization
{
    public interface IDataMigration : IDependency
    {
        int Create(DbContext DbContext);
    }
}
