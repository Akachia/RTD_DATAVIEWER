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
            reqATransfer_dgvReq = new TabControl();
            tp_ReqInfomation = new TabPage();
            tp_TransportList = new TabPage();
            tp_ReqAndTransfer = new TabPage();
            tp_CstHist = new TabPage();
            tp_EqpState = new TabPage();
            tableLayoutPanel8 = new TableLayoutPanel();
            bt_EqpState_Search = new Button();
            cb_EqpState_EqpGroupList = new ComboBox();
            label1 = new Label();
            eqpState_DgvEqpList = new UserWinfromControl.UWC_DataGridView();
            eqpState_DgvEqpPortList = new UserWinfromControl.UWC_DataGridView();
            tp_LogBox = new TabPage();
            tp_LnsPkgState = new TabPage();
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
            ss_selectionCount = new StatusStrip();
            ColumnCount = new ToolStripStatusLabel();
            RowCount = new ToolStripStatusLabel();
            tp_CstInfo = new TabPage();
            tableLayoutPanel1.SuspendLayout();
            reqATransfer_dgvReq.SuspendLayout();
            tp_EqpState.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            ss_selectionCount.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(reqATransfer_dgvReq, 0, 1);
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
            // reqATransfer_dgvReq
            // 
            reqATransfer_dgvReq.Controls.Add(tp_ReqInfomation);
            reqATransfer_dgvReq.Controls.Add(tp_TransportList);
            reqATransfer_dgvReq.Controls.Add(tp_ReqAndTransfer);
            reqATransfer_dgvReq.Controls.Add(tp_CstInfo);
            reqATransfer_dgvReq.Controls.Add(tp_CstHist);
            reqATransfer_dgvReq.Controls.Add(tp_EqpState);
            reqATransfer_dgvReq.Controls.Add(tp_LnsPkgState);
            reqATransfer_dgvReq.Controls.Add(tp_LogBox);
            reqATransfer_dgvReq.Dock = DockStyle.Fill;
            reqATransfer_dgvReq.Location = new Point(3, 43);
            reqATransfer_dgvReq.Name = "reqATransfer_dgvReq";
            reqATransfer_dgvReq.SelectedIndex = 0;
            reqATransfer_dgvReq.Size = new Size(1428, 631);
            reqATransfer_dgvReq.TabIndex = 0;
            // 
            // tp_ReqInfomation
            // 
            tp_ReqInfomation.Location = new Point(4, 24);
            tp_ReqInfomation.Name = "tp_ReqInfomation";
            tp_ReqInfomation.Padding = new Padding(3);
            tp_ReqInfomation.Size = new Size(1420, 603);
            tp_ReqInfomation.TabIndex = 0;
            tp_ReqInfomation.Text = "요청정보";
            tp_ReqInfomation.UseVisualStyleBackColor = true;
            // 
            // tp_TransportList
            // 
            tp_TransportList.Location = new Point(4, 24);
            tp_TransportList.Name = "tp_TransportList";
            tp_TransportList.Padding = new Padding(3);
            tp_TransportList.Size = new Size(1420, 603);
            tp_TransportList.TabIndex = 1;
            tp_TransportList.Text = "반송목록";
            tp_TransportList.UseVisualStyleBackColor = true;
            // 
            // tp_ReqAndTransfer
            // 
            tp_ReqAndTransfer.Location = new Point(4, 24);
            tp_ReqAndTransfer.Name = "tp_ReqAndTransfer";
            tp_ReqAndTransfer.Padding = new Padding(3);
            tp_ReqAndTransfer.Size = new Size(1420, 603);
            tp_ReqAndTransfer.TabIndex = 3;
            tp_ReqAndTransfer.Text = "요청/반송 이력";
            tp_ReqAndTransfer.UseVisualStyleBackColor = true;
            // 
            // tp_CstHist
            // 
            tp_CstHist.Location = new Point(4, 24);
            tp_CstHist.Name = "tp_CstHist";
            tp_CstHist.Padding = new Padding(3);
            tp_CstHist.Size = new Size(1420, 603);
            tp_CstHist.TabIndex = 4;
            tp_CstHist.Text = "케리어 이력";
            tp_CstHist.UseVisualStyleBackColor = true;
            // 
            // tp_EqpState
            // 
            tp_EqpState.Controls.Add(tableLayoutPanel8);
            tp_EqpState.Location = new Point(4, 24);
            tp_EqpState.Name = "tp_EqpState";
            tp_EqpState.Padding = new Padding(3);
            tp_EqpState.Size = new Size(1420, 603);
            tp_EqpState.TabIndex = 5;
            tp_EqpState.Text = "설비 상태";
            tp_EqpState.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 10;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel8.Controls.Add(bt_EqpState_Search, 7, 0);
            tableLayoutPanel8.Controls.Add(cb_EqpState_EqpGroupList, 6, 0);
            tableLayoutPanel8.Controls.Add(label1, 5, 0);
            tableLayoutPanel8.Controls.Add(eqpState_DgvEqpList, 0, 1);
            tableLayoutPanel8.Controls.Add(eqpState_DgvEqpPortList, 8, 1);
            tableLayoutPanel8.Dock = DockStyle.Fill;
            tableLayoutPanel8.Location = new Point(3, 3);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 2;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel8.Size = new Size(1414, 597);
            tableLayoutPanel8.TabIndex = 0;
            // 
            // bt_EqpState_Search
            // 
            bt_EqpState_Search.Dock = DockStyle.Fill;
            bt_EqpState_Search.Location = new Point(803, 3);
            bt_EqpState_Search.Name = "bt_EqpState_Search";
            bt_EqpState_Search.Size = new Size(107, 29);
            bt_EqpState_Search.TabIndex = 0;
            bt_EqpState_Search.Text = "Search";
            bt_EqpState_Search.UseVisualStyleBackColor = true;
            // 
            // cb_EqpState_EqpGroupList
            // 
            cb_EqpState_EqpGroupList.Dock = DockStyle.Fill;
            cb_EqpState_EqpGroupList.FormattingEnabled = true;
            cb_EqpState_EqpGroupList.Location = new Point(577, 3);
            cb_EqpState_EqpGroupList.Name = "cb_EqpState_EqpGroupList";
            cb_EqpState_EqpGroupList.Size = new Size(220, 23);
            cb_EqpState_EqpGroupList.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(479, 0);
            label1.Name = "label1";
            label1.Size = new Size(92, 35);
            label1.TabIndex = 2;
            label1.Text = "공정";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // eqpState_DgvEqpList
            // 
            tableLayoutPanel8.SetColumnSpan(eqpState_DgvEqpList, 8);
            eqpState_DgvEqpList.Dock = DockStyle.Fill;
            eqpState_DgvEqpList.Location = new Point(3, 38);
            eqpState_DgvEqpList.Name = "eqpState_DgvEqpList";
            eqpState_DgvEqpList.Size = new Size(907, 556);
            eqpState_DgvEqpList.TabIndex = 3;
            // 
            // eqpState_DgvEqpPortList
            // 
            tableLayoutPanel8.SetColumnSpan(eqpState_DgvEqpPortList, 2);
            eqpState_DgvEqpPortList.Dock = DockStyle.Fill;
            eqpState_DgvEqpPortList.Location = new Point(916, 38);
            eqpState_DgvEqpPortList.Name = "eqpState_DgvEqpPortList";
            eqpState_DgvEqpPortList.Size = new Size(495, 556);
            eqpState_DgvEqpPortList.TabIndex = 4;
            // 
            // tp_LogBox
            // 
            tp_LogBox.Location = new Point(4, 24);
            tp_LogBox.Name = "tp_LogBox";
            tp_LogBox.Padding = new Padding(3);
            tp_LogBox.Size = new Size(1420, 603);
            tp_LogBox.TabIndex = 2;
            tp_LogBox.Text = "LogBox";
            tp_LogBox.UseVisualStyleBackColor = true;
            // 
            // tp_LnsPkgState
            // 
            tp_LnsPkgState.Location = new Point(4, 24);
            tp_LnsPkgState.Name = "tp_LnsPkgState";
            tp_LnsPkgState.Padding = new Padding(3);
            tp_LnsPkgState.Size = new Size(1420, 603);
            tp_LnsPkgState.TabIndex = 6;
            tp_LnsPkgState.Text = "LnsPkgState";
            tp_LnsPkgState.UseVisualStyleBackColor = true;
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
            // ss_selectionCount
            // 
            ss_selectionCount.Items.AddRange(new ToolStripItem[] { ColumnCount, RowCount });
            ss_selectionCount.Location = new Point(0, 679);
            ss_selectionCount.Name = "ss_selectionCount";
            ss_selectionCount.Size = new Size(1434, 22);
            ss_selectionCount.TabIndex = 2;
            ss_selectionCount.Text = "statusStrip1";
            // 
            // ColumnCount
            // 
            ColumnCount.Name = "ColumnCount";
            ColumnCount.Size = new Size(121, 17);
            ColumnCount.Text = "toolStripStatusLabel1";
            // 
            // RowCount
            // 
            RowCount.Name = "RowCount";
            RowCount.Size = new Size(121, 17);
            RowCount.Text = "toolStripStatusLabel2";
            // 
            // tp_CstInfo
            // 
            tp_CstInfo.Location = new Point(4, 24);
            tp_CstInfo.Name = "tp_CstInfo";
            tp_CstInfo.Size = new Size(1420, 603);
            tp_CstInfo.TabIndex = 7;
            tp_CstInfo.Text = "tabPage1";
            tp_CstInfo.UseVisualStyleBackColor = true;
            // 
            // MainViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1434, 701);
            Controls.Add(ss_selectionCount);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainViewer";
            Text = "RTD_DataViewer v0.1";
            tableLayoutPanel1.ResumeLayout(false);
            reqATransfer_dgvReq.ResumeLayout(false);
            tp_EqpState.ResumeLayout(false);
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel8.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panel1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ss_selectionCount.ResumeLayout(false);
            ss_selectionCount.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TabControl reqATransfer_dgvReq;
        private TabPage tp_ReqInfomation;
        private TabPage tp_TransportList;
        private TableLayoutPanel tableLayoutPanel2;
        private Label lb_CurLocTime;
        private Label lb_KorTime;
        private Panel panel1;
        private TabPage tp_LogBox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private StatusStrip ss_selectionCount;
        private ToolStripStatusLabel ColumnCount;
        private TableLayoutPanel tableLayoutPanel3;
        private ComboBox cb_DBString;
        internal Label lb_ServerIP;
        internal Label lb_ServerName;
        private Button bt_DataRefresh;
        internal UserWinfromControl.UWC_DataGridView transList_dgvCstHist;
        internal UserWinfromControl.UWC_TextBox utb_RtdDataViewerLog;
        internal TabPage tp_ReqAndTransfer;
        private TabPage tp_CstHist;
        private TabPage tp_EqpState;
        private TabPage tp_LnsPkgState;
        private TableLayoutPanel tableLayoutPanel8;
        private Label label1;
        internal UserWinfromControl.UWC_DataGridView eqpState_DgvEqpList;
        internal ComboBox cb_EqpState_EqpGroupList;
        internal UserWinfromControl.UWC_DataGridView eqpState_DgvEqpPortList;
        internal Button bt_EqpState_Search;
        private UserWinfromControl.UWC_TextBox utb_RtdMessageText;
        private Button bt_beautifierJson;
        private Button bt_beautifierXml;
        private Button bt_Clear;
        private UserWinfromControl.UWC_TextBox utb_RtdEditerText;
        private Button bt_RtdEditerLogConvert;
        private Label label2;
        private Label label3;
        private ToolStripStatusLabel RowCount;
        private TabPage tp_CstInfo;
    }
}
