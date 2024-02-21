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
    public partial class RollCurrentSituation : UserControl
    {
        MainViewer main;
        public RollCurrentSituation(MainViewer main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void SearchRollCurrentSituation()
        {
            WinformUtils winformUtils = new WinformUtils(main);
            Dictionary<string, string> paramaterDic = new Dictionary<string, string>();
            string methodName = MethodBase.GetCurrentMethod().Name;
            try
            {
                // paramaterDic.Add("REQ_SEQNO", $"{req_SeqNo}");

                winformUtils.ExcuteSql(paramaterDic, dgw_RollCurrentSituation, main.correntConnectionStringSetting, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex) { MessageBox.Show($"{ex.Message} : {methodName}"); }
        }

        private void bt_RollSituationSearch_Click(object sender, EventArgs e)
        {
            SearchRollCurrentSituation();
        }
    }


}
