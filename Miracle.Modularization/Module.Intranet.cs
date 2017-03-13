using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization
{
    public partial class Module : IModule
    {
        public List<ControllerInformation> ControllerInformations { private set; get; }

        public ControllerInformation GetControllerInformation(string controllerName)
        {
            return this.ControllerInformations.SingleOrDefault(ci => ci.ControllerName.EqualsIgnoreCaseEx(controllerName));
        }

        public ActionInformation GetActionInformation(string controllerName, string actionName)
        {
            ControllerInformation controllerInformation = this.GetControllerInformation(controllerName);

            if (controllerInformation != null)
                return controllerInformation.GetActionInformation(actionName);

            return null;
        }

        public List<ActionInformation> GetAllActionInformation()
        {
            List<ActionInformation> allActionInformations = new List<ActionInformation>();
            //foreach (ControllerInformation controllerInformation in this.ControllerInformations)
            //{
            //    allActionInformations.AddRange(controllerInformation.ActionInformations);
            //}

            return allActionInformations;
        }

    }
}
