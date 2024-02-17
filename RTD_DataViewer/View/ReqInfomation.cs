using CustomUtills;
using Dapper;
using DBManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserWinfromControl;
using XmlManagement;
using static CustomUtils.CommonXml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RTD_DataViewer.View
{
    public partial class ReqInfomation : UserControl
    {
        #region Variable
        MainViewer main;
        int currNum = 0;
        string errMsg;
        WinformUtils? winformUtils = null;
        DefaultSqlData? reqListData = null;
        SearchCstInfo? searchCstInfoData = null;
        DefaultSqlData? searchTrfInfoData = null;
        Dictionary<string, string>? eventCallVal = null; 
        List<Control>? variableControls = new List<Control>();
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

            variableControls.Add(lAdtp_ReqInfo_StartDate);
            variableControls.Add(lAdtp_ReqInfo_EndDate);
            variableControls.Add(lAtb_ReqInfo_Cstid);
            variableControls.Add(lAtb_ReqInfo_ReqEqp);
            variableControls.Add(lAtb_ReqInfo_RuleText);
            variableControls.Add(cb_CarrierState);
            variableControls.Add(cb_ReqState);

            cb_CarrierState.SetCstStatData();
            cb_ReqState.SetReqStatCodeData();

            winformUtils = new(main);
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

            if (reqListData != null)
            {
                foreach (var item in reqListData.Sqldata.EventValueDic.Keys)
                {
                    EventValue eventValue = reqListData.Sqldata.EventValueDic[item];
                    eventValue.Value = (sender as DataGridView).CurrentRow.Cells[eventValue.ColumnName].Value.ToString();
                }
            }

            SearchTrfInfo();

            string cstId = reqListData.Sqldata.EventValueDic["CSTID"].Value;

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
                SearchCstInfo();
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

        private void MakeSituations()
        {

        }

        #endregion

        #region Assign SqlData to DataGrid view functuons Section 
        private void ReqList()
        {
            Dictionary<string, string> paramaterDic = winformUtils.MakeParamaterDic(variableControls);
            string methodName = MethodBase.GetCurrentMethod().Name;
            reqListData = winformUtils.ShowDgv(methodName, reqInfo_dgvReq.DgvData, reqListData, paramaterDic) as DefaultSqlData;
        }

        private void SearchCstInfo()
        {
            string methodName = MethodBase.GetCurrentMethod().Name;
            searchCstInfoData = winformUtils.ShowDgv(methodName, reqInfo_DgvCarrier.DgvData, searchCstInfoData, reqListData.Sqldata.getEventDicByFunctionName(methodName)) as SearchCstInfo;
        }

        private void SearchTrfInfo()
        {
            string methodName = MethodBase.GetCurrentMethod().Name;
            searchTrfInfoData = winformUtils.ShowDgv(methodName, reqInfo_dgvReq_TrfInfo.DgvData, searchTrfInfoData, reqListData.Sqldata.getEventDicByFunctionName(methodName)) as DefaultSqlData;
        }

#endregion
    }
}
