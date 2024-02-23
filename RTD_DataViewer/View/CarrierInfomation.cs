using CustomUtils;
using Dapper;
using DBManagement;
using DBManagemnet;
using Microsoft.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
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
    public partial class CarrierInfomation : UserControl
    {
        #region Variable
        WinformUtils? winformUtils = null;
        DefaultSqlData? SearchCarrierEventHistoryData = null;
        SearchCarrierInfomation? searchCarrierInfomationData = null;
        DefaultSqlData? SearchCarrierActHistoryData = null;
        List<Control>? variableControls = new List<Control>();
        #endregion

        #region Construction
        public CarrierInfomation(MainViewer main)
        {
            InitializeComponent();
            variableControls.Add(latb_CarrierId);
            winformUtils = new(main);
        }
        #endregion

        #region Events for UI Controls
        private void bt_CstInfoSearch_Click(object sender, EventArgs e)
        {
            SearchCarrierInfomation();
            SearchCarrierEventHistory();

            if (ckb_ValidNgHist.Checked == true)
            {
                SearchCarrierActHistory();
            }
            else
            {
                SearchCarrierActHistory();
            }
        }
        #endregion

        #region Utilities for Ui

        #endregion

        #region Assign SqlData to DataGrid view functuons Section 
        private void SearchCarrierInfomation()
        {
            try
            {
                Dictionary<string, string> paramaterDic = winformUtils.MakeParamaterDic(variableControls);
                string methodName = MethodBase.GetCurrentMethod().Name;
                searchCarrierInfomationData =
                    winformUtils.ShowDgv
                    (
                        methodName,
                        dgv_CarrierInfomation,
                        searchCarrierInfomationData,
                        paramaterDic
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void SearchCarrierActHistory()
        {
            string cstid = latb_CarrierId.Tb_Text;
            string methodName = MethodBase.GetCurrentMethod().Name;

            try
            {
                if (cstid != string.Empty)
                {
                    Dictionary<string, string> paramaterDic = winformUtils.MakeParamaterDic(variableControls);

                    SearchCarrierActHistoryData =
                        winformUtils.ShowDgv
                        (
                            methodName,
                            dgv_CarrierActHistory,
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
            string cstid = latb_CarrierId.Tb_Text;
            string methodName = MethodBase.GetCurrentMethod().Name;
            try
            {
                if (cstid != string.Empty)
                {
                    Dictionary<string, string> paramaterDic = winformUtils.MakeParamaterDic(variableControls);

                    SearchCarrierEventHistoryData =
                        winformUtils.ShowDgv
                        (
                            methodName,
                            dgv_CarrierEventHistory,
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
