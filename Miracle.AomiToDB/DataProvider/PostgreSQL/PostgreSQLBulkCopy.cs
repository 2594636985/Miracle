﻿using System;
using System.Collections.Generic;

namespace Miracle.AomiToDB.DataProvider.PostgreSQL
{
	using Data;

	class PostgreSQLBulkCopy : BasicBulkCopy
	{
		protected override BulkCopyRowsCopied MultipleRowsCopy<T>(
			DataConnection dataConnection, BulkCopyOptions options, IEnumerable<T> source)
		{
			return MultipleRowsCopy1(dataConnection, options, false, source);
		}
	}
}
