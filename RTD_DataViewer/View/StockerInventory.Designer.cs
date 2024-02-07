namespace RTD_DataViewer.View
{
    partial class StockerInventory
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            tableLayoutPanel1 = new TableLayoutPanel();
            bt_Search = new Button();
            cb_StockerGroupList = new ComboBox();
            cb_Cststat = new ComboBox();
            dgv_StoInventory = new DataGridView();
            dgv_StoStatus = new DataGridView();
            cb_TrfStatCode = new ComboBox();
            dgv_TrfCmd = new DataGridView();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_StoInventory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_StoStatus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_TrfCmd).BeginInit();
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
            tableLayoutPanel1.Controls.Add(cb_Cststat, 7, 0);
            tableLayoutPanel1.Controls.Add(dgv_StoInventory, 0, 1);
            tableLayoutPanel1.Controls.Add(dgv_StoStatus, 6, 1);
            tableLayoutPanel1.Controls.Add(cb_TrfStatCode, 6, 0);
            tableLayoutPanel1.Controls.Add(dgv_TrfCmd, 6, 3);
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
            // cb_Cststat
            // 
            cb_Cststat.Dock = DockStyle.Fill;
            cb_Cststat.FormattingEnabled = true;
            cb_Cststat.Items.AddRange(new object[] { "모두 : ALL", "실트레이 : U", "공트레이 : E" });
            cb_Cststat.Location = new Point(983, 3);
            cb_Cststat.Name = "cb_Cststat";
            cb_Cststat.Size = new Size(99, 23);
            cb_Cststat.TabIndex = 6;
            // 
            // dgv_StoInventory
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv_StoInventory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv_StoInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableLayoutPanel1.SetColumnSpan(dgv_StoInventory, 6);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgv_StoInventory.DefaultCellStyle = dataGridViewCellStyle2;
            dgv_StoInventory.Dock = DockStyle.Fill;
            dgv_StoInventory.Location = new Point(3, 33);
            dgv_StoInventory.Name = "dgv_StoInventory";
            tableLayoutPanel1.SetRowSpan(dgv_StoInventory, 3);
            dgv_StoInventory.RowTemplate.Height = 25;
            dgv_StoInventory.Size = new Size(834, 564);
            dgv_StoInventory.TabIndex = 7;
            // 
            // dgv_StoStatus
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgv_StoStatus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgv_StoStatus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableLayoutPanel1.SetColumnSpan(dgv_StoStatus, 4);
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgv_StoStatus.DefaultCellStyle = dataGridViewCellStyle4;
            dgv_StoStatus.Dock = DockStyle.Fill;
            dgv_StoStatus.Location = new Point(843, 33);
            dgv_StoStatus.Name = "dgv_StoStatus";
            tableLayoutPanel1.SetRowSpan(dgv_StoStatus, 2);
            dgv_StoStatus.RowTemplate.Height = 25;
            dgv_StoStatus.Size = new Size(554, 454);
            dgv_StoStatus.TabIndex = 8;
            // 
            // cb_TrfStatCode
            // 
            cb_TrfStatCode.Dock = DockStyle.Fill;
            cb_TrfStatCode.FormattingEnabled = true;
            cb_TrfStatCode.Items.AddRange(new object[] { "FINAL", "MOVING", "RESERVED" });
            cb_TrfStatCode.Location = new Point(843, 3);
            cb_TrfStatCode.Name = "cb_TrfStatCode";
            cb_TrfStatCode.Size = new Size(134, 23);
            cb_TrfStatCode.TabIndex = 9;
            cb_TrfStatCode.Text = "TRF_STAT_CODE";
            // 
            // dgv_TrfCmd
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgv_TrfCmd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgv_TrfCmd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableLayoutPanel1.SetColumnSpan(dgv_TrfCmd, 4);
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgv_TrfCmd.DefaultCellStyle = dataGridViewCellStyle6;
            dgv_TrfCmd.Dock = DockStyle.Fill;
            dgv_TrfCmd.Location = new Point(843, 493);
            dgv_TrfCmd.Name = "dgv_TrfCmd";
            dgv_TrfCmd.RowTemplate.Height = 25;
            dgv_TrfCmd.Size = new Size(554, 104);
            dgv_TrfCmd.TabIndex = 10;
            // 
            // StockerInventory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "StockerInventory";
            Size = new Size(1400, 600);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_StoInventory).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_StoStatus).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_TrfCmd).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button bt_Search;
        private ComboBox cb_StockerGroupList;
        private ComboBox cb_Cststat;
        private DataGridView dgv_StoStatus;
        private DataGridView dgv_StoInventory;
        private ComboBox cb_TrfStatCode;
        private DataGridView dgv_TrfCmd;
    }
}
