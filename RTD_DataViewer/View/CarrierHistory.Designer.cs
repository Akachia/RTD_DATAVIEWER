namespace RTD_DataViewer.View
{
    partial class CarrierHistory
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel7 = new TableLayoutPanel();
            lAdtp_CstHist_StartDate = new UserWinfromControl.UWC_LabelAndDateTimePicker();
            lAdtp_CstHist_EndDate = new UserWinfromControl.UWC_LabelAndDateTimePicker();
            lAtb_CstHist_CarrierId = new UserWinfromControl.UWC_LabelAndTextBox();
            bt_CstHist_Search = new Button();
            dgv_CarrierHistory = new UserWinfromControl.UWC_DataGridView();
            uwC_DataGridView3 = new UserWinfromControl.UWC_DataGridView();
            panel3 = new Panel();
            rb_IsTrayActHist = new RadioButton();
            rb_IsEventHist = new RadioButton();
            lAtb_CstHist_ToPort = new UserWinfromControl.UWC_LabelAndTextBox();
            tableLayoutPanel7.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 8;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
            tableLayoutPanel7.Controls.Add(lAdtp_CstHist_StartDate, 6, 0);
            tableLayoutPanel7.Controls.Add(lAdtp_CstHist_EndDate, 6, 1);
            tableLayoutPanel7.Controls.Add(lAtb_CstHist_CarrierId, 5, 0);
            tableLayoutPanel7.Controls.Add(bt_CstHist_Search, 7, 0);
            tableLayoutPanel7.Controls.Add(dgv_CarrierHistory, 0, 2);
            tableLayoutPanel7.Controls.Add(uwC_DataGridView3, 0, 3);
            tableLayoutPanel7.Controls.Add(panel3, 4, 0);
            tableLayoutPanel7.Controls.Add(lAtb_CstHist_ToPort, 5, 1);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(0, 0);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 4;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel7.Size = new Size(1400, 600);
            tableLayoutPanel7.TabIndex = 1;
            // 
            // lAdtp_CstHist_StartDate
            // 
            lAdtp_CstHist_StartDate.Dock = DockStyle.Fill;
            lAdtp_CstHist_StartDate.Dtp_Value = new DateTime(2023, 11, 30, 9, 34, 48, 775);
            lAdtp_CstHist_StartDate.IsChecked = false;
            lAdtp_CstHist_StartDate.Lb_Text = "시작 시간";
            lAdtp_CstHist_StartDate.Location = new Point(1011, 3);
            lAdtp_CstHist_StartDate.Name = "lAdtp_CstHist_StartDate";
            lAdtp_CstHist_StartDate.Size = new Size(274, 24);
            lAdtp_CstHist_StartDate.TabIndex = 0;
            lAdtp_CstHist_StartDate.VariableName = "";
            // 
            // lAdtp_CstHist_EndDate
            // 
            lAdtp_CstHist_EndDate.Dock = DockStyle.Fill;
            lAdtp_CstHist_EndDate.Dtp_Value = new DateTime(2023, 11, 30, 9, 34, 54, 344);
            lAdtp_CstHist_EndDate.IsChecked = false;
            lAdtp_CstHist_EndDate.Lb_Text = "종료 시간";
            lAdtp_CstHist_EndDate.Location = new Point(1011, 33);
            lAdtp_CstHist_EndDate.Name = "lAdtp_CstHist_EndDate";
            lAdtp_CstHist_EndDate.Size = new Size(274, 24);
            lAdtp_CstHist_EndDate.TabIndex = 1;
            lAdtp_CstHist_EndDate.VariableName = "";
            // 
            // lAtb_CstHist_CarrierId
            // 
            lAtb_CstHist_CarrierId.Dock = DockStyle.Fill;
            lAtb_CstHist_CarrierId.Lb_Text = "Carrier ID";
            lAtb_CstHist_CarrierId.Location = new Point(843, 3);
            lAtb_CstHist_CarrierId.Name = "lAtb_CstHist_CarrierId";
            lAtb_CstHist_CarrierId.Size = new Size(162, 24);
            lAtb_CstHist_CarrierId.TabIndex = 2;
            lAtb_CstHist_CarrierId.Tb_Text = "";
            lAtb_CstHist_CarrierId.VariableName = "";
            // 
            // bt_CstHist_Search
            // 
            bt_CstHist_Search.Dock = DockStyle.Fill;
            bt_CstHist_Search.Location = new Point(1291, 3);
            bt_CstHist_Search.Name = "bt_CstHist_Search";
            tableLayoutPanel7.SetRowSpan(bt_CstHist_Search, 2);
            bt_CstHist_Search.Size = new Size(106, 54);
            bt_CstHist_Search.TabIndex = 5;
            bt_CstHist_Search.Text = "Search";
            bt_CstHist_Search.UseVisualStyleBackColor = true;
            bt_CstHist_Search.Click += bt_CstHist_Search_Click;
            // 
            // dgv_CarrierHistory
            // 
            tableLayoutPanel7.SetColumnSpan(dgv_CarrierHistory, 8);
            dgv_CarrierHistory.Dock = DockStyle.Fill;
            dgv_CarrierHistory.Lb_Text = "SqlName";
            dgv_CarrierHistory.Lb_Text2 = "";
            dgv_CarrierHistory.Location = new Point(3, 63);
            dgv_CarrierHistory.Name = "dgv_CarrierHistory";
            dgv_CarrierHistory.Size = new Size(1394, 454);
            dgv_CarrierHistory.TabIndex = 6;
            // 
            // uwC_DataGridView3
            // 
            tableLayoutPanel7.SetColumnSpan(uwC_DataGridView3, 8);
            uwC_DataGridView3.Dock = DockStyle.Fill;
            uwC_DataGridView3.Lb_Text = "SqlName";
            uwC_DataGridView3.Lb_Text2 = "";
            uwC_DataGridView3.Location = new Point(3, 523);
            uwC_DataGridView3.Name = "uwC_DataGridView3";
            uwC_DataGridView3.Size = new Size(1394, 74);
            uwC_DataGridView3.TabIndex = 7;
            // 
            // panel3
            // 
            panel3.Controls.Add(rb_IsTrayActHist);
            panel3.Controls.Add(rb_IsEventHist);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(703, 3);
            panel3.Name = "panel3";
            tableLayoutPanel7.SetRowSpan(panel3, 2);
            panel3.Size = new Size(134, 54);
            panel3.TabIndex = 8;
            // 
            // rb_IsTrayActHist
            // 
            rb_IsTrayActHist.AutoSize = true;
            rb_IsTrayActHist.Location = new Point(37, 3);
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
            rb_IsEventHist.Location = new Point(52, 32);
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
            lAtb_CstHist_ToPort.Location = new Point(843, 33);
            lAtb_CstHist_ToPort.Name = "lAtb_CstHist_ToPort";
            lAtb_CstHist_ToPort.Size = new Size(162, 24);
            lAtb_CstHist_ToPort.TabIndex = 9;
            lAtb_CstHist_ToPort.Tb_Text = "";
            lAtb_CstHist_ToPort.VariableName = "";
            // 
            // CarrierHistory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel7);
            Name = "CarrierHistory";
            Size = new Size(1400, 600);
            tableLayoutPanel7.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel7;
        internal UserWinfromControl.UWC_LabelAndDateTimePicker lAdtp_CstHist_StartDate;
        internal UserWinfromControl.UWC_LabelAndDateTimePicker lAdtp_CstHist_EndDate;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_CstHist_CarrierId;
        private Button bt_CstHist_Search;
        internal UserWinfromControl.UWC_DataGridView dgv_CarrierHistory;
        internal UserWinfromControl.UWC_DataGridView uwC_DataGridView3;
        private Panel panel3;
        internal RadioButton rb_IsTrayActHist;
        internal RadioButton rb_IsEventHist;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_CstHist_ToPort;
    }
}
