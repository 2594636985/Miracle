﻿#pragma checksum "..\..\..\Pages\Authority.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "44FE1C2B1D34F6A717A61AE7316ADC95"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.36373
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using Miracle.Desktop.Toolkit;
using Miracle.Desktop.Toolkit.Validators;
using Miracle.Desktop.Toolkit.Windows;
using Miracle.Desktop.Toolkit.Windows.Controls;
using Miracle.Modulation.MainModule;
using Miracle.Modulation.MainModule.ViewModel;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Miracle.Modulation.MainModule.Pages {
    
    
    /// <summary>
    /// Authority
    /// </summary>
    public partial class Authority : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 142 "..\..\..\Pages\Authority.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock _tbOpenTime;
        
        #line default
        #line hidden
        
        
        #line 178 "..\..\..\Pages\Authority.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid _gridLoginInformation;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Miracle.Modulation.MainModule;component/pages/authority.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\Authority.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\..\Pages\Authority.xaml"
            ((Miracle.Modulation.MainModule.Pages.Authority)(target)).Initialized += new System.EventHandler(this.Authority_Initialized);
            
            #line default
            #line hidden
            
            #line 12 "..\..\..\Pages\Authority.xaml"
            ((Miracle.Modulation.MainModule.Pages.Authority)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Authority_Loaded);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\Pages\Authority.xaml"
            ((Miracle.Modulation.MainModule.Pages.Authority)(target)).Unloaded += new System.Windows.RoutedEventHandler(this.Authority_Unloaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this._tbOpenTime = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this._gridLoginInformation = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            
            #line 243 "..\..\..\Pages\Authority.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnLogin_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 270 "..\..\..\Pages\Authority.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnExit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

