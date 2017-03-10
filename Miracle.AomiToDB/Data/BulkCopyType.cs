using System;

namespace Miracle.AomiToDB.Data
{
	public enum BulkCopyType
	{
		Default = 0,
		RowByRow,
		MultipleRows,
		ProviderSpecific
	}
}
