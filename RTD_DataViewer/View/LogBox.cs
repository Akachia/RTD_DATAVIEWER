using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using Dapper;

namespace RTD_DataViewer.View
{
    public partial class LogBox : UserControl
    {
        MainViewer mainViewer;

        public delegate void AppendTextCallback(string text);
        public delegate void AppendLogWithParameterCallback(string text, DynamicParameters parameters);
        public delegate void AppendLogWithKeyValueCallback(string text, string key, string value);

        public AppendTextCallback appendTextCallback = null;
        public AppendLogWithParameterCallback appendLogWithParameterCallback = null;
        public AppendLogWithKeyValueCallback appendLogWithKeyValueCallback = null;
        public LogBox(MainViewer mainViewer)
        {
            InitializeComponent();
            this.mainViewer = mainViewer;

            appendTextCallback = new AppendTextCallback(AppendLog);
            appendLogWithParameterCallback = new AppendLogWithParameterCallback(AppendLogWithParameter);
            appendLogWithKeyValueCallback = new AppendLogWithKeyValueCallback(AppendLogWithKeyValue);
        }

        private void AppendLog(string text)
        {
            if (this.utb_RtdDataViewerLog.InvokeRequired)
            {
                this.Invoke(appendTextCallback, new object[] { text });
            }
            else
            {
                this.utb_RtdDataViewerLog.ApeendText(text);
            }
        }

        private void AppendLogWithParameter(string text, DynamicParameters parameters)
        {
            if (this.utb_RtdDataViewerLog.InvokeRequired)
            {
                this.Invoke(appendTextCallback, new object[] { text });
            }
            else
            {
                Dictionary<string, string> parameterDic = new Dictionary<string, string>();
                foreach (var item in parameters.ParameterNames)
                {
                    parameterDic.Add(item, parameters.Get<string>(item));
                }

                this.utb_RtdDataViewerLog.ApeendText(text, parameterDic);
            }
        }

        private void AppendLogWithKeyValue(string text, string key, string value)
        {
            if (this.utb_RtdDataViewerLog.InvokeRequired)
            {
                this.Invoke(appendTextCallback, new object[] { text });
            }
            else
            {
                this.utb_RtdDataViewerLog.ApeendText(text, key, value);
            }
        }

        private void bt_beautifierJson_Click(object sender, EventArgs e)
        {
            try
            {
                string jsonStr = utb_RtdMessageText.Text;
                string xmlStr = jsonStr;

                jsonStr = jsonStr.Replace(@"\r\n", "");
                jsonStr = jsonStr.Replace(@"\", "");
                JObject jsonOj = JObject.Parse(jsonStr);
                if (jsonOj != null)
                {
                    using (var stringReader = new StringReader(jsonStr))
                    using (var stringWriter = new StringWriter())
                    {
                        var jsonReader = new JsonTextReader(stringReader);
                        var jsonWriter = new JsonTextWriter(stringWriter) { Formatting = Newtonsoft.Json.Formatting.Indented };
                        jsonWriter.WriteToken(jsonReader);
                        utb_RtdMessageText.Text = string.Empty;
                        utb_RtdMessageText.ApeendText("\n" + stringWriter.ToString());
                    }
                    //var jsonWriter = new JsonTextWriter(jsonStr) { Formatting = Formatting.Indented };
                    //xmlOj = JsonConvert.DeserializeXmlNode(jsonOj.ToString(), "message");
                    //uwC_TextBox2.Text = System.Xml.Linq.XDocument.Parse(xmlOj.InnerXml).ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void bt_beautifierXml_Click(object sender, EventArgs e)
        {
            try
            {
                string jsonStr = utb_RtdMessageText.Text;
                string xmlStr = jsonStr;

                jsonStr = jsonStr.Replace(@"\r\n", "");
                jsonStr = jsonStr.Replace(@"\", "");
                JObject jsonOj = JObject.Parse(jsonStr);
                XmlDocument xmlOj;
                if (jsonOj != null)
                {
                    xmlOj = JsonConvert.DeserializeXmlNode(jsonOj.ToString(), "NewDataSet");
                    utb_RtdMessageText.Text = string.Empty;
                    utb_RtdMessageText.ApeendText("\n" + System.Xml.Linq.XDocument.Parse(xmlOj.InnerXml).ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_Clear_Click(object sender, EventArgs e)
        {
            utb_RtdDataViewerLog.Text = string.Empty;
        }

        private void bt_RtdEditerLogConvert_Click(object sender, EventArgs e)
        {
            string prevText = utb_RtdEditerText.Text;

            utb_RtdEditerText.Text = string.Empty;
            utb_RtdEditerText.ApeendText(prevText.Replace(",", "\n"));
        }
    }
}
