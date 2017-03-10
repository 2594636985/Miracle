using System;

namespace Miracle.AomiToDB.Linq
{
	using Mapping;
	using SqlProvider;

    /// <summary>
    /// 数据上下文信息类
    /// </summary>
	public interface IDataContextInfo
	{
		IDataContext     DataContext      { get; }
		string           ContextID        { get; }
		MappingSchema    MappingSchema    { get; }
		bool             DisposeContext   { get; }
		SqlProviderFlags SqlProviderFlags { get; }

		ISqlBuilder      CreateSqlBuilder ();
		ISqlOptimizer    GetSqlOptimizer  ();
		IDataContextInfo Clone(bool forNestedQuery);
	}
}
