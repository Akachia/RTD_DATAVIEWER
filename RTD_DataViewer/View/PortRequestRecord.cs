using CustomUtills;
using Dapper;
using DBManagement;
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
    public partial class PortRequestRecord : UserControl
    {

        #region Variable
        WinformUtils? winformUtils = null;
        DefaultSqlData? searchTransportJobRecordData = null;
        DefaultSqlData? searchPortRequestRecordData = null;
        List<Control>? variableControls = new List<Control>();
        #endregion

        #region Construction
        public PortRequestRecord(MainViewer main)
        {
            InitializeComponent();

            DateTime tomorrow = DateTime.Today.AddDays(1);
            DateTime yesterday = DateTime.Today.AddDays(-1);
            
            bt_ReqATransfer_Search.Click += Bt_ReqATransfer_Search_Click;
            dtp_EndTime.Dtp_Value = tomorrow;
            dtp__StartTime.Dtp_Value = yesterday;
            dtp_EndTime.IsChecked = false;
            dtp__StartTime.IsChecked = true;

            foreach (Control control in this.Controls[0].Controls)
            {
                if (control is UserControl)
                {
                    variableControls.Add(control);
                }
            }

            dgv_PortRequestRecord.DgvData.CellClick += DgvData_CellClick;

            cb_CarrierStat.SetCstStatData();
            cb_TransportStatList.SetTransportStatCodeData();

            winformUtils = new(main);
        }
        #endregion

        #region Events for UI Controls
        private void Bt_ReqATransfer_Search_Click(object? sender, EventArgs e)
        {
            SearchPortRequestHistory();
        }
        #endregion

        #region Utilities for Ui
        private void MakeRuleResult(string ruleResult)
        {
            RuleResultCollection ruleResultCollection = new RuleResultCollection(ruleResult);

            tv_SituationOrRuleResult.Nodes.Clear();

            foreach (RuleResult rule in ruleResultCollection.RuleResults)
            {
                TreeNode rootNode = new TreeNode($"{rule.RuleName} : {rule.ResultNum}");
                rootNode.Name = rule.RuleId.ToString();
                tv_SituationOrRuleResult.Nodes.Add(rootNode);

                foreach (RuleResult childRule in rule.ChildRuleResults)
                {
                    TreeNode childNode = new TreeNode($"{childRule.RuleName} : {childRule.ResultNum}");
                    childNode.Name = childRule.RuleId.ToString();
                    rootNode.Nodes.Add(childNode);
                }
            }
        }
        #endregion

        #region Assign SqlData to DataGrid view functuons Section 
        private void DgvData_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            string ruleResult = (sender as DataGridView).CurrentRow.Cells["RTD_EXEC_LOG_CNTT"].Value.ToString();
            MakeRuleResult(ruleResult);
        }

        private void SearchPortRequestHistory()
        {
            try
            {
                Dictionary<string, string> paramaterDic = winformUtils.MakeParamaterDic(variableControls);

                string methodName = MethodBase.GetCurrentMethod().Name;
                searchPortRequestRecordData =
                    winformUtils.ShowDgv
                    (
                        methodName,
                        dgv_PortRequestRecord,
                        searchPortRequestRecordData,
                        paramaterDic
                    ) as DefaultSqlData;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

    }
}
