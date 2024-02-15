using CustomUtils;
using Dapper;
using DBManagement;
using DBManagemnet;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RTD_DataViewer.View;
using System.Data;
using System.IO;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using UserWinfromControl;
using XmlManagement;
using static RTD_DataViewer.View.LogBox;

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

        AppendTextCallback appendTextCallback;
        AppendLogWithParameterCallback appendLogWithParameterCallback;
        AppendLogWithKeyValueCallback appendLogWithKeyValueCallback;

        public MainViewer()
        {
            InitializeComponent();
            SettingInit();

            LogBox logBox = new LogBox(this);
            tp_LogBox.Controls.Add(logBox);
            logBox.Dock = DockStyle.Fill;

            appendTextCallback = logBox.appendTextCallback;
            appendLogWithParameterCallback = logBox.appendLogWithParameterCallback;
            appendLogWithKeyValueCallback = logBox.appendLogWithKeyValueCallback;

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

            CstInfo cstInfo = new CstInfo(this);
            tp_CstInfo.Controls.Add(cstInfo);
            cstInfo.Dock = DockStyle.Fill;

            EqpState eqpState = new EqpState(this);
            tp_EqpState.Controls.Add(eqpState);
            eqpState.Dock = DockStyle.Fill;

            WaitWips waitWips = new WaitWips(this);
            tp_WaitWips.Controls.Add(waitWips);
            waitWips.Dock = DockStyle.Fill;

            LnsPkgState lnsPkgState = new LnsPkgState(this);
            tp_LnsPkgState.Controls.Add(lnsPkgState);
            lnsPkgState.Dock = DockStyle.Fill;

            StockerInventory stockerInventory = new StockerInventory(this);
            tp_StockerInventory.Controls.Add(stockerInventory);
            stockerInventory.Dock = DockStyle.Fill;

            RollSituation rollSituation = new RollSituation(this);
            tp_RollSituation.Controls.Add(rollSituation);
            rollSituation.Dock = DockStyle.Fill;

            BizRuleErr bizRuleErr = new BizRuleErr(this);
            tp_BizRuleErr.Controls.Add(bizRuleErr);
            rollSituation.Dock = DockStyle.Fill;
        }

        public void AppendLog(string text)
        {
            appendTextCallback(text);
        }

        public void AppendLog(string text, DynamicParameters paramaters)
        {
            appendLogWithParameterCallback(text, paramaters);
        }

        public void AppendLog(string text, string key, string value)
        {
            appendLogWithKeyValueCallback(text, key, value);
        }

        private void SettingInit()
        {
            try
            {
                xml = new XmlData(CommonConstants.sqlXmlPath);
                sqlList = xml.OptionSqlListparser();
                strs = new DatabaseUtilities().GetConfigList();

                List<string> stringss = strs.Keys.ToList();
                cb_DBString.DataSource = null;
                cb_DBString.Items.Clear();
                cb_DBString.DataSource = stringss;

                correntConnectionStringSetting = strs[cb_DBString.Text];

                ChangeDBConn(cb_DBString.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ChangeDBConn(string dbString)
        {
            lb_ServerIP.Text = strs[dbString].Server.ToString();
            lb_ServerName.Text = strs[dbString].Database.ToString();
            cstr = strs[dbString].ConnectionString();
        }

        private void bt_DataRefresh_Click(object sender, EventArgs e)
        {
            //sqlList.Clear();
            //xml = null;
            //strs.Clear();
            SettingInit();
        }

        private void cb_DBString_TextChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            if (comboBox.Text != string.Empty) ChangeDBConn(comboBox.Text);
            if (cb_DBString.Text != string.Empty)
            {
                correntConnectionStringSetting = strs[cb_DBString.Text];
            }
        }
    }
}
