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
    public partial class EquipmentCurrentState : UserControl
    {
        WinformUtils? winformUtils = null;
        DefaultSqlData? sarchEquipmentStateHistoryData = null;
        DefaultSqlData? searchEquipmentEioHistoryData = null;
        DefaultSqlData? searchEquipmentCurrentStateData = null;
        CommonCodeData? SearchCommonCodeData = null;
        List<Control>? variableControls = new List<Control>();
        public EquipmentCurrentState(MainViewer main)
        {
            InitializeComponent();
            dgv_EquipmentCurrentState.DgvData.CellClick += EquipmentStateHistory;


            foreach (Control control in this.Controls[0].Controls)
            {
                if (control is UserControl)
                {
                    variableControls.Add(control);
                }
            }
            winformUtils = new(main);
        }

        private void EquipmentStateHistory(object? sender, DataGridViewCellEventArgs e)
        {
            string eqpt_Id = (sender as DataGridView).CurrentRow.Cells["EQPTID"].Value.ToString();
            SearchEquipmentStateHistory(eqpt_Id);
            SearchEquipmentEioHistory(eqpt_Id);
        }

            private void SearchEquipmentStateHistory(string eqpt_id)
        {
            Dictionary<string, string> paramaterDic = new Dictionary<string, string>();
            string methodName = MethodBase.GetCurrentMethod().Name;
            string _EQP_GROUP_LIST = MakeEqpGroup();
            paramaterDic.Add("TOPNUMBER", "40");
            paramaterDic.Add("EQPT_ID", eqpt_id);
            sarchEquipmentStateHistoryData = winformUtils.ShowDgv(
                methodName,
                dgv_EquipmentStateHistory,
                sarchEquipmentStateHistoryData,
                paramaterDic) as DefaultSqlData;
        }

        private void SearchEquipmentEioHistory(string eqpt_id)
        {
            Dictionary<string, string> paramaterDic = new Dictionary<string, string>();
            string methodName = MethodBase.GetCurrentMethod().Name;
            paramaterDic.Add("TOPNUMBER", "40");
            paramaterDic.Add("EQPT_ID", eqpt_id);
            searchEquipmentEioHistoryData = winformUtils.ShowDgv(
                methodName,
                dgv_EquipmentEioHistory,
                searchEquipmentEioHistoryData,
                paramaterDic) as DefaultSqlData;
        }

        /// <summary>
        /// 	<AreaID>EO</AreaID>
        ///     <PlantID>U2</PlantID>
        /// </summary>
        private void SearchEquipmentGroupList()
        {
            try
            {
                string methodName = MethodBase.GetCurrentMethod().Name;
                SearchCommonCodeData = winformUtils.GetCommonCodes(methodName, clb_EquipmentGroupList, SearchCommonCodeData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string MakeEqpGroup()
        {
            string CmdStatCodeList = string.Empty;

            foreach (var item in this.clb_EquipmentGroupList.CheckedItem)
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

        private void bt_EqpStateSearch_Click(object sender, EventArgs e)
        {
            SearchEquipmentCurrentState();
        }

        private void SearchEquipmentCurrentState()
        {
            Dictionary<string, string> paramaterDic = new Dictionary<string, string>();
            string methodName = MethodBase.GetCurrentMethod().Name;
            string _EQP_GROUP_LIST = MakeEqpGroup();
            paramaterDic.Add("EQP_GROUP_ID_LIST", _EQP_GROUP_LIST);
          //  paramaterDic.Add("AREA_ID", @$"'{winformUtils.correntConnectionStringSetting.AreaID}%'");
          //  paramaterDic.Add("SYSTEM_TYPE_CODE", winformUtils.main.correntConnectionStringSetting.SystemTypeCode);

            searchEquipmentCurrentStateData = winformUtils.ShowDgv(
                methodName,
                dgv_EquipmentCurrentState,
                searchEquipmentCurrentStateData,
                paramaterDic) as DefaultSqlData;

        }


        private void bt_GetEqpGroup_Click(object sender, EventArgs e)
        {
            SearchEquipmentGroupList();
        }
    }
}
