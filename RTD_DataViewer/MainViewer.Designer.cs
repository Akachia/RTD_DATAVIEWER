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
            tAbt_ReqInfo_Search = new UserWinfromControl.UWC_TimerAndBtn();
            lAtb_ReqInfo_RuleText = new UserWinfromControl.UWC_LabelAndTextBox();
            lAtb_ReqInfo_ReqEqp = new UserWinfromControl.UWC_LabelAndTextBox();
            lAtb_ReqInfo_Cstid = new UserWinfromControl.UWC_LabelAndTextBox();
            lAdtp_ReqInfo_StartDate = new UserWinfromControl.UWC_LabelAndDateTimePicker();
            lAdtp_ReqInfo_EndDate = new UserWinfromControl.UWC_LabelAndDateTimePicker();
            tp_TransportList = new TabPage();
            tableLayoutPanel5 = new TableLayoutPanel();
            cb_Cststat = new ComboBox();
            ckb_IsValidTransfer = new CheckBox();
            ckb_IsAbnormal = new CheckBox();
            ckb_IsExceptDelete = new CheckBox();
            ckb_IsFaulty = new CheckBox();
            lAdtp_TransList_StartDate = new UserWinfromControl.UWC_LabelAndDateTimePicker();
            lAdtp_TransList_EndDate = new UserWinfromControl.UWC_LabelAndDateTimePicker();
            tAbt_TransList_Search = new UserWinfromControl.UWC_TimerAndBtn();
            lAtb_TransList_CarrierId = new UserWinfromControl.UWC_LabelAndTextBox();
            lAtb_TransList_ReqEqp = new UserWinfromControl.UWC_LabelAndTextBox();
            lAtb_TransList_LaneId = new UserWinfromControl.UWC_LabelAndTextBox();
            lAtb_TransList_ToEqp = new UserWinfromControl.UWC_LabelAndTextBox();
            transList_dgvReq = new UserWinfromControl.UWC_DataGridView();
            transList_CstHist = new UserWinfromControl.UWC_DataGridView();
            tc_LogBox = new TabPage();
            tableLayoutPanel3 = new TableLayoutPanel();
            uwC_TextBox1 = new UserWinfromControl.UWC_TextBox();
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
            tableLayoutPanel4.Controls.Add(tAbt_ReqInfo_Search, 7, 0);
            tableLayoutPanel4.Controls.Add(lAtb_ReqInfo_RuleText, 6, 0);
            tableLayoutPanel4.Controls.Add(lAtb_ReqInfo_ReqEqp, 6, 1);
            tableLayoutPanel4.Controls.Add(lAtb_ReqInfo_Cstid, 5, 0);
            tableLayoutPanel4.Controls.Add(lAdtp_ReqInfo_StartDate, 4, 0);
            tableLayoutPanel4.Controls.Add(lAdtp_ReqInfo_EndDate, 4, 1);
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
            // tAbt_ReqInfo_Search
            // 
            tAbt_ReqInfo_Search.Dock = DockStyle.Fill;
            tAbt_ReqInfo_Search.Interval = 20;
            tAbt_ReqInfo_Search.IsUseTimer = false;
            tAbt_ReqInfo_Search.Location = new Point(1229, 3);
            tAbt_ReqInfo_Search.Name = "tAbt_ReqInfo_Search";
            tableLayoutPanel4.SetRowSpan(tAbt_ReqInfo_Search, 2);
            tAbt_ReqInfo_Search.Size = new Size(182, 54);
            tAbt_ReqInfo_Search.TabIndex = 2;
            // 
            // lAtb_ReqInfo_RuleText
            // 
            lAtb_ReqInfo_RuleText.Dock = DockStyle.Fill;
            lAtb_ReqInfo_RuleText.Lb_Text = "요청 설비";
            lAtb_ReqInfo_RuleText.Location = new Point(1060, 3);
            lAtb_ReqInfo_RuleText.Name = "lAtb_ReqInfo_RuleText";
            lAtb_ReqInfo_RuleText.Size = new Size(163, 24);
            lAtb_ReqInfo_RuleText.TabIndex = 3;
            lAtb_ReqInfo_RuleText.Tb_Text = "";
            // 
            // lAtb_ReqInfo_ReqEqp
            // 
            lAtb_ReqInfo_ReqEqp.Dock = DockStyle.Fill;
            lAtb_ReqInfo_ReqEqp.Lb_Text = "Rule Name";
            lAtb_ReqInfo_ReqEqp.Location = new Point(1060, 33);
            lAtb_ReqInfo_ReqEqp.Name = "lAtb_ReqInfo_ReqEqp";
            lAtb_ReqInfo_ReqEqp.Size = new Size(163, 24);
            lAtb_ReqInfo_ReqEqp.TabIndex = 4;
            lAtb_ReqInfo_ReqEqp.Tb_Text = "";
            // 
            // lAtb_ReqInfo_Cstid
            // 
            lAtb_ReqInfo_Cstid.Dock = DockStyle.Fill;
            lAtb_ReqInfo_Cstid.Lb_Text = "Carrier ID";
            lAtb_ReqInfo_Cstid.Location = new Point(884, 3);
            lAtb_ReqInfo_Cstid.Name = "lAtb_ReqInfo_Cstid";
            lAtb_ReqInfo_Cstid.Size = new Size(170, 24);
            lAtb_ReqInfo_Cstid.TabIndex = 5;
            lAtb_ReqInfo_Cstid.Tb_Text = "";
            // 
            // lAdtp_ReqInfo_StartDate
            // 
            lAdtp_ReqInfo_StartDate.Dock = DockStyle.Fill;
            lAdtp_ReqInfo_StartDate.Dtp_Value = new DateTime(2023, 11, 27, 9, 43, 47, 506);
            lAdtp_ReqInfo_StartDate.Lb_Text = "시작 시간 ";
            lAdtp_ReqInfo_StartDate.Location = new Point(602, 3);
            lAdtp_ReqInfo_StartDate.Name = "lAdtp_ReqInfo_StartDate";
            lAdtp_ReqInfo_StartDate.Size = new Size(276, 24);
            lAdtp_ReqInfo_StartDate.TabIndex = 6;
            // 
            // lAdtp_ReqInfo_EndDate
            // 
            lAdtp_ReqInfo_EndDate.Dock = DockStyle.Fill;
            lAdtp_ReqInfo_EndDate.Dtp_Value = new DateTime(2023, 11, 27, 9, 43, 50, 385);
            lAdtp_ReqInfo_EndDate.Lb_Text = "종료 시간";
            lAdtp_ReqInfo_EndDate.Location = new Point(602, 33);
            lAdtp_ReqInfo_EndDate.Name = "lAdtp_ReqInfo_EndDate";
            lAdtp_ReqInfo_EndDate.Size = new Size(276, 24);
            lAdtp_ReqInfo_EndDate.TabIndex = 7;
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
            tableLayoutPanel5.Controls.Add(cb_Cststat, 4, 0);
            tableLayoutPanel5.Controls.Add(ckb_IsValidTransfer, 2, 0);
            tableLayoutPanel5.Controls.Add(ckb_IsAbnormal, 3, 0);
            tableLayoutPanel5.Controls.Add(ckb_IsExceptDelete, 2, 1);
            tableLayoutPanel5.Controls.Add(ckb_IsFaulty, 3, 1);
            tableLayoutPanel5.Controls.Add(lAdtp_TransList_StartDate, 1, 0);
            tableLayoutPanel5.Controls.Add(lAdtp_TransList_EndDate, 1, 1);
            tableLayoutPanel5.Controls.Add(tAbt_TransList_Search, 7, 0);
            tableLayoutPanel5.Controls.Add(lAtb_TransList_CarrierId, 5, 0);
            tableLayoutPanel5.Controls.Add(lAtb_TransList_ReqEqp, 6, 0);
            tableLayoutPanel5.Controls.Add(lAtb_TransList_LaneId, 5, 1);
            tableLayoutPanel5.Controls.Add(lAtb_TransList_ToEqp, 6, 1);
            tableLayoutPanel5.Controls.Add(transList_dgvReq, 0, 2);
            tableLayoutPanel5.Controls.Add(transList_CstHist, 6, 2);
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
            // cb_Cststat
            // 
            cb_Cststat.Dock = DockStyle.Fill;
            cb_Cststat.FormattingEnabled = true;
            cb_Cststat.Items.AddRange(new object[] { "모두 : ALL", "공트레이 : E", "실트레이 : U" });
            cb_Cststat.Location = new Point(779, 3);
            cb_Cststat.Name = "cb_Cststat";
            cb_Cststat.Size = new Size(107, 23);
            cb_Cststat.TabIndex = 7;
            // 
            // ckb_IsValidTransfer
            // 
            ckb_IsValidTransfer.AutoSize = true;
            ckb_IsValidTransfer.Checked = true;
            ckb_IsValidTransfer.CheckState = CheckState.Checked;
            ckb_IsValidTransfer.Dock = DockStyle.Fill;
            ckb_IsValidTransfer.Location = new Point(553, 3);
            ckb_IsValidTransfer.Name = "ckb_IsValidTransfer";
            ckb_IsValidTransfer.RightToLeft = RightToLeft.Yes;
            ckb_IsValidTransfer.Size = new Size(107, 24);
            ckb_IsValidTransfer.TabIndex = 8;
            ckb_IsValidTransfer.Text = "유효반송";
            ckb_IsValidTransfer.UseVisualStyleBackColor = true;
            // 
            // ckb_IsAbnormal
            // 
            ckb_IsAbnormal.AutoSize = true;
            ckb_IsAbnormal.Dock = DockStyle.Fill;
            ckb_IsAbnormal.Location = new Point(666, 3);
            ckb_IsAbnormal.Name = "ckb_IsAbnormal";
            ckb_IsAbnormal.RightToLeft = RightToLeft.Yes;
            ckb_IsAbnormal.Size = new Size(107, 24);
            ckb_IsAbnormal.TabIndex = 9;
            ckb_IsAbnormal.Text = "Abnormal";
            ckb_IsAbnormal.UseVisualStyleBackColor = true;
            // 
            // ckb_IsExceptDelete
            // 
            ckb_IsExceptDelete.AutoSize = true;
            ckb_IsExceptDelete.Checked = true;
            ckb_IsExceptDelete.CheckState = CheckState.Checked;
            ckb_IsExceptDelete.Dock = DockStyle.Fill;
            ckb_IsExceptDelete.Location = new Point(553, 33);
            ckb_IsExceptDelete.Name = "ckb_IsExceptDelete";
            ckb_IsExceptDelete.RightToLeft = RightToLeft.Yes;
            ckb_IsExceptDelete.Size = new Size(107, 24);
            ckb_IsExceptDelete.TabIndex = 10;
            ckb_IsExceptDelete.Text = "DELETE 제외";
            ckb_IsExceptDelete.UseVisualStyleBackColor = true;
            // 
            // ckb_IsFaulty
            // 
            ckb_IsFaulty.AutoSize = true;
            ckb_IsFaulty.Dock = DockStyle.Fill;
            ckb_IsFaulty.Location = new Point(666, 33);
            ckb_IsFaulty.Name = "ckb_IsFaulty";
            ckb_IsFaulty.RightToLeft = RightToLeft.Yes;
            ckb_IsFaulty.Size = new Size(107, 24);
            ckb_IsFaulty.TabIndex = 11;
            ckb_IsFaulty.Text = "불량적재";
            ckb_IsFaulty.UseVisualStyleBackColor = true;
            // 
            // lAdtp_TransList_StartDate
            // 
            lAdtp_TransList_StartDate.Dock = DockStyle.Fill;
            lAdtp_TransList_StartDate.Dtp_Value = new DateTime(2023, 11, 27, 10, 20, 54, 324);
            lAdtp_TransList_StartDate.Lb_Text = "시작 시간";
            lAdtp_TransList_StartDate.Location = new Point(271, 3);
            lAdtp_TransList_StartDate.Name = "lAdtp_TransList_StartDate";
            lAdtp_TransList_StartDate.Size = new Size(276, 24);
            lAdtp_TransList_StartDate.TabIndex = 12;
            // 
            // lAdtp_TransList_EndDate
            // 
            lAdtp_TransList_EndDate.Dock = DockStyle.Fill;
            lAdtp_TransList_EndDate.Dtp_Value = new DateTime(2023, 11, 27, 10, 20, 56, 692);
            lAdtp_TransList_EndDate.Lb_Text = "종료 시간";
            lAdtp_TransList_EndDate.Location = new Point(271, 33);
            lAdtp_TransList_EndDate.Name = "lAdtp_TransList_EndDate";
            lAdtp_TransList_EndDate.Size = new Size(276, 24);
            lAdtp_TransList_EndDate.TabIndex = 13;
            // 
            // tAbt_TransList_Search
            // 
            tAbt_TransList_Search.Dock = DockStyle.Fill;
            tAbt_TransList_Search.Interval = 20;
            tAbt_TransList_Search.IsUseTimer = false;
            tAbt_TransList_Search.Location = new Point(1230, 3);
            tAbt_TransList_Search.Name = "tAbt_TransList_Search";
            tableLayoutPanel5.SetRowSpan(tAbt_TransList_Search, 2);
            tAbt_TransList_Search.Size = new Size(181, 54);
            tAbt_TransList_Search.TabIndex = 14;
            // 
            // lAtb_TransList_CarrierId
            // 
            lAtb_TransList_CarrierId.Dock = DockStyle.Fill;
            lAtb_TransList_CarrierId.Lb_Text = "Carrier ID";
            lAtb_TransList_CarrierId.Location = new Point(892, 3);
            lAtb_TransList_CarrierId.Name = "lAtb_TransList_CarrierId";
            lAtb_TransList_CarrierId.Size = new Size(163, 24);
            lAtb_TransList_CarrierId.TabIndex = 15;
            lAtb_TransList_CarrierId.Tb_Text = "";
            // 
            // lAtb_TransList_ReqEqp
            // 
            lAtb_TransList_ReqEqp.Dock = DockStyle.Fill;
            lAtb_TransList_ReqEqp.Lb_Text = "출발지 설비";
            lAtb_TransList_ReqEqp.Location = new Point(1061, 3);
            lAtb_TransList_ReqEqp.Name = "lAtb_TransList_ReqEqp";
            lAtb_TransList_ReqEqp.Size = new Size(163, 24);
            lAtb_TransList_ReqEqp.TabIndex = 16;
            lAtb_TransList_ReqEqp.Tb_Text = "";
            // 
            // lAtb_TransList_LaneId
            // 
            lAtb_TransList_LaneId.Dock = DockStyle.Fill;
            lAtb_TransList_LaneId.Lb_Text = "Lane ID";
            lAtb_TransList_LaneId.Location = new Point(892, 33);
            lAtb_TransList_LaneId.Name = "lAtb_TransList_LaneId";
            lAtb_TransList_LaneId.Size = new Size(163, 24);
            lAtb_TransList_LaneId.TabIndex = 17;
            lAtb_TransList_LaneId.Tb_Text = "";
            // 
            // lAtb_TransList_ToEqp
            // 
            lAtb_TransList_ToEqp.Dock = DockStyle.Fill;
            lAtb_TransList_ToEqp.Lb_Text = "목적지 설비";
            lAtb_TransList_ToEqp.Location = new Point(1061, 33);
            lAtb_TransList_ToEqp.Name = "lAtb_TransList_ToEqp";
            lAtb_TransList_ToEqp.Size = new Size(163, 24);
            lAtb_TransList_ToEqp.TabIndex = 18;
            lAtb_TransList_ToEqp.Tb_Text = "";
            // 
            // transList_dgvReq
            // 
            tableLayoutPanel5.SetColumnSpan(transList_dgvReq, 6);
            transList_dgvReq.Dock = DockStyle.Fill;
            transList_dgvReq.Location = new Point(3, 63);
            transList_dgvReq.Name = "transList_dgvReq";
            tableLayoutPanel5.SetRowSpan(transList_dgvReq, 2);
            transList_dgvReq.Size = new Size(1052, 531);
            transList_dgvReq.TabIndex = 19;
            // 
            // transList_CstHist
            // 
            tableLayoutPanel5.SetColumnSpan(transList_CstHist, 2);
            transList_CstHist.Dock = DockStyle.Fill;
            transList_CstHist.Location = new Point(1061, 63);
            transList_CstHist.Name = "transList_CstHist";
            tableLayoutPanel5.SetRowSpan(transList_CstHist, 2);
            transList_CstHist.Size = new Size(350, 531);
            transList_CstHist.TabIndex = 20;
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
            tableLayoutPanel3.Controls.Add(uwC_TextBox1, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(1414, 597);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // uwC_TextBox1
            // 
            uwC_TextBox1.Dock = DockStyle.Fill;
            uwC_TextBox1.Location = new Point(3, 3);
            uwC_TextBox1.Name = "uwC_TextBox1";
            tableLayoutPanel3.SetRowSpan(uwC_TextBox1, 2);
            uwC_TextBox1.Size = new Size(1093, 591);
            uwC_TextBox1.TabIndex = 0;
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
        internal Label lb_ServerIP;
        internal Label lb_ServerName;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_ReqInfo_Cstid;
        internal UserWinfromControl.UWC_LabelAndDateTimePicker lAdtp_ReqInfo_StartDate;
        internal UserWinfromControl.UWC_LabelAndDateTimePicker lAdtp_ReqInfo_EndDate;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_ReqInfo_RuleText;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_ReqInfo_ReqEqp;
        internal TableLayoutPanel tableLayoutPanel4;
        internal UserWinfromControl.UWC_TimerAndBtn tAbt_ReqInfo_Search;
        private Button bt_DataRefresh;
        private TableLayoutPanel tableLayoutPanel5;
        private UserWinfromControl.UWC_DataGridView uwC_DataGridView2;
        internal ComboBox cb_Cststat;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_TransList_CarrierId;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_TransList_LaneId;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_TransList_ReqEqp;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_TransList_ToEqp;
        internal UserWinfromControl.UWC_LabelAndDateTimePicker lAdtp_TransList_StartDate;
        internal UserWinfromControl.UWC_LabelAndDateTimePicker lAdtp_TransList_EndDate;
        internal CheckBox ckb_IsValidTransfer;
        internal CheckBox ckb_IsAbnormal;
        internal CheckBox ckb_IsExceptDelete;
        internal CheckBox ckb_IsFaulty;
        internal UserWinfromControl.UWC_TimerAndBtn tAbt_TransList_Search;
        internal UserWinfromControl.UWC_DataGridView transList_dgvCstHist;
        internal UserWinfromControl.UWC_DataGridView reqInfo_dgvReq;
        internal UserWinfromControl.UWC_DataGridView reqInfo_DgvCarrier;
        internal UserWinfromControl.UWC_DataGridView transList_CstHist;
        internal UserWinfromControl.UWC_DataGridView transList_dgvReq;
        internal UserWinfromControl.UWC_TextBox uwC_TextBox1;
    }
}
