using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Desktop.Toolkit.ViewModel
{
    public class ValidatorSelector : List<IValidator>, IValidatorSelector
    {
        public ValidatorSelector(string propertyName)
        {
            this.PropertyName = propertyName;
        }

        public string PropertyName { private set; get; }

        public List<IValidator> Validators
        {
            get { return this; }
        }


        public void AddValidator(IValidator validator)
        {
            this.Add(validator);
        }
    }
}
