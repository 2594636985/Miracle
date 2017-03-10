using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;

namespace Miracle.AomiToDB
{
    using Data;
    using DataProvider;
    using Linq;
    using Mapping;
    using SqlProvider;

    /// <summary>
    /// 数据上下文
    /// </summary>
    public class DataContext : IDataContext
    {
        #region 私有字段
        private bool? _isMarsEnabled;
        private bool _keepConnectionAlive;
        private List<string> _queryHints;
        private List<string> _nextQueryHints;
        #endregion

        #region 保护字段
        protected DataConnection _dataConnection;
        #endregion

        #region 公有属性
        /// <summary>
        /// 配置字符串
        /// </summary>
        public string ConfigurationString { get; private set; }
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectionString { get; private set; }
        /// <summary>
        /// 数据供应者
        /// </summary>
        public IDataProvider DataProvider { get; private set; }
        /// <summary>
        /// 上下文ID
        /// </summary>
        public string ContextID { get; set; }
        public MappingSchema MappingSchema { get; set; }
        /// <summary>
        /// 用于在显示SQL加入回键符号
        /// </summary>
        public bool InlineParameters { get; set; }
        public string LastQuery { get; set; }

        public bool KeepConnectionAlive
        {
            get { return _keepConnectionAlive; }
            set
            {
                _keepConnectionAlive = value;

                if (value == false)
                    ReleaseQuery();
            }
        }


        public bool IsMarsEnabled
        {
            get
            {
                if (_isMarsEnabled == null)
                {
                    if (_dataConnection == null)
                        return false;
                    _isMarsEnabled = _dataConnection.IsMarsEnabled;
                }

                return _isMarsEnabled.Value;
            }
            set { _isMarsEnabled = value; }
        }

        public List<string> QueryHints
        {
            get
            {
                if (_dataConnection != null)
                    return _dataConnection.QueryHints;

                return _queryHints ?? (_queryHints = new List<string>());
            }
        }

        public List<string> NextQueryHints
        {
            get
            {
                if (_dataConnection != null)
                    return _dataConnection.NextQueryHints;

                return _nextQueryHints ?? (_nextQueryHints = new List<string>());
            }
        }

        #endregion

        #region 事件
        /// <summary>
        /// 关闭事情
        /// </summary>
        public event EventHandler OnClosing;
        #endregion

        #region 构造函数
        public DataContext()
            : this(DataConnection.DefaultConfiguration)
        {
        }

        public DataContext(string configurationString)
        {
            DataProvider = DataConnection.GetDataProvider(configurationString);
            ConfigurationString = configurationString ?? DataConnection.DefaultConfiguration;
            ContextID = DataProvider.Name;
            MappingSchema = DataProvider.MappingSchema;
        }

        public DataContext( IDataProvider dataProvider,  string connectionString)
        {
            if (dataProvider == null) throw new ArgumentNullException("dataProvider");
            if (connectionString == null) throw new ArgumentNullException("connectionString");

            DataProvider = dataProvider;
            ConnectionString = connectionString;
            ContextID = DataProvider.Name;
            MappingSchema = DataProvider.MappingSchema;
        }
        DataContext(int n) { }
        #endregion

        internal int LockDbManagerCounter;
        

        /// <summary>
        /// 获得一个数据连接。如果数据连接不存在就创建一个新的数据连接。
        /// </summary>
        /// <returns></returns>
        internal DataConnection GetDataConnection()
        {
            if (_dataConnection == null)
            {
                _dataConnection = ConnectionString != null
                    ? new DataConnection(DataProvider, ConnectionString)
                    : new DataConnection(ConfigurationString);

                if (_queryHints != null && _queryHints.Count > 0)
                {
                    _dataConnection.QueryHints.AddRange(_queryHints);
                    _queryHints = null;
                }

                if (_nextQueryHints != null && _nextQueryHints.Count > 0)
                {
                    _dataConnection.NextQueryHints.AddRange(_nextQueryHints);
                    _nextQueryHints = null;
                }
            }

            return _dataConnection;
        }

        internal void ReleaseQuery()
        {
            if (_dataConnection != null)
            {
                LastQuery = _dataConnection.LastQuery;

                if (LockDbManagerCounter == 0 && KeepConnectionAlive == false)
                {
                    if (_dataConnection.QueryHints.Count > 0) QueryHints.AddRange(_queryHints);
                    if (_dataConnection.NextQueryHints.Count > 0) NextQueryHints.AddRange(_nextQueryHints);

                    _dataConnection.Dispose();
                    _dataConnection = null;
                }
            }
        }

        Func<ISqlBuilder> IDataContext.CreateSqlProvider
        {
            get { return DataProvider.CreateSqlBuilder; }
        }

        Func<ISqlOptimizer> IDataContext.GetSqlOptimizer
        {
            get { return DataProvider.GetSqlOptimizer; }
        }

        Type IDataContext.DataReaderType
        {
            get { return DataProvider.DataReaderType; }
        }

        Expression IDataContext.GetReaderExpression(MappingSchema mappingSchema, IDataReader reader, int idx, Expression readerExpression, Type toType)
        {
            return DataProvider.GetReaderExpression(mappingSchema, reader, idx, readerExpression, toType);
        }

        bool? IDataContext.IsDBNullAllowed(IDataReader reader, int idx)
        {
            return DataProvider.IsDBNullAllowed(reader, idx);
        }

        object IDataContext.SetQuery(IQueryContext queryContext)
        {
            var ctx = GetDataConnection() as IDataContext;
            return ctx.SetQuery(queryContext);
        }

        /// <summary>
        /// 执行非查询操作
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        int IDataContext.ExecuteNonQuery(object query)
        {
            var ctx = GetDataConnection() as IDataContext;
            return ctx.ExecuteNonQuery(query);
        }

        object IDataContext.ExecuteScalar(object query)
        {
            var ctx = GetDataConnection() as IDataContext;
            return ctx.ExecuteScalar(query);
        }

        /// <summary>
        /// 执行一个查询操作。
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        IDataReader IDataContext.ExecuteReader(object query)
        {
            var ctx = GetDataConnection() as IDataContext;
            return ctx.ExecuteReader(query);
        }

        void IDataContext.ReleaseQuery(object query)
        {
            ReleaseQuery();
        }

        SqlProviderFlags IDataContext.SqlProviderFlags
        {
            get { return DataProvider.SqlProviderFlags; }
        }

        /// <summary>
        /// 获得SQL语句
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        string IDataContext.GetSqlText(object query)
        {
            if (_dataConnection != null)
                return ((IDataContext)_dataConnection).GetSqlText(query);

            var ctx = GetDataConnection() as IDataContext;
            var str = ctx.GetSqlText(query);

            ReleaseQuery();

            return str;
        }

       
        /// <summary>
        /// 复制一个当前的DataContext实例
        /// </summary>
        /// <param name="forNestedQuery"></param>
        /// <returns></returns>
        IDataContext IDataContext.Clone(bool forNestedQuery)
        {
            var dc = new DataContext(0)
            {
                ConfigurationString = ConfigurationString,
                ConnectionString = ConnectionString,
                KeepConnectionAlive = KeepConnectionAlive,
                DataProvider = DataProvider,
                ContextID = ContextID,
                MappingSchema = MappingSchema,
                InlineParameters = InlineParameters,
            };

            if (forNestedQuery && _dataConnection != null && _dataConnection.IsMarsEnabled)
                dc._dataConnection = _dataConnection.Transaction != null ?
                    new DataConnection(DataProvider, _dataConnection.Transaction) :
                    new DataConnection(DataProvider, _dataConnection.Connection);

            dc.QueryHints.AddRange(QueryHints);
            dc.NextQueryHints.AddRange(NextQueryHints);

            return dc;
        }

       

        void IDisposable.Dispose()
        {
            if (_dataConnection != null)
            {
                if (OnClosing != null)
                    OnClosing(this, EventArgs.Empty);

                if (_dataConnection.QueryHints.Count > 0) QueryHints.AddRange(_queryHints);
                if (_dataConnection.NextQueryHints.Count > 0) NextQueryHints.AddRange(_nextQueryHints);

                _dataConnection.Dispose();
                _dataConnection = null;
            }
        }

        /// <summary>
        /// 指定事务级别，开始一个事务
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public virtual DataContextTransaction BeginTransaction(IsolationLevel level)
        {
            var dct = new DataContextTransaction(this);

            dct.BeginTransaction(level);

            return dct;
        }
        /// <summary>
        /// 开始一个事务，默认是在关闭连接的时候，自动提交事务
        /// </summary>
        /// <param name="autoCommitOnDispose"></param>
        /// <returns></returns>
        public virtual DataContextTransaction BeginTransaction(bool autoCommitOnDispose = true)
        {
            var dct = new DataContextTransaction(this);

            dct.BeginTransaction();

            return dct;
        }
    }
}
