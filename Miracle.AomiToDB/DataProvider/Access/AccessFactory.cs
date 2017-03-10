using System;
using System.Collections.Specialized;



namespace Miracle.AomiToDB.DataProvider.Access
{
	
	class AccessFactory : IDataProviderFactory
	{
		IDataProvider IDataProviderFactory.GetDataProvider(NameValueCollection attributes)
		{
			return new AccessDataProvider();
		}
	}
}
