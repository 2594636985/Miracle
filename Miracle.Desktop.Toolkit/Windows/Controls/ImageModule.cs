using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Miracle.Desktop.Toolkit.Windows.Controls
{
    public class ImageModule : Control
    {
        private Image _iImage;
        public ImageModule()
        {
            this.DefaultStyleKey = typeof(ImageModule);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (this._iImage == null)
                this._iImage = this.GetTemplateChild("InnerImage") as Image;

        }

        public static readonly DependencyProperty RootLocationProperty = DependencyProperty.Register("RootLocation", typeof(string), typeof(ImageModule));
        public string RootLocation
        {
            get
            {
                return (string)GetValue(RootLocationProperty);
            }
            set
            {
                SetValue(RootLocationProperty, value);
            }
        }

        public static readonly DependencyProperty ModuleSourceProperty = DependencyProperty.Register("ModuleSource", typeof(string), typeof(ImageModule));
        public string ModuleSource
        {
            get
            {
                return (string)GetValue(ModuleSourceProperty);
            }
            set
            {
                SetValue(ModuleSourceProperty, value);
            }
        }

        //private static void OnModuleSourceChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        //{
        //    ((ImageModule)o).OnModuleSourceChanged(Convert.ToString(e.OldValue), Convert.ToString(e.NewValue));
        //}

        //private void OnModuleSourceChanged(string oldValue, string newValue)
        //{
        //    if (string.IsNullOrWhiteSpace(newValue) || newValue.EqualsIgnoreCaseEx(oldValue))
        //        return;

        //    if (this._viewModule == null)
        //        this._viewModule = this.GetParent<ViewModule>();

        //    string imageLocation = newValue;
        //    if (!Path.IsPathRooted(newValue))
        //        imageLocation = Path.Combine(this._viewModule.Module.Location, newValue);

        //    BitmapImage bitmapImage = new BitmapImage();
        //    bitmapImage.BeginInit();
        //    bitmapImage.UriSource = new Uri(imageLocation, UriKind.Absolute);
        //    bitmapImage.EndInit();

        //    this._iImage.Source = bitmapImage;
        //}

        public static readonly DependencyProperty StretchProperty = Image.StretchProperty.AddOwner(typeof(ImageModule));
        public Stretch Stretch
        {
            get { return (Stretch)GetValue(StretchProperty); }
            set { SetValue(StretchProperty, value); }
        }

        public static readonly DependencyProperty StretchDirectionProperty = Image.StretchDirectionProperty.AddOwner(typeof(ImageModule));
        public StretchDirection StretchDirection
        {
            get { return (StretchDirection)GetValue(StretchDirectionProperty); }
            set { SetValue(StretchDirectionProperty, value); }
        }
    }

}
