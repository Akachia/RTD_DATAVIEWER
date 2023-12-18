using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            else {
                CstActHistSearch();
            }
        }

        private void SearchCstInfo()
        {
            string cstid = latb_CarrierId.Tb_Text;
            XmlOptionData sqldata = main.sqlList["SearchCstInfo"];
            DynamicParameters parameters = new DynamicParameters();
            string cquery = sqldata.Sql;

            parameters.Add("@CSTID", cstid);

            new WinformUtils().ShowSqltoDGV(dgv_CstInfo.DgvData, cquery, parameters, main.correntConnectionStringSetting);

            main.AppendLog(cquery, "@CSTID", cstid);
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

                    main.AppendLog(cquery, parameters);
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

                    main.AppendLog(cquery, parameters);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} : CstEventHistSearch");
            }
        }

    }
}
