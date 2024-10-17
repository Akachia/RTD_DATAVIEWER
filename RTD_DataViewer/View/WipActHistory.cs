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
    public partial class WipActHistory : UserControl
    {
        #region Variable
        DefaultSqlData wipActHistoryData = null;
        WinformUtils? winformUtils = null;
        List<Control>? variableControls = new List<Control>();
        #endregion

        #region Construction
        public  WipActHistory(MainViewer main)
        {
            InitializeComponent();
           // dgv_BizRuleError.DgvData.CellClick += DgvData_CellClick;

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
            SearchWipActHistory();
        }

        #endregion

        #region Utilities for Ui

        #endregion

        #region Assign SqlData to DataGrid view functuons Section 

        public void SearchWipActHistory()
        {
            try
            {
                Dictionary<string, string> paramaterDic = winformUtils.MakeParamaterDic(variableControls);
                string methodName = MethodBase.GetCurrentMethod().Name;
                wipActHistoryData =
                    winformUtils.ShowDgv
                    (
                        methodName,
                        dgv_WipActHistory,
                        wipActHistoryData,
                        paramaterDic
                    ) as DefaultSqlData;

                //다른 정보 화면 클리어 처리
            }
            catch (Exception ex)
            {
                dgv_WipActHistory.DgvData.DataSource = null;
                MessageBox.Show(ex.Message);
            }
        }

        #endregion
    }
}
