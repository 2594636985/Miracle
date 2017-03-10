using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Miracle.Desktop.Toolkit.ViewModel
{
    public abstract class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        protected MemberInfo GetMemberInfo<TProperty>(Expression<Func<TProperty>> expressionProperty)
        {
            Expression body;
            var expression = expressionProperty.Body as UnaryExpression;
            if (expression != null)
                body = expression.Operand;
            else
                body = expressionProperty.Body;

            var member = body as MemberExpression;
            if (member == null)
                throw new ArgumentException("Property must be a MemberExpression");

            return member.Member;
        }


    }
}
