using Dapper;
using DBManagemnet;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
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
    public partial class EquipmentCurrentState : UserControl
    {

        #region Variable

        MainViewer main;
        #endregion

        #region Construction
        public EquipmentCurrentState(MainViewer main)
        {
            InitializeComponent();
            this.main = main;
            SearchEquipmentGroupList();
            dgv_EquipmentCurrentState.DgvData.CellClick += SearchPortCurrentState;
            dgv_EquipmentEioHist.DgvData.CellClick += SearchPortStateHistory;
            dgv_EquipmentEioHist.DgvData.CellDoubleClick += SearchPortEioHistory;
        }
        #endregion

        #region Events for UI Controls
        private void DgvData_CellValidated(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                dgv_EquipmentEioHist.DgvData.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.HotPink;
            }
        }
        private void SearchPortCurrentState(object? sender, DataGridViewCellEventArgs e)
        {
            try
            {
                WinformUtils winformUtils = new WinformUtils(main);
                string eqptId = (sender as DataGridView).CurrentRow.Cells["EQPTID"].Value.ToString();
                string eqgrId = (sender as DataGridView).CurrentRow.Cells["EQGRID"].Value.ToString();

                Dictionary<string, string> paramaterDic = new Dictionary<string, string>();
                string areaID = main.correntConnectionStringSetting.AreaID;

                paramaterDic.Add("EQPTID", eqptId);
                paramaterDic.Add("EQGRID", "%%");
                paramaterDic.Add("AREA_ID", areaID);

                winformUtils.ExcuteSql(paramaterDic, dgv_EquipmentEioHist.DgvData, main.correntConnectionStringSetting, MethodBase.GetCurrentMethod().Name);

                //  winformUtils.DataGridView_EioColoring(dgv_PortState.DgvData);
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void SearchPortStateHistory(object? sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string port_Id = (sender as DataGridView).CurrentRow.Cells["PORT_ID"].Value.ToString();
                //string eqgrId = (sender as DataGridView).CurrentRow.Cells["EQGRID"].Value.ToString();

                Dictionary<string, string> paramaterDic = new Dictionary<string, string>();
                string areaID = main.correntConnectionStringSetting.AreaID;

                paramaterDic.Add("PORT_ID", @$"'%{port_Id}%'");

                new WinformUtils(main).ExcuteSql(paramaterDic, dgv_EquipmentStateHist.DgvData, main.correntConnectionStringSetting, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SearchPortEioHistory(object? sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string port_Id = (sender as DataGridView).CurrentRow.Cells["PORT_ID"].Value.ToString();
                //string eqgrId = (sender as DataGridView).CurrentRow.Cells["EQGRID"].Value.ToString();

                Dictionary<string, string> paramaterDic = new Dictionary<string, string>();
                string areaID = main.correntConnectionStringSetting.AreaID;

                paramaterDic.Add("PORT_ID", @$"'%{port_Id}%'");

                new WinformUtils(main).ExcuteSql(paramaterDic, dgv_EquipmentStateHist.DgvData, main.correntConnectionStringSetting, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void bt_EqpStateSearch_Click(object sender, EventArgs e)
        {
            SearchEquipmentCurrentState();
        }

        private void SearchEquipmentCurrentState()
        {
            WinformUtils winformUtils = new WinformUtils(main);
            Dictionary<string, string> paramaterDic = new Dictionary<string, string>();
            string _EQP_GROUP_LIST = MakeEqpGroup();
            string areaID = main.correntConnectionStringSetting.AreaID;
            paramaterDic.Add("EQP_GROUP_ID_LIST", _EQP_GROUP_LIST);
            paramaterDic.Add("AREA_ID", @$"'{areaID}%'");

            winformUtils.ExcuteSql(paramaterDic, dgv_EquipmentCurrentState.DgvData, main.correntConnectionStringSetting, MethodBase.GetCurrentMethod().Name);
        }


        private void bt_GetEqpGroup_Click(object sender, EventArgs e)
        {
            SearchEquipmentGroupList();
        }

        #endregion

        #region Utilities for Ui
        private string MakeEqpGroup()
        {
            string CmdStatCodeList = string.Empty;

            foreach (var item in this.clb_EqpGroupList.CheckedItems)
            {
                if (CmdStatCodeList == string.Empty)
                {
                    CmdStatCodeList += @$"'{item}'";
                }
                else
                {
                    CmdStatCodeList += @$",'{item}'";
                }
            }
            return CmdStatCodeList;
        }
        #endregion

        #region Assign SqlData to DataGrid view functuons Section 
        private void SearchEquipmentGroupList()
        {
            try
            {
                if (!main.correntConnectionStringSetting.IsConnection)
                {
                    return;
                }
                clb_EqpGroupList.Items.Clear();
                string methodName = MethodBase.GetCurrentMethod().Name;
                XmlOptionData sqldata = main.sqlList[methodName];
                string cquery = sqldata.Sql;
                string plantId = main.correntConnectionStringSetting.PlantID;
                string systemTypeCode = main.correntConnectionStringSetting.SystemTypeCode;

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add($"@PLANT_ID", @$"{plantId}%");
                //parameters.Add($"@SYSTEM_TYPE_CODE", systemTypeCode);

                using (var connection = new SqlConnection(main.correntConnectionStringSetting.MssqlConnectionString()))
                {
                    List<GetEQGRID> getEQGRID = connection.Query<GetEQGRID>(cquery, parameters).ToList();

                    foreach (var item in getEQGRID)
                    {
                        clb_EqpGroupList.Items.Add(item.EQGRID);
                    }

                    main.AppendLog(cquery, parameters);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
