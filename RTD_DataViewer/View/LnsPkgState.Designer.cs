namespace RTD_DataViewer
{
    partial class LnsPkgState
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
            dgv_LnsPkgLot = new UserWinfromControl.UWC_DataGridView();
            dgv_lnsPkgEqp = new UserWinfromControl.UWC_DataGridView();
            bt_LnsPkgSearch = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 8;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.5F));
            tableLayoutPanel1.Controls.Add(dgv_LnsPkgLot, 0, 2);
            tableLayoutPanel1.Controls.Add(dgv_lnsPkgEqp, 4, 2);
            tableLayoutPanel1.Controls.Add(bt_LnsPkgSearch, 7, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1400, 600);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // dgv_LnsPkgLot
            // 
            tableLayoutPanel1.SetColumnSpan(dgv_LnsPkgLot, 4);
            dgv_LnsPkgLot.Dock = DockStyle.Fill;
            dgv_LnsPkgLot.Location = new Point(3, 63);
            dgv_LnsPkgLot.Name = "dgv_LnsPkgLot";
            dgv_LnsPkgLot.Size = new Size(694, 534);
            dgv_LnsPkgLot.TabIndex = 0;
            // 
            // dgv_lnsPkgEqp
            // 
            tableLayoutPanel1.SetColumnSpan(dgv_lnsPkgEqp, 4);
            dgv_lnsPkgEqp.Dock = DockStyle.Fill;
            dgv_lnsPkgEqp.Location = new Point(703, 63);
            dgv_lnsPkgEqp.Name = "dgv_lnsPkgEqp";
            dgv_lnsPkgEqp.Size = new Size(694, 534);
            dgv_lnsPkgEqp.TabIndex = 1;
            // 
            // bt_LnsPkgSearch
            // 
            bt_LnsPkgSearch.Dock = DockStyle.Fill;
            bt_LnsPkgSearch.Location = new Point(1298, 33);
            bt_LnsPkgSearch.Name = "bt_LnsPkgSearch";
            bt_LnsPkgSearch.Size = new Size(99, 24);
            bt_LnsPkgSearch.TabIndex = 2;
            bt_LnsPkgSearch.Text = "Search";
            bt_LnsPkgSearch.UseVisualStyleBackColor = true;
            bt_LnsPkgSearch.Click += bt_LnsPkgSearch_Click;
            // 
            // LnsPkgState
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "LnsPkgState";
            Size = new Size(1400, 600);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private UserWinfromControl.UWC_DataGridView dgv_LnsPkgLot;
        private UserWinfromControl.UWC_DataGridView dgv_lnsPkgEqp;
        private Button bt_LnsPkgSearch;
    }
}
