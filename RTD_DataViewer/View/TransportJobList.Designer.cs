namespace RTD_DataViewer.View
{
    partial class TransportJobList
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
            tableLayoutPanel5 = new TableLayoutPanel();
            ckb_Send = new CheckBox();
            ckb_Receive = new CheckBox();
            ckb_Delete = new CheckBox();
            lAdtp_TransList_StartDate = new UserWinfromControl.UWC_LabelAndDateTimePicker();
            lAdtp_TransList_EndDate = new UserWinfromControl.UWC_LabelAndDateTimePicker();
            tAbt_TransList_Search = new UserWinfromControl.UWC_TimerAndBtn();
            lAtb_TransList_CarrierId = new UserWinfromControl.UWC_LabelAndTextBox();
            lAtb_TransList_ReqEqp = new UserWinfromControl.UWC_LabelAndTextBox();
            lAtb_TransList_LaneId = new UserWinfromControl.UWC_LabelAndTextBox();
            lAtb_TransList_ToEqp = new UserWinfromControl.UWC_LabelAndTextBox();
            dgv_CurrentTransportJobList = new UserWinfromControl.UWC_DataGridView();
            dgv_TransportJobHistory = new UserWinfromControl.UWC_DataGridView();
            dgv_CarrierInfomation = new UserWinfromControl.UWC_DataGridView();
            ckb_IsFaulty = new CheckBox();
            ckb_Abnormal = new CheckBox();
            ckb_Moving = new CheckBox();
            ckb_Cancel = new CheckBox();
            cb_CarrierStat = new UserWinfromControl.UWC_ComboBox();
            lb_TransportJobStatus = new Label();
            dgv_RouteInfo = new UserWinfromControl.UWC_DataGridView();
            tableLayoutPanel5.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 10;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            tableLayoutPanel5.Controls.Add(ckb_Send, 3, 0);
            tableLayoutPanel5.Controls.Add(ckb_Receive, 4, 0);
            tableLayoutPanel5.Controls.Add(ckb_Delete, 3, 1);
            tableLayoutPanel5.Controls.Add(lAdtp_TransList_StartDate, 2, 0);
            tableLayoutPanel5.Controls.Add(lAdtp_TransList_EndDate, 2, 1);
            tableLayoutPanel5.Controls.Add(tAbt_TransList_Search, 9, 0);
            tableLayoutPanel5.Controls.Add(lAtb_TransList_CarrierId, 7, 0);
            tableLayoutPanel5.Controls.Add(lAtb_TransList_ReqEqp, 8, 0);
            tableLayoutPanel5.Controls.Add(lAtb_TransList_LaneId, 7, 1);
            tableLayoutPanel5.Controls.Add(lAtb_TransList_ToEqp, 8, 1);
            tableLayoutPanel5.Controls.Add(dgv_CurrentTransportJobList, 0, 2);
            tableLayoutPanel5.Controls.Add(dgv_TransportJobHistory, 8, 2);
            tableLayoutPanel5.Controls.Add(dgv_CarrierInfomation, 8, 4);
            tableLayoutPanel5.Controls.Add(ckb_IsFaulty, 6, 1);
            tableLayoutPanel5.Controls.Add(ckb_Abnormal, 4, 1);
            tableLayoutPanel5.Controls.Add(ckb_Moving, 5, 0);
            tableLayoutPanel5.Controls.Add(ckb_Cancel, 5, 1);
            tableLayoutPanel5.Controls.Add(cb_CarrierStat, 6, 0);
            tableLayoutPanel5.Controls.Add(lb_TransportJobStatus, 1, 0);
            tableLayoutPanel5.Controls.Add(dgv_RouteInfo, 8, 3);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(0, 0);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 5;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            tableLayoutPanel5.Size = new Size(1400, 600);
            tableLayoutPanel5.TabIndex = 1;
            // 
            // ckb_Send
            // 
            ckb_Send.AutoSize = true;
            ckb_Send.Checked = true;
            ckb_Send.CheckState = CheckState.Checked;
            ckb_Send.Dock = DockStyle.Fill;
            ckb_Send.Location = new Point(591, 3);
            ckb_Send.Name = "ckb_Send";
            ckb_Send.RightToLeft = RightToLeft.Yes;
            ckb_Send.Size = new Size(78, 24);
            ckb_Send.TabIndex = 8;
            ckb_Send.Text = "Send";
            ckb_Send.UseVisualStyleBackColor = true;
            // 
            // ckb_Receive
            // 
            ckb_Receive.AutoSize = true;
            ckb_Receive.Checked = true;
            ckb_Receive.CheckState = CheckState.Checked;
            ckb_Receive.Dock = DockStyle.Fill;
            ckb_Receive.Location = new Point(675, 3);
            ckb_Receive.Name = "ckb_Receive";
            ckb_Receive.RightToLeft = RightToLeft.Yes;
            ckb_Receive.Size = new Size(78, 24);
            ckb_Receive.TabIndex = 9;
            ckb_Receive.Text = "Receive";
            ckb_Receive.UseVisualStyleBackColor = true;
            // 
            // ckb_Delete
            // 
            ckb_Delete.AutoSize = true;
            ckb_Delete.Dock = DockStyle.Fill;
            ckb_Delete.Location = new Point(591, 33);
            ckb_Delete.Name = "ckb_Delete";
            ckb_Delete.RightToLeft = RightToLeft.Yes;
            ckb_Delete.Size = new Size(78, 24);
            ckb_Delete.TabIndex = 10;
            ckb_Delete.Text = "Delete";
            ckb_Delete.UseVisualStyleBackColor = true;
            // 
            // lAdtp_TransList_StartDate
            // 
            lAdtp_TransList_StartDate.Dock = DockStyle.Fill;
            lAdtp_TransList_StartDate.Dtp_Value = new DateTime(2023, 11, 27, 10, 20, 54, 324);
            lAdtp_TransList_StartDate.IsChecked = true;
            lAdtp_TransList_StartDate.Lb_Text = "시작 시간";
            lAdtp_TransList_StartDate.Location = new Point(311, 3);
            lAdtp_TransList_StartDate.Name = "lAdtp_TransList_StartDate";
            lAdtp_TransList_StartDate.Size = new Size(274, 24);
            lAdtp_TransList_StartDate.TabIndex = 12;
            lAdtp_TransList_StartDate.VariableName = "StartTime";
            // 
            // lAdtp_TransList_EndDate
            // 
            lAdtp_TransList_EndDate.Dock = DockStyle.Fill;
            lAdtp_TransList_EndDate.Dtp_Value = new DateTime(2023, 11, 27, 10, 20, 56, 692);
            lAdtp_TransList_EndDate.IsChecked = false;
            lAdtp_TransList_EndDate.Lb_Text = "종료 시간";
            lAdtp_TransList_EndDate.Location = new Point(311, 33);
            lAdtp_TransList_EndDate.Name = "lAdtp_TransList_EndDate";
            lAdtp_TransList_EndDate.Size = new Size(274, 24);
            lAdtp_TransList_EndDate.TabIndex = 13;
            lAdtp_TransList_EndDate.VariableName = "EndTime";
            // 
            // tAbt_TransList_Search
            // 
            tAbt_TransList_Search.Dock = DockStyle.Fill;
            tAbt_TransList_Search.Interval = 20;
            tAbt_TransList_Search.IsUseTimer = false;
            tAbt_TransList_Search.Location = new Point(1235, 3);
            tAbt_TransList_Search.Name = "tAbt_TransList_Search";
            tableLayoutPanel5.SetRowSpan(tAbt_TransList_Search, 2);
            tAbt_TransList_Search.Size = new Size(162, 54);
            tAbt_TransList_Search.TabIndex = 14;
            // 
            // lAtb_TransList_CarrierId
            // 
            lAtb_TransList_CarrierId.Dock = DockStyle.Fill;
            lAtb_TransList_CarrierId.IsMultiInputTextControl = true;
            lAtb_TransList_CarrierId.Lb_Text = "Carrier ID";
            lAtb_TransList_CarrierId.Location = new Point(927, 3);
            lAtb_TransList_CarrierId.Name = "lAtb_TransList_CarrierId";
            lAtb_TransList_CarrierId.Size = new Size(148, 24);
            lAtb_TransList_CarrierId.TabIndex = 15;
            lAtb_TransList_CarrierId.Tb_Text = "";
            lAtb_TransList_CarrierId.VariableName = "CSTID";
            // 
            // lAtb_TransList_ReqEqp
            // 
            lAtb_TransList_ReqEqp.Dock = DockStyle.Fill;
            lAtb_TransList_ReqEqp.IsMultiInputTextControl = false;
            lAtb_TransList_ReqEqp.Lb_Text = "출발지 설비";
            lAtb_TransList_ReqEqp.Location = new Point(1081, 3);
            lAtb_TransList_ReqEqp.Name = "lAtb_TransList_ReqEqp";
            lAtb_TransList_ReqEqp.Size = new Size(148, 24);
            lAtb_TransList_ReqEqp.TabIndex = 16;
            lAtb_TransList_ReqEqp.Tb_Text = "";
            lAtb_TransList_ReqEqp.VariableName = "ReqPortId";
            // 
            // lAtb_TransList_LaneId
            // 
            lAtb_TransList_LaneId.Dock = DockStyle.Fill;
            lAtb_TransList_LaneId.IsMultiInputTextControl = false;
            lAtb_TransList_LaneId.Lb_Text = "Lane ID";
            lAtb_TransList_LaneId.Location = new Point(927, 33);
            lAtb_TransList_LaneId.Name = "lAtb_TransList_LaneId";
            lAtb_TransList_LaneId.Size = new Size(148, 24);
            lAtb_TransList_LaneId.TabIndex = 17;
            lAtb_TransList_LaneId.Tb_Text = "";
            lAtb_TransList_LaneId.VariableName = "LANE_ID";
            // 
            // lAtb_TransList_ToEqp
            // 
            lAtb_TransList_ToEqp.Dock = DockStyle.Fill;
            lAtb_TransList_ToEqp.IsMultiInputTextControl = false;
            lAtb_TransList_ToEqp.Lb_Text = "목적지 설비";
            lAtb_TransList_ToEqp.Location = new Point(1081, 33);
            lAtb_TransList_ToEqp.Name = "lAtb_TransList_ToEqp";
            lAtb_TransList_ToEqp.Size = new Size(148, 24);
            lAtb_TransList_ToEqp.TabIndex = 18;
            lAtb_TransList_ToEqp.Tb_Text = "";
            lAtb_TransList_ToEqp.VariableName = "ToPortId";
            // 
            // dgv_CurrentTransportJobList
            // 
            tableLayoutPanel5.SetColumnSpan(dgv_CurrentTransportJobList, 8);
            dgv_CurrentTransportJobList.Dock = DockStyle.Fill;
            dgv_CurrentTransportJobList.Lb_Text = "SqlName";
            dgv_CurrentTransportJobList.Lb_Text2 = "";
            dgv_CurrentTransportJobList.Location = new Point(3, 63);
            dgv_CurrentTransportJobList.Name = "dgv_CurrentTransportJobList";
            tableLayoutPanel5.SetRowSpan(dgv_CurrentTransportJobList, 3);
            dgv_CurrentTransportJobList.Size = new Size(1072, 534);
            dgv_CurrentTransportJobList.TabIndex = 19;
            // 
            // dgv_TransportJobHistory
            // 
            tableLayoutPanel5.SetColumnSpan(dgv_TransportJobHistory, 2);
            dgv_TransportJobHistory.Dock = DockStyle.Fill;
            dgv_TransportJobHistory.Lb_Text = "SqlName";
            dgv_TransportJobHistory.Lb_Text2 = "";
            dgv_TransportJobHistory.Location = new Point(1081, 63);
            dgv_TransportJobHistory.Name = "dgv_TransportJobHistory";
            dgv_TransportJobHistory.Size = new Size(316, 162);
            dgv_TransportJobHistory.TabIndex = 20;
            // 
            // dgv_CarrierInfomation
            // 
            tableLayoutPanel5.SetColumnSpan(dgv_CarrierInfomation, 2);
            dgv_CarrierInfomation.Dock = DockStyle.Fill;
            dgv_CarrierInfomation.Lb_Text = "SqlName";
            dgv_CarrierInfomation.Lb_Text2 = "";
            dgv_CarrierInfomation.Location = new Point(1081, 483);
            dgv_CarrierInfomation.Name = "dgv_CarrierInfomation";
            dgv_CarrierInfomation.Size = new Size(316, 114);
            dgv_CarrierInfomation.TabIndex = 21;
            // 
            // ckb_IsFaulty
            // 
            ckb_IsFaulty.AutoSize = true;
            ckb_IsFaulty.Dock = DockStyle.Fill;
            ckb_IsFaulty.Location = new Point(843, 33);
            ckb_IsFaulty.Name = "ckb_IsFaulty";
            ckb_IsFaulty.RightToLeft = RightToLeft.Yes;
            ckb_IsFaulty.Size = new Size(78, 24);
            ckb_IsFaulty.TabIndex = 11;
            ckb_IsFaulty.Text = "불량적재";
            ckb_IsFaulty.UseVisualStyleBackColor = true;
            // 
            // ckb_Abnormal
            // 
            ckb_Abnormal.AutoSize = true;
            ckb_Abnormal.Dock = DockStyle.Fill;
            ckb_Abnormal.Location = new Point(675, 33);
            ckb_Abnormal.Name = "ckb_Abnormal";
            ckb_Abnormal.RightToLeft = RightToLeft.Yes;
            ckb_Abnormal.Size = new Size(78, 24);
            ckb_Abnormal.TabIndex = 22;
            ckb_Abnormal.Text = "Abnormal";
            ckb_Abnormal.TextAlign = ContentAlignment.MiddleCenter;
            ckb_Abnormal.UseVisualStyleBackColor = true;
            // 
            // ckb_Moving
            // 
            ckb_Moving.AutoSize = true;
            ckb_Moving.Checked = true;
            ckb_Moving.CheckState = CheckState.Checked;
            ckb_Moving.Dock = DockStyle.Fill;
            ckb_Moving.Location = new Point(759, 3);
            ckb_Moving.Name = "ckb_Moving";
            ckb_Moving.RightToLeft = RightToLeft.Yes;
            ckb_Moving.Size = new Size(78, 24);
            ckb_Moving.TabIndex = 23;
            ckb_Moving.Text = "Moving";
            ckb_Moving.UseVisualStyleBackColor = true;
            // 
            // ckb_Cancel
            // 
            ckb_Cancel.AutoSize = true;
            ckb_Cancel.Dock = DockStyle.Fill;
            ckb_Cancel.Location = new Point(759, 33);
            ckb_Cancel.Name = "ckb_Cancel";
            ckb_Cancel.RightToLeft = RightToLeft.Yes;
            ckb_Cancel.Size = new Size(78, 24);
            ckb_Cancel.TabIndex = 24;
            ckb_Cancel.Text = "Cancel";
            ckb_Cancel.UseVisualStyleBackColor = true;
            // 
            // cb_CarrierStat
            // 
            cb_CarrierStat.ComboBoxSelectedIndex = -1;
            cb_CarrierStat.ComboBoxText = "공/실";
            cb_CarrierStat.DataSource = null;
            cb_CarrierStat.Location = new Point(843, 3);
            cb_CarrierStat.Name = "cb_CarrierStat";
            cb_CarrierStat.Size = new Size(78, 24);
            cb_CarrierStat.TabIndex = 25;
            cb_CarrierStat.VariableName = "CSTSTAT";
            // 
            // lb_TransportJobStatus
            // 
            lb_TransportJobStatus.AutoSize = true;
            lb_TransportJobStatus.Dock = DockStyle.Fill;
            lb_TransportJobStatus.Location = new Point(227, 0);
            lb_TransportJobStatus.Name = "lb_TransportJobStatus";
            tableLayoutPanel5.SetRowSpan(lb_TransportJobStatus, 2);
            lb_TransportJobStatus.Size = new Size(78, 60);
            lb_TransportJobStatus.TabIndex = 26;
            lb_TransportJobStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgv_RouteInfo
            // 
            tableLayoutPanel5.SetColumnSpan(dgv_RouteInfo, 2);
            dgv_RouteInfo.Dock = DockStyle.Fill;
            dgv_RouteInfo.Lb_Text = "SqlName";
            dgv_RouteInfo.Lb_Text2 = "";
            dgv_RouteInfo.Location = new Point(1081, 231);
            dgv_RouteInfo.Name = "dgv_RouteInfo";
            dgv_RouteInfo.Size = new Size(316, 246);
            dgv_RouteInfo.TabIndex = 27;
            // 
            // TransportJobList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel5);
            Name = "TransportJobList";
            Size = new Size(1400, 600);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel5;
        internal CheckBox ckb_Send;
        internal CheckBox ckb_Receive;
        internal CheckBox ckb_Delete;
        internal CheckBox ckb_IsFaulty;
        internal UserWinfromControl.UWC_LabelAndDateTimePicker lAdtp_TransList_StartDate;
        internal UserWinfromControl.UWC_LabelAndDateTimePicker lAdtp_TransList_EndDate;
        internal UserWinfromControl.UWC_TimerAndBtn tAbt_TransList_Search;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_TransList_CarrierId;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_TransList_ReqEqp;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_TransList_LaneId;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_TransList_ToEqp;
        internal UserWinfromControl.UWC_DataGridView dgv_CurrentTransportJobList;
        internal UserWinfromControl.UWC_DataGridView dgv_TransportJobHistory;
        internal UserWinfromControl.UWC_DataGridView dgv_CarrierInfomation;
        private CheckBox ckb_Abnormal;
        private CheckBox ckb_Moving;
        private CheckBox ckb_Cancel;
        private UserWinfromControl.UWC_ComboBox cb_CarrierStat;
        private Label lb_TransportJobStatus;
        private UserWinfromControl.UWC_DataGridView dgv_RouteInfo;
    }
}
