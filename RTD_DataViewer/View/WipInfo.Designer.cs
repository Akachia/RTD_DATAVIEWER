namespace RTD_DataViewer.View
{
    partial class WipInfo
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
            lb_MismatchMessage = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            bt_CstInfoSearch = new Button();
            ckb_ValidNgHist = new CheckBox();
            label1 = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lb_MismatchMessage
            // 
            lb_MismatchMessage.AutoSize = true;
            lb_MismatchMessage.Dock = DockStyle.Fill;
            lb_MismatchMessage.Location = new Point(0, 0);
            lb_MismatchMessage.Name = "lb_MismatchMessage";
            lb_MismatchMessage.Size = new Size(0, 15);
            lb_MismatchMessage.TabIndex = 7;
            lb_MismatchMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 8;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.5F));
            tableLayoutPanel1.Controls.Add(bt_CstInfoSearch, 7, 0);
            tableLayoutPanel1.Controls.Add(ckb_ValidNgHist, 5, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.Size = new Size(1400, 600);
            tableLayoutPanel1.TabIndex = 8;
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
            // 
            // ckb_ValidNgHist
            // 
            ckb_ValidNgHist.AutoSize = true;
            ckb_ValidNgHist.Dock = DockStyle.Fill;
            ckb_ValidNgHist.Location = new Point(878, 3);
            ckb_ValidNgHist.Name = "ckb_ValidNgHist";
            ckb_ValidNgHist.RightToLeft = RightToLeft.Yes;
            ckb_ValidNgHist.Size = new Size(204, 24);
            ckb_ValidNgHist.TabIndex = 5;
            ckb_ValidNgHist.Text = "입고 불허 조회";
            ckb_ValidNgHist.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(274, 30);
            label1.TabIndex = 6;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // WipInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Controls.Add(lb_MismatchMessage);
            Name = "WipInfo";
            Size = new Size(1400, 600);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lb_MismatchMessage;
        private TableLayoutPanel tableLayoutPanel1;
        private UserWinfromControl.UWC_DataGridView dgv_LotActHist;
        private UserWinfromControl.UWC_DataGridView dgv_LotInfo;
        private UserWinfromControl.UWC_DataGridView dgv_LotHist;
        private Button bt_CstInfoSearch;
        private UserWinfromControl.UWC_LabelAndTextBox latb_LotId;
        private CheckBox ckb_ValidNgHist;
        private Label label1;
    }
}
