namespace RTD_DataViewer.View
{
    partial class StockerInventorySituation
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
            bt_Search = new Button();
            cb_StockerGroupList = new ComboBox();
            cb_TrfStatCode = new ComboBox();
            uwC_LabelAndTextBox1 = new UserWinfromControl.UWC_LabelAndTextBox();
            cb_Cststat = new UserWinfromControl.UWC_ComboBox();
            dgv_StockerInventory = new UserWinfromControl.UWC_DataGridView();
            dgv_StockerCurrState = new UserWinfromControl.UWC_DataGridView();
            dgv_TransportJobInfomation = new UserWinfromControl.UWC_DataGridView();
            bt_GetStockerGroupList = new Button();
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
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Controls.Add(bt_Search, 9, 0);
            tableLayoutPanel1.Controls.Add(cb_StockerGroupList, 8, 0);
            tableLayoutPanel1.Controls.Add(cb_TrfStatCode, 5, 0);
            tableLayoutPanel1.Controls.Add(uwC_LabelAndTextBox1, 6, 0);
            tableLayoutPanel1.Controls.Add(cb_Cststat, 7, 0);
            tableLayoutPanel1.Controls.Add(dgv_StockerInventory, 0, 1);
            tableLayoutPanel1.Controls.Add(dgv_StockerCurrState, 6, 1);
            tableLayoutPanel1.Controls.Add(dgv_TransportJobInfomation, 0, 3);
            tableLayoutPanel1.Controls.Add(bt_GetStockerGroupList, 9, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 110F));
            tableLayoutPanel1.Size = new Size(1400, 600);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // bt_Search
            // 
            bt_Search.Dock = DockStyle.Fill;
            bt_Search.Location = new Point(1263, 3);
            bt_Search.Name = "bt_Search";
            bt_Search.Size = new Size(134, 24);
            bt_Search.TabIndex = 2;
            bt_Search.Text = "Search";
            bt_Search.UseVisualStyleBackColor = true;
            bt_Search.Click += bt_Search_Click;
            // 
            // cb_StockerGroupList
            // 
            cb_StockerGroupList.Dock = DockStyle.Fill;
            cb_StockerGroupList.FormattingEnabled = true;
            cb_StockerGroupList.Location = new Point(1088, 3);
            cb_StockerGroupList.Name = "cb_StockerGroupList";
            cb_StockerGroupList.Size = new Size(169, 23);
            cb_StockerGroupList.TabIndex = 3;
            // 
            // cb_TrfStatCode
            // 
            cb_TrfStatCode.Dock = DockStyle.Fill;
            cb_TrfStatCode.FormattingEnabled = true;
            cb_TrfStatCode.Items.AddRange(new object[] { "FINAL", "MOVING", "RESERVED" });
            cb_TrfStatCode.Location = new Point(703, 3);
            cb_TrfStatCode.Name = "cb_TrfStatCode";
            cb_TrfStatCode.Size = new Size(134, 23);
            cb_TrfStatCode.TabIndex = 9;
            cb_TrfStatCode.Text = "TRF_STAT_CODE";
            // 
            // uwC_LabelAndTextBox1
            // 
            uwC_LabelAndTextBox1.IsMultiInputTextControl = false;
            uwC_LabelAndTextBox1.Lb_Text = "Carrier_ID";
            uwC_LabelAndTextBox1.Location = new Point(843, 3);
            uwC_LabelAndTextBox1.Name = "uwC_LabelAndTextBox1";
            uwC_LabelAndTextBox1.Size = new Size(134, 24);
            uwC_LabelAndTextBox1.TabIndex = 11;
            uwC_LabelAndTextBox1.Tb_Text = "";
            uwC_LabelAndTextBox1.VariableName = "CSTID";
            // 
            // cb_Cststat
            // 
            cb_Cststat.ComboBoxSelectedIndex = -1;
            cb_Cststat.ComboBoxText = "";
            cb_Cststat.DataSource = null;
            cb_Cststat.Dock = DockStyle.Fill;
            cb_Cststat.Location = new Point(983, 3);
            cb_Cststat.Name = "cb_Cststat";
            cb_Cststat.Size = new Size(99, 24);
            cb_Cststat.TabIndex = 12;
            cb_Cststat.VariableName = "";
            // 
            // dgv_StockerInventory
            // 
            tableLayoutPanel1.SetColumnSpan(dgv_StockerInventory, 6);
            dgv_StockerInventory.Dock = DockStyle.Fill;
            dgv_StockerInventory.Lb_Text = "SqlName";
            dgv_StockerInventory.Lb_Text2 = "";
            dgv_StockerInventory.Location = new Point(3, 33);
            dgv_StockerInventory.Name = "dgv_StockerInventory";
            tableLayoutPanel1.SetRowSpan(dgv_StockerInventory, 2);
            dgv_StockerInventory.Size = new Size(834, 454);
            dgv_StockerInventory.TabIndex = 13;
            // 
            // dgv_StockerCurrState
            // 
            tableLayoutPanel1.SetColumnSpan(dgv_StockerCurrState, 3);
            dgv_StockerCurrState.Dock = DockStyle.Fill;
            dgv_StockerCurrState.Lb_Text = "SqlName";
            dgv_StockerCurrState.Lb_Text2 = "";
            dgv_StockerCurrState.Location = new Point(843, 33);
            dgv_StockerCurrState.Name = "dgv_StockerCurrState";
            tableLayoutPanel1.SetRowSpan(dgv_StockerCurrState, 2);
            dgv_StockerCurrState.Size = new Size(414, 454);
            dgv_StockerCurrState.TabIndex = 14;
            // 
            // dgv_TransportJobInfomation
            // 
            tableLayoutPanel1.SetColumnSpan(dgv_TransportJobInfomation, 10);
            dgv_TransportJobInfomation.Dock = DockStyle.Fill;
            dgv_TransportJobInfomation.Lb_Text = "SqlName";
            dgv_TransportJobInfomation.Lb_Text2 = "";
            dgv_TransportJobInfomation.Location = new Point(3, 493);
            dgv_TransportJobInfomation.Name = "dgv_TransportJobInfomation";
            dgv_TransportJobInfomation.Size = new Size(1394, 104);
            dgv_TransportJobInfomation.TabIndex = 15;
            // 
            // bt_GetStockerGroupList
            // 
            bt_GetStockerGroupList.Dock = DockStyle.Fill;
            bt_GetStockerGroupList.Location = new Point(1263, 33);
            bt_GetStockerGroupList.Name = "bt_GetStockerGroupList";
            bt_GetStockerGroupList.Size = new Size(134, 24);
            bt_GetStockerGroupList.TabIndex = 16;
            bt_GetStockerGroupList.Text = "GetStockerGroup";
            bt_GetStockerGroupList.UseVisualStyleBackColor = true;
            // 
            // StockerInventorySituation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "StockerInventorySituation";
            Size = new Size(1400, 600);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button bt_Search;
        private ComboBox cb_StockerGroupList;
        private ComboBox cb_TrfStatCode;
        private UserWinfromControl.UWC_LabelAndTextBox uwC_LabelAndTextBox1;
        private UserWinfromControl.UWC_ComboBox cb_Cststat;
        private UserWinfromControl.UWC_DataGridView dgv_StockerInventory;
        private UserWinfromControl.UWC_DataGridView dgv_StockerCurrState;
        private UserWinfromControl.UWC_DataGridView dgv_TransportJobInfomation;
        private Button bt_GetStockerGroupList;
    }
}
