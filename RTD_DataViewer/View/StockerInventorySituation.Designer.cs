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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockerInventorySituation));
            tableLayoutPanel1 = new TableLayoutPanel();
            bt_Search = new Button();
            dgv_StockerInventory = new UserWinfromControl.UWC_DataGridView();
            dgv_StockerCurrState = new UserWinfromControl.UWC_DataGridView();
            dgv_TransportJobInfomation = new UserWinfromControl.UWC_DataGridView();
            bt_GetStockerGroupList = new Button();
            cb_CarrierStat = new UserWinfromControl.UWC_ComboBox();
            tb_CarrierId = new UserWinfromControl.UWC_LabelAndTextBox();
            cb_TrfStatCode = new UserWinfromControl.UWC_ComboBox();
            clb_StockerList = new UserWinfromControl.UWC_CheckListBox();
            clb_StockerCommonCodeList = new UserWinfromControl.UWC_ListBox();
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
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Controls.Add(bt_Search, 9, 0);
            tableLayoutPanel1.Controls.Add(dgv_StockerInventory, 0, 1);
            tableLayoutPanel1.Controls.Add(dgv_StockerCurrState, 6, 1);
            tableLayoutPanel1.Controls.Add(dgv_TransportJobInfomation, 0, 4);
            tableLayoutPanel1.Controls.Add(bt_GetStockerGroupList, 9, 1);
            tableLayoutPanel1.Controls.Add(cb_CarrierStat, 8, 0);
            tableLayoutPanel1.Controls.Add(tb_CarrierId, 7, 0);
            tableLayoutPanel1.Controls.Add(cb_TrfStatCode, 6, 0);
            tableLayoutPanel1.Controls.Add(clb_StockerList, 9, 3);
            tableLayoutPanel1.Controls.Add(clb_StockerCommonCodeList, 9, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
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
            // dgv_StockerInventory
            // 
            tableLayoutPanel1.SetColumnSpan(dgv_StockerInventory, 6);
            dgv_StockerInventory.Dock = DockStyle.Fill;
            dgv_StockerInventory.Lb_Text = "SqlName";
            dgv_StockerInventory.Lb_Text2 = "";
            dgv_StockerInventory.Location = new Point(3, 33);
            dgv_StockerInventory.Name = "dgv_StockerInventory";
            tableLayoutPanel1.SetRowSpan(dgv_StockerInventory, 3);
            dgv_StockerInventory.Size = new Size(869, 444);
            dgv_StockerInventory.TabIndex = 13;
            // 
            // dgv_StockerCurrState
            // 
            tableLayoutPanel1.SetColumnSpan(dgv_StockerCurrState, 3);
            dgv_StockerCurrState.Dock = DockStyle.Fill;
            dgv_StockerCurrState.Lb_Text = "SqlName";
            dgv_StockerCurrState.Lb_Text2 = "";
            dgv_StockerCurrState.Location = new Point(878, 33);
            dgv_StockerCurrState.Name = "dgv_StockerCurrState";
            tableLayoutPanel1.SetRowSpan(dgv_StockerCurrState, 3);
            dgv_StockerCurrState.Size = new Size(379, 444);
            dgv_StockerCurrState.TabIndex = 14;
            // 
            // dgv_TransportJobInfomation
            // 
            tableLayoutPanel1.SetColumnSpan(dgv_TransportJobInfomation, 10);
            dgv_TransportJobInfomation.Dock = DockStyle.Fill;
            dgv_TransportJobInfomation.Lb_Text = "SqlName";
            dgv_TransportJobInfomation.Lb_Text2 = "";
            dgv_TransportJobInfomation.Location = new Point(3, 483);
            dgv_TransportJobInfomation.Name = "dgv_TransportJobInfomation";
            dgv_TransportJobInfomation.Size = new Size(1394, 114);
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
            bt_GetStockerGroupList.Click += bt_GetStockerGroupList_Click;
            // 
            // cb_CarrierStat
            // 
            cb_CarrierStat.ComboBoxSelectedIndex = -1;
            cb_CarrierStat.ComboBoxText = "실/공";
            cb_CarrierStat.DataSource = null;
            cb_CarrierStat.Dock = DockStyle.Fill;
            cb_CarrierStat.Location = new Point(1158, 3);
            cb_CarrierStat.Name = "cb_CarrierStat";
            cb_CarrierStat.Size = new Size(99, 24);
            cb_CarrierStat.TabIndex = 12;
            cb_CarrierStat.VariableName = "CSTSTAT";
            // 
            // tb_CarrierId
            // 
            tb_CarrierId.Dock = DockStyle.Fill;
            tb_CarrierId.IsMultiInputTextControl = false;
            tb_CarrierId.Lb_Text = "Carrier_ID";
            tb_CarrierId.Location = new Point(1018, 3);
            tb_CarrierId.Name = "tb_CarrierId";
            tb_CarrierId.Size = new Size(134, 24);
            tb_CarrierId.TabIndex = 11;
            tb_CarrierId.Tb_Text = "";
            tb_CarrierId.VariableName = "CSTID";
            // 
            // cb_TrfStatCode
            // 
            cb_TrfStatCode.ComboBoxSelectedIndex = -1;
            cb_TrfStatCode.ComboBoxText = "TransportState";
            cb_TrfStatCode.DataSource = null;
            cb_TrfStatCode.Dock = DockStyle.Fill;
            cb_TrfStatCode.Location = new Point(878, 3);
            cb_TrfStatCode.Name = "cb_TrfStatCode";
            cb_TrfStatCode.Size = new Size(134, 24);
            cb_TrfStatCode.TabIndex = 18;
            cb_TrfStatCode.VariableName = "TransportState";
            // 
            // clb_StockerList
            // 
            clb_StockerList.DataObject = resources.GetObject("clb_StockerList.DataObject");
            clb_StockerList.Dock = DockStyle.Fill;
            clb_StockerList.Lb_Text = "StockerList";
            clb_StockerList.Location = new Point(1263, 231);
            clb_StockerList.Name = "clb_StockerList";
            clb_StockerList.Size = new Size(134, 246);
            clb_StockerList.TabIndex = 19;
            clb_StockerList.VariableName = "StockerList";
            // 
            // clb_StockerCommonCodeList
            // 
            clb_StockerCommonCodeList.DataObject = resources.GetObject("clb_StockerCommonCodeList.DataObject");
            clb_StockerCommonCodeList.Dock = DockStyle.Fill;
            clb_StockerCommonCodeList.Lb_Text = "StockerCommonCode";
            clb_StockerCommonCodeList.Location = new Point(1263, 63);
            clb_StockerCommonCodeList.Name = "clb_StockerCommonCodeList";
            clb_StockerCommonCodeList.Size = new Size(134, 162);
            clb_StockerCommonCodeList.TabIndex = 20;
            clb_StockerCommonCodeList.VariableName = "StockerCommonCode";
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
        private UserWinfromControl.UWC_LabelAndTextBox tb_CarrierId;
        private UserWinfromControl.UWC_ComboBox cb_CarrierStat;
        private UserWinfromControl.UWC_DataGridView dgv_StockerInventory;
        private UserWinfromControl.UWC_DataGridView dgv_StockerCurrState;
        private UserWinfromControl.UWC_DataGridView dgv_TransportJobInfomation;
        private Button bt_GetStockerGroupList;
        private UserWinfromControl.UWC_ComboBox cb_TrfStatCode;
        private UserWinfromControl.UWC_CheckListBox clb_StockerList;
        private UserWinfromControl.UWC_ListBox clb_StockerCommonCodeList;
    }
}
