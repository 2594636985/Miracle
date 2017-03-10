using System;
using System.Linq;
using System.Linq.Expressions;

namespace Miracle.AomiToDB.Linq
{
	class QueryableAccessor
	{
		public IQueryable                  Queryable;
		public Func<Expression,IQueryable> Accessor;
	}
}
