
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Miracle.Master.Registration
{
    using Miracle.Master.Intranet;
    using Modularization;
    using System.Net;

    public class RegisterCenter
    {
        public List<RegisterAction> RegistrationItems { private set; get; }

        public MiracleMaster MiracleMaster { private set; get; }

        public RegisterCenter(MiracleMaster miracleMaster)
        {
            this.MiracleMaster = miracleMaster;
            this.RegistrationItems = new List<RegisterAction>();
        }
        public void RegisterLocalList()
        {
            string filename = Path.Combine(this.MiracleMaster.AppLocation, "RegisterCenterList.txt");
            FileInfo fileInfo = new FileInfo(filename);
            if (!fileInfo.Exists)
            {
                fileInfo.Create().Close();
                return;
            }

            using (StreamReader sr = new StreamReader(filename, Encoding.UTF8))
            {
                string line = "";

                while (!string.IsNullOrWhiteSpace(line = sr.ReadLine()))
                {
                    string[] itemString = line.Split('|');

                    if (itemString != null)
                    {
                        RegisterAction registrationItem = new RegisterAction();

                        registrationItem.Localized = 0;
                        registrationItem.ModuleName = itemString[0];
                        registrationItem.ControllerName = itemString[1];
                        registrationItem.Url = itemString[2];
                        registrationItem.CreateTime = Convert.ToDateTime(itemString[3]);

                        this.RegistrationItems.Add(registrationItem);

                    }

                }
            }
        }

        public void RegisterMachine(ModuleFramework machine)
        {
            List<RegisterAction> addRegistrationItems = new List<RegisterAction>();
            List<Tuple<string, string, string>> enabledActionInformations = machine.GetEnabledActionInformation();
            foreach (Tuple<string, string, string> enabledActionInformation in enabledActionInformations)
            {
                string moduleName = enabledActionInformation.Item1;
                string controllerName = enabledActionInformation.Item2;
                string actionName = enabledActionInformation.Item3;

                if (!this.RegistrationItems.Any(item => item.ModuleName == moduleName && item.ControllerName == controllerName))
                {
                    RegisterAction registrationItem = new RegisterAction();
                    registrationItem.Localized = 1;
                    registrationItem.ModuleName = moduleName;
                    registrationItem.ControllerName = controllerName;
                    registrationItem.ActionName = actionName;

                    this.RegistrationItems.Add(registrationItem);
                }
            }
        }

        public bool HasRegistered(string moduleName, string serviceName)
        {
            return this.RegistrationItems.Any(item => item.ModuleName == moduleName && item.ControllerName == serviceName);
        }

        public bool HasRegistered(HttpRequest mReqeust)
        {
            return this.RegistrationItems.Any(item => item.ModuleName == mReqeust.ModuleName
                && item.ControllerName == mReqeust.ControllerName
                && item.ActionName == mReqeust.ActionName);
        }

        public RegisterAction GetRegisterAction(HttpRequest mReqeust)
        {
            return null;
        }




    }
}
