using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Miracle.Desktop.Toolkit.Windows.Controls
{
    public class DropDown : ContentControl
    {
        public DropDown()
        {
            this.DefaultStyleKey = typeof(DropDown);
        }

        public static readonly DependencyProperty DropDownPositionProperty = DependencyProperty.Register("DropDownPosition", typeof(PlacementMode), typeof(DropDown), new UIPropertyMetadata(PlacementMode.Bottom));
        public PlacementMode DropDownPosition
        {
            get
            {
                return (PlacementMode)GetValue(DropDownPositionProperty);
            }
            set
            {
                SetValue(DropDownPositionProperty, value);
            }
        }

        public static readonly DependencyProperty DropDownContentProperty = DependencyProperty.Register("DropDownContent", typeof(object), typeof(DropDown));
        public object DropDownContent
        {
            get
            {
                return (object)GetValue(DropDownContentProperty);
            }
            set
            {
                SetValue(DropDownContentProperty, value);
            }
        }

        public static readonly DependencyProperty MaxDropDownHeightProperty = DependencyProperty.Register("MaxDropDownHeight", typeof(double), typeof(DropDown), new UIPropertyMetadata(SystemParameters.PrimaryScreenHeight / 2.0));
        public double MaxDropDownHeight
        {
            get
            {
                return (double)GetValue(MaxDropDownHeightProperty);
            }
            set
            {
                SetValue(MaxDropDownHeightProperty, value);
            }
        }
    }
}
