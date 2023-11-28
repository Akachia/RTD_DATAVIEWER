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
            main.tAbt_ReqInfo_Search.timer.Tick += Timer_Tick;
            main.reqInfo_dgvReq.DgvData.CellClick += SearchCstId;
        }

        private void SearchCstId(object? sender, DataGridViewCellEventArgs e)
        {
            XmlOptionData sqldata = main.sqlList["ReqInfomation"];
            DynamicParameters parameters = new DynamicParameters();
            string cquery = string.Empty;
            WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 6);

            //DataGridView dataGrid = sender as DataGridView;

            string cstId = (sender as DataGridView).CurrentRow.Cells["CSTID"].Value.ToString();

            parameters.Add("@CSTID", cstId);

            new WinformUtils(main).ShowSqltoDGV(main.reqInfo_DgvCarrier.DgvData, cquery, parameters, main.correntConnectionStringSetting);

            main.uwC_TextBox1.ApeendText(cquery, "@CSTID", cstId);
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
            this.cstid = main.lAtb_ReqInfo_Cstid.Tb_Text;
            this.startDate = main.lAdtp_ReqInfo_StartDate.Dtp_Value.ToString("yyyy-MM-dd");
            this.endDate = main.lAdtp_ReqInfo_EndDate.Dtp_Value.ToString("yyyy-MM-dd");
            this.EqpId = main.lAtb_ReqInfo_ReqEqp.Tb_Text;
            this.ruleId = main.lAtb_ReqInfo_RuleText.Tb_Text;

            try
            {
                XmlOptionData sqldata = main.sqlList["ReqInfomation"];
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

                main.uwC_TextBox1.ApeendText(cquery, parameterDic);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} : ReqList");
            }
        }
    }
}
