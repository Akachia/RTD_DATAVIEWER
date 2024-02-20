using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace UserWinfromControl
{
    public partial class UWC_LabelAndDateTimePicker : UserControl
    {
        string variableName = string.Empty;

        public string VariableName
        {
            get { return variableName; }
            set { variableName = value; }
        }
        public string Lb_Text
        {
            get { return cb_Text.Text; }
            set { cb_Text.Text = value; }
        }
        public bool IsChecked
        {
            get { return cb_Text.Checked; }
            set { cb_Text.Checked = value; }
        }

        public DateTime Dtp_Value
        {
            get { return dtp_date.Value; }
            set { dtp_date.Value = value; }
        }

        public UWC_LabelAndDateTimePicker()
        {
            InitializeComponent();

            this.dtp_date.Value = DateTime.Today.AddDays(-1);
        }

        public string MakeNowDateStringAndSetting(string endDate)
        {

            if (cb_Text.Checked)
            {
                endDate = Dtp_Value.ToString("yyyy-MM-dd");
            }
            else
            {
                Dtp_Value = DateTime.Now;
                endDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }

            return endDate;
        }

        public string MakeNowDateStringAndSetting()
        {
            string endDate = string.Empty;
            if (cb_Text.Checked)
            {
                endDate = Dtp_Value.ToString("yyyy-MM-dd");
            }
            else
            {
                Dtp_Value = DateTime.Now;
                endDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }

            return endDate;
        }
    }
}
