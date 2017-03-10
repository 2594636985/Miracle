﻿using System;

namespace Miracle.AomiToDB.Linq
{
    using Mapping;
    using SqlProvider;
    /// <summary>
    /// 数据上下文信息类
    /// </summary>
    class DataContextInfo : IDataContextInfo
    {
        public DataContextInfo(IDataContext dataContext)
        {
            DataContext = dataContext;
            DisposeContext = false;
        }

        public DataContextInfo(IDataContext dataContext, bool disposeContext)
        {
            DataContext = dataContext;
            DisposeContext = disposeContext;
        }

        public IDataContext DataContext { get; private set; }
        public bool DisposeContext { get; private set; }
        public string ContextID { get { return DataContext.ContextID; } }
        public MappingSchema MappingSchema { get { return DataContext.MappingSchema; } }
        public SqlProviderFlags SqlProviderFlags { get { return DataContext.SqlProviderFlags; } }

        public ISqlBuilder CreateSqlBuilder()
        {
            return DataContext.CreateSqlProvider();
        }

        public ISqlOptimizer GetSqlOptimizer()
        {
            return DataContext.GetSqlOptimizer();
        }

        public IDataContextInfo Clone(bool forNestedQuery)
        {
            return new DataContextInfo(DataContext.Clone(forNestedQuery));
        }

        public static IDataContextInfo Create(IDataContext dataContext)
        {
            return dataContext == null ? (IDataContextInfo)new DefaultDataContextInfo() : new DataContextInfo(dataContext);
        }
    }
}
