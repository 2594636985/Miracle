using System;
using System.Collections.Generic;

namespace Miracle.AomiToDB.DataProvider.SapHana
{
	using SchemaProvider;


	public class ViewWithParametersTableSchema : TableSchema
	{
		public ViewWithParametersTableSchema()
		{
			IsProviderSpecific = true;
		}

		public List<ParameterSchema> Parameters { get; set; }
	}
}
