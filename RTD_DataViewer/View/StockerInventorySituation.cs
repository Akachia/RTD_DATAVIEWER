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
        DefaultSqlData? searchTransportJobHistoryData = null;
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
            winformUtils = new(main);
        }

        #endregion

        #region Events for UI Controls
        private void Dgv_StoInventory_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            string cstId = (sender as DataGridView).CurrentRow.Cells["CSTID"].Value.ToString();
            SearchTransportJobInfomation(cstId);
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
            try
            {
                if (!main.correntConnectionStringSetting.IsConnection)
                {
                    return;
                }
                XmlOptionData sqldata = main.sqlList["SearchStockerCommonCodeList"];
                string cquery = sqldata.Sql;
                string plantId = main.correntConnectionStringSetting.PlantID;
                string systemTypeCode = main.correntConnectionStringSetting.SystemTypeCode;

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add($"@PLANT_ID", @$"{plantId}%");
                parameters.Add($"@SYSTEM_TYPE_CODE", systemTypeCode);

                using (var connection = new SqlConnection(main.correntConnectionStringSetting.MssqlConnectionString()))
                {
                    List<StkComCode> stkComCodes = connection.Query<StkComCode>(cquery, parameters).ToList();
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
                if (SearchTransportJobInfomationData != null)
                {
                    string methodName = MethodBase.GetCurrentMethod().Name;
                    searchTransportJobHistoryData =
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

        private string MakestkComCodeString(List<StkComCode> stkComCodes)
        {
            string CmdStatCodeList = string.Empty;

            foreach (string key in this.clb_StockerCommonCodeList.CheckedItem)
            {
                string str = stkComCodes.First(a => a.Sto_Desc == key).Code;

                if (CmdStatCodeList == string.Empty)
                {
                    CmdStatCodeList += @$"'{str}'";
                }
                else
                {
                    CmdStatCodeList += @$",'{str}'";
                }
            }
            return CmdStatCodeList;
        }
        private void SearchStockerInventory()
        {
            Dictionary<string, string> paramaterDic = new Dictionary<string, string>();
            List<StkComCode> stkComCodes = clb_StockerCommonCodeList.DataObject as List<StkComCode>;

            string plantId = main.correntConnectionStringSetting.PlantID;
            string stoCode = 


            string trfStatCode = string.Empty;

            if (cb_TrfStatCode.SelectedIndex > 0)
            {
                trfStatCode = cb_TrfStatCode.Text;
            }

            paramaterDic.Add("PLANT_ID", $"'{plantId}'");
            paramaterDic.Add("STO_CODE", $"'{stoCode}'");
            paramaterDic.Add("CSTSTAT", $"{cb_CarrierStat.ComboBoxSelectedIndex}");
            paramaterDic.Add("TRF_STAT_CODE", $"{trfStatCode}");

            winformUtils.ExcuteSql(paramaterDic, dgv_StockerInventory.DgvData, main.correntConnectionStringSetting, MethodBase.GetCurrentMethod().Name);

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
                }
                catch (Exception)
                {

                    MessageBox.Show("SQL 문 점검이 필요합니다.");
                }

                //string eioIfMode = dgv_StoInventory.DgvData.Rows[i].Cells["EIOIFMODE"].Value.ToString();
                // string agingDttm = dgv_StoInventory.DgvData.Rows[i].Cells["AGING_ISS_SCHD_DTTM"].Value.ToString();

            }
        }
        private void SearchStockerCurrentState()
        {
            WinformUtils winformUtils = new WinformUtils(main);
            Dictionary<string, string> paramaterDic = new Dictionary<string, string>();

            string plantId = main.correntConnectionStringSetting.PlantID;
            //string stoCode = stkComCodeList[daff.Text];
            string systemTypeCode = main.correntConnectionStringSetting.SystemTypeCode;

            // paramaterDic.Add("STO_CODE", $"'{stoCode}'");
            paramaterDic.Add("PLANT_ID", @$"'{plantId}%'");
            paramaterDic.Add("SYSTEM_TYPE_CODE", $"'{systemTypeCode}'");

            winformUtils.ExcuteSql(paramaterDic, dgv_StockerCurrState.DgvData, main.correntConnectionStringSetting, MethodBase.GetCurrentMethod().Name);
            //winformUtils.DataGridView_EioColoring(dgv_StoStatus);
        }

        #endregion

        private void bt_GetStockerGroupList_Click(object sender, EventArgs e)
        {
            SearchStockerCommonCodeList();
        }
    }

    public class StkComCode
    {
        public string Code { get; set; }
        public string Sto_Desc { get; set; }
    }
}
