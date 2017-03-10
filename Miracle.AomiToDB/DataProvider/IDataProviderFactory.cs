using System;
using System.Collections.Specialized;

namespace Miracle.AomiToDB.DataProvider
{
    /// <summary>
    /// 数据供应者的工厂
    /// </summary>
    public interface IDataProviderFactory
    {
        /// <summary>
        /// 获得数据供应者
        /// </summary>
        /// <param name="attributes"></param>
        /// <returns></returns>
        IDataProvider GetDataProvider(NameValueCollection attributes);
    }
}
