using Miracle.Desktop.Toolkit.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modulation.MainModule.ViewModel
{
    public class LinkViewModel : ViewModelBase
    {
        /// <summary>
        /// 联系对象的模块名
        /// </summary>

        public string ModuleName
        {
            get { return this.PropertyChangeValue(() => this.ModuleName); }
            set { this.PropertyChangeValue(() => this.ModuleName, value); }
        }

        /// <summary>
        /// 联接应用名
        /// </summary>

        public string AppName
        {
            get { return this.PropertyChangeValue(() => this.AppName); }
            set { this.PropertyChangeValue(() => this.AppName, value); }
        }


        public string ViewPageLocation
        {
            get { return this.PropertyChangeValue(() => this.ViewPageLocation); }
            set { this.PropertyChangeValue(() => this.ViewPageLocation, value); }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is LinkViewModel))
                return false;

            LinkViewModel objLink = obj as LinkViewModel;

            return this.ModuleName == objLink.ModuleName && this.ViewPageLocation == objLink.ViewPageLocation;
        }

        public override int GetHashCode()
        {
            return this.ModuleName.GetHashCode() * 32 + this.ViewPageLocation.GetHashCode();
        }

        public override string ToString()
        {
            return this.ModuleName;
        }
    }
}
