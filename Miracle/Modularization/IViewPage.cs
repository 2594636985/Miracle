using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization
{
    public interface IViewPage
    {
        IModule Module { set; get; }

        Session Session { get; }

        /// <summary>
        /// 初始化
        /// </summary>
        void Initialize();

        /// <summary>
        /// 模块界面的参数
        /// </summary>
        Dictionary<string, object> Parameters { set; get; }

        /// <summary>
        /// 模块界面的控制器
        /// </summary>
        IViewPageBox ViewPageBox { set; get; }

        /// <summary>
        /// 是否缓存
        /// </summary>
        bool Cached { get; }

        /// <summary>
        /// 是否存入记录中，用于返回时调用。
        /// </summary>
        bool Stacked { get; }

        void Display(string vPageLocation);
    }
}
