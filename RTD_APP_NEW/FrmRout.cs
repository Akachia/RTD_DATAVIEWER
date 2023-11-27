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
    public partial class FrmRout : Form
    {
        public string ROUTID { get; set; }
        public string PROCID { get; set; }

        public FrmRout()
        {
            InitializeComponent();
        }

        private void FrmRout_Load(object sender, EventArgs e)
        {
            grdRout.Columns.Clear();
            grdRout.Columns.Add("SEQ", "순번");
            grdRout.Columns.Add("PROCID", "PROC");
            grdRout.Columns.Add("PROCNAME", "PROC NAME");
            grdRout.Columns.Add("LANE_ID", "LANE");
            grdRout.Columns[0].Width = 70; grdRout.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdRout.Columns[1].Width = 80; grdRout.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdRout.Columns[2].Width = 200; grdRout.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grdRout.Columns[3].Width = 80; grdRout.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DispRout();
        }

        private void DispRout()
        {
            if (ROUTID == "") return;
            string cstr = "Data Source=10.95.9.59,7433;Initial catalog=ESGM_BMES_FORM_P01;User ID=rtd_app;Password=##r51T1980D@!";

            string cquery = " SELECT   ";
            cquery += "              R.ROUTID ";
            cquery += "            , RP.PROC_SEQNO ";
            cquery += "            , RP.PROCID ";
            cquery += "            , P1.PROCDESC ";
            cquery += "            , RP.LANE_ID";
            //cquery += "            , PE.EQPTID";
            //cquery += "            , EA.S71 AS EQPT_LANE_ID";
            cquery += " FROM TB_MMD_FORM_ROUT               R  with(nolock) ";
            cquery += " INNER JOIN TB_MMD_FORM_ROUT_PROC    RP with(nolock) ON R.ROUTID = RP.ROUTID ";
            //cquery += " INNER JOIN PROCESSEQUIPMENT         PE with(nolock) ON PE.PROCID = RP.PROCID";
            //cquery += " INNER JOIN EQUIPMENT                E  with(nolock) ON E.EQPTID = PE.EQPTID  AND E.EQSGID = R.EQSGID ";
            //cquery += " INNER JOIN EQUIPMENTATTR            EA with(nolock) ON EA.EQPTID = E.EQPTID";
            cquery += " INNER JOIN Process                  P1 with(nolock) ON P1.PROCID = RP.PROCID";
            cquery += " WHERE R.ROUTID = '" + ROUTID + "'";
            cquery += "   AND RP.USE_FLAG = 'Y' ";
            cquery += " ORDER BY RP.PROC_SEQNO  ";
            SqlDataAdapter R = new SqlDataAdapter(cquery, cstr);


            ArrayList ar = new ArrayList();
            DataSet ds = new DataSet();
            R.Fill(ds);
            int idx = 0;

            grdRout.Rows.Clear();

            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        idx++;
                        string[] data = new string[] {
                                dr["PROC_SEQNO"].ToString(),
                                dr["PROCID"].ToString(),
                                dr["PROCDESC"].ToString(),
                                dr["LANE_ID"].ToString()
                            };
                        grdRout.Rows.Add(data);
                        if(dr["PROCID"].ToString() ==PROCID)
                        {
                            grdRout.Rows[grdRout.RowCount - 1].DefaultCellStyle.BackColor = Color.FromArgb(250, 250, 210); //(216, 191, 216);
                        }
                    }
                }
            }
        }
    }
}
