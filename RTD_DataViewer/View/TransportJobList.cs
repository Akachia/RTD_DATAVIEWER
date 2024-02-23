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

namespace RTD_DataViewer.View
{
    public partial class TransportJobList : UserControl
    {
        #region Variable
        MainViewer main;
        int currNum = 0;
        WinformUtils? winformUtils = null;
        DefaultSqlData? currentTransportJobListData = null;
        SearchCarrierInfomation? searchCarrierInfomationData = null;
        DefaultSqlData? searchTransportJobHistoryData = null;
        List<Control>? variableControls = new List<Control>();
        public TransportJobList(MainViewer main)
        {
            InitializeComponent();
            this.main = main;
            InitControlText(main);
            winformUtils = new(main);
        }

        #endregion

        #region Construction
        public void InitControlText(MainViewer main)
        {
            DateTime tomorrow = DateTime.Today.AddDays(1);
            DateTime yesterday = DateTime.Today.AddDays(-1);
            this.main = main;
            tAbt_TransList_Search.timer.Tick += Timer_Tick;
            tAbt_TransList_Search.bt_Search.Click += Bt_Search_Click;
            lAdtp_TransList_EndDate.Dtp_Value = tomorrow;
            lAdtp_TransList_StartDate.Dtp_Value = yesterday;
            dgv_CurrentTransportJobList.DgvData.CellClick += CurrentTransportJobListCellClick;
 

            variableControls.Add(lAdtp_TransList_EndDate);
            variableControls.Add(lAdtp_TransList_StartDate);
            variableControls.Add(lAtb_TransList_CarrierId);
            variableControls.Add(lAtb_TransList_LaneId);
            variableControls.Add(lAtb_TransList_ReqEqp);
            variableControls.Add(lAtb_TransList_ToEqp);
            variableControls.Add(cb_CarrierStat);

            //dgv_CurrentTransportJobList.DgvData.CellDoubleClick += SearchCstInfo;

            cb_CarrierStat.SetCstStatData();
        }

        #endregion

        #region Events for UI Controls
        private void Bt_Search_Click(object? sender, EventArgs e)
        {
            Btn_Click();
        }
        private void Timer_Tick(object? sender, EventArgs e)
        {
            int interval = tAbt_TransList_Search.Interval;

            if (currNum == 0)
            {
                SearchCurrentTransportJobList();
                currNum = tAbt_TransList_Search.Interval;
            }
            else
            {
                tAbt_TransList_Search.bt_Search.Text = currNum.ToString("000") + "\nStop";
                currNum--;
            }
        }

        private void SearchCstInfo(object? sender, DataGridViewCellEventArgs e)
        {
            SearchCarrierInfomation();
        }

        private void CurrentTransportJobListCellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (currentTransportJobListData != null)
            {
                foreach (var item in currentTransportJobListData.Sqldata.EventValueDic.Keys)
                {
                    EventValue eventValue = currentTransportJobListData.Sqldata.EventValueDic[item];
                    eventValue.Value = (sender as DataGridView).CurrentRow.Cells[eventValue.ColumnName].Value.ToString();
                }
            }

            SearchTransportJobHistory();
            SearchCarrierInfomation();
        }
        #endregion

        #region Utilities for Ui
        private string MakeCmdStatCodeList()
        {
            string CmdStatCodeList = string.Empty;

            if (ckb_Send.Checked)
            {
                if (CmdStatCodeList == string.Empty)
                {
                    CmdStatCodeList += @"'SEND'";
                }
                else
                {
                    CmdStatCodeList += @",'SEND'";
                }
            }

            if (ckb_Receive.Checked)
            {
                if (CmdStatCodeList == string.Empty)
                {
                    CmdStatCodeList += @"'RECEIVE'";
                }
                else
                {
                    CmdStatCodeList += @",'RECEIVE'";
                }
            }

            if (ckb_Moving.Checked)
            {
                if (CmdStatCodeList == string.Empty)
                {
                    CmdStatCodeList += @"'MOVING'";
                }
                else
                {
                    CmdStatCodeList += @",'MOVING'";
                }
            }

            if (ckb_Delete.Checked)
            {
                if (CmdStatCodeList == string.Empty)
                {
                    CmdStatCodeList += @"'DELETE'";
                }
                else
                {
                    CmdStatCodeList += @",'DELETE'";
                }
            }

            if (ckb_Abnormal.Checked)
            {
                if (CmdStatCodeList == string.Empty)
                {
                    CmdStatCodeList += @"'ABNORMAL_END'";
                }
                else
                {
                    CmdStatCodeList += @",'ABNORMAL_END'";
                }
            }

            if (ckb_Cancel.Checked)
            {
                if (CmdStatCodeList == string.Empty)
                {
                    CmdStatCodeList += @"'CANCEL'";
                }
                else
                {
                    CmdStatCodeList += @",'CANCEL'";
                }
            }

            return CmdStatCodeList;
        }
        internal void Btn_Click()
        {
            if (tAbt_TransList_Search.IsUseTimer)
            {
                tAbt_TransList_Search.timer.Interval = 1000;
                if (tAbt_TransList_Search.timer.Enabled)
                {
                    tAbt_TransList_Search.timer.Stop();
                    tAbt_TransList_Search.bt_Search.Text = "Search";
                }
                else
                {
                    tAbt_TransList_Search.timer.Start();
                }
            }
            else
            {
                SearchCurrentTransportJobList();
            }
        }

        #endregion

        #region Assign SqlData to DataGrid view functuons Section 
        private void SearchTransportJobHistory()
        {
            try
            {
                if (currentTransportJobListData != null)
                {
                    string methodName = MethodBase.GetCurrentMethod().Name;
                    searchTransportJobHistoryData =
                        winformUtils.ShowDgv
                        (
                            methodName,
                            dgv_TransportJobHistory,
                            searchTransportJobHistoryData,
                            currentTransportJobListData.Sqldata.getEventDicByFunctionName(methodName)
                        ) as DefaultSqlData;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void SearchCarrierInfomation()
        {
            try
            {
                if (currentTransportJobListData != null)
                {
                    string methodName = MethodBase.GetCurrentMethod().Name;
                    searchCarrierInfomationData =
                        winformUtils.ShowDgv
                        (
                            methodName,
                            dgv_CarrierInfomation,
                            searchCarrierInfomationData,
                            currentTransportJobListData.Sqldata.getEventDicByFunctionName(methodName)
                        );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        /// <summary>
        /// 현재 반송 현황을 보여주는 함수
        /// </summary>
        private void SearchCurrentTransportJobList()
        {
            Dictionary<string, string> paramaterDic = winformUtils.MakeParamaterDic(variableControls);

            paramaterDic.Add("CMD_STAT_CODE_LIST", MakeCmdStatCodeList());
            paramaterDic.Add("isFaulty", $"{ckb_IsFaulty.Checked}");

            string methodName = MethodBase.GetCurrentMethod().Name;
            currentTransportJobListData = winformUtils.ShowDgv(methodName, dgv_CurrentTransportJobList, currentTransportJobListData, paramaterDic) as DefaultSqlData;

        }
        #endregion


    }
}
