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
    public partial class CarrierHistory : UserControl
    {
        #region Variable
        WinformUtils? winformUtils = null;
        DefaultSqlData? SearchCarrierEventHistoryData = null;
        DefaultSqlData? SearchCarrierActHistoryData = null;
        List<Control>? variableControls = new List<Control>();

        #endregion

        #region Construction
        public CarrierHistory(MainViewer main)
        {
            InitializeComponent();

            DateTime tomorrow = DateTime.Today.AddDays(1);
            DateTime yesterday = DateTime.Today.AddDays(-1);

            lAdtp_CstHist_EndDate.Dtp_Value = tomorrow;
            lAdtp_CstHist_StartDate.Dtp_Value = yesterday;
            lAdtp_CstHist_EndDate.IsChecked = false;
            lAdtp_CstHist_StartDate.IsChecked = true;

            variableControls.Add(lAdtp_CstHist_EndDate);
            variableControls.Add(lAdtp_CstHist_StartDate);
            variableControls.Add(lAtb_CstHist_CarrierId);
            variableControls.Add(lAtb_CstHist_RepCst);

            winformUtils = new(main);
        }
        #endregion

        #region Events for UI Controls

        #endregion

        #region Utilities for Ui
        private void bt_CstHist_Search_Click(object sender, EventArgs e)
        {
            bool isTrayActHist = rb_IsTrayActHist.Checked;
            bool isEventHist = rb_IsEventHist.Checked;

            if (isTrayActHist == true)
            {
                SearchCarrierActHistory();
            }
            else if (isEventHist == true)
            {
                SearchCarrierEventHistory();
            }
        }
        #endregion

        #region Assign SqlData to DataGrid view functuons Section 

        private void SearchCarrierActHistory()
        {
            string cstid = lAtb_CstHist_CarrierId.Tb_Text;
            string repCstId = lAtb_CstHist_RepCst.Tb_Text;
            string methodName = MethodBase.GetCurrentMethod().Name;

            try
            {
                if (cstid != string.Empty || repCstId != string.Empty)
                {
                    Dictionary<string, string> paramaterDic = winformUtils.MakeParamaterDic(variableControls);
                    SearchCarrierActHistoryData =
                        winformUtils.ShowDgv
                        (
                            methodName,
                            dgv_CarrierHistory,
                            SearchCarrierActHistoryData,
                            paramaterDic
                        ) as DefaultSqlData;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} : {methodName}");
            }
        }

        private void SearchCarrierEventHistory()
        {
            string cstid = lAtb_CstHist_CarrierId.Tb_Text;
            string repCstId = lAtb_CstHist_RepCst.Tb_Text;
            string methodName = MethodBase.GetCurrentMethod().Name;
            try
            {
                if (cstid != string.Empty || repCstId != string.Empty)
                {
                    Dictionary<string, string> paramaterDic = winformUtils.MakeParamaterDic(variableControls);

                    SearchCarrierEventHistoryData =
                        winformUtils.ShowDgv
                        (
                            methodName,
                            dgv_CarrierHistory,
                            SearchCarrierEventHistoryData,
                            paramaterDic
                        ) as DefaultSqlData;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} : {methodName}");
            }
        }

        #endregion








    }
}
