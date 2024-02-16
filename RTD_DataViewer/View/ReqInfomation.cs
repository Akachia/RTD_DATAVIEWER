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

        List<Control> variableControls = new List<Control>();
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

        private Dictionary<string, string> MakeParamaterDic()//List<Control> variableControls)
        {
            Dictionary<string, string> paramaterDic = new Dictionary<string, string>();
            try
            {
                foreach (var item in variableControls)
                {
                    if (item is UWC_LabelAndDateTimePicker)
                    {
                        UWC_LabelAndDateTimePicker datePicker = item as UWC_LabelAndDateTimePicker;
                        paramaterDic.Add(datePicker.VariableName, datePicker.MakeNowDateStringAndSetting());
                    }

                    if (item is UWC_LabelAndTextBox)
                    {
                        UWC_LabelAndTextBox text = item as UWC_LabelAndTextBox;
                        paramaterDic.Add(text.VariableName, text.Tb_Text);
                    }

                    if (item is UWC_ComboBox)
                    {
                        UWC_ComboBox comboBox = item as UWC_ComboBox;

                        if (cb_ReqState.ComboBoxSelectedIndex > 0)
                        {
                            paramaterDic.Add(comboBox.VariableName, comboBox.ComboBoxSelectedItem);
                        }
                        else
                        {
                            paramaterDic.Add(comboBox.VariableName, $"");
                        }
                    }
                }

                return paramaterDic;
            }
            catch (Exception)
            {
                return null;
            }


        }

        private void GetValues()
        {

        }

        private void MakeSituations()
        {

        }

        #endregion

        #region Assign SqlData to DataGrid view functuons Section 
        private void ReqList()
        {
            MakeParamaterDic();
            string methodName = MethodBase.GetCurrentMethod().Name;
            winformUtils.ShowDgv(methodName, MakeParamaterDic(), reqInfo_dgvReq.DgvData, reqListData);
        }

        private void SearchCstInfo(string cstId)
        {
            string methodName = MethodBase.GetCurrentMethod().Name;
            MakeParamaterDic();
            winformUtils.ShowDgv(methodName, MakeParamaterDic(), reqInfo_DgvCarrier.DgvData, searchCstInfoData);
        }

        private void SearchTrfInfo(string req_SeqNo)
        {
            string methodName = MethodBase.GetCurrentMethod().Name;
            MakeParamaterDic();
            winformUtils.ShowDgv(methodName, MakeParamaterDic(), reqInfo_dgvReq_TrfInfo.DgvData, searchTrfInfoData);
        }
        #endregion

        private void cb_ReqState_Load(object sender, EventArgs e)
        {

        }
    }
}
