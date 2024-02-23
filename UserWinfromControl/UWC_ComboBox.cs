using Azure.Core;
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
    public partial class UWC_ComboBox : UserControl
    {
        string variableName = string.Empty;

        public string VariableName
        {
            get { return variableName; }
            set { variableName = value; }
        }

        public int ComboBoxSelectedIndex
        {
            get { return this.comboBox1.SelectedIndex; }
            set { this.comboBox1.SelectedIndex = value; }
        }

        public string ComboBoxSelectedItem
        {
            get { return this.comboBox1.SelectedItem.ToString(); }
            set { this.comboBox1.SelectedItem = value; }
        }

        public object DataSource
        {
            get { return this.comboBox1.DataSource; }
            set { this.comboBox1.DataSource = value; }
        }

        public ComboBox.ObjectCollection Items
        {
            get { return this.comboBox1.Items; }
        }

        public string ComboBoxText
        {
            get { return this.comboBox1.Text; }
            set { this.comboBox1.Text = value; }
        }

        public UWC_ComboBox()
        {
            InitializeComponent();
        }

        public void SetComboBoxData(List<string> strings)
        { 
            foreach (string s in strings)
            {
                this.comboBox1.Items.Add(s);
            }
        }

        public void SetCstStatData()
        {
            this.comboBox1.Items.Add("ALL");
            this.comboBox1.Items.Add("U");
            this.comboBox1.Items.Add("E");
        }

        public void SetReqStatCodeData()
        {
            this.comboBox1.Items.Add("ALL");
            this.comboBox1.Items.Add("CREATED");
            this.comboBox1.Items.Add("REQUEST");
        }

        public void SetTransportStatCodeData()
        {
            this.comboBox1.Items.Add("ALL");
            this.comboBox1.Items.Add("NORMAL_END");
            this.comboBox1.Items.Add("ABNORMAL_END");
            this.comboBox1.Items.Add("DELETE");
            this.comboBox1.Items.Add("SEND");
            this.comboBox1.Items.Add("RECEIVE");
            this.comboBox1.Items.Add("MOVING");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
