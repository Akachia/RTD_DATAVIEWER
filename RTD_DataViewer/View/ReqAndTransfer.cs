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
