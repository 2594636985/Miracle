using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Miracle.Desktop.Toolkit.Windows;
using Miracle.Modularization;

namespace Miracle.Desktop.Toolkit.Windows
{
    /// <summary>
    /// 窗体显示器
    /// </summary>
    /// 
    public class WindowShell : Window, IWindowShell, IDependency
    {
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            this.DragMove();
        }

        public IModule Module { set; get; }
    }
}
