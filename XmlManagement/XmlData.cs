using CustomUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlManagement
{
    public class XmlData
    {
        XmlDocument xdoc;

        private string mainSql;
        private Dictionary<string, XmlOptionData> optionSql;

        public XmlData(string xmlFilePath)
        {
            this.xdoc = new XmlDocument();
            XmlSync(xmlFilePath);
        }
        public XmlData(string xmlFilePath, string sqlPath)
        {
            this.xdoc = new XmlDocument();
            XmlSync(xmlFilePath);
            this.mainSql = MainSqlpaser($@"{sqlPath}/MainSQL");
            this.optionSql = OptionSqlListparser(sqlPath);
        }

        public string MainSql { get => mainSql; set => mainSql = value; }
        public Dictionary<string, XmlOptionData> OptionSql { get => optionSql; set => optionSql = value; }

        public void XmlSync(string sqlXmlPath) 
        {
            xdoc.Load(sqlXmlPath);
        }

        public Dictionary<string, XmlOptionData> OptionSqlListparser()
        {
            Dictionary<string, XmlOptionData> result = new Dictionary<string, XmlOptionData>();
            // 특정 노드들을 필터링
            XmlNodeList nodes = xdoc.ChildNodes;

            XmlNode node = nodes[1];

            foreach (XmlNode cnode in node.ChildNodes)
            {
                result.Add(cnode.Name, new XmlOptionData(cnode));
            }
            
            return result;
        }

        public Dictionary<string, XmlOptionData> OptionSqlListparser(string sqlPath)
        {
            Dictionary<string, XmlOptionData> result = new Dictionary<string, XmlOptionData>();
            // 특정 노드들을 필터링
            XmlNodeList nodes = xdoc.SelectNodes(sqlPath);

            foreach (XmlNode node in nodes)
            {
                foreach (XmlNode cnode in node.ChildNodes)
                {
                    if(cnode.Name.Contains(CommonXml.Option)) {   

                       // result.Add(cnode.Name, new XmlOptionData(cnode));
                    }
                }
            }
            return result;
        }

        public string MainSqlpaser(string sqlPath)
        {
            XmlNodeList nodes = xdoc.SelectNodes(sqlPath);

            return nodes[0].InnerText;
        }

    }
}
