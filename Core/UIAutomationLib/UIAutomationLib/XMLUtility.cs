using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace UIAutomationLib {
   public class XMLUtility {
       private string _xmlpath;
       private XmlDocument xmldoc = new XmlDocument();
      public XMLUtility(string xmlpath) {
           _xmlpath = xmlpath;
           xmldoc.Load(_xmlpath);
       }

       public string readNodeValue(string nodeName) {
           
           return xmldoc.SelectSingleNode("//" + nodeName).InnerText;
           
       }

       public string GetNodeValue(string nodeName) {
           string[] nodes = nodeName.Split('\\');
           XmlNode xn = xmldoc.SelectSingleNode("//" + nodes[0] + "//" + nodes[1]);

           XmlNodeList xnl = xn.ChildNodes;
           foreach (XmlNode node in xnl) {
               if (nodes[2] == node.Name) {
                   return node.InnerText;
               }
           }
           return "";
       }

       public int GetNodeCount(string nodeName) {
           string[] nodes = nodeName.Split('\\');
           XmlNode xn = xmldoc.SelectSingleNode("//" + nodes[0]);

           XmlNodeList xnl = xn.ChildNodes;

           return xnl.Count;
       }

       public XmlNodeList GetComponents() {
           XmlNode xn = xmldoc.SelectSingleNode("TestResult");
           return xn.ChildNodes;
       }
    }
}
