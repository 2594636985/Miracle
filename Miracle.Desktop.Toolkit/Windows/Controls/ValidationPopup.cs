using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;

namespace Miracle.Desktop.Toolkit.Windows.Controls
{
    public class ValidationPopup : Popup
    {
        private Window _mainWindow;

        public ValidationPopup()
        {
            this.Loaded += this.CustomValidationPopup_Loaded;
        }

        private void CustomValidationPopup_Loaded(object sender, RoutedEventArgs e)
        {
            var target = this.PlacementTarget as FrameworkElement;
            if (target == null)
            {
                return;
            }

            this._mainWindow = Window.GetWindow(target);
            if (this._mainWindow == null)
            {
                return;
            }

            target.SizeChanged -= this.hostWindow_SizeOrLocationChanged;
            target.SizeChanged += this.hostWindow_SizeOrLocationChanged;

            this._mainWindow.LocationChanged -= this.hostWindow_SizeOrLocationChanged;
            this._mainWindow.LocationChanged += this.hostWindow_SizeOrLocationChanged;
            this._mainWindow.SizeChanged -= this.hostWindow_SizeOrLocationChanged;
            this._mainWindow.SizeChanged += this.hostWindow_SizeOrLocationChanged;
            this._mainWindow.StateChanged -= this.hostWindow_StateChanged;
            this._mainWindow.StateChanged += this.hostWindow_StateChanged;

            this.Unloaded -= this.CustomValidationPopup_Unloaded;
            this.Unloaded += this.CustomValidationPopup_Unloaded;
        }

        private void CustomValidationPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            var target = this.PlacementTarget as FrameworkElement;
            if (target != null)
            {
                target.SizeChanged -= this.hostWindow_SizeOrLocationChanged;
            }
            if (this._mainWindow != null)
            {
                this._mainWindow.LocationChanged -= this.hostWindow_SizeOrLocationChanged;
                this._mainWindow.SizeChanged -= this.hostWindow_SizeOrLocationChanged;
                this._mainWindow.StateChanged -= this.hostWindow_StateChanged;
            }
            this.Unloaded -= this.CustomValidationPopup_Unloaded;
            this._mainWindow = null;
        }

        private void hostWindow_StateChanged(object sender, EventArgs e)
        {
            if (this._mainWindow != null && this._mainWindow.WindowState != WindowState.Minimized)
            {
                var target = this.PlacementTarget as FrameworkElement;
                var holder = target != null ? target.DataContext as AdornedElementPlaceholder : null;
                if (holder != null && holder.AdornedElement != null)
                {
                    this.PopupAnimation = PopupAnimation.None;
                    this.IsOpen = false;
                    var errorTemplate = holder.AdornedElement.GetValue(Validation.ErrorTemplateProperty);
                    holder.AdornedElement.SetValue(Validation.ErrorTemplateProperty, null);
                    holder.AdornedElement.SetValue(Validation.ErrorTemplateProperty, errorTemplate);
                }
            }
        }

        private void hostWindow_SizeOrLocationChanged(object sender, EventArgs e)
        {
            var offset = this.HorizontalOffset;
            this.HorizontalOffset = offset + 1;
            this.HorizontalOffset = offset;
        }

    }
}
