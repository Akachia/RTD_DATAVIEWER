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

namespace RTD_DataViewer.View
{
    public partial class BizRuleErr : UserControl
    {
        #region Variable
        MainViewer main;
        string errMsg;
        DefaultSqlData bizRuleErrData = null;
        Dictionary<string, string> paramaterDic;
        #endregion

        #region Construction
        public BizRuleErr(MainViewer main)
        {
            InitializeComponent();
            this.main = main;
            dgv_BizRuleError.DgvData.CellClick += DgvData_CellClick; ;
        }


        #endregion

        #region Events for UI Controls
        private void bt_Search_Click(object sender, EventArgs e)
        {
            SearchBizRuleError();
        }

        private void DgvData_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string exct_Location = (sender as DataGridView).CurrentRow.Cells["EXCT_LOCATION"].Value.ToString();
                string dataSet = (sender as DataGridView).CurrentRow.Cells["DATASET"].Value.ToString();

                utb_BizFlowText.Text = exct_Location;
                if (dataSet != string.Empty)
                {
                    utb_XmlMssageText.Text = System.Xml.Linq.XDocument.Parse(dataSet).ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }

        }
        #endregion

        #region Utilities for Ui

        #endregion

        #region Assign SqlData to DataGrid view functuons Section 

        public void SearchBizRuleError()
        {
            paramaterDic = new Dictionary<string, string>();
            string methodName = MethodBase.GetCurrentMethod().Name;

            paramaterDic.Add("StartDate", $"{lAdtp_StartTime.MakeNowDateStringAndSetting()}");
            paramaterDic.Add("EndDate", $"{lAdtp_EndTime.MakeNowDateStringAndSetting()}");
            paramaterDic.Add("ErrorText", $"{lAtb_ErrorText.Tb_Text}");
            paramaterDic.Add("BizRuleID", $"{lAtb_EqptId.Tb_Text}");

            try
            {
                if (bizRuleErrData == null)
                {
                    bizRuleErrData = new DefaultSqlData(paramaterDic, main.sqlList[methodName], main.correntConnectionStringSetting);
                    dgv_BizRuleError.DgvData.DataSource = bizRuleErrData.ExcuteSql();
                }
                else
                {
                    dgv_BizRuleError.DgvData.DataSource = bizRuleErrData.ExcuteSql(paramaterDic, main.sqlList[methodName], main.correntConnectionStringSetting);
                }

                if (bizRuleErrData.ErrMsg == string.Empty)
                {
                    main.AppendLog(bizRuleErrData.SqlStr);
                    new WinformUtils().DataGridView_Coloring(dgv_BizRuleError.DgvData, main.sqlList[methodName]);
                }
                else
                {
                    MessageBox.Show($"{bizRuleErrData.ErrMsg} : {methodName}");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} : {methodName}");
            }
        }

        #endregion
    }
}
