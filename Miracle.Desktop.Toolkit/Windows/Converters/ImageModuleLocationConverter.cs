using Miracle.Modularization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Miracle.Desktop.Toolkit.Windows.Converters
{
    public class ImageModuleLocationConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (values != null && values.Length > 0 && values[0] != null)
            {
                if (values.Length == 2 && values[1] != null)
                {
                    string moduleName = System.Convert.ToString(values[0]);

                    if (!string.IsNullOrWhiteSpace(moduleName))
                    {
                        return new BitmapImage(new Uri(Path.Combine(System.Convert.ToString(values[0]), System.Convert.ToString(values[1])), UriKind.Absolute));
                    }
                }

                return new BitmapImage(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, System.Convert.ToString(values[1])), UriKind.Absolute));
            }

            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
