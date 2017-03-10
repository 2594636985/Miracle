using System;
using System.Collections.Generic;

namespace Miracle.AomiToDB.DataProvider.SqlCe
{
	using Data;

	class SqlCeBulkCopy : BasicBulkCopy
	{
		protected override BulkCopyRowsCopied MultipleRowsCopy<T>(
			DataConnection dataConnection, BulkCopyOptions options, IEnumerable<T> source)
		{
			return MultipleRowsCopy2(dataConnection, options, false, source, "");
		}
	}
}
