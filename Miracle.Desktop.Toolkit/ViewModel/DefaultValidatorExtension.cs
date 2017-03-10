using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Desktop.Toolkit.ViewModel
{
    public static class DefaultValidatorExtension
    {
        public static IValidatorSelector NotNullEx(this IValidatorSelector ruleBuilder)
        {
            ruleBuilder.AddValidator(new NotNullValidator(ruleBuilder.PropertyName));

            return ruleBuilder;
        }

        public static IValidatorSelector NumberEx(this IValidatorSelector ruleBuilder)
        {
            ruleBuilder.AddValidator(new NumberValidator(ruleBuilder.PropertyName));

            return ruleBuilder;
        }


        public static IValidatorSelector ValidatorAction(this IValidatorSelector ruleBuilder, Action action)
        {
            return ruleBuilder;
        }

    }
}
