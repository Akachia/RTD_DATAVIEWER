namespace RTD_APP_NEW
{
    partial class FrmRout
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdRout = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdRout)).BeginInit();
            this.SuspendLayout();
            // 
            // grdRout
            // 
            this.grdRout.AllowUserToAddRows = false;
            this.grdRout.AllowUserToDeleteRows = false;
            this.grdRout.AllowUserToResizeRows = false;
            this.grdRout.ColumnHeadersHeight = 35;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Gulim", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdRout.DefaultCellStyle = dataGridViewCellStyle1;
            this.grdRout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRout.GridColor = System.Drawing.SystemColors.Control;
            this.grdRout.Location = new System.Drawing.Point(0, 0);
            this.grdRout.Name = "grdRout";
            this.grdRout.ReadOnly = true;
            this.grdRout.RowHeadersVisible = false;
            this.grdRout.RowTemplate.Height = 23;
            this.grdRout.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdRout.Size = new System.Drawing.Size(469, 455);
            this.grdRout.TabIndex = 1;
            // 
            // FrmRout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 455);
            this.Controls.Add(this.grdRout);
            this.Name = "FrmRout";
            this.Text = "FrmRout";
            this.Load += new System.EventHandler(this.FrmRout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdRout)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdRout;
    }
}