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
    public partial class FrmSubList : Form
    {
        public FrmSubList()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Disp_List();
        }
        private void Disp_List()
        {
            // 설비레벨:: CONVEYOR:C, STOCKER:C, HPCD:M, JIG:M, DEGAS:C, 충방:M, 대방:M, SELECTOR:M, EOL:C
            // EQGRID: CNV, DEG, EOL, FOR, HPC, JGF, MCS, OHS, SEL, STO
            // S70: 1(FORMATION),3(상온),4(고온),5(EOL),6(SELECTOR),7(출하),8(전용OCV),9(프리),D(DEGAS),E(공트레이),J(JIG FORMATION),U(HPCD)

            string cquery = " WITH TMP_EQPT_GRID AS (";
            cquery += " SELECT '9' AS GR_ID, N'PRE STO' AS GRNM,          '2' AS DISP_ORDER UNION ALL  ";
            cquery += " SELECT 'U' AS GR_ID, N'HPCD' AS GRNM,             '3' AS DISP_ORDER UNION ALL   ";
            cquery += " SELECT 'J' AS GR_ID, N'JIG FORMATION' AS GRNM,    '4' AS DISP_ORDER UNION ALL  ";
            cquery += " SELECT '4' AS GR_ID, N'고온 STO' AS GRNM,         '5' AS DISP_ORDER UNION ALL  ";
            cquery += " SELECT '3' AS GR_ID, N'상온 STO' AS GRNM,         '6' AS DISP_ORDER UNION ALL  ";
            cquery += " SELECT 'D' AS GR_ID, N'DEGAS' AS GRNM,            '7' AS DISP_ORDER UNION ALL  ";
            cquery += " SELECT '7' AS GR_ID, N'출하 STO' AS GRNM,          '8' AS DISP_ORDER UNION ALL  ";
            cquery += " SELECT '8' AS GR_ID, N'OCV' AS GRNM,              '9' AS DISP_ORDER UNION ALL  ";
            cquery += " SELECT '1' AS GR_ID, N'충방전' AS GRNM,           '10' AS DISP_ORDER UNION ALL  ";
            cquery += " SELECT '6' AS GR_ID, N'SELECTOR' AS GRNM,         '11' AS DISP_ORDER UNION ALL  ";
            cquery += " SELECT '5' AS GR_ID, N'EOL' AS GRNM,              '12' AS DISP_ORDER UNION ALL  ";
            cquery += " SELECT 'E' AS GR_ID, N'EMPTY STO' AS GRNM,        '13' AS DISP_ORDER  ";
            cquery += " ), ";
            cquery += " CMD_LIST AS ( ";
            cquery += " SELECT   ";
            cquery += "      E.EQPTID                AS EQPTID ";
            cquery += "      , EA.S70                  AS GR_ID ";
            cquery += "      , CH.TO_PORT_ID        AS PORT_ID ";
            cquery += "      , COUNT(CH.CMD_SEQNO)  AS CMD_CNT ";
            cquery += " FROM TB_MHS_TRF_CMD_HIST CH with(nolock) ";
            cquery += "   INNER JOIN EQUIPMENT E with(nolock) ON CH.TO_EQPTID = E.EQPTID ";
            cquery += "   INNER JOIN EQUIPMENTATTR EA with(nolock) ON E.EQPTID = EA.EQPTID ";
            cquery += " WHERE CH.CMD_STAT_CODE in ('MOVING', 'RECEIVE') ";
            cquery += "   AND DATEDIFF(HOUR, CH.UPDDTTM, GETDATE()) <= 72 ";
            if (chkRule.Checked == true) cquery += "   AND ISNULL(CH.RTD_RULE_ID,'') <> '' ";   // RTD 반송만
            cquery += "   AND CH.INSUSER <> 'MCS(SYNC)' ";
            cquery += " GROUP BY E.EQPTID, EA.S70, CH.TO_PORT_ID ";
            cquery += " ) ";
            cquery += " SELECT ";
            cquery += "        CASE WHEN CHARINDEX('PKG', A.EQPTID) > 0 THEN 'PKG' ";
            cquery += "             WHEN CHARINDEX('CNV', A.EQPTID) > 0 THEN 'CNV' ";
            cquery += "             WHEN CHARINDEX('STO', A.EQPTID) > 0 THEN 'STO' ";
            cquery += "             WHEN CHARINDEX('FOR', A.EQPTID) > 0 THEN N'충방전' ";
            cquery += "             ELSE B.GRNM   ";
            cquery += "        END AS GRNM        ";
            cquery += "        , B.DISP_ORDER     ";
            cquery += "        , A.GR_ID          ";
            cquery += "        , A.PORT_ID        ";
            cquery += "        , ISNULL(BUF.MAX_TRF_QTY, 0) AS MAX_TRF_QTY ";
            cquery += "        , ISNULL(A.CMD_CNT, 0)  AS CMD_CNT        ";
            cquery += "  FROM CMD_LIST A          ";
            cquery += "  INNER JOIN ( ";
            cquery += "     SELECT P.PORT_ID ";
            cquery += "            , IIF(P.MAX_TRF_QTY_MNGT_FLAG = 'Y', CP.MAX_TRF_QTY, NULL) AS MAX_TRF_QTY ";
            cquery += "      FROM TB_MCS_PORT P WITH(NOLOCK) ";
            cquery += "       LEFT OUTER JOIN TB_MCS_CURR_PORT CP WITH(NOLOCK) ON P.PORT_ID = CP.PORT_ID ";
            cquery += "  ) BUF ON BUF.PORT_ID = A.PORT_ID ";
            cquery += "  LEFT JOIN TMP_EQPT_GRID B ON A.GR_ID = B.GR_ID ";
            cquery += " ORDER BY A.CMD_CNT DESC, B.DISP_ORDER ";

            //CSTID, LOTID, ACTID, ACTDTTM, ROUTID, FLOWID, PROCID, EQSGID, EQPTID, WIPSTAT, WIPSTAT_PV, USERID, INSDTTM, UPTDTTM
            grdList.Columns.Clear();
            grdList.Columns.Add("SEQ", "순번");
            grdList.Columns.Add("GRNM", "GROUP");
            grdList.Columns.Add("PORT_ID", "PORT");
            grdList.Columns.Add("MAX_TRF_CNT", "버퍼");
            grdList.Columns.Add("CMD_CNT", "수량");

            grdList.Columns[0].Width = 60; grdList.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdList.Columns[1].Width = 110; grdList.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grdList.Columns[2].Width = 160; grdList.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grdList.Columns[3].Width = 60; grdList.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdList.Columns[4].Width = 60; grdList.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //for (int i = 0; i < 3; i++)
            //{
            //    grdList.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            //}

            string cstr = "Data Source=10.95.9.59,7433;Initial catalog=ESGM_BMES_FORM_P01;User ID=rtd_app;Password=##r51T1980D@!";


            SqlDataAdapter R = new SqlDataAdapter(cquery, cstr);
            ArrayList ar = new ArrayList();
            DataSet ds = new DataSet();
            R.Fill(ds);

            int idx = 0;
            grdList.Rows.Clear();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        idx++;
                        string[] data = new string[] {
                                idx.ToString(),
                                dr["GRNM"].ToString(),
                                dr["PORT_ID"].ToString(),
                                dr["MAX_TRF_QTY"].ToString(),
                                dr["CMD_CNT"].ToString()
                            };
                        grdList.Rows.Add(data);
                        if (Convert.ToSingle(dr["MAX_TRF_QTY"].ToString()) < Convert.ToSingle(dr["CMD_CNT"].ToString()))
                        {
                            grdList.Rows[grdList.RowCount - 1].DefaultCellStyle.BackColor = Color.OrangeRed;
                        }
                    }
                }
            }
        }

        private void FrmSubList_Load(object sender, EventArgs e)
        {
            Disp_List();
        }
    }
}
