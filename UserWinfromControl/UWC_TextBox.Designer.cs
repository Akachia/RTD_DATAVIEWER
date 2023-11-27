namespace UserWinfromControl
{
    partial class UWC_TextBox
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
            rtb_LogBox = new RichTextBox();
            SuspendLayout();
            // 
            // rtb_LogBox
            // 
            rtb_LogBox.Dock = DockStyle.Fill;
            rtb_LogBox.Location = new Point(0, 0);
            rtb_LogBox.Name = "rtb_LogBox";
            rtb_LogBox.Size = new Size(369, 344);
            rtb_LogBox.TabIndex = 0;
            rtb_LogBox.Text = "";
            // 
            // UWC_TextBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(rtb_LogBox);
            Name = "UWC_TextBox";
            Size = new Size(369, 344);
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox rtb_LogBox;
    }
}
