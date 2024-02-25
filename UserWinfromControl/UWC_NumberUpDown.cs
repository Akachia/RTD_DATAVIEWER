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
    public partial class UWC_NumberUpDown : UserControl
    {
        string variableName = string.Empty;

        public UWC_NumberUpDown()
        {
            InitializeComponent();
            numericUpDown.Value = 40;
            numericUpDown.Maximum = 200;
            numericUpDown.Minimum = 1;
        }

        public int Number
        {
            get => decimal.ToInt32(numericUpDown.Value);
            set => numericUpDown.Value = value;
        }

        public string VariableName
        {
            get => variableName; 
            set => variableName = value; 
        }
    }
}
