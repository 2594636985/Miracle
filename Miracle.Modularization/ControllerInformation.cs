using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization
{
    public class ControllerInformation
    {
        public ControllerInformation()
        {
            this.ActionInformations = new List<ActionInformation>();
        }
        public string ControllerName { set; get; }

        public Type ControllerType { set; get; }

        public List<ActionInformation> ActionInformations { set; get; }

        public List<string> InterceptorNames { set; get; }

        public ActionInformation GetActionInformation(string actionName)
        {
            return this.ActionInformations.SingleOrDefault(t => t.ActionName.EqualsIgnoreCaseEx(actionName));
        }
    }
}
