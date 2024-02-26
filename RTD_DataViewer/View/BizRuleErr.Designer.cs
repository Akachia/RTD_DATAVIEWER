namespace RTD_DataViewer.View
{
    partial class BizRuleErr
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
            dgv_BizRuleError = new UserWinfromControl.UWC_DataGridView();
            utb_XmlMssageText = new UserWinfromControl.UWC_TextBox();
            lAtb_ErrorText = new UserWinfromControl.UWC_LabelAndTextBox();
            bt_Search = new Button();
            utb_BizFlowText = new UserWinfromControl.UWC_TextBox();
            lAdtp_StartTime = new UserWinfromControl.UWC_LabelAndDateTimePicker();
            lAdtp_EndTime = new UserWinfromControl.UWC_LabelAndDateTimePicker();
            lAtb_BizRuleID = new UserWinfromControl.UWC_LabelAndTextBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 10;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayoutPanel1.Controls.Add(dgv_BizRuleError, 0, 1);
            tableLayoutPanel1.Controls.Add(utb_XmlMssageText, 7, 2);
            tableLayoutPanel1.Controls.Add(lAtb_ErrorText, 8, 0);
            tableLayoutPanel1.Controls.Add(bt_Search, 9, 0);
            tableLayoutPanel1.Controls.Add(utb_BizFlowText, 7, 1);
            tableLayoutPanel1.Controls.Add(lAdtp_StartTime, 5, 0);
            tableLayoutPanel1.Controls.Add(lAdtp_EndTime, 6, 0);
            tableLayoutPanel1.Controls.Add(lAtb_BizRuleID, 7, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.Size = new Size(1400, 600);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // dgv_BizRuleError
            // 
            tableLayoutPanel1.SetColumnSpan(dgv_BizRuleError, 7);
            dgv_BizRuleError.Dock = DockStyle.Fill;
            dgv_BizRuleError.Lb_Text = "SqlName";
            dgv_BizRuleError.Lb_Text2 = "";
            dgv_BizRuleError.Location = new Point(3, 33);
            dgv_BizRuleError.Name = "dgv_BizRuleError";
            tableLayoutPanel1.SetRowSpan(dgv_BizRuleError, 2);
            dgv_BizRuleError.Size = new Size(974, 564);
            dgv_BizRuleError.TabIndex = 0;
            // 
            // utb_XmlMssageText
            // 
            tableLayoutPanel1.SetColumnSpan(utb_XmlMssageText, 3);
            utb_XmlMssageText.Dock = DockStyle.Fill;
            utb_XmlMssageText.Location = new Point(983, 147);
            utb_XmlMssageText.Name = "utb_XmlMssageText";
            utb_XmlMssageText.Size = new Size(414, 450);
            utb_XmlMssageText.TabIndex = 1;
            // 
            // lAtb_ErrorText
            // 
            lAtb_ErrorText.Dock = DockStyle.Fill;
            lAtb_ErrorText.IsMultiInputTextControl = false;
            lAtb_ErrorText.Lb_Text = "Error Text";
            lAtb_ErrorText.Location = new Point(1123, 3);
            lAtb_ErrorText.Name = "lAtb_ErrorText";
            lAtb_ErrorText.Size = new Size(190, 24);
            lAtb_ErrorText.TabIndex = 2;
            lAtb_ErrorText.Tb_Text = "";
            lAtb_ErrorText.VariableName = "ErrorText";
            // 
            // bt_Search
            // 
            bt_Search.Dock = DockStyle.Fill;
            bt_Search.Location = new Point(1319, 3);
            bt_Search.Name = "bt_Search";
            bt_Search.Size = new Size(78, 24);
            bt_Search.TabIndex = 3;
            bt_Search.Text = "Search";
            bt_Search.UseVisualStyleBackColor = true;
            bt_Search.Click += bt_Search_Click;
            // 
            // utb_BizFlowText
            // 
            tableLayoutPanel1.SetColumnSpan(utb_BizFlowText, 3);
            utb_BizFlowText.Dock = DockStyle.Fill;
            utb_BizFlowText.Location = new Point(983, 33);
            utb_BizFlowText.Name = "utb_BizFlowText";
            utb_BizFlowText.Size = new Size(414, 108);
            utb_BizFlowText.TabIndex = 4;
            // 
            // lAdtp_StartTime
            // 
            lAdtp_StartTime.Dock = DockStyle.Fill;
            lAdtp_StartTime.Dtp_Value = new DateTime(2024, 2, 15, 15, 43, 57, 729);
            lAdtp_StartTime.IsChecked = true;
            lAdtp_StartTime.Lb_Text = "시작 시간";
            lAdtp_StartTime.Location = new Point(423, 3);
            lAdtp_StartTime.Name = "lAdtp_StartTime";
            lAdtp_StartTime.Size = new Size(274, 24);
            lAdtp_StartTime.TabIndex = 5;
            lAdtp_StartTime.VariableName = "StartTime";
            // 
            // lAdtp_EndTime
            // 
            lAdtp_EndTime.Dock = DockStyle.Fill;
            lAdtp_EndTime.Dtp_Value = new DateTime(2024, 2, 15, 15, 44, 3, 251);
            lAdtp_EndTime.IsChecked = false;
            lAdtp_EndTime.Lb_Text = "종료 시간";
            lAdtp_EndTime.Location = new Point(703, 3);
            lAdtp_EndTime.Name = "lAdtp_EndTime";
            lAdtp_EndTime.Size = new Size(274, 24);
            lAdtp_EndTime.TabIndex = 6;
            lAdtp_EndTime.VariableName = "EndTime";
            // 
            // lAtb_BizRuleID
            // 
            lAtb_BizRuleID.Dock = DockStyle.Fill;
            lAtb_BizRuleID.IsMultiInputTextControl = false;
            lAtb_BizRuleID.Lb_Text = "BizRuleID";
            lAtb_BizRuleID.Location = new Point(983, 3);
            lAtb_BizRuleID.Name = "lAtb_BizRuleID";
            lAtb_BizRuleID.Size = new Size(134, 24);
            lAtb_BizRuleID.TabIndex = 7;
            lAtb_BizRuleID.Tb_Text = "";
            lAtb_BizRuleID.VariableName = "BizRuleID";
            // 
            // BizRuleErr
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "BizRuleErr";
            Size = new Size(1400, 600);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private UserWinfromControl.UWC_DataGridView dgv_BizRuleError;
        private UserWinfromControl.UWC_TextBox utb_XmlMssageText;
        private UserWinfromControl.UWC_LabelAndTextBox lAtb_ErrorText;
        private Button bt_Search;
        private UserWinfromControl.UWC_TextBox utb_BizFlowText;
        private UserWinfromControl.UWC_LabelAndDateTimePicker lAdtp_StartTime;
        private UserWinfromControl.UWC_LabelAndDateTimePicker lAdtp_EndTime;
        private UserWinfromControl.UWC_LabelAndTextBox lAtb_BizRuleID;
    }
}
