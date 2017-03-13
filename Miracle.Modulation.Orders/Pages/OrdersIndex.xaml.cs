using Miracle.Desktop.Toolkit.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Miracle.Modulation.Orders.Pages
{
    /// <summary>
    /// OrdersIndex.xaml 的交互逻辑
    /// </summary>
    public partial class OrdersIndex : ViewPage
    {
        public OrdersIndex()
        {
            InitializeComponent();
        }

        private void ViewModule_Loaded(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 点击“更多”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMore_Click(object sender, RoutedEventArgs e)
        {
            FrmMore dd = new FrmMore();
            dd.Show();
        }
    }
}
