using System;
using System.Collections.Generic;

namespace Miracle.AomiToDB.Linq
{
	using SqlQuery;

	public interface IQueryContext
	{
		SelectQuery    SelectQuery { get; }
		object         Context     { get; set; }
		List<string>   QueryHints  { get; }
		SqlParameter[] GetParameters();
	}
}
