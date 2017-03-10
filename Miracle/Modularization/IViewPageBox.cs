using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization
{
    public interface IViewPageBox
    {
        /// <summary>
        /// 当前Link的个数
        /// </summary>
        int LinkStackCount { get; }

        /// <summary>
        /// 返回前一个Link
        /// </summary>
        void BackLink();

        /// <summary>
        /// 跳到最后一个Link
        /// </summary>
        void GotoLastLink();

        Session Session { get; }

        void Display(string moduleName, string vPageLocation);

        void Display(Link Link);

        void Destroy();
    }
}
