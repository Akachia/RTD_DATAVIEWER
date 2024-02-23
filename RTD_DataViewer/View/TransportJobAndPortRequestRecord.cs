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
    public partial class TransportJobAndPortRequestRecord : UserControl
    {

        #region Variable
        WinformUtils? winformUtils = null;
        DefaultSqlData? searchTransportJobRecordData = null;
        DefaultSqlData? searchPortRequestHistoryData = null;
        List<Control>? variableControls = new List<Control>();
        #endregion

        #region Construction
        public TransportJobAndPortRequestRecord(MainViewer main)
        {
            InitializeComponent();
            

            DateTime tomorrow = DateTime.Today.AddDays(1);
            DateTime yesterday = DateTime.Today.AddDays(-1);
            
            bt_ReqATransfer_Search.Click += Bt_ReqATransfer_Search_Click;
            lAdtp_ReqATransfer_EndDate.Dtp_Value = tomorrow;
            lAdtp_ReqATransfer_StartDate.Dtp_Value = yesterday;
            lAdtp_ReqATransfer_EndDate.IsChecked = false;
            lAdtp_ReqATransfer_StartDate.IsChecked = true;

            variableControls.Add(lAdtp_ReqATransfer_StartDate);
            variableControls.Add(lAdtp_ReqATransfer_EndDate);
            variableControls.Add(lAtb_ReqATransfer_CarrierId);
            variableControls.Add(lAtb_ReqATransfer_RuleId);
            variableControls.Add(lAtb_ReqATransfer_StartPort);
            variableControls.Add(lAtb_ReqATransfer_ArrPort);
            variableControls.Add(cb_CarrierStat);
            variableControls.Add(cb_TransportStatList);

            cb_CarrierStat.SetCstStatData();
            cb_TransportStatList.SetTransportStatCodeData();

             winformUtils = new(main);
        }
        #endregion

        #region Events for UI Controls
        private void Bt_ReqATransfer_Search_Click(object? sender, EventArgs e)
        {
            if (rb_ReqHist.Checked) { SearchPortRequestHistory(); }
            else { SearchTransportJobRecord(); }
        }
        #endregion

        #region Utilities for Ui

        #endregion

        #region Assign SqlData to DataGrid view functuons Section 
        private void SearchTransportJobRecord()
        {
            try
            {
                Dictionary<string, string> paramaterDic = winformUtils.MakeParamaterDic(variableControls);

                string methodName = MethodBase.GetCurrentMethod().Name;
                searchTransportJobRecordData =
                    winformUtils.ShowDgv
                    (
                        methodName,
                        dgv_PortRequestRecord,
                        searchTransportJobRecordData,
                        paramaterDic
                    ) as DefaultSqlData;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchPortRequestHistory()
        {

            try
            {
                Dictionary<string, string> paramaterDic = winformUtils.MakeParamaterDic(variableControls);

                string methodName = MethodBase.GetCurrentMethod().Name;
                searchPortRequestHistoryData =
                    winformUtils.ShowDgv
                    (
                        methodName,
                        dgv_PortRequestRecord,
                        searchPortRequestHistoryData,
                        paramaterDic
                    ) as DefaultSqlData;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion






    }
}
