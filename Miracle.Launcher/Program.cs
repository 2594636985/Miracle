using Miracle.Modularization.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Launcher
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            Miracle.Launcher.App app = new Miracle.Launcher.App();
            app.InitializeComponent();
            app.Run();
        }
    }
}
