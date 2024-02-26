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
    public partial class UWC_CheckListBox : UserControl
    {
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

        public CheckedListBox.ObjectCollection Item
        {
            get => checkedListBox1.Items;
        }

        public CheckedListBox.CheckedItemCollection CheckedItem
        {
            get => checkedListBox1.CheckedItems;
        }

        public string CheckedString
        {
            get => MakeCheckString();
        }

        public UWC_CheckListBox()
        {
            InitializeComponent();
        }

        private string MakeCheckString()
        {
            string CmdStatCodeList = string.Empty;

            foreach (var item in this.checkedListBox1.CheckedItems)
            {
                if (CmdStatCodeList == string.Empty)
                {
                    CmdStatCodeList += @$"'{item}'";
                }
                else
                {
                    CmdStatCodeList += @$",'{item}'";
                }
            }

            return CmdStatCodeList;
        }
    }
}
