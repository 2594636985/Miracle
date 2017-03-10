using System;
using System.Collections.Specialized;



namespace Miracle.AomiToDB.DataProvider.DB2
{
	class DB2Factory : IDataProviderFactory
	{
		IDataProvider IDataProviderFactory.GetDataProvider(NameValueCollection attributes)
		{
			for (var i = 0; i < attributes.Count; i++)
			{
				if (attributes.GetKey(i) == "version")
				{
					switch (attributes.Get(i))
					{
						case "zOS"  :
						case "z/OS" : return new DB2DataProvider(ProviderName.DB2zOS, DB2Version.zOS);
					}
				}
			}

			return new DB2DataProvider(ProviderName.DB2LUW, DB2Version.LUW);
		}
	}
}
