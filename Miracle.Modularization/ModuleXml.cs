using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace Miracle.Modularization
{

    public class ModuleXml
    {
        public string ModuleName { private set; get; }
        /// <summary>
        /// 应用名称
        /// </summary>
        public string AppName { private set; get; }

        public string ConnectionString { private set; get; }

        public string ModuleType { private set; get; }

        public string XmlLocation { private set; get; }

        public string MainAssemblyName { private set; get; }


        public Version ModuleVersion { private set; get; }

        public List<ModuleMenu> ModuleMenus { private set; get; }

        public XmlDocument XmlDocument { private set; get; }

        public ModuleXml(string xmlLocation)
        {
            this.XmlLocation = xmlLocation;
            this.XmlDocument = new XmlDocument();
        }

        public void Initialize()
        {
            this.XmlDocument.Load(this.XmlLocation);

            //加载其本的信息
            this.ConnectionString = this.GetNodeInnerText("ConnectionString");
            this.AppName = this.GetNodeInnerText("AppName");
            this.ModuleName = this.GetNodeInnerText("ModuleName");
            this.ModuleType = this.GetNodeInnerText("ModuleType") ?? "Extensional";
            this.ModuleVersion = new Version(this.GetNodeInnerText("Version") ?? "0,0,0,0");
            this.MainAssemblyName = this.GetNodeInnerText("MainAssemblyName");
            this.ModuleMenus = this.GetModuleMenus("ModuleMenus");
        }

        private string GetNodeInnerText(string tagName)
        {
            XmlNodeList xmlNodeList = this.XmlDocument.GetElementsByTagName(tagName);

            if (xmlNodeList != null && xmlNodeList.Count > 0)
                return xmlNodeList[0].InnerText;

            return null;
        }

        private string GetNodeInnerText(XmlNode xmlNode, string tagName)
        {
            XmlNode singleNode = xmlNode.SelectSingleNode(tagName);

            if (singleNode != null)
                return singleNode.InnerText;

            return null;
        }

        private List<ModuleMenu> GetModuleMenus(string tagName)
        {
            List<ModuleMenu> moduleMenus = new List<ModuleMenu>();

            XmlNodeList xmlNodeList = this.XmlDocument.GetElementsByTagName(tagName);

            if (xmlNodeList != null && xmlNodeList.Count > 0)
            {
                XmlNode xmlNode = xmlNodeList[0];

                foreach (XmlNode mXmlNode in xmlNode.ChildNodes)
                {

                    XmlAttributeCollection xmlAttributeCollection = mXmlNode.Attributes;

                    ModuleMenu moduleMenu = new ModuleMenu();
                    if (xmlAttributeCollection.Count > 0)
                    {
                        foreach (XmlAttribute xmlAttribute in xmlAttributeCollection)
                        {
                            if (xmlAttribute.Name == "AppName")
                                moduleMenu.AppName = xmlAttribute.Value;
                        }

                    }
                    moduleMenu.ViewPageLocation = mXmlNode.InnerText;

                    moduleMenus.Add(moduleMenu);
                }
            }

            return moduleMenus;
        }

    }

    public class ModuleMenu
    {
        public string AppName { set; get; }

        public string ViewPageLocation { set; get; }
    }
}
