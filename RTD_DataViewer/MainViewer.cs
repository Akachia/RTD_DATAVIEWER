using CustomUtils;
using Dapper;
using DBManagemnet;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RTD_DataViewer.View;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using UserWinfromControl;
using XmlManagement;

namespace RTD_DataViewer
{
    public partial class MainViewer : Form
    {
        //DataSet dsEQPTGR;
        public const string LastLoginFileName = "RTD_Server.txt";
        public Dictionary<string, string> list = null;
        public Dictionary<string, DBConnectionString> strs = null;
        public string _CorrentDbName = String.Empty;
        public string AREAID = "";
        public string PLANTID = "";
        public string cstr = "";
        private XmlData xml;
        public Dictionary<string, XmlOptionData> sqlList;
        public DBConnectionString correntConnectionStringSetting;

        public MainViewer()
        {
            InitializeComponent();
            SettingInit();

            ReqInfomation reqInfomation = new ReqInfomation(this);
            tp_ReqInfomation.Controls.Add(reqInfomation);
            reqInfomation.Dock = DockStyle.Fill;

            TransportList transportList = new TransportList(this);
            tp_TransportList.Controls.Add(transportList);
            transportList.Dock = DockStyle.Fill;

            ReqAndTransfer reqAndTransfer = new ReqAndTransfer(this);
            tp_ReqAndTransfer.Controls.Add(reqAndTransfer);
            reqAndTransfer.Dock = DockStyle.Fill;

            CstHist cstHist = new CstHist(this);
            tp_CstHist.Controls.Add(cstHist);
            cstHist.Dock = DockStyle.Fill;

            LnsPkgState lnsPkgState = new LnsPkgState(this);
            tp_LnsPkgState.Controls.Add(lnsPkgState);
            lnsPkgState.Dock = DockStyle.Fill;
        }

        private void SettingInit()
        {
            try
            {
                xml = new XmlData(CommonConstants.sqlXmlPath);
                sqlList = xml.OptionSqlListparser();
                strs = new WinformUtils(this).GetConfigList();

                List<string> stringss = strs.Keys.ToList();
                cb_DBString.DataSource = null;
                cb_DBString.Items.Clear();
                cb_DBString.DataSource = stringss;

                correntConnectionStringSetting = strs[cb_DBString.Text];

                new WinformUtils(this).ChangeDBConn(cb_DBString.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_DataRefresh_Click(object sender, EventArgs e)
        {
            SettingInit();
        }

        private void cb_DBString_TextChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            if (comboBox.Text != string.Empty) new WinformUtils(this).ChangeDBConn(comboBox.Text);

            correntConnectionStringSetting = strs[cb_DBString.Text];
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
