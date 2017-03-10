using System;
using System.Collections.Specialized;


namespace Miracle.AomiToDB.DataProvider.SQLite
{
	class SQLiteFactory: IDataProviderFactory
	{
		IDataProvider IDataProviderFactory.GetDataProvider(NameValueCollection attributes)
		{
			return new SQLiteDataProvider();
		}
	}
}
