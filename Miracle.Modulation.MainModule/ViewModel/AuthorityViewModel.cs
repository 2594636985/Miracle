using Miracle.Desktop.Toolkit.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modulation.MainModule.ViewModel
{
    public class AuthorityViewModel : ViewModelBase
    {
        public string Username
        {
            get { return this.PropertyChangeValue(() => this.Username); }
            set { this.PropertyChangeValue(() => this.Username, value); }
        }

        public string Password
        {
            get { return this.PropertyChangeValue(() => this.Password); }
            set { this.PropertyChangeValue(() => this.Password, value); }
        }

        public string SystemDateTime
        {
            get { return this.PropertyChangeValue(() => this.SystemDateTime); }
            set { this.PropertyChangeValue(() => this.SystemDateTime, value); }
        }
    }
}
