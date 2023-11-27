using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Collections;
using System.Xml;

namespace RTD_APP_NEW
{
    public partial class FrmCSTdeny : Form
    {
        private string txtCST;
        private string cstr;
        public FrmCSTdeny(string txtCST, string cstr)
        {
            InitializeComponent();
            this.txtCST = txtCST;
            this.cstr = cstr;
        }

        private void FrmCSTdeny_Load(object sender, EventArgs e)
        {
            grdDeny.Rows.Clear();
            grdDeny.Columns.Clear();
            grdDeny.Columns.Add("CSTID_Deny", "캐리어");
            grdDeny.Columns.Add("EQPTID_Deny", "요청설비");
            grdDeny.Columns.Add("PORT_ID_Deny", "요청포트");
            grdDeny.Columns.Add("ABNORM_ISS_RSN_CODE_Deny", "설명");
            grdDeny.Columns.Add("INSDTTM_Deny", "요청시각");
            grdDeny.Columns.Add("UPDDTTM_Deny", "수정시각");
            grdDeny.Columns.Add("INSUSER_Deny", "요청자");
            grdDeny.Columns.Add("UPDUSER_Deny", "수정자");
            grdDeny.Columns.Add("HIST_SEQNO_Deny", "순번이력");

            grdDeny.Columns[0].Width = 100; grdDeny.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 캐리어
            grdDeny.Columns[1].Width = 120; grdDeny.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 요청설비
            grdDeny.Columns[2].Width = 160; grdDeny.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 요청포트
            grdDeny.Columns[3].Width = 250; grdDeny.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 설명
            grdDeny.Columns[4].Width = 120; grdDeny.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 요청시각
            grdDeny.Columns[5].Width = 120; grdDeny.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 수정시각
            grdDeny.Columns[6].Width = 100; grdDeny.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 요청자
            grdDeny.Columns[7].Width = 100; grdDeny.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 수정자
            grdDeny.Columns[8].Width = 100; grdDeny.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 순번이력

            string cquery = "SELECT ";
            cquery += "D.CSTID AS CSTID_Deny, "; //캐리어
            cquery += "D.EQPTID AS EQPTID_Deny, "; //요청설비
            cquery += "D.PORT_ID AS PORT_ID_Deny, "; //요청포트
            cquery += "D.ABNORM_ISS_RSN_CODE AS ABNORM_ISS_RSN_CODE_Deny, "; //설명
            cquery += "CONVERT(CHAR(23), D.INSDTTM, 20) AS INSDTTM_Deny, "; //요청시각
            cquery += "CONVERT(CHAR(23), D.UPDDTTM, 20) AS UPDDTTM_Deny, "; //수정시각
            cquery += "D.INSUSER AS INSUSER_Deny, "; //요청자
            cquery += "D.UPDUSER AS UPDUSER_Deny, "; //수정자
            cquery += "D.HIST_SEQNO AS HIST_SEQNO_Deny "; //순번이력

            cquery += "FROM TB_MHS_ABNORM_ISS_HIST D WITH(NOLOCK) "; //Table
            cquery += "WHERE 1 = 1 "; //조건문
            if (txtCST != "")
            {
                cquery += "AND D.CSTID LIKE "; //조건
                cquery += " '" + txtCST + "' "; //조건
            }
            //cquery += "AND CONVERT(CHAR(10), D.INSDTTM, 20) BETWEEN ";//날짜범위
            //cquery += " '" + txtDenysDate.Text + "' AND '" + txtDenyeDate.Text + "' ";//날짜
            cquery += "ORDER BY D.UPDDTTM DESC;";//정렬

            SqlDataAdapter R = new SqlDataAdapter(cquery, cstr);
            ArrayList ar = new ArrayList();
            DataSet ds1 = new DataSet();
            R.Fill(ds1);

            if (ds1 != null)
            {
                if (ds1.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds1.Tables[0].Rows)
                    {
                        string[] data = new string[]
                        {
                            dr["CSTID_Deny"].ToString(),
                            dr["EQPTID_Deny"].ToString(),
                            dr["PORT_ID_Deny"].ToString(),
                            dr["ABNORM_ISS_RSN_CODE_Deny"].ToString(),
                            dr["INSDTTM_Deny"].ToString(),
                            dr["UPDDTTM_Deny"].ToString(),
                            dr["INSUSER_Deny"].ToString(),
                            dr["UPDUSER_Deny"].ToString(),
                            dr["HIST_SEQNO_Deny"].ToString(),
                    };
                        grdDeny.Rows.Add(data);
                    }
                }
            }
        }
    }
    }

