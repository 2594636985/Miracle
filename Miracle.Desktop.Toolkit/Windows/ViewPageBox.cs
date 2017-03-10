using Miracle.Desktop.Toolkit.Windows;
using Miracle.Modularization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Miracle.Desktop.Toolkit.Windows
{
    /// <summary>
    /// 页面选择器
    /// </summary>
    /// 
    [TemplatePart(Name = PART_Overlay, Type = typeof(Grid))]
    [TemplatePart(Name = PART_DialogZone, Type = typeof(Grid))]
    public class ViewPageBox : ContentControl, IViewPageBox
    {
        private const string PART_Overlay = "PART_Overlay";
        private const string PART_DialogZone = "PART_DialogZone";

        private Stack<Link> _linkStack = new Stack<Link>();
        private Dictionary<Link, IViewPage> _viewModuleCache = new Dictionary<Link, IViewPage>();
        private CancellationTokenSource _cancellationTokenSource;
        private bool _linkStacked = true;

        private Grid _gridOverlay;
        private Grid _gridDialogZone;

        public event Action<ViewPageBox, Link, IViewPage> OnViewPageChanged;
        public event Action<ViewPageBox, IViewPage> OnViewPageChanging;

        public event Action<ViewPageBox, Link, Link> OnViewBacking;
        public event Action<ViewPageBox, Link, Link> OnViewBacked;
        public event Action<ViewPageBox, Link, Link> OnViewFailure;

        public IModuleFramework ModuleFramework { set; get; }

        /// <summary>
        /// 当前Link的个数
        /// </summary>
        public int LinkStackCount { get { return this._linkStack.Count; } }

        public bool BackLinkEnabled { get { return this.LinkStackCount > 1; } }

        public Session Session { private set; get; }


        public ViewPageBox()
        {
            this.DefaultStyleKey = typeof(ViewPageBox);
            this.Session = new Session();


        }


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (this._gridOverlay == null)
                this._gridOverlay = GetTemplateChild(PART_Overlay) as Grid;

            if (this._gridDialogZone == null)
                this._gridDialogZone = GetTemplateChild(PART_DialogZone) as Grid;



        }

        /// <summary>
        /// 返回前一个Link
        /// </summary>
        public void BackLink()
        {
            if (this.BackLinkEnabled)
            {
                this._linkStacked = false;

                Link oldLink = this.DisplayLink as Link;

                this._linkStack.Pop();

                Link newLink = this._linkStack.Peek();

                if (this.OnViewBacking != null)
                    this.OnViewBacking(this, oldLink, newLink);

                SetCurrentValue(DisplayLinkProperty, this._linkStack.Peek());


                if (this.OnViewBacked != null)
                    this.OnViewBacked(this, oldLink, newLink);

                this._linkStacked = true;
            }
        }

        /// <summary>
        /// 跳到最后一个Link
        /// </summary>
        public void GotoLastLink()
        {
            while (this.LinkStackCount > 1)
            {
                this._linkStack.Pop();
            }

            this._linkStacked = false;
            this.SetCurrentValue(DisplayLinkProperty, this._linkStack.Peek());
            this._linkStacked = true;
        }

        /// <summary>
        /// 清除
        /// </summary>
        public void Destroy()
        {
            this._linkStack.Clear();
            this._viewModuleCache.Clear();
            this.Session.Clear();
        }


        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        private static void OnSourceChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            ((ViewPageBox)o).OnSourceChanged((Link)e.OldValue, (Link)e.NewValue);
        }

        /// <summary>
        /// 当显示器里面link发生变化的时候执行
        /// </summary>
        /// <param name="oldLink"></param>
        /// <param name="newLink"></param>
        private void OnSourceChanged(Link oldLink, Link newLink)
        {
            if (newLink != null && newLink == oldLink)
                return;

            //启动加载界面
            SetValue(IsViewPageLoadingPropertyKey, true);

            //关闭前面没有结束的线程
            if (this._cancellationTokenSource != null)
            {
                this._cancellationTokenSource.Cancel();
                this._cancellationTokenSource = null;
            }

            IViewPage newViewPage = null;

            if (newLink != null)
            {
                if (!this._viewModuleCache.TryGetValue(newLink, out newViewPage))
                {
                    this._cancellationTokenSource = new CancellationTokenSource();
                    this.ContentLoader.Module = this.ModuleFramework.GetModule(newLink.ModuleName);//设置加载当前所用的模块

                    TaskScheduler scheduler = TaskScheduler.FromCurrentSynchronizationContext();
                    Task<IViewPage> task = this.ContentLoader.LoadContentAsync(newLink, this._cancellationTokenSource.Token);
                    task.ContinueWith(t =>
                    {

                        try
                        {
                            if (t.IsCanceled || this._cancellationTokenSource.IsCancellationRequested)
                            {
                                Debug.WriteLine("Cancelled navigation to '{0}'", newLink);

                                if (this._linkStack.Peek() == newLink && this.DisplayLink != this._linkStack.Peek())
                                    this._linkStack.Pop();
                            }
                            else if (!t.IsFaulted && t.IsCompleted)
                            {
                                IViewPage viewModule = t.Result as IViewPage;

                                if (viewModule.Parameters == null)
                                    viewModule.Parameters = new Dictionary<string, object>();

                                if (newLink.Parameters != null && newLink.Parameters.Count > 0)
                                {
                                    foreach (string keyName in newLink.Parameters.Keys)
                                    {
                                        viewModule.Parameters.Add(keyName, newLink.Parameters[keyName]);
                                    }

                                    newLink.Parameters.Clear();
                                }

                                if (viewModule.Cached)
                                    this._viewModuleCache[newLink] = viewModule;

                                if (this._linkStacked && viewModule.Stacked)
                                    this._linkStack.Push(newLink);

                                SetContent(newLink, viewModule);

                                if (this.OnViewFailure != null)
                                    this.OnViewFailure(this, newLink, oldLink);
                            }
                        }
                        catch (Exception ex)
                        {
                            if (this.OnViewFailure != null)
                                this.OnViewFailure(this, newLink, oldLink);
                        }
                        finally
                        {
                            this._cancellationTokenSource.Dispose();
                            this._cancellationTokenSource = null;
                        }
                    }, scheduler);
                }
                else
                {
                    SetContent(newLink, newViewPage);
                }
            }
        }

        private void SetContent(Link nLink, IViewPage vPageModule)
        {
            vPageModule.ViewPageBox = this;

            if (this.OnViewPageChanging != null)
                this.OnViewPageChanging(this, vPageModule);

            this.Content = vPageModule;

            if (this.OnViewPageChanged != null)
                this.OnViewPageChanged(this, nLink, vPageModule);

            SetValue(IsViewPageLoadingPropertyKey, false);

        }


        /// <summary>
        /// 内部加载器
        /// </summary>
        public static readonly DependencyProperty ContentLoaderProperty = DependencyProperty.Register("ContentLoader", typeof(IViewPageLoader), typeof(ViewPageBox), new PropertyMetadata(new DefaultViewPageLoader()));


        /// <summary>
        /// 获得或设置内容加载器
        /// </summary>
        public IViewPageLoader ContentLoader
        {
            get { return (IViewPageLoader)GetValue(ContentLoaderProperty); }
            set { SetValue(ContentLoaderProperty, value); }
        }


        /// <summary>
        /// 用于表达只读依赖属性
        /// </summary>
        private static readonly DependencyPropertyKey IsViewPageLoadingPropertyKey = DependencyProperty.RegisterReadOnly("IsViewPageLoading", typeof(bool), typeof(ViewPageBox), new PropertyMetadata(false));

        public static readonly DependencyProperty IsViewPageLoadingProperty = IsViewPageLoadingPropertyKey.DependencyProperty;

        /// <summary>
        /// 获得一值表示现在加载当前的内容部分
        /// </summary>
        public bool IsViewPageLoading
        {
            get { return (bool)GetValue(IsViewPageLoadingProperty); }
        }


        /// <summary>
        /// 显示视图页面
        /// </summary>
        public static readonly DependencyProperty DisplayLinkProperty = DependencyProperty.Register("DisplayLink", typeof(Link), typeof(ViewPageBox), new PropertyMetadata(OnSourceChanged));

        /// <summary>
        /// 获得或是设置视图页面
        /// </summary>
        public Link DisplayLink
        {
            get { return (Link)GetValue(DisplayLinkProperty); }
            set { SetValue(DisplayLinkProperty, value); }
        }

        internal void DisplayDialog(Dialog dialog)
        {
            if (dialog != null)
            {
                this._gridDialogZone.Children.Add(dialog);
                this._gridDialogZone.Visibility = System.Windows.Visibility.Visible;
                this._gridOverlay.Visibility = System.Windows.Visibility.Visible;
            }
        }

        internal void CloseDialog(Dialog dialog)
        {
            if (this._gridDialogZone.Children.Contains(dialog))
            {
                this._gridDialogZone.Children.Remove(dialog);
                this._gridDialogZone.Visibility = System.Windows.Visibility.Hidden;
                this._gridOverlay.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        public void Display(string moduleName, string vPageLocation)
        {
            this.Display(new Link(moduleName, vPageLocation));
        }

        public void Display(Link link)
        {
            this.DisplayLink = link;
        }
    }

}
