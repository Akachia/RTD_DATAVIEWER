using CustomUtills;
using Dapper;
using DBManagement;
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
        #region Variable
        MainViewer main;
        int currNum = 0;
        string errMsg;
        DefaultSqlData reqListData = null;
        Dictionary<string, string> paramaterDic;
        #endregion

        #region Construction
        public ReqInfomation(MainViewer main)
        {
            InitializeComponent();
            this.main = main;
            tAbt_ReqInfo_Search.timer.Tick += Timer_Tick;
            tAbt_ReqInfo_Search.bt_Search.Click += Bt_Search_Click;
            reqInfo_dgvReq.DgvData.CellClick += ReqInfoDataGridViewCellClick;
            lAdtp_ReqInfo_EndDate.IsChecked = false;
            lAdtp_ReqInfo_StartDate.IsChecked = true;
        }
        #endregion

        #region Events for UI Controls
        private void label1_Click(object sender, EventArgs e)
        {

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


            if (ckb_IsOpenReqSituation.Checked)
            {
                MakeSituations();
            }
            else
            {
                string ruleResult = (sender as DataGridView).CurrentRow.Cells["RTD_EXEC_LOG_CNTT"].Value.ToString();
                MakeRuleResult(ruleResult);
            }
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

            if (main.correntConnectionStringSetting.DatabaseProvider != "ORACLE")
            {
                lb_TransferStatus.Text = MakeTransferStatusCountString("REQ_STAT_CODE", new string[] { "CREATED", "REQUEST" }, reqInfo_dgvReq.DgvData.RowCount);
            }
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



        #endregion

        #region Utilities for Ui
        private void MakeRuleResult(string ruleResult)
        {
            RuleResultCollection ruleResultCollection = new RuleResultCollection(ruleResult);

            tv_SituationOrRuleResult.Nodes.Clear();

            foreach (RuleResult rule in ruleResultCollection.RuleResults)
            {
                TreeNode rootNode = new TreeNode($"{rule.RuleName} : {rule.ResultNum}");
                rootNode.Name = rule.RuleId.ToString();
                tv_SituationOrRuleResult.Nodes.Add(rootNode);

                foreach (RuleResult childRule in rule.ChildRuleResults)
                {
                    TreeNode childNode = new TreeNode($"{childRule.RuleName} : {childRule.ResultNum}");
                    childNode.Name = childRule.RuleId.ToString();
                    rootNode.Nodes.Add(childNode);
                }
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


        private void GetValues()
        {

        }

        private void MakeSituations()
        {

        }

        #endregion

        #region Assign SqlData to DataGrid view functuons Section 

        public void ReqList()
        {
            paramaterDic = new Dictionary<string, string>();
            string methodName = MethodBase.GetCurrentMethod().Name;

            paramaterDic.Add("StartDate", $"{lAdtp_ReqInfo_StartDate.MakeNowDateStringAndSetting()}");
            paramaterDic.Add("EndDate", $"{lAdtp_ReqInfo_EndDate.MakeNowDateStringAndSetting()}");
            paramaterDic.Add("CSTID", $"{lAtb_ReqInfo_Cstid.Tb_Text}");
            paramaterDic.Add("PORT_ID", $"{lAtb_ReqInfo_ReqEqp.Tb_Text}");
            paramaterDic.Add("RULEID", $"{lAtb_ReqInfo_RuleText.Tb_Text}");
            paramaterDic.Add("CSTSTAT", $"{cb_CarrierState}");

            if (cb_ReqState.SelectedIndex > 0)
            {
                paramaterDic.Add("REQ_STAT_CODE", $"{cb_ReqState.Text}");
            }
            else
            {
                paramaterDic.Add("REQ_STAT_CODE", $"");
            }

            try
            {
                if (reqListData == null)
                {
                    reqListData = new DefaultSqlData(paramaterDic, main.sqlList[methodName], main.correntConnectionStringSetting);
                    reqInfo_dgvReq.DgvData.DataSource = reqListData.ExcuteSql();
                }
                else
                {
                    reqInfo_dgvReq.DgvData.DataSource = reqListData.ExcuteSql(paramaterDic, main.sqlList[methodName], main.correntConnectionStringSetting);
                }

                if (reqListData.ErrMsg == string.Empty)
                {
                    main.AppendLog(reqListData.sqlStr);
                    new WinformUtils().DataGridView_Coloring(reqInfo_dgvReq.DgvData, main.sqlList[methodName]);
                }
                else
                {
                    MessageBox.Show($"{reqListData.ErrMsg} : {methodName}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} : {methodName}");
            }
        }


        private void SearchCstInfo(string cstId)
        {
            string errMsg = string.Empty;
            new WinformUtils(main).SearchCstInfo(reqInfo_DgvCarrier.DgvData, cstId, ref errMsg);

            if (errMsg.Equals(string.Empty))
            {
                lb_CarrierInfoValidText.Text = "Carrier loading infomation is normal";
            }
            else
            {
                lb_CarrierInfoValidText.Text = errMsg;
            }
        }

        private void SearchTrfInfo(string req_SeqNo)
        {
            WinformUtils winformUtils = new WinformUtils(main);
            Dictionary<string, string> paramaterDic = new Dictionary<string, string>();
            try
            {
                paramaterDic.Add("REQ_SEQNO", $"{req_SeqNo}");
                paramaterDic.Add("CSTID", $"");

                winformUtils.ExcuteSql(paramaterDic, reqInfo_dgvReq_TrfInfo.DgvData, main.correntConnectionStringSetting, MethodBase.GetCurrentMethod().Name);


            }
            catch (Exception ex) { MessageBox.Show($"{ex.Message} : SearchTrfInfo"); }
        }

        #endregion
    }
}
