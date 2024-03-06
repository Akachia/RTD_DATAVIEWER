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
    public partial class UWC_ListBox : UserControl
    {
        public ListBox ListBox
        { 
            get => this.listBox; 
        }

        object dataObject = new();
        string variableName = string.Empty;
        public string VariableName
        {
            get => variableName;
            set => variableName = value;
        }
        public string Lb_Text
        {
            get => label1.Text;
            set => label1.Text = value;
        }

        public object DataObject
        {
            get => dataObject;
            set => dataObject = value;
        }

        public ListBox.ObjectCollection Item
        {
            get => listBox.Items;
        }

        public ListBox.SelectedObjectCollection SelectedItems
        {
            get => listBox.SelectedItems;
        }

        public UWC_ListBox()
        {
            InitializeComponent();
        }

        public void listBox_Click(object sender, EventArgs e)
        {

        }
    }
}
