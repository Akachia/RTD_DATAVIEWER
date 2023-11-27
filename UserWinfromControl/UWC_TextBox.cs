using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserWinfromControl
{
    public partial class UWC_TextBox : UserControl
    {
        public string Text
        {
            get { return rtb_LogBox.Text; }
            set { rtb_LogBox.Text = value; }
        }

        public void ApeendText(string sql, Dictionary<string, string> parameters)
        {
            rtb_LogBox.Text += "\n-------------------------SQL START---------------------------";

            rtb_LogBox.Text += sql;

            rtb_LogBox.Text += "\n-------------------------SQL PARAMETER START---------------------------";

            foreach (var item in parameters)
            {
                rtb_LogBox.Text += $"\n Key : {item.Key} , Value : {item.Value}";
            }

            rtb_LogBox.Text += "\n-------------------------SQL PARAMETER END---------------------------";

            rtb_LogBox.Text += "\n-------------------------SQL END---------------------------";

        }

        public void ApeendText(string sql, string parameterKey, string parameterValue)
        {
            rtb_LogBox.Text += "\n-------------------------SQL START---------------------------";

            rtb_LogBox.Text += sql;

            rtb_LogBox.Text += "\n-------------------------SQL PARAMETER START---------------------------";

            rtb_LogBox.Text += $"\n Key : {parameterKey} , Value : {parameterValue}";

            rtb_LogBox.Text += "\n-------------------------SQL PARAMETER END---------------------------";

            rtb_LogBox.Text += "\n-------------------------SQL END---------------------------";


        }

        public void ApeendText(string sql)
        {
            rtb_LogBox.Text += "\n-------------------------SQL START---------------------------";

            rtb_LogBox.Text += sql;

            rtb_LogBox.Text += "\n-------------------------SQL END---------------------------";
        }


        public UWC_TextBox()
        {
            InitializeComponent();
        }
    }
}
