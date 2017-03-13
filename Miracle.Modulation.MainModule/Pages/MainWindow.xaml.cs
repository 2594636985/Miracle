using Miracle.Desktop;
using Miracle.Desktop.Toolkit.Windows;
using Miracle.Modularization;
using Miracle.Injection;
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
using System.Windows.Shapes;
using Miracle.Modulation.MainModule.Services;

namespace Miracle.Modulation.MainModule.Pages
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : WindowShell
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ViewBoxProperty = DependencyProperty.Register("ViewBox", typeof(UserControl), typeof(MainWindow), new UIPropertyMetadata(null, OnViewPageChanged));
        public UserControl ViewBox
        {
            get
            {
                return (UserControl)GetValue(ViewBoxProperty);
            }
            set
            {
                SetValue(ViewBoxProperty, value);
            }
        }

        private static void OnViewPageChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            MainWindow window = o as MainWindow;
            if (window != null)
                window.OnViewPageChanged((UserControl)e.OldValue, (UserControl)e.NewValue);
        }

        protected virtual void OnViewPageChanged(UserControl oViewPage, UserControl nViewPage)
        {

        }

        private void WindowShell_Loaded(object sender, RoutedEventArgs e)
        {
            this.ViewBox = this.GetAuthorityControl();
        }

        private void Authority_OnAuthoritySucceed(string username, string password)
        {
            PageTemplate mainViewModule = new PageTemplate();
            mainViewModule.Module = this.Module;
            mainViewModule.OnAuthorityLogout += MainViewModule_OnAuthorityLogout;

            this.ViewBox = mainViewModule;
        }
        private void Authority_OnApplicationExited(Authority obj)
        {
            this.Close();
        }

        private void MainViewModule_OnAuthorityLogout(PageTemplate obj)
        {
            this.ViewBox = this.GetAuthorityControl();
        }

        private Authority GetAuthorityControl()
        {
            Authority authority = new Authority();
            authority.Module = this.Module;
            authority.OnAuthoritySucceed += Authority_OnAuthoritySucceed;
            authority.OnApplicationExited += Authority_OnApplicationExited;

            return authority;
        }


    }
}
