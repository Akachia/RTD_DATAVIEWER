using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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

            this.xmlData = new XmlData(sqlPath);
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
    }
}
