namespace RTD_DataViewer
{
    partial class CarrierInfomationList
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
            dgv_CarrierInfomationList = new UserWinfromControl.UWC_DataGridView();
            bt_Search = new Button();
            uwC_CarrierId = new UserWinfromControl.UWC_LabelAndTextBox();
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
            tableLayoutPanel1.Controls.Add(dgv_CarrierInfomationList, 0, 1);
            tableLayoutPanel1.Controls.Add(bt_Search, 7, 0);
            tableLayoutPanel1.Controls.Add(uwC_CarrierId, 5, 0);
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
            // dgv_CarrierInfomationList
            // 
            tableLayoutPanel1.SetColumnSpan(dgv_CarrierInfomationList, 8);
            dgv_CarrierInfomationList.Dock = DockStyle.Fill;
            dgv_CarrierInfomationList.Lb_Text = "SqlName";
            dgv_CarrierInfomationList.Lb_Text2 = "";
            dgv_CarrierInfomationList.Location = new Point(3, 33);
            dgv_CarrierInfomationList.Name = "dgv_CarrierInfomationList";
            tableLayoutPanel1.SetRowSpan(dgv_CarrierInfomationList, 2);
            dgv_CarrierInfomationList.Size = new Size(1394, 564);
            dgv_CarrierInfomationList.TabIndex = 0;
            // 
            // bt_Search
            // 
            bt_Search.Dock = DockStyle.Fill;
            bt_Search.Location = new Point(1298, 3);
            bt_Search.Name = "bt_Search";
            bt_Search.Size = new Size(99, 24);
            bt_Search.TabIndex = 2;
            bt_Search.Text = "Search";
            bt_Search.UseVisualStyleBackColor = true;
            bt_Search.Click += bt_Search_Click;
            // 
            // uwC_CarrierId
            // 
            tableLayoutPanel1.SetColumnSpan(uwC_CarrierId, 2);
            uwC_CarrierId.Dock = DockStyle.Fill;
            uwC_CarrierId.IsMultiInputTextControl = true;
            uwC_CarrierId.Lb_Text = "CarrierId";
            uwC_CarrierId.Location = new Point(913, 3);
            uwC_CarrierId.Name = "uwC_CarrierId";
            uwC_CarrierId.Size = new Size(379, 24);
            uwC_CarrierId.TabIndex = 3;
            uwC_CarrierId.Tb_Text = "";
            uwC_CarrierId.VariableName = "CSTID";
            // 
            // CarrierInfomationList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "CarrierInfomationList";
            Size = new Size(1400, 600);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private UserWinfromControl.UWC_DataGridView dgv_CarrierInfomationList;
        private Button bt_Search;
        private UserWinfromControl.UWC_LabelAndTextBox uwC_CarrierId;
    }
}
