using Miracle.Desktop.Toolkit.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Miracle.Modulation.MainModule.ViewModel
{
    public class LinkGroupViewModel : ViewModelBase
    {

        private ObservableCollection<LinkViewModel> _linkViewModels = new ObservableCollection<LinkViewModel>();

        public ObservableCollection<LinkViewModel> LinkViewModels
        {
            set { this._linkViewModels = value; }
            get { return this._linkViewModels; }
        }

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

        public string DisplayName
        {
            get { return this.PropertyChangeValue(() => this.DisplayName); }
            set { this.PropertyChangeValue(() => this.DisplayName, value); }
        }

    }
}
