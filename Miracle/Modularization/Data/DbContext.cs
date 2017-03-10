using Miracle.AomiToDB;
using Miracle.AomiToDB.DataProvider.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization.Data
{
    public class DbContext : DataContext
    {
        public DbContext(string connectionString)
            : base(SqlServerTools.GetDataProvider(), connectionString)
        { }
    }
}
