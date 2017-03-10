using System;
using System.Collections.Specialized;


namespace Miracle.AomiToDB.DataProvider.Firebird
{
	class FirebirdFactory: IDataProviderFactory
	{
		IDataProvider IDataProviderFactory.GetDataProvider(NameValueCollection attributes)
		{
			return new FirebirdDataProvider();
		}
	}
}
