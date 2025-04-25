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
    public partial class PortRequestList : UserControl
    {
        #region Variable
        MainViewer main;
        int currNum = 0;
        string errMsg;
        private string? durableId;
        WinformUtils? winformUtils = null;
        DefaultSqlData? searchPortRequestListData = null;
        DefaultSqlData? searchCarrierInfomationData = null;
        DefaultSqlData? searchTransportJobHistoryData = null;
        Dictionary<string, string>? eventCallVal = null; 
        List<Control>? variableControls = new List<Control>();
       
        #endregion

        #region Construction
        public PortRequestList(MainViewer main)
        {
            InitializeComponent();
            this.main = main;
            tAbt_ReqInfo_Search.timer.Tick += Timer_Tick;
            tAbt_ReqInfo_Search.bt_Search.Click += Bt_Search_Click;
            dgv_PortRequestList.DgvData.CellClick += ReqInfoDataGridViewCellClick;
            lAdtp_ReqInfo_EndDate.IsChecked = false;
            lAdtp_ReqInfo_StartDate.IsChecked = true;

            foreach (Control control in this.Controls[0].Controls)
            {
                if (control is UserControl)
                {
                    variableControls.Add(control);
                }
            }

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
            try
            {
                if (searchPortRequestListData != null)
                {
                    foreach (var item in searchPortRequestListData.Sqldata.EventValueDic.Keys)
                    {
                        EventValue eventValue = searchPortRequestListData.Sqldata.EventValueDic[item];
                        try
                        {
                            eventValue.Value = (sender as DataGridView).CurrentRow.Cells[eventValue.ColumnName].Value.ToString();

                            if (eventValue.Value == "")
                            {
                                continue;
                            }

                            // 동적으로 메서드 호출
                            winformUtils.InvokeMethodDynamically(this,eventValue.CallSQL, eventValue.Value);

                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                }
                //SearchTransportJobInfomation(1);

                //string localdurableId = searchPortRequestListData.Sqldata.EventValueDic["DURABLE_ID"].Value;

                //if (localdurableId == "")
                //{
                //    try
                //    {
                //        localdurableId = dgv_TransportJobInfomation.DgvData.Rows[0].Cells["DURABLE_ID"].Value.ToString();
                //    }
                //    catch (Exception)
                //    {
                //        localdurableId = "";
                //    }
                //}

                //if (localdurableId != "" && localdurableId != durableId)
                //{
                //    SearchCarrierInfomation(localdurableId);
                //    durableId = localdurableId;
                //}


                //if (ckb_IsOpenReqSituation.Checked)
                //{
                //    MakeSituations();
                //}
                //else
                //{
                //    string ruleResult = (sender as DataGridView).CurrentRow.Cells["RTD_EXEC_LOG_CNTT"].Value.ToString();
                //    MakeRuleResult(ruleResult);
                //}
            }
            catch { 
                
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
                SearchPortRequestList();
            }

            if (main.correntConnectionStringSetting.IsConnection)
            {
                //개별 옵션으로 내부 STR, 표기 STR을 따로 하게 수정필요
                lb_TransferStatus.Text = winformUtils.MakeTransferStatusCountString("REQ_STAT_CODE",dgv_PortRequestList);
            }
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            int interval = tAbt_ReqInfo_Search.Interval;

            if (currNum == 0)
            {
                SearchPortRequestList();
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

        private void MakeSituations()
        {

        }

        #endregion

        #region Assign SqlData to DataGrid view functuons Section 
        private void SearchPortRequestList()
        {
            try
            {
                Dictionary<string, string> paramaterDic = winformUtils.MakeParamaterDic(variableControls);
                string methodName = MethodBase.GetCurrentMethod().Name;
                searchPortRequestListData =
                    winformUtils.ShowDgv
                    (
                        methodName,
                        dgv_PortRequestList,
                        searchPortRequestListData,
                        paramaterDic
                    ) as DefaultSqlData;

                //다른 정보 화면 클리어 처리
                dgv_CarrierInfomation.DgvData.DataSource = null;
                dgv_TransportJobInfomation.DgvData.DataSource = null;
                tv_SituationOrRuleResult.Nodes.Clear();
            }
            catch (Exception ex)
            {
                dgv_PortRequestList.DgvData.DataSource = null;
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchCarrierInfomation(string carrierId)
        {
            try
            {
                if (searchPortRequestListData != null)
                {
                    Dictionary<string, string> paramaterDic = new Dictionary<string, string>();
                    string methodName = MethodBase.GetCurrentMethod().Name;
                    paramaterDic.Add("DURABLE_ID", carrierId);

                    searchCarrierInfomationData =
                        winformUtils.ShowDgv
                        (
                            methodName,
                            dgv_CarrierInfomation,
                            searchCarrierInfomationData,
                            paramaterDic
                        ) as DefaultSqlData;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchTransportJobInfomation(string carrierId)
        {
            try
            {
                if (searchPortRequestListData != null)
                {
                    string methodName = MethodBase.GetCurrentMethod().Name;
                    searchTransportJobHistoryData =
                        winformUtils.ShowDgv
                        (
                            methodName,
                            dgv_TransportJobInfomation,
                            searchTransportJobHistoryData,
                            searchPortRequestListData.Sqldata.getEventDicByFunctionName(methodName)
                        ) as DefaultSqlData;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
