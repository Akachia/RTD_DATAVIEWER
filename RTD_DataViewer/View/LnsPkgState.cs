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
    public partial class LnsPkgState : UserControl
    {
        MainViewer mainViewer;

        public LnsPkgState(MainViewer mainViewer)
        {
            InitializeComponent();
            this.mainViewer = mainViewer;
        }

        private void bt_LnsPkgSearch_Click(object sender, EventArgs e)
        {
            SearchLnsPkgLot();
            SearchLnsPkgEqp();
        }

        private void SearchLnsPkgLot()
        {
            try
            {
                XmlOptionData sqldata = mainViewer.sqlList["SearchLnsPkgLot"];
                Dictionary<string, string> parameterDic = new Dictionary<string, string>();
                string cquery = sqldata.sql;
                var parameters = new DynamicParameters();
                //WHERE INSDTTM BETWEEN '" + txtFrom.Text + "' AND '" + txtTo.Text + "'

                new WinformUtils().ShowSqltoDGV(this.dgv_LnsPkgLot.DgvData, cquery, parameters, mainViewer.correntConnectionStringSetting);

                mainViewer.utb_RtdDataViewerLog.ApeendText(cquery);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} : SearchLnsPkgLot");
            }
        }
        private void SearchLnsPkgEqp()
        {
            try
            {
                XmlOptionData sqldata = mainViewer.sqlList["SearchLnsPkgEqp"];
                Dictionary<string, string> parameterDic = new Dictionary<string, string>();
                string cquery = sqldata.sql;
                var parameters = new DynamicParameters();
                //WHERE INSDTTM BETWEEN '" + txtFrom.Text + "' AND '" + txtTo.Text + "'

                new WinformUtils().ShowSqltoDGV(this.dgv_lnsPkgEqp.DgvData, cquery, parameters, mainViewer.correntConnectionStringSetting);

                mainViewer.utb_RtdDataViewerLog.ApeendText(cquery);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} : SearchLnsPkgLot");
            }
        }
    }



}
