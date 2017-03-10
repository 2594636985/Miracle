
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization.Controller
{
    using Injection;

    public abstract class ControllerBase : IController
    {
        public IModule Module { set; get; }
    }
}
