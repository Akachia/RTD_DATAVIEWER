using System;
using System.Collections.Generic;
using System.Xml;

namespace XmlManagement
{
    /// <summary>
    /// XML Option 확인 
    /// </summary>
    public class XmlOptionData
    {
        public XmlOptionData(XmlNode xmlNode) {
            try
            {
                optionSqls = new List<XmlOptionSql>();
                name = xmlNode.Name;
                sql = xmlNode.ChildNodes[0].InnerText;

                foreach (XmlNode childNode in xmlNode.ChildNodes[1].ChildNodes)
                {
                    optionSqls.Add(new XmlOptionSql(childNode));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string name { get; set; }
        public string sql { get; set; }
        public List<XmlOptionSql> optionSqls { get; set; }
    }

    public class XmlOptionSql
    {
        public XmlOptionSql(XmlNode xmlNode) {

            name = xmlNode.Name;
            sql = xmlNode.InnerText.Trim();
        }

        public string name { get; set; }
        public string sql { get; set; }
    }
    //public XmlOptionData(XmlNode node)
    //{
    //    // Tag Name
    //    this.name = node.Name;
    //    // Tag Attribute List <Name, Value>
    //    this.values = node.Attributes;
    //    // option Sql
    //    this.optionSql = node.InnerText;
    //    this.isConvert = JudgeIsConvert(values);
    //}
    //private string name;
    //private XmlAttributeCollection values;
    //private string optionSql;
    //private bool isConvert = false;

    //public XmlAttributeCollection Values { get => values; set => this.values = value; }
    //public string Name { get => name; set => name = value; }
    //public string OptionSql { get => optionSql; set => optionSql = value; }
    //public bool IsConvert { get => isConvert; set => isConvert = value; }

    ////public Dictionary<string, string> MakeValueList(XmlNode node)
    ////{
    ////    Dictionary<string, string> valueList = new Dictionary<string, string>();

    ////    if (node != null)
    ////    {
    ////        valueList.Add(CommonXml.value, node.Attributes[CommonXml.value].Value);
    ////        valueList.Add(CommonXml.type, node.Attributes[CommonXml.type].Value);
    ////    }

    ////    return valueList;
    ////}

    //private bool JudgeIsConvert(XmlAttributeCollection values)
    //{
    //    if (values[CommonXml.type].Value == CommonXml.convert)
    //    {
    //        isConvert = true;
    //    }
    //    return isConvert;
    //}

}

