namespace RTD_DataViewer.View
{
    partial class LogBox
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
            tableLayoutPanel3 = new TableLayoutPanel();
            utb_RtdDataViewerLog = new UserWinfromControl.UWC_TextBox();
            utb_RtdMessageText = new UserWinfromControl.UWC_TextBox();
            bt_Log_Clear = new Button();
            bt_beautifierJson = new Button();
            bt_beautifierXml = new Button();
            label3 = new Label();
            bt_MessageClear = new Button();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 8;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanel3.Controls.Add(utb_RtdDataViewerLog, 0, 1);
            tableLayoutPanel3.Controls.Add(utb_RtdMessageText, 4, 1);
            tableLayoutPanel3.Controls.Add(bt_beautifierXml, 7, 0);
            tableLayoutPanel3.Controls.Add(bt_beautifierJson, 6, 0);
            tableLayoutPanel3.Controls.Add(bt_Log_Clear, 3, 0);
            tableLayoutPanel3.Controls.Add(bt_MessageClear, 5, 0);
            tableLayoutPanel3.Controls.Add(label3, 4, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(1400, 600);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // utb_RtdDataViewerLog
            // 
            tableLayoutPanel3.SetColumnSpan(utb_RtdDataViewerLog, 4);
            utb_RtdDataViewerLog.Dock = DockStyle.Fill;
            utb_RtdDataViewerLog.Location = new Point(3, 33);
            utb_RtdDataViewerLog.Name = "utb_RtdDataViewerLog";
            tableLayoutPanel3.SetRowSpan(utb_RtdDataViewerLog, 2);
            utb_RtdDataViewerLog.Size = new Size(904, 564);
            utb_RtdDataViewerLog.TabIndex = 0;
            // 
            // utb_RtdMessageText
            // 
            tableLayoutPanel3.SetColumnSpan(utb_RtdMessageText, 4);
            utb_RtdMessageText.Dock = DockStyle.Fill;
            utb_RtdMessageText.Location = new Point(913, 33);
            utb_RtdMessageText.Name = "utb_RtdMessageText";
            tableLayoutPanel3.SetRowSpan(utb_RtdMessageText, 2);
            utb_RtdMessageText.Size = new Size(484, 564);
            utb_RtdMessageText.TabIndex = 1;
            // 
            // bt_Log_Clear
            // 
            bt_Log_Clear.Location = new Point(833, 3);
            bt_Log_Clear.Name = "bt_Log_Clear";
            bt_Log_Clear.Size = new Size(74, 23);
            bt_Log_Clear.TabIndex = 4;
            bt_Log_Clear.Text = "Clear";
            bt_Log_Clear.UseVisualStyleBackColor = true;
            bt_Log_Clear.Click += bt_Clear_Click;
            // 
            // bt_beautifierJson
            // 
            bt_beautifierJson.Dock = DockStyle.Fill;
            bt_beautifierJson.Location = new Point(1243, 3);
            bt_beautifierJson.Name = "bt_beautifierJson";
            bt_beautifierJson.Size = new Size(74, 24);
            bt_beautifierJson.TabIndex = 2;
            bt_beautifierJson.Text = "Convert_J";
            bt_beautifierJson.UseVisualStyleBackColor = true;
            bt_beautifierJson.Click += bt_beautifierJson_Click;
            // 
            // bt_beautifierXml
            // 
            bt_beautifierXml.Dock = DockStyle.Fill;
            bt_beautifierXml.Location = new Point(1323, 3);
            bt_beautifierXml.Name = "bt_beautifierXml";
            bt_beautifierXml.Size = new Size(74, 24);
            bt_beautifierXml.TabIndex = 3;
            bt_beautifierXml.Text = "Convert_X";
            bt_beautifierXml.UseVisualStyleBackColor = true;
            bt_beautifierXml.Click += bt_beautifierXml_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(913, 0);
            label3.Name = "label3";
            label3.Size = new Size(244, 30);
            label3.TabIndex = 8;
            label3.Text = "RTD Massge Text Converter";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // bt_MessageClear
            // 
            bt_MessageClear.Dock = DockStyle.Fill;
            bt_MessageClear.Location = new Point(1163, 3);
            bt_MessageClear.Name = "bt_MessageClear";
            bt_MessageClear.Size = new Size(74, 24);
            bt_MessageClear.TabIndex = 9;
            bt_MessageClear.Text = "Clear";
            bt_MessageClear.UseVisualStyleBackColor = true;
            bt_MessageClear.Click += bt_MessageClear_Click;
            // 
            // LogBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel3);
            Name = "LogBox";
            Size = new Size(1400, 600);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel3;
        internal UserWinfromControl.UWC_TextBox utb_RtdDataViewerLog;
        private UserWinfromControl.UWC_TextBox utb_RtdMessageText;
        private Button bt_Log_Clear;
        private Button bt_beautifierJson;
        private Button bt_beautifierXml;
        private Label label3;
        private Button bt_MessageClear;
    }
}
