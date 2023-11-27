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
    public partial class UWC_LabelAndDateTimePicker : UserControl
    {
        public string lb_Txt
        {
            get { return lb_txt.Text; }
            set { lb_txt.Text = value; }
        }

        public DateTime dtp_Value
        {
            get { return dtp_date.Value; }
            set { dtp_date.Value = value; }
        }

        public UWC_LabelAndDateTimePicker()
        {
            InitializeComponent();
        }
    }
}
