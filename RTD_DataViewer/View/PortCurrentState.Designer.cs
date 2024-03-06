namespace RTD_DataViewer.View
{
    partial class PortCurrentState
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PortCurrentState));
            tableLayoutPanel1 = new TableLayoutPanel();
            dgv_PortCurrentList = new UserWinfromControl.UWC_DataGridView();
            dgv_PortEioRecord = new UserWinfromControl.UWC_DataGridView();
            bt_EqpStateSearch = new Button();
            bt_GetEqpGroup = new Button();
            dgv_PortStateRecord = new UserWinfromControl.UWC_DataGridView();
            lb_EqpGroupList = new UserWinfromControl.UWC_ListBox();
            clb_EquipmentList = new UserWinfromControl.UWC_CheckListBox();
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
            tableLayoutPanel1.Controls.Add(dgv_PortCurrentList, 0, 1);
            tableLayoutPanel1.Controls.Add(dgv_PortEioRecord, 6, 1);
            tableLayoutPanel1.Controls.Add(bt_EqpStateSearch, 9, 0);
            tableLayoutPanel1.Controls.Add(bt_GetEqpGroup, 9, 1);
            tableLayoutPanel1.Controls.Add(dgv_PortStateRecord, 6, 3);
            tableLayoutPanel1.Controls.Add(lb_EqpGroupList, 9, 2);
            tableLayoutPanel1.Controls.Add(clb_EquipmentList, 9, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.Size = new Size(1400, 600);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // dgv_PortCurrentList
            // 
            tableLayoutPanel1.SetColumnSpan(dgv_PortCurrentList, 6);
            dgv_PortCurrentList.Dock = DockStyle.Fill;
            dgv_PortCurrentList.Lb_Text = "SqlName";
            dgv_PortCurrentList.Lb_Text2 = "";
            dgv_PortCurrentList.Location = new Point(3, 33);
            dgv_PortCurrentList.Name = "dgv_PortCurrentList";
            tableLayoutPanel1.SetRowSpan(dgv_PortCurrentList, 3);
            dgv_PortCurrentList.Size = new Size(834, 564);
            dgv_PortCurrentList.TabIndex = 0;
            // 
            // dgv_PortEioRecord
            // 
            tableLayoutPanel1.SetColumnSpan(dgv_PortEioRecord, 3);
            dgv_PortEioRecord.Dock = DockStyle.Fill;
            dgv_PortEioRecord.Lb_Text = "SqlName";
            dgv_PortEioRecord.Lb_Text2 = "";
            dgv_PortEioRecord.Location = new Point(843, 33);
            dgv_PortEioRecord.Name = "dgv_PortEioRecord";
            tableLayoutPanel1.SetRowSpan(dgv_PortEioRecord, 2);
            dgv_PortEioRecord.Size = new Size(414, 240);
            dgv_PortEioRecord.TabIndex = 2;
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
            // dgv_PortStateRecord
            // 
            tableLayoutPanel1.SetColumnSpan(dgv_PortStateRecord, 3);
            dgv_PortStateRecord.Dock = DockStyle.Fill;
            dgv_PortStateRecord.Lb_Text = "SqlName";
            dgv_PortStateRecord.Lb_Text2 = "";
            dgv_PortStateRecord.Location = new Point(843, 279);
            dgv_PortStateRecord.Name = "dgv_PortStateRecord";
            dgv_PortStateRecord.Size = new Size(414, 318);
            dgv_PortStateRecord.TabIndex = 6;
            // 
            // lb_EqpGroupList
            // 
            lb_EqpGroupList.DataObject = resources.GetObject("lb_EqpGroupList.DataObject");
            lb_EqpGroupList.Dock = DockStyle.Fill;
            lb_EqpGroupList.Lb_Text = "EquipmentGroupList";
            lb_EqpGroupList.Location = new Point(1263, 63);
            lb_EqpGroupList.Name = "lb_EqpGroupList";
            lb_EqpGroupList.Size = new Size(134, 210);
            lb_EqpGroupList.TabIndex = 7;
            lb_EqpGroupList.VariableName = "EquipmentGroupList";
            // 
            // clb_EquipmentList
            // 
            clb_EquipmentList.DataObject = resources.GetObject("clb_EquipmentList.DataObject");
            clb_EquipmentList.Dock = DockStyle.Fill;
            clb_EquipmentList.Lb_Text = "EquipmentList";
            clb_EquipmentList.Location = new Point(1263, 279);
            clb_EquipmentList.Name = "clb_EquipmentList";
            clb_EquipmentList.Size = new Size(134, 318);
            clb_EquipmentList.TabIndex = 8;
            clb_EquipmentList.VariableName = "EquipmentList";
            // 
            // PortCurrentState
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "PortCurrentState";
            Size = new Size(1400, 600);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private UserWinfromControl.UWC_DataGridView dgv_PortCurrentList;
        private UserWinfromControl.UWC_DataGridView dgv_PortEioRecord;
        private Button bt_EqpStateSearch;
        private Button bt_GetEqpGroup;
        private UserWinfromControl.UWC_DataGridView dgv_PortStateRecord;
        private UserWinfromControl.UWC_ListBox lb_EqpGroupList;
        private UserWinfromControl.UWC_CheckListBox clb_EquipmentList;
    }
}
