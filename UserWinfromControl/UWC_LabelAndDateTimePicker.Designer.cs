namespace UserWinfromControl
{
    partial class UWC_LabelAndDateTimePicker
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
            dtp_date = new DateTimePicker();
            cb_Text = new CheckBox();
            SuspendLayout();
            // 
            // dtp_date
            // 
            dtp_date.Dock = DockStyle.Right;
            dtp_date.Location = new Point(86, 0);
            dtp_date.Name = "dtp_date";
            dtp_date.Size = new Size(180, 23);
            dtp_date.TabIndex = 0;
            // 
            // cb_Text
            // 
            cb_Text.AutoSize = true;
            cb_Text.Location = new Point(0, 3);
            cb_Text.Name = "cb_Text";
            cb_Text.Size = new Size(84, 19);
            cb_Text.TabIndex = 2;
            cb_Text.Text = "checkBox1";
            cb_Text.UseVisualStyleBackColor = true;
            // 
            // UWC_LabelAndDateTimePicker
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cb_Text);
            Controls.Add(dtp_date);
            Name = "UWC_LabelAndDateTimePicker";
            Size = new Size(266, 22);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtp_date;
        private CheckBox cb_Text;
    }
}
