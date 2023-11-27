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
    public partial class FrmTrayInfo : Form
    {
        public string CSTID { get; set; }
        public FrmTrayInfo()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 캐리어 정보
        /// </summary>
        private void CST_List()
        {
            //string cstr = "Data Source=10.95.9.59,7433;database=ESGM_BMES_FORM_P01;UID=rtd_app;pwd=##r51T1980D@!";
            string cstr = "Data Source=10.95.9.59,7433;Initial catalog=ESGM_BMES_FORM_P01;User ID=rtd_app;Password=##r51T1980D@!";

            grdCST.Columns.Clear();
            grdCST.Columns.Add("SEQ", "순번");
            grdCST.Columns.Add("CSTID", "트레이");
            grdCST.Columns.Add("LOAD_REP_CSTID", "대표트레이");
            grdCST.Columns.Add("CST_LOAD_LOCATION_CODE", "단");
            grdCST.Columns.Add("CSTSTAT", "구분");
            grdCST.Columns.Add("TRAY_TYPE_CODE", "타입");
            grdCST.Columns.Add("CURR_LOTID", "LOT");
            grdCST.Columns.Add("WIPSTAT", "WIPSTAT");
            grdCST.Columns.Add("CURR_RACK_ID", "RACK위치");
            grdCST.Columns.Add("EQPTID", "설비");
            grdCST.Columns.Add("PORT_ID", "포트");
            grdCST.Columns.Add("ROUTID", "ROUT");
            grdCST.Columns.Add("PROCID", "WIP.PROCID");
            grdCST.Columns.Add("LOTTYPE", "LOTTYPE");
            grdCST.Columns.Add("ASSY_LOTID", "조립LOT");
            grdCST.Columns.Add("SPCL_FLAG", "스페셜");
            grdCST.Columns.Add("LOT_DETL_TYPE_CODE", "LOT_DETL_TYPE_CODE");
            grdCST.Columns.Add("ABNORM_TRF_RSN_CODE", "ABNORM_TRF_RSN_CODE");
            grdCST.Columns.Add("DFCT_LIMIT_OVER_FLAG", "전셀불량");
            grdCST.Columns.Add("DFCT_OCCR_EQPTID", "발생설비");
            grdCST.Columns.Add("SPCL_NOTE", "SPCL_NOTE");
            grdCST.Columns.Add("FORM_SPCL_GR_ID", "FORM_SPCL_GR_ID");
            grdCST.Columns.Add("AGING_ISS_SCHD_DTTM,", "출고예정시각");
            grdCST.Columns.Add("SMPL_ISS_TYPE_CODE", "샘플출고");
            grdCST.Columns.Add("SCRP_TRAY_FLAG", "크렉트레이");
            grdCST.Columns.Add("TRAY_CNVR_BCR_SCAN_COUNT", "BCR횟수");
            grdCST.Columns.Add("UPDDTTM", "업데이트일시");


            grdCST.Columns[0].Width = 60; grdCST.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // SEQ
            grdCST.Columns[1].Width = 100; grdCST.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // CSTID
            grdCST.Columns[2].Width = 100; grdCST.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // 대표 트레이
            grdCST.Columns[3].Width = 60; grdCST.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 단
            grdCST.Columns[4].Width = 60; grdCST.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 공실구분
            grdCST.Columns[5].Width = 60; grdCST.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 타입
            grdCST.Columns[6].Width = 150; grdCST.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // LOT
            grdCST.Columns[7].Width = 100; grdCST.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // WIPSTAT
            grdCST.Columns[8].Width = 150; grdCST.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // RACK
            grdCST.Columns[9].Width = 110; grdCST.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // EQPT
            grdCST.Columns[10].Width = 150; grdCST.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // PORT
            grdCST.Columns[11].Width = 100; grdCST.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // ROUT
            grdCST.Columns[12].Width = 100; grdCST.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // procid
            grdCST.Columns[13].Width = 100; grdCST.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // LOTTYPE
            grdCST.Columns[14].Width = 100; grdCST.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // 조립LOT
            grdCST.Columns[15].Width = 80; grdCST.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // 스페셜구분
            grdCST.Columns[16].Width = 80; grdCST.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // LOT DELT TYPE CODE
            grdCST.Columns[17].Width = 150; grdCST.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;  // ABNORM_TRF_RSN_CODE
            grdCST.Columns[18].Width = 100; grdCST.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // DFCT LIMIT OVER FLAG, 전셀불량
            grdCST.Columns[19].Width = 100; grdCST.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // DFCT OCCR_EQPTID, 설비
            grdCST.Columns[20].Width = 150; grdCST.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // SPCL NOTE
            grdCST.Columns[21].Width = 80; grdCST.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // FORM_SPCL_GR_ID
            grdCST.Columns[22].Width = 150; grdCST.Columns[22].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // 출고예정시각
            grdCST.Columns[23].Width = 60; grdCST.Columns[23].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // 샘플출고
            grdCST.Columns[24].Width = 80; grdCST.Columns[24].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // 크렉트레이
            grdCST.Columns[25].Width = 80; grdCST.Columns[25].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // BCR COUNT
            grdCST.Columns[26].Width = 150; grdCST.Columns[26].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // UPDDTTM


            //for (int i = 0; i < 22; i++)
            //{
            //    grdCST.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            //}
            grdCST.Columns[0].Visible = false;

            string cquery = "SELECT C.CSTID,                    C.CSTSTAT,                      C.LOAD_REP_CSTID,   ";
            cquery += "             C.CST_LOAD_LOCATION_CODE,   C.CURR_RACK_ID,                 C.CURR_LOTID,      C.ABNORM_TRF_RSN_CODE,  ";
            cquery += "             C.EQPT_CUR AS EQPTID,       C.PORT_CUR AS PORT_ID,          W.ROUTID,           W.WIPSTAT,      ";
            cquery += "             L.LOTTYPE,                  WA.DAY_GR_LOTID AS ASSY_LOTID,  WA.SPCL_FLAG,       WA.SMPL_ISS_TYPE_CODE, ";
            cquery += "             WA.LOT_DETL_TYPE_CODE,      WA.DFCT_LIMIT_OVER_FLAG,        WA.SPCL_NOTE,       ";
            cquery += "             WA.FORM_SPCL_GR_ID,         W.PROCID,                       C.TRAY_TYPE_CODE,   ";
            cquery += "             CONVERT(CHAR(23), C.UPDDTTM, 20) AS UPDDTTM,                WA.DFCT_OCCR_EQPTID, CONVERT(CHAR(23),WA.AGING_ISS_SCHD_DTTM, 20) AS AGING_ISS_SCHD_DTTM , ";
            cquery += "             WA.SCRP_TRAY_FLAG,          WA.TRAY_CNVR_BCR_SCAN_COUNT     ";
            cquery += "  FROM Carrier C with(nolock) ";
            cquery += "       LEFT JOIN WIP W WITH(NOLOCK) ON C.CURR_LOTID = W.LOTID ";
            cquery += "       LEFT JOIN WIPATTR WA WITH(NOLOCK) ON WA.LOTID = W.LOTID ";
            cquery += "       LEFT JOIN LOT L WITH(NOLOCK) ON L.LOTID = WA.LOTID ";
            cquery += " WHERE (LOAD_REP_CSTID LIKE '%" + CSTID + "%' or C.CSTID LIKE '%" + CSTID + "%')";
            cquery += " ORDER BY UPDDTTM DESC,CST_LOAD_LOCATION_CODE DESC ";
            SqlDataAdapter R = new SqlDataAdapter(cquery, cstr);
            ArrayList ar = new ArrayList();
            DataSet ds = new DataSet();
            R.Fill(ds);



            int idx = 0; string routid = ""; string dfct = "F";string scrp = "N";
            grdCST.Rows.Clear();
            grdCstHist.Rows.Clear();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        idx++;
                        string[] data = new string[] {
                                idx.ToString(),
                                dr["CSTID"].ToString(),
                                dr["LOAD_REP_CSTID"].ToString(),
                                dr["CST_LOAD_LOCATION_CODE"].ToString(),
                                dr["CSTSTAT"].ToString(),
                                dr["TRAY_TYPE_CODE"].ToString(),
                                dr["CURR_LOTID"].ToString(),
                                dr["WIPSTAT"].ToString(),
                                dr["CURR_RACK_ID"].ToString(),
                                dr["EQPTID"].ToString(),
                                dr["PORT_ID"].ToString(),
                                dr["ROUTID"].ToString(),
                                dr["PROCID"].ToString(),
                                dr["LOTTYPE"].ToString(),
                                dr["ASSY_LOTID"].ToString(),        // 조립 lot
                                dr["SPCL_FLAG"].ToString(),         // 특별구분
                                dr["LOT_DETL_TYPE_CODE"].ToString(),
                                dr["ABNORM_TRF_RSN_CODE"].ToString(),
                                dr["DFCT_LIMIT_OVER_FLAG"].ToString(),
                                dr["DFCT_OCCR_EQPTID"].ToString(),
                                dr["SPCL_NOTE"].ToString(),
                                dr["FORM_SPCL_GR_ID"].ToString(),
                                dr["AGING_ISS_SCHD_DTTM"].ToString(),
                                dr["SMPL_ISS_TYPE_CODE"].ToString(),
                                dr["SCRP_TRAY_FLAG"].ToString(),
                                dr["TRAY_CNVR_BCR_SCAN_COUNT"].ToString(),
                                dr["UPDDTTM"].ToString(),
                            };
                        grdCST.Rows.Add(data);

                        if (dfct == "F") { dfct = dr["DFCT_LIMIT_OVER_FLAG"].ToString(); }
                        if (routid == "") { routid = dr["ROUTID"].ToString(); }
                        if (scrp == "N") { dfct = dr["SCRP_TRAY_FLAG"].ToString(); }
                        if (idx == 2)
                        {
                            //--------------------------------------------------------------------------------------------------------------------------------------------------
                            if (grdCST.Rows[0].Cells["CSTSTAT"].Value.ToString() != grdCST.Rows[1].Cells["CSTSTAT"].Value.ToString() ||
                                grdCST.Rows[0].Cells["TRAY_TYPE_CODE"].Value.ToString() != grdCST.Rows[1].Cells["TRAY_TYPE_CODE"].Value.ToString()) // cststat, 트레이 타입
                            {
                                grdCST.Rows[0].DefaultCellStyle.BackColor = Color.LightPink;
                                grdCST.Rows[1].DefaultCellStyle.BackColor = Color.LightGreen;
                                MessageBox.Show("트레이종류(실공, 타입)가 서로 다릅니다.");
                                return;
                            }
                            //--------------------------------------------------------------------------------------------------------------------------------------------------
                            if (grdCST.Rows[0].Cells["SPCL_FLAG"].Value.ToString() == "Y")
                            {
                                if (grdCST.Rows[0].Cells["ASSY_LOTID"].Value.ToString() != grdCST.Rows[1].Cells["ASSY_LOTID"].Value.ToString() ||
                                    grdCST.Rows[0].Cells["ROUTID"].Value.ToString() != grdCST.Rows[1].Cells["ROUTID"].Value.ToString() ||
                                    grdCST.Rows[0].Cells["PROCID"].Value.ToString() != grdCST.Rows[1].Cells["PROCID"].Value.ToString() ||
                                    grdCST.Rows[0].Cells["SPCL_FLAG"].Value.ToString() != grdCST.Rows[1].Cells["SPCL_FLAG"].Value.ToString() ||
                                    grdCST.Rows[0].Cells["LOTTYPE"].Value.ToString() != grdCST.Rows[1].Cells["LOTTYPE"].Value.ToString() ||
                                    grdCST.Rows[0].Cells["FORM_SPCL_GR_ID"].Value.ToString() != grdCST.Rows[1].Cells["FORM_SPCL_GR_ID"].Value.ToString()) // ||
                                    //|| grdCST.Rows[0].Cells["SPCL_NOTE"].Value.ToString() != grdCST.Rows[1].Cells["SPCL_NOTE"].Value.ToString()) // cststat, 트레이 타입
                                {
                                    grdCST.Rows[0].DefaultCellStyle.BackColor = Color.LightPink;
                                    grdCST.Rows[1].DefaultCellStyle.BackColor = Color.LightGreen;
                                    MessageBox.Show("스페셜 트레이 정보가 맞지 않습니다.");
                                    return;
                                }
                                //--------------------------------------------------------------------------------------------------------------------------------------------------
                                if (grdCST.Rows[0].Cells["ASSY_LOTID"].Value.ToString() != grdCST.Rows[1].Cells["ASSY_LOTID"].Value.ToString() ||
                                grdCST.Rows[0].Cells["ROUTID"].Value.ToString() != grdCST.Rows[1].Cells["ROUTID"].Value.ToString() ||
                                grdCST.Rows[0].Cells["PROCID"].Value.ToString() != grdCST.Rows[1].Cells["PROCID"].Value.ToString() ||
                                grdCST.Rows[0].Cells["SPCL_FLAG"].Value.ToString() != grdCST.Rows[1].Cells["SPCL_FLAG"].Value.ToString() ||
                                grdCST.Rows[0].Cells["LOTTYPE"].Value.ToString() != grdCST.Rows[1].Cells["LOTTYPE"].Value.ToString() ||
                                grdCST.Rows[0].Cells["FORM_SPCL_GR_ID"].Value.ToString() != grdCST.Rows[1].Cells["FORM_SPCL_GR_ID"].Value.ToString()) // || // 스페셜그룹ID
                                //grdCST.Rows[0].Cells["SPCL_NOTE"].Value.ToString() != grdCST.Rows[1].Cells["SPCL_NOTE"].Value.ToString())               // 스페셜 노트
                                {
                                    grdCST.Rows[0].DefaultCellStyle.BackColor = Color.LightPink;
                                    grdCST.Rows[1].DefaultCellStyle.BackColor = Color.LightGreen;
                                    MessageBox.Show("UP DOWN 트레이 정보가 맞지 않습니다.");
                                    return;
                                }
                            }
                        }
                    }
                    if (dfct == "Y")
                    {
                        MessageBox.Show("전셀 불량 트레이 입니다.");
                        return;
                    }
                    if (scrp == "Y")
                    {
                        MessageBox.Show("크렉 트레이 입니다.");
                        return;
                    }
                }
            }
        }
        /// <summary>
        /// 트레이 이력 조회
        /// </summary>
        private void CST_Hist()
        {
            string cstr = "Data Source=10.95.9.59,7433;Initial catalog=ESGM_BMES_FORM_P01;User ID=rtd_app;Password=##r51T1980D@!";

            string cquery = " SELECT   ";
            cquery += "              CSTID ";
            cquery += "            , FROM_EQPTID ";
            cquery += "            , FROM_PORT_iD ";
            cquery += "            , TO_EQPTID ";
            cquery += "            , TO_PORT_ID ";
            cquery += "            , CSTSTAT ";
            cquery += "            , RTD_RULE_ID ";
            cquery += "            , CMD_STAT_CODE ";
            cquery += "            , INSUSER ";
            cquery += "            , CONVERT(CHAR(23), INSDTTM, 20) AS INSDTTM ";
            cquery += "            , CONVERT(CHAR(23), UPDDTTM, 20) AS UPDDTTM ";
            cquery += "            , (CASE WHEN (DATEDIFF(minute, INSDTTM, GETDATE())>=60) THEN '1' ELSE 'O' END)  AS CMDCHK ";
            cquery += " FROM TB_MHS_TRF_CMD_HIST with(nolock) ";
            cquery += " WHERE CSTID = '" + CSTID + "'";
            //if (txtCST.Text != "")
            //{
            //    //cquery += " WHERE DATEDIFF(HOUR, UPDDTTM, GETDATE())<=24 ";
            //    cquery += " WHERE CSTID = '" + txtCST.Text + "'";
            //}
            cquery += " ORDER BY UPDDTTM DESC ";
            SqlDataAdapter R = new SqlDataAdapter(cquery, cstr);


            ArrayList ar = new ArrayList();
            DataSet ds = new DataSet();
            R.Fill(ds);
            int idx = 0;

            grdCstHist.Columns.Clear();
            grdCstHist.Columns.Add("SEQ", "순번");
            grdCstHist.Columns.Add("CSTID", "CSTID");
            grdCstHist.Columns.Add("FROM_EQPTID", "요청설비");
            grdCstHist.Columns.Add("FROM_PORT_ID", "요청포트");
            grdCstHist.Columns.Add("TO_EQPTID", "대상설비");
            grdCstHist.Columns.Add("TO_PORT_ID", "대상포트");
            grdCstHist.Columns.Add("CSTSTAT", "상태");
            grdCstHist.Columns.Add("RTD_RULE_ID", "RULE");
            grdCstHist.Columns.Add("CMD_STAT_CODE", "진행상태");
            grdCstHist.Columns.Add("INSUSER", "사용자");
            grdCstHist.Columns.Add("INSDTTM", "등록");
            grdCstHist.Columns.Add("UPDDTTM", "업데이트");

            grdCstHist.Columns[0].Width = 80; grdCstHist.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdCstHist.Columns[1].Width = 100; grdCstHist.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdCstHist.Columns[2].Width = 120; grdCstHist.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grdCstHist.Columns[3].Width = 160; grdCstHist.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grdCstHist.Columns[4].Width = 120; grdCstHist.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grdCstHist.Columns[5].Width = 160; grdCstHist.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grdCstHist.Columns[6].Width = 80; grdCstHist.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdCstHist.Columns[7].Width = 150; grdCstHist.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grdCstHist.Columns[8].Width = 150; grdCstHist.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grdCstHist.Columns[9].Width = 130; grdCstHist.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdCstHist.Columns[10].Width = 160; grdCstHist.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdCstHist.Columns[11].Width = 160; grdCstHist.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        idx++;
                        string[] data = new string[] {
                            idx.ToString(),
                            dr["CSTID"].ToString(),
                            dr["FROM_EQPTID"].ToString(),
                            dr["FROM_PORT_ID"].ToString(),
                            dr["TO_EQPTID"].ToString(),
                            dr["TO_PORT_ID"].ToString(),
                            dr["CSTSTAT"].ToString(),
                            dr["RTD_RULE_ID"].ToString(),
                            dr["CMD_STAT_CODE"].ToString(),
                            dr["INSUSER"].ToString(),
                            dr["INSDTTM"].ToString(),
                            dr["UPDDTTM"].ToString(),
                        };
                        grdCstHist.Rows.Add(data);
                        if (dr["CMDCHK"].ToString() == "1" && (dr["CMD_STAT_CODE"].ToString() != "ABNORMAL_END" && dr["CMD_STAT_CODE"].ToString() != "NORMAL_END"))
                        {
                            grdCstHist.Rows[grdCstHist.RowCount - 1].DefaultCellStyle.BackColor = Color.FromArgb(250, 250, 210); //(216, 191, 216);
                        }
                    }
                }
            }
        }

        private void FrmTrayInfo_Load(object sender, EventArgs e)
        {
            CST_List();
            CST_Hist();
        }

        private void FrmTrayInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
