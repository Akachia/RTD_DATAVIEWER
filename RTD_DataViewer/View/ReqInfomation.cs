using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XmlManagement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RTD_DataViewer.View
{
    public partial class ReqInfomation : UserControl
    {
        MainViewer main;
        string cstid = string.Empty;
        string startDate = string.Empty;
        string endDate = string.Empty;
        string EqpId = string.Empty;
        string ruleId = string.Empty;
        int currNum = 0;

        public ReqInfomation(MainViewer main)
        {
            InitializeComponent();
            DateTime tomorrow = DateTime.Today.AddDays(1);
            DateTime yesterday = DateTime.Today.AddDays(-1);
            this.main = main;
            tAbt_ReqInfo_Search.timer.Tick += Timer_Tick;
            tAbt_ReqInfo_Search.bt_Search.Click += Bt_Search_Click;
            reqInfo_dgvReq.DgvData.CellClick += ReqInfoDataGridViewCellClick;
            lAdtp_ReqInfo_EndDate.Dtp_Value = tomorrow;
            lAdtp_ReqInfo_StartDate.Dtp_Value = yesterday;
            lAdtp_ReqInfo_EndDate.IsChecked = false;
            lAdtp_ReqInfo_StartDate.IsChecked = true;
        }

        private void Bt_Search_Click(object? sender, EventArgs e)
        {
            Btn_Click();
        }

        private void ReqInfoDataGridViewCellClick(object? sender, DataGridViewCellEventArgs e)
        {
            string cstId = (sender as DataGridView).CurrentRow.Cells["CSTID"].Value.ToString();
            string req_SeqNo = (sender as DataGridView).CurrentRow.Cells["REQ_SEQNO"].Value.ToString();

            SearchTrfInfo(req_SeqNo);

            if (cstId == "")
            {
                try
                {
                    cstId = reqInfo_dgvReq_TrfInfo.DgvData.Rows[0].Cells["CSTID"].Value.ToString();
                }
                catch (Exception)
                {
                    cstId = "";
                }

            }

            if (cstId != "")
            {
                SearchCstInfo(cstId);
            }
        }

        private void SearchCstInfo(string cstId)
        {
            string errMsg = string.Empty;
            new WinformUtils(main).SearchCstInfo(reqInfo_DgvCarrier.DgvData, cstId, ref errMsg);
        }

        private void SearchTrfInfo(string req_SeqNo)
        {
            WinformUtils winformUtils = new WinformUtils(main);
            Dictionary<string, string> paramaterDic = new Dictionary<string, string>();
            try
            {
                paramaterDic.Add("REQ_SEQNO", $"{req_SeqNo}");

                winformUtils.ExcuteSql(paramaterDic, reqInfo_dgvReq_TrfInfo.DgvData, main.correntConnectionStringSetting, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex) { MessageBox.Show($"{ex.Message} : SearchTrfInfo"); }
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            int interval = tAbt_ReqInfo_Search.Interval;

            if (currNum == 0)
            {
                ReqList();
                currNum = tAbt_ReqInfo_Search.Interval;
            }
            else
            {
                tAbt_ReqInfo_Search.bt_Search.Text = currNum.ToString("000") + "\nStop";
                currNum--;
            }
        }

        private string MakeTransferStatusCountString(string columnName, string[] atrr, int rowCount)
        {
            List<string> list = new List<string>();
            int count = reqInfo_dgvReq.DgvData.RowCount;

            for (int i = 0; i < count; i++)
            {
                list.Add(reqInfo_dgvReq.DgvData.Rows[i].Cells[columnName].Value.ToString());
            }

            Dictionary<string, int> keyValuePairs = new();

            foreach (string row in atrr)
            {
                keyValuePairs.Add(row, list.Count(a => a.ToString() == row));
            }

            string str = string.Empty;
            foreach (string row in keyValuePairs.Keys)
            {
                str += $"{row} : {keyValuePairs[row]} \t";
            }

            return str;
        }

        internal void Btn_Click()
        {
            if (tAbt_ReqInfo_Search.IsUseTimer)
            {
                tAbt_ReqInfo_Search.timer.Interval = 1000;
                if (tAbt_ReqInfo_Search.timer.Enabled)
                {
                    tAbt_ReqInfo_Search.timer.Stop();
                    tAbt_ReqInfo_Search.bt_Search.Text = "Search";
                }
                else
                {
                    tAbt_ReqInfo_Search.timer.Start();
                }
            }
            else
            {
                ReqList();
            }

            lb_TransferStatus.Text = MakeTransferStatusCountString("REQ_STAT_CODE", new string[] { "CREATED", "REQUEST" }, reqInfo_dgvReq.DgvData.RowCount);

        }

        public void ReqList()
        {
            WinformUtils winformUtils = new WinformUtils(main);
            Dictionary<string, string> paramaterDic = new Dictionary<string, string>();

            reqInfo_dgvReq.DgvData.DataSource = null;
            reqInfo_dgvReq_TrfInfo.DgvData.DataSource = null;
            reqInfo_DgvCarrier.DgvData.DataSource = null;

            this.cstid = lAtb_ReqInfo_Cstid.Tb_Text;


            string endDate = lAdtp_ReqInfo_EndDate.MakeNowDateStringAndSetting();
            string startDate = lAdtp_ReqInfo_StartDate.MakeNowDateStringAndSetting();
            this.ruleId = lAtb_ReqInfo_RuleText.Tb_Text;
            this.EqpId = lAtb_ReqInfo_ReqEqp.Tb_Text;

            try
            {

                paramaterDic.Add("StartDate", $"'{startDate}'");
                paramaterDic.Add("EndDate", $"'{endDate}'");
                paramaterDic.Add("CSTID", $"{cstid}");
                paramaterDic.Add("EQPTID", $"{EqpId}");
                paramaterDic.Add("RULEID", $"{ruleId}");

                if (cb_ReqState.SelectedIndex > 0)
                {
                    paramaterDic.Add("REQ_STAT_CODE", $"{cb_ReqState.Text}");
                }
                else
                {
                    paramaterDic.Add("REQ_STAT_CODE", $"");
                }

                winformUtils.ExcuteSql(paramaterDic, reqInfo_dgvReq.DgvData, main.correntConnectionStringSetting, MethodBase.GetCurrentMethod().Name);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} : ReqList");
            }

        }
    }
}
