namespace RTD_DataViewer.View
{
    partial class PortRequestRecord
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
            tableLayoutPanel6 = new TableLayoutPanel();
            bt_ReqATransfer_Search = new Button();
            dtp__StartTime = new UserWinfromControl.UWC_LabelAndDateTimePicker();
            dtp_EndTime = new UserWinfromControl.UWC_LabelAndDateTimePicker();
            dgv_PortRequestRecord = new UserWinfromControl.UWC_DataGridView();
            lAtb_ReqATransfer_StartPort = new UserWinfromControl.UWC_LabelAndTextBox();
            lAtb_ReqATransfer_ArrPort = new UserWinfromControl.UWC_LabelAndTextBox();
            lAtb_ReqATransfer_CarrierId = new UserWinfromControl.UWC_LabelAndTextBox();
            lAtb_ReqATransfer_RuleId = new UserWinfromControl.UWC_LabelAndTextBox();
            cb_CarrierStat = new UserWinfromControl.UWC_ComboBox();
            cb_TransportStatList = new UserWinfromControl.UWC_ComboBox();
            tv_SituationOrRuleResult = new TreeView();
            tableLayoutPanel6.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 8;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
            tableLayoutPanel6.Controls.Add(bt_ReqATransfer_Search, 7, 0);
            tableLayoutPanel6.Controls.Add(dtp__StartTime, 3, 0);
            tableLayoutPanel6.Controls.Add(dtp_EndTime, 3, 1);
            tableLayoutPanel6.Controls.Add(dgv_PortRequestRecord, 0, 2);
            tableLayoutPanel6.Controls.Add(lAtb_ReqATransfer_StartPort, 6, 0);
            tableLayoutPanel6.Controls.Add(lAtb_ReqATransfer_ArrPort, 6, 1);
            tableLayoutPanel6.Controls.Add(lAtb_ReqATransfer_CarrierId, 5, 0);
            tableLayoutPanel6.Controls.Add(lAtb_ReqATransfer_RuleId, 5, 1);
            tableLayoutPanel6.Controls.Add(cb_CarrierStat, 4, 0);
            tableLayoutPanel6.Controls.Add(cb_TransportStatList, 4, 1);
            tableLayoutPanel6.Controls.Add(tv_SituationOrRuleResult, 6, 2);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(0, 0);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 3;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel6.Size = new Size(1400, 600);
            tableLayoutPanel6.TabIndex = 1;
            // 
            // bt_ReqATransfer_Search
            // 
            bt_ReqATransfer_Search.Dock = DockStyle.Fill;
            bt_ReqATransfer_Search.Location = new Point(1291, 3);
            bt_ReqATransfer_Search.Name = "bt_ReqATransfer_Search";
            tableLayoutPanel6.SetRowSpan(bt_ReqATransfer_Search, 2);
            bt_ReqATransfer_Search.Size = new Size(106, 54);
            bt_ReqATransfer_Search.TabIndex = 0;
            bt_ReqATransfer_Search.Text = "Search";
            bt_ReqATransfer_Search.UseVisualStyleBackColor = true;
            // 
            // dtp__StartTime
            // 
            dtp__StartTime.Dock = DockStyle.Fill;
            dtp__StartTime.Dtp_Value = new DateTime(2023, 11, 28, 9, 4, 55, 992);
            dtp__StartTime.IsChecked = true;
            dtp__StartTime.Lb_Text = "시작 시간";
            dtp__StartTime.Location = new Point(577, 3);
            dtp__StartTime.Name = "dtp__StartTime";
            dtp__StartTime.Size = new Size(274, 24);
            dtp__StartTime.TabIndex = 5;
            dtp__StartTime.VariableName = "StartTime";
            // 
            // dtp_EndTime
            // 
            dtp_EndTime.Dock = DockStyle.Fill;
            dtp_EndTime.Dtp_Value = new DateTime(2023, 11, 28, 9, 4, 58, 362);
            dtp_EndTime.IsChecked = false;
            dtp_EndTime.Lb_Text = "종료 시간";
            dtp_EndTime.Location = new Point(577, 33);
            dtp_EndTime.Name = "dtp_EndTime";
            dtp_EndTime.Size = new Size(274, 24);
            dtp_EndTime.TabIndex = 6;
            dtp_EndTime.VariableName = "EndTime";
            // 
            // dgv_PortRequestRecord
            // 
            tableLayoutPanel6.SetColumnSpan(dgv_PortRequestRecord, 6);
            dgv_PortRequestRecord.Dock = DockStyle.Fill;
            dgv_PortRequestRecord.Lb_Text = "SqlName";
            dgv_PortRequestRecord.Lb_Text2 = "";
            dgv_PortRequestRecord.Location = new Point(3, 63);
            dgv_PortRequestRecord.Name = "dgv_PortRequestRecord";
            dgv_PortRequestRecord.Size = new Size(1114, 534);
            dgv_PortRequestRecord.TabIndex = 12;
            // 
            // lAtb_ReqATransfer_StartPort
            // 
            lAtb_ReqATransfer_StartPort.Dock = DockStyle.Fill;
            lAtb_ReqATransfer_StartPort.IsMultiInputTextControl = false;
            lAtb_ReqATransfer_StartPort.Lb_Text = "EQUIPMENT_ID";
            lAtb_ReqATransfer_StartPort.Location = new Point(1123, 3);
            lAtb_ReqATransfer_StartPort.Name = "lAtb_ReqATransfer_StartPort";
            lAtb_ReqATransfer_StartPort.Size = new Size(162, 24);
            lAtb_ReqATransfer_StartPort.TabIndex = 2;
            lAtb_ReqATransfer_StartPort.Tb_Text = "";
            lAtb_ReqATransfer_StartPort.VariableName = "EQUIPMENT_ID";
            // 
            // lAtb_ReqATransfer_ArrPort
            // 
            lAtb_ReqATransfer_ArrPort.Dock = DockStyle.Fill;
            lAtb_ReqATransfer_ArrPort.IsMultiInputTextControl = false;
            lAtb_ReqATransfer_ArrPort.Lb_Text = "PORT_ID";
            lAtb_ReqATransfer_ArrPort.Location = new Point(1123, 33);
            lAtb_ReqATransfer_ArrPort.Name = "lAtb_ReqATransfer_ArrPort";
            lAtb_ReqATransfer_ArrPort.Size = new Size(162, 24);
            lAtb_ReqATransfer_ArrPort.TabIndex = 4;
            lAtb_ReqATransfer_ArrPort.Tb_Text = "";
            lAtb_ReqATransfer_ArrPort.VariableName = "PORT_ID";
            // 
            // lAtb_ReqATransfer_CarrierId
            // 
            lAtb_ReqATransfer_CarrierId.Dock = DockStyle.Fill;
            lAtb_ReqATransfer_CarrierId.IsMultiInputTextControl = false;
            lAtb_ReqATransfer_CarrierId.Lb_Text = "DURABLE_ID";
            lAtb_ReqATransfer_CarrierId.Location = new Point(955, 3);
            lAtb_ReqATransfer_CarrierId.Name = "lAtb_ReqATransfer_CarrierId";
            lAtb_ReqATransfer_CarrierId.Size = new Size(162, 24);
            lAtb_ReqATransfer_CarrierId.TabIndex = 1;
            lAtb_ReqATransfer_CarrierId.Tb_Text = "";
            lAtb_ReqATransfer_CarrierId.VariableName = "DURABLE_ID";
            // 
            // lAtb_ReqATransfer_RuleId
            // 
            lAtb_ReqATransfer_RuleId.Dock = DockStyle.Fill;
            lAtb_ReqATransfer_RuleId.IsMultiInputTextControl = false;
            lAtb_ReqATransfer_RuleId.Lb_Text = "RTD_RULE_ID";
            lAtb_ReqATransfer_RuleId.Location = new Point(955, 33);
            lAtb_ReqATransfer_RuleId.Name = "lAtb_ReqATransfer_RuleId";
            lAtb_ReqATransfer_RuleId.Size = new Size(162, 24);
            lAtb_ReqATransfer_RuleId.TabIndex = 3;
            lAtb_ReqATransfer_RuleId.Tb_Text = "";
            lAtb_ReqATransfer_RuleId.VariableName = "RTD_RULE_ID";
            // 
            // cb_CarrierStat
            // 
            cb_CarrierStat.ComboBoxSelectedIndex = -1;
            cb_CarrierStat.ComboBoxText = "공/실";
            cb_CarrierStat.DataSource = null;
            cb_CarrierStat.Dock = DockStyle.Fill;
            cb_CarrierStat.Location = new Point(857, 3);
            cb_CarrierStat.Name = "cb_CarrierStat";
            cb_CarrierStat.Size = new Size(92, 24);
            cb_CarrierStat.TabIndex = 14;
            cb_CarrierStat.VariableName = "CSTSTAT";
            // 
            // cb_TransportStatList
            // 
            cb_TransportStatList.ComboBoxSelectedIndex = -1;
            cb_TransportStatList.ComboBoxText = "반송 상태";
            cb_TransportStatList.DataSource = null;
            cb_TransportStatList.Dock = DockStyle.Fill;
            cb_TransportStatList.Location = new Point(857, 33);
            cb_TransportStatList.Name = "cb_TransportStatList";
            cb_TransportStatList.Size = new Size(92, 24);
            cb_TransportStatList.TabIndex = 15;
            cb_TransportStatList.VariableName = "PRCS_TYPE_CODE";
            // 
            // tv_SituationOrRuleResult
            // 
            tableLayoutPanel6.SetColumnSpan(tv_SituationOrRuleResult, 2);
            tv_SituationOrRuleResult.Dock = DockStyle.Fill;
            tv_SituationOrRuleResult.Location = new Point(1123, 63);
            tv_SituationOrRuleResult.Name = "tv_SituationOrRuleResult";
            tv_SituationOrRuleResult.Size = new Size(274, 534);
            tv_SituationOrRuleResult.TabIndex = 16;
            // 
            // PortRequestRecord
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel6);
            Name = "PortRequestRecord";
            Size = new Size(1400, 600);
            tableLayoutPanel6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        internal TableLayoutPanel tableLayoutPanel6;
        internal Button bt_ReqATransfer_Search;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_ReqATransfer_CarrierId;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_ReqATransfer_StartPort;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_ReqATransfer_RuleId;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_ReqATransfer_ArrPort;
        internal UserWinfromControl.UWC_LabelAndDateTimePicker dtp__StartTime;
        internal UserWinfromControl.UWC_LabelAndDateTimePicker dtp_EndTime;
        internal UserWinfromControl.UWC_DataGridView dgv_PortRequestRecord;
        private UserWinfromControl.UWC_ComboBox cb_TransportStatList;
        private UserWinfromControl.UWC_ComboBox cb_CarrierStat;
        private TreeView tv_SituationOrRuleResult;
    }
}
