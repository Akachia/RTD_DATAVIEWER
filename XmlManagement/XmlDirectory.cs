using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlManagement
{
    internal class XmlDirectory
    {
        internal XmlDirectory()
        {
            XmlDocument appXmlData = new XmlDocument();
            appXmlData.Load(AppConfigDirectory);
            XmlNode xml = appXmlData.ChildNodes[1];
            SqlDirectory = xml["SqlDirectory"].InnerText;
            DatabaseDirectory = xml["DBConDirectory"].InnerText;

        }

        internal XmlDirectory(string appDirectory) {
            XmlDocument appXmlData = new XmlDocument();
            appXmlData.Load(appDirectory);

            XmlNode xml = appXmlData.ChildNodes[1];
            SqlDirectory = xml["SqlDirectory"].InnerText;
            DatabaseDirectory = xml["DBConDirectory"].InnerText;
        }
        private string AppConfigDirectory = $@"./AppConfig.xml";
        internal string SqlDirectory { set; get; }
        internal string DatabaseDirectory { set; get; }
    }
}
