using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Desktop.Toolkit.ViewModel
{
    public interface IValidator
    {
        string PropertyName { get; }

        bool Validate(object obj);

        string ErrorMessage { get; }
    }
}
