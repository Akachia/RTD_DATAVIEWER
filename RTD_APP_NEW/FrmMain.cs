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
using Oracle.ManagedDataAccess;

using System.Data.OleDb;
using System.Collections;
using System.Security.Permissions;
using System.Reflection;
using CustomUtil;
using Dapper;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Threading;
using System.Diagnostics.Eventing.Reader;

namespace RTD_APP_NEW
{
    public partial class FrmMain : Form
    {
        //DataSet dsEQPTGR;
        public const string LastLoginFileName = "RTD_Server.txt";
        public static Dictionary<string, string> list = null;
        public static Dictionary<string, DBConnectionString> strs = null;
        public string _CorrentDbName = String.Empty;
        public string AREAID = "";
        public string PLANTID = "";
        public string cstr = "";
        private XmlData xml;
        Dictionary<string, XmlOptionData> sqlList;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cb_IsTimer.Checked)
            {
                tmr_SearchTransport.Interval = Decimal.ToInt32(nud_searchTime.Value) * 1000;
                if (tmr_SearchTransport.Enabled)
                {
                    tmr_SearchTransport.Stop();
                    btnOK.Text = "Search";
                }
                else 
                { 
                    tmr_SearchTransport.Start();
                    btnOK.Text = "Stop";
                }
            }
            else
            {
                SearchTransportReq();
            }
            
        }
        /// <summary>
        /// 요청 정보
        /// </summary>
        private void ReqList()
        {
            try
            {
                XmlOptionData sqldata = sqlList["ReqList"];
                DynamicParameters parameters = new DynamicParameters();
                //using (var connection = new OracleConnection(cstr))

                string cquery = sqldata.sql;
                if (txtReqCSTID.Text != "")
                {
                    CustomUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 0);
                    parameters.Add("@CSTID", string.Concat("%", txtReqCSTID.Text, "%"));
                    //cquery += "   AND REQ.CSTID = '" + txtReqCSTID.Text + "' ";
                }
                CustomUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 1);
                parameters.Add("@StartDate", txtReqsDate.Text, dbType: DbType.Date);
                parameters.Add("@EndDate", txtReqeDate.Text, dbType: DbType.Date);
                //cquery += "   AND CONVERT(CHAR(10), REQ.INSDTTM, 20) BETWEEN '" + txtReqsDate.Text + "' AND '" + txtReqeDate.Text + "' ";
                if (txtReqEqpt.Text != "")
                {
                    CustomUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 2);
                    parameters.Add("@EQPTID", string.Concat("%", txtReqEqpt.Text, "%"));
                    //cquery += "   AND REQ.EQPTID LIKE '" + txtReqEqpt.Text + "' ";
                }
                if (txtRule.Text != "")
                {
                    CustomUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 3);
                    parameters.Add("@EQPTID", string.Concat("%", txtRule.Text, "%"));
                    //cquery += "   AND REQ.RTD_RULE_ID LIKE '%" + txtRule.Text + "%' ";
                }
                if (chkQUERY.Checked == true)
                {
                    CustomUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 4);
                    // cquery += "   AND REQ.REQ_STAT_CODE = 'QUERY' ";
                }
                CustomUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 5);
                // cquery += "       ORDER BY REQ.CSTID, REQ.UPDDTTM DESC ";

                ShowSqltoDGV(grdReq, cquery, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} : {System.Reflection.MethodBase.GetCurrentMethod().Name}");
            }
        }

        /// <summary>
        /// 오류 목록
        /// </summary>
        private void ErrList()
        {
            try
            {
                XmlOptionData sqldata = sqlList["ErrList"];
                DynamicParameters parameters = new DynamicParameters();
                //using (var connection = new OracleConnection(cstr))

                string cquery = sqldata.sql;

                if (txtErrWord.Text != "")
                {
                    CustomUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 0);
                    parameters.Add("@ErrText", string.Concat("%", txtErrWord.Text, "%"));
                    //cquery += "AND (EXCT_MSG LIKE '%" + txtErrWord.Text + "%' OR EXCT_TYPE LIKE '%" + txtErrWord.Text + "%')";
                }

                CustomUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 1);
                //cquery += " ORDER BY INSDTTM DESC ";
                ShowSqltoDGV(grdErrList, cquery, parameters);
            } catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} : {System.Reflection.MethodBase.GetCurrentMethod().Name}");
            }
        }
        /// <summary>
        /// 캐리어 정보
        /// </summary>
        private void CST_List(String CSTID)
        {
            try
            {
                List<Carrier> carriers = new List<Carrier>();
                if (txtCST.Text == "") { return; }
                if (chkCSTdeny.Checked == true)
                {
                    FrmCSTdeny cstDeny = new FrmCSTdeny(txtCST.Text, cstr);
                    cstDeny.ShowDialog();
                }
                XmlOptionData sqldata = sqlList["CST_List"];

                string cquery = sqldata.sql;
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CSTID", string.Concat("%", CSTID, "%"));
                ShowSqltoDGV(grdCST, cquery, parameters);

                string optQuery = string.Empty;
                DynamicParameters optParameter = new DynamicParameters();
                CustomUtils.AddToOptionalSqlSyntax(ref optQuery, sqldata, 0);

                string errMsg = string.Empty;
                if (grdCST.RowCount < 2)
                {
                    if (grdCST.RowCount == 1)
                    {
                        optParameter.Add("@CSTID1", grdCST.Rows[0].Cells[0].Value);
                        optParameter.Add("@CSTID2", grdCST.Rows[0].Cells[0].Value);
                        using (var connection = new SqlConnection(cstr))
                        //using (var connection = new OracleConnection(cstr))
                        {
                            carriers = connection.Query<Carrier>(cquery, optParameter).ToList();
                        }
                        errMsg = CustomUtils.MakeCSTErrMsg(carriers);

                        MessageBox.Show(errMsg);
                    }
                }
                else
                {
                    optParameter.Add("@CSTID1", grdCST.Rows[0].Cells[0].Value);
                    optParameter.Add("@CSTID2", grdCST.Rows[1].Cells[0].Value);

                    using (var connection = new SqlConnection(cstr))
                    //using (var connection = new OracleConnection(cstr))
                    {
                        carriers = connection.Query<Carrier>(cquery, optParameter).ToList();
                    }
                    errMsg = CustomUtils.MakeCSTErrMsg(carriers);

                    if (errMsg != string.Empty)
                    {
                        MessageBox.Show(errMsg);
                    }
                }
                // using 문을 여러번 쓰는것은 별로 좋지 않는 상황인데... 이거 합리적으로 합치는 방안 고려 필요.

                if (errMsg == CustomUtil.CSTErrMsg.spcCstErr || errMsg == CustomUtil.CSTErrMsg.upDownErr || errMsg == CustomUtil.CSTErrMsg.typeErr)
                {
                    grdCST.Rows[0].DefaultCellStyle.BackColor = Color.LightPink;
                    grdCST.Rows[1].DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} : {System.Reflection.MethodBase.GetCurrentMethod().Name}");
            }
        }

        /// <summary>
        /// 캐리어별 이벤트 목록
        /// </summary>
        private void Event_Hist()
        {
            string Q = "";
            Q = " SELECT TOP 100 ";
            Q += " CSTID ";
            Q += " , CSTSTAT ";
            Q += " , EQPTID ";
            Q += " , PORT_ID ";
            Q += " , RACK_ID ";
            Q += " , EVENT_CODE ";
            Q += " , EVENT_TYPE_CODE ";
            Q += " , TRF_END_CODE ";
            Q += " , FINL_TO_PORT_ID ";
            Q += " , CONVERT(CHAR(23), UPDDTTM, 20) AS UPDDTTM ";
            Q += " FROM TB_MHS_TRF_EVENT_HIST WITH(NOLOCK) ";
            Q += " where DATEDIFF(DAY, getdate(), INSDTTM)<= 1 ";
            Q += " AND CSTID = '" + txtCST.Text + "'";
            Q += " ORDER BY INSDTTM DESC ";

        }
        private void Init()
        {
            //cobTarget.Items.Clear();
            //cobTarget.Items.Add("전체");
            //if (lb_DbName.Text.Contains("FORM"))
            //{
            //    cobTarget.Items.Add("Package");
            //    cobTarget.Items.Add("HPCD");
            //    cobTarget.Items.Add("J/F");
            //    cobTarget.Items.Add("Degas");
            //    cobTarget.Items.Add("Formation");
            //    cobTarget.Items.Add("Discharge");
            //    cobTarget.Items.Add("OCV");
            //    cobTarget.Items.Add("Selector");
            //    cobTarget.Items.Add("Stocker");
            //    cobTarget.Items.Add("EOL");
            //}
            //else if (lb_DbName.Text.Contains("CELL"))
            //{
            //    cobTarget.Items.Add("NND");
            //    cobTarget.Items.Add("Lamination");
            //    cobTarget.Items.Add("Stacking");
            //    cobTarget.Items.Add("Cleaner");
            //    cobTarget.Items.Add("Inspector");
            //    cobTarget.Items.Add("Stocker");
            //    cobTarget.Items.Add("Package");
            //}
            //else if (lb_DbName.Text.Contains("ELTR"))
            //{
            //    cobTarget.Items.Add("Coater");
            //    cobTarget.Items.Add("Roll Press");
            //    cobTarget.Items.Add("Cleaner");
            //    cobTarget.Items.Add("Stocker");
            //}
            //cobTarget.SelectedIndex = 0;

            // 설비 상태
            cobJob.Items.Clear();
            cobJob.Items.Add("전체");
            cobJob.Items.Add("Package");
            cobJob.Items.Add("Conveyor");
            cobJob.Items.Add("Selector");
            cobJob.Items.Add("HPCD");
            cobJob.Items.Add("Degas");
            cobJob.Items.Add("JIG Formation");
            cobJob.Items.Add("Formation & DIS");
            cobJob.Items.Add("Stocker & OCV");
            cobJob.Items.Add("EOL");
            cobJob.SelectedIndex = 0;

            // STOCKER 상태
            cobSTO.Items.Clear();
            cobSTO.Items.Add("PreAging");
            cobSTO.Items.Add("1차 공트레이 스토커");
            cobSTO.Items.Add("Jig Formation");
            cobSTO.Items.Add("고온Aging");
            cobSTO.Items.Add("상온Aging");
            cobSTO.Items.Add("2차 공트레이 스토커");
            cobSTO.Items.Add("출하Aging");
            cobSTO.Items.Add("충방전");
            cobSTO.SelectedIndex = 0;
        }
        /// <summary>
        /// 공정별 설비 상태
        /// </summary>
        private void Job_state()
        {
            if (cobJob.SelectedIndex == -1) return;

            grdState.Columns.Clear();
            grdState.Columns.Add("EQPTID", "설비ID");
            grdState.Columns.Add("EQGRID", "그룹");
            grdState.Columns.Add("LANE_ID", "LANE");
            grdState.Columns.Add("EQPTIUSE", "사용");
            grdState.Columns.Add("EIOSTAT", "상태");
            grdState.Columns.Add("EIOIFMODE", "통신");
            grdState.Columns.Add("MAX_QTY", "버퍼");
            grdState.Columns.Add("CMD_USING_QTY", "실수량");
            grdState.Columns.Add("CMD_EMPTY_QTY", "공수량");
            grdState.Columns.Add("UPDDTTM", "업데이트");


            grdState.Columns[0].Width = 130; grdState.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grdState.Columns[1].Width = 80; grdState.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdState.Columns[2].Width = 100; grdState.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdState.Columns[3].Width = 70; grdState.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdState.Columns[4].Width = 70; grdState.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdState.Columns[5].Width = 80; grdState.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdState.Columns[6].Width = 80; grdState.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdState.Columns[7].Width = 80; grdState.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdState.Columns[8].Width = 80; grdState.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdState.Columns[9].Width = 150; grdState.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            string cquery = " SELECT e.EQPTID, e.EQGRID, e.EQPTIUSE, ei.EIOSTAT, ei.EIOIFMODE, ea.S71 AS LANE_ID  ";
            cquery += "              , ei.EIOCOMSTAT ";
            cquery += "              , CONVERT(VARCHAR(23), ei.UPDDTTM, 20) AS UPDDTTM ";
            cquery += "              , ISNULL(Q.MAX_QTY,0) AS MAX_QTY  ";
            cquery += "              , ISNULL(Q.CMD_USING_QTY,0) AS CMD_USING_QTY ";
            cquery += "              , ISNULL(Q.CMD_EMPTY_QTY,0) AS CMD_EMPTY_QTY ";
            cquery += "  FROM EQUIPMENT e with(nolock) ";
            cquery += "  INNER JOIN EQUIPMENTATTR ea with(nolock) ON E.EQPTID = ea.EQPTID ";
            cquery += "  INNER JOIN EIO ei with(nolock) ON e.EQPTID = ei.EQPTID ";
            cquery += "  LEFT JOIN (  ";   // 버퍼수량 및 사용수량 조회
            cquery += "             SELECT TOT.EQPTID, TOT.MAX_QTY, CU.CMD_USING_QTY, CE.CMD_EMPTY_QTY   ";
            cquery += "              FROM(   ";
            cquery += "                  SELECT   ";
            cquery += "                      P.EQPTID,   ";
            cquery += "                      ISNULL(sum(CP.MAX_TRF_QTY),0) AS MAX_QTY   ";
            cquery += "                  FROM TB_MCS_PORT(NOLOCK) P   ";
            cquery += "                      INNER JOIN TB_MCS_CURR_PORT(NOLOCK) CP     ON P.PORT_ID = CP.PORT_ID   ";
            cquery += "                  where p.EQPTID like '" + PLANTID + "%'   ";
            cquery += "                  GROUP  BY P.EQPTID   ";
            //cquery += "                  HAVING ISNULL(sum(CP.MAX_TRF_QTY), 0) >= 0   ";
            cquery += "              )  TOT   ";
            cquery += "              LEFT JOIN(   ";
            cquery += "                      SELECT TO_EQPTID, ISNULL(COUNT(CSTID),0) AS CMD_USING_QTY   ";
            cquery += "                          FROM TB_MHS_TRF_CMD WITH(NOLOCK)   ";
            cquery += "                          WHERE CMD_STAT_CODE IN('RECEIVE', 'MOVING')   ";
            cquery += "                          AND CSTSTAT = 'U'   ";
            cquery += "                          AND ISNULL(CNCL_REQ_FLAG, '') NOT IN('Y', 'S')   ";
            cquery += "                          GROUP BY TO_EQPTID   ";
            cquery += "                      ) CU ON TOT.EQPTID = CU.TO_EQPTID   ";
            cquery += "              LEFT JOIN(   ";
            cquery += "                      SELECT TO_EQPTID, ISNULL(COUNT(CSTID),0) AS CMD_EMPTY_QTY   ";
            cquery += "                          FROM TB_MHS_TRF_CMD WITH(NOLOCK)   ";
            cquery += "                          WHERE CMD_STAT_CODE IN('RECEIVE', 'MOVING')   ";
            cquery += "                          AND CSTSTAT = 'E'   ";
            cquery += "                          AND ISNULL(CNCL_REQ_FLAG, '') NOT IN('Y', 'S')   ";
            cquery += "                          GROUP BY TO_EQPTID   ";
            cquery += "                      ) CE ON TOT.EQPTID = CE.TO_EQPTID   ";
            cquery += "   ) Q ON e.EQPTID = Q.EQPTID ";
            cquery += " WHERE 1 = 1";


            //string SortStr = " ORDER BY e.EQPTID ";
            if (lb_DbName.Text.Contains("FORM"))
            {
                switch (cobJob.SelectedIndex)
                {
                    case 0: // All
                        cquery += "   AND ((e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";//PKG
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE E.EQGRID = 'PKG' AND E.EQPTLEVEL = 'C' AND E.EQPTID LIKE '" + PLANTID + "A%' AND E.EQPTIUSE = 'Y' ";
                        cquery += "                     GROUP BY E.EQPTID )) ";
                        cquery += "   OR (e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";//CNV
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE E.EQGRID = 'CNV' AND E.EQPTLEVEL = 'C' AND E.EQPTID LIKE '" + PLANTID + "F%' AND E.EQPTIUSE = 'Y' ";
                        cquery += "                     GROUP BY E.EQPTID )) ";
                        cquery += "   OR (e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";//SEL
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE E.EQGRID = 'SEL' AND E.EQPTLEVEL = 'M' AND E.EQPTID LIKE '" + PLANTID + "F%' AND E.EQPTIUSE = 'Y' ";
                        cquery += "                     GROUP BY E.EQPTID )) ";
                        cquery += "   OR (e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";//HPC
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE E.EQGRID = 'HPC' AND E.EQPTLEVEL = 'M' AND E.EQPTID LIKE '" + PLANTID + "F%' AND E.EQPTIUSE = 'Y' ";
                        cquery += "                     GROUP BY E.EQPTID )) ";
                        cquery += "   OR (e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";//DEG
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE E.EQGRID = 'DEG' AND E.EQPTLEVEL = 'C' AND E.EQPTID LIKE '" + PLANTID + "F%' AND E.EQPTIUSE = 'Y' ";
                        cquery += "                     GROUP BY E.EQPTID )) ";
                        cquery += "   OR (e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";//J/F
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE EA.S70 = 'J' AND E.EQPTLEVEL = 'M' AND E.EQPTID LIKE '" + PLANTID + "FJGF%' AND E.EQPTIUSE = 'Y' AND LEN(E.EQPTID) = 9 ";
                        cquery += "                     GROUP BY E.EQPTID )) ";
                        cquery += "   OR (e.EQPTID LIKE '" + PLANTID + "FFOR%'   AND LEN(e.EQPTID) = 11)";//FOR
                        cquery += "       OR (e.EQPTID LIKE '" + PLANTID + "FDIS%'   AND LEN(e.EQPTID) = 9)";//DIS
                        cquery += "   OR (e.EQPTID LIKE '" + PLANTID + "FSTO%' AND LEN(e.EQPTID) = 11)";//STO
                        cquery += "       OR (e.EQPTID LIKE '" + PLANTID + "FOCV%' AND LEN(e.EQPTID) = 9)";//OCV
                        cquery += "   OR (e.EQPTID LIKE '" + PLANTID + "FEOL%'  AND LEN(e.EQPTID) = 11))";//EOL
                        break;
                    case 1: // Package
                            //cquery += "   AND e.EQPTID LIKE 'U1APKG%'  AND LEN(e.EQPTID) = 11 ";
                        cquery += "   AND e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE E.EQGRID = 'PKG' AND E.EQPTLEVEL = 'C' AND E.EQPTID LIKE '" + PLANTID + "A%' AND E.EQPTIUSE = 'Y' ";
                        cquery += "                     GROUP BY E.EQPTID ) ";
                        break;
                    case 2: // Conveyor
                            //cquery += "   AND (e.EQPTID LIKE 'U1FCNV%' AND LEN(e.EQPTID) = 11)";
                        cquery += "   AND e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE E.EQGRID = 'CNV' AND E.EQPTLEVEL = 'C' AND E.EQPTID LIKE '" + PLANTID + "F%' AND E.EQPTIUSE = 'Y' ";
                        cquery += "                     GROUP BY E.EQPTID ) ";
                        break;
                    case 3: // selector
                            //cquery += "   AND e.EQPTID LIKE 'U1FSEL%'";
                        cquery += "   AND e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE E.EQGRID = 'SEL' AND E.EQPTLEVEL = 'M' AND E.EQPTID LIKE '" + PLANTID + "F%' AND E.EQPTIUSE = 'Y' ";
                        cquery += "                     GROUP BY E.EQPTID ) ";
                        break;
                    case 4: // HPCD
                            //cquery += "   AND e.EQPTID LIKE 'U1FHPC%'  AND LEN(e.EQPTID) = 9 ";
                        cquery += "   AND e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE E.EQGRID = 'HPC' AND E.EQPTLEVEL = 'M' AND E.EQPTID LIKE '" + PLANTID + "F%' AND E.EQPTIUSE = 'Y' ";
                        cquery += "                     GROUP BY E.EQPTID ) ";
                        break;
                    case 5: // DEGAS
                        cquery += "   AND e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE E.EQGRID = 'DEG' AND E.EQPTLEVEL = 'C' AND E.EQPTID LIKE '" + PLANTID + "F%' AND E.EQPTIUSE = 'Y' ";
                        cquery += "                     GROUP BY E.EQPTID ) ";
                        break;
                    case 6: // JIG FORMATION
                            //cquery += "   AND ((e.EQPTID LIKE 'U1FJGF%'   AND LEN(e.EQPTID) = 9) OR  e.EQPTID IN ('U1FSTO11307','U1FSTO11308','U1FSTO11309','U1FSTO11310'))";
                        cquery += "   AND e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE EA.S70 = 'J' AND E.EQPTLEVEL = 'M' AND E.EQPTID LIKE '" + PLANTID + "FJGF%' AND E.EQPTIUSE = 'Y' AND LEN(E.EQPTID) = 9 ";
                        cquery += "                     GROUP BY E.EQPTID ) ";
                        break;
                    case 7: // FORMATION & DISCHARGE
                        cquery += "   AND ((e.EQPTID LIKE '" + PLANTID + "FFOR%'   AND LEN(e.EQPTID) = 11)";
                        cquery += "       OR (e.EQPTID LIKE '" + PLANTID + "FDIS%'   AND LEN(e.EQPTID) = 9))";
                        break;
                    case 8: // STOCKER & OCV
                        cquery += "   AND ((e.EQPTID LIKE '" + PLANTID + "FSTO%' AND LEN(e.EQPTID) = 11)";
                        cquery += "       OR (e.EQPTID LIKE '" + PLANTID + "FOCV%' AND LEN(e.EQPTID) = 9))";
                        break;
                    case 9: // EOL
                        cquery += "   AND (e.EQPTID LIKE '" + PLANTID + "FEOL%'  AND LEN(e.EQPTID) = 11)";
                        //cquery += "    OR (e.EQPTID LIKE 'U1FEOL%05' AND LEN(e.EQPTID) = 11))";
                        break;
                }
            }
            else if (lb_DbName.Text.Contains("CELL"))
            {
                switch (cobJob.SelectedIndex)
                {
                    case 0: // All
                        cquery += "   AND ((e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE E.EQGRID = 'STO' AND E.EQPTLEVEL = 'C' AND E.EQPTID LIKE '" + PLANTID + "A%' AND E.EQPTIUSE = 'Y' ";
                        cquery += "                     GROUP BY E.EQPTID )) ";
                        cquery += "   OR (e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE E.EQGRID = 'CNV' AND E.EQPTLEVEL = 'C' AND E.EQPTID LIKE '" + PLANTID + "A%' AND E.EQPTIUSE = 'Y' ";
                        cquery += "                     GROUP BY E.EQPTID )) ";
                        cquery += "   OR (e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE E.EQGRID = 'OHS' AND E.EQPTLEVEL = 'C' AND E.EQPTID LIKE '" + PLANTID + "A%' AND E.EQPTIUSE = 'Y' ";
                        cquery += "                     GROUP BY E.EQPTID )) ";
                        cquery += "   OR (e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE E.EQGRID = 'NND' AND E.EQPTLEVEL = 'C' AND E.EQPTID LIKE '" + PLANTID + "A%' AND E.EQPTIUSE = 'Y' ";
                        cquery += "                     GROUP BY E.EQPTID )) ";
                        cquery += "   OR (e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE E.EQGRID = 'LAM' AND E.EQPTLEVEL = 'C' AND E.EQPTID LIKE '" + PLANTID + "A%' AND E.EQPTIUSE = 'Y' ";
                        cquery += "                     GROUP BY E.EQPTID )) ";
                        cquery += "   OR (e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE E.EQGRID = 'STK' AND E.EQPTLEVEL = 'C' AND E.EQPTID LIKE '" + PLANTID + "A%' AND E.EQPTIUSE = 'Y' ";
                        cquery += "                     GROUP BY E.EQPTID )) ";
                        cquery += "   OR (e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE E.EQGRID = 'PKG' AND E.EQPTLEVEL = 'C' AND E.EQPTID LIKE '" + PLANTID + "A%' AND E.EQPTIUSE = 'Y' ";
                        cquery += "                     GROUP BY E.EQPTID ))) ";
                        break;
                    case 1: // Stocker
                        cquery += "   AND e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE E.EQGRID = 'STO' AND E.EQPTLEVEL = 'C' AND E.EQPTID LIKE '" + PLANTID + "A%' AND E.EQPTIUSE = 'Y' ";
                        cquery += "                     GROUP BY E.EQPTID ) ";
                        break;
                    case 2: //Conveyor
                        cquery += "   AND e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE E.EQGRID = 'CNV' AND E.EQPTLEVEL = 'C' AND E.EQPTID LIKE '" + PLANTID + "A%' AND E.EQPTIUSE = 'Y' ";
                        cquery += "                     GROUP BY E.EQPTID ) ";
                        break;
                    case 3: //OHS
                        cquery += "   AND e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE E.EQGRID = 'OHS' AND E.EQPTLEVEL = 'C' AND E.EQPTID LIKE '" + PLANTID + "A%' AND E.EQPTIUSE = 'Y' ";
                        cquery += "                     GROUP BY E.EQPTID ) ";
                        break;
                    case 4: //NND
                        cquery += "   AND e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE E.EQGRID = 'NND' AND E.EQPTLEVEL = 'C' AND E.EQPTID LIKE '" + PLANTID + "A%' AND E.EQPTIUSE = 'Y' ";
                        cquery += "                     GROUP BY E.EQPTID ) ";
                        break;
                    case 5: //Lamination
                        cquery += "   AND e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE E.EQGRID = 'LAM' AND E.EQPTLEVEL = 'C' AND E.EQPTID LIKE '" + PLANTID + "A%' AND E.EQPTIUSE = 'Y' ";
                        cquery += "                     GROUP BY E.EQPTID ) ";
                        break;
                    case 6: //Stacking
                        cquery += "   AND e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE E.EQGRID = 'STK' AND E.EQPTLEVEL = 'C' AND E.EQPTID LIKE '" + PLANTID + "A%' AND E.EQPTIUSE = 'Y' ";
                        cquery += "                     GROUP BY E.EQPTID ) ";
                        break;
                    case 7: //Package
                        cquery += "   AND e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE E.EQGRID = 'PKG' AND E.EQPTLEVEL = 'C' AND E.EQPTID LIKE '" + PLANTID + "A%' AND E.EQPTIUSE = 'Y' ";
                        cquery += "                     GROUP BY E.EQPTID ) ";
                        break;
                }
            }
            else if (lb_DbName.Text.Contains("ELTR"))
            {
                switch (cobJob.SelectedIndex)
                {
                    case 0: // All
                        cquery += "   AND ((e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE E.EQGRID = 'STO' AND E.EQPTLEVEL = 'C' AND E.EQPTID LIKE '" + PLANTID + "E%' AND E.EQPTIUSE = 'Y' ";
                        cquery += "                     GROUP BY E.EQPTID )) ";
                        cquery += "   OR (e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE E.EQGRID = 'CNV' AND E.EQPTLEVEL = 'C' AND E.EQPTID LIKE '" + PLANTID + "E%' AND E.EQPTIUSE = 'Y' ";
                        cquery += "                     GROUP BY E.EQPTID )) ";
                        cquery += "   OR (e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE E.EQGRID = 'OHS' AND E.EQPTLEVEL = 'C' AND E.EQPTID LIKE '" + PLANTID + "E%' AND E.EQPTIUSE = 'Y' ";
                        cquery += "                     GROUP BY E.EQPTID )) ";
                        cquery += "   OR (e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE E.EQGRID = 'COT' AND E.EQPTLEVEL = 'C' AND E.EQPTID LIKE '" + PLANTID + "E%' AND E.EQPTIUSE = 'Y' ";
                        cquery += "                     GROUP BY E.EQPTID )) ";
                        cquery += "   OR (e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE E.EQGRID = 'ROL' AND E.EQPTLEVEL = 'C' AND E.EQPTID LIKE '" + PLANTID + "E%' AND E.EQPTIUSE = 'Y' ";
                        cquery += "                     GROUP BY E.EQPTID ))) ";
                        break;
                    case 1: // Stocker
                        cquery += "   AND e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE E.EQGRID = 'STO' AND E.EQPTLEVEL = 'C' AND E.EQPTID LIKE '" + PLANTID + "E%' AND E.EQPTIUSE = 'Y' ";
                        cquery += "                     GROUP BY E.EQPTID ) ";
                        break;
                    case 2: //Conveyor
                        cquery += "   AND e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE E.EQGRID = 'CNV' AND E.EQPTLEVEL = 'C' AND E.EQPTID LIKE '" + PLANTID + "E%' AND E.EQPTIUSE = 'Y' ";
                        cquery += "                     GROUP BY E.EQPTID ) ";
                        break;
                    case 3: //OHS
                        cquery += "   AND e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE E.EQGRID = 'OHS' AND E.EQPTLEVEL = 'C' AND E.EQPTID LIKE '" + PLANTID + "E%' AND E.EQPTIUSE = 'Y' ";
                        cquery += "                     GROUP BY E.EQPTID ) ";
                        break;
                    case 4: //Coater
                        cquery += "   AND e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE E.EQGRID = 'COT' AND E.EQPTLEVEL = 'C' AND E.EQPTID LIKE '" + PLANTID + "E%' AND E.EQPTIUSE = 'Y' ";
                        cquery += "                     GROUP BY E.EQPTID ) ";
                        break;
                    case 5: //Roll Press
                        cquery += "   AND e.EQPTID IN (SELECT E.EQPTID FROM EQUIPMENT E WITH(NOLOCK) ";
                        cquery += "                      INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON E.EQPTID = EA.S01 ";
                        cquery += "                     WHERE E.EQGRID = 'ROL' AND E.EQPTLEVEL = 'C' AND E.EQPTID LIKE '" + PLANTID + "E%' AND E.EQPTIUSE = 'Y' ";
                        cquery += "                     GROUP BY E.EQPTID ) ";
                        break;
                }
            }

            cquery += " ORDER BY e.EQPTID ";
            txtSQL.Text = cquery;
            SqlDataAdapter R = new SqlDataAdapter(cquery, cstr);
            ArrayList ar = new ArrayList();
            DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            R.Fill(ds);


            grdState.Rows.Clear();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        string[] data = new string[] {
                                dr["EQPTID"].ToString(),
                                dr["EQGRID"].ToString(),
                                dr["LANE_ID"].ToString(),
                                dr["EQPTIUSE"].ToString(),
                                dr["EIOSTAT"].ToString(),
                                dr["EIOIFMODE"].ToString(),
                                (dr["MAX_QTY"].ToString()=="0"?"":dr["MAX_QTY"].ToString()),
                                (dr["CMD_USING_QTY"].ToString()=="0"?"":dr["CMD_USING_QTY"].ToString()),
                                (dr["CMD_EMPTY_QTY"].ToString()=="0"?"":dr["CMD_EMPTY_QTY"].ToString()),
                                dr["UPDDTTM"].ToString()
                            };
                        grdState.Rows.Add(data);

                        if (dr["EQPTIUSE"].ToString() == "N")
                        {
                            grdState.Rows[grdState.RowCount - 1].DefaultCellStyle.BackColor = Color.Silver;
                        }
                        else
                        {
                            if (dr["EIOIFMODE"].ToString() == "OFF")
                            {
                                grdState.Rows[grdState.RowCount - 1].Cells[5].Style.BackColor = Color.Orange;
                            }
                            if (dr["EIOSTAT"].ToString() == "F")
                            {
                                grdState.Rows[grdState.RowCount - 1].Cells[4].Style.BackColor = Color.FromArgb(100, 200, 89);
                            }
                            // 버퍼수량
                            if (int.Parse(dr["MAX_QTY"].ToString()) > 0)
                            {
                                grdState.Rows[grdState.RowCount - 1].Cells[6].Style.BackColor = Color.GreenYellow;
                            }
                            // 실트레이 사용량
                            if (int.Parse(dr["MAX_QTY"].ToString()) > 0 && int.Parse(dr["MAX_QTY"].ToString()) <= int.Parse(dr["CMD_USING_QTY"].ToString()))
                            {
                                grdState.Rows[grdState.RowCount - 1].Cells[7].Style.BackColor = Color.Tomato;
                            }
                            // 공트레이 사용량
                            if (int.Parse(dr["MAX_QTY"].ToString()) > 0 && int.Parse(dr["MAX_QTY"].ToString()) <= int.Parse(dr["CMD_EMPTY_QTY"].ToString()))
                            {
                                grdState.Rows[grdState.RowCount - 1].Cells[8].Style.BackColor = Color.Tomato;
                            }
                        }
                    }
                }
            }
            grdSubStat.Rows.Clear();
            // Jig Formation 포트 상세 표시
            if (cobJob.SelectedIndex == 3)      // Selector
            {
                Selector_Stat_List();
            }
            else if (cobJob.SelectedIndex == 5) // Degas
            {
                Degas_Stat_List();
            }
            else if (cobJob.SelectedIndex == 6) // jig formation
            {
                Eqpt_Sub_Stat_List();
            }
            else if (cobJob.SelectedIndex == 7) // 충방전기
            {   // 충방
                Eqpt_Sub_Formation_Stat_List();
            }
        }
        /// <summary>
        /// 설비 상세 상태 조회
        /// Selector의 포트 상태 표시
        /// </summary>
        private void Selector_Stat_List()
        {
            //string cstr = "Data Source=10.95.9.59,7433;Initial catalog=ESGM_BMES_FORM_P01;User ID=rtd_app;Password=##r51T1980D@!";

            string cquery = " SELECT EIO.EQPTID, EIO.EIOSTAT, CONVERT(CHAR(23), EIO.EIODTTM , 20) AS EIO_DTTM, MP.MAX_TRF_QTY, CE.CMD_QTY ";
            cquery += "         FROM EIO EIO WITH(NOLOCK) ";
            cquery += "           INNER JOIN TB_MCS_CURR_PORT MP WITH(NOLOCK) ON EIO.EQPTID = MP.PORT_ID ";
            cquery += "              LEFT JOIN(   ";
            cquery += "                      SELECT TO_EQPTID, TO_PORT_ID, ISNULL(COUNT(CSTID),0) AS CMD_QTY   ";
            cquery += "                          FROM TB_MHS_TRF_CMD WITH(NOLOCK)   ";
            cquery += "                          WHERE CMD_STAT_CODE IN('RECEIVE', 'MOVING')   ";
            cquery += "                          AND ISNULL(CNCL_REQ_FLAG, '') NOT IN('Y', 'S')   ";
            cquery += "                          GROUP BY TO_EQPTID, TO_PORT_ID   ";
            cquery += "                      ) CE ON EIO.EQPTID = CE.TO_PORT_ID  ";
            cquery += "         WHERE EIO.EQPTID LIKE 'U1FSEL%PL%'  ";
            cquery += " ORDER BY EIO.EQPTID  ";

            SqlDataAdapter R = new SqlDataAdapter(cquery, cstr);
            ArrayList ar = new ArrayList();
            DataSet ds = new DataSet();
            R.Fill(ds);

            grdSubStat.Rows.Clear();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        string[] data = new string[] {
                                dr["EQPTID"].ToString(),
                                dr["EIOSTAT"].ToString(),
                                dr["MAX_TRF_QTY"].ToString(),
                                dr["CMD_QTY"].ToString(),
                                dr["EIO_DTTM"].ToString()
                            };
                        grdSubStat.Rows.Add(data);
                        //// 버퍼수량
                        //if (txtHistPort.Text == "")
                        //{
                        //    if (dr["PORT_ID"].ToString().IndexOf("-PL1", 0) >= 0)
                        //    {
                        //        grdSubStat.Rows[grdSubStat.RowCount - 1].DefaultCellStyle.BackColor = Color.YellowGreen;
                        //    }
                        //}
                    }
                }
            }
        }
        /// <summary>
        /// 설비 상세 상태 조회
        /// Degas의 포트 상태 표시
        /// </summary>
        private void Degas_Stat_List()
        {
            grdSubStat.Columns.Clear();
            grdSubStat.Columns.Add("PORT_ID", "설비ID");
            grdSubStat.Columns.Add("PORT_STAT_CODE", "상태");
            grdSubStat.Columns.Add("MAX_TRF_QTY", "버퍼");
            grdSubStat.Columns.Add("CMD_QTY", "반송");
            grdSubStat.Columns.Add("PORT_STAT_CHG_DTTM", "상태변경시각");


            grdSubStat.Columns[0].Width = 150; grdSubStat.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdSubStat.Columns[1].Width = 80; grdSubStat.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdSubStat.Columns[2].Width = 80; grdSubStat.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdSubStat.Columns[3].Width = 80; grdSubStat.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdSubStat.Columns[4].Width = 180; grdSubStat.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;



            //string cstr = "Data Source=10.95.9.59,7433;Initial catalog=ESGM_BMES_FORM_P01;User ID=rtd_app;Password=##r51T1980D@!";

            string cquery = " SELECT EIO.EQPTID, EIO.EIOSTAT, CONVERT(CHAR(23), EIO.EIODTTM , 20) AS EIO_DTTM, MP.MAX_TRF_QTY, CE.CMD_QTY ";
            cquery += "         FROM EIO EIO WITH(NOLOCK) ";
            cquery += "           INNER JOIN TB_MCS_CURR_PORT MP WITH(NOLOCK) ON EIO.EQPTID = MP.PORT_ID ";
            cquery += "              LEFT JOIN(   ";
            cquery += "                      SELECT TO_EQPTID, TO_PORT_ID, ISNULL(COUNT(CSTID),0) AS CMD_QTY   ";
            cquery += "                          FROM TB_MHS_TRF_CMD WITH(NOLOCK)   ";
            cquery += "                          WHERE CMD_STAT_CODE IN('RECEIVE', 'MOVING')   ";
            cquery += "                          AND ISNULL(CNCL_REQ_FLAG, '') NOT IN('Y', 'S')   ";
            cquery += "                          GROUP BY TO_EQPTID, TO_PORT_ID   ";
            cquery += "                      ) CE ON EIO.EQPTID = CE.TO_PORT_ID  ";
            cquery += "         WHERE EIO.EQPTID LIKE 'U1FDEG%PL%'  ";
            cquery += " ORDER BY EIO.EQPTID ";


            SqlDataAdapter R = new SqlDataAdapter(cquery, cstr);
            ArrayList ar = new ArrayList();
            DataSet ds = new DataSet();
            R.Fill(ds);


            grdSubStat.Rows.Clear();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        string[] data = new string[] {
                                dr["EQPTID"].ToString(),
                                dr["EIOSTAT"].ToString(),
                                dr["MAX_TRF_QTY"].ToString(),
                                dr["CMD_QTY"].ToString(),
                                dr["EIO_DTTM"].ToString()
                            };
                        grdSubStat.Rows.Add(data);
                        //// 버퍼수량
                        //if (txtHistPort.Text == "")
                        //{
                        //    if (dr["PORT_ID"].ToString().IndexOf("-PL1", 0) >= 0)
                        //    {
                        //        grdSubStat.Rows[grdSubStat.RowCount - 1].DefaultCellStyle.BackColor = Color.YellowGreen;
                        //    }
                        //}
                    }
                }
            }
        }
        /// <summary>
        /// 설비 상세 상태 조회
        /// Jif Formation 포트
        /// </summary>
        private void Eqpt_Sub_Stat_List()
        {
            grdSubStat.Columns.Clear();
            grdSubStat.Columns.Add("PORT_ID", "설비ID");
            grdSubStat.Columns.Add("PORT_STAT_CODE", "상태");
            grdSubStat.Columns.Add("PORT_STAT_CHG_DTTM", "시각");


            grdSubStat.Columns[0].Width = 150; grdSubStat.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdSubStat.Columns[1].Width = 80; grdSubStat.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdSubStat.Columns[2].Width = 180; grdSubStat.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            //string cstr = "Data Source=10.95.9.59,7433;Initial catalog=ESGM_BMES_FORM_P01;User ID=rtd_app;Password=##r51T1980D@!";

            string cquery = " SELECT PORT_ID, PORT_STAT_CODE, CONVERT(CHAR(23), PORT_STAT_CHG_DTTM , 20) AS PORT_STAT_CHG_DTTM ";
            cquery += "         FROM TB_MCS_CURR_PORT WITH(NOLOCK) ";
            cquery += "         WHERE PORT_ID LIKE 'U1FJGF%'  ";
            cquery += " ORDER BY PORT_ID ";

            // 특정포트ID가 있으면 포트 상태 이력 조회(최근 12시간)
            if (txtHistPort.Text != "")
            {
                cquery = " SELECT PORT_ID, PORT_STAT_CODE, CONVERT(CHAR(23), ACTDTTM , 20) AS PORT_STAT_CHG_DTTM ";
                cquery += "         FROM TB_MCS_PORT_STAT_HIST WITH(NOLOCK) ";
                cquery += "         WHERE PORT_ID = '" + txtHistPort.Text + "'";
                cquery += "           AND DATEDIFF(HOUR, ACTDTTM, GETDATE())<=24 ";
                cquery += "  ORDER BY ACTDTTM DESC  ";
            }

            SqlDataAdapter R = new SqlDataAdapter(cquery, cstr);
            ArrayList ar = new ArrayList();
            DataSet ds = new DataSet();
            R.Fill(ds);


            grdSubStat.Rows.Clear();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        string[] data = new string[] {
                                dr["PORT_ID"].ToString(),
                                dr["PORT_STAT_CODE"].ToString(),
                                dr["PORT_STAT_CHG_DTTM"].ToString()
                            };
                        grdSubStat.Rows.Add(data);
                        // 버퍼수량
                        if (txtHistPort.Text == "")
                        {
                            if (dr["PORT_ID"].ToString().IndexOf("-PL1", 0) >= 0)
                            {
                                grdSubStat.Rows[grdSubStat.RowCount - 1].DefaultCellStyle.BackColor = Color.YellowGreen;
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 설비EIO HISTORY
        /// </summary>
        private void Eqpt_Eio_Act_Hist_List()
        {
            grdSubStat.Columns.Clear();
            grdSubStat.Columns.Add("EQPTID", "설비ID");
            grdSubStat.Columns.Add("EIOSTAT", "상태");
            grdSubStat.Columns.Add("EIOSTAT_PV", "이전");
            grdSubStat.Columns.Add("ACTDTTM", "시각");


            grdSubStat.Columns[0].Width = 150; grdSubStat.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdSubStat.Columns[1].Width = 80; grdSubStat.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdSubStat.Columns[2].Width = 80; grdSubStat.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdSubStat.Columns[3].Width = 180; grdSubStat.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            //string cstr = "Data Source=10.95.9.59,7433;Initial catalog=ESGM_BMES_FORM_P01;User ID=rtd_app;Password=##r51T1980D@!";

            string cquery = " SELECT EQPTID, EIOSTAT, EIOSTAT_PV, CONVERT(CHAR(23), ACTDTTM , 20) AS ACTDTTM ";
            cquery += "         FROM EIOACTHISTORY WITH(NOLOCK) ";
            cquery += "         WHERE EQPTID = '" + txtHistPort.Text + "'";
            cquery += "           AND DATEDIFF(HOUR, ACTDTTM, GETDATE())<=24 ";
            cquery += " ORDER BY ACTDTTM DESC  ";

            SqlDataAdapter R = new SqlDataAdapter(cquery, cstr);
            ArrayList ar = new ArrayList();
            DataSet ds = new DataSet();
            R.Fill(ds);


            grdSubStat.Rows.Clear();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        string[] data = new string[] {
                                dr["EQPTID"].ToString(),
                                dr["EIOSTAT"].ToString(),
                                dr["EIOSTAT_PV"].ToString(),
                                dr["ACTDTTM"].ToString()
                            };
                        grdSubStat.Rows.Add(data);
                    }
                }
            }
        }
        /// <summary>
        /// 설비 상세 상태 조회
        /// 충방 Formation 포트
        /// </summary>
        private void Eqpt_Sub_Formation_Stat_List(String PORT_ID = "")
        {
            grdSubStat.Columns.Clear();
            grdSubStat.Columns.Add("PORT_ID", "설비ID");
            grdSubStat.Columns.Add("EIOSTAT", "포트상태");
            grdSubStat.Columns.Add("EIOIFMODE", "통신상태");
            grdSubStat.Columns.Add("PORT_STAT_CODE", "상태");
            grdSubStat.Columns.Add("CSTID", "CSTID");
            grdSubStat.Columns.Add("AUTO_ISS_REQ_FLAG", "REQ_FLAG");
            grdSubStat.Columns.Add("PORT_STAT_CHG_DTTM", "시각");


            grdSubStat.Columns[0].Width = 180; grdSubStat.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdSubStat.Columns[1].Width = 60; grdSubStat.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //grdSubStat.Columns[1].Visible = false;
            grdSubStat.Columns[2].Width = 60; grdSubStat.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //grdSubStat.Columns[2].Visible = false;
            grdSubStat.Columns[3].Width = 60; grdSubStat.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdSubStat.Columns[4].Width = 120; grdSubStat.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; grdSubStat.Columns[4].Visible = false;
            grdSubStat.Columns[5].Width = 60; grdSubStat.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdSubStat.Columns[6].Width = 180; grdSubStat.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            //string cstr = "Data Source=10.95.9.59,7433;Initial catalog=ESGM_BMES_FORM_P01;User ID=rtd_app;Password=##r51T1980D@!";

            string cquery = " SELECT CP.PORT_ID, CP.PORT_STAT_CODE, CONVERT(CHAR(23), CP.PORT_STAT_CHG_DTTM , 20) AS PORT_STAT_CHG_DTTM, CP.MCS_CST_ID, CP.AUTO_ISS_REQ_FLAG, EIO.EIOSTAT, EIO.EIOIFMODE ";
            cquery += "         FROM TB_MCS_PORT P WITH(NOLOCK) ";
            cquery += "         INNER JOIN TB_MCS_CURR_PORT CP WITH(NOLOCK) ON CP.PORT_ID = P.PORT_ID ";
            cquery += "         INNER JOIN EIO EIO WITH(NOLOCK) ON EIO.EQPTID = P.EQPTID  ";  //SUBSTRING(CP.PORT_ID, 1, 15) ";
            if (PORT_ID != "") {
                cquery += "         WHERE CP.PORT_ID like '" + PORT_ID + "%-PB1' ";
            }
            else
            {
                cquery += "         WHERE CP.PORT_ID like 'U1FFOR%-PB1' ";
            }
            //cquery += "           AND LEN(CP.PORT_ID) =  19 ";
            cquery += " ORDER BY CASE WHEN CP.PORT_STAT_CODE = 'UR' THEN 0 ELSE 1 END, SUBSTRING(CP.PORT_ID, 1,11),CASE WHEN CP.PORT_STAT_CODE = 'LR' THEN 0 ELSE 1 END, CASE WHEN ISNULL(CP.PORT_STAT_CHG_DTTM,'') = '' THEN 9 ELSE 1 END, CP.PORT_STAT_CHG_DTTM  ";

            // 특정포트ID가 있으면 포트 상태 이력 조회(최근 12시간)
            //if (txtHistPort.Text != "")
            //{
            //    cquery = " SELECT PORT_ID, PORT_STAT_CODE, CONVERT(CHAR(23), ACTDTTM , 20) AS PORT_STAT_CHG_DTTM ";
            //    cquery += "         FROM TB_MCS_PORT_STAT_HIST WITH(NOLOCK) ";
            //    cquery += "         WHERE PORT_ID = '" + txtHistPort.Text + "'";
            //    cquery += "           AND DATEDIFF(HOUR, ACTDTTM, GETDATE())<=24 ";
            //    cquery += "  ORDER BY ACTDTTM DESC  ";
            //}

            SqlDataAdapter R = new SqlDataAdapter(cquery, cstr);
            ArrayList ar = new ArrayList();
            DataSet ds = new DataSet();
            R.Fill(ds);


            grdSubStat.Rows.Clear();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        string[] data = new string[] {
                                dr["PORT_ID"].ToString(),
                                dr["EIOSTAT"].ToString(),
                                dr["EIOIFMODE"].ToString(),
                                dr["PORT_STAT_CODE"].ToString(),
                                dr["MCS_CST_ID"].ToString(),
                                dr["AUTO_ISS_REQ_FLAG"].ToString(),
                                dr["PORT_STAT_CHG_DTTM"].ToString()
                            };
                        grdSubStat.Rows.Add(data);
                        // 버퍼수량
                        if (txtHistPort.Text == "")
                        {
                            if (dr["PORT_STAT_CODE"].ToString() == "UR")
                            {
                                grdSubStat.Rows[grdSubStat.RowCount - 1].DefaultCellStyle.BackColor = Color.BlueViolet;
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 스토크 상태 표시
        /// </summary>
        /// <param name="STONO"></param>
        private void Stocker_state()
        {
            if (cobSTO.SelectedIndex == -1) return;

            //string cstr = "Data Source=10.95.9.59,7433;Initial catalog=ESGM_BMES_FORM_P01;User ID=rtd_app;Password=##r51T1980D@!";
            string scond = "", scond2 = "", scond3 = "";

            switch (cobSTO.SelectedIndex)
            {
                case 0:  // PreAging
                    scond += $" '{Constants.Site.NB.ELEC.FOIL_STO}', 'U1FSTO11302','U1FSTO11303', 'U1FSTO11304'";
                    scond2 = " OR CR.EQPTID LIKE 'U1FHPC%'";
                    scond3 = " OR (e.EQPTID LIKE 'U1FHPC%'  AND e.EQPTLEVEL = 'M')";
                    break;
                case 1:  // 1차 공트레이
                    scond += "'U1FSTO11305', 'U1FSTO11306'";
                    break;
                case 2:  // JIG Stocker
                    scond += "'U1FSTO11307', 'U1FSTO11308', 'U1FSTO11309', 'U1FSTO11310'";
                    break;
                case 3:  // High Temp Aging
                    scond += "'U1FSTO11312', 'U1FSTO11313', 'U1FSTO11314', 'U1FSTO11315','U1FSTO11316', 'U1FSTO11317'";
                    break;
                case 4:  // Normal Temp Aging
                    scond += "'U1FSTO11318', 'U1FSTO11319', 'U1FSTO11320', 'U1FSTO11321', 'U1FSTO11322', 'U1FSTO11323'";
                    scond2 = " OR CR.EQPTID LIKE 'U1FDEG%01'";
                    scond3 = " OR e.EQPTID LIKE 'U1FDEG%01'";
                    break;
                case 5:  // 2차 공트레이
                    scond += "'U1FSTO12301', 'U1FSTO12302','U1FDEG01105','U1FDEG01205','U1FDEG02105','U1FDEG02205'";
                    break;
                case 6:  // 출하AGING
                    scond += "'U1FSTO12303', 'U1FSTO12304', 'U1FSTO12305', 'U1FSTO12306', 'U1FSTO12307', 'U1FSTO12308', 'U1FSTO12309', 'U1FSTO12310','U1FSTO12311', 'U1FSTO12312', 'U1FSTO12313', 'U1FSTO12314'";
                    scond2 += "  OR CR.EQPTID LIKE 'U1FOCV%' OR CR.EQPTID LIKE 'U1FSEL0%3' OR CR.EQPTID LIKE 'U1FEOL%'";
                    scond3 += "  OR e.EQPTID LIKE 'U1FOCV%' OR e.EQPTID LIKE 'U1FSEL0%3' OR e.EQPTID LIKE 'U1FEOL%'";
                    break;
                case 7:  // 충방전
                    scond += " AND (e.EQPTID LIKE 'U1FFOR%' AND LEN(e.EQPTID) = 15";
                    scond2 += "  OR CR.EQPTID LIKE 'U1FDIS%')";
                    scond3 += "  OR e.EQPTID LIKE 'U1FDIS%')";
                    break;
                default:
                    return;
            }

            string cquery = " SELECT e.EQPTID, e.EQPTIUSE, EA.S71 AS LANE_ID, ei.EIOSTAT, ei.EIOIFMODE, ei.EIOCOMSTAT ";
            cquery += "             , ISNULL(R.RACK_MAX_QTY,0) AS RACK_MAX_QTY ";
            cquery += "             , ISNULL(R.USABLE_QTY,0) AS USABLE_QTY      ";
            cquery += "             , ISNULL(R.USING_QTY, 0) AS USING_QTY   ";
            cquery += "             , ISNULL(R.DISABLE_QTY, 0) AS DISABLE_QTY   ";
            cquery += "  FROM EQUIPMENT e WITH(NOLOCK) ";
            cquery += "   INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON e.EQPTID = EA.EQPTID ";
            cquery += "   INNER JOIN EIO ei WITH(NOLOCK) ON e.EQPTID = ei.EQPTID ";
            cquery += "  LEFT JOIN (  ";
            cquery += "     SELECT  ";
            cquery += "           T.EQPTID  ";
            cquery += "  	    , T.OPTM_LOAD_RATE  ";
            cquery += "  	    , COUNT(T.RACK_ID) AS RACK_MAX_QTY  ";
            cquery += "         , SUM(T.EMPTY_RACK) AS USABLE_QTY  "; // --사용가능
            cquery += "         , SUM(T.USING_RACK) AS USING_QTY  "; // --사용중
            cquery += "  	    , SUM(T.DISABLE_RACK) AS DISABLE_QTY  ";  // -- 입고금지
            cquery += "     FROM  ";
            cquery += "         (  ";
            cquery += "             SELECT  ";
            cquery += "                 CR.EQPTID  ";
            cquery += "                 , PW.OPTM_LOAD_RATE  ";
            cquery += "                 , CR.RACK_ID  ";
            cquery += "                 , CASE  ";
            cquery += "                     WHEN         ";  //--사용가능 rack
            cquery += "                         CR.RACK_STAT_CODE = 'USABLE'  ";
            cquery += "                         AND ISNULL(CR.MCS_CST_ID, '') = ''  ";
            cquery += "                         AND CR.FIRE_OCCR_FLAG = 'N'  ";
            cquery += "                         AND CR.USE_FLAG = 'Y'  ";
            cquery += "                         THEN 1  ";
            cquery += "                     ELSE 0  ";
            cquery += "                 END AS EMPTY_RACK  ";
            cquery += "                 , CASE  ";
            cquery += "                     WHEN         ";  //--사용중 rack
            cquery += "                         CR.RACK_STAT_CODE = 'USING'  ";
            cquery += "                         AND CR.FIRE_OCCR_FLAG = 'N'  ";
            cquery += "                         AND CR.USE_FLAG = 'Y'  ";
            cquery += "                         THEN 1  ";
            cquery += "                     ELSE 0  ";
            cquery += "                 END AS USING_RACK  ";
            cquery += "                 , CASE  ";
            cquery += "                     WHEN         ";  //--사용중 rack
            cquery += "                         CR.RACK_STAT_CODE = 'DISABLE'  ";
            cquery += "                         OR CR.FIRE_OCCR_FLAG = 'Y'  ";
            cquery += "                         OR CR.USE_FLAG = 'N'  ";
            cquery += "                         THEN 1  ";
            cquery += "                     ELSE 0  ";
            cquery += "                 END AS DISABLE_RACK  ";
            cquery += "             FROM TB_MMD_PRDT_WH    PW WITH(NOLOCK)  ";
            cquery += "               INNER JOIN TB_MMD_RACK MR WITH(NOLOCK)        ON PW.WH_ID = MR.WH_ID      AND PW.USE_FLAG = 'Y'     AND MR.USE_FLAG = 'Y'  ";
            cquery += "               INNER JOIN TB_MCS_RACK CR WITH(NOLOCK)        ON CR.RACK_ID = MR.RACK_ID  AND CR.USE_FLAG = 'Y'  ";
            cquery += "             WHERE 1 = 1  ";
            if (cobSTO.SelectedIndex == 0 || cobSTO.SelectedIndex == 4 || cobSTO.SelectedIndex == 6)
            {
                cquery += "           AND (CR.EQPTID  IN (" + scond + ")";
                cquery += scond2 + ")";
            }
            else if (cobSTO.SelectedIndex == 7)
            {
                cquery += "           AND (CR.EQPTID LIKE 'U1FFOR%' AND LEN(CR.EQPTID) = 15";
                cquery += "                 OR CR.EQPTID IN ('U1FDIS012', 'U1FDIS011'))";
            }
            else
            {
                cquery += "           AND CR.EQPTID  IN (" + scond + ")";
            }
            cquery += "             ) AS T  ";
            cquery += "     GROUP BY T.EQPTID, T.OPTM_LOAD_RATE  ";
            cquery += "  ) AS R  ON  E.EQPTID = R.EQPTID ";
            cquery += " WHERE 1 = 1";
            if (cobSTO.SelectedIndex == 0 || cobSTO.SelectedIndex == 4 || cobSTO.SelectedIndex == 6)
            {
                cquery += "   AND (e.EQPTID IN (" + scond + ")";
                cquery += scond3 + ")";
            }
            else if (cobSTO.SelectedIndex == 7)
            {
                cquery += " AND (e.EQPTID LIKE 'U1FFOR%' AND LEN(e.EQPTID) = 15";
                cquery += "  OR e.EQPTID IN ('U1FDIS012', 'U1FDIS011'))";
            }
            else  // 충방전
            {
                cquery += "   AND e.EQPTID IN (" + scond + ")";
            }
            cquery += " ORDER BY e.EQPTID ";

            txtSQL.Text = cquery;
            SqlDataAdapter R = new SqlDataAdapter(cquery, cstr);
            ArrayList ar = new ArrayList();
            DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            R.Fill(ds);

            grdStoStat.Columns.Clear();
            grdStoStat.Columns.Add("EQPTID", "설비");
            grdStoStat.Columns.Add("EQPTIUSE", "사용");
            grdStoStat.Columns.Add("LANE_ID", "LANE");
            grdStoStat.Columns.Add("EIOSTAT", "상태");
            grdStoStat.Columns.Add("EIOIFMODE", "통신");
            grdStoStat.Columns.Add("RACK_MAX_QTY", "TOTAL");
            grdStoStat.Columns.Add("DISABLE_QTY", "사용불가");
            grdStoStat.Columns.Add("USABLE_QTY", "사용가능");
            grdStoStat.Columns.Add("USING_QTY", "사용중");
            grdStoStat.Columns.Add("USE_RATE", "사용율");

            grdStoStat.Columns[0].Width = 100; grdStoStat.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grdStoStat.Columns[1].Width = 60; grdStoStat.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdStoStat.Columns[2].Width = 100; grdStoStat.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdStoStat.Columns[3].Width = 60; grdStoStat.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdStoStat.Columns[4].Width = 60; grdStoStat.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdStoStat.Columns[5].Width = 70; grdStoStat.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdStoStat.Columns[6].Width = 70; grdStoStat.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdStoStat.Columns[7].Width = 70; grdStoStat.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdStoStat.Columns[8].Width = 70; grdStoStat.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdStoStat.Columns[9].Width = 80; grdStoStat.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            grdStoStat.Rows.Clear();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        string[] data = new string[] {
                                dr["EQPTID"].ToString(),
                                dr["EQPTIUSE"].ToString(),
                                dr["LANE_ID"].ToString(),
                                dr["EIOSTAT"].ToString(),
                                dr["EIOIFMODE"].ToString(),
                                dr["RACK_MAX_QTY"].ToString(),
                                dr["DISABLE_QTY"].ToString(),
                                dr["USABLE_QTY"].ToString(),
                                dr["USING_QTY"].ToString(),
                                (Convert.ToSingle(dr["RACK_MAX_QTY"].ToString())==0?"0":
                                      ((Convert.ToSingle(dr["DISABLE_QTY"].ToString())+Convert.ToSingle(dr["USING_QTY"].ToString()))/Convert.ToSingle(dr["RACK_MAX_QTY"].ToString())*100.0).ToString("##0"))
                            };
                        grdStoStat.Rows.Add(data);

                        if (dr["EQPTIUSE"].ToString() == "N")
                        {
                            grdStoStat.Rows[grdStoStat.RowCount - 1].DefaultCellStyle.BackColor = Color.Silver;
                        }
                        else
                        {
                            if (dr["EIOIFMODE"].ToString() == "OFF")
                            {
                                //grdStoStat.Rows[grdStoStat.RowCount - 1].DefaultCellStyle.BackColor = Color.Orange;
                                grdStoStat.Rows[grdStoStat.RowCount - 1].Cells[4].Style.BackColor = Color.Orange;
                            }
                            if (dr["EIOSTAT"].ToString() == "F")  //dr["EIOSTAT"].ToString() == "T" 
                            {
                                grdStoStat.Rows[grdStoStat.RowCount - 1].Cells[3].Style.BackColor = Color.FromArgb(100, 200, 89);
                            }
                            if (((Convert.ToSingle(dr["DISABLE_QTY"].ToString()) + Convert.ToSingle(dr["USING_QTY"].ToString())) / Convert.ToSingle(dr["RACK_MAX_QTY"].ToString()) * 100.0) > 90)
                            {
                                grdStoStat.Rows[grdStoStat.RowCount - 1].Cells[7].Style.BackColor = Color.PaleVioletRed;
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 랙정보 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rack_list()
        {
            if (cobJob.SelectedIndex == -1) return;

            grdRack.Rows.Clear();
            grdRack.Columns.Clear();
            grdRack.Columns.Add("SEQ", "순번");
            grdRack.Columns.Add("CSTID", "트레이");
            grdRack.Columns.Add("LOAD_REP_CSTID", "대표트레이");
            grdRack.Columns.Add("CST_LOAD_LOCATION_CODE", "단");
            grdRack.Columns.Add("CSTSTAT", "구분");
            grdRack.Columns.Add("LOTID", "LOT");
            grdRack.Columns.Add("WIPSTAT", "상태");
            grdRack.Columns.Add("ROUTID", "ROUT");
            grdRack.Columns.Add("PROCID", "공정");
            grdRack.Columns.Add("NEXT_PROCID", "다음공정");
            grdRack.Columns.Add("NEXT_LANEID", "LANE");
            grdRack.Columns.Add("RACK_ID", "위치");
            grdRack.Columns.Add("SMPL_ISS_TYPE_CODE", "샘플");
            grdRack.Columns.Add("ABNORM_STAT_CODE", "비정상코드");
            grdRack.Columns.Add("AGING_ISS_SCHD_DTTM", "완료예정시각");
            grdRack.Columns.Add("AGING_ISS_PRIORITY_NO", "순위");
            grdRack.Columns.Add("UPDDTTM_S", "업데이트시각");

            grdRack.Columns[0].Width = 60; grdRack.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 순번
            grdRack.Columns[1].Width = 100; grdRack.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;      // 트레이
            grdRack.Columns[2].Width = 100; grdRack.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;      // 대표트레이
            grdRack.Columns[3].Width = 60; grdRack.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 단
            grdRack.Columns[4].Width = 60; grdRack.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;      // 구분
            grdRack.Columns[5].Width = 180; grdRack.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;       // LOT
            grdRack.Columns[6].Width = 60; grdRack.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 상태
            grdRack.Columns[7].Width = 80; grdRack.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;       // ROUT
            grdRack.Columns[8].Width = 80; grdRack.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;       // PROC
            grdRack.Columns[9].Width = 80; grdRack.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;      // NEXT PROC
            grdRack.Columns[10].Width = 80; grdRack.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;      // NEXT LANE
            grdRack.Columns[11].Width = 170; grdRack.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // RACK
            grdRack.Columns[12].Width = 60; grdRack.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // SAMPLE
            grdRack.Columns[13].Width = 120; grdRack.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // 비정상코드
            grdRack.Columns[14].Width = 180; grdRack.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 출고예정시각
            grdRack.Columns[15].Width = 60; grdRack.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;      // 우선순위
            grdRack.Columns[16].Width = 180; grdRack.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 업데이트시각


            //string cstr = "Data Source=10.95.9.59,7433;Initial catalog=ESGM_BMES_FORM_P01;User ID=rtd_app;Password=##r51T1980D@!";

            string cquery = "";


            cquery = "		    SELECT C.CSTID      ";
            cquery += "		           , (CASE WHEN C.LOAD_REP_CSTID IS NULL THEN C.CSTID ELSE C.LOAD_REP_CSTID END) AS LOAD_REP_CSTID     ";
            cquery += "		           , CST_LOAD_LOCATION_CODE     ";
            cquery += "		           , CSTSTAT     ";
            cquery += "		           , C.EQPT_CUR     ";
            cquery += "		          , W.LOTID                    ";
            cquery += "		          , W.WIPSTAT                    ";
            cquery += "		          , W.ROUTID                    ";
            cquery += "		          , W.PROCID                    ";
            cquery += "		          , ISNULL(RP2.PROCID, '')  AS NEXT_PROCID      ";
            cquery += "		          , ISNULL(RP2.LANE_ID, '')  AS NEXT_LANEID      ";
            cquery += "		          , C.PORT_CUR      ";
            cquery += "		          , R.RACK_ID      ";
            cquery += "		          , R.RACK_STAT_CODE      ";
            cquery += "		          , R.ABNORM_STAT_CODE      ";
            cquery += "		          , WA.SMPL_ISS_TYPE_CODE   ";
            cquery += "		          , CONVERT(CHAR(23), WA.AGING_ISS_SCHD_DTTM, 20) AS AGING_ISS_SCHD_DTTM    ";//
            cquery += "		          , CONVERT(CHAR(23), r.UPDDTTM, 20) AS UPDDTTM_S               ";
            cquery += "		          , CONVERT(CHAR(23), C.UPDDTTM, 20) AS UPDDTTM_C               ";
            cquery += "		          , AGING_ISS_PRIORITY_NO     ";
            cquery += "		          , CASE WHEN DATEDIFF(minute, GETDATE(), AGING_ISS_SCHD_DTTM)> 0 THEN '0' ELSE '1' END AS OUTFLAG         ";
            cquery += "		     FROM  (                ";
            cquery += "		             SELECT C1.CSTID, C1.LOAD_REP_CSTID, C2.CURR_LOTID, C1.CSTSTAT, C1.EQPT_CUR, C1.PORT_CUR, C1.CST_LOAD_LOCATION_CODE, C1.UPDDTTM      ";
            cquery += "		               FROM  (SELECT C.CSTID     ";
            cquery += "		                    , ISNULL(C.LOAD_REP_CSTID, C.CSTID) AS LOAD_REP_CSTID                     ";
            cquery += "		                    , C.CURR_LOTID                     ";
            cquery += "		                    , C.CSTSTAT                     ";
            cquery += "		                    , C.EQPT_CUR                     ";
            cquery += "		                    , C.PORT_CUR                     ";
            cquery += "		                    , C.CST_LOAD_LOCATION_CODE                 ";
            cquery += "		                    , C.UPDDTTM                 ";
            cquery += "		                FROM Carrier C WITH(NOLOCK)                ";
            cquery += "		                 INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK)  ON C.EQPT_CUR =  EA.EQPTID                ";
            cquery += "		                WHERE C.CURR_AREAID = '" + AREAID + "'";
            //cquery += "		                WHERE((CST_LOAD_LOCATION_CODE = 1 AND LOAD_REP_CSTID IS NULL) OR(CST_LOAD_LOCATION_CODE = 2 AND LOAD_REP_CSTID IS NOT NULL))       ";
            if (!chkOrder.Checked)
            {
                if (txtCST1.Text != "")
                {
                    if (txtCST1.Text.IndexOf(",") > 0)
                    {
                        string sq = Text_Split(txtCST1.Text);
                        cquery += " AND (C.CSTID IN (" + sq + ") OR C.LOAD_REP_CSTID IN (" + sq + "))";
                    }
                    else
                    {
                        cquery += "	AND (C.CSTID LIKE '%" + txtCST1.Text + "%' OR C.LOAD_REP_CSTID LIKE '%" + txtCST1.Text + "%') ";
                    }
                }
                else
                {
                    if (cobEqpt.SelectedIndex == 0)
                    {
                        switch (cobSTO.SelectedIndex)
                        {
                            case 0:  // PreAging
                                //cquery += " AND EQPT_CUR IN ('U1FSTO11301', 'U1FSTO11302', 'U1FSTO11303', 'U1FSTO11304')";
                                cquery += " AND EA.S70 = '9' ";
                                break;
                            case 1:  // 1차 공트레이
                                cquery += " AND C.EQPT_CUR IN ('U1FSTO11305', 'U1FSTO11306')";
                                //cquery += " AND EA.S70 = 'E' ";
                                break;
                            case 2:  // JIG FORMATION
                                //cquery += " AND EQPT_CUR IN ('U1FSTO11307', 'U1FSTO11308', 'U1FSTO11309', 'U1FSTO11310') ";
                                cquery += " AND EA.S70 = 'J' ";
                                break;
                            case 3:  // 고온AGING
                                //cquery += " AND EQPT_CUR IN ('U1FSTO11312','U1FSTO11313','U1FSTO11315','U1FSTO11314','U1FSTO11316','U1FSTO11317')";
                                cquery += " AND EA.S70 = '4' ";
                                break;
                            case 4:  // 상온AGING
                                //cquery += " AND EQPT_CUR IN ('U1FSTO11318','U1FSTO11319','U1FSTO11320','U1FSTO11321','U1FSTO11322','U1FSTO11323')";
                                cquery += " AND EA.S70 = '3' ";
                                break;
                            case 5:  // 2차 공트레이 스토커
                                cquery += " AND C.EQPT_CUR IN ('U1FSTO12301','U1FSTO12302')";
                                //cquery += " AND EA.S70 = 'E' ";
                                break;
                            case 6:  // 출하 AGING
                                //cquery += " AND EQPT_CUR IN ('U1FSTO12303','U1FSTO12304','U1FSTO12305','U1FSTO12306','U1FSTO12307','U1FSTO12308','U1FSTO12309','U1FSTO12310','U1FSTO12311','U1FSTO12312','U1FSTO12313','U1FSTO12314')";
                                cquery += " AND EA.S70 = '7' ";
                                break;
                            case 7:  // 충방전
                                cquery += " AND C.EQPT_CUR LIKE 'U1FFOR%'";
                                cquery += " AND EA.S70 = 'J' ";
                                break;
                            default:
                                return;
                        }
                    }
                    else
                    {
                        cquery += " AND C.EQPT_CUR = '" + cobEqpt.Text + "'";
                    }
                }
            }
            else
            {
                //cquery += "		                WHERE((CST_LOAD_LOCATION_CODE = 1 AND LOAD_REP_CSTID IS NULL) OR(CST_LOAD_LOCATION_CODE = 2 AND LOAD_REP_CSTID IS NOT NULL))       ";
            }
            cquery += "    ) AS C1 ";
            cquery += "    INNER JOIN CARRIER C2 WITH(NOLOCK) ON C1.LOAD_REP_CSTID = C2.CSTID ) AS C     ";
            cquery += "    LEFT JOIN TB_MCS_RACK R WITH(NOLOCK)  ON R.MCS_CST_ID = C.LOAD_REP_CSTID ";
            cquery += "	   LEFT JOIN WIP W WITH(NOLOCK) ON C.CURR_LOTID = W.LOTID ";
            cquery += "    LEFT JOIN WIPATTR WA WITH(NOLOCK) ON WA.LOTID = W.LOTID ";
            cquery += "    LEFT JOIN TB_MMD_FORM_ROUT_PROC RP WITH(NOLOCK) ON RP.ROUTID = W.ROUTID AND RP.PROCID = W.PROCID  AND RP.USE_FLAG = 'Y' ";
            cquery += "    LEFT JOIN TB_MMD_FORM_ROUT_PROC RP2 WITH(NOLOCK) ON RP2.ROUTID = RP.ROUTID AND RP2.PROC_SEQNO = RP.PROC_SEQNO+1 AND RP2.USE_FLAG = 'Y' ";
            if (chkOrder.Checked)
            {
                cquery += "WHERE EQPT_CUR LIKE 'U1FSTO%' ";
                cquery += "  AND (DATEDIFF(minute, WA.AGING_ISS_SCHD_DTTM, GETDATE()) >= 1 ";
                cquery += "   OR AGING_ISS_PRIORITY_NO = '8' ";
                cquery += "   OR AGING_ISS_PRIORITY_NO = '9') ";
            }
            else
            {
                cquery += "WHERE 1=1 ";
            }

            if (chkWait.Checked == true)
            {
                cquery += "  AND w.wipstat = 'WAIT' ";
            }
            if (cobLane.SelectedIndex > 0)
            {
                cquery += " AND ISNULL(RP2.LANE_ID, '') LIKE '" + cobLane.Text + "%'";
            }
            cquery += "  ORDER BY CASE WHEN ISNULL(W.LOTID,'') ='' THEN '1' WHEN R.RACK_STAT_CODE ='DISABLE' THEN '2'  WHEN (AGING_ISS_PRIORITY_NO='8' OR AGING_ISS_PRIORITY_NO='9') THEN '3'   ELSE '4' END ASC, ";
            cquery += "           WA.AGING_ISS_SCHD_DTTM,  (CASE WHEN C.LOAD_REP_CSTID IS NULL THEN C.CSTID ELSE C.LOAD_REP_CSTID END), CST_LOAD_LOCATION_CODE ";

            txtSQL.Text = cquery;
            SqlDataAdapter R = new SqlDataAdapter(cquery, cstr);
            ArrayList ar = new ArrayList();
            DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            R.Fill(ds);

            RACK_init();

            int idx = 0;
            grdRack.Rows.Clear();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        idx++;
                        string[] data = new string[] {
                                idx.ToString(),
                                dr["EQPT_CUR"].ToString(),
                                dr["CSTID"].ToString(),
                                dr["LOAD_REP_CSTID"].ToString(),
                                dr["CST_LOAD_LOCATION_CODE"].ToString(),
                                dr["CSTSTAT"].ToString(),
                                dr["LOTID"].ToString(),
                                dr["WIPSTAT"].ToString(),
                                dr["ROUTID"].ToString(),
                                dr["PROCID"].ToString(),
                                dr["NEXT_PROCID"].ToString(),
                                dr["NEXT_LANEID"].ToString(),
                                (cobSTO.SelectedIndex==7? dr["PORT_CUR"].ToString(): dr["RACK_ID"].ToString()),
                                dr["SMPL_ISS_TYPE_CODE"].ToString(),    // 샘플출고구분
                                dr["ABNORM_STAT_CODE"].ToString(),      // 비정상 상태코드
                                dr["AGING_ISS_SCHD_DTTM"].ToString(),   //SMPL_ISS_TYPE_CODE
                                (dr["RACK_STAT_CODE"].ToString() == "DISABLE"?"DISABLE":dr["AGING_ISS_PRIORITY_NO"].ToString()),
                                (cobSTO.SelectedIndex==7? dr["UPDDTTM_C"].ToString(): dr["UPDDTTM_S"].ToString()),
                            };
                        grdRack.Rows.Add(data);

                        if (dr["RACK_STAT_CODE"].ToString() == "DISABLE")     // RACK 금지단 설정
                        {
                            grdRack.Rows[grdRack.RowCount - 1].DefaultCellStyle.BackColor = Color.OrangeRed;
                        }
                        else if ((dr["OUTFLAG"].ToString() == "1" && dr["AGING_ISS_SCHD_DTTM"].ToString() != "")
                            || (dr["AGING_ISS_PRIORITY_NO"].ToString() == "8" || dr["AGING_ISS_PRIORITY_NO"].ToString() == "9"))
                        {
                            grdRack.Rows[grdRack.RowCount - 1].DefaultCellStyle.BackColor = Color.LightPink;
                        }
                    }
                }
            }
        }
        private void RACK_init()
        {
            grdRack.Columns.Clear();
            grdRack.Columns.Add("SEQ", "순번");
            grdRack.Columns.Add("EQPT_CUR", "설비");
            grdRack.Columns.Add("CSTID", "트레이");
            grdRack.Columns.Add("LOAD_REP_CSTID", "대표트레이");
            grdRack.Columns.Add("CST_LOAD_LOCATION_CODE", "단수");
            grdRack.Columns.Add("CSTSTAT", "구분");
            grdRack.Columns.Add("LOTID", "LOT");
            grdRack.Columns.Add("WIPSTAT", "상태");
            grdRack.Columns.Add("ROUTID", "ROUT");
            grdRack.Columns.Add("PROCID", "현재");
            grdRack.Columns.Add("NEXT_PROCID", "다음공정");
            grdRack.Columns.Add("NEXT_LANEID", "LANE");
            grdRack.Columns.Add("PORT_ID", "위치");
            grdRack.Columns.Add("SMPL_ISS_TYPE_CODE", "샘플출고");
            grdRack.Columns.Add("ABNORM_STAT_CODE", "비정상코드");
            grdRack.Columns.Add("AGING_ISS_SCHD_DTTM", "완료예정시각");
            grdRack.Columns.Add("AGING_ISS_PRIORITY_NO", "순위");
            grdRack.Columns.Add("UPDDTTM", "업데이트시각");

            grdRack.Columns[0].Width = 60; grdRack.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;   // 순번
            grdRack.Columns[1].Width = 110; grdRack.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // 설비
            grdRack.Columns[2].Width = 110; grdRack.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // 트레이
            grdRack.Columns[3].Width = 110; grdRack.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // 대표트레이
            grdRack.Columns[4].Width = 60; grdRack.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;   // 단수
            grdRack.Columns[5].Width = 60; grdRack.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;   // 구분
            grdRack.Columns[6].Width = 140; grdRack.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // LOT
            grdRack.Columns[7].Width = 100; grdRack.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // 상태
            grdRack.Columns[8].Width = 80; grdRack.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;   // ROUT
            grdRack.Columns[9].Width = 80; grdRack.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;   // PROCID
            grdRack.Columns[10].Width = 80; grdRack.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;   // NEXT PROCID
            grdRack.Columns[11].Width = 80; grdRack.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;   // NEXT LANEID
            grdRack.Columns[12].Width = 150; grdRack.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // 위치
            grdRack.Columns[13].Width = 60; grdRack.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // 샘플출고구분
            grdRack.Columns[14].Width = 120; grdRack.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;    // 비정상코드
            grdRack.Columns[15].Width = 160; grdRack.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // 완료예정시각
            grdRack.Columns[16].Width = 60; grdRack.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 순위
            grdRack.Columns[17].Width = 160; grdRack.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // 업데이트시각
            if (!chkOrder.Checked) { grdRack.Columns[1].Visible = false; }
        }

        /// <summary>
        /// 충방 포트 정보 조회
        /// </summary>
        private void Formation_Stat_List()
        {
            string Q = "";
            Q = " SELECT P.PORT_ID ";
            Q += "   , C.PORT_STAT_CODE ";
            Q += "   , PORT_STAT_CHG_DTTM ";
            Q += "   , MCS_CST_ID ";
            Q += "   , AUTO_ISS_REQ_FLAG ";
            Q += "   , E.EIOSTAT ";
            Q += "   , E.EIOIFMODE ";
            Q += " FROM tb_mcs_port P  with(nolock) ";
            Q += "  INNER JOIN TB_MCS_CURR_PORT C WITH(NOLOCK) ON P.PORT_ID = C.PORT_ID ";
            Q += "   LEFT JOIN EIO E WITH(NOLOCK) ON P.PORT_ID = E.EQPTID ";
            Q += " WHERE P.PORT_ID like 'U1FFOR01101-%-PB1' ";
            Q += "   AND C.MCS_CST_ID IS NOT NULL ";
            Q += " ORDER BY P.PORT_ID ";


            grdRack.Columns.Clear();
            grdRack.Columns.Add("CSTID", "MCS_CST_ID");
            grdRack.Columns.Add("LOTID", "LOTID");
            grdRack.Columns.Add("ACTID", "ACTID");
            grdRack.Columns.Add("ACTDTTM", "ACTDTTM");
            grdRack.Columns.Add("ROUTID", "ROUTID");
            grdRack.Columns.Add("PROCID", "PROCID");
            grdRack.Columns.Add("EQSGID", "EQSGID");
            grdRack.Columns.Add("EQPTID", "EQPTID");
            grdRack.Columns.Add("WIPSTAT", "WIPSTAT");
            grdRack.Columns.Add("USERID", "USERID");
            grdRack.Columns.Add("INSDTTM", "INSDTTM");
            grdRack.Columns.Add("UPDDTTM", "UPDDTTM");


            grdRack.Columns[0].Width = 100; grdRack.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdRack.Columns[1].Width = 120; grdRack.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdRack.Columns[2].Width = 250;
            grdRack.Columns[3].Width = 150;
            grdRack.Columns[4].Width = 80; grdRack.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdRack.Columns[5].Width = 80; grdRack.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdRack.Columns[6].Width = 80; grdRack.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdRack.Columns[7].Width = 100; grdRack.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdRack.Columns[8].Width = 80; grdRack.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdRack.Columns[9].Width = 80;
            grdRack.Columns[10].Width = 150;
            grdRack.Columns[11].Width = 150;
            for (int i = 0; i < 12; i++)
            {
                grdRack.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }
        private void btnErrSel_Click(object sender, EventArgs e)
        {
            ErrList();
        }
        /// <summary>
        /// 캐리어 정보 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCst_Click(object sender, EventArgs e)
        {
            //txtCST.Text = Convert.ToInt64(txtCST.Text).ToString("000000");
            //String CSTID = cobGubun.Text + txtCST.Text;
            String CSTID = txtCST.Text.ToUpper();
            CST_List(CSTID);
            CST_Hist(CSTID);
        }
        /// <summary>
        /// 트레이 이력 조회
        /// </summary>
        private void CST_Hist(String CSTID)
        {
            try
            {
                if (txtCST.Text == "") { return; }

                XmlOptionData sqldata = sqlList["CST_Hist"];

                string cquery = sqldata.sql;
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CSTID", string.Concat("%", CSTID, "%"));

                ShowSqltoDGV(grdCstHist, cquery, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} : {System.Reflection.MethodBase.GetCurrentMethod().Name}");
            }

            //if (ds != null)
            //{
            //    if (ds.Tables.Count > 0)
            //    {
            //        foreach (DataRow dr in ds.Tables[0].Rows)
            //        {
            //            idx++;
            //            string[] data = new string[] {
            //                idx.ToString(),
            //                dr["CSTID"].ToString(),
            //                dr["FROM_EQPTID"].ToString(),
            //                dr["FROM_PORT_ID"].ToString(),
            //                dr["TO_EQPTID"].ToString(),
            //                dr["TO_PORT_ID"].ToString(),
            //                dr["CSTSTAT"].ToString(),
            //                dr["RTD_RULE_ID"].ToString(),
            //                dr["CMD_STAT_CODE"].ToString(),
            //                dr["INSUSER"].ToString(),
            //                dr["INSDTTM"].ToString(),
            //                dr["UPDDTTM"].ToString(),
            //            };
            //            grdCstHist.Rows.Add(data);
            //            if (dr["CMDCHK"].ToString() == "1" && (dr["CMD_STAT_CODE"].ToString() != "ABNORMAL_END" && dr["CMD_STAT_CODE"].ToString() != "NORMAL_END"))
            //            {
            //                grdCstHist.Rows[grdCstHist.RowCount - 1].DefaultCellStyle.BackColor = Color.FromArgb(250, 250, 210); //(216, 191, 216);
            //            }
            //        }
            //    }
            //}
        }
        /// <summary>
        /// 공정별 설비상태 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJobStat_Click(object sender, EventArgs e)
        {
            //if (tabMain.SelectedIndex == 3) { Job_state(); }
            txtHistPort.Text = "";
            Job_state();
        }
        /// <summary>
        /// LOT별 작업이력 조회
        /// </summary>
        private void WipActHistList()
        {
            if (txtHistID.Text == "") return;

            string Q = "";

            Q = " SELECT  ";
            Q += "   CSTID";
            Q += " , LOTID";
            Q += " , ACTID";
            Q += " , CONVERT(CHAR(23), ACTDTTM, 20)  AS ACTDTTM";
            Q += " , CONVERT(CHAR(23), AGING_ISS_SCHD_DTTM, 20)  AS AGING_ISS_SCHD_DTTM";
            Q += " , AGING_ISS_PRIORITY_NO ";
            Q += " , ROUTID";
            Q += " , PROCID";
            Q += " , EQSGID";
            Q += " , EQPTID";
            Q += " , WIPSTAT";
            Q += " , USERID";
            Q += " , CONVERT(CHAR(23), INSDTTM, 20) AS INSDTTM";
            Q += " , CONVERT(CHAR(23), UPDDTTM, 20) AS UPDDTTM";
            Q += " FROM wipacthistory with(nolock) ";
            Q += " where lotid like '" + txtHistID.Text + "%'";
            Q += " AND CONVERT(CHAR(20), ACTDTTM, 20) BETWEEN '" + txtHistsDate.Text + "' AND '" + txtHisteDate.Text + "' ";
            Q += " ORDER BY ACTDTTM DESC ";

            //CSTID, LOTID, ACTID, ACTDTTM, ROUTID, FLOWID, PROCID, EQSGID, EQPTID, WIPSTAT, WIPSTAT_PV, USERID, INSDTTM, UPTDTTM
            grdHistory.Columns.Clear();
            grdHistory.Columns.Add("CSTID", "CSTID");
            grdHistory.Columns.Add("LOTID", "LOTID");
            grdHistory.Columns.Add("ACTID", "ACTID");
            grdHistory.Columns.Add("ACTDTTM", "ACTDTTM");
            grdHistory.Columns.Add("ROUTID", "ROUTID");
            grdHistory.Columns.Add("PROCID", "PROCID");
            grdHistory.Columns.Add("EQSGID", "EQSGID");
            grdHistory.Columns.Add("EQPTID", "EQPTID");
            grdHistory.Columns.Add("WIPSTAT", "WIPSTAT");
            grdHistory.Columns.Add("AGING_ISS_SCHD_DTTM", "출고예정시각");
            grdHistory.Columns.Add("AGING_ISS_PRIORITY_NO", "출고구분");
            grdHistory.Columns.Add("USERID", "USERID");
            grdHistory.Columns.Add("INSDTTM", "INSDTTM");
            grdHistory.Columns.Add("UPDDTTM", "UPDDTTM");


            grdHistory.Columns[0].Width = 100; grdHistory.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdHistory.Columns[1].Width = 150; grdHistory.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdHistory.Columns[2].Width = 280;
            grdHistory.Columns[3].Width = 150;
            grdHistory.Columns[4].Width = 80; grdHistory.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdHistory.Columns[5].Width = 80; grdHistory.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdHistory.Columns[6].Width = 80; grdHistory.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdHistory.Columns[7].Width = 100; grdHistory.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdHistory.Columns[8].Width = 80; grdHistory.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdHistory.Columns[9].Width = 170; grdHistory.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdHistory.Columns[10].Width = 80;
            grdHistory.Columns[11].Width = 80;
            grdHistory.Columns[12].Width = 150;
            grdHistory.Columns[13].Width = 150;
            for (int i = 0; i < 13; i++)
            {
                grdHistory.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            SqlDataAdapter R = new SqlDataAdapter(Q, cstr);
            ArrayList ar = new ArrayList();
            DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            R.Fill(ds);

            grdHistory.Rows.Clear();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        string[] data = new string[] {
                                dr["CSTID"].ToString(),
                                dr["LOTID"].ToString(),
                                dr["ACTID"].ToString(),
                                dr["ACTDTTM"].ToString(),
                                dr["ROUTID"].ToString(),
                                dr["PROCID"].ToString(),
                                dr["EQSGID"].ToString(),
                                dr["EQPTID"].ToString(),
                                dr["WIPSTAT"].ToString(),
                                dr["AGING_ISS_SCHD_DTTM"].ToString(),
                                dr["AGING_ISS_PRIORITY_NO"].ToString(),
                                dr["USERID"].ToString(),
                                dr["INSDTTM"].ToString(),
                                dr["UPDDTTM"].ToString(),
                            };
                        grdHistory.Rows.Add(data);
                    }
                }
            }
        }

        private void ChangeDBConn()
        {
            lb_IP.Text = strs[cb_DbString.Text].Server.ToString();
            lb_DbName.Text = strs[cb_DbString.Text].Database.ToString();
            cstr = strs[cb_DbString.Text].ConnectionString();
        }

        private void ChangeDBConn(string dbString )
        {
            lb_IP.Text = strs[dbString].Server.ToString();
            lb_DbName.Text = strs[dbString].Database.ToString();
            cstr = strs[dbString].ConnectionString();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            SettingInit();

            Init();
            //cobGubun.SelectedIndex = 0;
            cobTray.SelectedIndex = 0;
            cobStat.SelectedIndex = 0;
            cobLane.SelectedIndex = 0;
            cobCmdLane.SelectedIndex = 0;
            DateTime sdate = new DateTime();
            sdate = DateTime.Now;

            txtTo.Text = txtFrom.Text = DateTime.Now.ToString();
            txtReqeDate.Value = sdate;
            txtReqsDate.Value = sdate.AddHours(-24);
            txteDate.Value = sdate;
            txtsDate.Value = sdate.AddHours(-24);
            txtHisteDate.Value = sdate;
            txtHistsDate.Value = sdate.AddHours(-24);
            txteTime.Value = sdate;
            txtsTime.Value = sdate.AddHours(-24);

            Init_Search();
        }

        private void SettingInit()
        {
            try
            {
                xml = new XmlData(CommonConstants.sqlXmlPath);
                sqlList = xml.OptionSqlListparser();
                strs = CustomUtils.GetConfigList();
                
                List<string> stringss = strs.Keys.ToList();
                cb_DbString.Items.Clear();
                cb_DbString.DataSource = stringss;

                ChangeDBConn();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// rack 정보 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRack_Click(object sender, EventArgs e)
        {
            if (chkRackCheck.Checked == true)
            {
                // RACK정보가 없는 트레이 조회
                Rack_check();
            }
            else { 
                Rack_list();
                Stocker_state();
            }
        }
        /// <summary>
        /// Rack정보가 존재하지 않는 트레이 조회
        /// </summary>
        private void Rack_check()
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


            grdRack.Rows.Clear();
            grdRack.Columns.Clear();
            grdRack.Columns.Add("SEQ", "순번");
            grdRack.Columns.Add("CSTID", "트레이");
            grdRack.Columns.Add("LOAD_REP_CSTID", "대표트레이");
            grdRack.Columns.Add("CST_LOAD_LOCATION_CODE", "단");
            grdRack.Columns.Add("CURR_LOTID", "LOT");
            grdRack.Columns.Add("TRF_STAT_CODE", "상태");
            grdRack.Columns.Add("PROCID", "PROC");
            grdRack.Columns.Add("WIPSTAT", "WIP");
            grdRack.Columns.Add("S26", "GR");
            grdRack.Columns.Add("EQPT_CUR", "EQPT");
            grdRack.Columns.Add("PORT_CUR", "PORT");
            grdRack.Columns.Add("CURR_RACK_ID", "RACK");
            grdRack.Columns.Add("AGING_ISS_SCHD_DTTM", "출고예정시각");
            grdRack.Columns.Add("REMAIN_MINUTE", "경과시간");
            grdRack.Columns.Add("FINL_ACTDTTM", "최종시각");
            grdRack.Columns.Add("FINL_ACT_EQPTID", "최종설비");
            grdRack.Columns.Add("FINL_ACT_PORT_ID", "최종PORT");
            grdRack.Columns.Add("FINL_ACT_RACK_ID", "최종RACK");

            grdRack.Columns[0].Width = 60; grdRack.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 순번
            grdRack.Columns[1].Width = 100; grdRack.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;      // 대표캐리어
            grdRack.Columns[2].Width = 100; grdRack.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;      // 트레이
            grdRack.Columns[3].Width = 60; grdRack.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 단
            grdRack.Columns[4].Width = 170; grdRack.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;      // LOT
            grdRack.Columns[5].Width = 60; grdRack.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 반송상태
            grdRack.Columns[6].Width = 80; grdRack.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 공정
            grdRack.Columns[7].Width = 60; grdRack.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 작업상태
            grdRack.Columns[8].Width = 60; grdRack.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 그룹
            grdRack.Columns[9].Width = 10; grdRack.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;      // 현재설비
            grdRack.Columns[10].Width = 10; grdRack.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // 현재포트
            grdRack.Columns[11].Width = 10; grdRack.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 현재RACK
            grdRack.Columns[12].Width = 10; grdRack.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 출고예정시각
            grdRack.Columns[13].Width = 80; grdRack.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;      // 경과시간
            grdRack.Columns[14].Width = 170; grdRack.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 최종시각
            grdRack.Columns[15].Width = 100; grdRack.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // 최종설비
            grdRack.Columns[16].Width = 150; grdRack.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // 최종포트
            grdRack.Columns[17].Width = 150; grdRack.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 최종렉

            //string cstr = "Data Source=10.95.9.59,7433;Initial catalog=ESGM_BMES_FORM_P01;User ID=rtd_app;Password=##r51T1980D@!";

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
                        grdRack.Rows.Add(data);
                    }
                }
            }
        }
        private void btnLOT_Click(object sender, EventArgs e)
        {
            // EIO 변경이력
            // LOT 작업이력
            if (rdoHist1.Checked == true)
            {
                WipActHistList();
            }
            else if (rdoHist2.Checked == true)
            {   // 포트정보 변경 이력
                Port_Stat_Hist();
            }
            else if (rdoHist3.Checked == true)
            {   // EIO 상태 변경 이력
                Eqpt_EIO_Hist();
            }
        }

        private void txtCSTID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnOK_Click(sender, e);
            }
        }

        private void txtCSTID_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtCSTID.Text = "";
        }

        private void txtLot_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnLOT_Click(sender, e);
            }
        }

        private void txtCST_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnCst_Click(sender, e);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tabMain.SelectedIndex == 0 && chkAuto.Checked)
            {
                btnOK_Click(sender, e);
            }
        }

        /// <summary>
        /// 설비 실적 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cobSTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            cobEqpt.Items.Clear();
            cobEqpt.Items.Add("ALL");
            if (cobSTO.SelectedIndex == 0)
            {
                cobEqpt.Items.Add("U1FSTO11301");
                cobEqpt.Items.Add("U1FSTO11302");
                cobEqpt.Items.Add("U1FSTO11303");
                cobEqpt.Items.Add("U1FSTO11304");
            }
            else if (cobSTO.SelectedIndex == 1)
            {
                cobEqpt.Items.Add("U1FSTO11305");
                cobEqpt.Items.Add("U1FSTO11306");
            }
            else if (cobSTO.SelectedIndex == 3)
            {
                cobEqpt.Items.Add("U1FSTO11312");
                cobEqpt.Items.Add("U1FSTO11313");
                cobEqpt.Items.Add("U1FSTO11314");
                cobEqpt.Items.Add("U1FSTO11315");
                cobEqpt.Items.Add("U1FSTO11316");
                cobEqpt.Items.Add("U1FSTO11317");
            }
            else if (cobSTO.SelectedIndex == 4)
            {
                cobEqpt.Items.Add("U1FSTO11318");
                cobEqpt.Items.Add("U1FSTO11319");
                cobEqpt.Items.Add("U1FSTO11320");
                cobEqpt.Items.Add("U1FSTO11321");
                cobEqpt.Items.Add("U1FSTO11322");
                cobEqpt.Items.Add("U1FSTO11323");
            }
            else if (cobSTO.SelectedIndex == 5)
            {
                cobEqpt.Items.Add("U1FSTO12301");
                cobEqpt.Items.Add("U1FSTO12302");
            }
            else if (cobSTO.SelectedIndex == 6)
            {
                cobEqpt.Items.Add("U1FSTO12303");
                cobEqpt.Items.Add("U1FSTO12304");
                cobEqpt.Items.Add("U1FSTO12305");
                cobEqpt.Items.Add("U1FSTO12306");
                cobEqpt.Items.Add("U1FSTO12307");
                cobEqpt.Items.Add("U1FSTO12308");
                cobEqpt.Items.Add("U1FSTO12309");
                cobEqpt.Items.Add("U1FSTO12310");
                cobEqpt.Items.Add("U1FSTO12311");
                cobEqpt.Items.Add("U1FSTO12312");
                cobEqpt.Items.Add("U1FSTO12313");
                cobEqpt.Items.Add("U1FSTO12314");
            }
            cobEqpt.SelectedIndex = 0;
        }

        /// <summary>
        /// 버퍼 계산
        /// </summary>
        private void Buffer_List()
        {
            string sPort = "";
            string Q = "";
            Q = "  SELECT  ";
            Q += "                P.EQPTID  ";
            Q += "              , C.CMD_QTY  ";
            Q += "              , ISNULL(SUM(CP.MAX_TRF_QTY), 0) AS BUFFER_QTY  ";
            Q += "  FROM TB_MCS_PORT(NOLOCK) P  ";
            Q += "    INNER JOIN TB_MCS_CURR_PORT(NOLOCK) CP ON P.PORT_ID = CP.PORT_ID  ";
            Q += "              LEFT JOIN(SELECT TC.TO_EQPTID, ISNULL(COUNT(TC.CSTID), 0) AS CMD_QTY  ";
            Q += "                           FROM TB_MHS_TRF_CMD TC WITH(NOLOCK)  ";
            Q += "                          WHERE TC.CMD_STAT_CODE IN( 'RECEIVE', 'MOVING' )  ";
            Q += "                      AND ISNULL(TC.CNCL_REQ_FLAG, '') NOT IN( 'Y', 'S' )  ";
            Q += "                            AND TC.TO_PORT_ID = '" + sPort + "'";
            Q += "                    GROUP BY TC.TO_EQPTID  ";
            Q += "                     ) C ON P.EQPTID = C.TO_EQPTID  ";
            Q += "  WHERE cp.port_id = '" + sPort + "'";
            Q += "         AND P.USE_FLAG = 'Y'  ";
            Q += "  GROUP BY P.EQPTID, C.CMD_QTY  ";

        }

        private void cobJob_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnJobStat_Click(sender, e);
        }
        /// <summary>
        /// 요청/반송 이력조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHist_Click(object sender, EventArgs e)
        {
            if (chkDelHist.Checked == true) Disp_Delete_CMD();
            else if (optReq.Checked) { Disp_Req_Hist(); }
            else { Disp_CMD_Hist(); }
        }
        /// <summary>
        /// 요청이력 조회
        /// </summary>
        private void Disp_Req_Hist()
        {
            try
            {
                XmlOptionData sqldata = sqlList["Disp_Req_Hist"];
                DynamicParameters parameters = new DynamicParameters();
                //using (var connection = new OracleConnection(cstr))

                parameters.Add("@StartDate", txtFrom.Text, dbType: DbType.Date);
                parameters.Add("@EndDate", txtTo.Text, dbType: DbType.Date);
                //cquery += "       WHERE INSDTTM BETWEEN '" + txtFrom.Text + "' AND '" + txtTo.Text + "'";
                
                string cquery = sqldata.sql;
                if (txtID.Text != "") 
                {
                    CustomUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 0);
                    parameters.Add("@CSTID", string.Concat("%", txtID.Text, "%"));
                    //cquery += "  AND CSTID = '" + txtID.Text + "'"
                }
                if (txtFromPort.Text != "") {
                    CustomUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 1);
                    parameters.Add("@PORT_ID", string.Concat("%", txtFromPort.Text, "%"));
                    //cquery += "  AND PORT_ID LIKE '" + txtFromPort.Text + "%'"; 
                }

                CustomUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 2);
                if (cobTray.SelectedIndex == 1) parameters.Add("@CSTSTAT", string.Concat("U"));    // 실트레이
                else if (cobTray.SelectedIndex == 2) parameters.Add("@CSTSTAT", string.Concat("E")); ;    // 공트레이
                                                                                                          //if (cobTray.SelectedIndex == 1) { cquery += " AND CSTSTAT = 'U'"; }
                                                                                                          //else if (cobTray.SelectedIndex == 2) { cquery += " AND CSTSTAT = 'E'"; }
                                                                                                          //cquery += " ORDER BY INSDTTM DESC ";

                ShowSqltoDGV(grdReq, cquery, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} : {System.Reflection.MethodBase.GetCurrentMethod().Name}");
            }
        }
        /// <summary>
        /// 반송이력 조회
        /// </summary>
        private void Disp_CMD_Hist()
        {

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
            cquery += " WHERE INSDTTM BETWEEN '" + txtFrom.Text + "' AND '" + txtTo.Text + "'";
            if (txtID.Text != "") { cquery += " AND CSTID LIKE '%" + txtID.Text + "%'"; }
            if (txtFromPort.Text != "") { cquery += " AND FROM_PORT_ID LIKE '%" + txtFromPort.Text + "%'"; }
            if (txtToPort.Text != "") { cquery += " AND TO_PORT_ID LIKE '%" + txtToPort.Text + "%'"; }
            if (cobTray.SelectedIndex == 1) { cquery += " AND CSTSTAT = 'U'"; }
            else if (cobTray.SelectedIndex == 2) { cquery += " AND CSTSTAT = 'E'"; }
            if (cobStat.SelectedIndex != 0) { cquery += " AND CMD_STAT_CODE = '" + cobStat.Text + "'"; }
            if(txtRuleList.Text.Trim() != "") { cquery += " AND RTD_RULE_ID = '" + txtRuleList.Text + "'"; }
        
            cquery += " ORDER BY INSDTTM  ";

            //CSTID, LOTID, ACTID, ACTDTTM, ROUTID, FLOWID, PROCID, EQSGID, EQPTID, WIPSTAT, WIPSTAT_PV, USERID, INSDTTM, UPTDTTM
            grdHist.Columns.Clear();
            grdHist.Columns.Add("SEQ", "순번");
            grdHist.Columns.Add("CSTID", "CSTID");
            grdHist.Columns.Add("FROM_EQPTID", "요청설비");
            grdHist.Columns.Add("FROM_PORT_ID", "요청포트");
            grdHist.Columns.Add("TO_EQPTID", "목적설비");
            grdHist.Columns.Add("TO_PORT_ID", "목적포트");
            grdHist.Columns.Add("CSTSTAT", "상태");
            grdHist.Columns.Add("RTD_RULE_ID", "RULE");
            grdHist.Columns.Add("CMD_STAT_CODE", "진행상태");
            grdHist.Columns.Add("INSUSER", "요청자");
            grdHist.Columns.Add("INSDTTM", "INSDTTM");
            grdHist.Columns.Add("UPDDTTM", "UPDDTTM");


            grdHist.Columns[0].Width = 70; grdHist.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 순번
            grdHist.Columns[1].Width = 120; grdHist.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;      //cstid
            grdHist.Columns[2].Width = 120; grdHist.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;        // 요청설비
            grdHist.Columns[3].Width = 150; grdHist.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;        // 요청포트
            grdHist.Columns[4].Width = 120; grdHist.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;        // 목적설비
            grdHist.Columns[5].Width = 150; grdHist.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;        // 목적포트
            grdHist.Columns[6].Width = 80; grdHist.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 상태
            grdHist.Columns[7].Width = 170; grdHist.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;        // rule
            grdHist.Columns[8].Width = 120; grdHist.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;      // 진행상태
            grdHist.Columns[9].Width = 120; grdHist.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;      // 요청자
            grdHist.Columns[10].Width = 150; grdHist.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // 등록시각
            grdHist.Columns[11].Width = 150; grdHist.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // 업데이트시각
            //for (int i = 0; i < 12; i++)
            //{
            //    grdHist.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            //}

            //string cstr = "Data Source=10.95.9.59,7433;Initial catalog=ESGM_BMES_FORM_P01;User ID=rtd_app;Password=##r51T1980D@!";

            txtSQL.Text = cquery;
            SqlDataAdapter R = new SqlDataAdapter(cquery, cstr);
            ArrayList ar = new ArrayList();
            DataSet ds = new DataSet();
            R.Fill(ds);

            int idx = 0;
            grdHist.Rows.Clear();
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
                        grdHist.Rows.Add(data);
                    }
                }
            }
        }

        /// <summary>
        /// 반송 삭제 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Disp_Delete_CMD()
        {

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
            cquery += "            , CONVERT(NVARCHAR(20), MAX(INSDTTM),20) AS LASTINSDTTM ";
            cquery += "            , COUNT(CSTID)  AS CNT ";
            cquery += " FROM TB_MHS_TRF_CMD_HIST with(nolock) ";
            cquery += " WHERE CONVERT(NVARCHAR(10), INSDTTM, 20) BETWEEN '" + txtFrom.Text.Substring(0,10) + "' AND '" + txtTo.Text.Substring(0, 10) + "'";
            cquery += "  AND CMD_STAT_CODE = 'DELETE' ";
            cquery += " GROUP BY CSTID, FROM_EQPTID, FROM_PORT_ID, TO_EQPTID, TO_PORT_ID, CSTSTAT, RTD_RULE_ID, CMD_STAT_CODE, INSUSER  ";
            cquery += " ORDER BY MAX(INSDTTM) DESC ";

            //CSTID, LOTID, ACTID, ACTDTTM, ROUTID, FLOWID, PROCID, EQSGID, EQPTID, WIPSTAT, WIPSTAT_PV, USERID, INSDTTM, UPTDTTM
            grdHist.Columns.Clear();
            grdHist.Columns.Add("SEQ", "순번");
            grdHist.Columns.Add("CSTID", "CSTID");
            grdHist.Columns.Add("FROM_EQPTID", "요청설비");
            grdHist.Columns.Add("FROM_PORT_ID", "요청포트");
            grdHist.Columns.Add("TO_EQPTID", "목적설비");
            grdHist.Columns.Add("TO_PORT_ID", "목적포트");
            grdHist.Columns.Add("CSTSTAT", "상태");
            grdHist.Columns.Add("RTD_RULE_ID", "RULE");
            grdHist.Columns.Add("CMD_STAT_CODE", "진행상태");
            grdHist.Columns.Add("INSUSER", "요청자");
            grdHist.Columns.Add("LASTINSDTTM", "LASTINSDTTM");
            grdHist.Columns.Add("CNT", "횟수");


            grdHist.Columns[0].Width = 70; grdHist.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 순번
            grdHist.Columns[1].Width = 120; grdHist.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;      //cstid
            grdHist.Columns[2].Width = 120; grdHist.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;        // 요청설비
            grdHist.Columns[3].Width = 150; grdHist.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;        // 요청포트
            grdHist.Columns[4].Width = 120; grdHist.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;        // 목적설비
            grdHist.Columns[5].Width = 150; grdHist.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;        // 목적포트
            grdHist.Columns[6].Width = 80; grdHist.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 상태
            grdHist.Columns[7].Width = 170; grdHist.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;        // rule
            grdHist.Columns[8].Width = 120; grdHist.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;      // 진행상태
            grdHist.Columns[9].Width = 120; grdHist.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;      // 요청자
            grdHist.Columns[10].Width = 150; grdHist.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // 마지막 생성시각
            grdHist.Columns[11].Width = 100; grdHist.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // 횟수

            //string cstr = "Data Source=10.95.9.59,7433;Initial catalog=ESGM_BMES_FORM_P01;User ID=rtd_app;Password=##r51T1980D@!";

            txtSQL.Text = cquery;
            SqlDataAdapter R = new SqlDataAdapter(cquery, cstr);
            ArrayList ar = new ArrayList();
            DataSet ds = new DataSet();
            R.Fill(ds);

            int idx = 0;
            grdHist.Rows.Clear();
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
                                dr["LASTINSDTTM"].ToString(),
                                dr["CNT"].ToString(),
                            };
                        grdHist.Rows.Add(data);
                    }
                }
            }
        }
        private void chkOrder_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOrder.Checked)
            {
                btnRack_Click(sender, e);
                chkOrder.ForeColor = Color.Red;
            }
            else
            {
                btnRack_Click(sender, e);
                chkOrder.ForeColor = Color.Black;
            }
        }
        /// <summary>
        /// 트레이 목록 더블클릭 -> 라우트정보 표시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdCST_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
            {
                string CSTID = grdCST.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                txtCST.Text = CSTID;
                CST_List(CSTID);
                CST_Hist(CSTID);
                return;
            }

            if (e.ColumnIndex == 12)
            {
                string ROUTID = grdCST.Rows[e.RowIndex].Cells[12].Value.ToString();
                string PROCID = grdCST.Rows[e.RowIndex].Cells[13].Value.ToString();
                if (ROUTID == "") return;
                FrmRout frout = new FrmRout();
                frout.ROUTID = ROUTID;
                frout.PROCID = PROCID;
                frout.ShowDialog();
            }
        }

        /// <summary>
        /// 2단 적재 트레이 정보 확인 쿼리
        /// 참고 biz : BR_MHS_DecideStackAble -DA_MHS_SEL_CARRIER_FOR_STACKABLE
        /// </summary>
        /// <param name="CSTID1"></param>
        /// <param name="CSTID2"></param>
        private void Check_Cst_Info(string CSTID1, string CSTID2)
        {
            string Q = "";
            //-------------------------------------------
            //-------------------------------------------
            //---2단 적재 트레이 정보 확인 쿼리
            //---CSTSTAT, PROCID_CUR, SPCL_FLAG, ASSY_LOT_ID, LOT_TYPE
            //------------------------------------------ -
            //-------------------------------------------
            Q += "        SELECT C.CSTID  ";
            Q += "           ,C.CSTSTAT  ";
            Q += "             ,W.LOTID  ";
            Q += "           ,W.WIPSTAT  ";
            Q += "           ,C.TRAY_TYPE_CODE  ";
            Q += "           ,ISNULL(CT.CST_STACK_CNT, 0) AS CST_STACK_CNT  ";
            Q += "            , W.ROUTID  ";
            Q += "           ,W.PROCID AS PROCID_CUR  ";
            Q += "           ,WA.PROD_LOTID  ";
            Q += "           ,WA.SPCL_FLAG  ";
            Q += "           ,WA.SPCL_LOT_GR_CODE  ";
            Q += "           ,WA.DAY_GR_LOTID AS ASSY_LOT_ID  ";
            Q += "           ,WA.FORM_SPCL_GR_ID  ";
            Q += "           ,WA.SPCL_NOTE  ";
            Q += "           ,L.LOTTYPE  ";
            Q += "           ,C.EQPT_CUR  ";
            Q += "           ,WA.LOT_DETL_TYPE_CODE  ";
            Q += "           ,WA.DFCT_LIMIT_OVER_FLAG  ";
            Q += "       FROM CARRIER C(NOLOCK)  ";
            Q += "      LEFT OUTER JOIN TB_MMD_FCS_CST_TYPE CT(NOLOCK) ON C.CURR_AREAID = CT.AREAID AND C.TRAY_TYPE_CODE = CT.CST_TYPE_CODE  ";
            Q += "      LEFT OUTER JOIN WIPATTR WA(NOLOCK) ON C.CURR_LOTID = WA.LOTID  ";
            Q += "      LEFT OUTER JOIN WIP W(NOLOCK) ON C.CURR_LOTID = W.LOTID  ";
            Q += "      LEFT OUTER JOIN LOT L(NOLOCK) ON W.LOTID = L.LOTID  ";
            Q += "      WHERE C.CSTID IN('" + CSTID1 + "','" + CSTID2 + "')  ";
            Q += "        AND C.CSTIUSE = 'Y'  ";
        }

        private void txtCST1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnRack_Click(sender, e);
            }
        }
        /// <summary>
        /// 요청 및 반송목록 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnOK_Click(sender, e);
            }
        }

        private void txtPort_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtPort.Text = "";
        }

        private void grdSubStat_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string PORTID = grdSubStat.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (PORTID != "")
            {
                //chkEio.Checked = false;
                txtHistPort.Text = PORTID;
                Eqpt_Sub_Stat_List();
            }
        }

        private void txtHistPort_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtHistPort.Text = "";
        }

        private void btnCnt_Click(object sender, EventArgs e)
        {
            FrmSubList f = new RTD_APP_NEW.FrmSubList();
            f.ShowDialog();
        }

        private void txtCST1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtCST1.Text = "";
        }

        private void grdReq_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                string CSTID = grdReq.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                //MessageBox.Show(CSTID);
                FrmTrayInfo ftray = new FrmTrayInfo();
                ftray.CSTID = CSTID;
                ftray.ShowDialog();
            }
            else if (e.ColumnIndex == 6)        // 반송구분
            {
                string CSTID = grdReq.Rows[e.RowIndex].Cells[1].Value.ToString();
                string sSeqNo = grdReq.Rows[e.RowIndex].Cells[13].Value.ToString();

                if (sSeqNo != "")
                {
                    FrmReqHist fRHist = new FrmReqHist();
                    fRHist.SEQNO = sSeqNo;
                    fRHist.ShowDialog();
                }
            }
            else if (e.ColumnIndex == 12)       // LOG
            {
                // log 항목 더블클릭시
                string sLog = grdReq.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                string sRule = grdReq.Rows[e.RowIndex].Cells[7].Value.ToString();

                if (sLog != "")
                {
                    FrmLogs fLog = new FrmLogs();
                    fLog.sLog = sLog;
                    fLog.RuleName = sRule;
                    fLog.ShowDialog();
                }
            }
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime sdate = new DateTime();
            sdate = DateTime.Now;

            //switch (tabMain.SelectedIndex)
            //{
            //    case 0:
            txtReqeDate.Value = sdate;
            txtReqsDate.Value = sdate.AddHours(-24);
            //        break;
            //    case 1:
            txteDate.Value = sdate;
            txtsDate.Value = sdate.AddHours(-24);
            //        break;
            //    case 9:
            //        txtHisteDate.Value = sdate;
            //        txtHistsDate.Value = sdate.AddHours(-24);
            //        break;
            //    case 10:
            //        txtTo.Value = sdate;
            //        txtFrom.Value = sdate.AddHours(-24);
            //        break;
            //    case 11:
            //        txteTime.Value = sdate;
            //        txtsTime.Value = sdate.AddHours(-24);
            //        break;
            //}
        }

        private void grdList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)         // 캐리어id
            {
                string CSTID = grdList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (CSTID != "")
                {
                    FrmTrayInfo ftray = new FrmTrayInfo();
                    ftray.CSTID = CSTID;
                    ftray.ShowDialog();
                }
            }
            if (e.ColumnIndex == 3)         // 요청정보 조회
            {
                string sSeqNo = grdList.Rows[e.RowIndex].Cells[19].Value.ToString();

                if (sSeqNo != "")
                {
                    FrmReqHist fRHist = new FrmReqHist();
                    fRHist.SEQNO = sSeqNo;
                    fRHist.ShowDialog();
                }
            }
            else if (e.ColumnIndex == 5)       // 목적포트
            {
                string PORT_ID = grdList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                txtPort.Text = PORT_ID;
            }
            else if (e.ColumnIndex == 8)       // ROUT 조회
            {
                string ROUTID = grdList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                string PROCID = grdList.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value.ToString();
                if (ROUTID != "")
                {
                    FrmRout Frout = new FrmRout();
                    Frout.Text = ROUTID;
                    Frout.ROUTID = ROUTID;
                    Frout.PROCID = PROCID;
                    Frout.ShowDialog();
                }
            }

        }
        /// <summary>
        /// 캐리어 작업 이력 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCstHist_Click(object sender, EventArgs e)
        {
            if (rdoActHist.Checked == true)
            {
                Tray_Act_Hist();
            }
            else if (rdoEventHist.Checked == true)
            {
                Tray_Event_Hist();
            }
        }
        /// <summary>
        /// Tray 작업이력 조회 처리
        /// </summary>
        private void Tray_Act_Hist()
        {
            if (txtCstId_Act.Text == "") return;

            string Q = "";
            string cstid = "";

            cstid = txtCstId_Act.Text;
            if(txtCstId_Act.Text.IndexOf(',')>=0)
            {
                cstid = Text_Split(txtCstId_Act.Text);
            }

            Q = " SELECT  ";
            Q += "   CSTID";
            Q += " , LOAD_REP_CSTID";
            Q += " , ACTID";
            Q += " , CONVERT(CHAR(23), ACTDTTM, 20)  AS ACTDTTM";
            Q += " , CSTSTAT";
            Q += " , EQPTID";
            Q += " , PROCID";
            Q += " , LOTID";
            Q += " , TRF_STAT_CODE";
            Q += " , CST_LOAD_LOCATION_CODE";
            Q += " , PORT_ID";
            Q += " , RACK_ID";
            Q += " , CSTIUSE";
            Q += " , INSUSER";
            Q += " , CONVERT(CHAR(23), INSDTTM, 20) AS INSDTTM";
            Q += " , CONVERT(CHAR(23), UPDDTTM, 20) AS UPDDTTM";
            Q += " FROM tb_sfc_cst_act_hist with(nolock) ";
            if (txtCstId_Act.Text.IndexOf(',') >= 0)
            {
                Q += " where CSTID  IN (" + cstid + ")";
            }
            else
            {
                Q += " where CSTID ='" + txtCstId_Act.Text + "'";
            }
            Q += "   and ACTDTTM BETWEEN '" + txtsTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + txteTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' ";
            Q += " ORDER BY ACTDTTM DESC ";

            //CSTID, LOTID, ACTID, ACTDTTM, ROUTID, FLOWID, PROCID, EQSGID, EQPTID, WIPSTAT, WIPSTAT_PV, USERID, INSDTTM, UPTDTTM
            grdCstActHist.Columns.Clear();
            grdCstActHist.Columns.Add("CSTID", "CSTID");
            grdCstActHist.Columns.Add("LOAD_REP_CSTID", "대표CST");
            grdCstActHist.Columns.Add("ACTID", "명령");
            grdCstActHist.Columns.Add("ACTDTTM", "명령시간");
            grdCstActHist.Columns.Add("CSTSTAT", "상태");
            grdCstActHist.Columns.Add("EQPTID", "설비");
            grdCstActHist.Columns.Add("PROCID", "PROC");
            grdCstActHist.Columns.Add("LOTID", "LOT");
            grdCstActHist.Columns.Add("TRF_STAT_CODE", "진행상태");
            grdCstActHist.Columns.Add("CST_LOAD_LOCATION_CODE", "캐리어위치");
            grdCstActHist.Columns.Add("PORT_ID", "포트");
            grdCstActHist.Columns.Add("RACK_ID", "RACK");
            grdCstActHist.Columns.Add("INSUSER", "등록담당");
            grdCstActHist.Columns.Add("INSDTTM", "INSDTTM");
            grdCstActHist.Columns.Add("UPDDTTM", "UPDDTTM");


            grdCstActHist.Columns[0].Width = 100; grdCstActHist.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdCstActHist.Columns[1].Width = 100; grdCstActHist.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdCstActHist.Columns[2].Width = 280; grdCstActHist.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grdCstActHist.Columns[3].Width = 180;
            grdCstActHist.Columns[4].Width = 80; grdCstActHist.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // 상태
            grdCstActHist.Columns[5].Width = 100; grdCstActHist.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //설비
            grdCstActHist.Columns[6].Width = 100; grdCstActHist.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // PROCID
            grdCstActHist.Columns[7].Width = 180; grdCstActHist.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // LOTID
            grdCstActHist.Columns[8].Width = 80; grdCstActHist.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;   //  진행상태
            grdCstActHist.Columns[9].Width = 100; grdCstActHist.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // 캐리어 위치
            grdCstActHist.Columns[10].Width = 180; grdCstActHist.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;  // 포트
            grdCstActHist.Columns[11].Width = 180; grdCstActHist.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // rack
            grdCstActHist.Columns[12].Width = 80;
            grdCstActHist.Columns[13].Width = 150;
            grdCstActHist.Columns[14].Width = 150;
            for (int i = 0; i < 15; i++)
            {
                grdCstActHist.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            //string cstr = "Data Source=10.95.9.59,7433;Initial catalog=ESGM_BMES_FORM_P01;User ID=rtd_app;Password=##r51T1980D@!";

            SqlDataAdapter R = new SqlDataAdapter(Q, cstr);
            ArrayList ar = new ArrayList();
            DataSet ds = new DataSet();
            R.Fill(ds);


            grdCstActHist.Rows.Clear();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        string[] data = new string[] {
                                dr["CSTID"].ToString(),
                                dr["LOAD_REP_CSTID"].ToString(),
                                dr["ACTID"].ToString(),
                                dr["ACTDTTM"].ToString(),
                                dr["CSTSTAT"].ToString(),
                                dr["EQPTID"].ToString(),
                                dr["PROCID"].ToString(),
                                dr["LOTID"].ToString(),
                                dr["TRF_STAT_CODE"].ToString(),
                                dr["CST_LOAD_LOCATION_CODE"].ToString(),
                                dr["PORT_ID"].ToString(),
                                dr["RACK_ID"].ToString(),
                                dr["INSUSER"].ToString(),
                                dr["INSDTTM"].ToString(),
                                dr["UPDDTTM"].ToString(),
                            };
                        grdCstActHist.Rows.Add(data);
                    }
                }
            }
        }
        /// <summary>
        /// Tray Event Hist
        /// </summary>
        private void Tray_Event_Hist()
        {
            if (txtCstId_Act.Text == "") return;

            string Q = "";

            Q = " SELECT  ";
            Q += "   CSTID";
            Q += " , CSTSTAT";
            Q += " , LOTID";
            Q += " , PROCID";
            Q += " , EQPTID";
            Q += " , PORT_ID";
            Q += " , RACK_ID";
            Q += " , EVENT_CODE";
            Q += " , EVENT_TYPE_CODE";
            Q += " , TRF_END_CODE";
            Q += " , FINL_TO_EQPTID";
            Q += " , FINL_TO_PORT_ID";
            Q += " , INSUSER ";
            Q += " , CONVERT(CHAR(23), INSDTTM, 20)  AS INSDTTM";
            Q += " , CONVERT(CHAR(23), UPDDTTM, 20)  AS UPDDTTM";
            Q += " FROM TB_MHS_TRF_EVENT_HIST with(nolock) ";
            Q += " where CSTID ='" + txtCstId_Act.Text + "'";
            Q += "   and INSDTTM BETWEEN '" + txtsTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + txteTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' ";
            Q += " ORDER BY INSDTTM DESC ";

            //CSTID, LOTID, ACTID, ACTDTTM, ROUTID, FLOWID, PROCID, EQSGID, EQPTID, WIPSTAT, WIPSTAT_PV, USERID, INSDTTM, UPTDTTM
            grdCstActHist.Columns.Clear();
            grdCstActHist.Columns.Add("UPDDTTM", "시각");
            grdCstActHist.Columns.Add("CSTID", "CSTID");
            grdCstActHist.Columns.Add("CSTSTAT", "상태");
            grdCstActHist.Columns.Add("LOTID", "LOT");
            grdCstActHist.Columns.Add("PROCID", "PROC");
            grdCstActHist.Columns.Add("EQPTID", "설비");
            grdCstActHist.Columns.Add("PORT_ID", "포트");
            grdCstActHist.Columns.Add("RACK_ID", "위치");
            grdCstActHist.Columns.Add("EVENT_CODE", "EVENT");
            grdCstActHist.Columns.Add("EVENT_TYPE_CODE", "RESULT");
            grdCstActHist.Columns.Add("TRF_END_CODE", "END_CODE");
            grdCstActHist.Columns.Add("FINL_TO_EQPTID", "목적설비");
            grdCstActHist.Columns.Add("FINL_TO_PORT_ID", "목적설비");
            grdCstActHist.Columns.Add("INSUSER", "등록담당");
            grdCstActHist.Columns.Add("INSDTTM", "등록시각");

            grdCstActHist.Columns[0].Width = 150; grdCstActHist.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdCstActHist.Columns[1].Width = 110; grdCstActHist.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdCstActHist.Columns[2].Width = 60; grdCstActHist.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdCstActHist.Columns[3].Width = 140; grdCstActHist.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grdCstActHist.Columns[4].Width = 80; grdCstActHist.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdCstActHist.Columns[5].Width = 110; grdCstActHist.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grdCstActHist.Columns[6].Width = 150; grdCstActHist.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grdCstActHist.Columns[7].Width = 170; grdCstActHist.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grdCstActHist.Columns[8].Width = 170; grdCstActHist.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grdCstActHist.Columns[9].Width = 60; grdCstActHist.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdCstActHist.Columns[10].Width = 60; grdCstActHist.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdCstActHist.Columns[11].Width = 100; grdCstActHist.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grdCstActHist.Columns[12].Width = 170; grdCstActHist.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grdCstActHist.Columns[13].Width = 100; grdCstActHist.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdCstActHist.Columns[14].Width = 200; grdCstActHist.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            for (int i = 0; i < 14; i++)
            {
                grdCstActHist.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            //string cstr = "Data Source=10.95.9.59,7433;Initial catalog=ESGM_BMES_FORM_P01;User ID=rtd_app;Password=##r51T1980D@!";

            SqlDataAdapter R = new SqlDataAdapter(Q, cstr);
            ArrayList ar = new ArrayList();
            DataSet ds = new DataSet();
            R.Fill(ds);


            grdCstActHist.Rows.Clear();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        string[] data = new string[] {
                                dr["UPDDTTM"].ToString(),
                                dr["CSTID"].ToString(),
                                dr["CSTSTAT"].ToString(),
                                dr["LOTID"].ToString(),
                                dr["PROCID"].ToString(),
                                dr["EQPTID"].ToString(),
                                dr["PORT_ID"].ToString(),
                                dr["RACK_ID"].ToString(),
                                dr["EVENT_CODE"].ToString(),
                                dr["EVENT_TYPE_CODE"].ToString(),
                                dr["TRF_END_CODE"].ToString(),
                                dr["FINL_TO_EQPTID"].ToString(),
                                dr["FINL_TO_PORT_ID"].ToString(),
                                dr["INSUSER"].ToString(),
                                dr["INSDTTM"].ToString()
                            };
                        grdCstActHist.Rows.Add(data);
                    }
                }
            }
        }
        /// <summary>
        /// 포트 상태변경 이력        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Port_Stat_Hist()
        {
            if (txtHistID.Text == "") return;

            string Q = "";

            Q = " SELECT  ";
            Q += "  CONVERT(CHAR(23), ACTDTTM, 20)  AS ACTDTTM";
            Q += " , PORT_ID";
            Q += " , PORT_STAT_CODE";
            Q += " , MTRL_EXST_FLAG";
            Q += " , MCS_CST_ID";
            Q += " , INSUSER ";
            Q += " , CONVERT(CHAR(23), INSDTTM, 20)  AS INSDTTM";
            Q += " FROM TB_MCS_PORT_STAT_HIST with(nolock) ";
            Q += " where PORT_ID like '%" + txtHistID.Text + "%'";
            Q += "   and ACTDTTM BETWEEN '" + txtHistsDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + txtHisteDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' ";
            Q += " ORDER BY ACTDTTM DESC ";

            //CSTID, LOTID, ACTID, ACTDTTM, ROUTID, FLOWID, PROCID, EQSGID, EQPTID, WIPSTAT, WIPSTAT_PV, USERID, INSDTTM, UPTDTTM
            grdHistory.Columns.Clear();
            grdHistory.Columns.Add("ACTDTTM", "ACT TIME");
            grdHistory.Columns.Add("PORT_ID", "PORT");
            grdHistory.Columns.Add("PORT_STAT_CODE", "상태");
            grdHistory.Columns.Add("MCS_CST_ID", "CSTID");
            grdHistory.Columns.Add("INSUSER", "등록담당");
            grdHistory.Columns.Add("INSDTTM", "등록시각");

            grdHistory.Columns[0].Width = 200; grdHistory.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdHistory.Columns[1].Width = 180; grdHistory.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdHistory.Columns[2].Width = 100; grdHistory.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grdHistory.Columns[3].Width = 120; grdHistory.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdHistory.Columns[4].Width = 120; grdHistory.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdHistory.Columns[5].Width = 200; grdHistory.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            for (int i = 0; i < 5; i++)
            {
                grdHistory.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            //string cstr = "Data Source=10.95.9.59,7433;Initial catalog=ESGM_BMES_FORM_P01;User ID=rtd_app;Password=##r51T1980D@!";

            SqlDataAdapter R = new SqlDataAdapter(Q, cstr);
            ArrayList ar = new ArrayList();
            DataSet ds = new DataSet();
            R.Fill(ds);


            grdHistory.Rows.Clear();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        string[] data = new string[] {
                                dr["ACTDTTM"].ToString(),
                                dr["PORT_ID"].ToString(),
                                dr["PORT_STAT_CODE"].ToString(),
                                dr["MCS_CST_ID"].ToString(),
                                dr["INSUSER"].ToString(),
                                dr["INSDTTM"].ToString()
                            };
                        grdHistory.Rows.Add(data);
                    }
                }
            }
        }
        /// <summary>
        /// 설비 상태 이력 조회
        /// </summary>
        private void Eqpt_EIO_Hist()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCstId_Act_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtCstId_Act.Text = "";
        }

        private void txtCstId_Act_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnCstHist_Click(sender, e);
            }
        }

        private void cobEqpt_SelectedIndexChanged(object sender, EventArgs e)
        {
            //btnRack_Click(sender, e);
        }

        private void grdRack_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(chkRackCheck.Checked==true)
            {   // 누락된 rack정보 조회시 column이 다름
                if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
                {
                    string CSTID = grdRack.Rows[e.RowIndex].Cells[2].Value.ToString();
                    FrmTrayInfo ftray = new FrmTrayInfo();
                    ftray.CSTID = CSTID;
                    ftray.ShowDialog();
                }
                return;
            }

            if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {
                string CSTID = grdRack.Rows[e.RowIndex].Cells[3].Value.ToString();
                FrmTrayInfo ftray = new FrmTrayInfo();
                ftray.CSTID = CSTID;
                ftray.ShowDialog();
            }
            else if (e.ColumnIndex == 8)
            {
                string ROUTID = grdRack.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                string PROCID = grdRack.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value.ToString();
                FrmRout FRout = new FrmRout();
                FRout.ROUTID = ROUTID;
                FRout.Text = ROUTID;
                FRout.PROCID = PROCID;
                FRout.ShowDialog();
            }
        }

        // 공백 grid
        private void Init_Search()
        {
            // 설비별 반송 현황 COMBO BOX
            cobEQGR.Items.Clear();  //1568du
            //cobEQGR.Items.AddRange(new string[] { "전체", "PKG", "CNV", "HPC", "DEG", "FOR", "SEL", "JGF", "EOL", "STO" });
            cobEQGR.Items.AddRange(new string[] { "전체", "HPC(U)", "DEG(D)", "SEL(6)", "OCV(8)", "DIS(1)", "EOL(5)" });
            cobEQGR.SelectedIndex = 0;

            grdSearch.Rows.Clear();
            grdSearch.Columns.Add("CSTID", "CSTID");
            grdSearch.Columns[0].Width = 150; grdSearch.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grdSearch.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            string csts = "";
            if (grdSearch.Rows.Count <= 0)
            {
                txtTemp.Text = "";
                return;
            }
            for (int idx = 0; idx <= grdSearch.Rows.Count - 1; idx++)
            {
                csts += "'" + grdSearch.Rows[idx].Cells[1].Value.ToString() + "',";
            }
            csts = csts.Trim();
            csts = csts.Substring(0, csts.Length - 1);
            CSTs_Search(csts);
        }

        private void grdSearch_KeyDown(object sender, KeyEventArgs e)
        {
            // Ctrl + V를 눌렀을 때

            if (e.Control && e.KeyCode == Keys.V)
            {
                txtTemp.Text = "";
                // 클립보드 내용을 가져와 개행 문자로 분리
                string data = Clipboard.GetText();
                txtTemp.Text = data;
                string[] rdata = data.Trim().Split('\n');
                if (data.Length < 1) return;

                grdSearch.Columns.Clear();
                grdSearch.Columns.Add("NO", "순번");
                grdSearch.Columns.Add("CSTID", "CSTID");
                grdSearch.Columns[0].Width = 60; grdSearch.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // SEQ
                grdSearch.Columns[1].Width = 100; grdSearch.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // CSTID
                grdSearch.Rows.Clear();
                int idx = 0;
                // 클릭한 셀 아래로 행을 증가하면서 붙여넣기
                foreach (string row in rdata)
                {
                    grdSearch.Rows.Add();
                    grdSearch.Rows[idx].Cells[0].Value = (idx + 1).ToString();
                    grdSearch.Rows[idx].Cells[1].Value = row.Replace('\r', ' ').Trim();
                    idx++;
                }
            }
        }

        private void grdSearch_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                string CSTID = grdSearch.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Replace('\r', ' ').Trim();
                FrmTrayInfo ftray = new FrmTrayInfo();
                ftray.CSTID = CSTID;
                ftray.ShowDialog();
            }
        }
        private void CSTs_Search(string CSTS)
        {
            //string cstr = "Data Source=10.95.9.59,7433;Initial catalog=ESGM_BMES_FORM_P01;User ID=rtd_app;Password=##r51T1980D@!";


            grdSearch.Columns.Clear();
            grdSearch.Columns.Add("SEQ", "순번");
            grdSearch.Columns.Add("CSTID", "트레이");
            grdSearch.Columns.Add("LOAD_REP_CSTID", "대표트레이");
            grdSearch.Columns.Add("CST_LOAD_LOCATION_CODE", "단");
            grdSearch.Columns.Add("CSTSTAT", "구분");
            grdSearch.Columns.Add("TRAY_TYPE_CODE", "타입");
            grdSearch.Columns.Add("CURR_LOTID", "LOT");
            grdSearch.Columns.Add("WIPSTAT", "WIPSTAT");
            grdSearch.Columns.Add("CURR_RACK_ID", "RACK위치");
            grdSearch.Columns.Add("EQPTID", "설비");
            grdSearch.Columns.Add("PORT_ID", "포트");
            grdSearch.Columns.Add("ROUTID", "ROUT");
            grdSearch.Columns.Add("PROCID", "WIP.PROCID");
            grdSearch.Columns.Add("LOTTYPE", "LOTTYPE");
            grdSearch.Columns.Add("ASSY_LOTID", "조립LOT");
            grdSearch.Columns.Add("SPCL_FLAG", "스페셜");
            grdSearch.Columns.Add("LOT_DETL_TYPE_CODE", "LOT_DETL_TYPE_CODE");
            grdSearch.Columns.Add("DFCT_LIMIT_OVER_FLAG", "전셀불량");
            grdSearch.Columns.Add("DFCT_OCCR_EQPTID", "발생설비");
            grdSearch.Columns.Add("SPCL_NOTE", "SPCL_NOTE");
            grdSearch.Columns.Add("FORM_SPCL_GR_ID", "FORM_SPCL_GR_ID");
            grdSearch.Columns.Add("AGING_ISS_SCHD_DTTM", "출고예정시각");
            grdSearch.Columns.Add("AGING_ISS_PRIORITY", "우선순위");
            grdSearch.Columns.Add("UPDDTTM", "업데이트일시");


            grdSearch.Columns[0].Width = 60; grdSearch.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // SEQ
            grdSearch.Columns[1].Width = 100; grdSearch.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // CSTID
            grdSearch.Columns[2].Width = 100; grdSearch.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // 대표 트레이
            grdSearch.Columns[3].Width = 60; grdSearch.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 단
            grdSearch.Columns[4].Width = 60; grdSearch.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 공실구분
            grdSearch.Columns[5].Width = 60; grdSearch.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 타입
            grdSearch.Columns[6].Width = 150; grdSearch.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // LOT
            grdSearch.Columns[7].Width = 80; grdSearch.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // WIP STAT
            grdSearch.Columns[8].Width = 150; grdSearch.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // RACK
            grdSearch.Columns[9].Width = 110; grdSearch.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // EQPT
            grdSearch.Columns[10].Width = 150; grdSearch.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // PORT
            grdSearch.Columns[11].Width = 100; grdSearch.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // ROUT
            grdSearch.Columns[12].Width = 100; grdSearch.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // procid
            grdSearch.Columns[13].Width = 100; grdSearch.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // LOTTYPE
            grdSearch.Columns[14].Width = 100; grdSearch.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // 조립LOT
            grdSearch.Columns[15].Width = 80; grdSearch.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // 스페셜구분
            grdSearch.Columns[16].Width = 80; grdSearch.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // LOT DELT TYPE CODE
            grdSearch.Columns[17].Width = 100; grdSearch.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // DFCT LIMIT OVER FLAG, 전셀불량
            grdSearch.Columns[18].Width = 100; grdSearch.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // DFCT OCCR_EQPTID, 설비
            grdSearch.Columns[19].Width = 150; grdSearch.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // SPCL NOTE
            grdSearch.Columns[20].Width = 80; grdSearch.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // FORM_SPCL_GR_ID
            grdSearch.Columns[21].Width = 150; grdSearch.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // 출고예정시각
            grdSearch.Columns[22].Width = 80; grdSearch.Columns[22].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // PRIORITY
            grdSearch.Columns[23].Width = 150; grdSearch.Columns[23].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // UPDDTTM


            //for (int i = 0; i < 21; i++)
            //{
            //    grdSearch.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            //}
            //grdSearch.Columns[0].Visible = false;

            string cquery = "SELECT C.CSTID,                    C.CSTSTAT,                      C.LOAD_REP_CSTID,   ";
            cquery += "             C.CST_LOAD_LOCATION_CODE,   C.CURR_RACK_ID,                 C.CURR_LOTID,       ";
            cquery += "             C.EQPT_CUR AS EQPTID,       C.PORT_CUR AS PORT_ID,          W.ROUTID,           W.WIPSTAT, ";
            cquery += "             L.LOTTYPE,                  WA.DAY_GR_LOTID AS ASSY_LOTID,  WA.SPCL_FLAG,       ";
            cquery += "             WA.LOT_DETL_TYPE_CODE,      WA.DFCT_LIMIT_OVER_FLAG,        WA.SPCL_NOTE,       ";
            cquery += "             WA.FORM_SPCL_GR_ID,         W.PROCID,                       C.TRAY_TYPE_CODE,   ";
            cquery += "             CONVERT(CHAR(23), WA.AGING_ISS_SCHD_DTTM, 20) AS AGING_ISS_SCHD_DTTM,        WA.AGING_ISS_PRIORITY_NO, ";
            cquery += "             CONVERT(CHAR(23), C.UPDDTTM, 20) AS UPDDTTM,                WA.DFCT_OCCR_EQPTID ";
            cquery += "  FROM Carrier C with(nolock) ";
            cquery += "       LEFT JOIN WIP W WITH(NOLOCK) ON C.CURR_LOTID = W.LOTID ";
            cquery += "       LEFT JOIN WIPATTR WA WITH(NOLOCK) ON WA.LOTID = W.LOTID ";
            cquery += "       LEFT JOIN LOT L WITH(NOLOCK) ON L.LOTID = WA.LOTID ";
            cquery += " WHERE (LOAD_REP_CSTID IN (" + CSTS + ") or C.CSTID IN (" + CSTS + "))";
            cquery += " ORDER BY UPDDTTM DESC,CST_LOAD_LOCATION_CODE DESC ";
            SqlDataAdapter R = new SqlDataAdapter(cquery, cstr);
            ArrayList ar = new ArrayList();
            DataSet ds = new DataSet();
            R.Fill(ds);

            int idx = 0; /*string routid = ""; string dfct = "F";*/
            grdSearch.Rows.Clear();
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
                                dr["DFCT_LIMIT_OVER_FLAG"].ToString(),
                                dr["DFCT_OCCR_EQPTID"].ToString(),
                                dr["SPCL_NOTE"].ToString(),
                                dr["FORM_SPCL_GR_ID"].ToString(),
                                dr["AGING_ISS_SCHD_DTTM"].ToString(),
                                dr["AGING_ISS_PRIORITY_NO"].ToString(),
                                dr["UPDDTTM"].ToString(),
                            };
                        grdSearch.Rows.Add(data);
                    }
                }
            }
        }

        private void grdRack_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private ArrayList EqptList(string GRID)
        {
            //string cstr = "Data Source=10.95.9.59,7433;Initial catalog=ESGM_BMES_FORM_P01;User ID=rtd_app;Password=##r51T1980D@!";

            string cquery = "SELECT EQPTID, EQPTNAME ";
            cquery += " FROM EQUIPMENT E WITH(NOLOCK) ";
            cquery += "  INNER JOIN EQUIPMENTSEGMENT ES  WITH(NOLOCK) ON E.EQSGID = ES.EQSGID AND ES.AREAID = '"+AREAID+"' ";

            SqlDataAdapter R = new SqlDataAdapter(cquery, cstr);
            ArrayList ar = new ArrayList();
            DataSet ds = new DataSet();
            R.Fill(ds);

            return ar;
        }

        private void txtsTime_TabIndexChanged(object sender, EventArgs e)
        {

        }
        //===========================================================================================
        /// <summary>
        /// 파레트 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPTFind_Click(object sender, EventArgs e)
        {
            //string ptid = txtPTid.Text.ToUpper();
            //if (ptid != "") PT_Info(ptid);
            if (chkPTReq.Checked == true) PT_Req_Hist();
            if (chkPLTList.Checked == true) Empty_PLT_Request_List();
            else PT_CMD_History();
        }
        /// <summary>
        /// 파레트 정보 조회
        /// </summary>
        /// <param name="CSTS"></param>
        private void PT_Info(string CSTS)
        {
            //string cstr = "Data Source=10.95.9.59,7433;Initial catalog=ESGM_BMES_FORM_P01;User ID=rtd_app;Password=##r51T1980D@!";


            grdPTInfo.Columns.Clear();
            grdPTInfo.Columns.Add("SEQ", "NO");
            grdPTInfo.Columns.Add("CSTID", "PTID");
            grdPTInfo.Columns.Add("CSTTYPE", "PT TYPE");
            grdPTInfo.Columns.Add("CSTSTAT", "구분");
            grdPTInfo.Columns.Add("CURR_LOTID", "LOT");
            grdPTInfo.Columns.Add("EQPT_CUR", "설비");
            grdPTInfo.Columns.Add("PORT_CUR", "포트");
            grdPTInfo.Columns.Add("CSTOWNER", "OWNER");
            grdPTInfo.Columns.Add("CSTPROD", "CSTPROD");
            grdPTInfo.Columns.Add("INSDTTM", "등록시각");
            grdPTInfo.Columns.Add("UPDDTTM", "수정시각");


            grdPTInfo.Columns[0].Width = 60; grdPTInfo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // SEQ
            grdPTInfo.Columns[1].Width = 120; grdPTInfo.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // CSTID
            grdPTInfo.Columns[2].Width = 80; grdPTInfo.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // pt type
            grdPTInfo.Columns[3].Width = 80; grdPTInfo.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 구분
            grdPTInfo.Columns[4].Width = 150; grdPTInfo.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // LOT
            grdPTInfo.Columns[5].Width = 120; grdPTInfo.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // 설비
            grdPTInfo.Columns[6].Width = 150; grdPTInfo.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // 포트
            grdPTInfo.Columns[7].Width = 100; grdPTInfo.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // OWNER
            grdPTInfo.Columns[8].Width = 100; grdPTInfo.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // CSTPROD
            grdPTInfo.Columns[9].Width = 150; grdPTInfo.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // 등록시각
            grdPTInfo.Columns[10].Width = 150; grdPTInfo.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // 수정시각

            //for (int i = 0; i < 10; i++)
            //{
            //    grdPTInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            //}

            string cquery = "SELECT C.CSTID,        C.CSTSTAT,            C.CSTTYPE,   ";
            cquery += "             C.EQPT_CUR,     C.PORT_CUR,           C.CSTOWNER,       ";
            cquery += "             C.CSTPROD,      C.CURR_LOTID,         C.FINL_ACTID,     C.FINL_ACTDTTM, ";
            cquery += "             CONVERT(CHAR(23), C.INSDTTM, 20) AS INSDTTM, CONVERT(CHAR(23), C.UPDDTTM, 20) AS UPDDTTM ";
            cquery += "  FROM Carrier C with(nolock) ";
            cquery += " WHERE CSTID = '" + CSTS + "'";
            cquery += " ORDER BY UPDDTTM DESC ";
            SqlDataAdapter R = new SqlDataAdapter(cquery, cstr);
            ArrayList ar = new ArrayList();
            DataSet ds = new DataSet();
            R.Fill(ds);

            int idx = 0;
            grdPTInfo.Rows.Clear();
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
                                dr["CSTTYPE"].ToString(),
                                dr["CSTSTAT"].ToString(),
                                dr["CURR_LOTID"].ToString(),
                                dr["EQPT_CUR"].ToString(),
                                dr["PORT_CUR"].ToString(),
                                dr["CSTOWNER"].ToString(),
                                dr["CSTPROD"].ToString(),
                                dr["INSDTTM"].ToString(),
                                dr["UPDDTTM"].ToString(),
                            };
                        grdPTInfo.Rows.Add(data);
                    }
                }
            }
        }
        /// <summary>
        /// 요청 목록
        /// </summary>
        private void PT_Req_Hist()
        {
            //string cstr = "Data Source=10.95.9.59,7433;Initial catalog=ESGM_BMES_FORM_P01;User ID=rtd_app;Password=##r51T1980D@!";


            grdPTInfo.Columns.Clear();
            grdPTInfo.Columns.Add("SEQ", "NO");
            grdPTInfo.Columns.Add("EQPTID", "설비");
            grdPTInfo.Columns.Add("PORT_ID", "포트");
            grdPTInfo.Columns.Add("REQ_TYPE_CODE", "REQ TYPE");
            grdPTInfo.Columns.Add("CSTID", "PTID");
            grdPTInfo.Columns.Add("CSTTYPE", "PT TYPE");
            grdPTInfo.Columns.Add("LOTID", "LOT");
            grdPTInfo.Columns.Add("PROCID", "PROCID");
            grdPTInfo.Columns.Add("REQ_STAT_CODE", "요청상태");
            grdPTInfo.Columns.Add("REQ_DTTM", "요청시각");
            grdPTInfo.Columns.Add("RTD_RULE_ID", "RULE");
            grdPTInfo.Columns.Add("INSUSER", "등록자");
            grdPTInfo.Columns.Add("INSDTTM", "등록시각");
            grdPTInfo.Columns.Add("UPDDTTM", "수정시각");


            grdPTInfo.Columns[0].Width = 60; grdPTInfo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // SEQ
            grdPTInfo.Columns[1].Width = 100; grdPTInfo.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;    // EQPTID
            grdPTInfo.Columns[2].Width = 150; grdPTInfo.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;    // PORT
            grdPTInfo.Columns[3].Width = 80; grdPTInfo.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // REQ TYPE
            grdPTInfo.Columns[4].Width = 120; grdPTInfo.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // PTID
            grdPTInfo.Columns[5].Width = 80; grdPTInfo.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // PT TYPE
            grdPTInfo.Columns[6].Width = 150; grdPTInfo.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // LOT
            grdPTInfo.Columns[7].Width = 80; grdPTInfo.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;    // PROCID
            grdPTInfo.Columns[8].Width = 100; grdPTInfo.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;    // 요청상태
            grdPTInfo.Columns[9].Width = 150; grdPTInfo.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // 요청시각
            grdPTInfo.Columns[10].Width = 150; grdPTInfo.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;    // RULE ID
            grdPTInfo.Columns[11].Width = 100; grdPTInfo.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;    // 등록자
            grdPTInfo.Columns[12].Width = 150; grdPTInfo.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // 등록시각
            grdPTInfo.Columns[13].Width = 150; grdPTInfo.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // 수정시각

            //for (int i = 0; i < 13; i++)
            //{
            //    grdPTInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            //}

            string cquery = "SELECT C.CSTID,        C.CSTSTAT,            C.LOTID,   ";
            cquery += "             C.EQPTID,       C.PORT_ID,            C.REQ_TYPE_CODE,       ";
            cquery += "             C.PROCID,       C.REQ_STAT_CODE,       C.RTD_RULE_ID,       C.INSUSER, ";
            cquery += "             CONVERT(CHAR(23), C.REQ_DTTM, 20) AS REQ_DTTM, ";
            cquery += "             CONVERT(CHAR(23), C.INSDTTM, 20) AS INSDTTM, CONVERT(CHAR(23), C.UPDDTTM, 20) AS UPDDTTM ";
            cquery += "  FROM TB_MHS_TRF_REQ_HIST C with(nolock) ";
            cquery += " WHERE 1 = 1 ";
            if (txtPTid.Text != "") { cquery += " AND  CSTID LIKE '" + txtPTid.Text + "%' "; }
            else { cquery += " AND  CSTID LIKE 'PTAB%' "; }

            if (txtPTPort.Text != "") { cquery += "  AND c.PORT_ID LIKE '" + txtPTPort.Text + "%'"; }

            if (chkPTGubun1.Checked != true || chkPTGubun2.Checked != true)
            {
                if (chkPTGubun2.Checked == true) { cquery += "  AND c.CSTSTAT = 'E' "; }
                else if (chkPTGubun1.Checked == true) { cquery += "  AND c.CSTSTAT = 'U' "; }
            }
            cquery += "   AND DATEDIFF(HOUR, UPDDTTM, GETDATE())<=24 ";
            cquery += " ORDER BY C.REQ_DTTM DESC, INSDTTM DESC ";

            txtSQL.Text = cquery;
            SqlDataAdapter R = new SqlDataAdapter(cquery, cstr);
            ArrayList ar = new ArrayList();
            DataSet ds = new DataSet();
            R.Fill(ds);

            int idx = 0;
            grdPTInfo.Rows.Clear();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        idx++;
                        string[] data = new string[] {
                                idx.ToString(),
                                dr["EQPTID"].ToString(),
                                dr["PORT_ID"].ToString(),
                                dr["REQ_TYPE_CODE"].ToString(),
                                dr["CSTID"].ToString(),
                                dr["CSTSTAT"].ToString(),
                                dr["LOTID"].ToString(),
                                dr["PROCID"].ToString(),
                                dr["REQ_STAT_CODE"].ToString(),
                                dr["REQ_DTTM"].ToString(),
                                dr["RTD_RULE_ID"].ToString(),
                                dr["INSUSER"].ToString(),
                                dr["INSDTTM"].ToString(),
                                dr["UPDDTTM"].ToString(),
                            };
                        grdPTInfo.Rows.Add(data);
                    }
                }
            }
        }
        /// <summary>
        /// 파레트 반송 조회
        /// </summary>
        /// <param name="CSTS"></param>
        private void PT_CMD_History()
        {
            //string cstr = "Data Source=10.95.9.59,7433;Initial catalog=ESGM_BMES_FORM_P01;User ID=rtd_app;Password=##r51T1980D@!";


            grdPTCmdList.Columns.Clear();
            grdPTCmdList.Columns.Add("NO", "NO");
            grdPTCmdList.Columns.Add("CSTID", "PTID");
            grdPTCmdList.Columns.Add("CSTSTAT", "구분");
            grdPTCmdList.Columns.Add("LOTID", "LOT");
            grdPTCmdList.Columns.Add("PROCID", "PROC");
            grdPTCmdList.Columns.Add("FROM_EQPT", "요청설비");
            grdPTCmdList.Columns.Add("FROM_PORT_ID", "요청포트");
            grdPTCmdList.Columns.Add("TO_EQPT", "목적설비");
            grdPTCmdList.Columns.Add("TO_PORT_ID", "목적포트");
            grdPTCmdList.Columns.Add("CMD_STAT_CODE", "반송상태");
            grdPTCmdList.Columns.Add("RTD_RULE_ID", "RULE");
            grdPTCmdList.Columns.Add("INSUSER", "등록자");
            grdPTCmdList.Columns.Add("INSDTTM", "등록시각");
            grdPTCmdList.Columns.Add("UPDDTTM", "수정시각");


            grdPTCmdList.Columns[0].Width = 60; grdPTCmdList.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // SEQ
            grdPTCmdList.Columns[1].Width = 120; grdPTCmdList.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // CSTID
            grdPTCmdList.Columns[2].Width = 80; grdPTCmdList.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // 구분
            grdPTCmdList.Columns[3].Width = 150; grdPTCmdList.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // LOT
            grdPTCmdList.Columns[4].Width = 80; grdPTCmdList.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // PROC
            grdPTCmdList.Columns[5].Width = 120; grdPTCmdList.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // 요청설비
            grdPTCmdList.Columns[6].Width = 150; grdPTCmdList.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // 요청포트
            grdPTCmdList.Columns[7].Width = 120; grdPTCmdList.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;    // 목적설비
            grdPTCmdList.Columns[8].Width = 150; grdPTCmdList.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;    // 목적포트
            grdPTCmdList.Columns[9].Width = 100; grdPTCmdList.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;    // 반송상태
            grdPTCmdList.Columns[10].Width = 150; grdPTCmdList.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;    // RULE
            grdPTCmdList.Columns[11].Width = 100; grdPTCmdList.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;    // 등록자
            grdPTCmdList.Columns[12].Width = 150; grdPTCmdList.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // 등록시각
            grdPTCmdList.Columns[13].Width = 150; grdPTCmdList.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // 수정시각
            
            //for (int i = 0; i < 13; i++)
            //{
            //    grdPTCmdList.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            //}

            string cquery = "SELECT C.CSTID,        C.CSTSTAT,            C.LOTID,   ";
            cquery += "             C.PROCID,       C.FROM_EQPTID,        C.FROM_PORT_ID,       ";
            cquery += "             C.TO_EQPTID,    C.TO_PORT_ID,         C.CMD_STAT_CODE,     C.RTD_RULE_ID, C.INSUSER, ";
            cquery += "             CONVERT(CHAR(23), C.INSDTTM, 20) AS INSDTTM, CONVERT(CHAR(23), C.UPDDTTM, 20) AS UPDDTTM ";
            cquery += "  FROM TB_MHS_TRF_CMD_HIST C with(nolock) ";
            cquery += " WHERE 1 = 1 ";
            if (txtPTid.Text != "") { cquery += " AND  CSTID LIKE '" + txtPTid.Text + "%' "; }
            else { cquery += " AND  C.CSTID LIKE 'PTAB%' "; }

            if (txtPTPort.Text != "") { cquery += "  AND c.PORT_ID LIKE '" + txtPTPort.Text + "%'"; }
            cquery += "   AND DATEDIFF(HOUR, UPDDTTM, GETDATE())<=24 ";
            if (chkPTGubun1.Checked != true || chkPTGubun2.Checked != true)
            {
                if (chkPTGubun2.Checked == true) { cquery += "  AND c.CSTSTAT = 'E' "; }
                else if (chkPTGubun1.Checked == true) { cquery += "  AND c.CSTSTAT = 'U' "; }
            }
            cquery += " ORDER BY UPDDTTM DESC ";

            txtSQL.Text = cquery;
            SqlDataAdapter R = new SqlDataAdapter(cquery, cstr);
            ArrayList ar = new ArrayList();
            DataSet ds = new DataSet();
            R.Fill(ds);

            int idx = 0;
            grdPTCmdList.Rows.Clear();
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
                                dr["CSTSTAT"].ToString(),
                                dr["LOTID"].ToString(),
                                dr["PROCID"].ToString(),
                                dr["FROM_EQPTID"].ToString(),
                                dr["FROM_PORT_ID"].ToString(),
                                dr["TO_EQPTID"].ToString(),
                                dr["TO_PORT_ID"].ToString(),
                                dr["CMD_STAT_CODE"].ToString(),
                                dr["RTD_RULE_ID"].ToString(),
                                dr["INSUSER"].ToString(),
                                dr["INSDTTM"].ToString(),
                                dr["UPDDTTM"].ToString(),
                            };
                        grdPTCmdList.Rows.Add(data);
                    }
                }
            }
        }

        private void Empty_PLT_Request_List()
        {
            string cQuery = "";
            cQuery = " SELECT CONTENT ";
            cQuery += "      , REQ_TRGT_EQPTID AS REQ_EQPTID"; 
            cQuery += "      , REQ_TRGT_PORT_ID AS REQ_PORT_ID";
            cQuery += "      , PORT_STAT_CODE  ";
            cQuery += "      , PORT_STAT_CHG_DTTM  ";
            cQuery += "      , CSTID   ";
            cQuery += "      , COUNT  ";
            cQuery += "  FROM ";
            cQuery += " (SELECT N'PORT_REQ_STAT(포트 요청 상태)'  AS CONTENT ";
            cQuery += "        , B.EQPTID   AS REQ_TRGT_EQPTID ";
            cQuery += "        , A.PORT_ID  AS REQ_TRGT_PORT_ID ";
            cQuery += "        , A.PORT_STAT_CODE  AS PORT_STAT_CODE ";
            cQuery += "        , CONVERT(CHAR(23), A.PORT_STAT_CHG_DTTM, 20)  AS PORT_STAT_CHG_DTTM ";
            cQuery += "        , NULL AS CSTID ";
            cQuery += "        , NULL AS COUNT ";
            cQuery += "        , '1' AS PRIORITY ";
            cQuery += "    FROM TB_MCS_CURR_PORT A WITH(NOLOCK) ";
            cQuery += "      INNER JOIN TB_MCS_PORT B WITH(NOLOCK) ON A.PORT_ID = B.PORT_ID ";
            cQuery += "    WHERE A.PORT_ID IN (SELECT COM_CODE ";
            cQuery += "                          FROM TB_MMD_AREA_COM_CODE WITH(NOLOCK) ";
            cQuery += "                          WHERE AREAID = '"+AREAID+"' ";
            cQuery += "                            AND COM_TYPE_CODE = 'MHS_EOL_LR_PORT_TO_WRTD' ";
            cQuery += "                            AND USE_FLAG = 'Y') ";
            cQuery += "     AND COALESCE(B.IF_EQPTID, '') <> '' ";
            cQuery += "     AND COALESCE(B.SKIP_TRGT_REQ_TRF_TYPE_CODE, '') = 'LR' ";
            cQuery += " UNION ALL ";
            cQuery += " SELECT '', '', '', '', '', '', '', '2' ";
            cQuery += " UNION ALL ";
            cQuery += " SELECT TOP 100 ";
            cQuery += "         N'REQ_E_PLT_HIST(공PLT 요청 이력)' ";
            cQuery += "        , A.REQ_TRGT_EQPTID ";
            cQuery += "         , A.REQ_TRGT_PORT_ID ";
            cQuery += "         , A.PORT_STAT_CODE ";
            cQuery += "         , CONVERT(CHAR(23), A.PORT_STAT_CHG_DTTM, 20) AS PORT_STAT_CHG_DTTM ";
            cQuery += "         , A.CSTID ";
            cQuery += "         , COUNT(A.CSTID) AS COUNT ";
            cQuery += "         , '3' ";
            cQuery += "   FROM TB_MHS_WRTD_TRF_REQ_HIST A ";
            cQuery += "  WHERE 1 = 1 ";
            cQuery += "  GROUP BY A.REQ_TRGT_EQPTID, A.REQ_TRGT_PORT_ID, A.PORT_STAT_CODE, A.PORT_STAT_CHG_DTTM, A.CSTID ";
            cQuery += "  ) A";
            cQuery += "  ORDER BY A.PRIORITY, A.PORT_STAT_CHG_DTTM DESC ";

            //string cstr = "Data Source=10.95.9.59,7433;Initial catalog=ESGM_BMES_FORM_P01;User ID=rtd_app;Password=##r51T1980D@!";


            grdPTCmdList.Columns.Clear();
            grdPTCmdList.Columns.Add("SEQ", "NO");
            grdPTCmdList.Columns.Add("CONTENT", "항 목");
            grdPTCmdList.Columns.Add("REQ_EQPTID", "요청설비");
            grdPTCmdList.Columns.Add("REQ_PORT_ID", "요청포트");
            grdPTCmdList.Columns.Add("PORT_STAT_CODE", "포트상태");
            grdPTCmdList.Columns.Add("PORT_STAT_CHG_DTTM", "요청시간");
            grdPTCmdList.Columns.Add("CSTID", "응답 공PLT");
            grdPTCmdList.Columns.Add("COUNT", "요청횟수");

            grdPTCmdList.Columns[0].Width = 60; grdPTCmdList.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // SEQ
            grdPTCmdList.Columns[1].Width = 250; grdPTCmdList.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;    // 항목
            grdPTCmdList.Columns[2].Width = 120; grdPTCmdList.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;    // 요청설비
            grdPTCmdList.Columns[3].Width = 150; grdPTCmdList.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;    // 요청포트
            grdPTCmdList.Columns[4].Width = 80; grdPTCmdList.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;    // 포트상태
            grdPTCmdList.Columns[5].Width = 180; grdPTCmdList.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // 요청시간
            grdPTCmdList.Columns[6].Width = 120; grdPTCmdList.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // 응답 공plt
            grdPTCmdList.Columns[7].Width = 80; grdPTCmdList.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // 요청횟수

            txtSQL.Text = cQuery;
            SqlDataAdapter R = new SqlDataAdapter(cQuery, cstr);
            ArrayList ar = new ArrayList();
            DataSet ds = new DataSet();
            R.Fill(ds);

            int idx = 0;
            grdPTCmdList.Rows.Clear();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        idx++;
                        string[] data = new string[] {
                                idx.ToString(),
                                dr["CONTENT"].ToString(),
                                dr["REQ_EQPTID"].ToString(),
                                dr["REQ_PORT_ID"].ToString(),
                                dr["PORT_STAT_CODE"].ToString(),
                                dr["PORT_STAT_CHG_DTTM"].ToString(),
                                dr["CSTID"].ToString(),
                                dr["COUNT"].ToString(),
                            };
                        grdPTCmdList.Rows.Add(data);
                    }
                }
            }
        }

        private void grdPTCmdList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (e.ColumnIndex == 1)
            {
                string ptid = grdPTCmdList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                txtPTid.Text = ptid;
                if (ptid != "") PT_Info(ptid);
                return;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            grdSearch.Rows.Clear();
            grdSearch.Columns.Clear();
        }

        private void grdHist_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && optCmd.Checked == true)
            {
                string CSTID = grdHist.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                FrmTrayInfo ftray = new FrmTrayInfo();
                ftray.CSTID = CSTID;
                ftray.ShowDialog();
            }
            else if(e.ColumnIndex==11)
            {
                // log 항목 더블클릭시
                string sLog = grdHist.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                string sRule = grdHist.Rows[e.RowIndex].Cells[8].Value.ToString();

                if (sLog != "")
                {
                    FrmLogs fLog = new FrmLogs();
                    fLog.sLog = sLog;
                    fLog.RuleName = sRule;
                    fLog.ShowDialog();
                }
            }
        }

        //private void grdLotList_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Control && e.KeyCode == Keys.V)
        //    {
        //        txtTemp.Text = "";
        //        // 클립보드 내용을 가져와 개행 문자로 분리
        //        string data = Clipboard.GetText();
        //        txtTemp.Text = data;
        //        string[] rdata = data.Trim().Split('\n');
        //        if (data.Length < 1) return;

        //        grdLotList.Columns.Clear();
        //        grdLotList.Columns.Add("NO", "순번");
        //        grdLotList.Columns.Add("lotid", "LOTID");
        //        grdLotList.Columns[0].Width = 60; grdLotList.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // SEQ
        //        grdLotList.Columns[1].Width = 100; grdLotList.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // CSTID
        //        grdLotList.Rows.Clear();
        //        int idx = 0;
        //        // 클릭한 셀 아래로 행을 증가하면서 붙여넣기
        //        foreach (string row in rdata)
        //        {
        //            grdLotList.Rows.Add();
        //            grdLotList.Rows[idx].Cells[0].Value = (idx + 1).ToString();
        //            grdLotList.Rows[idx].Cells[1].Value = row.Replace('\r', ' ').Trim();
        //            idx++;
        //        }
        //    }
        //}

        private void btnLotSearch_Click(object sender, EventArgs e)
        {   // 사용 안함
            //string lots = "";
            //if (grdLotList.Rows.Count <= 0)
            //{
            //    return;
            //}
            //for (int idx = 0; idx <= grdLotList.Rows.Count - 1; idx++)
            //{
            //    lots += "'" + grdLotList.Rows[idx].Cells[1].Value.ToString() + "',";
            //}
            //lots = lots.Trim();
            //lots = lots.Substring(0, lots.Length - 1);
            //Lots_Search(lots);

        }
        /// <summary>
        /// Stocker 현황
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSTKSearch_Click(object sender, EventArgs e)
        {
            grdSTKView.Rows.Clear();
            grdSTKView.Columns.Clear();
            grdSTKView.Columns.Add("SEQ", "순번");
            grdSTKView.Columns.Add("EQPTID", "설비ID");
            grdSTKView.Columns.Add("EQPTNAME", "설비명");
            grdSTKView.Columns.Add("EQPTIUSE", "사용");
            grdSTKView.Columns.Add("LANE_ID", "LANE");
            grdSTKView.Columns.Add("EIOSTAT", "상태");
            grdSTKView.Columns.Add("EIOIF", "통신");
            grdSTKView.Columns.Add("MAX_TRF_QTY", "버퍼");
            grdSTKView.Columns.Add("CMD_QTY", "반송");
            grdSTKView.Columns.Add("WAIT_QTY", "대기");
            grdSTKView.Columns.Add("RACK_MAX_QTY", "총렉수");
            grdSTKView.Columns.Add("USING_QTY", "사용");
            grdSTKView.Columns.Add("OPTM_LOAD_RATE", "설정적재율(%)");
            grdSTKView.Columns.Add("RATE", "현재적재율(%)");

            grdSTKView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grdSTKView.Columns[0].Width = 60; grdSTKView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // SEQ
            grdSTKView.Columns[1].Width = 120; grdSTKView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // 설비ID
            grdSTKView.Columns[2].Width = 280; grdSTKView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // 설비명
            grdSTKView.Columns[3].Width = 60; grdSTKView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 사용
            grdSTKView.Columns[4].Width = 80; grdSTKView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // LANE
            grdSTKView.Columns[5].Width = 60; grdSTKView.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 상태
            grdSTKView.Columns[6].Width = 80; grdSTKView.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 통신상태
            grdSTKView.Columns[7].Width = 80; grdSTKView.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;     // 버퍼수량
            grdSTKView.Columns[8].Width = 80; grdSTKView.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;     // 반송수량
            grdSTKView.Columns[9].Width = 80; grdSTKView.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;     // 대기 트레이
            grdSTKView.Columns[10].Width = 80; grdSTKView.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;     // 총렉수량
            grdSTKView.Columns[11].Width = 80; grdSTKView.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;     // 사용렉수량
            grdSTKView.Columns[12].Width = 120; grdSTKView.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;     // 설정적재율
            grdSTKView.Columns[13].Width = 120; grdSTKView.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;     // 현재적재율

            Stocker_state_View();
        }
        /// <summary>
        /// 스토크 상태 표시
        /// </summary>
        /// <param name="STONO"></param>
        private void Stocker_state_View()
        {
            grdSTKView.Rows.Clear();

            //string cstr = "Data Source=10.95.9.59,7433;Initial catalog=ESGM_BMES_FORM_P01;User ID=rtd_app;Password=##r51T1980D@!";

            string cquery = " SELECT e.EQPTID, e.EQPTNAME, e.EQPTIUSE, EA.S70 AS EQGRID, EA.S71 AS LANE_ID, ei.EIOSTAT, ei.EIOIFMODE, ei.EIOCOMSTAT ";
            cquery += "             , ISNULL(R.OPTM_LOAD_RATE,0) AS OPTM_LOAD_RATE ";
            cquery += "             , ISNULL(R.RACK_MAX_QTY,0) AS RACK_MAX_QTY ";
            cquery += "             , ISNULL(R.USABLE_QTY,0) AS USABLE_QTY      ";
            cquery += "             , ISNULL(R.USING_QTY, 0) AS USING_QTY   ";
            cquery += "             , ISNULL(R.DISABLE_QTY, 0) AS DISABLE_QTY   ";
            cquery += "             , ISNULL(CD.CMD_CNT, 0) AS CMD_QTY   ";
            cquery += "             , ISNULL(CP.MAX_TRF_QTY, 0) AS MAX_TRF_QTY   ";
            cquery += "             , ISNULL(WAT.WAIT_QTY, 0) AS WAIT_QTY        ";
            cquery += "  FROM EQUIPMENT e WITH(NOLOCK) ";
            cquery += "   INNER JOIN EQUIPMENTATTR EA WITH(NOLOCK) ON e.EQPTID = EA.EQPTID ";
            cquery += "   INNER JOIN EIO ei WITH(NOLOCK) ON e.EQPTID = ei.EQPTID ";
            cquery += "   INNER JOIN TB_MCS_CURR_PORT CP WITH(NOLOCK) ON CP.PORT_ID = CONCAT(e.EQPTID,'-SHELF')  ";
            cquery += "   LEFT JOIN (  ";
            cquery += "     SELECT  TO_EQPTID, COUNT(CSTID) AS CMD_CNT ";
            cquery += "       FROM  TB_MHS_TRF_CMD WITH(NOLOCK) ";
            cquery += "       GROUP BY TO_EQPTID ) CD  ON CD.TO_EQPTID = e.EQPTID ";
            cquery += "   LEFT JOIN (  ";
            cquery += "     SELECT  ";
            cquery += "           T.EQPTID  ";
            cquery += "  	    , T.OPTM_LOAD_RATE  ";
            cquery += "  	    , COUNT(T.RACK_ID) AS RACK_MAX_QTY  ";
            cquery += "         , SUM(T.EMPTY_RACK) AS USABLE_QTY  "; // --사용가능
            cquery += "         , SUM(T.USING_RACK) AS USING_QTY  "; // --사용중
            cquery += "  	    , SUM(T.DISABLE_RACK) AS DISABLE_QTY  ";  // -- 입고금지
            cquery += "     FROM  ";
            cquery += "         (  ";
            cquery += "             SELECT  ";
            cquery += "                 CR.EQPTID  ";
            cquery += "                 , PW.OPTM_LOAD_RATE  ";
            cquery += "                 , CR.RACK_ID  ";
            cquery += "                 , CASE  ";
            cquery += "                     WHEN         ";  //--사용가능 rack
            cquery += "                         CR.RACK_STAT_CODE = 'USABLE'  ";
            cquery += "                         AND ISNULL(CR.MCS_CST_ID, '') = ''  ";
            cquery += "                         AND CR.FIRE_OCCR_FLAG = 'N'  ";
            cquery += "                         AND CR.USE_FLAG = 'Y'  ";
            cquery += "                         THEN 1  ";
            cquery += "                     ELSE 0  ";
            cquery += "                   END AS EMPTY_RACK  ";
            cquery += "                 , CASE  ";
            cquery += "                     WHEN         ";  //--사용중 rack
            cquery += "                         CR.RACK_STAT_CODE = 'USING'  ";
            cquery += "                         AND CR.FIRE_OCCR_FLAG = 'N'  ";
            cquery += "                         AND CR.USE_FLAG = 'Y'  ";
            cquery += "                         THEN 1  ";
            cquery += "                     ELSE 0  ";
            cquery += "                   END AS USING_RACK  ";
            cquery += "                 , CASE  ";
            cquery += "                     WHEN         ";  //--사용중 rack
            cquery += "                         CR.RACK_STAT_CODE = 'DISABLE'  ";
            cquery += "                         OR CR.FIRE_OCCR_FLAG = 'Y'  ";
            cquery += "                         OR CR.USE_FLAG = 'N'  ";
            cquery += "                         THEN 1  ";
            cquery += "                     ELSE 0  ";
            cquery += "                    END AS DISABLE_RACK  ";
            cquery += "             FROM TB_MMD_PRDT_WH    PW WITH(NOLOCK)  ";
            cquery += "               INNER JOIN TB_MMD_RACK MR WITH(NOLOCK)        ON PW.WH_ID = MR.WH_ID      AND PW.USE_FLAG = 'Y'     AND MR.USE_FLAG = 'Y'  ";
            cquery += "               INNER JOIN TB_MCS_RACK CR WITH(NOLOCK)        ON CR.RACK_ID = MR.RACK_ID  AND CR.USE_FLAG = 'Y'  ";
            cquery += "             WHERE 1 = 1  ";
            cquery += "               AND CR.EQPTID  LIKE 'U1FSTO%' ";
            cquery += "             ) AS T  ";
            cquery += "     GROUP BY T.EQPTID, T.OPTM_LOAD_RATE  ";
            cquery += "  ) AS R  ON  E.EQPTID = R.EQPTID ";
            //---------------대기 트레이
            cquery += " LEFT JOIN ( ";
            cquery += "  SELECT MR.EQPTID, COUNT(MCS_CST_ID) AS WAIT_QTY ";
            cquery += "    FROM TB_MCS_RACK     MR WITH(NOLOCK) ";
            cquery += "     INNER JOIN CARRIER  C WITH(NOLOCK) ON C.CSTID = MR.MCS_CST_ID ";
            cquery += "     INNER JOIN WIP      W WITH(NOLOCK) ON W.LOTID = C.CURR_LOTID ";
            cquery += "     INNER JOIN WIPATTR  WA WITH(NOLOCK) ON WA.LOTID = W.LOTID ";
            cquery += "     WHERE 1 = 1 ";
            cquery += "       AND (WA.AGING_ISS_SCHD_DTTM < GETDATE() OR WA.AGING_ISS_PRIORITY_NO > 5)";
            cquery += "     GROUP BY MR.EQPTID ";
            cquery += " ) AS WAT ON WAT.EQPTID = R.EQPTID ";
            cquery += " WHERE 1 = 1";
            cquery += "   AND e.EQPTID like 'U1FSTO%'";
            cquery += " ORDER BY e.EQPTID ";
            SqlDataAdapter R = new SqlDataAdapter(cquery, cstr);
            ArrayList ar = new ArrayList();
            DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            R.Fill(ds);

            //txtSQL.Text = cquery;
            int Idx = 0;
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Idx++;
                        string eqnm = dr["EQPTNAME"].ToString().Substring(6);
                        eqnm = eqnm.Substring(0, eqnm.IndexOf('|'));
                        string[] data = new string[] {
                                Idx.ToString(),
                                dr["EQPTID"].ToString(),
                                eqnm,
                                dr["EQPTIUSE"].ToString(),
                                dr["LANE_ID"].ToString(),
                                dr["EIOSTAT"].ToString(),
                                dr["EIOIFMODE"].ToString(),
                                dr["MAX_TRF_QTY"].ToString(),
                                dr["CMD_QTY"].ToString(),
                                dr["WAIT_QTY"].ToString(),
                                dr["RACK_MAX_QTY"].ToString(),
                                //dr["DISABLE_QTY"].ToString(),
                                //dr["USABLE_QTY"].ToString(),
                                dr["USING_QTY"].ToString(),
                                Convert.ToSingle(dr["OPTM_LOAD_RATE"].ToString()).ToString("##0.0"),
                                (Convert.ToSingle(dr["RACK_MAX_QTY"].ToString())==0?"0":
                                      ((Convert.ToSingle(dr["DISABLE_QTY"].ToString())+Convert.ToSingle(dr["USING_QTY"].ToString()))/Convert.ToSingle(dr["RACK_MAX_QTY"].ToString())*100.0).ToString("##0.0"))
                            };
                        grdSTKView.Rows.Add(data);

                        if (dr["EQPTIUSE"].ToString() == "N")
                        {
                            grdSTKView.Rows[grdSTKView.RowCount - 1].DefaultCellStyle.BackColor = Color.Silver;
                        }
                        else
                        {
                            switch(dr["EQGRID"].ToString())
                            {
                                case "9":   // 프리
                                    grdSTKView.Rows[grdSTKView.RowCount - 1].DefaultCellStyle.BackColor = Color.Aqua;
                                    break;  
                                case "E":   // 공트레이
                                    grdSTKView.Rows[grdSTKView.RowCount - 1].DefaultCellStyle.BackColor = Color.White;
                                    break;
                                case "J":   // 지포
                                    grdSTKView.Rows[grdSTKView.RowCount - 1].DefaultCellStyle.BackColor = Color.YellowGreen;
                                    break;
                                case "4":   // 고온
                                    grdSTKView.Rows[grdSTKView.RowCount - 1].DefaultCellStyle.BackColor = Color.LightPink;
                                    break;
                                case "3":   // 상온
                                    grdSTKView.Rows[grdSTKView.RowCount - 1].DefaultCellStyle.BackColor = Color.GreenYellow;
                                    break;
                                case "7":   // 출하
                                    grdSTKView.Rows[grdSTKView.RowCount - 1].DefaultCellStyle.BackColor = Color.CadetBlue;
                                    break;
                                case "1":   // 충방
                                    grdSTKView.Rows[grdSTKView.RowCount - 1].DefaultCellStyle.BackColor = Color.NavajoWhite;
                                    break;
                            }
                            if (dr["EIOIFMODE"].ToString() == "OFF")
                            {
                                grdSTKView.Rows[grdSTKView.RowCount - 1].Cells[6].Style.BackColor = Color.Orange;
                            }
                            if (dr["EIOSTAT"].ToString() == "T" || dr["EIOSTAT"].ToString() == "U" || dr["EIOSTAT"].ToString() == "F")  //dr["EIOSTAT"].ToString() == "T" 
                            {
                                grdSTKView.Rows[grdSTKView.RowCount - 1].Cells[5].Style.BackColor = Color.FromArgb(100, 200, 89);
                            }
                            // 적재율이 90이상이면 표시
                            double rate = (Convert.ToSingle(dr["RACK_MAX_QTY"].ToString()) == 0 ? 0 :
                                      ((Convert.ToSingle(dr["DISABLE_QTY"].ToString()) + Convert.ToSingle(dr["USING_QTY"].ToString())) / Convert.ToSingle(dr["RACK_MAX_QTY"].ToString()) * 100.0));
                            if (rate >= Convert.ToSingle(dr["OPTM_LOAD_RATE"].ToString()) && rate >0 )
                            {
                                grdSTKView.Rows[grdSTKView.RowCount - 1].Cells[13].Style.BackColor = Color.OrangeRed;
                            }
                            // 반송대기
                            if (Convert.ToSingle(dr["WAIT_QTY"].ToString()) > 0)
                            {
                                grdSTKView.Rows[grdSTKView.RowCount - 1].Cells[9].Style.BackColor = Color.LightPink;
                            }
                            if (Convert.ToSingle(dr["MAX_TRF_QTY"].ToString()) <= 0 || dr["LANE_ID"].ToString() != "ABLOWER")
                            {
                                grdSTKView.Rows[grdSTKView.RowCount - 1].DefaultCellStyle.BackColor = Color.LightGray;
                            }
                            //if (((Convert.ToSingle(dr["DISABLE_QTY"].ToString()) + Convert.ToSingle(dr["USING_QTY"].ToString())) / Convert.ToSingle(dr["RACK_MAX_QTY"].ToString()) * 100.0) > 90)
                            //{
                            //    grdSTKView.Rows[grdSTKView.RowCount - 1].Cells[7].Style.BackColor = Color.PaleVioletRed;
                            //}
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 미반송 현황
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEMGSearch_Click(object sender, EventArgs e)
        {
            grdEMGView.Rows.Clear();
            grdEMGView.Columns.Clear();

            grdEMGView.Columns.Add("SEQ", "NO");
            grdEMGView.Columns.Add("EQPTID", "설비");
            grdEMGView.Columns.Add("RACK_ID", "위치");
            grdEMGView.Columns.Add("CSTID", "CST");
            grdEMGView.Columns.Add("LOTID", "LOT");
            grdEMGView.Columns.Add("AGING_ISS_SCHD_DTTM", "예정시각");
            grdEMGView.Columns.Add("AGING_ISS_PRIORITY_NO", "순위");
            grdEMGView.Columns.Add("ROUTID", "ROUT");
            grdEMGView.Columns.Add("PROCID", "공정");
            grdEMGView.Columns.Add("LANE_ID", "LANE");
            grdEMGView.Columns.Add("WIPSTAT", "상태");
            grdEMGView.Columns.Add("NEXT_PROCID", "다음공정");
            grdEMGView.Columns.Add("NEXT_LANEID", "다음LANE");
            grdEMGView.Columns.Add("TO_PORT_ID", "도착포트");
            grdEMGView.Columns.Add("CMD_STAT_CODE", "반송상태");
            grdEMGView.Columns.Add("INSDTTM", "반송생성");

            grdEMGView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grdEMGView.Columns[0].Width = 60; grdEMGView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // SEQ
            grdEMGView.Columns[1].Width = 100; grdEMGView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // EQPTID
            grdEMGView.Columns[2].Width = 140; grdEMGView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // RACK_ID
            grdEMGView.Columns[3].Width = 120; grdEMGView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // CSTID
            grdEMGView.Columns[4].Width = 140; grdEMGView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // LOTID
            grdEMGView.Columns[5].Width = 150; grdEMGView.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // 출고예정시각
            grdEMGView.Columns[6].Width = 60; grdEMGView.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 순위
            grdEMGView.Columns[7].Width = 80; grdEMGView.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // ROUT
            grdEMGView.Columns[8].Width = 80; grdEMGView.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // PROCID
            grdEMGView.Columns[9].Width = 80; grdEMGView.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // LANE_ID
            grdEMGView.Columns[10].Width = 60; grdEMGView.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // WIPSTAT
            grdEMGView.Columns[11].Width = 80; grdEMGView.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // NEXT PROCID
            grdEMGView.Columns[12].Width = 80; grdEMGView.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // NEXT LANE_ID
            grdEMGView.Columns[13].Width = 140; grdEMGView.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // 도착포트
            grdEMGView.Columns[14].Width = 100; grdEMGView.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // 반송상태
            grdEMGView.Columns[15].Width = 150; grdEMGView.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // 반송생성시각


            txtSQL.Text = "";
            Wait_List();
            Wait_EQPT_List();
            NoReturn_View();
        }
        /// <summary>
        /// 미반송 현화 조회
        /// </summary>
        private void NoReturn_View()
        {
            grdEMGView.Rows.Clear();

            //string cstr = "Data Source=10.95.9.59,7433;Initial catalog=ESGM_BMES_FORM_P01;User ID=rtd_app;Password=##r51T1980D@!";

            string cquery = " SELECT mr.EQPTID ";
            cquery += "             , MR.RACK_ID ";
            cquery += "             , C.CSTID ";
            cquery += "             , C.CURR_LOTID      ";
            cquery += "             , CONVERT(CHAR(23), WA.AGING_ISS_SCHD_DTTM, 20) AS AGING_ISS_SCHD_DTTM  ";
            cquery += "             , WA.AGING_ISS_PRIORITY_NO ";
            cquery += "             , W.ROUTID ";
            cquery += "             , W.PROCID ";
            cquery += "             , RP1.LANE_ID ";
            cquery += "             , W.WIPSTAT ";
            cquery += "             , RP2.PROCID   AS NEXT_PROCID ";
            cquery += "             , RP2.LANE_ID  AS NEXT_LANEID ";
            cquery += "             , CMD.TO_PORT_ID ";
            cquery += "             , CMD.CMD_STAT_CODE ";
            cquery += "             , CONVERT(CHAR(23), CMD.INSDTTM, 20) AS INSDTTM  ";
            cquery += "  FROM TB_MCS_RACK MR WITH(NOLOCK) ";
            cquery += "   INNER JOIN CARRIER C WITH(NOLOCK) ON C.CSTID = MR.MCS_CST_ID ";
            cquery += "   INNER JOIN WIP W WITH(NOLOCK) ON W.LOTID = C.CURR_LOTID ";
            cquery += "   INNER JOIN WIPATTR WA WITH(NOLOCK) ON WA.LOTID = W.LOTID ";
            cquery += "   INNER JOIN TB_MMD_FORM_ROUT_PROC RP1 WITH(NOLOCK) ON RP1.ROUTID = W.ROUTID AND RP1.PROCID = W.PROCID  ";
            cquery += "   INNER JOIN TB_MMD_FORM_ROUT_PROC RP2 WITH(NOLOCK) ON RP2.ROUTID = RP1.ROUTID AND RP2.PROC_SEQNO = RP1.PROC_SEQNO+1 AND RP2.USE_FLAG = 'Y'  ";
            cquery += "   LEFT JOIN (  ";
            cquery += "     SELECT  CSTID, CMD_STAT_CODE, TO_PORT_ID, INSDTTM ";
            cquery += "       FROM  TB_MHS_TRF_CMD WITH(NOLOCK) ";
            cquery += "       WHERE CMD_STAT_CODE IN ('RECEIVE', 'MOVING') ";
            cquery += "   ) AS CMD ON C.CSTID = CMD.CSTID ";
            cquery += " WHERE 1 = 1";
            cquery += "   AND WA.AGING_ISS_SCHD_DTTM < GETDATE() OR WA.AGING_ISS_PRIORITY_NO > 5 ";
            cquery += " ORDER BY MR.RACK_ID, CONVERT(CHAR(23), WA.AGING_ISS_SCHD_DTTM, 20) DESC ";
            SqlDataAdapter R = new SqlDataAdapter(cquery, cstr);
            ArrayList ar = new ArrayList();
            DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            R.Fill(ds);

            //txtSQL.Text = cquery;
            int Idx = 0;
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Idx++;
                        //string eqnm = dr["EQPTNAME"].ToString().Substring(6);
                        //eqnm = eqnm.Substring(0, eqnm.IndexOf('|'));
                        string[] data = new string[] {
                                Idx.ToString(),
                                dr["EQPTID"].ToString(),
                                dr["RACK_ID"].ToString(),
                                dr["CSTID"].ToString(),
                                dr["CURR_LOTID"].ToString(),
                                dr["AGING_ISS_SCHD_DTTM"].ToString(),
                                dr["AGING_ISS_PRIORITY_NO"].ToString(),
                                dr["ROUTID"].ToString(),
                                dr["PROCID"].ToString(),
                                dr["LANE_ID"].ToString(),
                                dr["WIPSTAT"].ToString(),
                                dr["NEXT_PROCID"].ToString(),
                                dr["NEXT_LANEID"].ToString(),
                                dr["TO_PORT_ID"].ToString(),
                                dr["CMD_STAT_CODE"].ToString(),
                                dr["INSDTTM"].ToString()
                            };
                        grdEMGView.Rows.Add(data);
                        //if (dr["EQPTIUSE"].ToString() == "N")
                        //{
                        //    grdEMGView.Rows[grdSTKView.RowCount - 1].DefaultCellStyle.BackColor = Color.Silver;
                        //}
                        //else
                        //{
                        //    if (dr["EIOIFMODE"].ToString() == "OFF")
                        //    {
                        //        grdEMGView.Rows[grdSTKView.RowCount - 1].Cells[4].Style.BackColor = Color.Orange;
                        //    }
                        //    if (dr["EIOSTAT"].ToString() == "F")  //dr["EIOSTAT"].ToString() == "T" 
                        //    {
                        //        grdEMGView.Rows[grdSTKView.RowCount - 1].Cells[3].Style.BackColor = Color.FromArgb(100, 200, 89);
                        //    }                            
                        //}
                    }
                }
            }
        }
        /// <summary>
        /// 반송대기 현황
        /// </summary>
        private void Wait_List()
        {
            //string cstr = "Data Source=10.95.9.59,7433;Initial catalog=ESGM_BMES_FORM_P01;User ID=rtd_app;Password=##r51T1980D@!";

            grdWaitList.Rows.Clear();
            grdWaitList.Columns.Clear();

            grdWaitList.Columns.Add("SEQ", "NO");
            grdWaitList.Columns.Add("EQPTID", "설비");
            grdWaitList.Columns.Add("PROCID", "현재공정");
            grdWaitList.Columns.Add("NEXT_PROC", "다음공정");
            grdWaitList.Columns.Add("LANE_ID", "LANE");
            grdWaitList.Columns.Add("WAIT_QTY", "대기수량");

            grdWaitList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grdWaitList.Columns[0].Width = 60; grdWaitList.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // SEQ
            grdWaitList.Columns[1].Width = 100; grdWaitList.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // 설비
            grdWaitList.Columns[2].Width = 200; grdWaitList.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // 현재공정
            grdWaitList.Columns[3].Width = 200; grdWaitList.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // 다음공정
            grdWaitList.Columns[4].Width = 80; grdWaitList.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // LANE
            grdWaitList.Columns[5].Width = 80; grdWaitList.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;     // 대기 수량


            string cQuery = "";
            cQuery = "SELECT MR.EQPTID, W.ROUTID, W.PROCID, PP1.PROCDESC, RP2.PROCID AS NEXT_PROC, PP2.PROCDESC AS NEXT_PROCDESC, RP2.LANE_ID, COUNT(C.CSTID) AS WAIT_QTY ";
            cQuery += " FROM TB_MCS_RACK MR WITH(NOLOCK) ";
            cQuery += " INNER JOIN CARRIER C WITH(NOLOCK) ON C.CSTID = MR.MCS_CST_ID ";
            cQuery += " INNER JOIN WIP W WITH(NOLOCK) ON W.LOTID = C.CURR_LOTID ";
            cQuery += " INNER JOIN WIPATTR WA WITH(NOLOCK) ON W.LOTID = WA.LOTID ";
            cQuery += " INNER JOIN TB_MMD_FORM_ROUT_PROC RP1 WITH(NOLOCK) ON RP1.ROUTID = W.ROUTID AND RP1.PROCID = W.PROCID ";
            cQuery += " INNER JOIN TB_MMD_FORM_ROUT_PROC RP2 WITH(NOLOCK) ON RP2.ROUTID = RP1.ROUTID AND RP2.PROC_SEQNO = RP1.PROC_SEQNO+1 ";
            cQuery += " INNER JOIN PROCESS PP1 WITH(NOLOCK) ON PP1.PROCID = W.PROCID ";
            cQuery += " INNER JOIN PROCESS PP2 WITH(NOLOCK) ON PP2.PROCID = RP2.PROCID ";
            cQuery += " WHERE (WA.AGING_ISS_SCHD_DTTM < GETDATE() OR WA.AGING_ISS_PRIORITY_NO > 5) ";
            cQuery += " GROUP BY MR.EQPTID, W.ROUTID, W.PROCID, PP1.PROCDESC, RP2.PROCID, PP2.PROCDESC, RP2.LANE_ID ";
            SqlDataAdapter R = new SqlDataAdapter(cQuery, cstr);
            ArrayList ar = new ArrayList();
            DataSet ds = new DataSet();
            R.Fill(ds);

            int Idx = 0;
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Idx++;
                        string[] data = new string[] {
                                Idx.ToString(),
                                dr["EQPTID"].ToString(),
                                dr["PROCID"].ToString()+"("+dr["PROCDESC"].ToString()+")",
                                dr["NEXT_PROC"].ToString()+"("+dr["NEXT_PROCDESC"].ToString()+")",
                                dr["LANE_ID"].ToString(),
                                dr["WAIT_QTY"].ToString()
                        };
                        grdWaitList.Rows.Add(data);
                    }
                }
            }
        }
        /// <summary>
        /// 대기 트레이에 해당하는 다음공정 관련 설비/상태 표시
        /// </summary>
        private void Wait_EQPT_List()
        {
            grdEqptStat.Rows.Clear();
            grdEqptStat.Columns.Clear();
            grdEqptStat.Columns.Add("PROCID", "공정");
            grdEqptStat.Columns.Add("EQGRID", "그룹");
            grdEqptStat.Columns.Add("EQPTID", "설비");
            grdEqptStat.Columns.Add("LANE_ID", "LANE");
            grdEqptStat.Columns.Add("EIOSTAT", "상태");
            grdEqptStat.Columns.Add("EIOIFMODE", "통신");
            grdEqptStat.Columns.Add("PORT_ID", "포트");
            grdEqptStat.Columns.Add("MAX_TRF_QTY", "버퍼");
            grdEqptStat.Columns.Add("CMD_QTY", "반송");

            grdEqptStat.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grdEqptStat.Columns[0].Width = 200; grdEqptStat.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // 공정
            grdEqptStat.Columns[1].Width = 80; grdEqptStat.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 그룹
            grdEqptStat.Columns[2].Width = 120; grdEqptStat.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // 설비
            grdEqptStat.Columns[3].Width = 80; grdEqptStat.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // LANE
            grdEqptStat.Columns[4].Width = 60; grdEqptStat.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 상태
            grdEqptStat.Columns[5].Width = 60; grdEqptStat.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 통신
            grdEqptStat.Columns[6].Width = 140; grdEqptStat.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // 포트
            grdEqptStat.Columns[7].Width = 60; grdEqptStat.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;     // 버퍼
            grdEqptStat.Columns[8].Width = 60; grdEqptStat.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;     // 반송


            //string cstr = "Data Source=10.95.9.59,7433;Initial catalog=ESGM_BMES_FORM_P01;User ID=rtd_app;Password=##r51T1980D@!";
            string cQuery = "";
            cQuery = "SELECT RP2.PROCID AS NEXT_PROC, RP2.LANE_ID ";
            cQuery += " FROM       TB_MCS_RACK           MR WITH(NOLOCK) ";
            cQuery += " INNER JOIN CARRIER               C  WITH(NOLOCK) ON C.CSTID = MR.MCS_CST_ID ";
            cQuery += " INNER JOIN WIP                   W  WITH(NOLOCK) ON W.LOTID = C.CURR_LOTID ";
            cQuery += " INNER JOIN WIPATTR               WA WITH(NOLOCK) ON W.LOTID = WA.LOTID ";
            cQuery += " INNER JOIN TB_MMD_FORM_ROUT_PROC RP1 WITH(NOLOCK) ON RP1.ROUTID = W.ROUTID AND RP1.PROCID = W.PROCID ";
            cQuery += " INNER JOIN TB_MMD_FORM_ROUT_PROC RP2 WITH(NOLOCK) ON RP2.ROUTID = RP1.ROUTID AND RP2.PROC_SEQNO = RP1.PROC_SEQNO+1 ";
            cQuery += " WHERE (WA.AGING_ISS_SCHD_DTTM < GETDATE() OR WA.AGING_ISS_PRIORITY_NO > 5) ";
            cQuery += " GROUP BY RP2.PROCID, RP2.LANE_ID ";
            SqlDataAdapter R = new SqlDataAdapter(cQuery, cstr);
            ArrayList ar = new ArrayList();
            DataSet ds = new DataSet();
            R.Fill(ds);

            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Disp_Status(dr["NEXT_PROC"].ToString(), dr["LANE_ID"].ToString());
                    }
                }
            }
        }
        /// <summary>
        /// Wait Eqpt List
        /// PROCID와 LANE에 해당하는 설비 및 설비 상태 조회
        /// </summary>
        private void Disp_Status(string PROCID, string LANEID)
        {
            //string cstr = "Data Source=10.95.9.59,7433;Initial catalog=ESGM_BMES_FORM_P01;User ID=rtd_app;Password=##r51T1980D@!";

            string cQuery = "";
            cQuery = "SELECT PE.PROCID, PP.PROCDESC, E.EQGRID, PE.EQPTID, EA.S71 AS LANE_ID, EIO.EIOSTAT, EIO.EIOIFMODE, CP.PORT_ID ";
            cQuery += "      ,ISNULL(CP.MAX_TRF_QTY, 0) AS MAX_TRF_QTY, ISNULL(CMD.CMD_QTY, 0) AS CMD_QTY ";
            cQuery += "   FROM PROCESSEQUIPMENT PE WITH(NOLOCK) ";
            cQuery += "   INNER JOIN EQUIPMENT E WITH(NOLOCK) ON E.EQPTID = PE.EQPTID AND E.EQPTIUSE = 'Y' ";
            cQuery += "   INNER JOIN EQUIPMENTSEGMENT ES WITH(NOLOCK) ON ES.EQSGID = E.EQSGID ";
            cQuery += "   INNER JOIN EQUIPMENTATTR    EA WITH(NOLOCK) ON EA.EQPTID = E.EQPTID ";
            cQuery += "   INNER JOIN EIO     EIO WITH(NOLOCK) ON EIO.EQPTID = E.EQPTID ";
            cQuery += "   INNER JOIN TB_MCS_PORT MP WITH(NOLOCK) ON MP.EQPTID = E.EQPTID ";
            cQuery += "   INNER JOIN TB_MCS_CURR_PORT CP WITH(NOLOCK) ON CP.PORT_ID = MP.PORT_ID ";
            cQuery += "   INNER JOIN PROCESS PP WITH(NOLOCK) ON PP.PROCID = PE.PROCID ";
            cQuery += "   LEFT JOIN ( SELECT TO_PORT_ID, COUNT(CSTID) AS CMD_QTY ";
            cQuery += "                 FROM TB_MHS_TRF_CMD WITH(NOLOCK) ";
            cQuery += "                WHERE CMD_STAT_CODE IN ('RECEIVE','MOVING') ";
            cQuery += "              GROUP BY TO_PORT_ID ";
            cQuery += "   ) AS CMD ON CMD.TO_PORT_ID = MP.PORT_ID ";
            cQuery += "   WHERE PE.PROCID = '" + PROCID + "'";
            cQuery += "     AND EA.S71 LIKE '" + (LANEID.Substring(LANEID.Length - 1) == "0" ? LANEID.Substring(0, 5) + "%" : LANEID) + "'";
            cQuery += "     AND CP.PORT_ID = (CASE WHEN E.EQGRID = 'STO' THEN E.EQPTID + '-SHELF' ELSE MP.PORT_ID END) ";
            cQuery += "     AND PE.USE_FLAG = 'Y' ";
            cQuery += "   ORDER BY CP.PORT_ID   ";
                                            
            txtSQL.Text += cQuery;
            SqlDataAdapter R = new SqlDataAdapter(cQuery, cstr);
            ArrayList ar = new ArrayList();
            DataSet ds = new DataSet();
            R.Fill(ds);

            string EQGRID = "";
            string EQPTID = "";

            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        EQGRID = dr["EQGRID"].ToString();
                        EQPTID = dr["EQPTID"].ToString();

                        string[] data = new string[] {
                                dr["PROCID"].ToString()+"("+dr["PROCDESC"].ToString()+")",
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
                            if (EQPTID.Length == 11) grdEqptStat.Rows.Add(data);
                        }
                        else if (EQGRID == "EOL")
                        {
                            if (EQPTID.Length == 11 && dr["PORT_ID"].ToString().IndexOf("-PL1") >= 0) grdEqptStat.Rows.Add(data);
                        }
                        else
                        {
                            grdEqptStat.Rows.Add(data);
                        }
                        if (dr["MAX_TRF_QTY"].ToString() == "0")
                        {
                            grdEqptStat.Rows[grdEqptStat.RowCount - 1].DefaultCellStyle.BackColor = Color.GreenYellow;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 미반송 현황 이벤트 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdEMGView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                string CSTID = grdEMGView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (CSTID != "")
                {
                    FrmTrayInfo ftray = new FrmTrayInfo();
                    ftray.CSTID = CSTID;
                    ftray.ShowDialog();
                }
            }
            else if (e.ColumnIndex == 7)
            {
                string ROUTID = grdEMGView.Rows[e.RowIndex].Cells[7].Value.ToString();
                string PROCID = grdEMGView.Rows[e.RowIndex].Cells[8].Value.ToString();
                if (ROUTID == "") return;
                FrmRout frout = new FrmRout();
                frout.ROUTID = ROUTID;
                frout.PROCID = PROCID;
                frout.ShowDialog();
            }
            else if (e.ColumnIndex == 11)  // 다음 공정
            {
                string LANEID = grdEMGView.Rows[e.RowIndex].Cells[12].Value.ToString();
                string PROCID = grdEMGView.Rows[e.RowIndex].Cells[11].Value.ToString();
                if (PROCID == "") return;
                FrmNextProcEqpt frout = new FrmNextProcEqpt();
                frout.LANEID = LANEID;
                frout.PROCID = PROCID;
                frout.ShowDialog();
            }
        }
        /// <summary>
        /// 설비별 반송현황 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEQPTView_Click(object sender, EventArgs e)
        {

            grdEQPTView.Rows.Clear();
            grdEQPTView.Columns.Clear();

            grdEQPTView.Columns.Add("SEQ", "NO");
            grdEQPTView.Columns.Add("EQGRID", "그룹");
            grdEQPTView.Columns.Add("EQPTID", "설비");
            grdEQPTView.Columns.Add("PORT_ID", "포트");
            grdEQPTView.Columns.Add("PORT_NAME", "포트명");
            grdEQPTView.Columns.Add("EQPTIUSE", "사용");
            grdEQPTView.Columns.Add("LANE_ID", "LANE");
            grdEQPTView.Columns.Add("EIOSTAT", "상태");
            grdEQPTView.Columns.Add("EIOIFMODE", "통신");
            grdEQPTView.Columns.Add("MAX_TRF_QTY", "버퍼");
            grdEQPTView.Columns.Add("CMD_QTY", "반송");

            grdEQPTView.Columns[0].Width = 60; grdEQPTView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // SEQ
            grdEQPTView.Columns[1].Width = 150; grdEQPTView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // 그룹
            grdEQPTView.Columns[2].Width = 100; grdEQPTView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // 설비
            grdEQPTView.Columns[3].Width = 150; grdEQPTView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // 포트
            grdEQPTView.Columns[4].Width = 350; grdEQPTView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     // 포트명
            grdEQPTView.Columns[5].Width = 80; grdEQPTView.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 사용여부
            grdEQPTView.Columns[6].Width = 80; grdEQPTView.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // lane
            grdEQPTView.Columns[7].Width = 80; grdEQPTView.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 상태
            grdEQPTView.Columns[8].Width = 80; grdEQPTView.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 통신
            grdEQPTView.Columns[9].Width = 80; grdEQPTView.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;     // 버퍼
            grdEQPTView.Columns[10].Width = 80; grdEQPTView.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;     // 반송

            Each_Eqpt_View();
        }
        /// <summary>
        /// 설비별 반송 현황
        /// </summary>
        private void Each_Eqpt_View()
        {
            grdEQPTView.Rows.Clear();

            //string cstr = "Data Source=10.95.9.59,7433;Initial catalog=ESGM_BMES_FORM_P01;User ID=rtd_app;Password=##r51T1980D@!";

            string cquery = " SELECT EA.S70 AS EQGRDETID, CC.CMCDNAME AS EQGRDETNM, e.EQGRID, MP.EQPTID, e.EQPTID AS PORT_ID, e.EQPTNAME AS PORT_NAME, e.EQPTIUSE, EA.S71 AS LANE_ID, ei.EIOSTAT, ei.EIOIFMODE, ei.EIOCOMSTAT ";
            cquery += "             , ISNULL(CP.MAX_TRF_QTY, 0) AS MAX_TRF_QTY   ";
            cquery += "             , ISNULL(CD.CMD_CNT, 0) AS CMD_QTY   ";
            cquery += "    FROM EQUIPMENT                e WITH(NOLOCK) ";
            cquery += "   INNER JOIN EQUIPMENTATTR      EA WITH(NOLOCK) ON e.EQPTID   = EA.EQPTID ";
            cquery += "   INNER JOIN COMMONCODE         CC WITH(NOLOCK) ON CC.CMCDTYPE = 'EQPT_GR_TYPE_CODE' AND CC.CMCODE = EA.S70";
            cquery += "   INNER JOIN EQUIPMENTSEGMENT   ES WITH(NOLOCK) ON ES.EQSGID  = E.EQSGID ";
            cquery += "   INNER JOIN TB_MCS_PORT        MP WITH(NOLOCK) ON MP.PORT_ID = e.EQPTID AND MP.USE_FLAG = 'Y' ";
            cquery += "   INNER JOIN TB_MCS_CURR_PORT   CP WITH(NOLOCK) ON CP.PORT_ID = e.EQPTID  ";
            cquery += "   INNER JOIN EIO                ei WITH(NOLOCK) ON ei.EQPTID  = mp.EQPTID ";
            cquery += "   LEFT JOIN (  ";
            cquery += "     SELECT  TO_EQPTID, TO_PORT_ID, COUNT(CSTID) AS CMD_CNT ";
            cquery += "       FROM  TB_MHS_TRF_CMD WITH(NOLOCK) ";
            cquery += "       GROUP BY TO_EQPTID, TO_PORT_ID ) CD  ON CD.TO_PORT_ID = e.EQPTID ";
            cquery += " WHERE 1 = 1";
            if (cobEQGR.SelectedIndex > 0)
            {
                cquery += "   AND EA.S70 = '" + cobEQGR.Text.Substring(cobEQGR.Text.IndexOf('(')+1,1) + "'";
            } else
            {
                cquery += "   AND EA.S70 IS NOT NULL ";
            }
            cquery += "   AND SUBSTRING(E.EQPTID, 4,3) NOT IN ('FOR','JGF') ";
            //cquery += "   AND E.EQGRID  NOT IN ('JGF','DIS','FOR','CNV','STO','OHS') ";
            cquery += "   AND ES.AREAID  = '"+AREAID+"' ";
            cquery += "   AND e.EQPTID like 'U1F%'";
            cquery += "   AND e.EQPTLEVEL = 'U' AND e.EQPTTYPE = 'L' ";
            //cquery += "   AND e.EQPTID NOT LIKE '%-PU%'";
            //cquery += "   AND (EQGRID <> 'DEG' OR LEN(MP.EQPTID) <> 9) ";
            cquery += "   AND e.EQPTIUSE = 'Y'";
            cquery += " ORDER BY EA.S70, e.EQGRID, MP.EQPTID, e.EQPTID ";
            SqlDataAdapter R = new SqlDataAdapter(cquery, cstr);
            ArrayList ar = new ArrayList();
            DataSet ds = new DataSet();
            R.Fill(ds);

            txtSQL.Text = cquery;
            int Idx = 0, sIDX=0;
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Idx++;
                        string PORT_NM = "", EQGRDETNM = "", sTemp="";
                        PORT_NM = dr["PORT_NAME"].ToString().Substring(6);
                        if (PORT_NM != "")
                        {
                            PORT_NM = PORT_NM.Substring(0, PORT_NM.IndexOf('|'));
                        } //EQGRDETNM
                        sTemp = dr["EQGRDETNM"].ToString();
                        EQGRDETNM = sTemp;
                        sIDX = sTemp.IndexOf('|');
                        if (sIDX>=0)
                        {                            
                            sIDX = EQGRDETNM.IndexOf('|');
                            if (sIDX > 0) EQGRDETNM = sTemp.Substring(6, sIDX - 6);
                        } //

                        string[] data = new string[] {
                                Idx.ToString(),
                                EQGRDETNM,
                                dr["EQPTID"].ToString(),
                                dr["PORT_ID"].ToString(),
                                PORT_NM,
                                dr["EQPTIUSE"].ToString(),
                                dr["LANE_ID"].ToString(),
                                dr["EIOSTAT"].ToString(),
                                dr["EIOIFMODE"].ToString(),
                                dr["MAX_TRF_QTY"].ToString(),
                                dr["CMD_QTY"].ToString()
                            };
                        grdEQPTView.Rows.Add(data);

                        if (dr["EQPTIUSE"].ToString() == "N")
                        {
                            grdEQPTView.Rows[grdEQPTView.RowCount - 1].DefaultCellStyle.BackColor = Color.Silver;
                        }
                        else
                        {
                            if (cobEQGR.SelectedIndex == 0)
                            {
                                switch (dr["EQGRDETID"].ToString())
                                {
                                    case "D":       // DEGAS (U:unit)
                                        grdEQPTView.Rows[grdEQPTView.RowCount - 1].DefaultCellStyle.BackColor = Color.Aqua;
                                        break;
                                    case "5":       // EOL (U:unit)
                                        grdEQPTView.Rows[grdEQPTView.RowCount - 1].DefaultCellStyle.BackColor = Color.White;
                                        break;
                                    case "U":       // HPCD (U:unit)
                                        grdEQPTView.Rows[grdEQPTView.RowCount - 1].DefaultCellStyle.BackColor = Color.YellowGreen;
                                        break;
                                    case "6":       // SEL (EQPTLEVEL->U:unit, EQPTTYPE -> L:물류)
                                        grdEQPTView.Rows[grdEQPTView.RowCount - 1].DefaultCellStyle.BackColor = Color.LightPink;
                                        break;
                                    case "1":       // DIS(충방) (EQPTLEVEL->U:unit, EQPTTYPE -> L:물류)
                                        grdEQPTView.Rows[grdEQPTView.RowCount - 1].DefaultCellStyle.BackColor = Color.GreenYellow;
                                        break;
                                    case "8":       // OCV (EQPTLEVEL->U:unit, EQPTTYPE -> L:물류)
                                        grdEQPTView.Rows[grdEQPTView.RowCount - 1].DefaultCellStyle.BackColor = Color.NavajoWhite;
                                        break;
                                }
                            }
                            if (dr["EIOIFMODE"].ToString() == "OFF")
                            {
                                grdEQPTView.Rows[grdEQPTView.RowCount - 1].Cells[8].Style.BackColor = Color.Orange;
                            }
                            if (dr["EIOSTAT"].ToString() == "F")  //dr["EIOSTAT"].ToString() == "T" 
                            {
                                grdEQPTView.Rows[grdEQPTView.RowCount - 1].Cells[7].Style.BackColor = Color.FromArgb(100, 200, 89);
                            }
                            //if (((Convert.ToSingle(dr["DISABLE_QTY"].ToString()) + Convert.ToSingle(dr["USING_QTY"].ToString())) / Convert.ToSingle(dr["RACK_MAX_QTY"].ToString()) * 100.0) > 90)
                            //{
                            //    grdEQPTView.Rows[grdEQPTView.RowCount - 1].Cells[7].Style.BackColor = Color.PaleVioletRed;
                            //}
                        }
                    }
                }
            }

        }
        /// <summary>
        /// 반송 요청정보 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReqList_Click(object sender, EventArgs e)
        {
            ReqList();
        }

        private void txtReqCSTID_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtReqCSTID.Text = "";
        }

        private void txtReqEqpt_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtReqEqpt.Text = "";
        }
        /// <summary>
        /// 문자 분리
        /// 예) A362,B372,D382  => 'A362','B372','D382'
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        private string Text_Split(string txt)
        {
            if (txt.Trim().Length == 0) return "";
            string retData = "";

            string[] cst;
            cst = txt.Split(',');
            for (int i = 0; i < cst.Length; i++)
            {
                retData += "'" + cst[i].Trim() + "',";
            }
            if (retData.Length >= 1) retData = retData.Substring(0, retData.Length - 1);
            return retData;
        }

        private void txtReqPort_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtReqPort.Text = "";
        }

        private void tmUSA_Tick(object sender, EventArgs e)
        {
            DateTime usaTime = DateTime.UtcNow;

            if (lb_DbName.Text.Contains("ESGM_"))
            {
                lblTimeUSA.Text = "US(Ohio) : " + TimeZoneInfo.ConvertTimeBySystemTimeZoneId(usaTime, "US Eastern Standard Time").ToString("yyyy-MM-dd HH:mm:ss");
            }
            else if (lb_DbName.Text.Contains("CNB_"))
            {
                lblTimeUSA.Text = "China(Nanjing) : " + TimeZoneInfo.ConvertTimeBySystemTimeZoneId(usaTime, "China Standard Time").ToString("yyyy-MM-dd HH:mm:ss");
            }
            else if (lb_DbName.Text.Contains("ESHM_"))
            {
                lblTimeUSA.Text = "Indonesia(Jakarta) : " + TimeZoneInfo.ConvertTimeBySystemTimeZoneId(usaTime, "SE Asia Standard Time").ToString("yyyy-MM-dd HH:mm:ss");
            }
            else if (lb_DbName.Text.Contains("CWB_"))
            {
                lblTimeUSA.Text = "Poland(Wroclaw) : " + TimeZoneInfo.ConvertTimeBySystemTimeZoneId(usaTime, "Central European Standard Time").ToString("yyyy-MM-dd HH:mm:ss");
            }
            else if (lb_DbName.Text.Contains("xe") || lb_DbName.Text.Contains("ESGM2_"))
            {
                lblTimeUSA.Text = "US(Tennessee) : " + TimeZoneInfo.ConvertTimeBySystemTimeZoneId(usaTime, "Central Standard Time").ToString("yyyy-MM-dd HH:mm:ss");
            }
            lblKor.Text = "한국시간 : " + TimeZoneInfo.ConvertTimeBySystemTimeZoneId(usaTime, "Korea Standard Time").ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void grdState_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cobJob.SelectedIndex == 7) // 충방전기
            {   // 충방
                string PORT_ID = grdState.Rows[e.RowIndex].Cells[0].Value.ToString();
                Eqpt_Sub_Formation_Stat_List(PORT_ID);
            }
            else
            {
                string EQPTID = grdState.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (EQPTID != "")
                {
                    //chkEio.Checked = true;
                    txtHistPort.Text = EQPTID;
                    Eqpt_Eio_Act_Hist_List();
                }
            }
        }

        private void lblKor_DoubleClick(object sender, EventArgs e)
        {
            txtSQL.Visible = !txtSQL.Visible;
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void chkReqhist_CheckedChanged(object sender, EventArgs e)
        {
            if(chkReqhist.Checked==true)
            {
                spconReq.Panel2Collapsed = false;
            }
            else
            {
                spconReq.Panel2Collapsed = true;
            }
        }

        private void txtHistPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Eqpt_Eio_Act_Hist_List();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            FrmLogin FrmLogin = new FrmLogin(LastLoginFileName);
            FrmLogin.ShowDialog();

            if (FrmLogin.cstr != null)             // Normal Login
            {
                if (FrmLogin.logincstr != "Manual") // Auto Login
                {
                    cstr = FrmLogin.cstr;
                    AREAID = FrmLogin.aryAREA[1];
                    PLANTID = FrmLogin.aryPLANT[1];
                    lb_IP.Text = FrmLogin.aryDS[1];
                    lb_DbName.Text = FrmLogin.aryIC[1];
                }
                else // Manual Login
                {
                    cstr = FrmLogin.cstr;
                    AREAID = FrmLogin.manuAREA;
                    PLANTID = FrmLogin.manuPLANT;
                    lb_IP.Text = FrmLogin.manuDS;
                    lb_DbName.Text = FrmLogin.manuIC;
                }
            }
            else // Abnormal Login
            {
                return;
            }
            Init();
            //cobGubun.SelectedIndex = 0;
            cobTray.SelectedIndex = 0;
            cobStat.SelectedIndex = 0;
            cobLane.SelectedIndex = 0;
            cobCmdLane.SelectedIndex = 0;
            DateTime sdate = new DateTime();
            sdate = DateTime.Now;

            txtTo.Text = txtFrom.Text = DateTime.Now.ToString();
            txtReqeDate.Value = sdate;
            txtReqsDate.Value = sdate.AddHours(-24);
            txteDate.Value = sdate;
            txtsDate.Value = sdate.AddHours(-24);
            txtHisteDate.Value = sdate;
            txtHistsDate.Value = sdate.AddHours(-24);
            txteTime.Value = sdate;
            txtsTime.Value = sdate.AddHours(-24);

            Init_Search();
        }

        private void lblTimeUSA_Click(object sender, EventArgs e)
        {
            txtSQL.Visible = !txtSQL.Visible;
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            txtSQL.Visible = !txtSQL.Visible;
        }

        private void ShowSqltoDGV(DataGridView dataGridView, string cquery, DynamicParameters parameters)
        {
            if (strs[cb_DbString.Text].DatabaseProvider.ToString() == "ORACLE")
            {
                ShowSqltoDGV_ORACLE(dataGridView, cquery, parameters);
            } else if (strs[cb_DbString.Text].DatabaseProvider.ToString() == "MSSQL")
            {
                ShowSqltoDGV_MSSQL(dataGridView, cquery, parameters);
            }
            else { MessageBox.Show("Check DatabaseProvier into DBConnectionString.xml file "); }
            
            
        }

        private void ShowSqltoDGV_ORACLE(DataGridView dataGridView, string cquery, DynamicParameters parameters)
        {
            try
            {
                dataGridView.DataSource = null;
                //dgv_test.AutoGenerateColumns = false;
                //using (var connection = new OracleConnection(cstr))
                using (var connection = new OracleConnection(cstr))
                {
                    if (parameters != null)
                    {
                        dataGridView.DataSource = connection.Query(cquery, parameters).ToList();
                    }
                    else
                    {
                        dataGridView.DataSource = connection.Query(cquery).ToList();
                    }
                }
                dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
                dataGridView.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowSqltoDGV_MSSQL(DataGridView dataGridView, string cquery, DynamicParameters parameters)
        {
            try
            {
                dataGridView.DataSource = null;
                //dgv_test.AutoGenerateColumns = false;
                //using (var connection = new OracleConnection(cstr))
                using (var connection = new SqlConnection(cstr))
                {
                    if (parameters != null)
                    {
                        dataGridView.DataSource = connection.Query(cquery, parameters).ToList();
                    }
                    else
                    {
                        dataGridView.DataSource = connection.Query(cquery).ToList();
                    }
                }
                dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
                dataGridView.AutoResizeColumns();
                dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cb_DbString_TextChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            if (comboBox.Text != string.Empty) ChangeDBConn(comboBox.Text);

        }

        private void bt_SettingRefresh_Click(object sender, EventArgs e)
        {
            SettingInit();
        }

        private void bt_Test_Click(object sender, EventArgs e)
        {
            ShowSqltoDGV(dgv_test, rtb_test.Text, null);
        }

        private void SearchTransportReq()
        {
            try
            {
                XmlOptionData sqldata = sqlList["btnOK_Click"];

                string cquery = sqldata.sql;
                var parameters = new DynamicParameters();
                if (chkuCmd.Checked == false)        // 유효반송이 아니면
                {   // 이력 조회
                    CustomUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 0);
                    //cquery += " INNER JOIN TB_MHS_TRF_CMD_HIST H with(nolock) ON H.CSTID = CC.CSTID  ";
                }
                else
                {   // 유효반송 조회
                    CustomUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 1);
                    //cquery += " INNER JOIN TB_MHS_TRF_CMD H with(nolock) ON H.CSTID = CC.CSTID  ";
                }
                CustomUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 2);
                //cquery += " LEFT JOIN WIP W with(nolock) ON W.LOTID = CC.CURR_LOTID ";
                //cquery += " LEFT JOIN WIPATTR WA with(nolock) ON WA.LOTID = W.LOTID ";
                //cquery += " LEFT JOIN COMMONCODE     C with(nolock) ON C.CMCDTYPE = 'TRF_REQ_ERR_CODE' AND C.CMCODE = H.RSPN_CODE";
                if (txtCSTID.Text != "" || chkuCmd.Checked)
                {
                    CustomUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 3);
                    //cquery += " WHERE  1=1 ";
                }
                else //if (chk24.Checked)
                {
                    CustomUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 4);
                    parameters.Add("@StartDate", string.Concat("%", txtsDate.Text, "%"));
                    parameters.Add("@EndDate", string.Concat("%", txteDate.Text, "%"));
                    //cquery += " WHERE CONVERT(CHAR(10), H.INSDTTM, 20) BETWEEN '" + txtsDate.Text + "' AND '" + txteDate.Text + "' ";
                }
                if (cobCmdLane.SelectedIndex > 0)
                {
                    CustomUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 5);
                    parameters.Add("@LANE_ID", string.Concat("%", cobCmdLane.Text, "%"));
                    //cquery += " AND WA.LANE_ID LIKE '" + cobCmdLane.Text + "%'";
                }
                if (chkuCmd.Checked && chkAbnormal.Checked)        // 유효반송 비정상종료
                {
                    CustomUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 6);
                    //cquery += " AND H.CMD_STAT_CODE IN ('MOVING','RECEIVE','ABNORMAL_END')";
                    //cquery += " AND ISNULL(H.CNCL_REQ_FLAG, '') NOT IN ('Y', 'S') ";
                }
                else if (chkAbnormal.Checked) // 비정상종료
                {
                    CustomUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 7);
                    //cquery += " AND H.CMD_STAT_CODE IN ('ABNORMAL_END')";
                }
                else if (chkuCmd.Checked) //유효반송
                {
                    CustomUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 8);
                    //cquery += " AND H.CMD_STAT_CODE IN ('MOVING','RECEIVE')";
                    //cquery += " AND ISNULL(H.CNCL_REQ_FLAG, '') NOT IN ('Y', 'S') ";
                }
                if (chkDel.Checked)         // 삭제 이력
                {
                    CustomUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 9);
                    //cquery += " AND H.CMD_STAT_CODE <> 'DELETE' ";
                }
                if (!(chkUsing.Checked && chkEmpty.Checked))
                {
                    CustomUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 10);
                    if (chkUsing.Checked) parameters.Add("@CSTSTAT", string.Concat("U")); ;    // 실트레이
                    if (chkEmpty.Checked) parameters.Add("@CSTSTAT", string.Concat("E")); ;    // 공트레이
                }
                if (txtCSTID.Text != "")
                {
                    CustomUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 11);
                    parameters.Add("@CSTID", string.Concat("%", txtCSTID.Text, "%"));
                    //cquery += " AND H.CSTID LIKE '%" + txtCSTID.Text + "%'";
                }
                if (txtReqPort.Text != "")
                {
                    CustomUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 12);
                    parameters.Add("@ReqPortId", string.Concat("%", txtReqPort.Text, "%"));
                    //cquery += " AND H.FROM_PORT_ID LIKE '%" + txtReqPort.Text + "%'";
                }
                if (txtPort.Text != "")
                {
                    CustomUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 13);
                    parameters.Add("@ToPortId", string.Concat("%", txtPort.Text, "%"));
                    //cquery += " AND H.TO_PORT_ID LIKE '%" + txtPort.Text + "%'";
                }
                if (chkABNORM.Checked == true)
                {
                    CustomUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 14);
                    //cquery += " AND CC.ABNORM_TRF_RSN_CODE = 'STACK_VALID_ERROR' ";
                }
                CustomUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 15);
                //cquery += "  AND H.INSUSER <> 'MCS(SYNC)' ";
                //cquery += " ORDER BY H.INSDTTM DESC ";


                ShowSqltoDGV(grdList, cquery, parameters);
            }
            catch (Exception ex)
            {
                if (tmr_SearchTransport.Enabled)
                {
                    tmr_SearchTransport.Stop();
                }

                MessageBox.Show($"{ex.Message} : {System.Reflection.MethodBase.GetCurrentMethod().Name}");
            }

        }

        private void tmr_SearchTransport_Tick(object sender, EventArgs e)
        {
            SearchTransportReq();
        }
    }
}