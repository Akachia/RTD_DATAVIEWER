namespace RTD_DataViewer.View
{
    partial class WipActHistory
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
            dgv_WipActHistory = new UserWinfromControl.UWC_DataGridView();
            lAtb_CarrierId = new UserWinfromControl.UWC_LabelAndTextBox();
            bt_Search = new Button();
            lAdtp_StartTime = new UserWinfromControl.UWC_LabelAndDateTimePicker();
            lAdtp_EndTime = new UserWinfromControl.UWC_LabelAndDateTimePicker();
            lAtb_LotId = new UserWinfromControl.UWC_LabelAndTextBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 10;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayoutPanel1.Controls.Add(dgv_WipActHistory, 0, 1);
            tableLayoutPanel1.Controls.Add(lAtb_CarrierId, 8, 0);
            tableLayoutPanel1.Controls.Add(bt_Search, 9, 0);
            tableLayoutPanel1.Controls.Add(lAdtp_StartTime, 5, 0);
            tableLayoutPanel1.Controls.Add(lAdtp_EndTime, 6, 0);
            tableLayoutPanel1.Controls.Add(lAtb_LotId, 7, 0);
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
            // dgv_WipActHistory
            // 
            tableLayoutPanel1.SetColumnSpan(dgv_WipActHistory, 10);
            dgv_WipActHistory.Dock = DockStyle.Fill;
            dgv_WipActHistory.Lb_Text = "SqlName";
            dgv_WipActHistory.Lb_Text2 = "";
            dgv_WipActHistory.Location = new Point(3, 33);
            dgv_WipActHistory.Name = "dgv_WipActHistory";
            tableLayoutPanel1.SetRowSpan(dgv_WipActHistory, 2);
            dgv_WipActHistory.Size = new Size(1394, 564);
            dgv_WipActHistory.TabIndex = 0;
            // 
            // lAtb_CarrierId
            // 
            lAtb_CarrierId.Dock = DockStyle.Fill;
            lAtb_CarrierId.IsMultiInputTextControl = false;
            lAtb_CarrierId.Lb_Text = "CSTID";
            lAtb_CarrierId.Location = new Point(1179, 3);
            lAtb_CarrierId.Name = "lAtb_CarrierId";
            lAtb_CarrierId.Size = new Size(134, 24);
            lAtb_CarrierId.TabIndex = 2;
            lAtb_CarrierId.Tb_Text = "";
            lAtb_CarrierId.VariableName = "CSTID";
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
            // lAdtp_StartTime
            // 
            lAdtp_StartTime.Dock = DockStyle.Fill;
            lAdtp_StartTime.Dtp_Value = new DateTime(2024, 2, 15, 15, 43, 57, 729);
            lAdtp_StartTime.IsChecked = true;
            lAdtp_StartTime.Lb_Text = "시작 시간";
            lAdtp_StartTime.Location = new Point(479, 3);
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
            lAdtp_EndTime.Location = new Point(759, 3);
            lAdtp_EndTime.Name = "lAdtp_EndTime";
            lAdtp_EndTime.Size = new Size(274, 24);
            lAdtp_EndTime.TabIndex = 6;
            lAdtp_EndTime.VariableName = "EndTime";
            // 
            // lAtb_LotId
            // 
            lAtb_LotId.Dock = DockStyle.Fill;
            lAtb_LotId.IsMultiInputTextControl = false;
            lAtb_LotId.Lb_Text = "LOTID";
            lAtb_LotId.Location = new Point(1039, 3);
            lAtb_LotId.Name = "lAtb_LotId";
            lAtb_LotId.Size = new Size(134, 24);
            lAtb_LotId.TabIndex = 7;
            lAtb_LotId.Tb_Text = "";
            lAtb_LotId.VariableName = "LOTID";
            // 
            // WipActHistory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "WipActHistory";
            Size = new Size(1400, 600);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private UserWinfromControl.UWC_DataGridView dgv_WipActHistory;
        private UserWinfromControl.UWC_LabelAndTextBox lAtb_CarrierId;
        private Button bt_Search;
        private UserWinfromControl.UWC_LabelAndDateTimePicker lAdtp_StartTime;
        private UserWinfromControl.UWC_LabelAndDateTimePicker lAdtp_EndTime;
        private UserWinfromControl.UWC_LabelAndTextBox lAtb_LotId;
    }
}
