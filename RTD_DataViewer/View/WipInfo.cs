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
    public partial class WipInfo : UserControl
    {
        MainViewer main;
        public WipInfo(MainViewer main)
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
                paramaterDic.Add("REQ_SEQNO", $"{req_SeqNo}");

                // winformUtils.ExcuteSql(paramaterDic, reqInfo_dgvReq_TrfInfo.DgvData, main.correntConnectionStringSetting, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex) { MessageBox.Show($"{ex.Message} : SearchTrfInfo"); }
        }
    }


}
