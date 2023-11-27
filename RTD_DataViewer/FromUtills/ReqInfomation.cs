using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlManagement;

namespace RTD_DataViewer
{
    public class ReqInfomation
    {
        MainViewer main;
        string cstid = string.Empty;
        string startDate = string.Empty;
        string endDate = string.Empty;
        string EqpId = string.Empty;
        string ruleId = string.Empty;
        int currNum = 0;

        public ReqInfomation(MainViewer main)
        {
            this.main = main;
            InitControlText(main);
        }

        public void InitControlText(MainViewer main)
        {
            main.lAtb_ReqInfo_ReqEqp.lb_Txt.Text = "요청설비";
            main.lAtb_ReqInfo_RuleText.lb_Txt.Text = "Rule Name";
            main.lAtb_ReqInfo_Cstid.lb_Txt.Text = "Carrier ID";
            main.lAdtp_ReqInfo_StartDate.lb_Txt = "시작 일시";
            main.lAdtp_ReqInfo_EndDate.lb_Txt = "종료 일시";

            main.tAbt_ReqInfo_Search.timer.Tick += Timer_Tick;
            main.reqInfo_dgvReq.DgvData.CellClick += SearchCstId;
        }

        private void SearchCstId(object? sender, DataGridViewCellEventArgs e)
        {
            XmlOptionData sqldata = main.sqlList["ReqList"];
            DynamicParameters parameters = new DynamicParameters();
            string cquery = string.Empty;
            WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 6);

            //DataGridView dataGrid = sender as DataGridView;

            string cstId = (sender as DataGridView).CurrentRow.Cells["CSTID"].Value.ToString();

            parameters.Add("@CSTID", cstId);

            new WinformUtils(main).ShowSqltoDGV(main.reqInfo_DgvCarrier.DgvData, cquery, parameters, main.correntConnectionStringSetting);

            main.uwC_TextBox2.ApeendText(cquery, "@CSTID", cstId);
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            int interval = main.tAbt_ReqInfo_Search.Interval;         

            if (currNum == 0) {
                ReqList();
                currNum = main.tAbt_ReqInfo_Search.Interval;
            }
            else {
                main.tAbt_ReqInfo_Search.bt_Search.Text = currNum.ToString("000") + "\nStop";
                currNum--;
            }
        }

        internal void Btn_Click()
        {
            if (main.tAbt_ReqInfo_Search.IsUseTimer)
            {
                main.tAbt_ReqInfo_Search.timer.Interval = 1000;
                if (main.tAbt_ReqInfo_Search.timer.Enabled)
                {
                    main.tAbt_ReqInfo_Search.timer.Stop();
                    main.tAbt_ReqInfo_Search.bt_Search.Text = "Search";
                }
                else
                {
                    main.tAbt_ReqInfo_Search.timer.Start();
                }
            }
            else
            {
                ReqList();
            }
        }

        public void ReqList()
        {
            this.cstid = main.lAtb_ReqInfo_Cstid.textBox.Text;
            this.startDate = main.lAdtp_ReqInfo_StartDate.dtp_Value.ToString("yyyy-MM-dd");
            this.endDate = main.lAdtp_ReqInfo_EndDate.dtp_Value.ToString("yyyy-MM-dd");
            this.EqpId = main.lAtb_ReqInfo_ReqEqp.textBox.Text;
            this.ruleId = main.lAtb_ReqInfo_RuleText.textBox.Text;

            try
            {
                XmlOptionData sqldata = main.sqlList["ReqList"];
                DynamicParameters parameters = new DynamicParameters();
                Dictionary<string, string> parameterDic = new Dictionary<string, string>();
                //using (var connection = new OracleConnection(cstr))

                string cquery = sqldata.sql;
                if (cstid != "")
                {
                    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 0);
                    parameterDic.Add("@CSTID", string.Concat(@"%", cstid, "%"));
                    parameters.Add("@CSTID", string.Concat(@"%", cstid, "%"));
                    //cquery += "   AND REQ.CSTID = '" + txtReqCSTID.Text + "' ";
                }
                WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 1);
                parameterDic.Add("@StartDate", startDate);
                parameters.Add("@StartDate", startDate, dbType: DbType.DateTime);
                parameterDic.Add("@EndDate", endDate);
                parameters.Add("@EndDate", endDate, dbType: DbType.DateTime);
                //cquery += "   AND CONVERT(CHAR(10), REQ.INSDTTM, 20) BETWEEN '" + txtReqsDate.Text + "' AND '" + txtReqeDate.Text + "' ";
                if (EqpId != "")
                {
                    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 2);
                    parameters.Add("@EQPTID", string.Concat("%", EqpId, "%"));
                    parameterDic.Add("@EQPTID", string.Concat("%", EqpId, "%"));
                    //cquery += "   AND REQ.EQPTID LIKE '" + txtReqEqpt.Text + "' ";
                }
                if (ruleId != "")
                {
                    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 3);
                    parameters.Add("@RULEID", string.Concat("%", ruleId, "%"));
                    parameterDic.Add("@RULEID", string.Concat("%", ruleId, "%"));
                    //cquery += "   AND REQ.RTD_RULE_ID LIKE '%" + txtRule.Text + "%' ";
                }
                WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 5);
                // cquery += "       ORDER BY REQ.CSTID, REQ.UPDDTTM DESC ";

                new WinformUtils(main).ShowSqltoDGV(main.reqInfo_dgvReq.DgvData, cquery, parameters, main.correntConnectionStringSetting);

                main.uwC_TextBox2.ApeendText(cquery, parameterDic);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} : ReqList");
            }
        }
    }
}
