using System;
using System.Diagnostics;

namespace Miracle.AomiToDB.SchemaProvider
{
	[DebuggerDisplay("TypeName = {TypeName}, DataType = {DataType}, CreateFormat = {CreateFormat}, CreateParameters = {CreateParameters}")]
	public class DataTypeInfo
	{
		public string TypeName;
		public string DataType;
		public string CreateFormat;
		public string CreateParameters;
		public int    ProviderDbType;
	}
}
