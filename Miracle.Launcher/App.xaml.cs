using Miracle.Master;
using Miracle.Modularization;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Miracle.Desktop.Toolkit.Windows;

namespace Miracle.Launcher
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        MiracleMaster _mMaster = new MiracleMaster();
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            this._mMaster.SteupViewPageLoader(new DefaultViewPageLoader());
            this._mMaster.Initialize();
            this._mMaster.Start();

            this.MainWindow = _mMaster.GetAppWindowShell() as Window;

            this.MainWindow.Show();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            this._mMaster.Stop();
        }

    }
}
