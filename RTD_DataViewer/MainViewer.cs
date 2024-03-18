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

            //To-Do : ���� ��Ȳ

            //��û ���
            PortRequestList reqInfomation = new PortRequestList(this);
            tp_ReqInfomation.Controls.Add(reqInfomation);
            reqInfomation.Dock = DockStyle.Fill;

            //��û �̷�
            PortRequestRecord portRequestRecord = new PortRequestRecord(this);
            tp_PortRequestRecord.Controls.Add(portRequestRecord);
            portRequestRecord.Dock = DockStyle.Fill;

            //�ݼ� ���
            TransportJobList transportList = new TransportJobList(this);
            tp_TransportList.Controls.Add(transportList);
            transportList.Dock = DockStyle.Fill;

            //�ݼ� �̷�
            TransportJobRecord reqAndTransfer = new TransportJobRecord(this);
            tp_TransportRecode.Controls.Add(reqAndTransfer);
            reqAndTransfer.Dock = DockStyle.Fill;

            //�ɸ��� ����
            CarrierInfomation cstInfo = new CarrierInfomation(this);
            tp_CstInfo.Controls.Add(cstInfo);
            cstInfo.Dock = DockStyle.Fill;

            //To-Do : �ɸ��� ����(Multi)

            //�ɸ��� �̷�
            CarrierHistory cstHist = new CarrierHistory(this);
            tp_CstHist.Controls.Add(cstHist);
            cstHist.Dock = DockStyle.Fill;

            //To-Do : Wip ����
            //To-Do : Wip �̷�

            //TO-DO : ���� ��Ȳ ����
            EquipmentCurrentState eqpState = new EquipmentCurrentState(this);
            tp_EqpState.Controls.Add(eqpState);
            eqpState.Dock = DockStyle.Fill;

            //��Ʈ ��Ȳ
            PortCurrentState portCurrState = new PortCurrentState(this);
            tp_PortCurrState.Controls.Add(portCurrState);
            portCurrState.Dock = DockStyle.Fill;

            //��� �� ��Ȳ
            WaitingLotInfomation waitWips = new WaitingLotInfomation(this);
            tp_WaitWips.Controls.Add(waitWips);
            waitWips.Dock = DockStyle.Fill;

            //����Ŀ ��Ȳ
            StockerInventorySituation stockerInventory = new StockerInventorySituation(this);
            tp_StockerInventory.Controls.Add(stockerInventory);
            stockerInventory.Dock = DockStyle.Fill;

            //lnsPkgState -> ���� ����
            CarrierInfomationList lnsPkgState = new CarrierInfomationList(this);
            tp_CarrierInformationList.Controls.Add(lnsPkgState);
            lnsPkgState.Dock = DockStyle.Fill;

            //�� ȭ��
            RollCurrentSituation rollSituation = new RollCurrentSituation(this);
            tp_RollSituation.Controls.Add(rollSituation);
            rollSituation.Dock = DockStyle.Fill;

            //���� �� ����
            BizRuleErr bizRuleErr = new BizRuleErr(this);
            tp_BizRuleErr.Controls.Add(bizRuleErr);
            bizRuleErr.Dock = DockStyle.Fill;
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
                correntConnectionStringSetting.TestConnection();
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
            try
            {
                ComboBox comboBox = sender as ComboBox;

                if (comboBox.Text != string.Empty) ChangeDBConn(comboBox.Text);
                if (cb_DBString.Text != string.Empty)
                {
                    correntConnectionStringSetting = strs[cb_DBString.Text];
                    correntConnectionStringSetting.TestConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
