using Miracle.Desktop.Toolkit.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Reflection;
using Miracle.Modularization;

namespace Miracle.Desktop.Toolkit.Windows
{
    /// <summary>
    /// 默认加载器
    /// </summary>
    public class DefaultViewPageLoader : IViewPageLoader
    {
        public IModule Module { set; get; }

        /// <summary>
        /// 异步加载内容
        /// </summary>
        /// <param name="link"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IViewPage> LoadContentAsync(Link link, CancellationToken cancellationToken)
        {
            if (!Application.Current.Dispatcher.CheckAccess())
                throw new InvalidOperationException("当前的线程访问不了UI线程");

            var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            return Task.Factory.StartNew<IViewPage>(() => LoadContent(link), cancellationToken, TaskCreationOptions.None, scheduler);
        }

        /// <summary>
        /// 加载内容
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        protected virtual IViewPage LoadContent(Link link)
        {
            IModule vPageModule = this.Module.ModuleFramework.GetModule(link.ModuleName);

            string vPageAssemblyName = this.CheckAndTrimEndExtension(vPageModule.MainAssemblyName, ".dll");

            Uri vPageUri = new Uri(string.Format("/{0};Component/Pages/{1}", vPageAssemblyName, link.ViewPageLocation), System.UriKind.Relative);

            IViewPage vPage = Application.LoadComponent(vPageUri) as IViewPage;

            vPage.Module = this.Module;

            return vPage;
        }

        private string CheckAndTrimEndExtension(string value, string extension)
        {
            return value.EndsWith(extension, StringComparison.CurrentCultureIgnoreCase) ? value.TrimEndEx(extension) : value;
        }

    }
}
