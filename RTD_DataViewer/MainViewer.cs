using CustomUtils;
using Dapper;
using DBManagemnet;
using System.Data;
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
            SettingInit();

            tAbt_ReqInfo_Search.bt_Search.Click += bt_Search_Click;
        }

        private void bt_Search_Click(object sender, EventArgs e)
        {
            new ReqInfomation(this).Btn_Click();
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
        }
    }
}
