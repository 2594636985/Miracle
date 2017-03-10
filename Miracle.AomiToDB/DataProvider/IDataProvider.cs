using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;

namespace Miracle.AomiToDB.DataProvider
{
    using Data;
    using Mapping;
    using SchemaProvider;
    using SqlProvider;

    /// <summary>
    /// 数据供应者
    /// </summary>
    public interface IDataProvider
    {
        /// <summary>
        /// 供应者的名称
        /// </summary>
        string Name { get; }
        /// <summary>
        /// 连接类的空间命名
        /// </summary>
        string ConnectionNamespace { get; }
        /// <summary>
        /// 对应DataReader类的类型
        /// </summary>
        Type DataReaderType { get; }
        /// <summary>
        /// 获得当前的结构映射
        /// </summary>
        MappingSchema MappingSchema { get; }
        /// <summary>
        /// 有一点像是标记数据库的状态
        /// </summary>
        SqlProviderFlags SqlProviderFlags { get; }
        /// <summary>
        /// 新建一个数据库连接
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        IDbConnection CreateConnection(string connectionString);
        /// <summary>
        /// 新建一个生成T-SQL的SQL生成类
        /// </summary>
        /// <returns></returns>
        ISqlBuilder CreateSqlBuilder();
        /// <summary>
        /// 新建一个优化SQL的优化类
        /// </summary>
        /// <returns></returns>
        ISqlOptimizer GetSqlOptimizer();
        /// <summary>
        /// 初始化一个Command命令。Command就是如SqlCommand之类的。
        /// </summary>
        /// <param name="dataConnection"></param>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        void InitCommand(DataConnection dataConnection, CommandType commandType, string commandText, DataParameter[] parameters);
        /// <summary>
        /// 删除一个Command命令
        /// </summary>
        /// <param name="dataConnection"></param>
        void DisposeCommand(DataConnection dataConnection);
        object GetConnectionInfo(DataConnection dataConnection, string parameterName);
        Expression GetReaderExpression(MappingSchema mappingSchema, IDataReader reader, int idx, Expression readerExpression, Type toType);
        bool? IsDBNullAllowed(IDataReader reader, int idx);
        void SetParameter(IDbDataParameter parameter, string name, DataType dataType, object value);
        Type ConvertParameterType(Type type, DataType dataType);
        bool IsCompatibleConnection(IDbConnection connection);

        ISchemaProvider GetSchemaProvider();

        BulkCopyRowsCopied BulkCopy<T>(DataConnection dataConnection, BulkCopyOptions options, IEnumerable<T> source);
        int Merge<T>(DataConnection dataConnection, Expression<Func<T, bool>> predicate, bool delete, IEnumerable<T> source,
                                                  string tableName, string databaseName, string schemaName)
            where T : class;

    }
}
