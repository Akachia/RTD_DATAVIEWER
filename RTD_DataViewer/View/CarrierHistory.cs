using Dapper;
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
    public partial class CarrierHistory : UserControl
    {
        MainViewer main;

        public CarrierHistory(MainViewer main)
        {
            InitializeComponent();
            this.main = main;

            DateTime tomorrow = DateTime.Today.AddDays(1);
            DateTime yesterday = DateTime.Today.AddDays(-1);

            lAdtp_CstHist_EndDate.Dtp_Value = tomorrow;
            lAdtp_CstHist_StartDate.Dtp_Value = yesterday;
            lAdtp_CstHist_EndDate.IsChecked = false;
            lAdtp_CstHist_StartDate.IsChecked = true;
        }

        private void SearchCstInfo(object? sender, DataGridViewCellEventArgs e)
        {
            XmlOptionData sqldata = main.sqlList["SearchCstInfo"];
            DynamicParameters parameters = new DynamicParameters();
            string cquery = string.Empty;
            WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 16);

            //DataGridView dataGrid = sender as DataGridView;

            string trf_Code = (sender as DataGridView).CurrentRow.Cells["TRF_CODE"].Value.ToString();

            parameters.Add("@TRF_CODE", trf_Code);

            // new WinformUtils(main).ShowSqltoDGV(main.transList_CstHist.DgvData, cquery, parameters, main.correntConnectionStringSetting);

            main.AppendLog(cquery, parameters);
        }

        internal void Btn_Click()
        {
            bool isTrayActHist = rb_IsTrayActHist.Checked;
            bool isEventHist = rb_IsEventHist.Checked;

            if (isTrayActHist == true)
            {
                CstActHistSearch();
            }
            else if (isEventHist == true)
            {
                CstEventHistSearch();
            }
        }

        private void CstActHistSearch()
        {
            string cstid = lAtb_CstHist_CarrierId.Tb_Text;
            string toPortId = lAtb_CstHist_ToPort.Tb_Text;

            string startDate;
            string endDate; ;
            if (lAdtp_CstHist_EndDate.IsChecked)
            {
                endDate = lAdtp_CstHist_EndDate.Dtp_Value.ToString("yyyy-MM-dd");
            }
            else
            {
                lAdtp_CstHist_EndDate.Dtp_Value = DateTime.Now;
                endDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }

            if (lAdtp_CstHist_StartDate.IsChecked)
            {
                startDate = lAdtp_CstHist_StartDate.Dtp_Value.ToString("yyyy-MM-dd");
            }
            else
            {
                lAdtp_CstHist_StartDate.Dtp_Value = DateTime.Today.AddDays(-1);
                startDate = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss");
            }

            //int cb_Num = main.cb_Cststat.SelectedIndex;

            try
            {
                Dictionary<string, string> paramaterDic = new Dictionary<string, string>();

                paramaterDic.Add("PORTID", toPortId);
                paramaterDic.Add("CSTID", cstid);
                paramaterDic.Add("StartDate", $"'{startDate}'");
                paramaterDic.Add("EndDate", $"'{endDate}'");

                new WinformUtils(main).ExcuteSql(paramaterDic, dgv_CarrierHistory.DgvData, main.correntConnectionStringSetting, MethodBase.GetCurrentMethod().Name);


                //XmlOptionData sqldata = main.sqlList["CstActHistSearch"];
                //string cquery = sqldata.Sql;
                //var parameters = new DynamicParameters();

                //if (toPortId != string.Empty)
                //{
                //    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 0);
                //    parameters.Add("@PORTID", string.Concat("%", toPortId, "%"));
                //}

                //if (cstid != string.Empty)
                //{
                //    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 1);
                //    parameters.Add("@CSTID", string.Concat("%", cstid, "%"));
                //}

                //WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 2);
                //parameters.Add("@StartDate", startDate);
                //parameters.Add("@EndDate", endDate);

                //new WinformUtils(main).ShowSqltoDGV(cstHist_Dgv.DgvData, cquery, parameters, main.correntConnectionStringSetting);

                //main.AppendLog(cquery, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} : CstActHistSearch");
            }
        }

        private void CstEventHistSearch()
        {
            string cstid = lAtb_CstHist_CarrierId.Tb_Text;
            string toEqpId = lAtb_CstHist_ToPort.Tb_Text;

            string endDate = lAdtp_CstHist_EndDate.MakeNowDateStringAndSetting();
            string startDate = lAdtp_CstHist_StartDate.MakeNowDateStringAndSetting();

            try
            {

                Dictionary<string, string> paramaterDic = new Dictionary<string, string>();

                paramaterDic.Add("CSTID", $"'{cstid}'");
                paramaterDic.Add("StartDate", $"'{startDate}'");
                paramaterDic.Add("EndDate", $"'{endDate}'");

                new WinformUtils(main).ExcuteSql(paramaterDic, dgv_CarrierHistory.DgvData, main.correntConnectionStringSetting, MethodBase.GetCurrentMethod().Name);

                //XmlOptionData sqldata = main.sqlList["CstEventHistSearch"];
                //Dictionary<string, string> parameterDic = new Dictionary<string, string>();
                //string cquery = sqldata.Sql;
                //var parameters = new DynamicParameters();

                //parameters.Add("@StartDate", startDate);
                //parameters.Add("@EndDate", endDate);

                //parameters.Add("@CSTID", string.Concat("%", cstid, "%"));

                //new WinformUtils(main).ShowSqltoDGV(cstHist_Dgv.DgvData, cquery, parameters, main.correntConnectionStringSetting);

               // main.AppendLog(cquery, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} : CstEventHistSearch");
            }
        }

        private void bt_CstHist_Search_Click(object sender, EventArgs e)
        {
            Btn_Click();
        }
    }
}
