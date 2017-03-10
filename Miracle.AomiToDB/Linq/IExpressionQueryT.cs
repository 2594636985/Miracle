using System;
using System.Linq;
using System.Linq.Expressions;

namespace Miracle.AomiToDB.Linq
{
    /// <summary>
    /// Linq查询的类
    /// </summary>
    /// <typeparam name="T"></typeparam>
	public interface IExpressionQuery<out T> : IOrderedQueryable<T>, IQueryProvider
	{
		new Expression Expression { get; set; }
		string         SqlText    { get; }
	}
}
