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
            lb_CstStat = new Label();
            lb_AgingIssPriortyNo = new Label();
            lb_RackStatCode = new Label();
            lb_TrfStatCode = new Label();
            lb_Prodid = new Label();
            lb_WipStat = new Label();
            lb_Procid = new Label();
            lb_NextProcid = new Label();
            panel1 = new Panel();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 12;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Controls.Add(bt_Search, 11, 0);
            tableLayoutPanel1.Controls.Add(dgv_StockerInventory, 0, 2);
            tableLayoutPanel1.Controls.Add(dgv_StockerCurrState, 8, 1);
            tableLayoutPanel1.Controls.Add(dgv_TransportJobInfomation, 0, 4);
            tableLayoutPanel1.Controls.Add(bt_GetStockerGroupList, 11, 1);
            tableLayoutPanel1.Controls.Add(cb_CarrierStat, 10, 0);
            tableLayoutPanel1.Controls.Add(tb_CarrierId, 9, 0);
            tableLayoutPanel1.Controls.Add(cb_TrfStatCode, 8, 0);
            tableLayoutPanel1.Controls.Add(clb_StockerList, 11, 3);
            tableLayoutPanel1.Controls.Add(clb_StockerCommonCodeList, 11, 2);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
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
            tableLayoutPanel1.SetColumnSpan(dgv_StockerInventory, 8);
            dgv_StockerInventory.Dock = DockStyle.Fill;
            dgv_StockerInventory.Lb_Text = "SqlName";
            dgv_StockerInventory.Lb_Text2 = "";
            dgv_StockerInventory.Location = new Point(3, 63);
            dgv_StockerInventory.Name = "dgv_StockerInventory";
            tableLayoutPanel1.SetRowSpan(dgv_StockerInventory, 2);
            dgv_StockerInventory.Size = new Size(876, 414);
            dgv_StockerInventory.TabIndex = 13;
            // 
            // dgv_StockerCurrState
            // 
            tableLayoutPanel1.SetColumnSpan(dgv_StockerCurrState, 3);
            dgv_StockerCurrState.Dock = DockStyle.Fill;
            dgv_StockerCurrState.Lb_Text = "SqlName";
            dgv_StockerCurrState.Lb_Text2 = "";
            dgv_StockerCurrState.Location = new Point(885, 33);
            dgv_StockerCurrState.Name = "dgv_StockerCurrState";
            tableLayoutPanel1.SetRowSpan(dgv_StockerCurrState, 3);
            dgv_StockerCurrState.Size = new Size(372, 444);
            dgv_StockerCurrState.TabIndex = 14;
            // 
            // dgv_TransportJobInfomation
            // 
            tableLayoutPanel1.SetColumnSpan(dgv_TransportJobInfomation, 12);
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
            cb_CarrierStat.Location = new Point(1165, 3);
            cb_CarrierStat.Name = "cb_CarrierStat";
            cb_CarrierStat.Size = new Size(92, 24);
            cb_CarrierStat.TabIndex = 12;
            cb_CarrierStat.VariableName = "CSTSTAT";
            // 
            // tb_CarrierId
            // 
            tb_CarrierId.Dock = DockStyle.Fill;
            tb_CarrierId.IsMultiInputTextControl = false;
            tb_CarrierId.Lb_Text = "Carrier_ID";
            tb_CarrierId.Location = new Point(1025, 3);
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
            cb_TrfStatCode.Location = new Point(885, 3);
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
            // lb_CstStat
            // 
            lb_CstStat.AutoSize = true;
            lb_CstStat.Font = new Font("맑은 고딕", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            lb_CstStat.Location = new Point(577, 7);
            lb_CstStat.Name = "lb_CstStat";
            lb_CstStat.Size = new Size(43, 13);
            lb_CstStat.TabIndex = 21;
            lb_CstStat.Text = "CstStat";
            lb_CstStat.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lb_AgingIssPriortyNo
            // 
            lb_AgingIssPriortyNo.AutoSize = true;
            lb_AgingIssPriortyNo.Font = new Font("맑은 고딕", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            lb_AgingIssPriortyNo.Location = new Point(647, 7);
            lb_AgingIssPriortyNo.Name = "lb_AgingIssPriortyNo";
            lb_AgingIssPriortyNo.Size = new Size(98, 13);
            lb_AgingIssPriortyNo.TabIndex = 22;
            lb_AgingIssPriortyNo.Text = "AgingIssPriortyNo";
            lb_AgingIssPriortyNo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lb_RackStatCode
            // 
            lb_RackStatCode.AutoSize = true;
            lb_RackStatCode.Font = new Font("맑은 고딕", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            lb_RackStatCode.Location = new Point(780, 7);
            lb_RackStatCode.Name = "lb_RackStatCode";
            lb_RackStatCode.Size = new Size(78, 13);
            lb_RackStatCode.TabIndex = 23;
            lb_RackStatCode.Text = "RackStatCode";
            lb_RackStatCode.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lb_TrfStatCode
            // 
            lb_TrfStatCode.AutoSize = true;
            lb_TrfStatCode.Font = new Font("맑은 고딕", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            lb_TrfStatCode.Location = new Point(479, 7);
            lb_TrfStatCode.Name = "lb_TrfStatCode";
            lb_TrfStatCode.Size = new Size(67, 13);
            lb_TrfStatCode.TabIndex = 24;
            lb_TrfStatCode.Text = "TrfStatCode";
            lb_TrfStatCode.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lb_Prodid
            // 
            lb_Prodid.AutoSize = true;
            lb_Prodid.Font = new Font("맑은 고딕", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            lb_Prodid.Location = new Point(94, 7);
            lb_Prodid.Name = "lb_Prodid";
            lb_Prodid.Size = new Size(41, 13);
            lb_Prodid.TabIndex = 25;
            lb_Prodid.Text = "Prodid";
            lb_Prodid.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lb_WipStat
            // 
            lb_WipStat.AutoSize = true;
            lb_WipStat.Font = new Font("맑은 고딕", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            lb_WipStat.Location = new Point(10, 7);
            lb_WipStat.Name = "lb_WipStat";
            lb_WipStat.Size = new Size(47, 13);
            lb_WipStat.TabIndex = 26;
            lb_WipStat.Text = "WipStat";
            lb_WipStat.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lb_Procid
            // 
            lb_Procid.AutoSize = true;
            lb_Procid.Font = new Font("맑은 고딕", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            lb_Procid.Location = new Point(241, 7);
            lb_Procid.Name = "lb_Procid";
            lb_Procid.Size = new Size(39, 13);
            lb_Procid.TabIndex = 27;
            lb_Procid.Text = "Procid";
            lb_Procid.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lb_NextProcid
            // 
            lb_NextProcid.AutoSize = true;
            lb_NextProcid.Font = new Font("맑은 고딕", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            lb_NextProcid.Location = new Point(353, 7);
            lb_NextProcid.Name = "lb_NextProcid";
            lb_NextProcid.Size = new Size(62, 13);
            lb_NextProcid.TabIndex = 28;
            lb_NextProcid.Text = "NextProcid";
            lb_NextProcid.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            tableLayoutPanel1.SetColumnSpan(panel1, 8);
            panel1.Controls.Add(lb_TrfStatCode);
            panel1.Controls.Add(lb_NextProcid);
            panel1.Controls.Add(lb_Procid);
            panel1.Controls.Add(lb_WipStat);
            panel1.Controls.Add(lb_Prodid);
            panel1.Controls.Add(lb_RackStatCode);
            panel1.Controls.Add(lb_AgingIssPriortyNo);
            panel1.Controls.Add(lb_CstStat);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            tableLayoutPanel1.SetRowSpan(panel1, 2);
            panel1.Size = new Size(876, 54);
            panel1.TabIndex = 29;
            // 
            // StockerInventorySituation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "StockerInventorySituation";
            Size = new Size(1400, 600);
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        private Label lb_CstStat;
        private Label lb_AgingIssPriortyNo;
        private Label lb_RackStatCode;
        private Label lb_TrfStatCode;
        private Label lb_Prodid;
        private Label lb_WipStat;
        private Label lb_Procid;
        private Label lb_NextProcid;
        private Panel panel1;
    }
}
