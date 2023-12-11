using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using XmlManagement;

namespace RTD_DataViewer
{
    internal class ReqAndTransfer
    {

        MainViewer main;
        int currNum = 0;
        public ReqAndTransfer(MainViewer main)
        {
            this.main = main;
            InitControlText(main);
        }

        public void InitControlText(MainViewer main)
        {
            //main.cb_ReqATransfer_CstStat.SelectedIndex = 0;
            //main.cb_ReqATransfer_MovingState.SelectedIndex = 0;
        }

        internal void Btn_Click()
        {
            if (main.ckb_IsDeleteTransfer.Checked == true) SearchDeleteTransfer();
            else if (main.rb_ReqHist.Checked) { SearchReq(); }
            else { SearchTransfer(); }
        }

        private void SearchTransfer()
        {
            string cstid = main.lAtb_ReqATransfer_CarrierId.Tb_Text;
            string toEqpId = main.lAtb_ReqATransfer_ArrPort.Tb_Text;
            string reqEqpId = main.lAtb_ReqATransfer_StartPort.Tb_Text;
            string ruleId = main.lAtb_ReqATransfer_RuleId.Tb_Text;
            string startDate = main.lAdtp_ReqATransfer_StartDate.Dtp_Value.ToString("yyyy-MM-dd");
            string endDate = main.lAdtp_ReqATransfer_EndDate.Dtp_Value.ToString("yyyy-MM-dd");

            int cb_CstStat_Num = main.cb_ReqATransfer_CstStat.SelectedIndex;
            int cb_Moving_Num = main.cb_ReqATransfer_MovingState.SelectedIndex;
            try
            {
                XmlOptionData sqldata = main.sqlList["SearchTransfer"];
                Dictionary<string, string> parameterDic = new Dictionary<string, string>();
                string cquery = sqldata.sql;
                var parameters = new DynamicParameters();
                parameters.Add("@StartDate",  startDate);
                parameters.Add("@EndDate",  endDate);
                //WHERE INSDTTM BETWEEN '" + txtFrom.Text + "' AND '" + txtTo.Text + "'

                if (cstid != string.Empty)
                {
                    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 0);
                    parameters.Add("@CSTID", string.Concat("%", cstid, "%"));
                    //cquery += " AND CSTID LIKE '%" + txtID.Text + "%'";
                }
                if (reqEqpId != string.Empty) 
                {
                    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 1);
                    parameters.Add("@ReqEQP", string.Concat("%", reqEqpId, "%"));
                    //cquery += " AND FROM_PORT_ID LIKE '%" + txtFromPort.Text + "%'"; 
                }
                if (toEqpId != string.Empty) 
                {
                    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 2);
                    parameters.Add("@ToEQP", string.Concat("%", toEqpId, "%"));
                    //cquery += " AND TO_PORT_ID LIKE '%" + txtToPort.Text + "%'";
                }
                if (cb_CstStat_Num != 0)
                {
                    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 3);
                    if (cb_CstStat_Num == 1) parameters.Add("@CSTSTAT", string.Concat("U")); ;    // 실트레이
                    if (cb_CstStat_Num == 2) parameters.Add("@CSTSTAT", string.Concat("E")); ;    // 공트레이
                    //cquery += " AND CSTSTAT = 'U'"
                    //cquery += " AND CSTSTAT = 'E'"
                }
                if (cb_Moving_Num != 0) 
                {
                    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 4);
                    parameters.Add("@MovingState", main.cb_ReqATransfer_MovingState.Text);
                    //if (cobStat.SelectedIndex != 0) { cquery += " AND CMD_STAT_CODE = '" + cobStat.Text + "'"
                }
                if (ruleId != string.Empty) 
                {
                    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 5);
                    parameters.Add("@RuleId", string.Concat("%", ruleId, "%"));
                    //if(txtRuleList.Text.Trim() != "") { cquery += " AND RTD_RULE_ID = '" + txtRuleList.Text + "'"
                }

                new WinformUtils(main).ShowSqltoDGV(main.reqAndTransfer_dgvReq.DgvData, cquery, parameters, main.correntConnectionStringSetting);

                main.uwC_TextBox1.ApeendText(cquery, "@CSTID", cstid);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} : SearchTransfer");
            }
        }

        private void SearchDeleteTransfer()
        {
            string startDate = main.lAdtp_ReqATransfer_StartDate.Dtp_Value.ToString("yyyy-MM-dd");
            string endDate = main.lAdtp_ReqATransfer_EndDate.Dtp_Value.ToString("yyyy-MM-dd");
            string toEqpId = main.lAtb_ReqATransfer_ArrPort.Tb_Text;
            string reqEqpId = main.lAtb_ReqATransfer_StartPort.Tb_Text;

            try
            {
                XmlOptionData sqldata = main.sqlList["SearchDeleteTransfer"];
                Dictionary<string, string> parameterDic = new Dictionary<string, string>();
                string cquery = sqldata.sql;
                var parameters = new DynamicParameters();
                parameters.Add("@ReqEQP", string.Concat("%", reqEqpId, "%"));
                parameters.Add("@ToEQP", string.Concat("%", toEqpId, "%"));
                new WinformUtils(main).ShowSqltoDGV(main.reqAndTransfer_dgvReq.DgvData, cquery, parameters, main.correntConnectionStringSetting);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} : SearchDeleteTransfer");
            }
        }

        private void SearchReq()
        {
            string cstid = main.lAtb_ReqATransfer_CarrierId.Tb_Text;
            string toEqpId = main.lAtb_ReqATransfer_StartPort.Tb_Text;
            string startDate = main.lAdtp_ReqATransfer_StartDate.Dtp_Value.ToString("yyyy-MM-dd");
            string endDate = main.lAdtp_ReqATransfer_EndDate.Dtp_Value.ToString("yyyy-MM-dd");

            int cb_CstStat_Num = main.cb_ReqATransfer_CstStat.SelectedIndex;

            try
            {
                XmlOptionData sqldata = main.sqlList["SearchReq"];
                DynamicParameters parameters = new DynamicParameters();
                //using (var connection = new OracleConnection(cstr))

                parameters.Add("@StartDate", startDate, dbType: DbType.Date);
                parameters.Add("@EndDate", endDate, dbType: DbType.Date);
                //cquery += "       WHERE INSDTTM BETWEEN '" + txtFrom.Text + "' AND '" + txtTo.Text + "'";

                string cquery = sqldata.sql;
                if (cstid != string.Empty)
                {
                    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 0);
                    parameters.Add("@CSTID", string.Concat("%", cstid, "%"));
                    //cquery += "  AND CSTID = '" + txtID.Text + "'"
                }
                if (toEqpId != string.Empty)
                {
                    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 1);
                    parameters.Add("@PORT_ID", string.Concat("%", toEqpId, "%"));
                    //cquery += "  AND PORT_ID LIKE '" + txtFromPort.Text + "%'"; 
                }

                if (cb_CstStat_Num != 0)
                {
                    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 2);
                    if (cb_CstStat_Num == 1) parameters.Add("@CSTSTAT", string.Concat("U")); ;    // 실트레이
                    if (cb_CstStat_Num == 2) parameters.Add("@CSTSTAT", string.Concat("E")); ;    // 공트레이
                    //cquery += " AND CSTSTAT = 'U'"
                    //cquery += " AND CSTSTAT = 'E'"
                }
                WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 3);
                new WinformUtils(main).ShowSqltoDGV(main.reqAndTransfer_dgvReq.DgvData, cquery, parameters, main.correntConnectionStringSetting);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} : SearchReq");
            }
        }
    }
}
