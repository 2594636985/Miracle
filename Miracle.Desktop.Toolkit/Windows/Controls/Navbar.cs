using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Miracle.Desktop.Toolkit.Windows.Controls
{
    [TemplateVisualState(GroupName = TemplateAllDrawersGroupName, Name = TemplateAllDrawersAllClosedStateName)]
    [TemplateVisualState(GroupName = TemplateAllDrawersGroupName, Name = TemplateAllDrawersAnyOpenStateName)]
    [TemplateVisualState(GroupName = TemplateLeftDrawerGroupName, Name = TemplateLeftClosedStateName)]
    [TemplateVisualState(GroupName = TemplateLeftDrawerGroupName, Name = TemplateLeftOpenStateName)]
    [TemplateVisualState(GroupName = TemplateRightDrawerGroupName, Name = TemplateRightClosedStateName)]
    [TemplateVisualState(GroupName = TemplateRightDrawerGroupName, Name = TemplateRightOpenStateName)]
    [TemplatePart(Name = TemplateContentCoverPartName, Type = typeof(FrameworkElement))]
    [TemplatePart(Name = TemplateLeftDrawerPartName, Type = typeof(FrameworkElement))]
    [TemplatePart(Name = TemplateRightDrawerPartName, Type = typeof(FrameworkElement))]
    public class Navbar : ContentControl
    {
        public const string TemplateAllDrawersGroupName = "AllDrawers";
        public const string TemplateAllDrawersAllClosedStateName = "AllClosed";
        public const string TemplateAllDrawersAnyOpenStateName = "AnyOpen";
        public const string TemplateLeftDrawerGroupName = "LeftDrawer";
        public const string TemplateLeftClosedStateName = "LeftDrawerClosed";
        public const string TemplateLeftOpenStateName = "LeftDrawerOpen";

        public const string TemplateRightDrawerGroupName = "RightDrawer";
        public const string TemplateRightClosedStateName = "RightDrawerClosed";
        public const string TemplateRightOpenStateName = "RightDrawerOpen";


        public const string TemplateContentCoverPartName = "PART_ContentCover";
        public const string TemplateLeftDrawerPartName = "PART_LeftDrawer";
        public const string TemplateRightDrawerPartName = "PART_RightDrawer";

        public static RoutedCommand OpenDrawerCommand = new RoutedCommand();
        public static RoutedCommand CloseDrawerCommand = new RoutedCommand();

        private FrameworkElement _templateContentCoverElement;
        private FrameworkElement _leftDrawerElement;
        private FrameworkElement _rightDrawerElement;

        private bool _lockZIndexes;

        private readonly IDictionary<DependencyProperty, DependencyPropertyKey> _zIndexPropertyLookup = new Dictionary<DependencyProperty, DependencyPropertyKey>
        {
            { IsLeftDrawerOpenProperty, LeftDrawerZIndexPropertyKey },
            { IsRightDrawerOpenProperty, RightDrawerZIndexPropertyKey }
        };

        static Navbar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Navbar), new FrameworkPropertyMetadata(typeof(Navbar)));
        }

        public Navbar()
        {
            CommandBindings.Add(new CommandBinding(OpenDrawerCommand, OpenDrawerHandler));
            CommandBindings.Add(new CommandBinding(CloseDrawerCommand, CloseDrawerHandler));
        }

        public static readonly DependencyProperty DisableTransitionsProperty = DependencyProperty.Register("DisableTransitions", typeof(bool), typeof(Navbar), new FrameworkPropertyMetadata(default(bool)));
        public bool DisableTransitions
        {
            get { return (bool)GetValue(DisableTransitionsProperty); }
            set { SetValue(DisableTransitionsProperty, value); }
        }

        #region  左边弹出功能

        public static readonly DependencyProperty LeftDrawerContentProperty = DependencyProperty.Register(
            "LeftDrawerContent", typeof(object), typeof(Navbar), new PropertyMetadata(default(object)));

        public object LeftDrawerContent
        {
            get { return (object)GetValue(LeftDrawerContentProperty); }
            set { SetValue(LeftDrawerContentProperty, value); }
        }

        public static readonly DependencyProperty LeftDrawerContentTemplateProperty = DependencyProperty.Register(
            "LeftDrawerContentTemplate", typeof(DataTemplate), typeof(Navbar), new PropertyMetadata(default(DataTemplate)));

        public DataTemplate LeftDrawerContentTemplate
        {
            get { return (DataTemplate)GetValue(LeftDrawerContentTemplateProperty); }
            set { SetValue(LeftDrawerContentTemplateProperty, value); }
        }

        public static readonly DependencyProperty LeftDrawerContentTemplateSelectorProperty = DependencyProperty.Register(
            "LeftDrawerContentTemplateSelector", typeof(DataTemplateSelector), typeof(Navbar), new PropertyMetadata(default(DataTemplateSelector)));

        public DataTemplateSelector LeftDrawerContentTemplateSelector
        {
            get { return (DataTemplateSelector)GetValue(LeftDrawerContentTemplateSelectorProperty); }
            set { SetValue(LeftDrawerContentTemplateSelectorProperty, value); }
        }

        public static readonly DependencyProperty LeftDrawerContentStringFormatProperty = DependencyProperty.Register(
            "LeftDrawerContentStringFormat", typeof(string), typeof(Navbar), new PropertyMetadata(default(string)));

        public string LeftDrawerContentStringFormat
        {
            get { return (string)GetValue(LeftDrawerContentStringFormatProperty); }
            set { SetValue(LeftDrawerContentStringFormatProperty, value); }
        }

        public static readonly DependencyProperty LeftDrawerBackgroundProperty = DependencyProperty.Register(
            "LeftDrawerBackground", typeof(Brush), typeof(Navbar), new PropertyMetadata(default(Brush)));

        public Brush LeftDrawerBackground
        {
            get { return (Brush)GetValue(LeftDrawerBackgroundProperty); }
            set { SetValue(LeftDrawerBackgroundProperty, value); }
        }

        public static readonly DependencyProperty IsLeftDrawerOpenProperty = DependencyProperty.Register(
            "IsLeftDrawerOpen", typeof(bool), typeof(Navbar), new FrameworkPropertyMetadata(default(bool), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, IsDrawerOpenPropertyChangedCallback));

        public bool IsLeftDrawerOpen
        {
            get { return (bool)GetValue(IsLeftDrawerOpenProperty); }
            set { SetValue(IsLeftDrawerOpenProperty, value); }
        }

        private static readonly DependencyPropertyKey LeftDrawerZIndexPropertyKey =
                                            DependencyProperty.RegisterReadOnly(
                                            "LeftDrawerZIndex", typeof(int), typeof(Navbar),
                                            new PropertyMetadata(2));

        public static readonly DependencyProperty LeftDrawerZIndexProperty = LeftDrawerZIndexPropertyKey.DependencyProperty;

        public int LeftDrawerZIndex
        {
            get { return (int)GetValue(LeftDrawerZIndexProperty); }
            private set { SetValue(LeftDrawerZIndexPropertyKey, value); }
        }

        #endregion

        #region 右边弹出功能

        public static readonly DependencyProperty RightDrawerContentProperty = DependencyProperty.Register(
            "RightDrawerContent", typeof(object), typeof(Navbar), new PropertyMetadata(default(object)));

        public object RightDrawerContent
        {
            get { return (object)GetValue(RightDrawerContentProperty); }
            set { SetValue(RightDrawerContentProperty, value); }
        }

        public static readonly DependencyProperty RightDrawerContentTemplateProperty = DependencyProperty.Register(
            "RightDrawerContentTemplate", typeof(DataTemplate), typeof(Navbar), new PropertyMetadata(default(DataTemplate)));

        public DataTemplate RightDrawerContentTemplate
        {
            get { return (DataTemplate)GetValue(RightDrawerContentTemplateProperty); }
            set { SetValue(RightDrawerContentTemplateProperty, value); }
        }

        public static readonly DependencyProperty RightDrawerContentTemplateSelectorProperty = DependencyProperty.Register(
           "RightDrawerContentTemplateSelector", typeof(DataTemplateSelector), typeof(Navbar), new PropertyMetadata(default(DataTemplateSelector)));

        public DataTemplateSelector RightDrawerContentTemplateSelector
        {
            get { return (DataTemplateSelector)GetValue(RightDrawerContentTemplateSelectorProperty); }
            set { SetValue(RightDrawerContentTemplateSelectorProperty, value); }
        }

        public static readonly DependencyProperty RightDrawerContentStringFormatProperty = DependencyProperty.Register(
           "RightDrawerContentStringFormat", typeof(string), typeof(Navbar), new PropertyMetadata(default(string)));

        public string RightDrawerContentStringFormat
        {
            get { return (string)GetValue(RightDrawerContentStringFormatProperty); }
            set { SetValue(RightDrawerContentStringFormatProperty, value); }
        }

        public static readonly DependencyProperty RightDrawerBackgroundProperty = DependencyProperty.Register(
            "RightDrawerBackground", typeof(Brush), typeof(Navbar), new PropertyMetadata(default(Brush)));

        public Brush RightDrawerBackground
        {
            get { return (Brush)GetValue(RightDrawerBackgroundProperty); }
            set { SetValue(RightDrawerBackgroundProperty, value); }
        }

        public static readonly DependencyProperty IsRightDrawerOpenProperty = DependencyProperty.Register(
            "IsRightDrawerOpen", typeof(bool), typeof(Navbar), new FrameworkPropertyMetadata(default(bool), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, IsDrawerOpenPropertyChangedCallback));

        public bool IsRightDrawerOpen
        {
            get { return (bool)GetValue(IsRightDrawerOpenProperty); }
            set { SetValue(IsRightDrawerOpenProperty, value); }
        }

        private static readonly DependencyPropertyKey RightDrawerZIndexPropertyKey =
                                    DependencyProperty.RegisterReadOnly(
                                    "RightDrawerZIndex", typeof(int), typeof(Navbar),
                                    new PropertyMetadata(1));

        public static readonly DependencyProperty RightDrawerZIndexProperty = RightDrawerZIndexPropertyKey.DependencyProperty;

        public int RightDrawerZIndex
        {
            get { return (int)GetValue(RightDrawerZIndexProperty); }
            private set { SetValue(RightDrawerZIndexPropertyKey, value); }
        }

        #endregion



        public override void OnApplyTemplate()
        {
            if (_templateContentCoverElement != null)
                _templateContentCoverElement.PreviewMouseLeftButtonUp += TemplateContentCoverElementOnPreviewMouseLeftButtonUp;
            WireDrawer(_leftDrawerElement, true);
            WireDrawer(_rightDrawerElement, true);

            base.OnApplyTemplate();

            _templateContentCoverElement = GetTemplateChild(TemplateContentCoverPartName) as FrameworkElement;
            if (_templateContentCoverElement != null)
                _templateContentCoverElement.PreviewMouseLeftButtonUp += TemplateContentCoverElementOnPreviewMouseLeftButtonUp;
            _leftDrawerElement = WireDrawer(GetTemplateChild(TemplateLeftDrawerPartName) as FrameworkElement, false);
            _rightDrawerElement = WireDrawer(GetTemplateChild(TemplateRightDrawerPartName) as FrameworkElement, false);

            UpdateVisualStates(false);
        }

        private FrameworkElement WireDrawer(FrameworkElement drawerElement, bool unwire)
        {
            if (drawerElement == null) return null;

            if (unwire)
            {
                drawerElement.GotFocus -= DrawerElement_GotFocus;
                drawerElement.MouseDown -= DrawerElement_MouseDown;

                return drawerElement;
            }

            drawerElement.GotFocus += DrawerElement_GotFocus;
            drawerElement.MouseDown += DrawerElement_MouseDown;

            return drawerElement;
        }

        private void DrawerElement_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ReactToFocus(sender);
        }

        private void DrawerElement_GotFocus(object sender, RoutedEventArgs e)
        {
            ReactToFocus(sender);
        }

        private void ReactToFocus(object sender)
        {
            if (sender == _leftDrawerElement)
                PrepareZIndexes(LeftDrawerZIndexPropertyKey);
            else if (sender == _rightDrawerElement)
                PrepareZIndexes(RightDrawerZIndexPropertyKey);
        }

        private void TemplateContentCoverElementOnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            SetCurrentValue(IsLeftDrawerOpenProperty, false);
            SetCurrentValue(IsRightDrawerOpenProperty, false);
        }

        private void UpdateVisualStates(bool? useTransitions = null)
        {
            var anyOpen = IsLeftDrawerOpen || IsRightDrawerOpen;

            VisualStateManager.GoToState(this,
                !anyOpen ? TemplateAllDrawersAllClosedStateName : TemplateAllDrawersAnyOpenStateName, useTransitions.HasValue ? useTransitions.Value : !this.DisableTransitions);

            VisualStateManager.GoToState(this,
                IsLeftDrawerOpen ? TemplateLeftOpenStateName : TemplateLeftClosedStateName, useTransitions.HasValue ? useTransitions.Value : !this.DisableTransitions);

            VisualStateManager.GoToState(this,
                IsRightDrawerOpen ? TemplateRightOpenStateName : TemplateRightClosedStateName, useTransitions.HasValue ? useTransitions.Value : !this.DisableTransitions);

        }

        private static void IsDrawerOpenPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var drawerHost = (Navbar)dependencyObject;
            if (!drawerHost._lockZIndexes && (bool)dependencyPropertyChangedEventArgs.NewValue)
                drawerHost.PrepareZIndexes(drawerHost._zIndexPropertyLookup[dependencyPropertyChangedEventArgs.Property]);
            drawerHost.UpdateVisualStates();
        }

        private void PrepareZIndexes(DependencyPropertyKey zIndexDependencyPropertyKey)
        {
            var newOrder = new[] { zIndexDependencyPropertyKey }
                .Concat(_zIndexPropertyLookup.Values.Except(new[] { zIndexDependencyPropertyKey })
                .OrderByDescending(dpk => (int)GetValue(dpk.DependencyProperty)))
                .Reverse()
                .Select((dpk, idx) => new { dpk, idx });

            foreach (var a in newOrder)
                SetValue(a.dpk, a.idx);
        }

        private void CloseDrawerHandler(object sender, ExecutedRoutedEventArgs executedRoutedEventArgs)
        {
            if (executedRoutedEventArgs.Handled) return;

            SetOpenFlag(executedRoutedEventArgs, false);

            executedRoutedEventArgs.Handled = true;
        }

        private void OpenDrawerHandler(object sender, ExecutedRoutedEventArgs executedRoutedEventArgs)
        {
            if (executedRoutedEventArgs.Handled) return;

            SetOpenFlag(executedRoutedEventArgs, true);

            executedRoutedEventArgs.Handled = true;
        }

        private void SetOpenFlag(ExecutedRoutedEventArgs executedRoutedEventArgs, bool value)
        {
            if (executedRoutedEventArgs.Parameter is Dock)
            {
                switch ((Dock)executedRoutedEventArgs.Parameter)
                {
                    case Dock.Left:
                        SetCurrentValue(IsLeftDrawerOpenProperty, value);
                        break;
                    case Dock.Right:
                        SetCurrentValue(IsRightDrawerOpenProperty, value);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                try
                {
                    _lockZIndexes = true;
                    SetCurrentValue(IsLeftDrawerOpenProperty, value);
                    SetCurrentValue(IsRightDrawerOpenProperty, value);
                }
                finally
                {
                    _lockZIndexes = false;
                }
            }
        }

        private bool GetDisableTransitions(DependencyObject element)
        {
            return (bool)element.GetValue(DisableTransitionsProperty);
        }
    }
}
