using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserWinfromControl
{
    public partial class UWC_LabelAndTextBox : UserControl
    {
        AutoCompleteStringCollection source = new AutoCompleteStringCollection();

        public string Lb_Text
        {
            get
            { return this.lb_Txt.Text; }
            set { this.lb_Txt.Text = value; }

        }

        public string Tb_Text
        {
            get
            { return this.textBox.Text; }
            set { this.textBox.Text = value; }

        }

        public UWC_LabelAndTextBox()
        {
            InitializeComponent();
            this.textBox.AutoCompleteCustomSource = source;
            this.textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }

        private void textBox_Click(object sender, EventArgs e)
        {
            lb_Txt.Visible = false;
            lb_Txt.Enabled = false;
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox.Text == string.Empty)
            {
                lb_Txt.Visible = true;
                lb_Txt.Enabled = true;
            }
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            if (this.textBox.Text == string.Empty)
            {
                lb_Txt.Visible = true;
                lb_Txt.Enabled = true;
            }
            else
            {
                if (!source.Contains(this.textBox.Text))
                {
                    source.Add(this.textBox.Text);
                }

                lb_Txt.Visible = false;
                lb_Txt.Enabled = false;
            }
        }
    }
}
