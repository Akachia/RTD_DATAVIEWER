namespace RTD_DataViewer.View
{
    partial class EqpState
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
            dgv_EqpState = new UserWinfromControl.UWC_DataGridView();
            dgv_PortState = new UserWinfromControl.UWC_DataGridView();
            clb_EqpGroupList = new CheckedListBox();
            bt_EqpStateSearch = new Button();
            bt_GetEqpGroup = new Button();
            dgv_PortStateHist = new UserWinfromControl.UWC_DataGridView();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 10;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Controls.Add(dgv_EqpState, 0, 1);
            tableLayoutPanel1.Controls.Add(dgv_PortState, 6, 1);
            tableLayoutPanel1.Controls.Add(clb_EqpGroupList, 9, 2);
            tableLayoutPanel1.Controls.Add(bt_EqpStateSearch, 9, 0);
            tableLayoutPanel1.Controls.Add(bt_GetEqpGroup, 9, 1);
            tableLayoutPanel1.Controls.Add(dgv_PortStateHist, 6, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1400, 600);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // dgv_EqpState
            // 
            tableLayoutPanel1.SetColumnSpan(dgv_EqpState, 6);
            dgv_EqpState.Dock = DockStyle.Fill;
            dgv_EqpState.Location = new Point(3, 33);
            dgv_EqpState.Name = "dgv_EqpState";
            tableLayoutPanel1.SetRowSpan(dgv_EqpState, 3);
            dgv_EqpState.Size = new Size(834, 564);
            dgv_EqpState.TabIndex = 0;
            // 
            // dgv_PortState
            // 
            tableLayoutPanel1.SetColumnSpan(dgv_PortState, 3);
            dgv_PortState.Dock = DockStyle.Fill;
            dgv_PortState.Location = new Point(843, 33);
            dgv_PortState.Name = "dgv_PortState";
            tableLayoutPanel1.SetRowSpan(dgv_PortState, 2);
            dgv_PortState.Size = new Size(414, 186);
            dgv_PortState.TabIndex = 2;
            // 
            // clb_EqpGroupList
            // 
            clb_EqpGroupList.Dock = DockStyle.Fill;
            clb_EqpGroupList.FormattingEnabled = true;
            clb_EqpGroupList.Location = new Point(1263, 63);
            clb_EqpGroupList.Name = "clb_EqpGroupList";
            tableLayoutPanel1.SetRowSpan(clb_EqpGroupList, 2);
            clb_EqpGroupList.Size = new Size(134, 534);
            clb_EqpGroupList.TabIndex = 3;
            // 
            // bt_EqpStateSearch
            // 
            bt_EqpStateSearch.Dock = DockStyle.Fill;
            bt_EqpStateSearch.Location = new Point(1263, 3);
            bt_EqpStateSearch.Name = "bt_EqpStateSearch";
            bt_EqpStateSearch.Size = new Size(134, 24);
            bt_EqpStateSearch.TabIndex = 4;
            bt_EqpStateSearch.Text = "Search";
            bt_EqpStateSearch.UseVisualStyleBackColor = true;
            bt_EqpStateSearch.Click += bt_EqpStateSearch_Click;
            // 
            // bt_GetEqpGroup
            // 
            bt_GetEqpGroup.Dock = DockStyle.Fill;
            bt_GetEqpGroup.Location = new Point(1263, 33);
            bt_GetEqpGroup.Name = "bt_GetEqpGroup";
            bt_GetEqpGroup.Size = new Size(134, 24);
            bt_GetEqpGroup.TabIndex = 5;
            bt_GetEqpGroup.Text = "Get EqpGroup";
            bt_GetEqpGroup.UseVisualStyleBackColor = true;
            bt_GetEqpGroup.Click += bt_GetEqpGroup_Click;
            // 
            // dgv_PortStateHist
            // 
            tableLayoutPanel1.SetColumnSpan(dgv_PortStateHist, 3);
            dgv_PortStateHist.Dock = DockStyle.Fill;
            dgv_PortStateHist.Location = new Point(843, 225);
            dgv_PortStateHist.Name = "dgv_PortStateHist";
            dgv_PortStateHist.Size = new Size(414, 372);
            dgv_PortStateHist.TabIndex = 6;
            // 
            // EqpState
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "EqpState";
            Size = new Size(1400, 600);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private UserWinfromControl.UWC_DataGridView dgv_EqpState;
        private UserWinfromControl.UWC_DataGridView dgv_PortState;
        private CheckedListBox clb_EqpGroupList;
        private Button bt_EqpStateSearch;
        private Button bt_GetEqpGroup;
        private UserWinfromControl.UWC_DataGridView dgv_PortStateHist;
    }
}
