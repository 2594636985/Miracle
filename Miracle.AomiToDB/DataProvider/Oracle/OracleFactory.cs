using System;
using System.Collections.Specialized;


namespace Miracle.AomiToDB.DataProvider.Oracle
{
	class OracleFactory : IDataProviderFactory
	{
		IDataProvider IDataProviderFactory.GetDataProvider(NameValueCollection attributes)
		{
			for (var i = 0; i < attributes.Count; i++)
				if (attributes.GetKey(i) == "assemblyName")
					OracleTools.AssemblyName = attributes.Get(i);

			return new OracleDataProvider();
		}
	}
}
