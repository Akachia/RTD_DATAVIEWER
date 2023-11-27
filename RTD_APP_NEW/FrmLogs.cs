using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTD_APP_NEW
{
    public partial class FrmLogs : Form
    {
        //private string RuleName;
        public string sLog { get; set; }

        public string RuleName { get; set; }
        public FrmLogs()
        {
            InitializeComponent();
        }

        private void FrmLogs_Load(object sender, EventArgs e)
        {
            this.Text = RuleName;
            ParseLog();
        }

        private void ParseLog()
        {
            grdLogs.Rows.Clear();

            string[] srow = sLog.Split(',');
            if(srow.Length>0)
            {
                for(int idx=0;idx<srow.Length;idx++)
                {
                    string[] scol = srow[idx].Split('|');
                    grdLogs.Rows.Add(scol);
                }
            }
        }
    }
}
