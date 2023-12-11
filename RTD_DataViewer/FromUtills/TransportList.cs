using Dapper;
using DBManagemnet;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XmlManagement;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace RTD_DataViewer
{
    internal class TransportList
    {
        MainViewer main;
        int currNum = 0;
        public TransportList(MainViewer main)
        {
            this.main = main;
            InitControlText(main);
        }

        public void InitControlText(MainViewer main)
        {
            main.cb_Cststat.SelectedIndex = 0;

            main.tAbt_TransList_Search.timer.Tick += Timer_Tick;
            main.transList_dgvReq.DgvData.CellClick += SearchCstId;
            main.transList_dgvReq.DgvData.CellClick += SearchTrf;
        }

        private void SearchTrf(object? sender, DataGridViewCellEventArgs e)
        {
            try
            {
                XmlOptionData sqldata = main.sqlList["TransportList"];
                DynamicParameters parameters = new DynamicParameters();
                string cquery = string.Empty;
                WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 16);

                //DataGridView dataGrid = sender as DataGridView;

                string trf_Code = (sender as DataGridView).CurrentRow.Cells["TRF_CODE"].Value.ToString();

                parameters.Add("@TRF_CODE", trf_Code);

                new WinformUtils(main).ShowSqltoDGV(main.transList_CstHist.DgvData, cquery, parameters, main.correntConnectionStringSetting);

                main.uwC_TextBox1.ApeendText(cquery, "@TRF_CODE", trf_Code);
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void SearchCstId(object? sender, DataGridViewCellEventArgs e)
        {
            try
            {
                XmlOptionData sqldata = main.sqlList["TransportList"];
                DynamicParameters parameters = new DynamicParameters();
                string cquery = string.Empty;
                WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 17);

                //DataGridView dataGrid = sender as DataGridView;

                string cstId = (sender as DataGridView).CurrentRow.Cells["CSTID"].Value.ToString();

                parameters.Add("@CSTID", cstId);

                new WinformUtils(main).ShowSqltoDGV(main.transList_CstInfo.DgvData, cquery, parameters, main.correntConnectionStringSetting);
                
                main.uwC_TextBox1.ApeendText(cquery, "@CSTID", cstId);
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            int interval = main.tAbt_TransList_Search.Interval;
            
            if (currNum == 0)
            {
                SearchTransportReq();
                currNum = main.tAbt_TransList_Search.Interval;
            }
            else
            {
                main.tAbt_TransList_Search.bt_Search.Text = currNum.ToString("000") + "\nStop";
                currNum--;
            }
        }

        internal void Btn_Click()
        {


            if (main.tAbt_TransList_Search.IsUseTimer)
            {
                main.tAbt_TransList_Search.timer.Interval = 1000;
                if (main.tAbt_TransList_Search.timer.Enabled)
                {
                    main.tAbt_TransList_Search.timer.Stop();
                    main.tAbt_TransList_Search.bt_Search.Text = "Search";
                }
                else
                {
                    main.tAbt_TransList_Search.timer.Start();
                }
            }
            else
            {
                SearchTransportReq();
            }
        }

        private void SearchTransportReq()
        {
            bool isValidTransfer = main.ckb_IsValidTransfer.Checked;
            bool isAbnormal = main.ckb_IsAbnormal.Checked;
            bool isExceptDelete = main.ckb_IsExceptDelete.Checked;
            bool isFaulty = main.ckb_IsFaulty.Checked;

            string cstid = main.lAtb_TransList_CarrierId.Tb_Text;
            string toEqpId = main.lAtb_TransList_ToEqp.Tb_Text;
            string reqEqpId = main.lAtb_TransList_ReqEqp.Tb_Text;
            string laneId = main.lAtb_TransList_LaneId.Tb_Text;
            string startDate = main.lAdtp_TransList_StartDate.Dtp_Value.ToString("yyyy-MM-dd");
            string endDate = main.lAdtp_TransList_EndDate.Dtp_Value.ToString("yyyy-MM-dd");

            int cb_Num = main.cb_Cststat.SelectedIndex;

            try
            {
                XmlOptionData sqldata = main.sqlList["TransportList"];
                Dictionary<string, string> parameterDic = new Dictionary<string, string>();
                string cquery = sqldata.sql;
                var parameters = new DynamicParameters();
                if (isValidTransfer == false)        // 유효반송이 아니면
                {   // 이력 조회
                    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 0);
                    //cquery += " INNER JOIN TB_MHS_TRF_CMD_HIST H with(nolock) ON H.CSTID = CC.CSTID  ";
                }
                else
                {   // 유효반송 조회
                    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 1);
                    //cquery += " INNER JOIN TB_MHS_TRF_CMD H with(nolock) ON H.CSTID = CC.CSTID  ";
                }
                WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 2);
                //cquery += " LEFT JOIN WIP W with(nolock) ON W.LOTID = CC.CURR_LOTID ";
                //cquery += " LEFT JOIN WIPATTR WA with(nolock) ON WA.LOTID = W.LOTID ";
                //cquery += " LEFT JOIN COMMONCODE     C with(nolock) ON C.CMCDTYPE = 'TRF_REQ_ERR_CODE' AND C.CMCODE = H.RSPN_CODE";
                if (cstid != string.Empty || isValidTransfer)
                {
                    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 3);
                    //cquery += " WHERE  1=1 ";
                }
                else //if (chk24.Checked)
                {
                    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 4);
                    parameters.Add("@StartDate", string.Concat("%", startDate, "%"));
                    parameters.Add("@EndDate", string.Concat("%", endDate, "%"));
                    //cquery += " WHERE CONVERT(CHAR(10), H.INSDTTM, 20) BETWEEN '" + txtsDate.Text + "' AND '" + txteDate.Text + "' ";
                }
                if (laneId != string.Empty)
                {
                    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 5);
                    parameters.Add("@LANE_ID", string.Concat("%", laneId, "%"));
                    //cquery += " AND WA.LANE_ID LIKE '" + cobCmdLane.Text + "%'";
                }
                if (isAbnormal && isValidTransfer)        // 유효반송 비정상종료
                {
                    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 6);
                    //cquery += " AND H.CMD_STAT_CODE IN ('MOVING','RECEIVE','ABNORMAL_END')";
                    //cquery += " AND ISNULL(H.CNCL_REQ_FLAG, '') NOT IN ('Y', 'S') ";
                }
                else if (isAbnormal) // 비정상종료
                {
                    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 7);
                    //cquery += " AND H.CMD_STAT_CODE IN ('ABNORMAL_END')";
                }
                else if (isValidTransfer) //유효반송
                {
                    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 8);
                    //cquery += " AND H.CMD_STAT_CODE IN ('MOVING','RECEIVE')";
                    //cquery += " AND ISNULL(H.CNCL_REQ_FLAG, '') NOT IN ('Y', 'S') ";
                }
                if (isExceptDelete)         // 삭제 이력
                {
                    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 9);
                    //cquery += " AND H.CMD_STAT_CODE <> 'DELETE' ";
                }
                if (cb_Num != 0)
                {
                    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 10);
                    if (cb_Num == 1) parameters.Add("@CSTSTAT", string.Concat("U")); ;    // 실트레이
                    if (cb_Num == 2) parameters.Add("@CSTSTAT", string.Concat("E")); ;    // 공트레이
                }
                if (cstid != string.Empty)
                {
                    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 11);
                    parameters.Add("@CSTID", string.Concat("%", cstid, "%"));
                    //cquery += " AND H.CSTID LIKE '%" + txtCSTID.Text + "%'";
                }
                if (reqEqpId != string.Empty)
                {
                    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 12);
                    parameters.Add("@ReqPortId", string.Concat("%", reqEqpId, "%"));
                    //cquery += " AND H.FROM_PORT_ID LIKE '%" + txtReqPort.Text + "%'";
                }
                if (toEqpId != string.Empty)
                {
                    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 13);
                    parameters.Add("@ToPortId", string.Concat("%", toEqpId, "%"));
                    //cquery += " AND H.TO_PORT_ID LIKE '%" + txtPort.Text + "%'";
                }
                if (isAbnormal)
                {
                    WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 14);
                    //cquery += " AND CC.ABNORM_TRF_RSN_CODE = 'STACK_VALID_ERROR' ";
                }
                WinformUtils.AddToOptionalSqlSyntax(ref cquery, sqldata, 15);
                //cquery += "  AND H.INSUSER <> 'MCS(SYNC)' ";
                //cquery += " ORDER BY H.INSDTTM DESC ";


                new WinformUtils(main).ShowSqltoDGV(main.transList_dgvReq.DgvData, cquery, parameters, main.correntConnectionStringSetting);

                main.uwC_TextBox1.ApeendText(cquery, "@CSTID", cstid);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} : SearchTransportReq");
            }

        }
    }
}
