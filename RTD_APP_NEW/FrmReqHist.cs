using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTD_APP_NEW
{
    public partial class FrmReqHist : Form
    {
        /// <summary>
        /// 요청번호
        /// </summary>
        public string SEQNO { get; set; }

        public FrmReqHist()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ReqList()
        {
            //string cstr = "Data Source=10.95.9.59,7433;database=ESGM_BMES_FORM_P01;UID=rtd_app;pwd=##r51T1980D@!";
            string cstr = "Data Source=10.95.9.59,7433;Initial catalog=ESGM_BMES_FORM_P01;User ID=rtd_app;Password=##r51T1980D@!";

            grdHist.Rows.Clear();
            grdHist.Columns.Clear();
            grdHist.Columns.Add("SEQ", "순번");
            grdHist.Columns.Add("CSTID", "CST");
            grdHist.Columns.Add("CST_STAT", "상태");
            grdHist.Columns.Add("REQ_EQPTID", "요청설비");
            grdHist.Columns.Add("REQ_PORT_D", "요청포트");
            grdHist.Columns.Add("REQ_TYPE_CODE", "구분");
            grdHist.Columns.Add("PRCS_TYPE_CODE", "요청구분");
            grdHist.Columns.Add("REQ_STAT_CODE", "요청상태");
            grdHist.Columns.Add("RTD_RULE_CODE", "RULE");
            grdHist.Columns.Add("INSUSER", "요청자");
            grdHist.Columns.Add("INSDTTM", "생성시각");
            //grdHist.Columns.Add("UPDDTTM", "수정시각");
            //grdHist.Columns.Add("REQ_SEQS", "처리횟수");
            grdHist.Columns.Add("ERR_CODE", "ERROR");
            grdHist.Columns.Add("ERR_DESC", "ERR DESC");
            grdHist.Columns.Add("RTD_EXEC_LOG_CNTT", "RULE LOG");
            //grdHist.Columns.Add("REQ_SEQNO", "SEQNO");

            grdHist.Columns[0].Width = 60; grdHist.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // SEQ
            grdHist.Columns[1].Width = 100; grdHist.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // cstid
            grdHist.Columns[2].Width = 60; grdHist.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 상태
            grdHist.Columns[3].Width = 100; grdHist.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; grdHist.Columns[3].Visible = false;    // 요청설비
            grdHist.Columns[4].Width = 150; grdHist.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // 요청포트
            grdHist.Columns[5].Width = 60; grdHist.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 구분(UR/LR)
            grdHist.Columns[6].Width = 80; grdHist.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 요청구분(EQPT_REQ, BTCH_REQ)
            grdHist.Columns[7].Width = 80; grdHist.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 진행상태
            grdHist.Columns[8].Width = 150; grdHist.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // RULE
            grdHist.Columns[9].Width = 100; grdHist.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // 요청자
            grdHist.Columns[10].Width = 150; grdHist.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // 생성시각
            //grdHist.Columns[10].Width = 150; grdHist.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // 수정시각
            //grdHist.Columns[11].Width = 100; grdHist.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;     // 처리횟수
            grdHist.Columns[11].Width = 60; grdHist.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // error code
            grdHist.Columns[12].Width = 200; grdHist.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // error desc
            grdHist.Columns[13].Width = 200; grdHist.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // rule log

            string cquery = "SELECT TOP 100 ";
            cquery += "           REQ.REQ_SEQNO     ";
            cquery += "         , REQ.CSTID AS CSTID_R  ";
            cquery += "         , REQ.CSTSTAT AS CSTSTAT_R  ";
            cquery += "         , REQ.EQPTID AS EQPTID_R  ";
            cquery += "         , REQ.PORT_ID AS PORT_ID_R  ";
            cquery += "         , REQ.REQ_TYPE_CODE AS REQ_TYPE_CODE_R  ";
            cquery += "         , REQ.PRCS_TYPE_CODE  ";
            cquery += "         , REQ.REQ_STAT_CODE  ";
            cquery += "         , REQ.RTD_RULE_ID AS RTD_RULE_ID_R ";
            cquery += "         , REQ.INSUSER AS INSUSER_R  ";
            cquery += "         , CONVERT(CHAR(23), REQ.INSDTTM, 20) AS INSDTTM_R  ";
            cquery += "         , CONVERT(CHAR(23), REQ.UPDDTTM, 20) AS UPDDTTM_R  ";
            cquery += "         , REQ.REQ_STAT_CODE  ";          // 상태
            cquery += "         , REQ.ERR_CODE  ";          // ERROR CODE
            cquery += "         , ISNULL(CC.CMCDNAME, '')  AS ERR_DESC  ";          // ERROR DESC
            cquery += "         , REQ.REQ_SEQS  ";          // 요청횟수
            cquery += "         , REQ.RTD_EXEC_LOG_CNTT ";
            cquery += "        FROM TB_MHS_TRF_REQ_HIST REQ with(nolock) ";
            cquery += "        LEFT JOIN COMMONCODE CC with(nolock) ON CC.CMCDTYPE ='TRF_REQ_ERR_CODE' AND CC.CMCODE = ERR_CODE ";
            //cquery += "       WHERE DATEDIFF(hour, REQ.INSDTTM, GETDATE())<=24 ";
            cquery += "       WHERE REQ.REQ_SEQNO = " + SEQNO;
            cquery += "       ORDER BY REQ.HIST_SEQNO DESC ";
            SqlDataAdapter R = new SqlDataAdapter(cquery, cstr);
            ArrayList ar = new ArrayList();
            DataSet ds1 = new DataSet();
            //DataTable dt = new DataTable();
            R.Fill(ds1);

            int idx = 0;
            if (ds1 != null)
            {
                if (ds1.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds1.Tables[0].Rows)
                    {
                        idx++;
                        string err = "";
                        if (dr["ERR_DESC"].ToString().Length > 6)
                        {
                            err = dr["ERR_DESC"].ToString().Substring(6);
                            if (err != "")
                            {
                                err = err.Substring(0, err.IndexOf('|'));
                            }
                            if (dr["ERR_CODE"].ToString() == "-1") { err = "Timeout.(-1)"; }
                        }

                        string[] data = new string[] {
                                idx.ToString(),
                                dr["CSTID_R"].ToString(),
                                dr["CSTSTAT_R"].ToString(),
                                dr["EQPTID_R"].ToString(),
                                dr["PORT_ID_R"].ToString(),
                                dr["REQ_TYPE_CODE_R"].ToString(),
                                dr["PRCS_TYPE_CODE"].ToString(),
                                dr["REQ_STAT_CODE"].ToString(),
                                dr["RTD_RULE_ID_R"].ToString(),
                                dr["INSUSER_R"].ToString(),
                                dr["INSDTTM_R"].ToString(),
                                //dr["UPDDTTM_R"].ToString(),
                                //dr["REQ_SEQS"].ToString(),
                                dr["ERR_CODE"].ToString(),
                                err,
                                dr["RTD_EXEC_LOG_CNTT"].ToString()
                                //dr["REQ_SEQNO"].ToString()
                            };
                        grdHist.Rows.Add(data);
                    }
                }
            }

        }

        private void FrmReqHist_Load(object sender, EventArgs e)
        {
            ReqList();
        }

        private void grdHist_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // log 항목 더블클릭시
            string sLog = grdHist.Rows[e.RowIndex].Cells[13].Value.ToString();
            string sRule = grdHist.Rows[e.RowIndex].Cells[7].Value.ToString();

            if (sLog != "")
            {
                FrmLogs fLog = new FrmLogs();
                fLog.sLog = sLog;
                fLog.RuleName = sRule;
                fLog.ShowDialog();
            }
        }
    }
}
