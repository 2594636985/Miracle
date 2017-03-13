using Miracle.Desktop.Toolkit.Windows;
using Miracle.Injection;
using Miracle.Modularization;
using Miracle.Modulation.MainModule.Code;
using Miracle.Modulation.MainModule.Model;
using Miracle.Modulation.MainModule.Services;
using Miracle.Modulation.MainModule.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Miracle.Modulation.MainModule.Pages
{
    /// <summary>
    /// Authority.xaml 的交互逻辑
    /// </summary>
    public partial class Authority : UserControl
    {
        private DispatcherTimer _timer = new DispatcherTimer();

        public IModule Module { set; get; }

        public event Action<string, string> OnAuthoritySucceed;

        public event Action<Authority> OnApplicationExited;

        public Authority()
        {
            InitializeComponent();
        }

        private void Authority_Initialized(object sender, EventArgs e)
        {
            this._timer.Interval = TimeSpan.FromSeconds(4);
            this._timer.Tick += Timer_Tick;
        }


        private void Authority_Unloaded(object sender, RoutedEventArgs e)
        {
            this._timer.Stop();
        }

        private void Authority_Loaded(object sender, RoutedEventArgs e)
        {
            this.UpdateSystemTime();
            this._timer.Start();

        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            AuthorityService authorityService = this.Module.GetService<AuthorityService>();

            User user = authorityService.GetUserById("");

           var aa = authorityService.ToString();

            if (this.OnAuthoritySucceed != null)
                this.OnAuthoritySucceed("", "");
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            if (this.OnApplicationExited != null)
                this.OnApplicationExited(this);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.UpdateSystemTime();
        }

        /// <summary>
        /// 更新系统时间
        /// </summary>
        private void UpdateSystemTime()
        {
            this._tbOpenTime.Text = DateTime.Now.ToString(" yyyy-MM-dd  hh:mm");
        }
    }
}
