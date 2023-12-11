namespace UserWinfromControl
{
    partial class UWC_LabelAndTextBox
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
            textBox = new TextBox();
            lb_Txt = new Label();
            SuspendLayout();
            // 
            // textBox
            // 
            textBox.Dock = DockStyle.Fill;
            textBox.Location = new Point(0, 0);
            textBox.Name = "textBox";
            textBox.Size = new Size(200, 23);
            textBox.TabIndex = 0;
            textBox.Click += textBox_Click;
            textBox.TextChanged += textBox_TextChanged;
            textBox.Leave += textBox_Leave;
            // 
            // lb_Txt
            // 
            lb_Txt.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lb_Txt.AutoSize = true;
            lb_Txt.Location = new Point(3, 3);
            lb_Txt.Name = "lb_Txt";
            lb_Txt.Size = new Size(39, 15);
            lb_Txt.TabIndex = 1;
            lb_Txt.Text = "label1";
            // 
            // UWC_LabelAndTextBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lb_Txt);
            Controls.Add(textBox);
            Name = "UWC_LabelAndTextBox";
            Size = new Size(200, 25);
            MouseHover += UWC_LabelAndTextBox_MouseHover;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lb_Txt;
        private TextBox textBox;
    }
}
