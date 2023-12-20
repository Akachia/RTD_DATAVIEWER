using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                OptionSqls = new ();
                AdditionalVarDic = new Dictionary<string, AdditionalVariable>();
                Name = xmlNode.Name;
                Sql = xmlNode.ChildNodes[0].InnerText;

                foreach (XmlNode childNode in xmlNode[CustomUtils.CommonXml.Option].ChildNodes)
                {
                    OptionSqls.Add(new XmlOptionSql(childNode));
                }

                foreach (XmlNode childNode in xmlNode[CustomUtils.CommonXml.AdditionalVariable].ChildNodes)
                {
                    AdditionalVarDic.Add(childNode.Name, new AdditionalVariable(childNode));
                }
            }
            catch (Exception ex)
            {
                ex.Source = $"{Name} Xml에 이상이 있습니다. \n" + ex.Source;
                throw ex;
            }
        }

        public string? Name { get; set; }
        public string? Sql { get; set; }
        public List<XmlOptionSql>? OptionSqls { get; set; }
        public Dictionary<string, AdditionalVariable>? AdditionalVarDic { get; set; }
    }

    public class XmlOptionSql
    {
        public XmlOptionSql(XmlNode xmlNode) {

            Name = xmlNode.Name;
            Sql = xmlNode.InnerText.Trim();

            try { this.Type = xmlNode.Attributes.GetNamedItem(CustomUtils.CommonXml.type).Value;}catch (Exception){this.Type = "";}
            try { this.Condition = xmlNode.Attributes.GetNamedItem(CustomUtils.CommonXml.condition).Value; } catch (Exception) { this.Condition = "";}
            try { this.Key = xmlNode.Attributes.GetNamedItem(CustomUtils.CommonXml.key).Value; } catch (Exception) { this.Key = "";}
            try
            {
                this.DataType = xmlNode.Attributes.GetNamedItem(CustomUtils.CommonXml.dataType).Value;
            }
            catch (Exception) { this.DataType = "string"; }
            try
            {
                this.Default = xmlNode.Attributes.GetNamedItem(CustomUtils.CommonXml.Default).Value;
            }
            catch (Exception) { this.Default = ""; }

        }

        public string? Name { get; set; }
        public string? Sql { get; set; }

        public string? Type { get; set; }
        public string? Condition { get; set; }
        public string? Key { get; set; }
        public string? DataType { get; set; }
        public string? Default { get; set; }
    }

    public class AdditionalVariable
    {
        public AdditionalVariable(XmlNode xmlNode)
        {
            try
            {
                Name = xmlNode.Name;
                try
                {
                    this.DataType = xmlNode.Attributes.GetNamedItem(CustomUtils.CommonXml.dataType).Value;
                }
                catch (Exception) { this.DataType = "string"; }
                try
                {
                    this.DefaultValue = xmlNode.Attributes.GetNamedItem(CustomUtils.CommonXml.Default).Value;
                }
                catch (Exception) { this.DataType = ""; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Name { get; set; }
        public string DataType { get; set; }
        public string DefaultValue { get; set; }

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

