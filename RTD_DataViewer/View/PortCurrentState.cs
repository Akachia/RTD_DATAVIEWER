using CustomUtills;
using Dapper;
using DBManagement;
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
    public partial class PortCurrentState : UserControl
    {

        #region Variable
        WinformUtils winformUtils;
        DefaultSqlData? SearchPortCurrentListData = null;
        DefaultSqlData? SearchPortEioRecordData = null;
        DefaultSqlData? SearchPortStateRecordData = null;
        CommonCodeData? SearchCommonCodeData = null;
        Dictionary<string, string>? eventCallVal = null;
        Dictionary<string, string>? stkComCodeList = null;
        List<Control>? variableControls = new List<Control>();
        #endregion

        #region Construction
        public PortCurrentState(MainViewer main)
        {
            InitializeComponent();
            //SearchEquipmentGroupList();
           // dgv_EquipmentCurrentState.DgvData.CellClick += SearchPortCurrentState;
            dgv_PortCurrentList.DgvData.CellClick += SearchPortHistory;

            foreach (Control control in this.Controls[0].Controls)
            {
                if (control is UserControl)
                {
                    variableControls.Add(control);
                }
            }

            winformUtils = new(main);
            this.lb_EqpGroupList.ListBox.SelectedValueChanged += ListBox_SelectedValueChanged;
        }
        #endregion

        #region Events for UI Controls
        private void bt_EqpStateSearch_Click(object sender, EventArgs e)
        {
            SearchPortCurrentList();
        }
        private void bt_GetEqpGroup_Click(object sender, EventArgs e)
        {
            SearchEquipmentGroupList();
        }
        private void ListBox_SelectedValueChanged(object? sender, EventArgs e)
        {
            ListBox listBox = sender as ListBox;

            SearchEquipmentList(listBox.SelectedItem.ToString());
        }
        #endregion

        #region Utilities for Ui
        private string MakeEqpGroup()
        {
            string CmdStatCodeList = string.Empty;

            foreach (var item in this.clb_EquipmentList.CheckedItem)
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

        private void SearchPortCurrentList()
        {
            Dictionary<string, string> paramaterDic = new Dictionary<string, string>();
            string methodName = MethodBase.GetCurrentMethod().Name;
            string _EQP_GROUP_LIST = MakeEqpGroup();
            paramaterDic.Add("EQPTID_LIST", _EQP_GROUP_LIST);
        //    paramaterDic.Add("SYSTEM_TYPE_CODE", winformUtils.main.correntConnectionStringSetting.SystemTypeCode);

            SearchPortCurrentListData = winformUtils.ShowDgv(
                methodName,
                dgv_PortCurrentList, 
                SearchPortCurrentListData, 
                paramaterDic) as DefaultSqlData;
        }

        private void SearchPortHistory(object? sender, DataGridViewCellEventArgs e)
        {

            string port_Id = (sender as DataGridView).CurrentRow.Cells["PORT_ID"].Value.ToString();
            SearchPortStateRecord(port_Id);
            SearchPortEioRecord(port_Id);
        }

        private void SearchPortStateRecord(string portId)
        {
            try
            {
                string methodName = MethodBase.GetCurrentMethod().Name;
                Dictionary<string, string> paramaterDic = new Dictionary<string, string>();
                paramaterDic.Add("PORT_ID", @$"'%{portId}%'");

                SearchPortStateRecordData = winformUtils.ShowDgv(
                      methodName,
                      dgv_PortStateRecord,
                      SearchPortStateRecordData,
                      paramaterDic) as DefaultSqlData;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SearchPortEioRecord(string portId)
        {
            try
            {
                string methodName = MethodBase.GetCurrentMethod().Name;
                Dictionary<string, string> paramaterDic = new Dictionary<string, string>();

                paramaterDic.Add("PORT_ID", @$"'%{portId}%'");

                SearchPortEioRecordData = winformUtils.ShowDgv(
                    methodName, 
                    dgv_PortEioRecord,
                    SearchPortEioRecordData,
                    paramaterDic) as DefaultSqlData;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SearchEquipmentList(string EquipmentGroupName)
        {
            try
            {
                string methodName = MethodBase.GetCurrentMethod().Name;
                Dictionary<string, string> paramaterDic = new Dictionary<string, string>();
                paramaterDic.Add($"EQP_GROUP_ID_LIST", EquipmentGroupName);
                SearchCommonCodeData = winformUtils.GetCommonCodes(methodName, clb_EquipmentList, SearchCommonCodeData, paramaterDic);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void SearchEquipmentGroupList()
        {
            try
            {
                string methodName = MethodBase.GetCurrentMethod().Name;
                SearchCommonCodeData = winformUtils.GetCommonCodes(methodName, lb_EqpGroupList, SearchCommonCodeData);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
