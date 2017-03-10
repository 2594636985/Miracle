using System;
using System.Linq.Expressions;

namespace Miracle.AomiToDB.Linq
{
    /// <summary>
    /// 集合表类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Table<T> : ExpressionQuery<T>, ITable<T>, ITable
    {
        public string DatabaseName { set; get; }
        public string SchemaName { set; get; }
        public string TableName { set; get; }

        public Table(IDataContextInfo dataContextInfo)
        {
            Init(dataContextInfo, null);
        }

        public Table(IDataContext dataContext)
        {
            Init(dataContext == null ? null : new DataContextInfo(dataContext), null);
        }

        public Table(IDataContext dataContext, Expression expression)
        {
            Init(dataContext == null ? null : new DataContextInfo(dataContext), expression);
        }

        public Table()
        {
            Init(null, null);
        }
    }
}
