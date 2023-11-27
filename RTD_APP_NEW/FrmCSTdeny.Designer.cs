namespace RTD_APP_NEW
{
    partial class FrmCSTdeny
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdDeny = new System.Windows.Forms.DataGridView();
            this.CSTID_Deny = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EQPTID_Deny = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PORT_ID_Deny = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ABNORM_ISS_RSN_CODE_Deny = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INSDTTM_Deny = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UPDDTTM_Deny = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INSUSER_Deny = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UPDUSER_Deny = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HIST_SEQNO_Deny = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdDeny)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDeny
            // 
            this.grdDeny.AllowUserToAddRows = false;
            this.grdDeny.AllowUserToDeleteRows = false;
            this.grdDeny.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.grdDeny.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdDeny.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdDeny.ColumnHeadersHeight = 35;
            this.grdDeny.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdDeny.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CSTID_Deny,
            this.EQPTID_Deny,
            this.PORT_ID_Deny,
            this.ABNORM_ISS_RSN_CODE_Deny,
            this.INSDTTM_Deny,
            this.UPDDTTM_Deny,
            this.INSUSER_Deny,
            this.UPDUSER_Deny,
            this.HIST_SEQNO_Deny});
            this.grdDeny.Location = new System.Drawing.Point(1, 1);
            this.grdDeny.Name = "grdDeny";
            this.grdDeny.RowHeadersVisible = false;
            this.grdDeny.RowTemplate.Height = 23;
            this.grdDeny.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDeny.Size = new System.Drawing.Size(1173, 286);
            this.grdDeny.TabIndex = 0;
            // 
            // CSTID_Deny
            // 
            this.CSTID_Deny.HeaderText = "캐리어";
            this.CSTID_Deny.Name = "CSTID_Deny";
            // 
            // EQPTID_Deny
            // 
            this.EQPTID_Deny.HeaderText = "요청설비";
            this.EQPTID_Deny.Name = "EQPTID_Deny";
            // 
            // PORT_ID_Deny
            // 
            this.PORT_ID_Deny.HeaderText = "요청포트";
            this.PORT_ID_Deny.Name = "PORT_ID_Deny";
            // 
            // ABNORM_ISS_RSN_CODE_Deny
            // 
            this.ABNORM_ISS_RSN_CODE_Deny.HeaderText = "설명";
            this.ABNORM_ISS_RSN_CODE_Deny.Name = "ABNORM_ISS_RSN_CODE_Deny";
            // 
            // INSDTTM_Deny
            // 
            this.INSDTTM_Deny.HeaderText = "요청시각";
            this.INSDTTM_Deny.Name = "INSDTTM_Deny";
            // 
            // UPDDTTM_Deny
            // 
            this.UPDDTTM_Deny.HeaderText = "수정시각";
            this.UPDDTTM_Deny.Name = "UPDDTTM_Deny";
            // 
            // INSUSER_Deny
            // 
            this.INSUSER_Deny.HeaderText = "요청자";
            this.INSUSER_Deny.Name = "INSUSER_Deny";
            // 
            // UPDUSER_Deny
            // 
            this.UPDUSER_Deny.HeaderText = "수정자";
            this.UPDUSER_Deny.Name = "UPDUSER_Deny";
            // 
            // HIST_SEQNO_Deny
            // 
            this.HIST_SEQNO_Deny.HeaderText = "수정이력";
            this.HIST_SEQNO_Deny.Name = "HIST_SEQNO_Deny";
            // 
            // FrmCSTdeny
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 288);
            this.Controls.Add(this.grdDeny);
            this.Name = "FrmCSTdeny";
            this.Text = "FrmCSTdeny";
            this.Load += new System.EventHandler(this.FrmCSTdeny_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDeny)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdDeny;
        private System.Windows.Forms.DataGridViewTextBoxColumn CSTID_Deny;
        private System.Windows.Forms.DataGridViewTextBoxColumn EQPTID_Deny;
        private System.Windows.Forms.DataGridViewTextBoxColumn PORT_ID_Deny;
        private System.Windows.Forms.DataGridViewTextBoxColumn ABNORM_ISS_RSN_CODE_Deny;
        private System.Windows.Forms.DataGridViewTextBoxColumn INSDTTM_Deny;
        private System.Windows.Forms.DataGridViewTextBoxColumn UPDDTTM_Deny;
        private System.Windows.Forms.DataGridViewTextBoxColumn INSUSER_Deny;
        private System.Windows.Forms.DataGridViewTextBoxColumn UPDUSER_Deny;
        private System.Windows.Forms.DataGridViewTextBoxColumn HIST_SEQNO_Deny;
    }
}