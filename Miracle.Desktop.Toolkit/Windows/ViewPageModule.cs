using Miracle.Injection;
using Miracle.Modularization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Miracle.Desktop.Toolkit.Windows
{

    /// <summary>
    /// 模块界面
    /// </summary>
    public class ViewPage : UserControl, IViewPage
    {
        /// <summary>
        /// 对应的模块
        /// </summary>
        public IModule Module { set; get; }


        /// <summary>
        /// 模块的核心类
        /// </summary>
        public IModuleFramework ModuleFramework
        {
            get
            {
                if (this.Module != null)
                    return this.Module.ModuleFramework;
                return null;
            }
        }

        public Session Session
        {
            get
            {
                return this.ViewPageBox.Session;
            }
        }

        /// <summary>
        /// 模块界面的参数
        /// </summary>
        public Dictionary<string, object> Parameters { set; get; }

        /// <summary>
        /// 模块界面的控制器
        /// </summary>
        public IViewPageBox ViewPageBox { set; get; }

        /// <summary>
        /// 是否缓存当前的模块界面
        /// </summary>
        public virtual bool Cached { get { return true; } }

        /// <summary>
        /// 是否存入记录中，用于返回时调用。
        /// </summary>
        public virtual bool Stacked { get { return true; } }

        public void Display(string vPageLocation)
        {
            this.ViewPageBox.Display(this.Module.ModuleName, vPageLocation);
        }

        public void Initialize()
        {
            if (this.Module == null)
                throw new InvalidOperationException("控件没有到到相关的模块信息");

            this.Parameters = new Dictionary<string, object>();
        }

        /// <summary>
        /// 关闭整个应用
        /// </summary>
        public void ApplicationExit()
        {
            if (this.ViewPageBox != null)
                this.ViewPageBox.Destroy();

            this.WindowShell.Close();
        }

        public WindowShell WindowShell
        {
            get
            {
                return Window.GetWindow(this) as WindowShell;
            }
        }


    }
}
