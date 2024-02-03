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
    public partial class RollSituation : UserControl
    {
        MainViewer main;
        public RollSituation(MainViewer main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void RollCurrentSituation()
        {
            WinformUtils winformUtils = new WinformUtils(main);
            Dictionary<string, string> paramaterDic = new Dictionary<string, string>();
            try
            {
                // paramaterDic.Add("REQ_SEQNO", $"{req_SeqNo}");

                winformUtils.ExcuteSql(paramaterDic, dgw_RollCurrentSituation, main.correntConnectionStringSetting, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex) { MessageBox.Show($"{ex.Message} : RollCurrentSituation"); }
        }

        private void bt_RollSituationSearch_Click(object sender, EventArgs e)
        {
            RollCurrentSituation();
        }
    }


}
