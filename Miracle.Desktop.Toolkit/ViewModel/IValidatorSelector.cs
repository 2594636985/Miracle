using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Desktop.Toolkit.ViewModel
{
    public interface IValidatorSelector
    {
        string PropertyName { get; }

        List<IValidator> Validators { get; }

        void AddValidator(IValidator validator);
    }
}
