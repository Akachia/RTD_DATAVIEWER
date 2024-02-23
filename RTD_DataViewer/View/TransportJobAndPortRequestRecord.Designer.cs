namespace RTD_DataViewer.View
{
    partial class TransportJobAndPortRequestRecord
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
            tableLayoutPanel6 = new TableLayoutPanel();
            bt_ReqATransfer_Search = new Button();
            lAdtp_ReqATransfer_StartDate = new UserWinfromControl.UWC_LabelAndDateTimePicker();
            lAdtp_ReqATransfer_EndDate = new UserWinfromControl.UWC_LabelAndDateTimePicker();
            dgv_PortRequestRecord = new UserWinfromControl.UWC_DataGridView();
            panel2 = new Panel();
            rb_TransferHist = new RadioButton();
            rb_ReqHist = new RadioButton();
            lAtb_ReqATransfer_StartPort = new UserWinfromControl.UWC_LabelAndTextBox();
            lAtb_ReqATransfer_ArrPort = new UserWinfromControl.UWC_LabelAndTextBox();
            lAtb_ReqATransfer_CarrierId = new UserWinfromControl.UWC_LabelAndTextBox();
            lAtb_ReqATransfer_RuleId = new UserWinfromControl.UWC_LabelAndTextBox();
            cb_CarrierStat = new UserWinfromControl.UWC_ComboBox();
            cb_TransportStatList = new UserWinfromControl.UWC_ComboBox();
            tableLayoutPanel6.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 8;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
            tableLayoutPanel6.Controls.Add(bt_ReqATransfer_Search, 7, 0);
            tableLayoutPanel6.Controls.Add(lAdtp_ReqATransfer_StartDate, 2, 0);
            tableLayoutPanel6.Controls.Add(lAdtp_ReqATransfer_EndDate, 2, 1);
            tableLayoutPanel6.Controls.Add(dgv_PortRequestRecord, 0, 2);
            tableLayoutPanel6.Controls.Add(panel2, 3, 0);
            tableLayoutPanel6.Controls.Add(lAtb_ReqATransfer_StartPort, 6, 0);
            tableLayoutPanel6.Controls.Add(lAtb_ReqATransfer_ArrPort, 6, 1);
            tableLayoutPanel6.Controls.Add(lAtb_ReqATransfer_CarrierId, 5, 0);
            tableLayoutPanel6.Controls.Add(lAtb_ReqATransfer_RuleId, 5, 1);
            tableLayoutPanel6.Controls.Add(cb_CarrierStat, 4, 0);
            tableLayoutPanel6.Controls.Add(cb_TransportStatList, 4, 1);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(0, 0);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 3;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.Size = new Size(1400, 600);
            tableLayoutPanel6.TabIndex = 1;
            // 
            // bt_ReqATransfer_Search
            // 
            bt_ReqATransfer_Search.Dock = DockStyle.Fill;
            bt_ReqATransfer_Search.Location = new Point(1291, 3);
            bt_ReqATransfer_Search.Name = "bt_ReqATransfer_Search";
            tableLayoutPanel6.SetRowSpan(bt_ReqATransfer_Search, 2);
            bt_ReqATransfer_Search.Size = new Size(106, 54);
            bt_ReqATransfer_Search.TabIndex = 0;
            bt_ReqATransfer_Search.Text = "Search";
            bt_ReqATransfer_Search.UseVisualStyleBackColor = true;
            // 
            // lAdtp_ReqATransfer_StartDate
            // 
            lAdtp_ReqATransfer_StartDate.Dock = DockStyle.Fill;
            lAdtp_ReqATransfer_StartDate.Dtp_Value = new DateTime(2023, 11, 28, 9, 4, 55, 992);
            lAdtp_ReqATransfer_StartDate.IsChecked = true;
            lAdtp_ReqATransfer_StartDate.Lb_Text = "시간 시간";
            lAdtp_ReqATransfer_StartDate.Location = new Point(493, 3);
            lAdtp_ReqATransfer_StartDate.Name = "lAdtp_ReqATransfer_StartDate";
            lAdtp_ReqATransfer_StartDate.Size = new Size(274, 24);
            lAdtp_ReqATransfer_StartDate.TabIndex = 5;
            lAdtp_ReqATransfer_StartDate.VariableName = "StartTime";
            // 
            // lAdtp_ReqATransfer_EndDate
            // 
            lAdtp_ReqATransfer_EndDate.Dock = DockStyle.Fill;
            lAdtp_ReqATransfer_EndDate.Dtp_Value = new DateTime(2023, 11, 28, 9, 4, 58, 362);
            lAdtp_ReqATransfer_EndDate.IsChecked = false;
            lAdtp_ReqATransfer_EndDate.Lb_Text = "종료 시간";
            lAdtp_ReqATransfer_EndDate.Location = new Point(493, 33);
            lAdtp_ReqATransfer_EndDate.Name = "lAdtp_ReqATransfer_EndDate";
            lAdtp_ReqATransfer_EndDate.Size = new Size(274, 24);
            lAdtp_ReqATransfer_EndDate.TabIndex = 6;
            lAdtp_ReqATransfer_EndDate.VariableName = "EndTime";
            // 
            // dgv_PortRequestRecord
            // 
            tableLayoutPanel6.SetColumnSpan(dgv_PortRequestRecord, 8);
            dgv_PortRequestRecord.Dock = DockStyle.Fill;
            dgv_PortRequestRecord.Lb_Text = "SqlName";
            dgv_PortRequestRecord.Lb_Text2 = "";
            dgv_PortRequestRecord.Location = new Point(3, 63);
            dgv_PortRequestRecord.Name = "dgv_PortRequestRecord";
            dgv_PortRequestRecord.Size = new Size(1394, 534);
            dgv_PortRequestRecord.TabIndex = 12;
            // 
            // panel2
            // 
            panel2.Controls.Add(rb_TransferHist);
            panel2.Controls.Add(rb_ReqHist);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(773, 3);
            panel2.Name = "panel2";
            tableLayoutPanel6.SetRowSpan(panel2, 2);
            panel2.Size = new Size(78, 54);
            panel2.TabIndex = 13;
            // 
            // rb_TransferHist
            // 
            rb_TransferHist.AutoSize = true;
            rb_TransferHist.Checked = true;
            rb_TransferHist.Location = new Point(3, 31);
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
            rb_ReqHist.Location = new Point(3, 3);
            rb_ReqHist.Name = "rb_ReqHist";
            rb_ReqHist.RightToLeft = RightToLeft.Yes;
            rb_ReqHist.Size = new Size(73, 19);
            rb_ReqHist.TabIndex = 9;
            rb_ReqHist.TabStop = true;
            rb_ReqHist.Text = "요청이력";
            rb_ReqHist.UseVisualStyleBackColor = true;
            // 
            // lAtb_ReqATransfer_StartPort
            // 
            lAtb_ReqATransfer_StartPort.Dock = DockStyle.Fill;
            lAtb_ReqATransfer_StartPort.Lb_Text = "출발 포트";
            lAtb_ReqATransfer_StartPort.Location = new Point(1123, 3);
            lAtb_ReqATransfer_StartPort.Name = "lAtb_ReqATransfer_StartPort";
            lAtb_ReqATransfer_StartPort.Size = new Size(162, 24);
            lAtb_ReqATransfer_StartPort.TabIndex = 2;
            lAtb_ReqATransfer_StartPort.Tb_Text = "";
            lAtb_ReqATransfer_StartPort.VariableName = "ReqPortId";
            // 
            // lAtb_ReqATransfer_ArrPort
            // 
            lAtb_ReqATransfer_ArrPort.Dock = DockStyle.Fill;
            lAtb_ReqATransfer_ArrPort.Lb_Text = "도착 포트";
            lAtb_ReqATransfer_ArrPort.Location = new Point(1123, 33);
            lAtb_ReqATransfer_ArrPort.Name = "lAtb_ReqATransfer_ArrPort";
            lAtb_ReqATransfer_ArrPort.Size = new Size(162, 24);
            lAtb_ReqATransfer_ArrPort.TabIndex = 4;
            lAtb_ReqATransfer_ArrPort.Tb_Text = "";
            lAtb_ReqATransfer_ArrPort.VariableName = "ToPortId";
            // 
            // lAtb_ReqATransfer_CarrierId
            // 
            lAtb_ReqATransfer_CarrierId.Dock = DockStyle.Fill;
            lAtb_ReqATransfer_CarrierId.Lb_Text = "Carrier ID";
            lAtb_ReqATransfer_CarrierId.Location = new Point(955, 3);
            lAtb_ReqATransfer_CarrierId.Name = "lAtb_ReqATransfer_CarrierId";
            lAtb_ReqATransfer_CarrierId.Size = new Size(162, 24);
            lAtb_ReqATransfer_CarrierId.TabIndex = 1;
            lAtb_ReqATransfer_CarrierId.Tb_Text = "";
            lAtb_ReqATransfer_CarrierId.VariableName = "CSTID";
            // 
            // lAtb_ReqATransfer_RuleId
            // 
            lAtb_ReqATransfer_RuleId.Dock = DockStyle.Fill;
            lAtb_ReqATransfer_RuleId.Lb_Text = "Rule ID";
            lAtb_ReqATransfer_RuleId.Location = new Point(955, 33);
            lAtb_ReqATransfer_RuleId.Name = "lAtb_ReqATransfer_RuleId";
            lAtb_ReqATransfer_RuleId.Size = new Size(162, 24);
            lAtb_ReqATransfer_RuleId.TabIndex = 3;
            lAtb_ReqATransfer_RuleId.Tb_Text = "";
            lAtb_ReqATransfer_RuleId.VariableName = "RuleId";
            // 
            // cb_CarrierStat
            // 
            cb_CarrierStat.ComboBoxSelectedIndex = -1;
            cb_CarrierStat.ComboBoxText = "공/실";
            cb_CarrierStat.DataSource = null;
            cb_CarrierStat.Dock = DockStyle.Fill;
            cb_CarrierStat.Location = new Point(857, 3);
            cb_CarrierStat.Name = "cb_CarrierStat";
            cb_CarrierStat.Size = new Size(92, 24);
            cb_CarrierStat.TabIndex = 14;
            cb_CarrierStat.VariableName = "CSTSTAT";
            // 
            // cb_TransportStatList
            // 
            cb_TransportStatList.ComboBoxSelectedIndex = -1;
            cb_TransportStatList.ComboBoxText = "반송 상태";
            cb_TransportStatList.DataSource = null;
            cb_TransportStatList.Dock = DockStyle.Fill;
            cb_TransportStatList.Location = new Point(857, 33);
            cb_TransportStatList.Name = "cb_TransportStatList";
            cb_TransportStatList.Size = new Size(92, 24);
            cb_TransportStatList.TabIndex = 15;
            cb_TransportStatList.VariableName = "MOVINGSTATE";
            // 
            // TransportJobAndPortRequestRecord
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel6);
            Name = "TransportJobAndPortRequestRecord";
            Size = new Size(1400, 600);
            tableLayoutPanel6.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        internal TableLayoutPanel tableLayoutPanel6;
        internal Button bt_ReqATransfer_Search;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_ReqATransfer_CarrierId;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_ReqATransfer_StartPort;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_ReqATransfer_RuleId;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_ReqATransfer_ArrPort;
        internal UserWinfromControl.UWC_LabelAndDateTimePicker lAdtp_ReqATransfer_StartDate;
        internal UserWinfromControl.UWC_LabelAndDateTimePicker lAdtp_ReqATransfer_EndDate;
        internal UserWinfromControl.UWC_DataGridView dgv_PortRequestRecord;
        private Panel panel2;
        internal RadioButton rb_TransferHist;
        internal RadioButton rb_ReqHist;
        private UserWinfromControl.UWC_ComboBox cb_TransportStatList;
        private UserWinfromControl.UWC_ComboBox cb_CarrierStat;
    }
}
