using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Miracle.Desktop.Toolkit.Windows.Controls
{
    public partial class Icon : Control
    {
        private static Lazy<IDictionary<IconMark, string>> dataIndex;

        public Icon()
        {
            this.DefaultStyleKey = typeof(Icon);

            if (dataIndex == null)
                dataIndex = new Lazy<IDictionary<IconMark, string>>(this.Create);
        }

        public static readonly DependencyProperty IconMarkProperty = DependencyProperty.Register("IconMark", typeof(IconMark), typeof(Icon), new PropertyMetadata(default(IconMark), KindPropertyChangedCallback));

        private static void KindPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            ((Icon)dependencyObject).UpdateData();
        }

        public IconMark IconMark
        {
            get { return (IconMark)GetValue(IconMarkProperty); }
            set { SetValue(IconMarkProperty, value); }
        }

        private static readonly DependencyPropertyKey DataPropertyKey = DependencyProperty.RegisterReadOnly("Data", typeof(string), typeof(Icon), new PropertyMetadata(""));

        public static readonly DependencyProperty DataProperty = DataPropertyKey.DependencyProperty;


        [TypeConverter(typeof(GeometryConverter))]
        public string Data
        {
            get { return (string)GetValue(DataProperty); }
            private set { SetValue(DataPropertyKey, value); }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            UpdateData();
        }

        internal void UpdateData()
        {
            string data = null;
            if (dataIndex.Value != null)
                dataIndex.Value.TryGetValue(IconMark, out data);
            Data = data;
        }
    }

    public enum IconMark
    {
        User,
        Password,
        Server
    }
}
