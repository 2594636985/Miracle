using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Miracle.Master
{
    public class MiracleXml
    {
        public string ConnectionString { private set; get; }

        public string AddInName { private set; get; }

        public string HttpServerUrl { private set; get; }

        public Version MiracleVersion { private set; get; }

        public List<string> CenterUris { private set; get; }

        public string StartModuleName { private set; get; }

        public string XmlLocation { private set; get; }

        public XmlDocument XmlDocument { private set; get; }

        public MiracleXml(string xmlLocation)
        {
            this.XmlLocation = xmlLocation;
            this.XmlDocument = new XmlDocument();
        }

        public void Initialize()
        {
            this.XmlDocument.Load(this.XmlLocation);

            this.ConnectionString = this.GetNodeInnerText("ConnectionString");
            this.AddInName = this.GetNodeInnerText("AddInName");
            this.MiracleVersion = new Version(this.GetNodeInnerText("Version") ?? "0,0,0,0");
            this.HttpServerUrl = this.GetNodeInnerText("HttpServerUrl");
            this.StartModuleName = this.GetNodeInnerText("StartModuleName");
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

    }
}
