using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Miracle.Desktop.Toolkit.Windows.Controls
{
    public class PathButton : Button
    {
        public PathButton()
        {
            this.DefaultStyleKey = typeof(PathButton);
        }

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(PathButton), new PropertyMetadata(new CornerRadius()));

        public static readonly DependencyProperty DataProperty = DependencyProperty.Register("Data", typeof(Geometry), typeof(PathButton));
        public Geometry Data
        {
            get { return (Geometry)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }
    }
}
