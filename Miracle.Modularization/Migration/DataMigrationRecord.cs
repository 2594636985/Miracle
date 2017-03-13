using Miracle.AomiToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization.Migration
{
    [Table]
    public class DataMigrationRecord
    {
        [Column, PrimaryKey, Identity]
        public virtual int Id { get; set; }

        [Column]
        public virtual string DataMigrationClass { get; set; }

        [Column]
        public virtual int Version { get; set; }
    }
}
