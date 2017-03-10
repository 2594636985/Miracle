using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Desktop.Toolkit.ViewModel
{
    public class NumberValidator : IValidator
    {
        public NumberValidator(string propertyName)
        {
            this.PropertyName = propertyName;
        }
        public string PropertyName { private set; get; }

        public bool Validate(object obj)
        {
            if (obj == null)
                return false;

            double number;

            return Double.TryParse(Convert.ToString(obj), out number);
        }

        public string ErrorMessage
        {
            get { return "{0}必须是数字".FormatEx(this.PropertyName); }
        }
    }
}
