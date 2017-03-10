using Miracle.Modularization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Miracle.Desktop.Toolkit.Windows
{
    public class Dialog : UserControl
    {
        public IViewPageBox ViewPageBox { set; get; }

        public void Display(IViewPageBox vPageControl, bool modal = false)
        {
            this.ViewPageBox = vPageControl;
           
        }

        public void Display(ViewPage vPageModule, bool modal = false)
        {
            this.Display(vPageModule.ViewPageBox, modal);
        }

        public void Close()
        {
           
        }
    }
}
