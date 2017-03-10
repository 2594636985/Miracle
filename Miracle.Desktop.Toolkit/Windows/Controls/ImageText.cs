using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Miracle.Desktop.Toolkit.Windows.Controls
{
    public class ImageText : Control
    {
        private HintText _hintText;
        public ImageText()
        {
            this.DefaultStyleKey = typeof(ImageText);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (this._hintText != null)
            {
                this._hintText.TextChanged -= this.HintText_TextChanged;
            }

            this._hintText = this.GetTemplateChild("PART_InputText") as HintText;

            if (this._hintText != null)
            {
                this._hintText.TextChanged += this.HintText_TextChanged;
            }
        }

        private void HintText_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Text = ((HintText)(sender)).Text;
        }

        public static readonly DependencyProperty TextProperty = TextBox.TextProperty.AddOwner(typeof(ImageText));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty HintProperty = HintText.HintProperty.AddOwner(typeof(ImageText));
        public string Hint
        {
            get { return (string)GetValue(HintProperty); }
            set { SetValue(HintProperty, value); }
        }


        public static readonly DependencyProperty DataProperty = Path.DataProperty.AddOwner(typeof(ImageText));
        public Geometry Data
        {
            get { return (Geometry)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        public static readonly DependencyProperty IHeightProperty = DependencyProperty.Register("IHeight", typeof(double), typeof(ImageText), new PropertyMetadata(20D));
        public double IHeight
        {
            get { return (double)GetValue(IHeightProperty); }
            set { SetValue(IHeightProperty, value); }
        }


        public static readonly DependencyProperty IWidthProperty = DependencyProperty.Register("IWidth", typeof(double), typeof(ImageText), new PropertyMetadata(20D));
        public double IWidth
        {
            get { return (double)GetValue(IWidthProperty); }
            set { SetValue(IWidthProperty, value); }
        }

        public static readonly DependencyProperty IsReadOnlyProperty = TextBox.IsReadOnlyProperty.AddOwner(typeof(ImageText));
        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }
    }
}
