namespace UserWinfromControl
{
    partial class UWC_TimerAndBtn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            nud_Timer = new NumericUpDown();
            cb_IsTimer = new CheckBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            bt_Search = new Button();
            ((System.ComponentModel.ISupportInitialize)nud_Timer).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // nud_Timer
            // 
            nud_Timer.Dock = DockStyle.Fill;
            nud_Timer.Location = new Point(3, 25);
            nud_Timer.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            nud_Timer.Minimum = new decimal(new int[] { 20, 0, 0, 0 });
            nud_Timer.Name = "nud_Timer";
            nud_Timer.Size = new Size(79, 23);
            nud_Timer.TabIndex = 1;
            nud_Timer.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // cb_IsTimer
            // 
            cb_IsTimer.AutoSize = true;
            cb_IsTimer.Dock = DockStyle.Fill;
            cb_IsTimer.Location = new Point(3, 3);
            cb_IsTimer.Name = "cb_IsTimer";
            cb_IsTimer.Size = new Size(79, 16);
            cb_IsTimer.TabIndex = 2;
            cb_IsTimer.Text = "Use Timer";
            cb_IsTimer.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(bt_Search, 1, 0);
            tableLayoutPanel1.Controls.Add(cb_IsTimer, 0, 0);
            tableLayoutPanel1.Controls.Add(nud_Timer, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 44F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 56F));
            tableLayoutPanel1.Size = new Size(170, 50);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // bt_Search
            // 
            bt_Search.Dock = DockStyle.Fill;
            bt_Search.Location = new Point(88, 3);
            bt_Search.Name = "bt_Search";
            tableLayoutPanel1.SetRowSpan(bt_Search, 2);
            bt_Search.Size = new Size(79, 44);
            bt_Search.TabIndex = 1;
            bt_Search.Text = "Search";
            bt_Search.UseVisualStyleBackColor = true;
            bt_Search.Click += bt_Search_Click;
            // 
            // UWC_TimerAndBtn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "UWC_TimerAndBtn";
            Size = new Size(170, 50);
            ((System.ComponentModel.ISupportInitialize)nud_Timer).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private CheckBox cb_IsTimer;
        private NumericUpDown nud_Timer;
        private System.Windows.Forms.Timer timer1;
        public Button bt_Search;
    }
}
