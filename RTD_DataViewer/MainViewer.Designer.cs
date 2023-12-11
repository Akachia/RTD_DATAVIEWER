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
            tableLayoutPanel4 = new TableLayoutPanel();
            reqInfo_dgvReq = new UserWinfromControl.UWC_DataGridView();
            reqInfo_DgvCarrier = new UserWinfromControl.UWC_DataGridView();
            tAbt_ReqInfo_Search = new UserWinfromControl.UWC_TimerAndBtn();
            lAtb_ReqInfo_ReqEqp = new UserWinfromControl.UWC_LabelAndTextBox();
            lAtb_ReqInfo_RuleText = new UserWinfromControl.UWC_LabelAndTextBox();
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
            transList_CstInfo = new UserWinfromControl.UWC_DataGridView();
            tp_ReqAndTransfer = new TabPage();
            tableLayoutPanel6 = new TableLayoutPanel();
            bt_ReqATransfer_Search = new Button();
            lAtb_ReqATransfer_CarrierId = new UserWinfromControl.UWC_LabelAndTextBox();
            lAtb_ReqATransfer_StartPort = new UserWinfromControl.UWC_LabelAndTextBox();
            lAtb_ReqATransfer_RuleId = new UserWinfromControl.UWC_LabelAndTextBox();
            lAtb_ReqATransfer_ArrPort = new UserWinfromControl.UWC_LabelAndTextBox();
            lAdtp_ReqATransfer_StartDate = new UserWinfromControl.UWC_LabelAndDateTimePicker();
            lAdtp_ReqATransfer_EndDate = new UserWinfromControl.UWC_LabelAndDateTimePicker();
            cb_ReqATransfer_CstStat = new ComboBox();
            cb_ReqATransfer_MovingState = new ComboBox();
            ckb_IsDeleteTransfer = new CheckBox();
            reqAndTransfer_dgvReq = new UserWinfromControl.UWC_DataGridView();
            panel2 = new Panel();
            rb_TransferHist = new RadioButton();
            rb_ReqHist = new RadioButton();
            tp_CstHist = new TabPage();
            tableLayoutPanel7 = new TableLayoutPanel();
            lAdtp_CstHist_StartDate = new UserWinfromControl.UWC_LabelAndDateTimePicker();
            lAdtp_CstHist_EndDate = new UserWinfromControl.UWC_LabelAndDateTimePicker();
            lAtb_CstHist_CarrierId = new UserWinfromControl.UWC_LabelAndTextBox();
            bt_CstHist_Search = new Button();
            cstHist_Dgv = new UserWinfromControl.UWC_DataGridView();
            uwC_DataGridView3 = new UserWinfromControl.UWC_DataGridView();
            panel3 = new Panel();
            rb_IsTrayActHist = new RadioButton();
            rb_IsEventHist = new RadioButton();
            lAtb_CstHist_ToPort = new UserWinfromControl.UWC_LabelAndTextBox();
            tp_EqpState = new TabPage();
            tableLayoutPanel8 = new TableLayoutPanel();
            bt_EqpState_Search = new Button();
            cb_EqpState_EqpGroupList = new ComboBox();
            label1 = new Label();
            eqpState_DgvEqpList = new UserWinfromControl.UWC_DataGridView();
            eqpState_DgvEqpPortList = new UserWinfromControl.UWC_DataGridView();
            tc_LogBox = new TabPage();
            tableLayoutPanel3 = new TableLayoutPanel();
            uwC_TextBox1 = new UserWinfromControl.UWC_TextBox();
            uwC_TextBox2 = new UserWinfromControl.UWC_TextBox();
            bt_beautifierJson = new Button();
            bt_beautifierXml = new Button();
            tabPage1 = new TabPage();
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
            reqATransfer_dgvReq.SuspendLayout();
            tp_ReqInfomation.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tp_TransportList.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tp_ReqAndTransfer.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            panel2.SuspendLayout();
            tp_CstHist.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            panel3.SuspendLayout();
            tp_EqpState.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
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
            reqATransfer_dgvReq.Controls.Add(tp_CstHist);
            reqATransfer_dgvReq.Controls.Add(tp_EqpState);
            reqATransfer_dgvReq.Controls.Add(tc_LogBox);
            reqATransfer_dgvReq.Controls.Add(tabPage1);
            reqATransfer_dgvReq.Dock = DockStyle.Fill;
            reqATransfer_dgvReq.Location = new Point(3, 43);
            reqATransfer_dgvReq.Name = "reqATransfer_dgvReq";
            reqATransfer_dgvReq.SelectedIndex = 0;
            reqATransfer_dgvReq.Size = new Size(1428, 631);
            reqATransfer_dgvReq.TabIndex = 0;
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
            tableLayoutPanel4.Controls.Add(lAtb_ReqInfo_ReqEqp, 6, 0);
            tableLayoutPanel4.Controls.Add(lAtb_ReqInfo_RuleText, 6, 1);
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
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 110F));
            tableLayoutPanel4.Size = new Size(1414, 597);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // reqInfo_dgvReq
            // 
            tableLayoutPanel4.SetColumnSpan(reqInfo_dgvReq, 8);
            reqInfo_dgvReq.Dock = DockStyle.Fill;
            reqInfo_dgvReq.Location = new Point(3, 63);
            reqInfo_dgvReq.Name = "reqInfo_dgvReq";
            reqInfo_dgvReq.Size = new Size(1408, 421);
            reqInfo_dgvReq.TabIndex = 0;
            // 
            // reqInfo_DgvCarrier
            // 
            tableLayoutPanel4.SetColumnSpan(reqInfo_DgvCarrier, 8);
            reqInfo_DgvCarrier.Dock = DockStyle.Fill;
            reqInfo_DgvCarrier.Location = new Point(3, 490);
            reqInfo_DgvCarrier.Name = "reqInfo_DgvCarrier";
            reqInfo_DgvCarrier.Size = new Size(1408, 104);
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
            // lAtb_ReqInfo_ReqEqp
            // 
            lAtb_ReqInfo_ReqEqp.Dock = DockStyle.Fill;
            lAtb_ReqInfo_ReqEqp.Lb_Text = "요청 설비";
            lAtb_ReqInfo_ReqEqp.Location = new Point(1060, 3);
            lAtb_ReqInfo_ReqEqp.Name = "lAtb_ReqInfo_ReqEqp";
            lAtb_ReqInfo_ReqEqp.Size = new Size(163, 24);
            lAtb_ReqInfo_ReqEqp.TabIndex = 3;
            lAtb_ReqInfo_ReqEqp.Tb_Text = "";
            // 
            // lAtb_ReqInfo_RuleText
            // 
            lAtb_ReqInfo_RuleText.Dock = DockStyle.Fill;
            lAtb_ReqInfo_RuleText.Lb_Text = "Rule Name";
            lAtb_ReqInfo_RuleText.Location = new Point(1060, 33);
            lAtb_ReqInfo_RuleText.Name = "lAtb_ReqInfo_RuleText";
            lAtb_ReqInfo_RuleText.Size = new Size(163, 24);
            lAtb_ReqInfo_RuleText.TabIndex = 4;
            lAtb_ReqInfo_RuleText.Tb_Text = "";
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
            tableLayoutPanel5.Controls.Add(transList_CstInfo, 6, 3);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 3);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 4;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 110F));
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
            transList_CstHist.Size = new Size(350, 421);
            transList_CstHist.TabIndex = 20;
            // 
            // transList_CstInfo
            // 
            tableLayoutPanel5.SetColumnSpan(transList_CstInfo, 2);
            transList_CstInfo.Dock = DockStyle.Fill;
            transList_CstInfo.Location = new Point(1061, 490);
            transList_CstInfo.Name = "transList_CstInfo";
            transList_CstInfo.Size = new Size(350, 104);
            transList_CstInfo.TabIndex = 21;
            // 
            // tp_ReqAndTransfer
            // 
            tp_ReqAndTransfer.Controls.Add(tableLayoutPanel6);
            tp_ReqAndTransfer.Location = new Point(4, 24);
            tp_ReqAndTransfer.Name = "tp_ReqAndTransfer";
            tp_ReqAndTransfer.Padding = new Padding(3);
            tp_ReqAndTransfer.Size = new Size(1420, 603);
            tp_ReqAndTransfer.TabIndex = 3;
            tp_ReqAndTransfer.Text = "요청/반송 이력";
            tp_ReqAndTransfer.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 8;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
            tableLayoutPanel6.Controls.Add(bt_ReqATransfer_Search, 7, 0);
            tableLayoutPanel6.Controls.Add(lAtb_ReqATransfer_CarrierId, 4, 0);
            tableLayoutPanel6.Controls.Add(lAtb_ReqATransfer_StartPort, 5, 0);
            tableLayoutPanel6.Controls.Add(lAtb_ReqATransfer_RuleId, 4, 1);
            tableLayoutPanel6.Controls.Add(lAtb_ReqATransfer_ArrPort, 5, 1);
            tableLayoutPanel6.Controls.Add(lAdtp_ReqATransfer_StartDate, 2, 0);
            tableLayoutPanel6.Controls.Add(lAdtp_ReqATransfer_EndDate, 2, 1);
            tableLayoutPanel6.Controls.Add(cb_ReqATransfer_CstStat, 6, 0);
            tableLayoutPanel6.Controls.Add(cb_ReqATransfer_MovingState, 6, 1);
            tableLayoutPanel6.Controls.Add(ckb_IsDeleteTransfer, 1, 1);
            tableLayoutPanel6.Controls.Add(reqAndTransfer_dgvReq, 0, 2);
            tableLayoutPanel6.Controls.Add(panel2, 3, 0);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(3, 3);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 3;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.Size = new Size(1414, 597);
            tableLayoutPanel6.TabIndex = 0;
            // 
            // bt_ReqATransfer_Search
            // 
            bt_ReqATransfer_Search.Dock = DockStyle.Fill;
            bt_ReqATransfer_Search.Location = new Point(1300, 3);
            bt_ReqATransfer_Search.Name = "bt_ReqATransfer_Search";
            tableLayoutPanel6.SetRowSpan(bt_ReqATransfer_Search, 2);
            bt_ReqATransfer_Search.Size = new Size(111, 54);
            bt_ReqATransfer_Search.TabIndex = 0;
            bt_ReqATransfer_Search.Text = "Search";
            bt_ReqATransfer_Search.UseVisualStyleBackColor = true;
            // 
            // lAtb_ReqATransfer_CarrierId
            // 
            lAtb_ReqATransfer_CarrierId.Dock = DockStyle.Fill;
            lAtb_ReqATransfer_CarrierId.Lb_Text = "Carrier ID";
            lAtb_ReqATransfer_CarrierId.Location = new Point(779, 3);
            lAtb_ReqATransfer_CarrierId.Name = "lAtb_ReqATransfer_CarrierId";
            lAtb_ReqATransfer_CarrierId.Size = new Size(177, 24);
            lAtb_ReqATransfer_CarrierId.TabIndex = 1;
            lAtb_ReqATransfer_CarrierId.Tb_Text = "";
            // 
            // lAtb_ReqATransfer_StartPort
            // 
            lAtb_ReqATransfer_StartPort.Dock = DockStyle.Fill;
            lAtb_ReqATransfer_StartPort.Lb_Text = "출발 포트";
            lAtb_ReqATransfer_StartPort.Location = new Point(962, 3);
            lAtb_ReqATransfer_StartPort.Name = "lAtb_ReqATransfer_StartPort";
            lAtb_ReqATransfer_StartPort.Size = new Size(163, 24);
            lAtb_ReqATransfer_StartPort.TabIndex = 2;
            lAtb_ReqATransfer_StartPort.Tb_Text = "";
            // 
            // lAtb_ReqATransfer_RuleId
            // 
            lAtb_ReqATransfer_RuleId.Dock = DockStyle.Fill;
            lAtb_ReqATransfer_RuleId.Lb_Text = "Rule ID";
            lAtb_ReqATransfer_RuleId.Location = new Point(779, 33);
            lAtb_ReqATransfer_RuleId.Name = "lAtb_ReqATransfer_RuleId";
            lAtb_ReqATransfer_RuleId.Size = new Size(177, 24);
            lAtb_ReqATransfer_RuleId.TabIndex = 3;
            lAtb_ReqATransfer_RuleId.Tb_Text = "";
            // 
            // lAtb_ReqATransfer_ArrPort
            // 
            lAtb_ReqATransfer_ArrPort.Dock = DockStyle.Fill;
            lAtb_ReqATransfer_ArrPort.Lb_Text = "도착 포트";
            lAtb_ReqATransfer_ArrPort.Location = new Point(962, 33);
            lAtb_ReqATransfer_ArrPort.Name = "lAtb_ReqATransfer_ArrPort";
            lAtb_ReqATransfer_ArrPort.Size = new Size(163, 24);
            lAtb_ReqATransfer_ArrPort.TabIndex = 4;
            lAtb_ReqATransfer_ArrPort.Tb_Text = "";
            // 
            // lAdtp_ReqATransfer_StartDate
            // 
            lAdtp_ReqATransfer_StartDate.Dock = DockStyle.Fill;
            lAdtp_ReqATransfer_StartDate.Dtp_Value = new DateTime(2023, 11, 28, 9, 4, 55, 992);
            lAdtp_ReqATransfer_StartDate.Lb_Text = "시간 시간";
            lAdtp_ReqATransfer_StartDate.Location = new Point(384, 3);
            lAdtp_ReqATransfer_StartDate.Name = "lAdtp_ReqATransfer_StartDate";
            lAdtp_ReqATransfer_StartDate.Size = new Size(276, 24);
            lAdtp_ReqATransfer_StartDate.TabIndex = 5;
            // 
            // lAdtp_ReqATransfer_EndDate
            // 
            lAdtp_ReqATransfer_EndDate.Dock = DockStyle.Fill;
            lAdtp_ReqATransfer_EndDate.Dtp_Value = new DateTime(2023, 11, 28, 9, 4, 58, 362);
            lAdtp_ReqATransfer_EndDate.Lb_Text = "종료 시간";
            lAdtp_ReqATransfer_EndDate.Location = new Point(384, 33);
            lAdtp_ReqATransfer_EndDate.Name = "lAdtp_ReqATransfer_EndDate";
            lAdtp_ReqATransfer_EndDate.Size = new Size(276, 24);
            lAdtp_ReqATransfer_EndDate.TabIndex = 6;
            // 
            // cb_ReqATransfer_CstStat
            // 
            cb_ReqATransfer_CstStat.Dock = DockStyle.Fill;
            cb_ReqATransfer_CstStat.FormattingEnabled = true;
            cb_ReqATransfer_CstStat.Items.AddRange(new object[] { "모두 : ALL", "실트레이 : U", "공트레이 : E" });
            cb_ReqATransfer_CstStat.Location = new Point(1131, 3);
            cb_ReqATransfer_CstStat.Name = "cb_ReqATransfer_CstStat";
            cb_ReqATransfer_CstStat.Size = new Size(163, 23);
            cb_ReqATransfer_CstStat.TabIndex = 7;
            cb_ReqATransfer_CstStat.Text = "트레이 구분";
            // 
            // cb_ReqATransfer_MovingState
            // 
            cb_ReqATransfer_MovingState.Dock = DockStyle.Fill;
            cb_ReqATransfer_MovingState.FormattingEnabled = true;
            cb_ReqATransfer_MovingState.Items.AddRange(new object[] { "ALL", "DELETE", "NORMAL_END", "ABNORMAL_END", "RECEIVE", "MOVING", "SEND" });
            cb_ReqATransfer_MovingState.Location = new Point(1131, 33);
            cb_ReqATransfer_MovingState.Name = "cb_ReqATransfer_MovingState";
            cb_ReqATransfer_MovingState.Size = new Size(163, 23);
            cb_ReqATransfer_MovingState.TabIndex = 8;
            cb_ReqATransfer_MovingState.Text = "진행상태";
            // 
            // ckb_IsDeleteTransfer
            // 
            ckb_IsDeleteTransfer.AutoSize = true;
            ckb_IsDeleteTransfer.Dock = DockStyle.Fill;
            ckb_IsDeleteTransfer.Location = new Point(271, 33);
            ckb_IsDeleteTransfer.Name = "ckb_IsDeleteTransfer";
            ckb_IsDeleteTransfer.RightToLeft = RightToLeft.Yes;
            ckb_IsDeleteTransfer.Size = new Size(107, 24);
            ckb_IsDeleteTransfer.TabIndex = 11;
            ckb_IsDeleteTransfer.Text = "반송 삭제 조회";
            ckb_IsDeleteTransfer.UseVisualStyleBackColor = true;
            // 
            // reqAndTransfer_dgvReq
            // 
            tableLayoutPanel6.SetColumnSpan(reqAndTransfer_dgvReq, 8);
            reqAndTransfer_dgvReq.Dock = DockStyle.Fill;
            reqAndTransfer_dgvReq.Location = new Point(3, 63);
            reqAndTransfer_dgvReq.Name = "reqAndTransfer_dgvReq";
            reqAndTransfer_dgvReq.Size = new Size(1408, 531);
            reqAndTransfer_dgvReq.TabIndex = 12;
            // 
            // panel2
            // 
            panel2.Controls.Add(rb_TransferHist);
            panel2.Controls.Add(rb_ReqHist);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(666, 3);
            panel2.Name = "panel2";
            tableLayoutPanel6.SetRowSpan(panel2, 2);
            panel2.Size = new Size(107, 54);
            panel2.TabIndex = 13;
            // 
            // rb_TransferHist
            // 
            rb_TransferHist.AutoSize = true;
            rb_TransferHist.Checked = true;
            rb_TransferHist.Location = new Point(31, 32);
            rb_TransferHist.Name = "rb_TransferHist";
            rb_TransferHist.RightToLeft = RightToLeft.Yes;
            rb_TransferHist.Size = new Size(73, 19);
            rb_TransferHist.TabIndex = 10;
            rb_TransferHist.TabStop = true;
            rb_TransferHist.Text = "반송이력";
            rb_TransferHist.UseVisualStyleBackColor = true;
            // 
            // rb_ReqHist
            // 
            rb_ReqHist.AutoSize = true;
            rb_ReqHist.Location = new Point(31, 3);
            rb_ReqHist.Name = "rb_ReqHist";
            rb_ReqHist.RightToLeft = RightToLeft.Yes;
            rb_ReqHist.Size = new Size(73, 19);
            rb_ReqHist.TabIndex = 9;
            rb_ReqHist.TabStop = true;
            rb_ReqHist.Text = "요청이력";
            rb_ReqHist.UseVisualStyleBackColor = true;
            // 
            // tp_CstHist
            // 
            tp_CstHist.Controls.Add(tableLayoutPanel7);
            tp_CstHist.Location = new Point(4, 24);
            tp_CstHist.Name = "tp_CstHist";
            tp_CstHist.Padding = new Padding(3);
            tp_CstHist.Size = new Size(1420, 603);
            tp_CstHist.TabIndex = 4;
            tp_CstHist.Text = "케리어 이력";
            tp_CstHist.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 8;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
            tableLayoutPanel7.Controls.Add(lAdtp_CstHist_StartDate, 6, 0);
            tableLayoutPanel7.Controls.Add(lAdtp_CstHist_EndDate, 6, 1);
            tableLayoutPanel7.Controls.Add(lAtb_CstHist_CarrierId, 5, 0);
            tableLayoutPanel7.Controls.Add(bt_CstHist_Search, 7, 0);
            tableLayoutPanel7.Controls.Add(cstHist_Dgv, 0, 2);
            tableLayoutPanel7.Controls.Add(uwC_DataGridView3, 0, 3);
            tableLayoutPanel7.Controls.Add(panel3, 4, 0);
            tableLayoutPanel7.Controls.Add(lAtb_CstHist_ToPort, 5, 1);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(3, 3);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 4;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel7.Size = new Size(1414, 597);
            tableLayoutPanel7.TabIndex = 0;
            // 
            // lAdtp_CstHist_StartDate
            // 
            lAdtp_CstHist_StartDate.Dock = DockStyle.Fill;
            lAdtp_CstHist_StartDate.Dtp_Value = new DateTime(2023, 11, 30, 9, 34, 48, 775);
            lAdtp_CstHist_StartDate.Lb_Text = "시작 시간";
            lAdtp_CstHist_StartDate.Location = new Point(1047, 3);
            lAdtp_CstHist_StartDate.Name = "lAdtp_CstHist_StartDate";
            lAdtp_CstHist_StartDate.Size = new Size(248, 24);
            lAdtp_CstHist_StartDate.TabIndex = 0;
            // 
            // lAdtp_CstHist_EndDate
            // 
            lAdtp_CstHist_EndDate.Dock = DockStyle.Fill;
            lAdtp_CstHist_EndDate.Dtp_Value = new DateTime(2023, 11, 30, 9, 34, 54, 344);
            lAdtp_CstHist_EndDate.Lb_Text = "종료 시간";
            lAdtp_CstHist_EndDate.Location = new Point(1047, 33);
            lAdtp_CstHist_EndDate.Name = "lAdtp_CstHist_EndDate";
            lAdtp_CstHist_EndDate.Size = new Size(248, 24);
            lAdtp_CstHist_EndDate.TabIndex = 1;
            // 
            // lAtb_CstHist_CarrierId
            // 
            lAtb_CstHist_CarrierId.Dock = DockStyle.Fill;
            lAtb_CstHist_CarrierId.Lb_Text = "Carrier ID";
            lAtb_CstHist_CarrierId.Location = new Point(878, 3);
            lAtb_CstHist_CarrierId.Name = "lAtb_CstHist_CarrierId";
            lAtb_CstHist_CarrierId.Size = new Size(163, 24);
            lAtb_CstHist_CarrierId.TabIndex = 2;
            lAtb_CstHist_CarrierId.Tb_Text = "";
            // 
            // bt_CstHist_Search
            // 
            bt_CstHist_Search.Dock = DockStyle.Fill;
            bt_CstHist_Search.Location = new Point(1301, 3);
            bt_CstHist_Search.Name = "bt_CstHist_Search";
            tableLayoutPanel7.SetRowSpan(bt_CstHist_Search, 2);
            bt_CstHist_Search.Size = new Size(110, 54);
            bt_CstHist_Search.TabIndex = 5;
            bt_CstHist_Search.Text = "Search";
            bt_CstHist_Search.UseVisualStyleBackColor = true;
            bt_CstHist_Search.Click += bt_CstHist_Search_Click;
            // 
            // cstHist_Dgv
            // 
            tableLayoutPanel7.SetColumnSpan(cstHist_Dgv, 8);
            cstHist_Dgv.Dock = DockStyle.Fill;
            cstHist_Dgv.Location = new Point(3, 63);
            cstHist_Dgv.Name = "cstHist_Dgv";
            cstHist_Dgv.Size = new Size(1408, 451);
            cstHist_Dgv.TabIndex = 6;
            // 
            // uwC_DataGridView3
            // 
            tableLayoutPanel7.SetColumnSpan(uwC_DataGridView3, 8);
            uwC_DataGridView3.Dock = DockStyle.Fill;
            uwC_DataGridView3.Location = new Point(3, 520);
            uwC_DataGridView3.Name = "uwC_DataGridView3";
            uwC_DataGridView3.Size = new Size(1408, 74);
            uwC_DataGridView3.TabIndex = 7;
            // 
            // panel3
            // 
            panel3.Controls.Add(rb_IsTrayActHist);
            panel3.Controls.Add(rb_IsEventHist);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(709, 3);
            panel3.Name = "panel3";
            tableLayoutPanel7.SetRowSpan(panel3, 2);
            panel3.Size = new Size(163, 54);
            panel3.TabIndex = 8;
            // 
            // rb_IsTrayActHist
            // 
            rb_IsTrayActHist.AutoSize = true;
            rb_IsTrayActHist.Location = new Point(66, 3);
            rb_IsTrayActHist.Name = "rb_IsTrayActHist";
            rb_IsTrayActHist.RightToLeft = RightToLeft.Yes;
            rb_IsTrayActHist.Size = new Size(94, 19);
            rb_IsTrayActHist.TabIndex = 3;
            rb_IsTrayActHist.Text = "Tray Act Hist";
            rb_IsTrayActHist.UseVisualStyleBackColor = true;
            // 
            // rb_IsEventHist
            // 
            rb_IsEventHist.AutoSize = true;
            rb_IsEventHist.Checked = true;
            rb_IsEventHist.Location = new Point(81, 32);
            rb_IsEventHist.Name = "rb_IsEventHist";
            rb_IsEventHist.RightToLeft = RightToLeft.Yes;
            rb_IsEventHist.Size = new Size(79, 19);
            rb_IsEventHist.TabIndex = 4;
            rb_IsEventHist.TabStop = true;
            rb_IsEventHist.Text = "Event Hist";
            rb_IsEventHist.UseVisualStyleBackColor = true;
            // 
            // lAtb_CstHist_ToPort
            // 
            lAtb_CstHist_ToPort.Dock = DockStyle.Fill;
            lAtb_CstHist_ToPort.Lb_Text = "목적 포트 ID";
            lAtb_CstHist_ToPort.Location = new Point(878, 33);
            lAtb_CstHist_ToPort.Name = "lAtb_CstHist_ToPort";
            lAtb_CstHist_ToPort.Size = new Size(163, 24);
            lAtb_CstHist_ToPort.TabIndex = 9;
            lAtb_CstHist_ToPort.Tb_Text = "";
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
            tableLayoutPanel3.ColumnCount = 4;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanel3.Controls.Add(uwC_TextBox1, 0, 0);
            tableLayoutPanel3.Controls.Add(uwC_TextBox2, 1, 1);
            tableLayoutPanel3.Controls.Add(bt_beautifierJson, 2, 0);
            tableLayoutPanel3.Controls.Add(bt_beautifierXml, 3, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanel3.Size = new Size(1414, 597);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // uwC_TextBox1
            // 
            uwC_TextBox1.Dock = DockStyle.Fill;
            uwC_TextBox1.Location = new Point(3, 3);
            uwC_TextBox1.Name = "uwC_TextBox1";
            tableLayoutPanel3.SetRowSpan(uwC_TextBox1, 3);
            uwC_TextBox1.Size = new Size(621, 591);
            uwC_TextBox1.TabIndex = 0;
            // 
            // uwC_TextBox2
            // 
            tableLayoutPanel3.SetColumnSpan(uwC_TextBox2, 3);
            uwC_TextBox2.Dock = DockStyle.Fill;
            uwC_TextBox2.Location = new Point(630, 33);
            uwC_TextBox2.Name = "uwC_TextBox2";
            uwC_TextBox2.Size = new Size(781, 390);
            uwC_TextBox2.TabIndex = 1;
            // 
            // bt_beautifierJson
            // 
            bt_beautifierJson.Location = new Point(1257, 3);
            bt_beautifierJson.Name = "bt_beautifierJson";
            bt_beautifierJson.Size = new Size(74, 23);
            bt_beautifierJson.TabIndex = 2;
            bt_beautifierJson.Text = "Convert_J";
            bt_beautifierJson.UseVisualStyleBackColor = true;
            bt_beautifierJson.Click += bt_beautifierJson_Click;
            // 
            // bt_beautifierXml
            // 
            bt_beautifierXml.Location = new Point(1337, 3);
            bt_beautifierXml.Name = "bt_beautifierXml";
            bt_beautifierXml.Size = new Size(74, 23);
            bt_beautifierXml.TabIndex = 3;
            bt_beautifierXml.Text = "Convert_X";
            bt_beautifierXml.UseVisualStyleBackColor = true;
            bt_beautifierXml.Click += bt_beautifierXml_Click;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1420, 603);
            tabPage1.TabIndex = 6;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
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
            reqATransfer_dgvReq.ResumeLayout(false);
            tp_ReqInfomation.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tp_TransportList.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            tp_ReqAndTransfer.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tp_CstHist.ResumeLayout(false);
            tableLayoutPanel7.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tp_EqpState.ResumeLayout(false);
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel8.PerformLayout();
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
        private TabControl reqATransfer_dgvReq;
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
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_ReqInfo_ReqEqp;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_ReqInfo_RuleText;
        internal TableLayoutPanel tableLayoutPanel4;
        internal UserWinfromControl.UWC_TimerAndBtn tAbt_ReqInfo_Search;
        private Button bt_DataRefresh;
        private TableLayoutPanel tableLayoutPanel5;
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
        internal TabPage tp_ReqAndTransfer;
        internal TableLayoutPanel tableLayoutPanel6;
        internal Button bt_ReqATransfer_Search;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_ReqATransfer_CarrierId;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_ReqATransfer_StartPort;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_ReqATransfer_RuleId;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_ReqATransfer_ArrPort;
        internal UserWinfromControl.UWC_LabelAndDateTimePicker lAdtp_ReqATransfer_StartDate;
        internal UserWinfromControl.UWC_LabelAndDateTimePicker lAdtp_ReqATransfer_EndDate;
        internal ComboBox cb_ReqATransfer_CstStat;
        internal ComboBox cb_ReqATransfer_MovingState;
        internal RadioButton rb_ReqHist;
        internal CheckBox ckb_IsDeleteTransfer;
        internal UserWinfromControl.UWC_DataGridView reqAndTransfer_dgvReq;
        internal RadioButton rb_TransferHist;
        private TabPage tp_CstHist;
        private TableLayoutPanel tableLayoutPanel7;
        private Button bt_CstHist_Search;
        private Panel panel2;
        private Panel panel3;
        internal UserWinfromControl.UWC_LabelAndDateTimePicker lAdtp_CstHist_StartDate;
        internal UserWinfromControl.UWC_LabelAndDateTimePicker lAdtp_CstHist_EndDate;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_CstHist_CarrierId;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_CstHist_ToPort;
        internal RadioButton rb_IsTrayActHist;
        internal RadioButton rb_IsEventHist;
        internal UserWinfromControl.UWC_DataGridView cstHist_Dgv;
        internal UserWinfromControl.UWC_DataGridView uwC_DataGridView3;
        private TabPage tp_EqpState;
        private TabPage tabPage1;
        private TableLayoutPanel tableLayoutPanel8;
        private Label label1;
        internal UserWinfromControl.UWC_DataGridView eqpState_DgvEqpList;
        internal ComboBox cb_EqpState_EqpGroupList;
        internal UserWinfromControl.UWC_DataGridView eqpState_DgvEqpPortList;
        internal Button bt_EqpState_Search;
        private UserWinfromControl.UWC_TextBox uwC_TextBox2;
        private Button bt_beautifierJson;
        internal UserWinfromControl.UWC_DataGridView transList_CstInfo;
        private Button bt_beautifierXml;
    }
}
