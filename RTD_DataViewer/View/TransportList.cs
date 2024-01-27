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
    public partial class TransportList : UserControl
    {
        MainViewer main;
        int currNum = 0;
        public TransportList(MainViewer main)
        {
            InitializeComponent();
            this.main = main;
            InitControlText(main);
        }

        public void InitControlText(MainViewer main)
        {
            cb_Cststat.SelectedIndex = 0;

            DateTime tomorrow = DateTime.Today.AddDays(1);
            DateTime yesterday = DateTime.Today.AddDays(-1);
            this.main = main;
            tAbt_TransList_Search.timer.Tick += Timer_Tick;
            tAbt_TransList_Search.bt_Search.Click += Bt_Search_Click;
            lAdtp_TransList_EndDate.Dtp_Value = tomorrow;
            lAdtp_TransList_StartDate.Dtp_Value = yesterday;
            transList_dgvReq.DgvData.CellClick += SearchCstInfo;
            transList_dgvReq.DgvData.CellClick += SearchTrf;

            transList_dgvReq.DgvData.CellDoubleClick += SearchCstInfo;
        }

        private string MakeCmdStatCodeList()
        {
            string CmdStatCodeList = string.Empty;

            if (ckb_Send.Checked)
            {
                if (CmdStatCodeList == string.Empty)
                {
                    CmdStatCodeList += @"'SEND'";
                }
                else
                {
                    CmdStatCodeList += @",'SEND'";
                }
            }

            if (ckb_Receive.Checked)
            {
                if (CmdStatCodeList == string.Empty)
                {
                    CmdStatCodeList += @"'RECEIVE'";
                }
                else
                {
                    CmdStatCodeList += @",'RECEIVE'";
                }
            }

            if (ckb_Moving.Checked)
            {
                if (CmdStatCodeList == string.Empty)
                {
                    CmdStatCodeList += @"'MOVING'";
                }
                else
                {
                    CmdStatCodeList += @",'MOVING'";
                }
            }

            if (ckb_Delete.Checked)
            {
                if (CmdStatCodeList == string.Empty)
                {
                    CmdStatCodeList += @"'DELETE'";
                }
                else
                {
                    CmdStatCodeList += @",'DELETE'";
                }
            }

            if (ckb_Abnormal.Checked)
            {
                if (CmdStatCodeList == string.Empty)
                {
                    CmdStatCodeList += @"'ABNORMAL_END'";
                }
                else
                {
                    CmdStatCodeList += @",'ABNORMAL_END'";
                }
            }

            if (ckb_Cancel.Checked)
            {
                if (CmdStatCodeList == string.Empty)
                {
                    CmdStatCodeList += @"'CANCEL'";
                }
                else
                {
                    CmdStatCodeList += @",'CANCEL'";
                }
            }

            return CmdStatCodeList;
        }

        private void SearchCstId(object? sender, DataGridViewCellEventArgs e)
        {
            try
            {
                XmlOptionData sqldata = main.sqlList["SearchCstInfo"];
                DynamicParameters parameters = new DynamicParameters();
                string cquery = sqldata.Sql;

                //DataGridView dataGrid = sender as DataGridView;

                string trf_Code = (sender as DataGridView).CurrentRow.Cells["TRF_CODE"].Value.ToString();

                parameters.Add("@TRF_CODE", trf_Code);

                new WinformUtils(main).ShowSqltoDGV(transList_CstHist.DgvData, cquery, parameters, main.correntConnectionStringSetting);
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void Bt_Search_Click(object? sender, EventArgs e)
        {
            Btn_Click();
        }

        private void SearchTrf(object? sender, DataGridViewCellEventArgs e)
        {
            try
            {
                XmlOptionData sqldata = main.sqlList["SearchTrf"];
                DynamicParameters parameters = new DynamicParameters();
                string cquery = sqldata.Sql;

                string trf_Code = (sender as DataGridView).CurrentRow.Cells["TRF_CODE"].Value.ToString();

                parameters.Add("@TRF_CODE", trf_Code);

                new WinformUtils(main).ShowSqltoDGV(transList_CstHist.DgvData, cquery, parameters, main.correntConnectionStringSetting);
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void SearchCstInfo(object? sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string cstId = (sender as DataGridView).CurrentRow.Cells["CSTID"].Value.ToString();
                string errMsg = string.Empty;
                new WinformUtils(main).SearchCstInfo(transList_CstInfo.DgvData, cstId, ref errMsg);
                //XmlOptionData sqldata = main.sqlList["SearchCstInfo"];
                //DynamicParameters parameters = new DynamicParameters();
                //string cquery = sqldata.Sql;

                //string cstId = (sender as DataGridView).CurrentRow.Cells["CSTID"].Value.ToString();

                //parameters.Add("@CSTID", cstId);

                //new WinformUtils(main).ShowSqltoDGV(transList_CstInfo.DgvData, cquery, parameters, main.correntConnectionStringSetting);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            int interval = tAbt_TransList_Search.Interval;

            if (currNum == 0)
            {
                SearchTransportReq();
                currNum = tAbt_TransList_Search.Interval;
            }
            else
            {
                tAbt_TransList_Search.bt_Search.Text = currNum.ToString("000") + "\nStop";
                currNum--;
            }
        }

        internal void Btn_Click()
        {
            if (tAbt_TransList_Search.IsUseTimer)
            {
                tAbt_TransList_Search.timer.Interval = 1000;
                if (tAbt_TransList_Search.timer.Enabled)
                {
                    tAbt_TransList_Search.timer.Stop();
                    tAbt_TransList_Search.bt_Search.Text = "Search";
                }
                else
                {
                    tAbt_TransList_Search.timer.Start();
                }
            }
            else
            {
                SearchTransportReq();
            }
        }

        /// <summary>
        /// 현재 반송 현황을 보여주는 함수
        /// </summary>
        private void SearchTransportReq()
        {
            Dictionary<string, string> paramaterDic = new Dictionary<string, string>();

            paramaterDic.Add("CMD_STAT_CODE_LIST", MakeCmdStatCodeList());
            paramaterDic.Add("LaneId", lAtb_TransList_LaneId.Tb_Text);
            paramaterDic.Add("CSTSTAT", $"{cb_Cststat.SelectedIndex}");
            paramaterDic.Add("CstId", lAtb_TransList_CarrierId.Tb_Text);
            paramaterDic.Add("ReqPortId", lAtb_TransList_ReqEqp.Tb_Text);
            paramaterDic.Add("ToPortId", lAtb_TransList_ToEqp.Tb_Text);
            paramaterDic.Add("isFaulty", $"{ckb_IsFaulty.Checked}");

            paramaterDic.Add("StartDate", $"'{lAdtp_TransList_StartDate.Dtp_Value.ToString("yyyy-MM-dd")}'");
            paramaterDic.Add("EndDate", $"'{lAdtp_TransList_EndDate.Dtp_Value.ToString("yyyy-MM-dd")}'");

            new WinformUtils(main).ExcuteSql(paramaterDic, transList_dgvReq.DgvData, main.correntConnectionStringSetting, MethodBase.GetCurrentMethod().Name);

        }
    }
}
