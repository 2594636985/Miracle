using Miracle.Modularization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Miracle.Modularization
{

    /// <summary>
    /// 内容加载器
    /// </summary>
    public interface IViewPageLoader
    {
        IModule Module { set; get; }

        /// <summary>
        /// 异步加载
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IViewPage> LoadContentAsync(Link link, CancellationToken cancellationToken);
    }
}
