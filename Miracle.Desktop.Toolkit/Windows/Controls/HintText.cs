using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Miracle.Desktop.Toolkit.Windows.Controls
{
    public class HintText : TextBox
    {
        public HintText()
        {
            this.DefaultStyleKey = typeof(HintText);
        }

        public static readonly DependencyProperty HintProperty = DependencyProperty.Register("Hint", typeof(string), typeof(HintText));
        public string Hint
        {
            get { return (string)GetValue(HintProperty); }
            set { SetValue(HintProperty, value); }
        }

        public static readonly int a;
    }
}
