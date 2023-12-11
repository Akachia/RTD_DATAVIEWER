using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlManagement;

namespace RTD_DataViewer.FromUtills
{
    internal class CstHist
    {
        MainViewer main;
        int currNum = 0;
        public CstHist(MainViewer main)
        {
            this.main = main;
            InitControlText(main);
        }

        public void InitControlText(MainViewer main)
        {
            main.transList_dgvReq.DgvData.CellClick += SearchCstId;

            main.cb_Cststat.SelectedIndex = 0;
        }

        private void SearchCstId(object? sender, DataGridViewCellEventArgs e)
        {
            XmlOptionData sqldata = main.sqlList["TransportList"];
            DynamicParameters parameters = new DynamicParameters();
            string cquery = string.Empty;
            WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 16);

            //DataGridView dataGrid = sender as DataGridView;

            string trf_Code = (sender as DataGridView).CurrentRow.Cells["TRF_CODE"].Value.ToString();

            parameters.Add("@TRF_CODE", trf_Code);

            new WinformUtils(main).ShowSqltoDGV(main.transList_CstHist.DgvData, cquery, parameters, main.correntConnectionStringSetting);

            main.uwC_TextBox1.ApeendText(cquery, "@TRF_CODE", trf_Code);
        }

        internal void Btn_Click()
        {
            bool isTrayActHist = main.rb_IsTrayActHist.Checked;
            bool isEventHist = main.rb_IsEventHist.Checked;

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
            string cstid = main.lAtb_CstHist_CarrierId.Tb_Text;
            string toPortId = main.lAtb_CstHist_ToPort.Tb_Text;

            string startDate = main.lAdtp_CstHist_StartDate.Dtp_Value.ToString("yyyy-MM-dd");
            string endDate = main.lAdtp_CstHist_EndDate.Dtp_Value.ToString("yyyy-MM-dd");

            int cb_Num = main.cb_Cststat.SelectedIndex;

            try
            {
                XmlOptionData sqldata = main.sqlList["CstActHistSearch"];
                Dictionary<string, string> parameterDic = new Dictionary<string, string>();
                string cquery = sqldata.sql;
                var parameters = new DynamicParameters();

                if (toPortId != string.Empty)
                {
                    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 0);
                    parameters.Add("@ToPort", string.Concat("%", toPortId, "%"));
                }

                if (cstid != string.Empty)
                {
                    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 1);
                    parameters.Add("@CSTID", string.Concat("%", cstid, "%"));
                }

                WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 2);
                parameters.Add("@StartDate", startDate);
                parameters.Add("@EndDate", endDate);

                new WinformUtils(main).ShowSqltoDGV(main.cstHist_Dgv.DgvData, cquery, parameters, main.correntConnectionStringSetting);

                main.uwC_TextBox1.ApeendText(cquery, "@CSTID", cstid);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} : CstActHistSearch");
            }
        }

        private void CstEventHistSearch()
        {
            string cstid = main.lAtb_CstHist_CarrierId.Tb_Text;
            string toEqpId = main.lAtb_CstHist_ToPort.Tb_Text;

            string startDate = main.lAdtp_CstHist_StartDate.Dtp_Value.ToString("yyyy-MM-dd");
            string endDate = main.lAdtp_CstHist_EndDate.Dtp_Value.ToString("yyyy-MM-dd");

            int cb_Num = main.cb_Cststat.SelectedIndex;

            try
            {
                XmlOptionData sqldata = main.sqlList["CstEventHistSearch"];
                Dictionary<string, string> parameterDic = new Dictionary<string, string>();
                string cquery = sqldata.sql;
                var parameters = new DynamicParameters();

                parameters.Add("@StartDate", startDate);
                parameters.Add("@EndDate", endDate);

                parameters.Add("@CSTID", string.Concat("%", cstid, "%"));

                new WinformUtils(main).ShowSqltoDGV(main.cstHist_Dgv.DgvData, cquery, parameters, main.correntConnectionStringSetting);

                main.uwC_TextBox1.ApeendText(cquery, "@CSTID", cstid);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} : CstEventHistSearch");
            }

        }
    }
}
