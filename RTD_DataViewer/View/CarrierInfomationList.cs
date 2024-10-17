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

namespace RTD_DataViewer
{
    public partial class CarrierInfomationList : UserControl
    {

        #region Variable
        DefaultSqlData? searchCarrierInfomationListData = null;
        WinformUtils? winformUtils = null;
        List<Control>? variableControls = new List<Control>();
        #endregion

        #region Construction
        public CarrierInfomationList(MainViewer mainViewer)
        {
            InitializeComponent();
            winformUtils = new(mainViewer);

            foreach (Control control in this.Controls[0].Controls)
            {
                if (control is UserControl)
                {
                    variableControls.Add(control);
                }
            }
        }
        #endregion

        #region Events for UI Controls
        private void bt_Search_Click(object sender, EventArgs e)
        {
            searchCarrierInfomationList();
        }
        #endregion

        #region Utilities for Ui

        #endregion

        #region Assign SqlData to DataGrid view functuons Section 
        private void searchCarrierInfomationList()
        {
            try
            {
                Dictionary<string, string> paramaterDic = winformUtils.MakeParamaterDic(variableControls);
                string methodName = MethodBase.GetCurrentMethod().Name;
                searchCarrierInfomationListData =
                    winformUtils.ShowDgv
                    (
                        methodName,
                        dgv_CarrierInfomationList,
                        searchCarrierInfomationListData,
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
