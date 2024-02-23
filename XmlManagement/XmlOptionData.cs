using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using static CustomUtils.CommonXml;

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
                OptionSqls = new();
                AdditionalVarDic = new Dictionary<string, AdditionalVariable>();
                ColoringDic = new Dictionary<string, Coloring>();
                EventValueDic = new Dictionary<string, EventValue>();
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

                foreach (XmlNode childNode in xmlNode[CustomUtils.CommonXml.Coloring].ChildNodes)
                {
                    ColoringDic.Add(childNode.Name, new Coloring(childNode));
                }
                foreach (XmlNode childNode in xmlNode[EventValues.ClassName].ChildNodes)
                {
                    EventValueDic.Add(childNode.Name, new EventValue(childNode));
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
        public Dictionary<string, Coloring>? ColoringDic { get; set; }
        public Dictionary<string, EventValue>? EventValueDic { get; set; }

        /// <summary>
        /// 세팅 값 -> SQL명, 컬럼명
        /// 0. 지정된SQL에 세팅된 컬럼의 값을 각 객체에 있는 EventValue에 저장한다.
        /// 1. SQL명으로 컬럼값을 저장한 Dic을 반환 
        /// 2. 저장한 Dic에 있는 Value값으로 처리 
        /// 
        /// </summary>
        /// <param name="functionName"></param>
        /// <returns></returns>
        public Dictionary<string, string> getEventDicByFunctionName(string functionName)
        {
            EventValue ev = EventValueDic.Single(a => a.Value.CallSQL == functionName).Value;
            Dictionary<string, string> valuePairs = new();
            valuePairs.Add(ev.ColumnName, ev.Value);
            return valuePairs;
        }
    }

    public class XmlOptionSql
    {
        public XmlOptionSql(XmlNode xmlNode) {

            Name = xmlNode.Name;
            Sql = xmlNode.InnerText.Trim();

            try { this.Type = xmlNode.Attributes.GetNamedItem(CustomUtils.CommonXml.type).Value; } catch (Exception) { this.Type = ""; }
            try { this.Condition = xmlNode.Attributes.GetNamedItem(CustomUtils.CommonXml.condition).Value; } catch (Exception) { this.Condition = ""; }
            try { this.Key = xmlNode.Attributes.GetNamedItem(CustomUtils.CommonXml.key).Value; } catch (Exception) { this.Key = ""; }
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

    public class Coloring
    {
        public Coloring(XmlNode xmlNode)
        {
            ColoringVarDic = new Dictionary<string, ColoringValue>();
            try
            {
                Value = xmlNode.Name;
                try { this.IsColoringColumn = bool.Parse(xmlNode.Attributes.GetNamedItem(CustomUtils.CommonXml.IsColoringColumn).Value); } catch (Exception) { this.IsColoringColumn = false; }
                try { this.IsTimeCompare = bool.Parse(xmlNode.Attributes.GetNamedItem(CustomUtils.CommonXml.IsTimeCompare).Value); } catch (Exception) { this.IsColoringColumn = false; }
                try { this.Red = int.Parse(xmlNode.Attributes.GetNamedItem(CustomUtils.CommonXml.Red).Value); } catch (Exception) { this.Red = 0; }
                try { this.Green = int.Parse(xmlNode.Attributes.GetNamedItem(CustomUtils.CommonXml.Green).Value); } catch (Exception) { this.Green = 0; }
                try { this.Blue = int.Parse(xmlNode.Attributes.GetNamedItem(CustomUtils.CommonXml.Blue).Value); } catch (Exception) { this.Blue = 0; }
                foreach (XmlNode childNode in xmlNode.ChildNodes)
                {
                    ColoringVarDic.Add(childNode.Name, new ColoringValue(childNode));

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Value { get; set; }
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
        public bool IsColoringColumn { get; set; }
        public bool IsTimeCompare { get; set; }
        public Dictionary<string, ColoringValue>? ColoringVarDic { get; set; }
    }

    public class ColoringValue
    {
        public ColoringValue(XmlNode xmlNode)
        {
            try
            {
                Value = xmlNode.Name;
                try { this.Red = int.Parse(xmlNode.Attributes.GetNamedItem(CustomUtils.CommonXml.Red).Value); } catch (Exception) { this.Red = 0; }
                try { this.Green = int.Parse(xmlNode.Attributes.GetNamedItem(CustomUtils.CommonXml.Green).Value); } catch (Exception) { this.Green = 0; }
                try { this.Blue = int.Parse(xmlNode.Attributes.GetNamedItem(CustomUtils.CommonXml.Blue).Value); } catch (Exception) { this.Blue = 0; }
                try { this.IsColoringRow = bool.Parse(xmlNode.Attributes.GetNamedItem(CustomUtils.CommonXml.IsColoringRow).Value); } catch (Exception) { this.IsColoringRow = false; }
 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Value { get; set; }
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
        public bool IsColoringRow { get; set; }

    }

    public class ColoringDate
    {
        public ColoringDate(XmlNode xmlNode)
        {
            try
            {
                if (xmlNode.Name == "TODAY")
                {
                    Value = DateTime.Now;
                }

                if (xmlNode.Name == "TOMORROW")
                {
                    Value = DateTime.Now.AddDays(1);
                }

                if (xmlNode.Name == "YESTERDAY")
                {
                    Value = DateTime.Now.AddDays(-1);
                }

                try { this.Red = int.Parse(xmlNode.Attributes.GetNamedItem(CustomUtils.CommonXml.Red).Value); } catch (Exception) { this.Red = 0; }
                try { this.Green = int.Parse(xmlNode.Attributes.GetNamedItem(CustomUtils.CommonXml.Green).Value); } catch (Exception) { this.Green = 0; }
                try { this.Blue = int.Parse(xmlNode.Attributes.GetNamedItem(CustomUtils.CommonXml.Blue).Value); } catch (Exception) { this.Blue = 0; }
                try { this.IsColoringRow = bool.Parse(xmlNode.Attributes.GetNamedItem(CustomUtils.CommonXml.IsColoringRow).Value); } catch (Exception) { this.IsColoringRow = false; }
                try { this.Condition = xmlNode.Attributes.GetNamedItem(CustomUtils.CommonXml.condition).Value; } catch (Exception) { this.Condition = ""; }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DateTime Value { get; set; }
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
        public bool IsColoringRow { get; set; }
        public string Condition { get; set; }

    }

    public class EventValue
    {
        public EventValue(XmlNode xmlNode)
        {
            try
            {
                ColumnName = xmlNode.Name;
                try { this.Type = xmlNode.Attributes.GetNamedItem(EventValues.TYPE).Value; } catch (Exception) { this.Type = ""; }
                try { this.CallSQL = xmlNode.Attributes.GetNamedItem(EventValues.CallSQL).Value; } catch (Exception) { this.CallSQL = ""; }
                try { this.EventType = xmlNode.Attributes.GetNamedItem(EventValues.EventType).Value; } catch (Exception) { this.EventType = ""; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ColumnName { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public string CallSQL { get; set; }
        public string EventType { get; set; }

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

