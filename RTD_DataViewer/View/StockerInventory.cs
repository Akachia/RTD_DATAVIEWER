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
        }

        private void SearchStkComCode()
        {
            try
            {
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

            new WinformUtils(main).ExcuteSql(paramaterDic, dgv_StoInventory.DgvData, main.correntConnectionStringSetting, MethodBase.GetCurrentMethod().Name);


            DateTime date1 = DateTime.Now;

            int rowCount = dgv_StoInventory.DgvData.RowCount - 1;

            for (int i = 0; i < rowCount; i++)
            {
                string agingDttm = dgv_StoInventory.DgvData.Rows[i].Cells["AGING_ISS_SCHD_DTTM"].Value.ToString();

                if (agingDttm != string.Empty)
                {
                    DateTime dateTime = DateTime.Parse(agingDttm);

                    if (dateTime > date1)
                    {
                        dgv_StoInventory.DgvData.Rows[i].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                    }
                }

            }
        }

        private void bt_Search_Click(object sender, EventArgs e)
        {
            SearchStkInventory();
        }
    }

    public class StkComCode
    {
        public string Code { get; set; }
        public string Sto_Desc { get; set; }
    }
}
