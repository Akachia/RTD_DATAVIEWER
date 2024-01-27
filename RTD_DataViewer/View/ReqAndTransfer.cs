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
    public partial class ReqAndTransfer : UserControl
    {
        MainViewer main;

        public ReqAndTransfer(MainViewer main)
        {
            InitializeComponent();
            this.main = main;

            DateTime tomorrow = DateTime.Today.AddDays(1);
            DateTime yesterday = DateTime.Today.AddDays(-1);
            this.main = main;
            bt_ReqATransfer_Search.Click += Bt_ReqATransfer_Search_Click;
            lAdtp_ReqATransfer_EndDate.Dtp_Value = tomorrow;
            lAdtp_ReqATransfer_StartDate.Dtp_Value = yesterday;

            cb_ReqATransfer_CstStat.SelectedIndex = 0;
            cb_ReqATransfer_MovingState.SelectedIndex = 0;
            lAdtp_ReqATransfer_EndDate.IsChecked = false;
            lAdtp_ReqATransfer_StartDate.IsChecked = true;

        }

        private void Bt_ReqATransfer_Search_Click(object? sender, EventArgs e)
        {
            Btn_Click();
        }

        internal void Btn_Click()
        {
            if (ckb_IsDeleteTransfer.Checked == true) SearchDeleteTransfer();
            else if (rb_ReqHist.Checked) { SearchReq(); }
            else { SearchTransfer(); }
        }

        private void SearchTransfer()
        {
            string cstid = lAtb_ReqATransfer_CarrierId.Tb_Text;
            string toEqpId = lAtb_ReqATransfer_ArrPort.Tb_Text;
            string reqEqpId = lAtb_ReqATransfer_StartPort.Tb_Text;
            string ruleId = lAtb_ReqATransfer_RuleId.Tb_Text;

            string startDate = lAdtp_ReqATransfer_StartDate.MakeNowDateStringAndSetting();
            string endDate = lAdtp_ReqATransfer_EndDate.MakeNowDateStringAndSetting();

            int cb_CstStat_Num = cb_ReqATransfer_CstStat.SelectedIndex;
            int cb_Moving_Num = cb_ReqATransfer_MovingState.SelectedIndex;
            try
            {
                //XmlOptionData sqldata = main.sqlList["SearchTransfer"];
                //Dictionary<string, string> parameterDic = new Dictionary<string, string>();
                //string cquery = sqldata.Sql;
                //var parameters = new DynamicParameters();
                //parameters.Add("@StartDate", startDate);
                //parameters.Add("@EndDate", endDate);
                //parameters.Add("@CSTID", string.Concat("%", cstid, "%"));
                //parameters.Add("@ReqEQP", string.Concat("%", reqEqpId, "%"));
                //parameters.Add("@ToEQP", string.Concat("%", toEqpId, "%"));
                //parameters.Add("@MovingState", cb_ReqATransfer_MovingState.Text);
                //parameters.Add("@RuleId", string.Concat("%", ruleId, "%"));

                Dictionary<string, string> paramaterDic = new Dictionary<string, string>();

                paramaterDic.Add("CSTSTAT", $"{cb_CstStat_Num}");
                paramaterDic.Add("MOVINGSTATE", $"{cb_Moving_Num}");
                paramaterDic.Add("CSTID", cstid);
                paramaterDic.Add("RuleId", ruleId);
                paramaterDic.Add("ReqEQP", reqEqpId);
                paramaterDic.Add("ToEQP", toEqpId);
                paramaterDic.Add("StartDate", $"'{startDate}'");
                paramaterDic.Add("EndDate", $"'{endDate}'");

                new WinformUtils(main).ExcuteSql(paramaterDic, reqAndTransfer_dgvReq.DgvData, main.correntConnectionStringSetting, MethodBase.GetCurrentMethod().Name);


                //WHERE INSDTTM BETWEEN '" + txtFrom.Text + "' AND '" + txtTo.Text + "'

                //if (cstid != string.Empty)
                //{
                //    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 0);
                //    parameters.Add("@CSTID", string.Concat("%", cstid, "%"));
                //    //cquery += " AND CSTID LIKE '%" + txtID.Text + "%'";
                //}
                //if (reqEqpId != string.Empty)
                //{
                //    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 1);
                //    parameters.Add("@ReqEQP", string.Concat("%", reqEqpId, "%"));
                //    //cquery += " AND FROM_PORT_ID LIKE '%" + txtFromPort.Text + "%'"; 
                //}
                //if (toEqpId != string.Empty)
                //{
                //    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 2);
                //    parameters.Add("@ToEQP", string.Concat("%", toEqpId, "%"));
                //    //cquery += " AND TO_PORT_ID LIKE '%" + txtToPort.Text + "%'";
                //}
                //if (cb_CstStat_Num != 0)
                //{
                //    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 3);
                //    if (cb_CstStat_Num == 1) parameters.Add("@CSTSTAT", string.Concat("U")); ;    // 실트레이
                //    if (cb_CstStat_Num == 2) parameters.Add("@CSTSTAT", string.Concat("E")); ;    // 공트레이
                //    //cquery += " AND CSTSTAT = 'U'"
                //    //cquery += " AND CSTSTAT = 'E'"
                //}
                //if (cb_Moving_Num != 0)
                //{
                //    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 4);
                //    parameters.Add("@MovingState", cb_ReqATransfer_MovingState.Text);
                //    //if (cobStat.SelectedIndex != 0) { cquery += " AND CMD_STAT_CODE = '" + cobStat.Text + "'"
                //}
                //if (ruleId != string.Empty)
                //{
                //    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 5);
                //    parameters.Add("@RuleId", string.Concat("%", ruleId, "%"));
                //    //if(txtRuleList.Text.Trim() != "") { cquery += " AND RTD_RULE_ID = '" + txtRuleList.Text + "'"
                //}

                //new WinformUtils(main).ShowSqltoDGV(reqAndTransfer_dgvReq.DgvData, cquery, parameters, main.correntConnectionStringSetting);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} : SearchTransfer");
            }
        }

        private void SearchDeleteTransfer()
        {
            string startDate = lAdtp_ReqATransfer_StartDate.MakeNowDateStringAndSetting();
            string endDate = lAdtp_ReqATransfer_EndDate.MakeNowDateStringAndSetting();

            string toEqpId = lAtb_ReqATransfer_ArrPort.Tb_Text;
            string reqEqpId = lAtb_ReqATransfer_StartPort.Tb_Text;

            try
            {
                XmlOptionData sqldata = main.sqlList["SearchDeleteTransfer"];
                Dictionary<string, string> parameterDic = new Dictionary<string, string>();
                string cquery = sqldata.Sql;
                var parameters = new DynamicParameters();
                parameters.Add("@ReqEQP", string.Concat("%", reqEqpId, "%"));
                parameters.Add("@ToEQP", string.Concat("%", toEqpId, "%"));
                new WinformUtils(main).ShowSqltoDGV(reqAndTransfer_dgvReq.DgvData, cquery, parameters, main.correntConnectionStringSetting);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} : SearchDeleteTransfer");
            }
        }

        private void SearchReq()
        {
            string cstid = lAtb_ReqATransfer_CarrierId.Tb_Text;
            string toEqpId = lAtb_ReqATransfer_StartPort.Tb_Text;
            string startDate = lAdtp_ReqATransfer_StartDate.MakeNowDateStringAndSetting();
            string endDate = lAdtp_ReqATransfer_EndDate.MakeNowDateStringAndSetting();

            int cb_CstStat_Num = cb_ReqATransfer_CstStat.SelectedIndex;

            try
            {
                Dictionary<string, string> paramaterDic = new Dictionary<string, string>();

                paramaterDic.Add("PRCS_TYPE_CODE", $"{cb_ReqATransfer_CstStat.SelectedIndex}");
                paramaterDic.Add("CSTSTAT", $"{cb_ReqATransfer_CstStat.SelectedIndex}");
                paramaterDic.Add("CSTID", lAtb_ReqATransfer_CarrierId.Tb_Text);
                paramaterDic.Add("PORTID", lAtb_ReqATransfer_StartPort.Tb_Text);
                paramaterDic.Add("StartDate", $"'{startDate}'");
                paramaterDic.Add("EndDate", $"'{endDate}'");

                new WinformUtils(main).ExcuteSql(paramaterDic, reqAndTransfer_dgvReq.DgvData, main.correntConnectionStringSetting, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} : SearchReq");
            }
        }

    }
}
