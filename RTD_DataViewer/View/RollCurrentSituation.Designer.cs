namespace RTD_DataViewer.View
{
    partial class RollCurrentSituation
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            lb_MismatchMessage = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            bt_RollSituationSearch = new Button();
            label1 = new Label();
            dgw_RollCurrentSituation = new DataGridView();
            dgv_RollList = new DataGridView();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgw_RollCurrentSituation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_RollList).BeginInit();
            SuspendLayout();
            // 
            // lb_MismatchMessage
            // 
            lb_MismatchMessage.AutoSize = true;
            lb_MismatchMessage.Dock = DockStyle.Fill;
            lb_MismatchMessage.Location = new Point(0, 0);
            lb_MismatchMessage.Name = "lb_MismatchMessage";
            lb_MismatchMessage.Size = new Size(0, 15);
            lb_MismatchMessage.TabIndex = 7;
            lb_MismatchMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 8;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.5F));
            tableLayoutPanel1.Controls.Add(bt_RollSituationSearch, 7, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(dgw_RollCurrentSituation, 0, 1);
            tableLayoutPanel1.Controls.Add(dgv_RollList, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.Size = new Size(1400, 600);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // bt_RollSituationSearch
            // 
            bt_RollSituationSearch.Dock = DockStyle.Fill;
            bt_RollSituationSearch.Location = new Point(1298, 3);
            bt_RollSituationSearch.Name = "bt_RollSituationSearch";
            bt_RollSituationSearch.Size = new Size(99, 24);
            bt_RollSituationSearch.TabIndex = 4;
            bt_RollSituationSearch.Text = "Search";
            bt_RollSituationSearch.UseVisualStyleBackColor = true;
            bt_RollSituationSearch.Click += bt_RollSituationSearch_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(274, 30);
            label1.TabIndex = 6;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgw_RollCurrentSituation
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgw_RollCurrentSituation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgw_RollCurrentSituation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableLayoutPanel1.SetColumnSpan(dgw_RollCurrentSituation, 8);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgw_RollCurrentSituation.DefaultCellStyle = dataGridViewCellStyle2;
            dgw_RollCurrentSituation.Dock = DockStyle.Fill;
            dgw_RollCurrentSituation.Location = new Point(3, 33);
            dgw_RollCurrentSituation.Name = "dgw_RollCurrentSituation";
            dgw_RollCurrentSituation.RowTemplate.Height = 25;
            dgw_RollCurrentSituation.Size = new Size(1394, 165);
            dgw_RollCurrentSituation.TabIndex = 7;
            // 
            // dgv_RollList
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgv_RollList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgv_RollList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableLayoutPanel1.SetColumnSpan(dgv_RollList, 8);
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgv_RollList.DefaultCellStyle = dataGridViewCellStyle4;
            dgv_RollList.Dock = DockStyle.Fill;
            dgv_RollList.Location = new Point(3, 204);
            dgv_RollList.Name = "dgv_RollList";
            dgv_RollList.RowTemplate.Height = 25;
            dgv_RollList.Size = new Size(1394, 393);
            dgv_RollList.TabIndex = 8;
            // 
            // RollCurrentSituation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Controls.Add(lb_MismatchMessage);
            Name = "RollCurrentSituation";
            Size = new Size(1400, 600);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgw_RollCurrentSituation).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_RollList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lb_MismatchMessage;
        private TableLayoutPanel tableLayoutPanel1;
        private UserWinfromControl.UWC_DataGridView dgv_LotActHist;
        private UserWinfromControl.UWC_DataGridView dgv_LotInfo;
        private UserWinfromControl.UWC_DataGridView dgv_LotHist;
        private Button bt_RollSituationSearch;
        private UserWinfromControl.UWC_LabelAndTextBox latb_LotId;
        private Label label1;
        private DataGridView dgw_RollCurrentSituation;
        private DataGridView dgv_RollList;
    }
}
