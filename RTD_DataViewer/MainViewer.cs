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

            timer1.Interval = 1000;
            timer2.Interval = 1000;
            timer1.Tick += UsaCentralTime;
            timer2.Tick += KoreaTime;
            timer1.Start();
            timer2.Start();

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
            WipActHistory waitWips = new WipActHistory(this);
            tp_WipActHistory.Controls.Add(waitWips);
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
                strs = new DatabaseUtilities().GetConfigList();

                List<string> stringss = strs.Keys.ToList();
                cb_DBString.DataSource = null;
                cb_DBString.Items.Clear();
                cb_DBString.DataSource = stringss;

                correntConnectionStringSetting = strs[cb_DBString.Text];
                correntConnectionStringSetting.TestConnection();
                ChangeDBConn(cb_DBString.Text);

                xml = new XmlData(correntConnectionStringSetting.DatabaseProvider,
                    correntConnectionStringSetting.SystemTypeCode);
                lb_xmlPath.Text = xml.xmlPath;
                sqlList = xml.OptionSqlListparser();
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
                    ChangeDBConn(cb_DBString.Text);

                    xml = new XmlData(correntConnectionStringSetting.DatabaseProvider,
                        correntConnectionStringSetting.SystemTypeCode);
                    lb_xmlPath.Text = xml.xmlPath;
                    sqlList = xml.OptionSqlListparser();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UsaCentralTime(object sender, EventArgs args)
        {
            DateTime thisTime = DateTime.Now;
            TimeZoneInfo tst = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            DateTime tstTime = TimeZoneInfo.ConvertTime(thisTime, TimeZoneInfo.Local, tst);

            string? timeName = tst.IsDaylightSavingTime(tstTime) ? tst.DaylightName : tst.StandardName;
            DateTime usaCentralTime = TimeZoneInfo.ConvertTimeToUtc(tstTime, tst);
            lb_CurLocTime.Text = @$"{timeName} : {usaCentralTime:yyyy-MM-dd HH:mm:ss}";

        }

        private void KoreaTime(object sender, EventArgs args)
        {
            DateTime utcNow = DateTime.Now;
            TimeZoneInfo localTzInfo = TimeZoneInfo.Local;
            string? timeName = localTzInfo.IsDaylightSavingTime(utcNow)
                ? localTzInfo.DaylightName
                : localTzInfo.StandardName;
            lb_KorTime.Text = @$"{timeName} : {utcNow:yyyy-MM-dd HH:mm:ss}";
        }

        private void MainViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ����� Ȯ��
            var result = MessageBox.Show("���ø����̼��� �����Ͻðڽ��ϱ�?", "���� Ȯ��", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true; // ���� ���
                return;
            }

            // ������ ���� �۾� ����
            PerformSafeShutdown();
        }

        private void PerformSafeShutdown()
        {
            try
            {
                // Ÿ�̸� ����
                timer1?.Stop();
                timer2?.Stop();

                // �����ͺ��̽� ���� ����
                if (correntConnectionStringSetting != null && correntConnectionStringSetting.IsConnection)
                {
                    // ���� �׽�Ʈ �� ����
                    //correntConnectionStringSetting.TestConnection();
                    // ���� ���� ���� �߰� (�ʿ� ��)
                }

                // XML ������ ���� (�ʿ� ��)
                //xml?.XmlSync();

                // �α� ���� (�ʿ� ��)
                AppendLog("���ø����̼� ���� ��...");

                // ��Ÿ ���ҽ� ����
                Dispose(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"���� �� ���� �߻�: {ex.Message}", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
