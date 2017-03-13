
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization
{
    using System.Reflection;

    public class ActionInvocation
    {
        public string ModuleName { private set; get; }

        public string ConrollerName { private set; get; }

        public string ActionName { private set; get; }

        public Module Module { private set; get; }

        public object Instance { private set; get; }

        public MethodInfo MethedInfo { private set; get; }

        public object[] Parameters { private set; get; }


        public ActionInvocation(Module module)
        {
            this.Module = module;
            this.ModuleName = module.ModuleName;
        }

        public void Setup(string controllerName, string actionName, Dictionary<string, string> parameters)
        {
            this.ConrollerName = controllerName;
            this.ActionName = actionName;

            ActionInformation actionInformaction = this.Module.GetActionInformation(controllerName, actionName);


            this.MethedInfo = actionInformaction.MethodInfo;
            this.Parameters = new object[actionInformaction.ParameterInfos.Count];

            Dictionary<string, ParameterInfo> actionParameterInfos = actionInformaction.ParameterInfos;

            foreach (string parameterName in parameters.Keys)
            {
                if (actionParameterInfos.ContainsKey(parameterName))
                {
                    ParameterInfo parameterInfo = actionParameterInfos[parameterName];
                    this.Parameters[parameterInfo.Position] = parameters[parameterName];
                }
            }

            //this.Instance = this.Module.GetInstance(actionInformaction.ControllerInformation.ControllerType);
        }

        public object Invoke()
        {

            //if (this.InterceptorList.MoveNext())
            //{
            //    return ((IInterceptor)this.InterceptorList.Current).Intercept(this);
            //}
            //else
            //{
            //    if (this.Instance != null && this.MethedInfo != null)
            //    {
            //        return this.MethedInfo.Invoke(this.Instance, this.Parameters);
            //    }
            //}

            return null;

        }

    }
}
