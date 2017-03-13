using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Master.Registration
{
    public class RegisterAction
    {
        public int Localized { set; get; }

        public string Url { set; get; }

        public string ModuleName { set; get; }

        public string ControllerName { set; get; }

        public string ActionName { set; get; }

        public DateTime CreateTime { set; get; }
    }
}
