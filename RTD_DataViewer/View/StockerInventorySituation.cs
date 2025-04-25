using CustomUtills;
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


        ToolTip toolTipProdid = new ToolTip();
        ToolTip toolTipNextProcid = new ToolTip();
        ToolTip toolTipRoute = new ToolTip();
        ToolTip toolProcid = new ToolTip();
        ToolTip toolWipStat = new ToolTip();
        ToolTip toolCstStat = new ToolTip();
        ToolTip toolRackStatCode = new ToolTip();
        ToolTip toolAgingIssPriortyNo = new ToolTip();
        #endregion

        #region Construction
        public StockerInventorySituation(MainViewer main)
        {
            InitializeComponent();
            this.main = main;
            dgv_StockerInventory.DgvData.CellClick += Dgv_StoInventory_CellClick;
            cb_CarrierStat.SetCstStatData();
            cb_TrfStatCode.SetTransportStateCodeData();
            cb_AgingIssPriortyNo.SetAgingIssPriortyNo();
            cb_WipStat.SetWipStat();
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



           // toolTipProdid.SetToolTip(lb_Prodid, lb_Prodid.Text);
            //toolTipNextProcid.SetToolTip(lb_NextProcid, lb_NextProcid.Text);
            //toolTipRoute.SetToolTip(lb_Route, lb_Route.Text);
            //toolProcid.SetToolTip(lb_Procid, lb_Procid.Text);
            //toolProcid.SetToolTip(lb_WipStat, lb_WipStat.Text);
            //toolProcid.SetToolTip(lb_CstStat, lb_CstStat.Text);
            //toolProcid.SetToolTip(lb_RackStatCode, lb_RackStatCode.Text);
            //toolProcid.SetToolTip(lb_AgingIssPriortyNo, lb_AgingIssPriortyNo.Text) ;

        }

        private void TestSearchStockerList()
        {
            XmlOptionData sqldata = main.sqlList["SearchStockerList"];
            string cquery = sqldata.Sql;
            string area_Id = main.correntConnectionStringSetting.AreaID;
            StkComCodeList stkComCodes = clb_StockerCommonCodeList.DataObject as StkComCodeList;
            string systemTypeCode = "7";
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add($"@AREA_ID", area_Id);
            parameters.Add($"@StockerCommonCode", systemTypeCode);

            if (main.correntConnectionStringSetting.DatabaseProvider == "ORACLE")
            {
                using (var connection = new OracleConnection(main.correntConnectionStringSetting.ConnectionString()))
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
            clb_StockerCommonCodeList.Item.Add("TEST");
            clb_StockerList.Item.Add(new Stocker() { EQPTID = "J1FSTO12307" }.EQPTID);
            clb_StockerList.Item.Add(new Stocker() { EQPTID = "J1FSTO12308" }.EQPTID);
        }


        private void ListBox_SelectedValueChanged(object? sender, EventArgs e)
        {
            ListBox listBox = (ListBox)sender;

            clb_StockerList.Item.Clear();
            string methodName = MethodBase.GetCurrentMethod().Name;
            try
            {
                XmlOptionData sqldata = main.sqlList["SearchStockerList"];
                string cquery = sqldata.Sql;
                string area_Id = main.correntConnectionStringSetting.AreaID;
                StkComCodeList stkComCodes = clb_StockerCommonCodeList.DataObject as StkComCodeList;
                string systemTypeCode = stkComCodes.StkComCodeDic[listBox.SelectedItem.ToString()];
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add($"@AREA_ID", area_Id);
                parameters.Add($"@StockerCommonCode", systemTypeCode);

                if (main.correntConnectionStringSetting.DatabaseProvider == "ORACLE")
                {
                    using (var connection = new OracleConnection(main.correntConnectionStringSetting.ConnectionString()))
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
                else
                {
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
            string cstId = (sender as DataGridView).CurrentRow.Cells["DURABLE_ID"].Value.ToString();
            SearchTransportJobInfomation(cstId);

            //string RoutId = (sender as DataGridView).CurrentRow.Cells["ROUT"].Value.ToString();
            //SearchRouteInfo(RoutId);
        }

        private void bt_Search_Click(object sender, EventArgs e)
        {
            if (clb_StockerList.Item.Count == 0)
            {
                SearchStockerCommonCodeList();
            }
            else
            {
                SearchStockerInventory();
                SearchStockerCurrentState();
            }


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

                XmlOptionData sqldata = main.sqlList[methodName];
                string cquery = sqldata.Sql;
                string area_Id = main.correntConnectionStringSetting.AreaID;
                string systemTypeCode = main.correntConnectionStringSetting.SystemTypeCode;

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add($"@AREA_ID", area_Id);
                parameters.Add($"@SYSTEM_TYPE_CODE", systemTypeCode);

                if (main.correntConnectionStringSetting.DatabaseProvider == "ORACLE")
                {
                    using (var connection = new OracleConnection(main.correntConnectionStringSetting.ConnectionString()))
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
                else
                {
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

               // TestSearchStockerList();
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

            paramaterDic.Add("DURABLE_ID", $"{cstid}");
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
            int dateOverRowCount = 0;
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
                            dateOverRowCount++;
                        }
                    }

                    if (agingPriority != string.Empty)
                    {
                        if (agingPriority == "8") //
                        {
                            //FFD4D4
                            dgv_StockerInventory.DgvData.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(45, 149, 150);
                        }

                        if (agingPriority == "7") //
                        {
                            //FFD4D4
                            dgv_StockerInventory.DgvData.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(45, 149, 150);
                        }

                        if (agingPriority == "4") //적재 출고
                        {
                            //FFD4D4
                            dgv_StockerInventory.DgvData.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(45, 149, 150);
                        }

                        if (agingPriority == "6") //스토커 이동
                        {
                            //FFD4D4
                            dgv_StockerInventory.DgvData.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(45, 149, 150);
                        }

                        if (agingPriority == "9") //강제 출고
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
                //string agingDttm = dgv_StoInventory.DgvData.Rows[i].Cells["AGING_ISS_SCHD_DTTM"].Value.ToString();
            }

            for (int i = 0; i < flowLayoutPanel1.Controls.Count; i++)
            {
                object VARIABLE = flowLayoutPanel1.Controls[i];

                if (VARIABLE is UWC_Label)
                {
                    UWC_Label lb_Del = VARIABLE as UWC_Label;
                    lb_Del.Dispose();
                }
            }

                UWC_Label lb_new = new UWC_Label();
                //lb_new.Name = $"lb_{"TRF_STAT_CODE"}";
                lb_new.Parent = this.flowLayoutPanel1;
                lb_new.Text = winformUtils.MakeTransferStatusCountString("TRF_STAT_CODE", dgv_StockerInventory, "반송상태");
                lb_new.AutoSize = true;
                lb_new.AutoSizeMode = AutoSizeMode.GrowAndShrink;

                //lb_WipStat.Text = winformUtils.MakeTransferStatusCountString("WIPSTAT", dgv_StockerInventory);
                //lb_CstStat.Text = winformUtils.MakeTransferStatusCountString("CSTSTAT", dgv_StockerInventory, "상태");
                //lb_TrayLevel.Text = winformUtils.MakeTransferStatusCountString("단", dgv_StockerInventory, "단");
                //lb_Prodid.Text = winformUtils.MakeTransferStatusCountString("PRODID", dgv_StockerInventory);
                //lb_Route.Text = winformUtils.MakeTransferStatusCountString("ROUT", dgv_StockerInventory);
                //lb_RackStatCode.Text = winformUtils.MakeTransferStatusCountString("RACK_STAT_CODE", dgv_StockerInventory, "Rack현황");
                //lb_TrfStatCode.Text = winformUtils.MakeTransferStatusCountString("TRF_STAT_CODE", dgv_StockerInventory, "반송상태");
                //lb_AgingIssPriortyNo.Text = winformUtils.MakeTransferStatusCountString("AGING_ISS_PRIORITY_NO", dgv_StockerInventory, "출고 번호");
                //lb_NextProcid.Text = winformUtils.MakeTransferStatusCountString("NEXT_PROCID", dgv_StockerInventory, "다음공정");
                //lb_Procid.Text = winformUtils.MakeTransferStatusCountString("PROCID", dgv_StockerInventory, "현공정");
                //lb_DateOverRowCount.Text = $"반송 대기 : {dateOverRowCount}\n";
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


        private void lb_TrfStatCode_Click(object sender, EventArgs e)
        {

        }
    }
}
