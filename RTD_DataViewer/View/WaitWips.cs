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
    public partial class WaitWips : UserControl
    {
        MainViewer main;
        public WaitWips(MainViewer main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void SearchWaitingWips(string req_SeqNo)
        {
            WinformUtils winformUtils = new WinformUtils(main);
            Dictionary<string, string> paramaterDic = new Dictionary<string, string>();
            try
            {
                //paramaterDic.Add("REQ_SEQNO", $"{req_SeqNo}");

                winformUtils.ExcuteSql(paramaterDic, watingWips.DgvData, main.correntConnectionStringSetting, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex) { MessageBox.Show($"{ex.Message} : SearchTrfInfo"); }
        }




        private void bt_Search_Click(object sender, EventArgs e)
        {
            SearchWaitingWips("");
        }
    }
}

