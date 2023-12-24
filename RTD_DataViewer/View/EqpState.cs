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
    public partial class EqpState : UserControl
    {
        MainViewer main;
        public EqpState(MainViewer main)
        {
            InitializeComponent();
            this.main = main;
            SearchEqpGroup();
            dgv_EqpState.DgvData.CellClick += SearchPortState;
            dgv_PortState.DgvData.CellClick += SearchPortStateHist;
            dgv_PortState.DgvData.CellDoubleClick += SearchPortEioHist;
        }

        private void DgvData_CellValidated(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                dgv_PortState.DgvData.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.HotPink;
            }
        }

        private void SearchPortState(object? sender, DataGridViewCellEventArgs e)
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

                winformUtils.ExcuteSql(paramaterDic, dgv_PortState.DgvData, main.correntConnectionStringSetting, MethodBase.GetCurrentMethod().Name);

                winformUtils.DataGridView_EioColoring(dgv_PortState.DgvData);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SearchPortStateHist(object? sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string port_Id = (sender as DataGridView).CurrentRow.Cells["PORT_ID"].Value.ToString();
                //string eqgrId = (sender as DataGridView).CurrentRow.Cells["EQGRID"].Value.ToString();

                Dictionary<string, string> paramaterDic = new Dictionary<string, string>();
                string areaID = main.correntConnectionStringSetting.AreaID;

                paramaterDic.Add("PORT_ID", @$"'%{port_Id}%'");

                new WinformUtils(main).ExcuteSql(paramaterDic, dgv_PortStateHist.DgvData, main.correntConnectionStringSetting, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SearchPortEioHist(object? sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string port_Id = (sender as DataGridView).CurrentRow.Cells["PORT_ID"].Value.ToString();
                //string eqgrId = (sender as DataGridView).CurrentRow.Cells["EQGRID"].Value.ToString();

                Dictionary<string, string> paramaterDic = new Dictionary<string, string>();
                string areaID = main.correntConnectionStringSetting.AreaID;

                paramaterDic.Add("PORT_ID", @$"'%{port_Id}%'");

                new WinformUtils(main).ExcuteSql(paramaterDic, dgv_PortStateHist.DgvData, main.correntConnectionStringSetting, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 	<AreaID>EO</AreaID>
        ///     <PlantID>U2</PlantID>
        /// </summary>
        private void SearchEqpGroup()
        {
            try
            {
                clb_EqpGroupList.Items.Clear();
                XmlOptionData sqldata = main.sqlList["SearchEqpGroup"];
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

        private void bt_EqpStateSearch_Click(object sender, EventArgs e)
        {
            SearchEqpState();
        }

        private void SearchEqpState()
        {
            WinformUtils winformUtils = new WinformUtils(main);
            Dictionary<string, string> paramaterDic = new Dictionary<string, string>();
            string _EQP_GROUP_LIST = MakeEqpGroup();
            string areaID = main.correntConnectionStringSetting.AreaID;
            paramaterDic.Add("EQP_GROUP_ID_LIST", _EQP_GROUP_LIST);
            paramaterDic.Add("AREA_ID", @$"'{areaID}%'");

            winformUtils.ExcuteSql(paramaterDic, dgv_EqpState.DgvData, main.correntConnectionStringSetting, MethodBase.GetCurrentMethod().Name);

            int columnCount = dgv_EqpState.DgvData.Columns.Count;
            winformUtils.DataGridView_EioColoring(dgv_EqpState.DgvData);
        }


        private void bt_GetEqpGroup_Click(object sender, EventArgs e)
        {
            SearchEqpGroup();
        }
    }

    public class GetEQGRID
    {
        public string EQGRID { get; set; }
    }
}
