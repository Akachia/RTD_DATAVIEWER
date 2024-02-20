using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserWinfromControl
{
    public partial class UWC_DataGridView : UserControl
    {
        public DataGridView DgvData
        {
            get { return this.dgv; }
            set { this.dgv = value; }
        }

        public string Lb_Text
        {
            get => label1.Text;
            set => label1.Text = value;
        }

        public string Lb_Text2
        {
            get => label2.Text;
            set => label2.Text = value;
        }
        public UWC_DataGridView()
        {
            InitializeComponent();
        }
    }
}
