using Miracle.Desktop;
using Miracle.Desktop.Toolkit.Windows;
using Miracle.Desktop.Toolkit.Windows.Controls;
using Miracle.Modularization;
using Miracle.Modulation.MainModule.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// MainViewModule.xaml 的交互逻辑
    /// </summary>
    public partial class PageTemplate : UserControl
    {
        private DispatcherTimer _timer = new DispatcherTimer();

        public event Action<PageTemplate> OnAuthorityLogout;
        public IModule Module { set; get; }
        public Button CurrentMenuButton { private set; get; }

        public static readonly DependencyProperty SelectedLinkProperty = DependencyProperty.Register("SelectedLink", typeof(LinkViewModel), typeof(PageTemplate));
        public LinkViewModel SelectedLink
        {
            get { return (LinkViewModel)GetValue(SelectedLinkProperty); }
            set { SetValue(SelectedLinkProperty, value); }
        }

        public PageTemplate()
        {
            InitializeComponent();
        }

        private void PageTemplate_Loaded(object sender, RoutedEventArgs e)
        {
            this.SetupViewPageBox();

            this.UpdateSystemTime();

            this.InitializeAuthority();

            this.InitializeMenuLink();

            this.StartTimer();

        }

        private void PageTemplate_Unloaded(object sender, RoutedEventArgs e)
        {
            this._timer.Stop();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.UpdateSystemTime();
        }

        private void PageTemplate_Initialized(object sender, EventArgs e)
        {
            this._timer.Interval = TimeSpan.FromSeconds(4);
            this._timer.Tick += Timer_Tick;
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            if (this.OnAuthorityLogout != null)
                this.OnAuthorityLogout(this);
        }

        private void BtnMenu_Click(object sender, RoutedEventArgs e)
        {
            Button mButton = sender as Button;
            if (this.CurrentMenuButton == null || this.CurrentMenuButton != mButton)
            {
                if (mButton != null && mButton.DataContext != null)
                {
                    LinkViewModel linkViewModel = mButton.DataContext as LinkViewModel;

                    this._viewPageBox.DisplayLink = new Link(linkViewModel.ModuleName, linkViewModel.ViewPageLocation);

                    Navbar.CloseDrawerCommand.Execute(Dock.Right, mButton);

                    this.CurrentMenuButton = mButton;
                }
            }
        }

        /// <summary>
        /// 设置页面加载器
        /// </summary>
        private void SetupViewPageBox()
        {
            this._viewPageBox.ModuleFramework = this.Module.ModuleFramework;
        }

        /// <summary>
        /// 更新系统时间
        /// </summary>
        private void UpdateSystemTime()
        {
            this._tbOpenTime.Text = DateTime.Now.ToString(" yyyy-MM-dd  hh:mm");
        }

        /// <summary>
        /// 初始化登录用户信息
        /// </summary>
        private void InitializeAuthority()
        {
            this._tbAuthorityName.Text = "Aomi";
        }

        /// <summary>
        /// 初始化菜单导航
        /// </summary>
        private void InitializeMenuLink()
        {
            MainViewModuleViewModel mvmvm = this.DataContext as MainViewModuleViewModel;

            if (mvmvm.LinkGroupViewModels == null)
                mvmvm.LinkGroupViewModels = new System.Collections.ObjectModel.ObservableCollection<LinkGroupViewModel>();
            else
                mvmvm.LinkGroupViewModels.Clear();

            List<IModule> extModules = this.Module.ModuleFramework.GetExtModules();

            foreach (IModule extModule in extModules)
            {
                if (extModule.Links.Count > 0)
                {
                    LinkGroupViewModel lgvm = new LinkGroupViewModel();
                    lgvm.DisplayName = extModule.AppName;
                    lgvm.ModuleName = extModule.ModuleName;

                    foreach (Link link in extModule.Links)
                    {
                        LinkViewModel lvm = new LinkViewModel();
                        lvm.ModuleName = extModule.ModuleName;
                        lvm.AppName = link.AppName;
                        lvm.ViewPageLocation = link.ViewPageLocation;

                        lgvm.LinkViewModels.Add(lvm);
                    }

                    mvmvm.LinkGroupViewModels.Add(lgvm);
                }
            }

            //如果存在数据的话，选择第一条为默认显示
            if (mvmvm.LinkGroupViewModels.Count > 0)
            {
                LinkGroupViewModel defaultLinkGroup = mvmvm.LinkGroupViewModels[0];
                if (defaultLinkGroup.LinkViewModels.Count > 0)
                {
                    LinkViewModel defaultLink = defaultLinkGroup.LinkViewModels[0];
                    this._viewPageBox.DisplayLink = this._viewPageBox.DisplayLink = new Link(defaultLink.ModuleName, defaultLink.AppName, defaultLink.ViewPageLocation);
                }
            }
        }

        /// <summary>
        /// 开始执行时间
        /// </summary>
        private void StartTimer()
        {
            this._timer.Start();
        }

        private void ViewPageBox_ViewFailure(ViewPageBox arg1, Link arg2, Link arg3)
        {

            //this.CurrentMenuButton.IsEnabled = true;
        }

        private void ViewPageBox_ViewPageChanged(ViewPageBox vPageBox, Link nLink, IViewPage vPage)
        {
            MainViewModuleViewModel mvmvm = this.DataContext as MainViewModuleViewModel;

            foreach (LinkGroupViewModel lgvm in mvmvm.LinkGroupViewModels)
            {
                LinkViewModel selectLinkViewModel = lgvm.LinkViewModels.FirstOrDefault(lvm => lvm.ModuleName == nLink.ModuleName && lvm.ViewPageLocation == nLink.ViewPageLocation);

                if (selectLinkViewModel != null)
                {
                    this.SelectedLink = selectLinkViewModel;
                    break;
                }

            }

        }
    }
}
