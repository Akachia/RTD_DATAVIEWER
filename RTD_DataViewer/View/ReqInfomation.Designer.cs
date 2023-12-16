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
            tAbt_ReqInfo_Search = new UserWinfromControl.UWC_TimerAndBtn();
            lAtb_ReqInfo_ReqEqp = new UserWinfromControl.UWC_LabelAndTextBox();
            lAtb_ReqInfo_RuleText = new UserWinfromControl.UWC_LabelAndTextBox();
            lAtb_ReqInfo_Cstid = new UserWinfromControl.UWC_LabelAndTextBox();
            lAdtp_ReqInfo_StartDate = new UserWinfromControl.UWC_LabelAndDateTimePicker();
            lAdtp_ReqInfo_EndDate = new UserWinfromControl.UWC_LabelAndDateTimePicker();
            tableLayoutPanel4.SuspendLayout();
            SuspendLayout();
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
            tableLayoutPanel4.Location = new Point(0, 0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 4;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 110F));
            tableLayoutPanel4.Size = new Size(1400, 600);
            tableLayoutPanel4.TabIndex = 1;
            // 
            // reqInfo_dgvReq
            // 
            tableLayoutPanel4.SetColumnSpan(reqInfo_dgvReq, 8);
            reqInfo_dgvReq.Dock = DockStyle.Fill;
            reqInfo_dgvReq.Location = new Point(3, 63);
            reqInfo_dgvReq.Name = "reqInfo_dgvReq";
            reqInfo_dgvReq.Size = new Size(1394, 424);
            reqInfo_dgvReq.TabIndex = 0;
            // 
            // reqInfo_DgvCarrier
            // 
            tableLayoutPanel4.SetColumnSpan(reqInfo_DgvCarrier, 8);
            reqInfo_DgvCarrier.Dock = DockStyle.Fill;
            reqInfo_DgvCarrier.Location = new Point(3, 493);
            reqInfo_DgvCarrier.Name = "reqInfo_DgvCarrier";
            reqInfo_DgvCarrier.Size = new Size(1394, 104);
            reqInfo_DgvCarrier.TabIndex = 1;
            // 
            // tAbt_ReqInfo_Search
            // 
            tAbt_ReqInfo_Search.Dock = DockStyle.Fill;
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
            lAtb_ReqInfo_ReqEqp.Dock = DockStyle.Fill;
            lAtb_ReqInfo_ReqEqp.Lb_Text = "요청 설비";
            lAtb_ReqInfo_ReqEqp.Location = new Point(1053, 3);
            lAtb_ReqInfo_ReqEqp.Name = "lAtb_ReqInfo_ReqEqp";
            lAtb_ReqInfo_ReqEqp.Size = new Size(162, 24);
            lAtb_ReqInfo_ReqEqp.TabIndex = 3;
            lAtb_ReqInfo_ReqEqp.Tb_Text = "";
            // 
            // lAtb_ReqInfo_RuleText
            // 
            lAtb_ReqInfo_RuleText.Dock = DockStyle.Fill;
            lAtb_ReqInfo_RuleText.Lb_Text = "Rule Name";
            lAtb_ReqInfo_RuleText.Location = new Point(1053, 33);
            lAtb_ReqInfo_RuleText.Name = "lAtb_ReqInfo_RuleText";
            lAtb_ReqInfo_RuleText.Size = new Size(162, 24);
            lAtb_ReqInfo_RuleText.TabIndex = 4;
            lAtb_ReqInfo_RuleText.Tb_Text = "";
            // 
            // lAtb_ReqInfo_Cstid
            // 
            lAtb_ReqInfo_Cstid.Dock = DockStyle.Fill;
            lAtb_ReqInfo_Cstid.Lb_Text = "Carrier ID";
            lAtb_ReqInfo_Cstid.Location = new Point(878, 3);
            lAtb_ReqInfo_Cstid.Name = "lAtb_ReqInfo_Cstid";
            lAtb_ReqInfo_Cstid.Size = new Size(169, 24);
            lAtb_ReqInfo_Cstid.TabIndex = 5;
            lAtb_ReqInfo_Cstid.Tb_Text = "";
            // 
            // lAdtp_ReqInfo_StartDate
            // 
            lAdtp_ReqInfo_StartDate.Dock = DockStyle.Fill;
            lAdtp_ReqInfo_StartDate.Dtp_Value = new DateTime(2023, 11, 27, 9, 43, 47, 506);
            lAdtp_ReqInfo_StartDate.Lb_Text = "시작 시간 ";
            lAdtp_ReqInfo_StartDate.Location = new Point(598, 3);
            lAdtp_ReqInfo_StartDate.Name = "lAdtp_ReqInfo_StartDate";
            lAdtp_ReqInfo_StartDate.Size = new Size(274, 24);
            lAdtp_ReqInfo_StartDate.TabIndex = 6;
            // 
            // lAdtp_ReqInfo_EndDate
            // 
            lAdtp_ReqInfo_EndDate.Dock = DockStyle.Fill;
            lAdtp_ReqInfo_EndDate.Dtp_Value = new DateTime(2023, 11, 27, 9, 43, 50, 385);
            lAdtp_ReqInfo_EndDate.Lb_Text = "종료 시간";
            lAdtp_ReqInfo_EndDate.Location = new Point(598, 33);
            lAdtp_ReqInfo_EndDate.Name = "lAdtp_ReqInfo_EndDate";
            lAdtp_ReqInfo_EndDate.Size = new Size(274, 24);
            lAdtp_ReqInfo_EndDate.TabIndex = 7;
            // 
            // ReqInfomation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel4);
            Name = "ReqInfomation";
            Size = new Size(1400, 600);
            tableLayoutPanel4.ResumeLayout(false);
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
    }
}
