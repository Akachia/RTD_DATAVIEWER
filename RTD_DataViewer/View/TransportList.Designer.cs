namespace RTD_DataViewer.View
{
    partial class TransportList
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
            tableLayoutPanel5.SuspendLayout();
            SuspendLayout();
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
            tableLayoutPanel5.Location = new Point(0, 0);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 4;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 110F));
            tableLayoutPanel5.Size = new Size(1400, 600);
            tableLayoutPanel5.TabIndex = 1;
            // 
            // cb_Cststat
            // 
            cb_Cststat.Dock = DockStyle.Fill;
            cb_Cststat.FormattingEnabled = true;
            cb_Cststat.Items.AddRange(new object[] { "모두 : ALL", "공트레이 : E", "실트레이 : U" });
            cb_Cststat.Location = new Point(773, 3);
            cb_Cststat.Name = "cb_Cststat";
            cb_Cststat.Size = new Size(106, 23);
            cb_Cststat.TabIndex = 7;
            // 
            // ckb_IsValidTransfer
            // 
            ckb_IsValidTransfer.AutoSize = true;
            ckb_IsValidTransfer.Checked = true;
            ckb_IsValidTransfer.CheckState = CheckState.Checked;
            ckb_IsValidTransfer.Dock = DockStyle.Fill;
            ckb_IsValidTransfer.Location = new Point(549, 3);
            ckb_IsValidTransfer.Name = "ckb_IsValidTransfer";
            ckb_IsValidTransfer.RightToLeft = RightToLeft.Yes;
            ckb_IsValidTransfer.Size = new Size(106, 24);
            ckb_IsValidTransfer.TabIndex = 8;
            ckb_IsValidTransfer.Text = "유효반송";
            ckb_IsValidTransfer.UseVisualStyleBackColor = true;
            // 
            // ckb_IsAbnormal
            // 
            ckb_IsAbnormal.AutoSize = true;
            ckb_IsAbnormal.Dock = DockStyle.Fill;
            ckb_IsAbnormal.Location = new Point(661, 3);
            ckb_IsAbnormal.Name = "ckb_IsAbnormal";
            ckb_IsAbnormal.RightToLeft = RightToLeft.Yes;
            ckb_IsAbnormal.Size = new Size(106, 24);
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
            ckb_IsExceptDelete.Location = new Point(549, 33);
            ckb_IsExceptDelete.Name = "ckb_IsExceptDelete";
            ckb_IsExceptDelete.RightToLeft = RightToLeft.Yes;
            ckb_IsExceptDelete.Size = new Size(106, 24);
            ckb_IsExceptDelete.TabIndex = 10;
            ckb_IsExceptDelete.Text = "DELETE 제외";
            ckb_IsExceptDelete.UseVisualStyleBackColor = true;
            // 
            // ckb_IsFaulty
            // 
            ckb_IsFaulty.AutoSize = true;
            ckb_IsFaulty.Dock = DockStyle.Fill;
            ckb_IsFaulty.Location = new Point(661, 33);
            ckb_IsFaulty.Name = "ckb_IsFaulty";
            ckb_IsFaulty.RightToLeft = RightToLeft.Yes;
            ckb_IsFaulty.Size = new Size(106, 24);
            ckb_IsFaulty.TabIndex = 11;
            ckb_IsFaulty.Text = "불량적재";
            ckb_IsFaulty.UseVisualStyleBackColor = true;
            // 
            // lAdtp_TransList_StartDate
            // 
            lAdtp_TransList_StartDate.Dock = DockStyle.Fill;
            lAdtp_TransList_StartDate.Dtp_Value = new DateTime(2023, 11, 27, 10, 20, 54, 324);
            lAdtp_TransList_StartDate.Lb_Text = "시작 시간";
            lAdtp_TransList_StartDate.Location = new Point(269, 3);
            lAdtp_TransList_StartDate.Name = "lAdtp_TransList_StartDate";
            lAdtp_TransList_StartDate.Size = new Size(274, 24);
            lAdtp_TransList_StartDate.TabIndex = 12;
            // 
            // lAdtp_TransList_EndDate
            // 
            lAdtp_TransList_EndDate.Dock = DockStyle.Fill;
            lAdtp_TransList_EndDate.Dtp_Value = new DateTime(2023, 11, 27, 10, 20, 56, 692);
            lAdtp_TransList_EndDate.Lb_Text = "종료 시간";
            lAdtp_TransList_EndDate.Location = new Point(269, 33);
            lAdtp_TransList_EndDate.Name = "lAdtp_TransList_EndDate";
            lAdtp_TransList_EndDate.Size = new Size(274, 24);
            lAdtp_TransList_EndDate.TabIndex = 13;
            // 
            // tAbt_TransList_Search
            // 
            tAbt_TransList_Search.Dock = DockStyle.Fill;
            tAbt_TransList_Search.Interval = 20;
            tAbt_TransList_Search.IsUseTimer = false;
            tAbt_TransList_Search.Location = new Point(1221, 3);
            tAbt_TransList_Search.Name = "tAbt_TransList_Search";
            tableLayoutPanel5.SetRowSpan(tAbt_TransList_Search, 2);
            tAbt_TransList_Search.Size = new Size(176, 54);
            tAbt_TransList_Search.TabIndex = 14;
            // 
            // lAtb_TransList_CarrierId
            // 
            lAtb_TransList_CarrierId.Dock = DockStyle.Fill;
            lAtb_TransList_CarrierId.Lb_Text = "Carrier ID";
            lAtb_TransList_CarrierId.Location = new Point(885, 3);
            lAtb_TransList_CarrierId.Name = "lAtb_TransList_CarrierId";
            lAtb_TransList_CarrierId.Size = new Size(162, 24);
            lAtb_TransList_CarrierId.TabIndex = 15;
            lAtb_TransList_CarrierId.Tb_Text = "";
            // 
            // lAtb_TransList_ReqEqp
            // 
            lAtb_TransList_ReqEqp.Dock = DockStyle.Fill;
            lAtb_TransList_ReqEqp.Lb_Text = "출발지 설비";
            lAtb_TransList_ReqEqp.Location = new Point(1053, 3);
            lAtb_TransList_ReqEqp.Name = "lAtb_TransList_ReqEqp";
            lAtb_TransList_ReqEqp.Size = new Size(162, 24);
            lAtb_TransList_ReqEqp.TabIndex = 16;
            lAtb_TransList_ReqEqp.Tb_Text = "";
            // 
            // lAtb_TransList_LaneId
            // 
            lAtb_TransList_LaneId.Dock = DockStyle.Fill;
            lAtb_TransList_LaneId.Lb_Text = "Lane ID";
            lAtb_TransList_LaneId.Location = new Point(885, 33);
            lAtb_TransList_LaneId.Name = "lAtb_TransList_LaneId";
            lAtb_TransList_LaneId.Size = new Size(162, 24);
            lAtb_TransList_LaneId.TabIndex = 17;
            lAtb_TransList_LaneId.Tb_Text = "";
            // 
            // lAtb_TransList_ToEqp
            // 
            lAtb_TransList_ToEqp.Dock = DockStyle.Fill;
            lAtb_TransList_ToEqp.Lb_Text = "목적지 설비";
            lAtb_TransList_ToEqp.Location = new Point(1053, 33);
            lAtb_TransList_ToEqp.Name = "lAtb_TransList_ToEqp";
            lAtb_TransList_ToEqp.Size = new Size(162, 24);
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
            transList_dgvReq.Size = new Size(1044, 534);
            transList_dgvReq.TabIndex = 19;
            // 
            // transList_CstHist
            // 
            tableLayoutPanel5.SetColumnSpan(transList_CstHist, 2);
            transList_CstHist.Dock = DockStyle.Fill;
            transList_CstHist.Location = new Point(1053, 63);
            transList_CstHist.Name = "transList_CstHist";
            transList_CstHist.Size = new Size(344, 424);
            transList_CstHist.TabIndex = 20;
            // 
            // transList_CstInfo
            // 
            tableLayoutPanel5.SetColumnSpan(transList_CstInfo, 2);
            transList_CstInfo.Dock = DockStyle.Fill;
            transList_CstInfo.Location = new Point(1053, 493);
            transList_CstInfo.Name = "transList_CstInfo";
            transList_CstInfo.Size = new Size(344, 104);
            transList_CstInfo.TabIndex = 21;
            // 
            // TransportList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel5);
            Name = "TransportList";
            Size = new Size(1400, 600);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel5;
        internal ComboBox cb_Cststat;
        internal CheckBox ckb_IsValidTransfer;
        internal CheckBox ckb_IsAbnormal;
        internal CheckBox ckb_IsExceptDelete;
        internal CheckBox ckb_IsFaulty;
        internal UserWinfromControl.UWC_LabelAndDateTimePicker lAdtp_TransList_StartDate;
        internal UserWinfromControl.UWC_LabelAndDateTimePicker lAdtp_TransList_EndDate;
        internal UserWinfromControl.UWC_TimerAndBtn tAbt_TransList_Search;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_TransList_CarrierId;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_TransList_ReqEqp;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_TransList_LaneId;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_TransList_ToEqp;
        internal UserWinfromControl.UWC_DataGridView transList_dgvReq;
        internal UserWinfromControl.UWC_DataGridView transList_CstHist;
        internal UserWinfromControl.UWC_DataGridView transList_CstInfo;
    }
}
