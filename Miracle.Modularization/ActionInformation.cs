
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Miracle.Modularization
{

    public class ActionInformation
    {
        public ControllerInformation ControllerInformation { private set; get; }

        public string ControllerName { get { return this.ControllerInformation.ControllerName; } }

        public string ActionName { set; get; }


        public MethodInfo MethodInfo { set; get; }

        public Dictionary<string, ParameterInfo> ParameterInfos { get { return MethodInfo.GetParameters().ToDictionary(t => t.Name); } }

        public ActionInformation(ControllerInformation controllerInformation)
        {
            this.ControllerInformation = controllerInformation;
          
        }
    }
}
