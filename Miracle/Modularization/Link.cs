using Miracle.Modularization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization
{
    public class Link
    {
        public Link()
        {
            this.Parameters = new Dictionary<string, object>();
        }
        public Link(string moduleName, string vPageLocation)
            : this(moduleName, "", vPageLocation, null)
        {

        }

        public Link(string moduleName, string appName, string vPageLocation)
            : this(moduleName, appName, vPageLocation, null)
        {

        }

        public Link(string moduleName, string appName, string vPageLocation, Dictionary<string, object> parameters)
        {
            this.ModuleName = moduleName;
            this.ViewPageLocation = vPageLocation;

            if (parameters != null && parameters.Count > 0)
            {
                foreach (string keyName in parameters.Keys)
                {
                    this.Parameters.Add(keyName, parameters[keyName]);
                }
            }
        }

        /// <summary>
        /// 联系对象的模块名
        /// </summary>
        public string ModuleName { set; get; }

        /// <summary>
        /// 联接的对象类型
        /// </summary>
        public string ViewPageLocation { set; get; }

        /// <summary>
        /// 联接应用名
        /// </summary>
        public string AppName { set; get; }

        /// <summary>
        /// 参数
        /// </summary>
        public Dictionary<string, object> Parameters { set; get; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Link))
                return false;

            Link objLink = obj as Link;

            return this.ModuleName == objLink.ModuleName && this.ViewPageLocation == objLink.ViewPageLocation;
        }

        public override int GetHashCode()
        {
            return this.ModuleName.GetHashCode() * 32 + this.ViewPageLocation.GetHashCode();
        }
    }
}
