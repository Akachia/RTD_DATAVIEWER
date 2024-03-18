using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XmlManagement;

namespace RTD_DataViewer
{
    public partial class CarrierInfomationList : UserControl
    {
        MainViewer mainViewer;

        public CarrierInfomationList(MainViewer mainViewer)
        {
            InitializeComponent();
            this.mainViewer = mainViewer;
        }

        private void bt_LnsPkgSearch_Click(object sender, EventArgs e)
        {
            SearchLnsPkgLot();
        }

        private void SearchLnsPkgLot()
        {
            try
            {
                XmlOptionData sqldata = mainViewer.sqlList["SearchLnsPkgLot"];
                Dictionary<string, string> parameterDic = new Dictionary<string, string>();
                string cquery = sqldata.Sql;
                var parameters = new DynamicParameters();
                //WHERE INSDTTM BETWEEN '" + txtFrom.Text + "' AND '" + txtTo.Text + "'

                new WinformUtils(mainViewer).ShowSqltoDGV(this.dgv_CarrierInfomationList.DgvData, cquery, parameters, mainViewer.correntConnectionStringSetting);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} : SearchLnsPkgLot");
            }
        }
    }



}
