using CustomUtils;
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
    public partial class CstInfo : UserControl
    {
        MainViewer main;
        public CstInfo(MainViewer main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void bt_CstInfoSearch_Click(object sender, EventArgs e)
        {
            SearchCstInfo();
            CstEventHistSearch();

            if (ckb_ValidNgHist.Checked == true)
            {
                CstActHistSearch();
            }
            else
            {
                CstActHistSearch();
            }
        }

        private void SearchCstInfo()
        {
            string cstid = latb_CarrierId.Tb_Text;
            //XmlOptionData sqldata = main.sqlList["SearchCstInfo"];
            //DynamicParameters parameters = new DynamicParameters();
            //string cquery = sqldata.Sql;

            //parameters.Add("@CSTID", cstid);

            //new WinformUtils(main).ShowSqltoDGV(dgv_CstInfo.DgvData, cquery, parameters, main.correntConnectionStringSetting);

            try
            {
                XmlOptionData sqldata = main.sqlList["SearchCstInfo2"];
                string cquery = sqldata.Sql;
                string plantId = main.correntConnectionStringSetting.PlantID;
                string systemTypeCode = main.correntConnectionStringSetting.SystemTypeCode;

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@CSTID", cstid);
                List<Carrier> carriers;

                using (var connection = new SqlConnection(main.correntConnectionStringSetting.MssqlConnectionString()))
                {
                    carriers = connection.Query<Carrier>(cquery, parameters).ToList();
                    dgv_CstInfo.DgvData.DataSource = carriers;
                }
                foreach (DataGridViewColumn col in dgv_CstInfo.DgvData.Columns)
                {
                    var prop = typeof(Carrier).GetProperty(col.DataPropertyName);
                    var displayName = prop?.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName;
                    if (displayName != null)
                    {
                        col.HeaderText = displayName;
                    }
                }
                main.AppendLog(cquery, parameters);
                dgv_CstInfo.DgvData.SelectionMode = DataGridViewSelectionMode.CellSelect;
                dgv_CstInfo.DgvData.AutoResizeColumns();

                if (carriers != null)
                {
                    string mismatchMessage = MakeCSTErrMsg(carriers);
                    lb_MismatchMessage.Text = mismatchMessage;
                    if (mismatchMessage == string.Empty)
                    {
                        dgv_CstInfo.DgvData.Rows[0].DefaultCellStyle.BackColor = Color.FromArgb(179, 255, 174);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string MakeCSTErrMsg(List<Carrier> carriers)
        {
            string routid = ""; string dfct = "F"; string scrp = "N";
            if (carriers.Count != 0)
            {
                if (dfct != "Y") { dfct = carriers[0].DFCT_LIMIT_OVER_FLAG; }
                if (routid == "") { routid = carriers[0].ROUTID; }
                if (scrp != "N") { scrp = carriers[0].SCRP_TRAY_FLAG; }

                if (carriers.Count == 2)
                {
                    //--------------------------------------------------------------------------------------------------------------------------------------------------
                    if (carriers[0].CSTSTAT != carriers[1].CSTSTAT ||
                        carriers[0].TRAY_TYPE_CODE != carriers[1].TRAY_TYPE_CODE) // cststat, 트레이 타입
                    {
                        return CSTErrMsg.typeErr;
                    }
                    //--------------------------------------------------------------------------------------------------------------------------------------------------
                    if (carriers[0].DAY_GR_LOTID != carriers[1].DAY_GR_LOTID ||
                        carriers[0].ROUTID != carriers[1].ROUTID ||
                        carriers[0].PROCID != carriers[1].PROCID ||
                        carriers[0].SPCL_FLAG != carriers[1].SPCL_FLAG ||
                        carriers[0].LOTTYPE != carriers[1].LOTTYPE)
                    { return CSTErrMsg.typeErr; }
                }
                //--------------------------------------------------------------------------------------------------------------------------------------------------
                if (carriers[0].SPCL_FLAG == "Y")
                {
                    if (carriers.Count == 2)
                    {
                        if (carriers[0].DAY_GR_LOTID != carriers[1].DAY_GR_LOTID ||
                    carriers[0].ROUTID != carriers[1].ROUTID ||
                    carriers[0].PROCID != carriers[1].PROCID ||
                    carriers[0].SPCL_FLAG != carriers[1].SPCL_FLAG ||
                    carriers[0].LOTTYPE != carriers[1].LOTTYPE ||
                    carriers[0].FORM_SPCL_GR_ID != carriers[1].FORM_SPCL_GR_ID
                    )
                        {
                            return CSTErrMsg.spcCstErr;
                        }
                    }
                }

                if (dfct == "Y")
                {
                    return CSTErrMsg.allCellErr;
                }
                if (scrp == "Y")
                {
                    return CSTErrMsg.crackTrayErr;
                }
            }
            return string.Empty;
        }


        private void CstActHistSearch()
        {
            string cstid = latb_CarrierId.Tb_Text;

            DateTime tomorrow = DateTime.Today.AddDays(1);
            DateTime yesterday = DateTime.Today.AddDays(-1);

            string startDate = yesterday.ToString("yyyy-MM-dd");
            string endDate = tomorrow.ToString("yyyy-MM-dd");

            //int cb_Num = main.cb_Cststat.SelectedIndex;

            try
            {
                if (cstid != string.Empty)
                {
                    XmlOptionData sqldata = main.sqlList["CstActHistSearch"];
                    Dictionary<string, string> parameterDic = new Dictionary<string, string>();
                    string cquery = sqldata.Sql;
                    var parameters = new DynamicParameters();

                    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 1);
                    parameters.Add("@CSTID", string.Concat("%", cstid, "%"));


                    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 2);
                    parameters.Add("@StartDate", startDate);
                    parameters.Add("@EndDate", endDate);

                    new WinformUtils(main).ShowSqltoDGV(dgv_CstActHist.DgvData, cquery, parameters, main.correntConnectionStringSetting);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} : CstActHistSearch");
            }
        }

        private void CstEventHistSearch()
        {
            string cstid = latb_CarrierId.Tb_Text;

            DateTime tomorrow = DateTime.Today.AddDays(1);
            DateTime yesterday = DateTime.Today.AddDays(-1);

            string startDate = yesterday.ToString("yyyy-MM-dd");
            string endDate = tomorrow.ToString("yyyy-MM-dd");

            try
            {
                if (cstid != string.Empty)
                {
                    XmlOptionData sqldata = main.sqlList["CstEventHistSearch"];
                    Dictionary<string, string> parameterDic = new Dictionary<string, string>();
                    string cquery = sqldata.Sql;
                    var parameters = new DynamicParameters();

                    parameters.Add("@StartDate", startDate);
                    parameters.Add("@EndDate", endDate);

                    parameters.Add("@CSTID", string.Concat("%", cstid, "%"));

                    new WinformUtils(main).ShowSqltoDGV(dgv_CstHist.DgvData, cquery, parameters, main.correntConnectionStringSetting);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} : CstEventHistSearch");
            }
        }
    }

    public class Carrier {
        [DisplayName("CSTID")]
        public string CSTID { get; set; }
        [DisplayName("CSTSTAT")]
        public string CSTSTAT { get; set; }
        [DisplayName("대표CST")]
        public string LOAD_REP_CSTID { get; set; }
        [DisplayName("단")]
        public int CST_LOAD_LOCATION_CODE { get; set; }
        public string CURR_RACK_ID { get; set; }
        public string CURR_LOTID { get; set; }
        public string ABNORM_TRF_RSN_CODE { get; set; }
        public string EQPT_CUR { get; set; }
        public string PORT_CUR { get; set; }
        public string ROUTID { get; set; }
        public string WIPSTAT { get; set; }
        public string LOTTYPE { get; set; }
        public string DAY_GR_LOTID { get; set; }
        public string SPCL_FLAG { get; set; }
        public string SMPL_ISS_TYPE_CODE { get; set; }
        public string LOT_DETL_TYPE_CODE { get; set; }
        public string DFCT_LIMIT_OVER_FLAG { get; set; }
        public string SPCL_NOTE { get; set; }
        public string FORM_SPCL_GR_ID { get; set; }
        public string PROCID { get; set; }
        public string TRAY_TYPE_CODE { get; set; }
        public DateTime UPDDTTM { get; set; }
        public string DFCT_OCCR_EQPTID { get; set; }
        public DateTime AGING_ISS_SCHD_DTTM { get; set; }
        public string SCRP_TRAY_FLAG { get; set; }
        public string TRAY_CNVR_BCR_SCAN_COUNT { get; set; }
    }
}
