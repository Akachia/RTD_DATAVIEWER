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
    public partial class ReqInfomation : UserControl
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
            InitializeComponent();
            DateTime tomorrow = DateTime.Today.AddDays(1);
            DateTime yesterday = DateTime.Today.AddDays(-1);
            this.main = main;
            tAbt_ReqInfo_Search.timer.Tick += Timer_Tick;
            tAbt_ReqInfo_Search.bt_Search.Click += Bt_Search_Click;
            reqInfo_dgvReq.DgvData.CellClick += SearchCstInfo;
            lAdtp_ReqInfo_EndDate.Dtp_Value = tomorrow;
            lAdtp_ReqInfo_StartDate.Dtp_Value = yesterday;
        }

        private void Bt_Search_Click(object? sender, EventArgs e)
        {
            Btn_Click();
        }

        private void SearchCstInfo(object? sender, DataGridViewCellEventArgs e)
        {
            XmlOptionData sqldata = main.sqlList["SearchCstInfo"];
            DynamicParameters parameters = new DynamicParameters();
            string cquery = sqldata.Sql;

            string cstId = (sender as DataGridView).CurrentRow.Cells["CSTID"].Value.ToString();

            parameters.Add("@CSTID", cstId);

            new WinformUtils(main).ShowSqltoDGV(reqInfo_DgvCarrier.DgvData, cquery, parameters, main.correntConnectionStringSetting);
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            int interval = tAbt_ReqInfo_Search.Interval;

            if (currNum == 0)
            {
                ReqList();
                currNum = tAbt_ReqInfo_Search.Interval;
            }
            else
            {
                tAbt_ReqInfo_Search.bt_Search.Text = currNum.ToString("000") + "\nStop";
                currNum--;
            }
        }

        internal void Btn_Click()
        {
            if (tAbt_ReqInfo_Search.IsUseTimer)
            {
                tAbt_ReqInfo_Search.timer.Interval = 1000;
                if (tAbt_ReqInfo_Search.timer.Enabled)
                {
                    tAbt_ReqInfo_Search.timer.Stop();
                    tAbt_ReqInfo_Search.bt_Search.Text = "Search";
                }
                else
                {
                    tAbt_ReqInfo_Search.timer.Start();
                }
            }
            else
            {
                ReqList();
            }
        }

        public void ReqList()
        {
            this.cstid = lAtb_ReqInfo_Cstid.Tb_Text;
            this.startDate = lAdtp_ReqInfo_StartDate.Dtp_Value.ToString("yyyy-MM-dd");
            this.endDate = lAdtp_ReqInfo_EndDate.Dtp_Value.ToString("yyyy-MM-dd");
            this.ruleId = lAtb_ReqInfo_RuleText.Tb_Text;
            this.EqpId = lAtb_ReqInfo_ReqEqp.Tb_Text;

            try
            {
                XmlOptionData sqldata = main.sqlList["ReqInfomation"];
                DynamicParameters parameters = new DynamicParameters();
                //using (var connection = new OracleConnection(cstr))

                string cquery = sqldata.Sql;
                if (cstid != "")
                {
                    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 0);
                    parameters.Add("@CSTID", string.Concat(@"%", cstid, "%"));
                    //cquery += "   AND REQ.CSTID = '" + txtReqCSTID.Text + "' ";
                }
                WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 1);
                parameters.Add("@StartDate", startDate, dbType: DbType.DateTime);
                parameters.Add("@EndDate", endDate, dbType: DbType.DateTime);
                //cquery += "   AND CONVERT(CHAR(10), REQ.INSDTTM, 20) BETWEEN '" + txtReqsDate.Text + "' AND '" + txtReqeDate.Text + "' ";
                if (EqpId != "")
                {
                    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 2);
                    parameters.Add("@EQPTID", string.Concat("%", EqpId, "%"));
                    //cquery += "   AND REQ.EQPTID LIKE '" + txtReqEqpt.Text + "' ";
                }
                if (ruleId != "")
                {
                    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 3);
                    parameters.Add("@RULEID", string.Concat("%", ruleId, "%"));
                    //cquery += "   AND REQ.RTD_RULE_ID LIKE '%" + txtRule.Text + "%' ";
                }
                WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 5);
                // cquery += "       ORDER BY REQ.CSTID, REQ.UPDDTTM DESC ";

                new WinformUtils(main).ShowSqltoDGV(reqInfo_dgvReq.DgvData, cquery, parameters, main.correntConnectionStringSetting);

                int rowCount = reqInfo_dgvReq.DgvData.RowCount;

                for (int i = 0; i < rowCount; i++)
                {
                    string req_stat_code = reqInfo_dgvReq.DgvData.Rows[i].Cells["REQ_STAT_CODE"].Value.ToString();

                    if (req_stat_code != string.Empty)
                    {
                        if (req_stat_code == "REQUEST" || req_stat_code == "QUERY")
                        {
                            //FFD4D4
                            reqInfo_dgvReq.DgvData.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 212, 212);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} : ReqList");
            }

        }
    }
}
