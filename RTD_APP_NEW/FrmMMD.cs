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
    public partial class FrmMMD : Form
    {
        public FrmMMD()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            string Q = "";
            Q = "SELECT C.LOAD_REP_CSTID, CST_LOAD_LOCATION_CODE AS DAN, C.CSTID, C.CURR_LOTID, ";
            Q += "      C.TRF_STAT_CODE, W.PROCID, W.WIPSTAT, PA.S26, C.EQPT_CUR, C.PORT_CUR, ";
            Q += "      C.CURR_RACK_ID, CONVERT(CHAR(23), AGING_ISS_SCHD_DTTM, 20) AS AGING_ISS_SCHD_DTTM, DATEDIFF(MINUTE, GETDATE(), AGING_ISS_SCHD_DTTM) AS REMAIN_MINUTE, ";
            Q += "      CONVERT(CHAR(23), C.FINL_ACTDTTM, 20) AS FINL_ACTDTTM, C.FINL_ACT_EQPTID, C.FINL_ACT_PORT_ID, C.FINL_ACT_RACK_ID ";
            Q += " FROM CARRIER C WITH(NOLOCK) ";
            Q += "   LEFT JOIN WIPATTR WA WITH(NOLOCK) ON C.CSTID = WA.CSTID AND C.CURR_LOTID = WA.LOTID ";
            Q += "   LEFT JOIN WIP W WITH(NOLOCK) ON W.LOTID = WA.LOTID ";
            Q += "   LEFT JOIN PROCESSATTR PA WITH(NOLOCK) ON W.PROCID = PA.PROCID ";
            Q += "   LEFT JOIN COMMONCODE CM WITH(NOLOCK) ON CM.CMCDTYPE = 'PROC_GR_CODE' AND PA.S26 = CM.CMCODE ";
            Q += "  WHERE CSTSTAT = 'U' AND C.CURR_RACK_ID IS NULL AND PA.S26 IS NOT NULL AND PA.S26 IN ('3','4','7','9') ";
            Q += "    AND (EQPT_CUR LIKE '%STO%' OR EQPT_CUR IS NULL)  AND PORT_CUR IS NULL ";


            grdList.Rows.Clear();
            grdList.Columns.Clear();
            grdList.Columns.Add("SEQ", "순번");
            grdList.Columns.Add("CSTID", "트레이");
            grdList.Columns.Add("LOAD_REP_CSTID", "대표트레이");
            grdList.Columns.Add("CST_LOAD_LOCATION_CODE", "단");
            grdList.Columns.Add("CURR_LOTID", "LOT");
            grdList.Columns.Add("TRF_STAT_CODE", "상태");
            grdList.Columns.Add("PROCID", "PROC");
            grdList.Columns.Add("WIPSTAT", "WIP");
            grdList.Columns.Add("S26", "GR");
            grdList.Columns.Add("EQPT_CUR", "EQPT");
            grdList.Columns.Add("PORT_CUR", "PORT");
            grdList.Columns.Add("CURR_RACK_ID", "RACK");
            grdList.Columns.Add("AGING_ISS_SCHD_DTTM", "출고예정시각");
            grdList.Columns.Add("REMAIN_MINUTE", "경과시간");
            grdList.Columns.Add("FINL_ACTDTTM", "최종시각");
            grdList.Columns.Add("FINL_ACT_EQPTID", "최종설비");
            grdList.Columns.Add("FINL_ACT_PORT_ID", "최종PORT");
            grdList.Columns.Add("FINL_ACT_RACK_ID", "최종RACK");

            grdList.Columns[0].Width = 60; grdList.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 순번
            grdList.Columns[1].Width = 100; grdList.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;      // 대표캐리어
            grdList.Columns[2].Width = 100; grdList.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;      // 트레이
            grdList.Columns[3].Width = 60; grdList.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 단
            grdList.Columns[4].Width = 170; grdList.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;      // LOT
            grdList.Columns[5].Width = 60; grdList.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 반송상태
            grdList.Columns[6].Width = 80; grdList.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 공정
            grdList.Columns[7].Width = 60; grdList.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 작업상태
            grdList.Columns[8].Width = 60; grdList.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 그룹
            grdList.Columns[9].Width = 10; grdList.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;      // 현재설비
            grdList.Columns[10].Width = 10; grdList.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // 현재포트
            grdList.Columns[11].Width = 10; grdList.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 현재RACK
            grdList.Columns[12].Width = 10; grdList.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 출고예정시각
            grdList.Columns[13].Width = 80; grdList.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;      // 경과시간
            grdList.Columns[14].Width = 170; grdList.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 최종시각
            grdList.Columns[15].Width = 100; grdList.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // 최종설비
            grdList.Columns[16].Width = 150; grdList.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // 최종포트
            grdList.Columns[17].Width = 150; grdList.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 최종렉

            string cstr = "Data Source=10.95.9.59,7433;Initial catalog=ESGM_BMES_FORM_P01;User ID=rtd_app;Password=##r51T1980D@!";

            txtSQL.Text = Q;
            SqlDataAdapter R = new SqlDataAdapter(Q, cstr);
            ArrayList ar = new ArrayList();
            DataSet ds = new DataSet();
            R.Fill(ds);
            int idx = 1;
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        string[] data = new string[] {
                                idx++.ToString(),
                                dr["CSTID"].ToString(),
                                dr["LOAD_REP_CSTID"].ToString(),
                                dr["DAN"].ToString(),
                                dr["CURR_LOTID"].ToString(),
                                dr["TRF_STAT_CODE"].ToString(),
                                dr["PROCID"].ToString(),
                                dr["WIPSTAT"].ToString(),
                                dr["S26"].ToString(),
                                dr["EQPT_CUR"].ToString(),
                                dr["PORT_CUR"].ToString(),
                                dr["CURR_RACK_ID"].ToString(),
                                dr["AGING_ISS_SCHD_DTTM"].ToString(),
                                dr["REMAIN_MINUTE"].ToString(),
                                dr["FINL_ACTDTTM"].ToString(),
                                dr["FINL_ACT_EQPTID"].ToString(),
                                dr["FINL_ACT_PORT_ID"].ToString(),
                                dr["FINL_ACT_RACK_ID"].ToString(),
                            };
                        grdList.Rows.Add(data);
                    }
                }
            }
        }
    }
}
