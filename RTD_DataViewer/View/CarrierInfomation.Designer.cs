namespace RTD_DataViewer.View
{
    partial class CarrierInfomation
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
            tableLayoutPanel1 = new TableLayoutPanel();
            dgv_CarrierActAbbreviatedRecord = new UserWinfromControl.UWC_DataGridView();
            dgv_CarrierInfomation = new UserWinfromControl.UWC_DataGridView();
            dgv_CarrierEventAbbreviatedRecord = new UserWinfromControl.UWC_DataGridView();
            bt_CstInfoSearch = new Button();
            latb_CarrierId = new UserWinfromControl.UWC_LabelAndTextBox();
            lb_MismatchMessage = new Label();
            ckb_ValidNgHist = new CheckBox();
            uwC_NumberUpDown1 = new UserWinfromControl.UWC_NumberUpDown();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 8;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.5F));
            tableLayoutPanel1.Controls.Add(dgv_CarrierActAbbreviatedRecord, 0, 2);
            tableLayoutPanel1.Controls.Add(dgv_CarrierInfomation, 0, 1);
            tableLayoutPanel1.Controls.Add(dgv_CarrierEventAbbreviatedRecord, 4, 2);
            tableLayoutPanel1.Controls.Add(bt_CstInfoSearch, 7, 0);
            tableLayoutPanel1.Controls.Add(latb_CarrierId, 6, 0);
            tableLayoutPanel1.Controls.Add(lb_MismatchMessage, 0, 0);
            tableLayoutPanel1.Controls.Add(ckb_ValidNgHist, 4, 0);
            tableLayoutPanel1.Controls.Add(uwC_NumberUpDown1, 5, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.Size = new Size(1400, 600);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // dgv_CarrierActAbbreviatedRecord
            // 
            tableLayoutPanel1.SetColumnSpan(dgv_CarrierActAbbreviatedRecord, 4);
            dgv_CarrierActAbbreviatedRecord.Dock = DockStyle.Fill;
            dgv_CarrierActAbbreviatedRecord.Lb_Text = "SqlName";
            dgv_CarrierActAbbreviatedRecord.Lb_Text2 = "";
            dgv_CarrierActAbbreviatedRecord.Location = new Point(3, 204);
            dgv_CarrierActAbbreviatedRecord.Name = "dgv_CarrierActAbbreviatedRecord";
            dgv_CarrierActAbbreviatedRecord.Size = new Size(834, 393);
            dgv_CarrierActAbbreviatedRecord.TabIndex = 0;
            // 
            // dgv_CarrierInfomation
            // 
            tableLayoutPanel1.SetColumnSpan(dgv_CarrierInfomation, 8);
            dgv_CarrierInfomation.Dock = DockStyle.Fill;
            dgv_CarrierInfomation.Lb_Text = "SqlName";
            dgv_CarrierInfomation.Lb_Text2 = "";
            dgv_CarrierInfomation.Location = new Point(3, 33);
            dgv_CarrierInfomation.Name = "dgv_CarrierInfomation";
            dgv_CarrierInfomation.Size = new Size(1394, 165);
            dgv_CarrierInfomation.TabIndex = 1;
            // 
            // dgv_CarrierEventAbbreviatedRecord
            // 
            tableLayoutPanel1.SetColumnSpan(dgv_CarrierEventAbbreviatedRecord, 4);
            dgv_CarrierEventAbbreviatedRecord.Dock = DockStyle.Fill;
            dgv_CarrierEventAbbreviatedRecord.Lb_Text = "SqlName";
            dgv_CarrierEventAbbreviatedRecord.Lb_Text2 = "";
            dgv_CarrierEventAbbreviatedRecord.Location = new Point(843, 204);
            dgv_CarrierEventAbbreviatedRecord.Name = "dgv_CarrierEventAbbreviatedRecord";
            dgv_CarrierEventAbbreviatedRecord.Size = new Size(554, 393);
            dgv_CarrierEventAbbreviatedRecord.TabIndex = 2;
            // 
            // bt_CstInfoSearch
            // 
            bt_CstInfoSearch.Dock = DockStyle.Fill;
            bt_CstInfoSearch.Location = new Point(1298, 3);
            bt_CstInfoSearch.Name = "bt_CstInfoSearch";
            bt_CstInfoSearch.Size = new Size(99, 24);
            bt_CstInfoSearch.TabIndex = 4;
            bt_CstInfoSearch.Text = "Search";
            bt_CstInfoSearch.UseVisualStyleBackColor = true;
            bt_CstInfoSearch.Click += bt_CstInfoSearch_Click;
            // 
            // latb_CarrierId
            // 
            latb_CarrierId.Dock = DockStyle.Fill;
            latb_CarrierId.IsMultiInputTextControl = false;
            latb_CarrierId.Lb_Text = "DURABLE_ID";
            latb_CarrierId.Location = new Point(1088, 3);
            latb_CarrierId.Name = "latb_CarrierId";
            latb_CarrierId.Size = new Size(204, 24);
            latb_CarrierId.TabIndex = 3;
            latb_CarrierId.Tb_Text = "";
            latb_CarrierId.VariableName = "DURABLE_ID";
            // 
            // lb_MismatchMessage
            // 
            lb_MismatchMessage.AutoSize = true;
            lb_MismatchMessage.Dock = DockStyle.Fill;
            lb_MismatchMessage.Location = new Point(3, 0);
            lb_MismatchMessage.Name = "lb_MismatchMessage";
            lb_MismatchMessage.Size = new Size(274, 30);
            lb_MismatchMessage.TabIndex = 6;
            lb_MismatchMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ckb_ValidNgHist
            // 
            ckb_ValidNgHist.AutoSize = true;
            ckb_ValidNgHist.Dock = DockStyle.Fill;
            ckb_ValidNgHist.Location = new Point(843, 3);
            ckb_ValidNgHist.Name = "ckb_ValidNgHist";
            ckb_ValidNgHist.RightToLeft = RightToLeft.Yes;
            ckb_ValidNgHist.Size = new Size(169, 24);
            ckb_ValidNgHist.TabIndex = 5;
            ckb_ValidNgHist.Text = "입고 불허 조회";
            ckb_ValidNgHist.UseVisualStyleBackColor = true;
            // 
            // uwC_NumberUpDown1
            // 
            uwC_NumberUpDown1.Dock = DockStyle.Fill;
            uwC_NumberUpDown1.Location = new Point(1018, 3);
            uwC_NumberUpDown1.Name = "uwC_NumberUpDown1";
            uwC_NumberUpDown1.Number = 40;
            uwC_NumberUpDown1.Size = new Size(64, 24);
            uwC_NumberUpDown1.TabIndex = 7;
            uwC_NumberUpDown1.VariableName = "TOPNUMBER";
            // 
            // CarrierInfomation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "CarrierInfomation";
            Size = new Size(1400, 600);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private UserWinfromControl.UWC_DataGridView dgv_CarrierActAbbreviatedRecord;
        private UserWinfromControl.UWC_DataGridView dgv_CarrierInfomation;
        private UserWinfromControl.UWC_DataGridView dgv_CarrierEventAbbreviatedRecord;
        private UserWinfromControl.UWC_LabelAndTextBox latb_CarrierId;
        private Button bt_CstInfoSearch;
        private CheckBox ckb_ValidNgHist;
        private Label lb_MismatchMessage;
        private UserWinfromControl.UWC_NumberUpDown uwC_NumberUpDown1;
    }
}
