using Dapper;
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
    public partial class StockerInventory : UserControl
    {
        MainViewer main;
        Dictionary<string, string> stkComCodeList;
        public StockerInventory(MainViewer main)
        {
            InitializeComponent();
            this.main = main;
            SearchStkComCode();
            FillComboBox();
            cb_Cststat.SelectedIndex = 0;
        }

        private void SearchStkComCode()
        {
            try
            {
                if (main.correntConnectionStringSetting.DatabaseProvider == "ORACLE")
                {
                    return;
                }
                XmlOptionData sqldata = main.sqlList["SearchStkComCode"];
                string cquery = sqldata.Sql;
                string plantId = main.correntConnectionStringSetting.PlantID;
                string systemTypeCode = main.correntConnectionStringSetting.SystemTypeCode;

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add($"@PLANT_ID", @$"{plantId}%");
                parameters.Add($"@SYSTEM_TYPE_CODE", systemTypeCode);

                using (var connection = new SqlConnection(main.correntConnectionStringSetting.MssqlConnectionString()))
                {
                    List<StkComCode> stkComCodes = connection.Query<StkComCode>(cquery, parameters).ToList();
                    stkComCodeList = new Dictionary<string, string>();
                    foreach (var stkComCode in stkComCodes)
                    {
                        stkComCodeList.Add(stkComCode.Sto_Desc, stkComCode.Code);
                    }

                    main.AppendLog(cquery, parameters);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void FillComboBox()
        {
            if (main.correntConnectionStringSetting.DatabaseProvider == "ORACLE")
            {
                return;
            }
            foreach (var item in stkComCodeList)
            {
                cb_StockerGroupList.Items.Add(item.Key);
            }

            cb_StockerGroupList.SelectedIndex = 0;
        }

        private void SearchStkInventory()
        {
            Dictionary<string, string> paramaterDic = new Dictionary<string, string>();

            string plantId = main.correntConnectionStringSetting.PlantID;
            string stoCode = stkComCodeList[cb_StockerGroupList.Text];

            paramaterDic.Add("PLANT_ID", $"'{plantId}'");
            paramaterDic.Add("STO_CODE", $"'{stoCode}'");
            paramaterDic.Add("CstStat", $"{cb_Cststat.SelectedIndex}");

            new WinformUtils(main).ExcuteSql(paramaterDic, dgv_StoInventory, main.correntConnectionStringSetting, MethodBase.GetCurrentMethod().Name);


            DateTime date1 = DateTime.Now;

            int rowCount = dgv_StoInventory.RowCount;

            foreach (DataGridViewRow row in dgv_StoInventory.Rows)
            {
                row.Cells["AGING_ISS_SCHD_DTTM"].Style.BackColor = Color.FromArgb(222, 245, 229); // 색상 변경
            }

            for (int i = 0; i < rowCount; i++)
            {
                try
                {
                    string agingDttm = dgv_StoInventory.Rows[i].Cells["AGING_ISS_SCHD_DTTM"].Value.ToString();
                    string trf_Stat_Code = dgv_StoInventory.Rows[i].Cells["TRF_STAT_CODE"].Value.ToString();

                    if (agingDttm != string.Empty)
                    {
                        DateTime dateTime = DateTime.Parse(agingDttm);

                        if (dateTime < date1)
                        {
                            //FFD4D4
                            dgv_StoInventory.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 212, 212);
                        }
                    }

                    if (trf_Stat_Code != string.Empty)
                    {
                        if (trf_Stat_Code == "RESERVED")
                        {
                            //F8FFDB
                            dgv_StoInventory.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(248, 255, 219);
                        }
                        if (trf_Stat_Code == "MOVING")
                        {
                            //B3FFAE
                            dgv_StoInventory.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(179, 255, 174);
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
        private void SearchStockerCurrState()
        {
            WinformUtils winformUtils = new WinformUtils(main);
            Dictionary<string, string> paramaterDic = new Dictionary<string, string>();

            string plantId = main.correntConnectionStringSetting.PlantID;
            string stoCode = stkComCodeList[cb_StockerGroupList.Text];
            string systemTypeCode = main.correntConnectionStringSetting.SystemTypeCode;

            paramaterDic.Add("STO_CODE", $"'{stoCode}'");
            paramaterDic.Add("PLANT_ID", @$"'{plantId}%'");
            paramaterDic.Add("SYSTEM_TYPE_CODE", $"'{systemTypeCode}'");

            winformUtils.ExcuteSql(paramaterDic, dgv_StoStatus, main.correntConnectionStringSetting, MethodBase.GetCurrentMethod().Name);
            //winformUtils.DataGridView_EioColoring(dgv_StoStatus);
        }

        private void bt_Search_Click(object sender, EventArgs e)
        {
            SearchStkInventory();
            SearchStockerCurrState();
        }
    }

    public class StkComCode
    {
        public string Code { get; set; }
        public string Sto_Desc { get; set; }
    }
}
