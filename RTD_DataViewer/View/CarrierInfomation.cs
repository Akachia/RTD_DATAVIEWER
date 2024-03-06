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
        DefaultSqlData? SearchCarrierEventAbbreviatedRecordData = null;
        SearchCarrierInfomation? searchCarrierInfomationData = null;
        DefaultSqlData? SearchCarrierActAbbreviatedRecordData = null;
        List<Control>? variableControls = new List<Control>();
        #endregion

        #region Construction
        public CarrierInfomation(MainViewer main)
        {
            InitializeComponent();

            foreach (Control control in this.Controls[0].Controls)
            {
                if (control is UserControl)
                {
                    variableControls.Add(control);
                }
            }

            winformUtils = new(main);
        }
        #endregion

        #region Events for UI Controls
        private void bt_CstInfoSearch_Click(object sender, EventArgs e)
        {

            dgv_CarrierInfomation.DgvData.DataSource = null;
            dgv_CarrierActAbbreviatedRecord.DgvData.DataSource = null;
            dgv_CarrierEventAbbreviatedRecord.DgvData.DataSource = null;

            SearchCarrierInfomation();
            SearchCarrierEventAbbreviatedRecord();

            if (ckb_ValidNgHist.Checked == true)
            {
                SearchCarrierActAbbreviatedRecord();
            }
            else
            {
                SearchCarrierActAbbreviatedRecord();
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


        private void SearchCarrierActAbbreviatedRecord()
        {
            string cstid = latb_CarrierId.Tb_Text;
            string methodName = MethodBase.GetCurrentMethod().Name;

            try
            {
                if (cstid != string.Empty)
                {
                    Dictionary<string, string> paramaterDic = winformUtils.MakeParamaterDic(variableControls);

                    SearchCarrierActAbbreviatedRecordData =
                        winformUtils.ShowDgv
                        (
                            methodName,
                            dgv_CarrierActAbbreviatedRecord,
                            SearchCarrierActAbbreviatedRecordData,
                            paramaterDic
                        ) as DefaultSqlData;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} : {methodName}");
            }
        }

        private void SearchCarrierEventAbbreviatedRecord()
        {
            string cstid = latb_CarrierId.Tb_Text;
            string methodName = MethodBase.GetCurrentMethod().Name;
            try
            {
                if (cstid != string.Empty)
                {
                    Dictionary<string, string> paramaterDic = winformUtils.MakeParamaterDic(variableControls);

                    SearchCarrierEventAbbreviatedRecordData =
                        winformUtils.ShowDgv
                        (
                            methodName,
                            dgv_CarrierEventAbbreviatedRecord,
                            SearchCarrierEventAbbreviatedRecordData,
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
