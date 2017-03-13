using Miracle.Modularization.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Miracle.AomiToDB;
using System.Reflection;

namespace Miracle.Modularization.Migration
{
    public class DataInitializer
    {
        public IModule Module { private set; get; }

        public IDataMigration DataMigration { private set; get; }

        public DataInitializer(IModule module, IDataMigration dataMigration)
        {
            this.Module = module;
            this.DataMigration = dataMigration;
        }

        public void Initialize()
        {
            using (DbContext db = this.Module.GetDbContext())
            {
                DataMigrationRecord dataMigrationRecord = db.GetTable<DataMigrationRecord>().SingleOrDefault(dmr => dmr.DataMigrationClass == this.Module.ModuleName);

                int current = 0;

                if (dataMigrationRecord != null)
                    current = dataMigrationRecord.Version;

                try
                {
                    if (current == 0)
                        current = (int)this.DataMigration.Create(db);

                    Dictionary<int, MethodInfo> migrateLookupTable = CreateMigrateLookupTable(this.DataMigration);

                    while (migrateLookupTable.ContainsKey(current))
                    {
                        try
                        {
                            current = (int)migrateLookupTable[current].Invoke(this.DataMigration, new object[1] { db });
                        }
                        catch (Exception ex)
                        {
                        }
                    }

                }
                catch (Exception ex)
                {

                }
            }

        }

        private Dictionary<int, MethodInfo> CreateMigrateLookupTable(IDataMigration dataMigration)
        {
            return dataMigration
                .GetType()
                .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Select(GetMigrateMethod)
                .Where(tuple => tuple != null)
                .ToDictionary(tuple => tuple.Item1, tuple => tuple.Item2);
        }

        private Tuple<int, MethodInfo> GetMigrateMethod(MethodInfo mi)
        {
            const string updatefromPrefix = "Migrate";

            if (mi.Name.StartsWith(updatefromPrefix))
            {
                var version = mi.Name.Substring(updatefromPrefix.Length);
                int versionValue;
                if (int.TryParse(version, out versionValue))
                {
                    return new Tuple<int, MethodInfo>(versionValue, mi);
                }
            }

            return null;
        }


    }
}
