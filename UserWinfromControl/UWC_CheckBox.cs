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
    public partial class UWC_CheckBox : UserControl
    {
        public UWC_CheckBox()
        {
            InitializeComponent();
        }

        string variableName = string.Empty;

        public string VariableName
        {
            get { return variableName; }
            set { variableName = value; }
        }

        public string CheckBoxText
        {
            get => checkBox1.Text;
            set => checkBox1.Text = value;
        }

        public string IsChecked
        {
            get => checkBox1.Checked.ToString();
        }
    }
}
