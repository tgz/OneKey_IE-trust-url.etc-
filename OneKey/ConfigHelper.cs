using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Regedit
{
    class ConfigHelper
    {
        public string[] readAddress()
        {
            XmlDocument xmlDoc = new XmlDocument();
            string configFilePath = AppDomain.CurrentDomain.BaseDirectory.ToString()+"App.config";
            xmlDoc.Load(configFilePath);
            XmlNodeList nodes = xmlDoc.GetElementsByTagName("add");
            int nodesCount = nodes.Count;
            string[] ip=new string[nodesCount];
            for (int i = 0; i < nodesCount; i++)
            {
                XmlAttribute att = nodes[i].Attributes["value"];
                ip[i]= att.Value.ToString();
            }
            return ip;   
        }
    }
}
