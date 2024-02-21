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
            dgv_StockerInventory = new DataGridView();
            dgv_StockerCurrState = new DataGridView();
            cb_TrfStatCode = new ComboBox();
            dgv_TransportJobInfomation = new DataGridView();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_StockerInventory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_StockerCurrState).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_TransportJobInfomation).BeginInit();
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
            tableLayoutPanel1.Controls.Add(dgv_StockerInventory, 0, 1);
            tableLayoutPanel1.Controls.Add(dgv_StockerCurrState, 6, 1);
            tableLayoutPanel1.Controls.Add(cb_TrfStatCode, 6, 0);
            tableLayoutPanel1.Controls.Add(dgv_TransportJobInfomation, 6, 3);
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
            // dgv_StockerInventory
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv_StockerInventory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv_StockerInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableLayoutPanel1.SetColumnSpan(dgv_StockerInventory, 6);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgv_StockerInventory.DefaultCellStyle = dataGridViewCellStyle2;
            dgv_StockerInventory.Dock = DockStyle.Fill;
            dgv_StockerInventory.Location = new Point(3, 33);
            dgv_StockerInventory.Name = "dgv_StockerInventory";
            tableLayoutPanel1.SetRowSpan(dgv_StockerInventory, 3);
            dgv_StockerInventory.RowTemplate.Height = 25;
            dgv_StockerInventory.Size = new Size(834, 564);
            dgv_StockerInventory.TabIndex = 7;
            // 
            // dgv_StockerCurrState
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgv_StockerCurrState.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgv_StockerCurrState.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableLayoutPanel1.SetColumnSpan(dgv_StockerCurrState, 4);
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgv_StockerCurrState.DefaultCellStyle = dataGridViewCellStyle4;
            dgv_StockerCurrState.Dock = DockStyle.Fill;
            dgv_StockerCurrState.Location = new Point(843, 33);
            dgv_StockerCurrState.Name = "dgv_StockerCurrState";
            tableLayoutPanel1.SetRowSpan(dgv_StockerCurrState, 2);
            dgv_StockerCurrState.RowTemplate.Height = 25;
            dgv_StockerCurrState.Size = new Size(554, 454);
            dgv_StockerCurrState.TabIndex = 8;
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
            // dgv_TransportJobInfomation
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgv_TransportJobInfomation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgv_TransportJobInfomation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableLayoutPanel1.SetColumnSpan(dgv_TransportJobInfomation, 4);
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgv_TransportJobInfomation.DefaultCellStyle = dataGridViewCellStyle6;
            dgv_TransportJobInfomation.Dock = DockStyle.Fill;
            dgv_TransportJobInfomation.Location = new Point(843, 493);
            dgv_TransportJobInfomation.Name = "dgv_TransportJobInfomation";
            dgv_TransportJobInfomation.RowTemplate.Height = 25;
            dgv_TransportJobInfomation.Size = new Size(554, 104);
            dgv_TransportJobInfomation.TabIndex = 10;
            // 
            // StockerInventorySituation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "StockerInventorySituation";
            Size = new Size(1400, 600);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_StockerInventory).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_StockerCurrState).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_TransportJobInfomation).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button bt_Search;
        private ComboBox cb_StockerGroupList;
        private ComboBox cb_Cststat;
        private DataGridView dgv_StockerCurrState;
        private DataGridView dgv_StockerInventory;
        private ComboBox cb_TrfStatCode;
        private DataGridView dgv_TransportJobInfomation;
    }
}
