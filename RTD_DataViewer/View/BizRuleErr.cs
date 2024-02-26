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
        DefaultSqlData bizRuleErrData = null;
        WinformUtils? winformUtils = null;
        List<Control>? variableControls = new List<Control>();
        #endregion

        #region Construction
        public BizRuleErr(MainViewer main)
        {
            InitializeComponent();
            dgv_BizRuleError.DgvData.CellClick += DgvData_CellClick;

            foreach (Control control in this.Controls[0].Controls) {
                if (control is UserControl)
                {
                    variableControls.Add(control);
                }
            }

            winformUtils = new(main);
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
            try
            {
                Dictionary<string, string> paramaterDic = winformUtils.MakeParamaterDic(variableControls);
                string methodName = MethodBase.GetCurrentMethod().Name;
                bizRuleErrData =
                    winformUtils.ShowDgv
                    (
                        methodName,
                        dgv_BizRuleError,
                        bizRuleErrData,
                        paramaterDic
                    ) as DefaultSqlData;

                //다른 정보 화면 클리어 처리
            }
            catch (Exception ex)
            {
                dgv_BizRuleError.DgvData.DataSource = null;
                MessageBox.Show(ex.Message);
            }
        }

        #endregion
    }
}
