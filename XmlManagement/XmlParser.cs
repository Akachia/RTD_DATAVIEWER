using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DBManagemnet;

namespace XmlManagement
{
    public class XmlParser
    {
        public XmlData xmlData;
        public XmlParser()
        {
        }
        public XmlParser(string xmlFilePath)
        {
            this.xmlData = new XmlData(xmlFilePath);
        }
        public XmlParser(string xmlFilePath, string sqlPath)
        {

            this.xmlData = new XmlData(xmlFilePath, sqlPath);
        }

        public string MakeOptionSql(string sql, XmlData xmlData, int squence)
        {
            //string sqlString = xmlData.OptionSql["Option1"].OptionSql;

            //if (xmlData.OptionSql[0].IsConvert)
            //{
            //    XmlAttributeCollection xmlArr = xmlData.OptionSql["Option1"].Values;

            //    sqlString.Replace("", "");
            //}

            return null;
        }

        public Dictionary<string, DBConnectionString> MakeConnectionStringLIst(string sqlXmlPath)
        {
            XmlDocument xdoc = new XmlDocument();
            Dictionary<string, DBConnectionString> result = new Dictionary<string, DBConnectionString>();
            // 특정 노드들을 필터링
            xdoc.Load(sqlXmlPath);
            XmlNode nodes = xdoc.ChildNodes[1];

            foreach (XmlNode node in nodes)
            {
                result.Add(node.Name, new DBConnectionString(
                    node["Server"].InnerText,
                    node["Database"].InnerText,
                    node["DatabaseProvider"].InnerText,
                    node["UserId"].InnerText,
                    node["Password"].InnerText,
                    node["AreaID"].InnerText,
                    node["PlantID"].InnerText)
                    );
            }
            return result;
        }
    }
}
