using CustomUtils;
using Dapper;
using DBManagemnet;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RTD_DataViewer.FromUtills;
using System.Data;
using System.IO;
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
            new ReqInfomation(this);
            new TransportList(this);
            SettingInit();

            tAbt_ReqInfo_Search.bt_Search.Click += bt_ReqInfo_Search_Click;
            tAbt_TransList_Search.bt_Search.Click += bt_TransList_Search_Click;
            bt_ReqATransfer_Search.Click += bt_ReqATransfer_Search_Click;

            DateTime tomorrow = DateTime.Today.AddDays(1);
            DateTime yesterday = DateTime.Today.AddDays(-1);

            lAdtp_ReqATransfer_EndDate.Dtp_Value = tomorrow;
            lAdtp_ReqATransfer_StartDate.Dtp_Value = yesterday;

            lAdtp_ReqInfo_EndDate.Dtp_Value = tomorrow;
            lAdtp_ReqInfo_StartDate.Dtp_Value = yesterday;

            lAdtp_TransList_EndDate.Dtp_Value = tomorrow;
            lAdtp_TransList_StartDate.Dtp_Value = yesterday;

            lAdtp_CstHist_EndDate.Dtp_Value = tomorrow;
            lAdtp_CstHist_StartDate.Dtp_Value = yesterday;

            cb_ReqATransfer_CstStat.SelectedIndex = 0;
            cb_ReqATransfer_MovingState.SelectedIndex = 0;
        }
        private void bt_ReqInfo_Search_Click(object sender, EventArgs e)
        {
            new ReqInfomation(this).Btn_Click();
        }

        private void bt_TransList_Search_Click(object sender, EventArgs e)
        {
            new TransportList(this).Btn_Click();
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

        private void bt_ReqATransfer_Search_Click(object sender, EventArgs e)
        {
            new ReqAndTransfer(this).Btn_Click();
        }

        private void bt_CstHist_Search_Click(object sender, EventArgs e)
        {
            new CstHist(this).Btn_Click();
        }

        private void bt_beautifierJson_Click(object sender, EventArgs e)
        {
            try
            {
                string jsonStr = uwC_TextBox2.Text;
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
                        uwC_TextBox1.ApeendText("\n" + stringWriter.ToString());
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
                string jsonStr = uwC_TextBox2.Text;
                string xmlStr = jsonStr;

                jsonStr = jsonStr.Replace(@"\r\n", "");
                jsonStr = jsonStr.Replace(@"\", "");
                JObject jsonOj = JObject.Parse(jsonStr);
                XmlDocument xmlOj;
                if (jsonOj != null)
                {
                    xmlOj = JsonConvert.DeserializeXmlNode(jsonOj.ToString(), "NewDataSet");
                    uwC_TextBox1.ApeendText("\n" + System.Xml.Linq.XDocument.Parse(xmlOj.InnerXml).ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
