using CustomUtils;
using Dapper;
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
            string errMsg = string.Empty;
            new WinformUtils(main).SearchCstInfo(dgv_CstInfo.DgvData, latb_CarrierId.Tb_Text, ref errMsg);


            lb_MismatchMessage.Text = errMsg;

            //string cstid = latb_CarrierId.Tb_Text;
            ////XmlOptionData sqldata = main.sqlList["SearchCstInfo"];
            ////DynamicParameters parameters = new DynamicParameters();
            ////string cquery = sqldata.Sql;

            ////parameters.Add("@CSTID", cstid);

            ////new WinformUtils(main).ShowSqltoDGV(dgv_CstInfo.DgvData, cquery, parameters, main.correntConnectionStringSetting);

            //try
            //{
            //    XmlOptionData sqldata = main.sqlList["SearchCstInfo2"];
            //    string cquery = sqldata.Sql;
            //    string plantId = main.correntConnectionStringSetting.PlantID;
            //    string systemTypeCode = main.correntConnectionStringSetting.SystemTypeCode;

            //    DynamicParameters parameters = new DynamicParameters();
            //    if (cstid == string.Empty)
            //    {
            //        MessageBox.Show("CSTID를 입력해주세요.");
            //        return;
            //    }
            //    parameters.Add("@CSTID", cstid);
            //    List<Carrier> carriers;

            //    if (main.correntConnectionStringSetting.DatabaseProvider == "ORACLE")
            //    {

            //        string testcquery = "SELECT * FROM AKACHISCHEMA.CARRIER";

            //        dgv_CstInfo.DgvData.DataSource = null;
            //        dgv_CstInfo.DgvData.Rows.Clear();
            //        dgv_CstInfo.DgvData.Columns.Clear();
            //         // dgv_CstInfo.DgvData.RowPostPaint -= DataGridView_RowPostPaint;
            //        using (var connection = new OracleConnection(main.correntConnectionStringSetting.ConnectionString()))
            //        {
            //            if (parameters != null)
            //            {
            //                dgv_CstInfo.DgvData.DataSource = connection.Query(testcquery, parameters).ToList();
            //                main.AppendLog(cquery, parameters);
            //            }
            //            else
            //            {
            //                dgv_CstInfo.DgvData.DataSource = connection.Query(testcquery).ToList();
            //                main.AppendLog(cquery);
            //            }
            //        }
            //        dgv_CstInfo.DgvData.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Gray;

            //        dgv_CstInfo.DgvData.SelectionMode = DataGridViewSelectionMode.CellSelect;
            //        dgv_CstInfo.DgvData.AutoResizeColumns();

            //        //    dgv_CstInfo.DgvData.RowPostPaint += DataGridView_RowPostPaint;
            //        foreach (DataGridViewRow item in dgv_CstInfo.DgvData.Rows)
            //        {
            //            item.DefaultCellStyle.BackColor = Color.FromArgb(179, 255, 174);
            //        }
            //        return;
            //    }

            //    using (var connection = new SqlConnection(main.correntConnectionStringSetting.MssqlConnectionString()))
            //    {
            //        carriers = connection.Query<Carrier>(cquery, parameters).ToList();
            //        dgv_CstInfo.DgvData.DataSource = carriers;
            //    }
            //    foreach (DataGridViewColumn col in dgv_CstInfo.DgvData.Columns)
            //    {
            //        var prop = typeof(Carrier).GetProperty(col.DataPropertyName);
            //        var displayName = prop?.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName;
            //        if (displayName != null)
            //        {
            //            col.HeaderText = displayName;
            //        }
            //    }
            //    main.AppendLog(cquery, parameters);
            //    dgv_CstInfo.DgvData.SelectionMode = DataGridViewSelectionMode.CellSelect;
            //    dgv_CstInfo.DgvData.AutoResizeColumns();

            //    if (carriers != null)
            //    {
            //        string mismatchMessage = MakeCSTErrMsg(carriers);
            //        lb_MismatchMessage.Text = mismatchMessage;
            //        if (mismatchMessage == string.Empty)
            //        {
            //            foreach (DataGridViewRow item in dgv_CstInfo.DgvData.Rows)
            //            {
            //                item.DefaultCellStyle.BackColor = Color.FromArgb(179, 255, 174);
            //            }
            //        }
            //        else
            //        {
            //            int rowCount = 0;
            //            lb_MismatchMessage.BackColor = Color.FromArgb(255, 155, 155);
            //            foreach (DataGridViewRow item in dgv_CstInfo.DgvData.Rows)
            //            {
            //                if (rowCount == 0)
            //                {
            //                    item.DefaultCellStyle.BackColor = Color.FromArgb(179, 255, 174);
            //                    rowCount++;
            //                }
            //                else
            //                {
            //                    item.DefaultCellStyle.BackColor = Color.FromArgb(255, 214, 165);
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }


        private void CstActHistSearch()
        {
            string cstid = latb_CarrierId.Tb_Text;
            string portid = latb_CarrierId.Tb_Text;

            DateTime tomorrow = DateTime.Today.AddDays(1);
            DateTime yesterday = DateTime.Today.AddDays(-1);

            string startDate = yesterday.ToString("yyyy-MM-dd");
            string endDate = tomorrow.ToString("yyyy-MM-dd");

            //int cb_Num = main.cb_Cststat.SelectedIndex;

            try
            {
                if (cstid != string.Empty)
                {

                    Dictionary<string, string> paramaterDic = new Dictionary<string, string>();
                    paramaterDic.Add("CSTID", cstid);
                    paramaterDic.Add("PORTID", portid);
                    paramaterDic.Add("StartDate", $"'{startDate}'");
                    paramaterDic.Add("EndDate", $"'{endDate}'");


                    new WinformUtils(main).ExcuteSql(paramaterDic, dgv_CstActHist.DgvData, main.correntConnectionStringSetting, MethodBase.GetCurrentMethod().Name);

                    //XmlOptionData sqldata = main.sqlList["CstActHistSearch"];
                    //Dictionary<string, string> parameterDic = new Dictionary<string, string>();
                    //string cquery = sqldata.Sql;
                    //var parameters = new DynamicParameters();

                    //WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 1);
                    //parameters.Add("@CSTID", string.Concat("%", cstid, "%"));


                    //WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 2);
                    //parameters.Add("@StartDate", startDate);
                    //parameters.Add("@EndDate", endDate);

                    //new WinformUtils(main).ShowSqltoDGV(dgv_CstActHist.DgvData, cquery, parameters, main.correntConnectionStringSetting);
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
}
