using System;
using System.Collections.Specialized;


namespace Miracle.AomiToDB.DataProvider.MySql
{
	class MySqlFactory : IDataProviderFactory
	{
		IDataProvider IDataProviderFactory.GetDataProvider(NameValueCollection attributes)
		{
			return new MySqlDataProvider();
		}
	}
}
