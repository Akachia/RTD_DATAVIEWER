namespace RTD_DataViewer.View
{
    partial class EquipmentCurrentState
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EquipmentCurrentState));
            tableLayoutPanel1 = new TableLayoutPanel();
            dgv_EquipmentCurrentState = new UserWinfromControl.UWC_DataGridView();
            dgv_EquipmentStateHistory = new UserWinfromControl.UWC_DataGridView();
            bt_EqpStateSearch = new Button();
            bt_GetEqpGroup = new Button();
            dgv_EquipmentStateHist = new UserWinfromControl.UWC_DataGridView();
            clb_EquipmentGroupList = new UserWinfromControl.UWC_CheckListBox();
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
            tableLayoutPanel1.Controls.Add(dgv_EquipmentCurrentState, 0, 1);
            tableLayoutPanel1.Controls.Add(dgv_EquipmentStateHistory, 6, 1);
            tableLayoutPanel1.Controls.Add(bt_EqpStateSearch, 9, 0);
            tableLayoutPanel1.Controls.Add(bt_GetEqpGroup, 9, 1);
            tableLayoutPanel1.Controls.Add(dgv_EquipmentStateHist, 6, 3);
            tableLayoutPanel1.Controls.Add(clb_EquipmentGroupList, 9, 2);
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
            // dgv_EquipmentCurrentState
            // 
            tableLayoutPanel1.SetColumnSpan(dgv_EquipmentCurrentState, 6);
            dgv_EquipmentCurrentState.Dock = DockStyle.Fill;
            dgv_EquipmentCurrentState.Lb_Text = "SqlName";
            dgv_EquipmentCurrentState.Lb_Text2 = "";
            dgv_EquipmentCurrentState.Location = new Point(3, 33);
            dgv_EquipmentCurrentState.Name = "dgv_EquipmentCurrentState";
            tableLayoutPanel1.SetRowSpan(dgv_EquipmentCurrentState, 3);
            dgv_EquipmentCurrentState.Size = new Size(834, 564);
            dgv_EquipmentCurrentState.TabIndex = 0;
            // 
            // dgv_EquipmentStateHistory
            // 
            tableLayoutPanel1.SetColumnSpan(dgv_EquipmentStateHistory, 3);
            dgv_EquipmentStateHistory.Dock = DockStyle.Fill;
            dgv_EquipmentStateHistory.Lb_Text = "SqlName";
            dgv_EquipmentStateHistory.Lb_Text2 = "";
            dgv_EquipmentStateHistory.Location = new Point(843, 33);
            dgv_EquipmentStateHistory.Name = "dgv_EquipmentStateHistory";
            tableLayoutPanel1.SetRowSpan(dgv_EquipmentStateHistory, 2);
            dgv_EquipmentStateHistory.Size = new Size(414, 186);
            dgv_EquipmentStateHistory.TabIndex = 2;
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
            // dgv_EquipmentStateHist
            // 
            tableLayoutPanel1.SetColumnSpan(dgv_EquipmentStateHist, 3);
            dgv_EquipmentStateHist.Dock = DockStyle.Fill;
            dgv_EquipmentStateHist.Lb_Text = "SqlName";
            dgv_EquipmentStateHist.Lb_Text2 = "";
            dgv_EquipmentStateHist.Location = new Point(843, 225);
            dgv_EquipmentStateHist.Name = "dgv_EquipmentStateHist";
            dgv_EquipmentStateHist.Size = new Size(414, 372);
            dgv_EquipmentStateHist.TabIndex = 6;
            // 
            // clb_EquipmentGroupList
            // 
            clb_EquipmentGroupList.DataObject = resources.GetObject("clb_EquipmentGroupList.DataObject");
            clb_EquipmentGroupList.Dock = DockStyle.Fill;
            clb_EquipmentGroupList.Lb_Text = "EquipmentGroupList";
            clb_EquipmentGroupList.Location = new Point(1263, 63);
            clb_EquipmentGroupList.Name = "clb_EquipmentGroupList";
            tableLayoutPanel1.SetRowSpan(clb_EquipmentGroupList, 2);
            clb_EquipmentGroupList.Size = new Size(134, 534);
            clb_EquipmentGroupList.TabIndex = 7;
            clb_EquipmentGroupList.VariableName = "EquipmentGroupList";
            // 
            // EquipmentCurrentState
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "EquipmentCurrentState";
            Size = new Size(1400, 600);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private UserWinfromControl.UWC_DataGridView dgv_EquipmentCurrentState;
        private UserWinfromControl.UWC_DataGridView dgv_EquipmentStateHistory;
        private Button bt_EqpStateSearch;
        private Button bt_GetEqpGroup;
        private UserWinfromControl.UWC_DataGridView dgv_EquipmentStateHist;
        private UserWinfromControl.UWC_CheckListBox clb_EquipmentGroupList;
    }
}
