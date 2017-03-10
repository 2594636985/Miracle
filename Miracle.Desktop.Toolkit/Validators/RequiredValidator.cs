using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Miracle.Desktop.Toolkit.Validators
{
    public class RequiredValidator : ValidationRule
    {
        public string LabelText { set; get; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
                return new ValidationResult(false, "{0}不能为空值！".FormatEx(this.LabelText));

            if (string.IsNullOrEmpty(value.ToString()))
                return new ValidationResult(false, "{0}不能为空字符串！".FormatEx(this.LabelText));

            return new ValidationResult(true, null);
        }
    }
}
