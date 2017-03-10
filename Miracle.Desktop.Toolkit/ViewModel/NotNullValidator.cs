using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Desktop.Toolkit.ViewModel
{
    public class NotNullValidator : IValidator
    {
        public NotNullValidator(string propertyName)
        {
            this.PropertyName = propertyName;
        }
        public string PropertyName { private set; get; }

        public bool Validate(object obj)
        {
            if (obj == null)
                return false;

            return !string.IsNullOrWhiteSpace(Convert.ToString(obj));
        }

        public string ErrorMessage
        {
            get { return "{0}不能为空".FormatEx(this.PropertyName); }
        }
    }
}
