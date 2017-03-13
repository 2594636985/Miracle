using Miracle.Desktop;
using Miracle.Desktop.Toolkit.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Miracle.Modulation.MainModule.ViewModel
{
    public class MainViewModuleViewModel : ViewModelBase
    {
        private ObservableCollection<LinkGroupViewModel> _linkGroupViewModels = new ObservableCollection<LinkGroupViewModel>();

        public ObservableCollection<LinkGroupViewModel> LinkGroupViewModels
        {
            set { this._linkGroupViewModels = value; }
            get { return this._linkGroupViewModels; }
        }

        public LinkViewModel SelectLinkViewModel
        {
            get { return this.PropertyChangeValue(() => this.SelectLinkViewModel); }
            set { this.PropertyChangeValue(() => this.SelectLinkViewModel, value); }
        }

        public string ViewName
        {
            get { return this.PropertyChangeValue(() => this.ViewName); }
            set { this.PropertyChangeValue(() => this.ViewName, value); }
        }
    }
}
