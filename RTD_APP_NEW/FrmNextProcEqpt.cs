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
    public partial class FrmNextProcEqpt : Form
    {
        public string PROCID { get; set; }
        public string LANEID { get; set; }
        public FrmNextProcEqpt()
        {
            InitializeComponent();
        }

        private void FrmNextProcEqpt_Load(object sender, EventArgs e)
        {
            grdStatus.Rows.Clear();
            grdStatus.Columns.Clear();
            grdStatus.Columns.Add("PROCID", "공정");
            grdStatus.Columns.Add("EQGRID", "그룹");
            grdStatus.Columns.Add("EQPTID", "설비");
            grdStatus.Columns.Add("LANE_ID", "LANE");
            grdStatus.Columns.Add("EIOSTAT", "상태");
            grdStatus.Columns.Add("EIOIFMODE", "통신");
            grdStatus.Columns.Add("PORT_ID", "포트");
            grdStatus.Columns.Add("MAX_TRF_QTY", "버퍼");
            grdStatus.Columns.Add("CMD_QTY", "반송");

            grdStatus.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grdStatus.Columns[0].Width = 80; grdStatus.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 공정
            grdStatus.Columns[1].Width = 80; grdStatus.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 그룹
            grdStatus.Columns[2].Width = 120; grdStatus.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // 설비
            grdStatus.Columns[3].Width = 80; grdStatus.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // LANE
            grdStatus.Columns[4].Width = 60; grdStatus.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 상태
            grdStatus.Columns[5].Width = 60; grdStatus.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 통신
            grdStatus.Columns[6].Width = 140; grdStatus.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // 포트
            grdStatus.Columns[7].Width = 60; grdStatus.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;     // 버퍼
            grdStatus.Columns[8].Width = 60; grdStatus.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;     // 반송

            Disp_Status();
        }

        private void Disp_Status()
        {
            string cstr = "Data Source=10.95.9.59,7433;Initial catalog=ESGM_BMES_FORM_P01;User ID=rtd_app;Password=##r51T1980D@!";

            string cQuery = "";
            cQuery = "SELECT PE.PROCID, E.EQGRID, PE.EQPTID, EA.S71 AS LANE_ID, EIO.EIOSTAT, EIO.EIOIFMODE, CP.PORT_ID ";
            cQuery += "      ,CP.MAX_TRF_QTY, ISNULL(CMD.CMD_QTY, 0) AS CMD_QTY ";
            cQuery += "   FROM PROCESSEQUIPMENT PE WITH(NOLOCK) ";
            cQuery += "   INNER JOIN EQUIPMENT E WITH(NOLOCK) ON E.EQPTID = PE.EQPTID AND E.EQPTIUSE = 'Y' ";
            cQuery += "   INNER JOIN EQUIPMENTSEGMENT ES WITH(NOLOCK) ON ES.EQSGID = E.EQSGID ";
            cQuery += "   INNER JOIN EQUIPMENTATTR    EA WITH(NOLOCK) ON EA.EQPTID = E.EQPTID ";
            cQuery += "   INNER JOIN EIO     EIO WITH(NOLOCK) ON EIO.EQPTID = E.EQPTID ";
            cQuery += "   INNER JOIN TB_MCS_PORT MP WITH(NOLOCK) ON MP.EQPTID = E.EQPTID ";
            cQuery += "   INNER JOIN TB_MCS_CURR_PORT CP WITH(NOLOCK) ON CP.PORT_ID = MP.PORT_ID ";
            cQuery += "   LEFT JOIN ( SELECT TO_PORT_ID, COUNT(CSTID) AS CMD_QTY ";
            cQuery += "                 FROM TB_MHS_TRF_CMD WITH(NOLOCK) ";
            cQuery += "                WHERE CMD_STAT_CODE IN ('RECEIVE','MOVING') ";
            cQuery += "              GROUP BY TO_PORT_ID ";
            cQuery += "   ) AS CMD ON CMD.TO_PORT_ID = MP.PORT_ID ";
            cQuery += "   WHERE PE.PROCID = '" + PROCID + "'";
            cQuery += "     AND EA.S71 LIKE '" + (LANEID.Substring(LANEID.Length - 1) == "0" ? LANEID.Substring(0, 5) + "%" : LANEID) + "'";
            cQuery += "     AND PE.USE_FLAG = 'Y' ";
            cQuery += "   ORDER BY CP.PORT_ID   ";

            SqlDataAdapter R = new SqlDataAdapter(cQuery, cstr);
            ArrayList ar = new ArrayList();
            DataSet ds = new DataSet();
            R.Fill(ds);

            //int idx = 0;
            string EQGRID = "";
            string EQPTID = "";

            grdStatus.Rows.Clear();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        EQGRID = dr["EQGRID"].ToString();
                        EQPTID = dr["EQPTID"].ToString();

                        string[] data = new string[] {
                                dr["PROCID"].ToString(),
                                dr["EQGRID"].ToString(),
                                dr["EQPTID"].ToString(),
                                dr["LANE_ID"].ToString(),
                                dr["EIOSTAT"].ToString(),
                                dr["EIOIFMODE"].ToString(),
                                dr["PORT_ID"].ToString(),
                                dr["MAX_TRF_QTY"].ToString(),
                                dr["CMD_QTY"].ToString()
                        };
                        if (EQGRID == "DEG")
                        {
                            if (EQPTID.Length == 11 ) grdStatus.Rows.Add(data);
                        }
                        else if (EQGRID == "EOL")
                        {
                            if (EQPTID.Length == 11 && dr["PORT_ID"].ToString().IndexOf("-PL1") >= 0) grdStatus.Rows.Add(data);
                        }
                        else
                        {
                            grdStatus.Rows.Add(data);
                        }
                        if (dr["MAX_TRF_QTY"].ToString() == "0")
                        {
                            grdStatus.Rows[grdStatus.RowCount - 1].DefaultCellStyle.BackColor = Color.GreenYellow;
                        }

                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Disp_Status();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
