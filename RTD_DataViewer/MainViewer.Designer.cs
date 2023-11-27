namespace RTD_DataViewer
{
    partial class MainViewer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            tc_RtdDataViewer = new TabControl();
            tp_ReqInfomation = new TabPage();
            tableLayoutPanel4 = new TableLayoutPanel();
            reqInfo_dgvReq = new UserWinfromControl.UWC_DataGridView();
            reqInfo_DgvCarrier = new UserWinfromControl.UWC_DataGridView();
            lAtb_ReqInfo_Cstid = new UserWinfromControl.UWC_LabelAndTextBox();
            lAtb_ReqInfo_RuleText = new UserWinfromControl.UWC_LabelAndTextBox();
            lAdtp_ReqInfo_StartDate = new UserWinfromControl.UWC_LabelAndDateTimePicker();
            lAdtp_ReqInfo_EndDate = new UserWinfromControl.UWC_LabelAndDateTimePicker();
            lAtb_ReqInfo_ReqEqp = new UserWinfromControl.UWC_LabelAndTextBox();
            tAbt_ReqInfo_Search = new UserWinfromControl.UWC_TimerAndBtn();
            tp_TransportList = new TabPage();
            tableLayoutPanel5 = new TableLayoutPanel();
            uwC_TimerAndBtn1 = new UserWinfromControl.UWC_TimerAndBtn();
            uwC_LabelAndTextBox1 = new UserWinfromControl.UWC_LabelAndTextBox();
            uwC_LabelAndTextBox2 = new UserWinfromControl.UWC_LabelAndTextBox();
            uwC_LabelAndTextBox3 = new UserWinfromControl.UWC_LabelAndTextBox();
            uwC_LabelAndTextBox4 = new UserWinfromControl.UWC_LabelAndTextBox();
            uwC_LabelAndDateTimePicker1 = new UserWinfromControl.UWC_LabelAndDateTimePicker();
            uwC_LabelAndDateTimePicker2 = new UserWinfromControl.UWC_LabelAndDateTimePicker();
            comboBox1 = new ComboBox();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            uwC_DataGridView2 = new UserWinfromControl.UWC_DataGridView();
            tc_LogBox = new TabPage();
            tableLayoutPanel3 = new TableLayoutPanel();
            uwC_TextBox2 = new UserWinfromControl.UWC_TextBox();
            uwC_DataGridView1 = new UserWinfromControl.UWC_DataGridView();
            tableLayoutPanel2 = new TableLayoutPanel();
            lb_ServerIP = new Label();
            lb_ServerName = new Label();
            lb_CurLocTime = new Label();
            lb_KorTime = new Label();
            panel1 = new Panel();
            bt_DataRefresh = new Button();
            cb_DBString = new ComboBox();
            menuStrip1 = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            uwC_DataGridView3 = new UserWinfromControl.UWC_DataGridView();
            tableLayoutPanel1.SuspendLayout();
            tc_RtdDataViewer.SuspendLayout();
            tp_ReqInfomation.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tp_TransportList.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tc_LogBox.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tc_RtdDataViewer, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 24);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1434, 677);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tc_RtdDataViewer
            // 
            tc_RtdDataViewer.Controls.Add(tp_ReqInfomation);
            tc_RtdDataViewer.Controls.Add(tp_TransportList);
            tc_RtdDataViewer.Controls.Add(tc_LogBox);
            tc_RtdDataViewer.Dock = DockStyle.Fill;
            tc_RtdDataViewer.Location = new Point(3, 43);
            tc_RtdDataViewer.Name = "tc_RtdDataViewer";
            tc_RtdDataViewer.SelectedIndex = 0;
            tc_RtdDataViewer.Size = new Size(1428, 631);
            tc_RtdDataViewer.TabIndex = 0;
            // 
            // tp_ReqInfomation
            // 
            tp_ReqInfomation.Controls.Add(tableLayoutPanel4);
            tp_ReqInfomation.Location = new Point(4, 24);
            tp_ReqInfomation.Name = "tp_ReqInfomation";
            tp_ReqInfomation.Padding = new Padding(3);
            tp_ReqInfomation.Size = new Size(1420, 603);
            tp_ReqInfomation.TabIndex = 0;
            tp_ReqInfomation.Text = "요청정보";
            tp_ReqInfomation.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 8;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13F));
            tableLayoutPanel4.Controls.Add(reqInfo_dgvReq, 0, 2);
            tableLayoutPanel4.Controls.Add(reqInfo_DgvCarrier, 0, 3);
            tableLayoutPanel4.Controls.Add(lAtb_ReqInfo_Cstid, 5, 0);
            tableLayoutPanel4.Controls.Add(lAtb_ReqInfo_RuleText, 6, 0);
            tableLayoutPanel4.Controls.Add(lAdtp_ReqInfo_StartDate, 4, 0);
            tableLayoutPanel4.Controls.Add(lAdtp_ReqInfo_EndDate, 4, 1);
            tableLayoutPanel4.Controls.Add(lAtb_ReqInfo_ReqEqp, 6, 1);
            tableLayoutPanel4.Controls.Add(tAbt_ReqInfo_Search, 7, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 4;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel4.Size = new Size(1414, 597);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // reqInfo_dgvReq
            // 
            tableLayoutPanel4.SetColumnSpan(reqInfo_dgvReq, 8);
            reqInfo_dgvReq.Dock = DockStyle.Fill;
            reqInfo_dgvReq.Location = new Point(3, 63);
            reqInfo_dgvReq.Name = "reqInfo_dgvReq";
            reqInfo_dgvReq.Size = new Size(1408, 451);
            reqInfo_dgvReq.TabIndex = 0;
            // 
            // reqInfo_DgvCarrier
            // 
            tableLayoutPanel4.SetColumnSpan(reqInfo_DgvCarrier, 8);
            reqInfo_DgvCarrier.Dock = DockStyle.Fill;
            reqInfo_DgvCarrier.Location = new Point(3, 520);
            reqInfo_DgvCarrier.Name = "reqInfo_DgvCarrier";
            reqInfo_DgvCarrier.Size = new Size(1408, 74);
            reqInfo_DgvCarrier.TabIndex = 1;
            // 
            // lAtb_ReqInfo_Cstid
            // 
            lAtb_ReqInfo_Cstid.Dock = DockStyle.Fill;
            lAtb_ReqInfo_Cstid.Location = new Point(884, 3);
            lAtb_ReqInfo_Cstid.Name = "lAtb_ReqInfo_Cstid";
            lAtb_ReqInfo_Cstid.Size = new Size(170, 24);
            lAtb_ReqInfo_Cstid.TabIndex = 3;
            // 
            // lAtb_ReqInfo_RuleText
            // 
            lAtb_ReqInfo_RuleText.Dock = DockStyle.Fill;
            lAtb_ReqInfo_RuleText.Location = new Point(1060, 3);
            lAtb_ReqInfo_RuleText.Name = "lAtb_ReqInfo_RuleText";
            lAtb_ReqInfo_RuleText.Size = new Size(163, 24);
            lAtb_ReqInfo_RuleText.TabIndex = 4;
            // 
            // lAdtp_ReqInfo_StartDate
            // 
            lAdtp_ReqInfo_StartDate.Dock = DockStyle.Fill;
            lAdtp_ReqInfo_StartDate.dtp_Value = new DateTime(2023, 11, 26, 21, 58, 21, 486);
            lAdtp_ReqInfo_StartDate.lb_Txt = "label1";
            lAdtp_ReqInfo_StartDate.Location = new Point(602, 3);
            lAdtp_ReqInfo_StartDate.Name = "lAdtp_ReqInfo_StartDate";
            lAdtp_ReqInfo_StartDate.Size = new Size(276, 24);
            lAdtp_ReqInfo_StartDate.TabIndex = 6;
            // 
            // lAdtp_ReqInfo_EndDate
            // 
            lAdtp_ReqInfo_EndDate.Dock = DockStyle.Fill;
            lAdtp_ReqInfo_EndDate.dtp_Value = new DateTime(2023, 11, 26, 21, 58, 24, 67);
            lAdtp_ReqInfo_EndDate.lb_Txt = "label1";
            lAdtp_ReqInfo_EndDate.Location = new Point(602, 33);
            lAdtp_ReqInfo_EndDate.Name = "lAdtp_ReqInfo_EndDate";
            lAdtp_ReqInfo_EndDate.Size = new Size(276, 24);
            lAdtp_ReqInfo_EndDate.TabIndex = 7;
            // 
            // lAtb_ReqInfo_ReqEqp
            // 
            lAtb_ReqInfo_ReqEqp.Dock = DockStyle.Fill;
            lAtb_ReqInfo_ReqEqp.Location = new Point(1060, 33);
            lAtb_ReqInfo_ReqEqp.Name = "lAtb_ReqInfo_ReqEqp";
            lAtb_ReqInfo_ReqEqp.Size = new Size(163, 24);
            lAtb_ReqInfo_ReqEqp.TabIndex = 5;
            // 
            // tAbt_ReqInfo_Search
            // 
            tAbt_ReqInfo_Search.Dock = DockStyle.Fill;
            tAbt_ReqInfo_Search.Interval = 20;
            tAbt_ReqInfo_Search.IsUseTimer = false;
            tAbt_ReqInfo_Search.Location = new Point(1229, 3);
            tAbt_ReqInfo_Search.Name = "tAbt_ReqInfo_Search";
            tableLayoutPanel4.SetRowSpan(tAbt_ReqInfo_Search, 2);
            tAbt_ReqInfo_Search.Size = new Size(182, 54);
            tAbt_ReqInfo_Search.TabIndex = 8;
            // 
            // tp_TransportList
            // 
            tp_TransportList.Controls.Add(tableLayoutPanel5);
            tp_TransportList.Location = new Point(4, 24);
            tp_TransportList.Name = "tp_TransportList";
            tp_TransportList.Padding = new Padding(3);
            tp_TransportList.Size = new Size(1420, 603);
            tp_TransportList.TabIndex = 1;
            tp_TransportList.Text = "반송목록";
            tp_TransportList.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 8;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13F));
            tableLayoutPanel5.Controls.Add(uwC_TimerAndBtn1, 7, 0);
            tableLayoutPanel5.Controls.Add(uwC_LabelAndTextBox1, 5, 0);
            tableLayoutPanel5.Controls.Add(uwC_LabelAndTextBox2, 5, 1);
            tableLayoutPanel5.Controls.Add(uwC_LabelAndTextBox3, 6, 0);
            tableLayoutPanel5.Controls.Add(uwC_LabelAndTextBox4, 6, 1);
            tableLayoutPanel5.Controls.Add(uwC_LabelAndDateTimePicker1, 1, 0);
            tableLayoutPanel5.Controls.Add(uwC_LabelAndDateTimePicker2, 1, 1);
            tableLayoutPanel5.Controls.Add(comboBox1, 4, 0);
            tableLayoutPanel5.Controls.Add(checkBox1, 2, 0);
            tableLayoutPanel5.Controls.Add(checkBox2, 3, 0);
            tableLayoutPanel5.Controls.Add(checkBox3, 2, 1);
            tableLayoutPanel5.Controls.Add(checkBox4, 3, 1);
            tableLayoutPanel5.Controls.Add(uwC_DataGridView2, 0, 2);
            tableLayoutPanel5.Controls.Add(uwC_DataGridView3, 6, 2);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 3);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 4;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel5.Size = new Size(1414, 597);
            tableLayoutPanel5.TabIndex = 0;
            // 
            // uwC_TimerAndBtn1
            // 
            uwC_TimerAndBtn1.Dock = DockStyle.Fill;
            uwC_TimerAndBtn1.Interval = 20;
            uwC_TimerAndBtn1.IsUseTimer = false;
            uwC_TimerAndBtn1.Location = new Point(1230, 3);
            uwC_TimerAndBtn1.Name = "uwC_TimerAndBtn1";
            tableLayoutPanel5.SetRowSpan(uwC_TimerAndBtn1, 2);
            uwC_TimerAndBtn1.Size = new Size(181, 54);
            uwC_TimerAndBtn1.TabIndex = 0;
            // 
            // uwC_LabelAndTextBox1
            // 
            uwC_LabelAndTextBox1.Dock = DockStyle.Fill;
            uwC_LabelAndTextBox1.Location = new Point(892, 3);
            uwC_LabelAndTextBox1.Name = "uwC_LabelAndTextBox1";
            uwC_LabelAndTextBox1.Size = new Size(163, 24);
            uwC_LabelAndTextBox1.TabIndex = 1;
            // 
            // uwC_LabelAndTextBox2
            // 
            uwC_LabelAndTextBox2.Dock = DockStyle.Fill;
            uwC_LabelAndTextBox2.Location = new Point(892, 33);
            uwC_LabelAndTextBox2.Name = "uwC_LabelAndTextBox2";
            uwC_LabelAndTextBox2.Size = new Size(163, 24);
            uwC_LabelAndTextBox2.TabIndex = 2;
            // 
            // uwC_LabelAndTextBox3
            // 
            uwC_LabelAndTextBox3.Dock = DockStyle.Fill;
            uwC_LabelAndTextBox3.Location = new Point(1061, 3);
            uwC_LabelAndTextBox3.Name = "uwC_LabelAndTextBox3";
            uwC_LabelAndTextBox3.Size = new Size(163, 24);
            uwC_LabelAndTextBox3.TabIndex = 3;
            // 
            // uwC_LabelAndTextBox4
            // 
            uwC_LabelAndTextBox4.Dock = DockStyle.Fill;
            uwC_LabelAndTextBox4.Location = new Point(1061, 33);
            uwC_LabelAndTextBox4.Name = "uwC_LabelAndTextBox4";
            uwC_LabelAndTextBox4.Size = new Size(163, 24);
            uwC_LabelAndTextBox4.TabIndex = 4;
            // 
            // uwC_LabelAndDateTimePicker1
            // 
            uwC_LabelAndDateTimePicker1.Dock = DockStyle.Fill;
            uwC_LabelAndDateTimePicker1.dtp_Value = new DateTime(2023, 11, 26, 23, 22, 9, 939);
            uwC_LabelAndDateTimePicker1.lb_Txt = "label1";
            uwC_LabelAndDateTimePicker1.Location = new Point(271, 3);
            uwC_LabelAndDateTimePicker1.Name = "uwC_LabelAndDateTimePicker1";
            uwC_LabelAndDateTimePicker1.Size = new Size(276, 24);
            uwC_LabelAndDateTimePicker1.TabIndex = 5;
            // 
            // uwC_LabelAndDateTimePicker2
            // 
            uwC_LabelAndDateTimePicker2.Dock = DockStyle.Fill;
            uwC_LabelAndDateTimePicker2.dtp_Value = new DateTime(2023, 11, 26, 23, 22, 12, 582);
            uwC_LabelAndDateTimePicker2.lb_Txt = "label1";
            uwC_LabelAndDateTimePicker2.Location = new Point(271, 33);
            uwC_LabelAndDateTimePicker2.Name = "uwC_LabelAndDateTimePicker2";
            uwC_LabelAndDateTimePicker2.Size = new Size(276, 24);
            uwC_LabelAndDateTimePicker2.TabIndex = 6;
            // 
            // comboBox1
            // 
            comboBox1.Dock = DockStyle.Fill;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "모두 : ALL", "공트레이 : E", "실트레이 : U" });
            comboBox1.Location = new Point(779, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(107, 23);
            comboBox1.TabIndex = 7;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Dock = DockStyle.Fill;
            checkBox1.Location = new Point(553, 3);
            checkBox1.Name = "checkBox1";
            checkBox1.RightToLeft = RightToLeft.Yes;
            checkBox1.Size = new Size(107, 24);
            checkBox1.TabIndex = 8;
            checkBox1.Text = "유효반송";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Dock = DockStyle.Fill;
            checkBox2.Location = new Point(666, 3);
            checkBox2.Name = "checkBox2";
            checkBox2.RightToLeft = RightToLeft.Yes;
            checkBox2.Size = new Size(107, 24);
            checkBox2.TabIndex = 9;
            checkBox2.Text = "Abnormal";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Checked = true;
            checkBox3.CheckState = CheckState.Checked;
            checkBox3.Dock = DockStyle.Fill;
            checkBox3.Location = new Point(553, 33);
            checkBox3.Name = "checkBox3";
            checkBox3.RightToLeft = RightToLeft.Yes;
            checkBox3.Size = new Size(107, 24);
            checkBox3.TabIndex = 10;
            checkBox3.Text = "DELETE 제외";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Dock = DockStyle.Fill;
            checkBox4.Location = new Point(666, 33);
            checkBox4.Name = "checkBox4";
            checkBox4.RightToLeft = RightToLeft.Yes;
            checkBox4.Size = new Size(107, 24);
            checkBox4.TabIndex = 11;
            checkBox4.Text = "불량적재";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // uwC_DataGridView2
            // 
            tableLayoutPanel5.SetColumnSpan(uwC_DataGridView2, 6);
            uwC_DataGridView2.Dock = DockStyle.Fill;
            uwC_DataGridView2.Location = new Point(3, 63);
            uwC_DataGridView2.Name = "uwC_DataGridView2";
            tableLayoutPanel5.SetRowSpan(uwC_DataGridView2, 2);
            uwC_DataGridView2.Size = new Size(1052, 531);
            uwC_DataGridView2.TabIndex = 12;
            // 
            // tc_LogBox
            // 
            tc_LogBox.Controls.Add(tableLayoutPanel3);
            tc_LogBox.Location = new Point(4, 24);
            tc_LogBox.Name = "tc_LogBox";
            tc_LogBox.Padding = new Padding(3);
            tc_LogBox.Size = new Size(1420, 603);
            tc_LogBox.TabIndex = 2;
            tc_LogBox.Text = "LogBox";
            tc_LogBox.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 77.77778F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.2222214F));
            tableLayoutPanel3.Controls.Add(uwC_TextBox2, 0, 0);
            tableLayoutPanel3.Controls.Add(uwC_DataGridView1, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(1414, 597);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // uwC_TextBox2
            // 
            uwC_TextBox2.Dock = DockStyle.Fill;
            uwC_TextBox2.Location = new Point(3, 3);
            uwC_TextBox2.Name = "uwC_TextBox2";
            tableLayoutPanel3.SetRowSpan(uwC_TextBox2, 2);
            uwC_TextBox2.Size = new Size(1093, 591);
            uwC_TextBox2.TabIndex = 0;
            // 
            // uwC_DataGridView1
            // 
            uwC_DataGridView1.Dock = DockStyle.Fill;
            uwC_DataGridView1.Location = new Point(1102, 3);
            uwC_DataGridView1.Name = "uwC_DataGridView1";
            uwC_DataGridView1.Size = new Size(309, 292);
            uwC_DataGridView1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 6;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.5F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.5F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13F));
            tableLayoutPanel2.Controls.Add(lb_ServerIP, 4, 0);
            tableLayoutPanel2.Controls.Add(lb_ServerName, 4, 1);
            tableLayoutPanel2.Controls.Add(lb_CurLocTime, 0, 0);
            tableLayoutPanel2.Controls.Add(lb_KorTime, 1, 0);
            tableLayoutPanel2.Controls.Add(panel1, 2, 0);
            tableLayoutPanel2.Controls.Add(cb_DBString, 5, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(1428, 34);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // lb_ServerIP
            // 
            lb_ServerIP.AutoSize = true;
            lb_ServerIP.Dock = DockStyle.Fill;
            lb_ServerIP.Location = new Point(1058, 0);
            lb_ServerIP.Name = "lb_ServerIP";
            lb_ServerIP.Size = new Size(179, 17);
            lb_ServerIP.TabIndex = 0;
            lb_ServerIP.Text = "ServerIP";
            // 
            // lb_ServerName
            // 
            lb_ServerName.AutoSize = true;
            lb_ServerName.Dock = DockStyle.Fill;
            lb_ServerName.Location = new Point(1058, 17);
            lb_ServerName.Name = "lb_ServerName";
            lb_ServerName.Size = new Size(179, 17);
            lb_ServerName.TabIndex = 1;
            lb_ServerName.Text = "ServerName";
            // 
            // lb_CurLocTime
            // 
            lb_CurLocTime.AutoSize = true;
            lb_CurLocTime.Dock = DockStyle.Fill;
            lb_CurLocTime.Location = new Point(3, 0);
            lb_CurLocTime.Name = "lb_CurLocTime";
            tableLayoutPanel2.SetRowSpan(lb_CurLocTime, 2);
            lb_CurLocTime.Size = new Size(315, 34);
            lb_CurLocTime.TabIndex = 2;
            lb_CurLocTime.Text = "CurrentLocatuonTime";
            lb_CurLocTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lb_KorTime
            // 
            lb_KorTime.AutoSize = true;
            lb_KorTime.Dock = DockStyle.Fill;
            lb_KorTime.Location = new Point(324, 0);
            lb_KorTime.Name = "lb_KorTime";
            tableLayoutPanel2.SetRowSpan(lb_KorTime, 2);
            lb_KorTime.Size = new Size(315, 34);
            lb_KorTime.TabIndex = 3;
            lb_KorTime.Text = "KoreaTime";
            lb_KorTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(bt_DataRefresh);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(645, 3);
            panel1.Name = "panel1";
            tableLayoutPanel2.SetRowSpan(panel1, 2);
            panel1.Size = new Size(208, 28);
            panel1.TabIndex = 4;
            // 
            // bt_DataRefresh
            // 
            bt_DataRefresh.Dock = DockStyle.Left;
            bt_DataRefresh.Location = new Point(0, 0);
            bt_DataRefresh.Name = "bt_DataRefresh";
            bt_DataRefresh.Size = new Size(86, 28);
            bt_DataRefresh.TabIndex = 0;
            bt_DataRefresh.Text = "Data Refresh";
            bt_DataRefresh.UseVisualStyleBackColor = true;
            bt_DataRefresh.Click += bt_DataRefresh_Click;
            // 
            // cb_DBString
            // 
            cb_DBString.Dock = DockStyle.Fill;
            cb_DBString.FormattingEnabled = true;
            cb_DBString.Location = new Point(1243, 3);
            cb_DBString.Name = "cb_DBString";
            tableLayoutPanel2.SetRowSpan(cb_DBString, 2);
            cb_DBString.Size = new Size(182, 23);
            cb_DBString.TabIndex = 5;
            cb_DBString.TextChanged += cb_DBString_TextChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1434, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(50, 20);
            menuToolStripMenuItem.Text = "Menu";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 679);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1434, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(121, 17);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // uwC_DataGridView3
            // 
            tableLayoutPanel5.SetColumnSpan(uwC_DataGridView3, 2);
            uwC_DataGridView3.Dock = DockStyle.Fill;
            uwC_DataGridView3.Location = new Point(1061, 63);
            uwC_DataGridView3.Name = "uwC_DataGridView3";
            tableLayoutPanel5.SetRowSpan(uwC_DataGridView3, 2);
            uwC_DataGridView3.Size = new Size(350, 531);
            uwC_DataGridView3.TabIndex = 13;
            // 
            // MainViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1434, 701);
            Controls.Add(statusStrip1);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainViewer";
            Text = "RTD_DataViewer v0.1";
            tableLayoutPanel1.ResumeLayout(false);
            tc_RtdDataViewer.ResumeLayout(false);
            tp_ReqInfomation.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tp_TransportList.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            tc_LogBox.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panel1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TabControl tc_RtdDataViewer;
        private TabPage tp_ReqInfomation;
        private TabPage tp_TransportList;
        private TableLayoutPanel tableLayoutPanel2;
        private Label lb_CurLocTime;
        private Label lb_KorTime;
        private Panel panel1;
        private TabPage tc_LogBox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private TableLayoutPanel tableLayoutPanel3;
        private ComboBox cb_DBString;
        public UserWinfromControl.UWC_DataGridView reqInfo_dgvReq;
        public UserWinfromControl.UWC_DataGridView reqInfo_DgvCarrier;
        internal Label lb_ServerIP;
        internal Label lb_ServerName;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_ReqInfo_Cstid;
        internal UserWinfromControl.UWC_LabelAndDateTimePicker lAdtp_ReqInfo_StartDate;
        internal UserWinfromControl.UWC_LabelAndDateTimePicker lAdtp_ReqInfo_EndDate;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_ReqInfo_RuleText;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_ReqInfo_ReqEqp;
        internal TableLayoutPanel tableLayoutPanel4;
        internal UserWinfromControl.UWC_TimerAndBtn tAbt_ReqInfo_Search;
        internal UserWinfromControl.UWC_TextBox uwC_TextBox2;
        private UserWinfromControl.UWC_DataGridView uwC_DataGridView1;
        private Button bt_DataRefresh;
        private TableLayoutPanel tableLayoutPanel5;
        private UserWinfromControl.UWC_TimerAndBtn uwC_TimerAndBtn1;
        private UserWinfromControl.UWC_LabelAndTextBox uwC_LabelAndTextBox1;
        private UserWinfromControl.UWC_LabelAndTextBox uwC_LabelAndTextBox2;
        private UserWinfromControl.UWC_LabelAndTextBox uwC_LabelAndTextBox3;
        private UserWinfromControl.UWC_LabelAndTextBox uwC_LabelAndTextBox4;
        private UserWinfromControl.UWC_LabelAndDateTimePicker uwC_LabelAndDateTimePicker1;
        private UserWinfromControl.UWC_LabelAndDateTimePicker uwC_LabelAndDateTimePicker2;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private UserWinfromControl.UWC_DataGridView uwC_DataGridView2;
        internal ComboBox comboBox1;
        private UserWinfromControl.UWC_DataGridView uwC_DataGridView3;
    }
}
