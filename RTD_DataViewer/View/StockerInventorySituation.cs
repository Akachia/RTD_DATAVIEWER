using CustomUtills;
using Dapper;
using DBManagement;
using Microsoft.Data.SqlClient;
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
using UserWinfromControl;
using XmlManagement;

namespace RTD_DataViewer.View
{
    public partial class StockerInventorySituation : UserControl
    {

        #region Variable
        MainViewer main;
        int currNum = 0;
        string errMsg;
        WinformUtils? winformUtils = null;
        DefaultSqlData? SearchStockerInventoryData = null;
        DefaultSqlData? SearchTransportJobInfomationData = null;
        DefaultSqlData? SearchStockerCurrentStateData = null;
        Dictionary<string, string>? eventCallVal = null;
        Dictionary<string, string>? stkComCodeList = null;
        List<Control>? variableControls = new List<Control>();
        #endregion

        #region Construction
        public StockerInventorySituation(MainViewer main)
        {
            InitializeComponent();
            this.main = main;
            dgv_StockerInventory.DgvData.CellClick += Dgv_StoInventory_CellClick;
            cb_CarrierStat.SetCstStatData();
            cb_TrfStatCode.SetTransportStateCodeData();
            tb_CarrierId.IsMultiInputTextControl = true;

            foreach (Control control in this.Controls[0].Controls)
            {
                if (control is UserControl)
                {
                    variableControls.Add(control);
                }
            }

            this.clb_StockerCommonCodeList.ListBox.SelectedValueChanged += ListBox_SelectedValueChanged;

            winformUtils = new(main);
        }

        private void ListBox_SelectedValueChanged(object? sender, EventArgs e)
        {
            ListBox listBox = (ListBox)sender;

            clb_StockerList.Item.Clear();
            string methodName = MethodBase.GetCurrentMethod().Name;
            try
            {

                if (!main.correntConnectionStringSetting.IsConnection)
                {
                    return;
                }
                XmlOptionData sqldata = main.sqlList["SearchStockerList"];
                string cquery = sqldata.Sql;
                string area_Id = main.correntConnectionStringSetting.AreaID;
                StkComCodeList stkComCodes = clb_StockerCommonCodeList.DataObject as StkComCodeList;
                string systemTypeCode = stkComCodes.StkComCodeDic[listBox.SelectedItem.ToString()];
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add($"@AREA_ID", @$"{area_Id}%");
                parameters.Add($"@StockerCommonCode", systemTypeCode);

                using (var connection = new SqlConnection(main.correntConnectionStringSetting.MssqlConnectionString()))
                {
                    List<Stocker> list = connection.Query<Stocker>(cquery, parameters).ToList();
                    foreach (Stocker item in list)
                    {

                        clb_StockerList.Item.Add(item.EQPTID);
                    }

                    clb_StockerList.DataObject = list;
                    main.AppendLog(cquery, parameters);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void bt_GetStockerGroupList_Click(object sender, EventArgs e)
        {
            SearchStockerCommonCodeList();
        }

        private void clb_StockerCommonCodeList_Click(object sender, EventArgs e)
        {
            ListBox listBox = sender as ListBox;



        }
        #endregion

        #region Events for UI Controls
        private void Dgv_StoInventory_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            string cstId = (sender as DataGridView).CurrentRow.Cells["CSTID"].Value.ToString();
            SearchTransportJobInfomation(cstId);

            //string RoutId = (sender as DataGridView).CurrentRow.Cells["ROUT"].Value.ToString();
            //SearchRouteInfo(RoutId);
        }

        private void bt_Search_Click(object sender, EventArgs e)
        {
            SearchStockerInventory();
            SearchStockerCurrentState();
        }
        #endregion

        #region Utilities for Ui

        #endregion

        #region Assign SqlData to DataGrid view functuons Section 
        private void SearchStockerCommonCodeList()
        {
            clb_StockerCommonCodeList.Item.Clear();
            clb_StockerList.Item.Clear();
            string methodName = MethodBase.GetCurrentMethod().Name;
            try
            {

                if (!main.correntConnectionStringSetting.IsConnection)
                {
                    return;
                }
                XmlOptionData sqldata = main.sqlList[methodName];
                string cquery = sqldata.Sql;
                string area_Id = main.correntConnectionStringSetting.AreaID;
                string systemTypeCode = main.correntConnectionStringSetting.SystemTypeCode;

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add($"@AREA_ID", @$"{area_Id}%");
                parameters.Add($"@SYSTEM_TYPE_CODE", systemTypeCode);

                using (var connection = new SqlConnection(main.correntConnectionStringSetting.MssqlConnectionString()))
                {
                    StkComCodeList stkComCodes = new(connection.Query<CustomUtills.StkComCode>(cquery, parameters).ToList());
                    foreach (var item in stkComCodes)
                    {
                        clb_StockerCommonCodeList.Item.Add(item.Sto_Desc);
                    }

                    clb_StockerCommonCodeList.DataObject = stkComCodes;
                    main.AppendLog(cquery, parameters);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void SearchTransportJobInfomation(string cstid)
        {
            //WinformUtils winformUtils = new WinformUtils(main);
            //Dictionary<string, string> paramaterDic = new Dictionary<string, string>();
            //try
            //{
            //    paramaterDic.Add("CSTID", $"{cstid}");
            //    paramaterDic.Add("REQ_SEQNO", $"0");

            //    winformUtils.ExcuteSql(paramaterDic, dgv_TransportJobInfomation.DgvData, main.correntConnectionStringSetting, MethodBase.GetCurrentMethod().Name);
            //}
            //catch (Exception ex) { MessageBox.Show($"{ex.Message} : SearchTransportJobInfomation"); }
            Dictionary<string, string> paramaterDic = new Dictionary<string, string>();

            paramaterDic.Add("CSTID", $"{cstid}");
            try
            {
                if (SearchStockerInventoryData != null)
                {
                    string methodName = MethodBase.GetCurrentMethod().Name;
                    SearchTransportJobInfomationData =
                        winformUtils.ShowDgv
                        (
                            methodName,
                            this.dgv_TransportJobInfomation,
                            SearchTransportJobInfomationData,
                            paramaterDic
                        ) as DefaultSqlData;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private string MakestkComCodeString(List<StkComCode> stkComCodes)
        //{
        //    string CmdStatCodeList = string.Empty;

        //    foreach (string key in this.clb_StockerCommonCodeList.CheckedItem)
        //    {
        //        string str = stkComCodes.First(a => a.Sto_Desc == key).Code;

        //        if (CmdStatCodeList == string.Empty)
        //        {
        //            CmdStatCodeList += @$"'{str}'";
        //        }
        //        else
        //        {
        //            CmdStatCodeList += @$",'{str}'";
        //        }
        //    }
        //    return CmdStatCodeList;
        //}

        private void SearchStockerInventory()
        {
            Dictionary<string, string> paramaterDic = winformUtils.MakeParamaterDic(variableControls);
            string plantId = main.correntConnectionStringSetting.PlantID;
            //paramaterDic.Add("PLANT_ID", $"{plantId}");
            string methodName = MethodBase.GetCurrentMethod().Name;

            SearchStockerInventoryData =
                winformUtils.ShowDgv
                (
                    methodName,
                    dgv_StockerInventory,
                    SearchStockerInventoryData,
                    paramaterDic
                ) as DefaultSqlData;
            

            DateTime date1 = DateTime.Now;

            int rowCount = dgv_StockerInventory.DgvData.RowCount;

            foreach (DataGridViewRow row in dgv_StockerInventory.DgvData.Rows)
            {
                row.Cells["AGING_ISS_SCHD_DTTM"].Style.BackColor = Color.FromArgb(222, 245, 229); // 색상 변경
            }

            for (int i = 0; i < rowCount; i++)
            {
                try
                {
                    string agingDttm = dgv_StockerInventory.DgvData.Rows[i].Cells["AGING_ISS_SCHD_DTTM"].Value.ToString();
                    string agingPriority = dgv_StockerInventory.DgvData.Rows[i].Cells["AGING_ISS_PRIORITY_NO"].Value.ToString();
                    string trf_Stat_Code = dgv_StockerInventory.DgvData.Rows[i].Cells["TRF_STAT_CODE"].Value.ToString();

                    if (agingDttm != string.Empty)
                    {
                        DateTime dateTime = DateTime.Parse(agingDttm);

                        if (dateTime < date1)
                        {
                            //FFD4D4
                            dgv_StockerInventory.DgvData.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 212, 212);
                        }
                    }

                    if (agingPriority != string.Empty)
                    {
                        if (agingPriority == "8")
                        {
                            //FFD4D4
                            dgv_StockerInventory.DgvData.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(45, 149, 150);
                        }

                        if (agingPriority == "7")
                        {
                            //FFD4D4
                            dgv_StockerInventory.DgvData.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(45, 149, 150);
                        }

                        if (agingPriority == "9")
                        {
                            //FFD4D4
                            dgv_StockerInventory.DgvData.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(45, 149, 150);
                        }
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("SQL 문 점검이 필요합니다.");
                }

                //string eioIfMode = dgv_StoInventory.DgvData.Rows[i].Cells["EIOIFMODE"].Value.ToString();
                // string agingDttm = dgv_StoInventory.DgvData.Rows[i].Cells["AGING_ISS_SCHD_DTTM"].Value.ToString();
                
            }

            lb_WipStat.Text = winformUtils.MakeTransferStatusCountString("WIPSTAT", dgv_StockerInventory);
            lb_CstStat.Text = winformUtils.MakeTransferStatusCountString("CSTSTAT", dgv_StockerInventory, "상태");
            lb_Prodid.Text = winformUtils.MakeTransferStatusCountString("PRODID", dgv_StockerInventory);
            lb_RackStatCode.Text = winformUtils.MakeTransferStatusCountString("ROUT", dgv_StockerInventory);
            lb_TrfStatCode.Text = winformUtils.MakeTransferStatusCountString("TRF_STAT_CODE", dgv_StockerInventory, "반송상태");
            lb_AgingIssPriortyNo.Text = winformUtils.MakeTransferStatusCountString("AGING_ISS_PRIORITY_NO", dgv_StockerInventory, "출고 번호");
            lb_NextProcid.Text = winformUtils.MakeTransferStatusCountString("NEXT_PROCID", dgv_StockerInventory, "다음공정");
            lb_Procid.Text = winformUtils.MakeTransferStatusCountString("PROCID", dgv_StockerInventory,"현공정");
        }
        private void SearchStockerCurrentState()
        {
            Dictionary<string, string> paramaterDic = winformUtils.MakeParamaterDic(variableControls);
            string methodName = MethodBase.GetCurrentMethod().Name;

            //paramaterDic.Add("PLANT_ID", @$"'{plantId}%'");
            //paramaterDic.Add("SYSTEM_TYPE_CODE", $"'{systemTypeCode}'");

            SearchStockerCurrentStateData =
                winformUtils.ShowDgv
                (
                    methodName,
                    dgv_StockerCurrState,
                    SearchStockerCurrentStateData,
                    paramaterDic
                ) as DefaultSqlData;

        }

        private void SearchRouteInfo(string RoutId)
        {
            Dictionary<string, string> paramaterDic = winformUtils.MakeParamaterDic(variableControls);
            string methodName = MethodBase.GetCurrentMethod().Name;
            string plantId = main.correntConnectionStringSetting.PlantID;
            string systemTypeCode = main.correntConnectionStringSetting.SystemTypeCode;

            //paramaterDic.Add("PLANT_ID", @$"{plantId}");
            //paramaterDic.Add("SYSTEM_TYPE_CODE", $"{systemTypeCode}");
            paramaterDic.Add("ROUT", $"{RoutId}");

            SearchStockerCurrentStateData =
                winformUtils.ShowDgv
                (
                    methodName,
                    dgv_StockerCurrState,
                    SearchStockerCurrentStateData,
                    paramaterDic
                ) as DefaultSqlData;

        }

        #endregion


    }
}
