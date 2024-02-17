namespace RTD_DataViewer.View
{
    partial class ReqInfomation
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
            tableLayoutPanel4 = new TableLayoutPanel();
            reqInfo_dgvReq = new UserWinfromControl.UWC_DataGridView();
            reqInfo_DgvCarrier = new UserWinfromControl.UWC_DataGridView();
            reqInfo_dgvReq_TrfInfo = new UserWinfromControl.UWC_DataGridView();
            tAbt_ReqInfo_Search = new UserWinfromControl.UWC_TimerAndBtn();
            lAtb_ReqInfo_ReqEqp = new UserWinfromControl.UWC_LabelAndTextBox();
            lAtb_ReqInfo_RuleText = new UserWinfromControl.UWC_LabelAndTextBox();
            lAtb_ReqInfo_Cstid = new UserWinfromControl.UWC_LabelAndTextBox();
            lAdtp_ReqInfo_StartDate = new UserWinfromControl.UWC_LabelAndDateTimePicker();
            lAdtp_ReqInfo_EndDate = new UserWinfromControl.UWC_LabelAndDateTimePicker();
            lb_TransferStatus = new Label();
            panel1 = new Panel();
            lb_CarrierInfoValidText = new Label();
            ckb_IsOpenReqSituation = new CheckBox();
            tv_SituationOrRuleResult = new TreeView();
            cb_CarrierState = new UserWinfromControl.UWC_ComboBox();
            cb_ReqState = new UserWinfromControl.UWC_ComboBox();
            tableLayoutPanel4.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 9;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13F));
            tableLayoutPanel4.Controls.Add(reqInfo_dgvReq, 0, 2);
            tableLayoutPanel4.Controls.Add(reqInfo_DgvCarrier, 3, 4);
            tableLayoutPanel4.Controls.Add(reqInfo_dgvReq_TrfInfo, 0, 3);
            tableLayoutPanel4.Controls.Add(tAbt_ReqInfo_Search, 8, 0);
            tableLayoutPanel4.Controls.Add(lAtb_ReqInfo_ReqEqp, 7, 0);
            tableLayoutPanel4.Controls.Add(lAtb_ReqInfo_RuleText, 7, 1);
            tableLayoutPanel4.Controls.Add(lAtb_ReqInfo_Cstid, 6, 0);
            tableLayoutPanel4.Controls.Add(lAdtp_ReqInfo_StartDate, 4, 0);
            tableLayoutPanel4.Controls.Add(lAdtp_ReqInfo_EndDate, 4, 1);
            tableLayoutPanel4.Controls.Add(lb_TransferStatus, 3, 0);
            tableLayoutPanel4.Controls.Add(panel1, 0, 4);
            tableLayoutPanel4.Controls.Add(ckb_IsOpenReqSituation, 5, 1);
            tableLayoutPanel4.Controls.Add(tv_SituationOrRuleResult, 8, 2);
            tableLayoutPanel4.Controls.Add(cb_CarrierState, 5, 0);
            tableLayoutPanel4.Controls.Add(cb_ReqState, 6, 1);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(0, 0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 6;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel4.Size = new Size(1400, 600);
            tableLayoutPanel4.TabIndex = 1;
            // 
            // reqInfo_dgvReq
            // 
            tableLayoutPanel4.SetColumnSpan(reqInfo_dgvReq, 8);
            reqInfo_dgvReq.Dock = DockStyle.Fill;
            reqInfo_dgvReq.Location = new Point(3, 63);
            reqInfo_dgvReq.Name = "reqInfo_dgvReq";
            reqInfo_dgvReq.Size = new Size(1212, 334);
            reqInfo_dgvReq.TabIndex = 0;
            // 
            // reqInfo_DgvCarrier
            // 
            tableLayoutPanel4.SetColumnSpan(reqInfo_DgvCarrier, 9);
            reqInfo_DgvCarrier.Dock = DockStyle.Fill;
            reqInfo_DgvCarrier.Location = new Point(3, 503);
            reqInfo_DgvCarrier.Name = "reqInfo_DgvCarrier";
            reqInfo_DgvCarrier.Size = new Size(1394, 94);
            reqInfo_DgvCarrier.TabIndex = 1;
            // 
            // reqInfo_dgvReq_TrfInfo
            // 
            tableLayoutPanel4.SetColumnSpan(reqInfo_dgvReq_TrfInfo, 8);
            reqInfo_dgvReq_TrfInfo.Dock = DockStyle.Fill;
            reqInfo_dgvReq_TrfInfo.Location = new Point(3, 403);
            reqInfo_dgvReq_TrfInfo.Name = "reqInfo_dgvReq_TrfInfo";
            reqInfo_dgvReq_TrfInfo.Size = new Size(1212, 74);
            reqInfo_dgvReq_TrfInfo.TabIndex = 8;
            // 
            // tAbt_ReqInfo_Search
            // 
            tAbt_ReqInfo_Search.Interval = 20;
            tAbt_ReqInfo_Search.IsUseTimer = false;
            tAbt_ReqInfo_Search.Location = new Point(1221, 3);
            tAbt_ReqInfo_Search.Name = "tAbt_ReqInfo_Search";
            tableLayoutPanel4.SetRowSpan(tAbt_ReqInfo_Search, 2);
            tAbt_ReqInfo_Search.Size = new Size(176, 54);
            tAbt_ReqInfo_Search.TabIndex = 2;
            // 
            // lAtb_ReqInfo_ReqEqp
            // 
            lAtb_ReqInfo_ReqEqp.Lb_Text = "EqptId";
            lAtb_ReqInfo_ReqEqp.Location = new Point(1053, 3);
            lAtb_ReqInfo_ReqEqp.Name = "lAtb_ReqInfo_ReqEqp";
            lAtb_ReqInfo_ReqEqp.Size = new Size(162, 24);
            lAtb_ReqInfo_ReqEqp.TabIndex = 3;
            lAtb_ReqInfo_ReqEqp.Tb_Text = "";
            lAtb_ReqInfo_ReqEqp.VariableName = "PORTID";
            // 
            // lAtb_ReqInfo_RuleText
            // 
            lAtb_ReqInfo_RuleText.Lb_Text = "Rule Name";
            lAtb_ReqInfo_RuleText.Location = new Point(1053, 33);
            lAtb_ReqInfo_RuleText.Name = "lAtb_ReqInfo_RuleText";
            lAtb_ReqInfo_RuleText.Size = new Size(162, 24);
            lAtb_ReqInfo_RuleText.TabIndex = 4;
            lAtb_ReqInfo_RuleText.Tb_Text = "";
            lAtb_ReqInfo_RuleText.VariableName = "RULEID";
            // 
            // lAtb_ReqInfo_Cstid
            // 
            lAtb_ReqInfo_Cstid.Lb_Text = "Carrier ID";
            lAtb_ReqInfo_Cstid.Location = new Point(885, 3);
            lAtb_ReqInfo_Cstid.Name = "lAtb_ReqInfo_Cstid";
            lAtb_ReqInfo_Cstid.Size = new Size(162, 24);
            lAtb_ReqInfo_Cstid.TabIndex = 5;
            lAtb_ReqInfo_Cstid.Tb_Text = "";
            lAtb_ReqInfo_Cstid.VariableName = "CSTID";
            // 
            // lAdtp_ReqInfo_StartDate
            // 
            lAdtp_ReqInfo_StartDate.Dock = DockStyle.Fill;
            lAdtp_ReqInfo_StartDate.Dtp_Value = new DateTime(2024, 2, 15, 0, 0, 0, 0);
            lAdtp_ReqInfo_StartDate.IsChecked = true;
            lAdtp_ReqInfo_StartDate.Lb_Text = "시작 시간 ";
            lAdtp_ReqInfo_StartDate.Location = new Point(521, 3);
            lAdtp_ReqInfo_StartDate.Name = "lAdtp_ReqInfo_StartDate";
            lAdtp_ReqInfo_StartDate.Size = new Size(274, 24);
            lAdtp_ReqInfo_StartDate.TabIndex = 6;
            lAdtp_ReqInfo_StartDate.VariableName = "StartTime";
            // 
            // lAdtp_ReqInfo_EndDate
            // 
            lAdtp_ReqInfo_EndDate.Dock = DockStyle.Fill;
            lAdtp_ReqInfo_EndDate.Dtp_Value = new DateTime(2024, 2, 15, 0, 0, 0, 0);
            lAdtp_ReqInfo_EndDate.IsChecked = false;
            lAdtp_ReqInfo_EndDate.Lb_Text = "종료 시간";
            lAdtp_ReqInfo_EndDate.Location = new Point(521, 33);
            lAdtp_ReqInfo_EndDate.Name = "lAdtp_ReqInfo_EndDate";
            lAdtp_ReqInfo_EndDate.Size = new Size(274, 24);
            lAdtp_ReqInfo_EndDate.TabIndex = 7;
            lAdtp_ReqInfo_EndDate.VariableName = "EndTime";
            // 
            // lb_TransferStatus
            // 
            lb_TransferStatus.AutoSize = true;
            lb_TransferStatus.Dock = DockStyle.Fill;
            lb_TransferStatus.Location = new Point(423, 0);
            lb_TransferStatus.Name = "lb_TransferStatus";
            tableLayoutPanel4.SetRowSpan(lb_TransferStatus, 2);
            lb_TransferStatus.Size = new Size(92, 60);
            lb_TransferStatus.TabIndex = 10;
            lb_TransferStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            tableLayoutPanel4.SetColumnSpan(panel1, 8);
            panel1.Controls.Add(lb_CarrierInfoValidText);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 483);
            panel1.Name = "panel1";
            panel1.Size = new Size(1212, 14);
            panel1.TabIndex = 13;
            // 
            // lb_CarrierInfoValidText
            // 
            lb_CarrierInfoValidText.AutoSize = true;
            lb_CarrierInfoValidText.Dock = DockStyle.Fill;
            lb_CarrierInfoValidText.Location = new Point(0, 0);
            lb_CarrierInfoValidText.Name = "lb_CarrierInfoValidText";
            lb_CarrierInfoValidText.Size = new Size(0, 15);
            lb_CarrierInfoValidText.TabIndex = 0;
            lb_CarrierInfoValidText.TextAlign = ContentAlignment.MiddleCenter;
            lb_CarrierInfoValidText.Click += label1_Click;
            // 
            // ckb_IsOpenReqSituation
            // 
            ckb_IsOpenReqSituation.AutoSize = true;
            ckb_IsOpenReqSituation.Dock = DockStyle.Fill;
            ckb_IsOpenReqSituation.Location = new Point(801, 33);
            ckb_IsOpenReqSituation.Name = "ckb_IsOpenReqSituation";
            ckb_IsOpenReqSituation.RightToLeft = RightToLeft.No;
            ckb_IsOpenReqSituation.Size = new Size(78, 24);
            ckb_IsOpenReqSituation.TabIndex = 14;
            ckb_IsOpenReqSituation.Text = "현황표";
            ckb_IsOpenReqSituation.TextAlign = ContentAlignment.MiddleCenter;
            ckb_IsOpenReqSituation.UseVisualStyleBackColor = true;
            // 
            // tv_SituationOrRuleResult
            // 
            tv_SituationOrRuleResult.Dock = DockStyle.Fill;
            tv_SituationOrRuleResult.Location = new Point(1221, 63);
            tv_SituationOrRuleResult.Name = "tv_SituationOrRuleResult";
            tableLayoutPanel4.SetRowSpan(tv_SituationOrRuleResult, 3);
            tv_SituationOrRuleResult.Size = new Size(176, 434);
            tv_SituationOrRuleResult.TabIndex = 15;
            // 
            // cb_CarrierState
            // 
            cb_CarrierState.ComboBoxSelectedIndex = -1;
            cb_CarrierState.ComboBoxText = "공/실";
            cb_CarrierState.DataSource = null;
            cb_CarrierState.Dock = DockStyle.Fill;
            cb_CarrierState.Location = new Point(801, 3);
            cb_CarrierState.Name = "cb_CarrierState";
            cb_CarrierState.Size = new Size(78, 24);
            cb_CarrierState.TabIndex = 16;
            cb_CarrierState.VariableName = "CSTSTAT";
            // 
            // cb_ReqState
            // 
            cb_ReqState.ComboBoxSelectedIndex = -1;
            cb_ReqState.ComboBoxText = "REQ_STAT_CODE";
            cb_ReqState.DataSource = null;
            cb_ReqState.Dock = DockStyle.Fill;
            cb_ReqState.Location = new Point(885, 33);
            cb_ReqState.Name = "cb_ReqState";
            cb_ReqState.Size = new Size(162, 24);
            cb_ReqState.TabIndex = 17;
            cb_ReqState.VariableName = "REQ_STAT_CODE";
            // 
            // ReqInfomation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel4);
            Name = "ReqInfomation";
            Size = new Size(1400, 600);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        internal TableLayoutPanel tableLayoutPanel4;
        internal UserWinfromControl.UWC_DataGridView reqInfo_dgvReq;
        internal UserWinfromControl.UWC_DataGridView reqInfo_DgvCarrier;
        internal UserWinfromControl.UWC_TimerAndBtn tAbt_ReqInfo_Search;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_ReqInfo_ReqEqp;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_ReqInfo_RuleText;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_ReqInfo_Cstid;
        internal UserWinfromControl.UWC_LabelAndDateTimePicker lAdtp_ReqInfo_StartDate;
        internal UserWinfromControl.UWC_LabelAndDateTimePicker lAdtp_ReqInfo_EndDate;
        private UserWinfromControl.UWC_DataGridView reqInfo_dgvReq_TrfInfo;
        private Label lb_TransferStatus;
        private Panel panel1;
        private Label lb_CarrierInfoValidText;
        private CheckBox ckb_IsOpenReqSituation;
        private TreeView tv_SituationOrRuleResult;
        private UserWinfromControl.UWC_ComboBox cb_CarrierState;
        private UserWinfromControl.UWC_ComboBox cb_ReqState;
    }
}
