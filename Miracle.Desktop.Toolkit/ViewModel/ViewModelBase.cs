using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Miracle.Desktop.Toolkit.ViewModel
{
    public abstract class ViewModelBase : NotifyPropertyChanged
    {
        private Dictionary<string, object> _propertyChangedValues = new Dictionary<string, object>();

        protected virtual TProperty PropertyChangeValue<TProperty>(Expression<Func<TProperty>> expressionProperty)
        {
            string keyName = this.GetMemberInfo(expressionProperty).Name;

            if (this._propertyChangedValues.ContainsKey(keyName))
                return (TProperty)this._propertyChangedValues[keyName];

            return default(TProperty);
        }

        protected virtual void PropertyChangeValue<TProperty>(Expression<Func<TProperty>> expressionProperty, object value)
        {
            string keyName = this.GetMemberInfo(expressionProperty).Name;
            if (this._propertyChangedValues.ContainsKey(keyName))
                this._propertyChangedValues[keyName] = value;
            else
                this._propertyChangedValues.Add(keyName, value);

            this.OnPropertyChanged(keyName);
        }
    }
}
