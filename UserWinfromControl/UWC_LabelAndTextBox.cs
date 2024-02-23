using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserWinfromControl
{
    public partial class UWC_LabelAndTextBox : UserControl
    {
        AutoCompleteStringCollection source = new AutoCompleteStringCollection();

        string variableName = string.Empty;

        public string VariableName
        {
            get { return variableName; }
            set { variableName = value; }
        }

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
            this.textBox.Multiline = true;

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

        public string TextToCarrierListByRex(string carrierText)
        {
            string carrierIds = string.Empty;
            Regex regex_Form = new(@"(TKA[E|D][0-9]{6})");
            Regex regex_Elec = new(@"([[B|E][B|X][A|E][E|O][C|A|R][A|S]\d{4})");

            MatchCollection matches_Form = regex_Form.Matches(carrierText);
            MatchCollection matches_Elec = regex_Elec.Matches(carrierText);

            if (matches_Form.Count > 0)
            {
                foreach (Match s in matches_Form)
                {
                    if (carrierIds.Equals(string.Empty))
                    {
                        carrierIds += @$"'{s.Value}'";
                    }
                    else
                    {
                        carrierIds += @$",'{s.Value}'";
                    }
                }
            }
            if (matches_Elec.Count > 0)
            {
                foreach (Match s in matches_Elec)
                {
                    if (carrierIds.Equals(string.Empty))
                    {
                        carrierIds += @$"'{s.Value}'";
                    }
                    else
                    {
                        carrierIds += @$",'{s.Value}'";
                    }
                }
            }

            if (matches_Elec.Count == 0 && matches_Form.Count == 0)
            {
                if (carrierText == string.Empty)
                {
                    return carrierText;
                }
                else 
                { 
                    return CustomUtills.CustomUtill.LikeStringMaskingByBoth(carrierText); 
                }
                
            }

            return carrierIds;
        }

        private string MakeCmdStatCodeList()
        {
            string CmdStatCodeList = string.Empty;


            return CmdStatCodeList;
        }


        private void textBox_Enter(object sender, EventArgs e)
        {
            lb_Txt.Visible = false;
            lb_Txt.Enabled = false;
        }

        private void textBox_MouseEnter(object sender, EventArgs e)
        {
            lb_Txt.Visible = false;
            lb_Txt.Enabled = false;
        }

        private void textBox_MouseHover(object sender, EventArgs e)
        {
            lb_Txt.Visible = false;
            lb_Txt.Enabled = false;
        }

        private void textBox_MouseLeave(object sender, EventArgs e)
        {
            if (this.textBox.Text == string.Empty)
            {
                lb_Txt.Visible = true;
                lb_Txt.Enabled = true;
            }
        }
    }
}
