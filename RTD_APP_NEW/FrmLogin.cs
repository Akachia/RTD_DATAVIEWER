using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTD_APP_NEW
{
    /// <summary>
    /// Made by - Chulho Jeong - April 20, 2023
    /// </summary>
    public partial class FrmLogin : Form
    {
        private string LastLoginFileName;
        private string serverBox;
        private string[] serverItem;
        public string cstr;
        public string logincstr;
        public string[] arylogincstr;
        public string[] aryDS;
        public string[] aryIC;
        public string[] aryAREA;
        public string[] aryPLANT;
        public string manuDS;
        public string manuIC;
        public string manuAREA;
        public string manuPLANT;
        public FrmLogin(string LastLoginFileName)
        {
            InitializeComponent();
            this.LastLoginFileName = LastLoginFileName;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader(LastLoginFileName))
            {
                while ((serverBox = sr.ReadLine()) != null)
                {
                    serverItem = serverBox.Split(';');
                    cmbServer.Items.Add(serverItem[1].Split('=')[1]);
                }
            }
            cmbServer.Items.RemoveAt(12); //Delete last login log 
            chkmanual.Checked = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (chkmanual.Checked != true)
            {
                using (StreamReader sr = new StreamReader(LastLoginFileName))
                {
                    while ((serverBox = sr.ReadLine()) != null)
                    {
                        if (serverBox.Contains(cmbServer.SelectedItem as string))
                        {
                            logincstr = serverBox;
                        }
                    }
                }
                // Update last login log
                string[] serverlines = File.ReadAllLines(LastLoginFileName);
                serverlines[serverlines.Length - 1] = logincstr;
                File.WriteAllLines(LastLoginFileName, serverlines);
                // Create parameter
                arylogincstr = logincstr.Split(';');
                aryDS = arylogincstr[0].Split('=');
                aryIC = arylogincstr[1].Split('=');
                aryAREA = arylogincstr[4].Split('=');
                aryPLANT = arylogincstr[5].Split('=');
                // Input global variable
                cstr = $"{arylogincstr[0]};{arylogincstr[1]};{arylogincstr[2]};{arylogincstr[3]}";
            }
            else
            {
                cstr =  $"Data Source={txtIP.Text}; Initial catalog={txtCATALOG.Text}; User ID={txtID.Text}; Password={txtPW.Text}; Area ID={txtAREAID.Text}; Plant ID={txtPLANTID.Text}";
                logincstr = "Manual";
                manuDS = txtIP.Text;
                manuIC = txtCATALOG.Text;
                manuAREA = txtAREAID.Text;
                manuPLANT = txtPLANTID.Text;
            }
            this.Close();
        }

        private void chkmanual_CheckedChanged(object sender, EventArgs e)
        {
            if(chkmanual.Checked != true)
            {
                pnlManual.Visible = true;
            }
            else
            {
                pnlManual.Visible = false;
            }
        }
    }
}
