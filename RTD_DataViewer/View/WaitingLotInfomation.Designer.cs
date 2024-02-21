namespace RTD_DataViewer.View
{
    partial class WaitingLotInfomation
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
            tableLayoutPanel5 = new TableLayoutPanel();
            cb_Cststat = new ComboBox();
            ckb_Send = new CheckBox();
            ckb_Receive = new CheckBox();
            ckb_Delete = new CheckBox();
            lAtb_TransList_CarrierId = new UserWinfromControl.UWC_LabelAndTextBox();
            lAtb_TransList_ReqEqp = new UserWinfromControl.UWC_LabelAndTextBox();
            lAtb_TransList_LaneId = new UserWinfromControl.UWC_LabelAndTextBox();
            lAtb_TransList_ToEqp = new UserWinfromControl.UWC_LabelAndTextBox();
            watingWips = new UserWinfromControl.UWC_DataGridView();
            transList_CstHist = new UserWinfromControl.UWC_DataGridView();
            transList_CstInfo = new UserWinfromControl.UWC_DataGridView();
            ckb_IsFaulty = new CheckBox();
            ckb_Abnormal = new CheckBox();
            ckb_Moving = new CheckBox();
            ckb_Cancel = new CheckBox();
            bt_Search = new Button();
            tableLayoutPanel5.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 9;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayoutPanel5.Controls.Add(cb_Cststat, 5, 0);
            tableLayoutPanel5.Controls.Add(ckb_Send, 2, 0);
            tableLayoutPanel5.Controls.Add(ckb_Receive, 3, 0);
            tableLayoutPanel5.Controls.Add(ckb_Delete, 2, 1);
            tableLayoutPanel5.Controls.Add(lAtb_TransList_CarrierId, 6, 0);
            tableLayoutPanel5.Controls.Add(lAtb_TransList_ReqEqp, 7, 0);
            tableLayoutPanel5.Controls.Add(lAtb_TransList_LaneId, 6, 1);
            tableLayoutPanel5.Controls.Add(lAtb_TransList_ToEqp, 7, 1);
            tableLayoutPanel5.Controls.Add(watingWips, 0, 2);
            tableLayoutPanel5.Controls.Add(transList_CstHist, 7, 2);
            tableLayoutPanel5.Controls.Add(transList_CstInfo, 7, 3);
            tableLayoutPanel5.Controls.Add(ckb_IsFaulty, 5, 1);
            tableLayoutPanel5.Controls.Add(ckb_Abnormal, 3, 1);
            tableLayoutPanel5.Controls.Add(ckb_Moving, 4, 0);
            tableLayoutPanel5.Controls.Add(ckb_Cancel, 4, 1);
            tableLayoutPanel5.Controls.Add(bt_Search, 8, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(0, 0);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 4;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 110F));
            tableLayoutPanel5.Size = new Size(1400, 600);
            tableLayoutPanel5.TabIndex = 2;
            // 
            // cb_Cststat
            // 
            cb_Cststat.Dock = DockStyle.Fill;
            cb_Cststat.FormattingEnabled = true;
            cb_Cststat.Items.AddRange(new object[] { "모두 : ALL", "실트레이 : U", "공트레이 : E" });
            cb_Cststat.Location = new Point(843, 3);
            cb_Cststat.Name = "cb_Cststat";
            cb_Cststat.Size = new Size(106, 23);
            cb_Cststat.TabIndex = 7;
            // 
            // ckb_Send
            // 
            ckb_Send.AutoSize = true;
            ckb_Send.Checked = true;
            ckb_Send.CheckState = CheckState.Checked;
            ckb_Send.Dock = DockStyle.Fill;
            ckb_Send.Location = new Point(591, 3);
            ckb_Send.Name = "ckb_Send";
            ckb_Send.RightToLeft = RightToLeft.Yes;
            ckb_Send.Size = new Size(78, 24);
            ckb_Send.TabIndex = 8;
            ckb_Send.Text = "Send";
            ckb_Send.UseVisualStyleBackColor = true;
            // 
            // ckb_Receive
            // 
            ckb_Receive.AutoSize = true;
            ckb_Receive.Checked = true;
            ckb_Receive.CheckState = CheckState.Checked;
            ckb_Receive.Dock = DockStyle.Fill;
            ckb_Receive.Location = new Point(675, 3);
            ckb_Receive.Name = "ckb_Receive";
            ckb_Receive.RightToLeft = RightToLeft.Yes;
            ckb_Receive.Size = new Size(78, 24);
            ckb_Receive.TabIndex = 9;
            ckb_Receive.Text = "Receive";
            ckb_Receive.UseVisualStyleBackColor = true;
            // 
            // ckb_Delete
            // 
            ckb_Delete.AutoSize = true;
            ckb_Delete.Dock = DockStyle.Fill;
            ckb_Delete.Location = new Point(591, 33);
            ckb_Delete.Name = "ckb_Delete";
            ckb_Delete.RightToLeft = RightToLeft.Yes;
            ckb_Delete.Size = new Size(78, 24);
            ckb_Delete.TabIndex = 10;
            ckb_Delete.Text = "Delete";
            ckb_Delete.UseVisualStyleBackColor = true;
            // 
            // lAtb_TransList_CarrierId
            // 
            lAtb_TransList_CarrierId.Dock = DockStyle.Fill;
            lAtb_TransList_CarrierId.Lb_Text = "Carrier ID";
            lAtb_TransList_CarrierId.Location = new Point(955, 3);
            lAtb_TransList_CarrierId.Name = "lAtb_TransList_CarrierId";
            lAtb_TransList_CarrierId.Size = new Size(176, 24);
            lAtb_TransList_CarrierId.TabIndex = 15;
            lAtb_TransList_CarrierId.Tb_Text = "";
            lAtb_TransList_CarrierId.VariableName = "";
            // 
            // lAtb_TransList_ReqEqp
            // 
            lAtb_TransList_ReqEqp.Dock = DockStyle.Fill;
            lAtb_TransList_ReqEqp.Lb_Text = "출발지 설비";
            lAtb_TransList_ReqEqp.Location = new Point(1137, 3);
            lAtb_TransList_ReqEqp.Name = "lAtb_TransList_ReqEqp";
            lAtb_TransList_ReqEqp.Size = new Size(176, 24);
            lAtb_TransList_ReqEqp.TabIndex = 16;
            lAtb_TransList_ReqEqp.Tb_Text = "";
            lAtb_TransList_ReqEqp.VariableName = "";
            // 
            // lAtb_TransList_LaneId
            // 
            lAtb_TransList_LaneId.Dock = DockStyle.Fill;
            lAtb_TransList_LaneId.Lb_Text = "Lane ID";
            lAtb_TransList_LaneId.Location = new Point(955, 33);
            lAtb_TransList_LaneId.Name = "lAtb_TransList_LaneId";
            lAtb_TransList_LaneId.Size = new Size(176, 24);
            lAtb_TransList_LaneId.TabIndex = 17;
            lAtb_TransList_LaneId.Tb_Text = "";
            lAtb_TransList_LaneId.VariableName = "";
            // 
            // lAtb_TransList_ToEqp
            // 
            lAtb_TransList_ToEqp.Dock = DockStyle.Fill;
            lAtb_TransList_ToEqp.Lb_Text = "목적지 설비";
            lAtb_TransList_ToEqp.Location = new Point(1137, 33);
            lAtb_TransList_ToEqp.Name = "lAtb_TransList_ToEqp";
            lAtb_TransList_ToEqp.Size = new Size(176, 24);
            lAtb_TransList_ToEqp.TabIndex = 18;
            lAtb_TransList_ToEqp.Tb_Text = "";
            lAtb_TransList_ToEqp.VariableName = "";
            // 
            // watingWips
            // 
            tableLayoutPanel5.SetColumnSpan(watingWips, 7);
            watingWips.Dock = DockStyle.Fill;
            watingWips.Lb_Text = "SqlName";
            watingWips.Lb_Text2 = "";
            watingWips.Location = new Point(3, 63);
            watingWips.Name = "watingWips";
            tableLayoutPanel5.SetRowSpan(watingWips, 2);
            watingWips.Size = new Size(1128, 534);
            watingWips.TabIndex = 19;
            // 
            // transList_CstHist
            // 
            tableLayoutPanel5.SetColumnSpan(transList_CstHist, 2);
            transList_CstHist.Dock = DockStyle.Fill;
            transList_CstHist.Lb_Text = "SqlName";
            transList_CstHist.Lb_Text2 = "";
            transList_CstHist.Location = new Point(1137, 63);
            transList_CstHist.Name = "transList_CstHist";
            transList_CstHist.Size = new Size(260, 424);
            transList_CstHist.TabIndex = 20;
            // 
            // transList_CstInfo
            // 
            tableLayoutPanel5.SetColumnSpan(transList_CstInfo, 2);
            transList_CstInfo.Dock = DockStyle.Fill;
            transList_CstInfo.Lb_Text = "SqlName";
            transList_CstInfo.Lb_Text2 = "";
            transList_CstInfo.Location = new Point(1137, 493);
            transList_CstInfo.Name = "transList_CstInfo";
            transList_CstInfo.Size = new Size(260, 104);
            transList_CstInfo.TabIndex = 21;
            // 
            // ckb_IsFaulty
            // 
            ckb_IsFaulty.AutoSize = true;
            ckb_IsFaulty.Dock = DockStyle.Fill;
            ckb_IsFaulty.Location = new Point(843, 33);
            ckb_IsFaulty.Name = "ckb_IsFaulty";
            ckb_IsFaulty.RightToLeft = RightToLeft.Yes;
            ckb_IsFaulty.Size = new Size(106, 24);
            ckb_IsFaulty.TabIndex = 11;
            ckb_IsFaulty.Text = "불량적재";
            ckb_IsFaulty.UseVisualStyleBackColor = true;
            // 
            // ckb_Abnormal
            // 
            ckb_Abnormal.AutoSize = true;
            ckb_Abnormal.Dock = DockStyle.Fill;
            ckb_Abnormal.Location = new Point(675, 33);
            ckb_Abnormal.Name = "ckb_Abnormal";
            ckb_Abnormal.RightToLeft = RightToLeft.Yes;
            ckb_Abnormal.Size = new Size(78, 24);
            ckb_Abnormal.TabIndex = 22;
            ckb_Abnormal.Text = "Abnormal";
            ckb_Abnormal.TextAlign = ContentAlignment.MiddleCenter;
            ckb_Abnormal.UseVisualStyleBackColor = true;
            // 
            // ckb_Moving
            // 
            ckb_Moving.AutoSize = true;
            ckb_Moving.Checked = true;
            ckb_Moving.CheckState = CheckState.Checked;
            ckb_Moving.Dock = DockStyle.Fill;
            ckb_Moving.Location = new Point(759, 3);
            ckb_Moving.Name = "ckb_Moving";
            ckb_Moving.RightToLeft = RightToLeft.Yes;
            ckb_Moving.Size = new Size(78, 24);
            ckb_Moving.TabIndex = 23;
            ckb_Moving.Text = "Moving";
            ckb_Moving.UseVisualStyleBackColor = true;
            // 
            // ckb_Cancel
            // 
            ckb_Cancel.AutoSize = true;
            ckb_Cancel.Dock = DockStyle.Fill;
            ckb_Cancel.Location = new Point(759, 33);
            ckb_Cancel.Name = "ckb_Cancel";
            ckb_Cancel.RightToLeft = RightToLeft.Yes;
            ckb_Cancel.Size = new Size(78, 24);
            ckb_Cancel.TabIndex = 24;
            ckb_Cancel.Text = "Cancel";
            ckb_Cancel.UseVisualStyleBackColor = true;
            // 
            // bt_Search
            // 
            bt_Search.Dock = DockStyle.Fill;
            bt_Search.Location = new Point(1319, 3);
            bt_Search.Name = "bt_Search";
            tableLayoutPanel5.SetRowSpan(bt_Search, 2);
            bt_Search.Size = new Size(78, 54);
            bt_Search.TabIndex = 25;
            bt_Search.Text = "Search";
            bt_Search.UseVisualStyleBackColor = true;
            bt_Search.Click += bt_Search_Click;
            // 
            // WaitingLotInfomation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel5);
            Name = "WaitingLotInfomation";
            Size = new Size(1400, 600);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel5;
        internal ComboBox cb_Cststat;
        internal CheckBox ckb_Send;
        internal CheckBox ckb_Receive;
        internal CheckBox ckb_Delete;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_TransList_CarrierId;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_TransList_ReqEqp;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_TransList_LaneId;
        internal UserWinfromControl.UWC_LabelAndTextBox lAtb_TransList_ToEqp;
        internal UserWinfromControl.UWC_DataGridView watingWips;
        internal UserWinfromControl.UWC_DataGridView transList_CstHist;
        internal UserWinfromControl.UWC_DataGridView transList_CstInfo;
        internal CheckBox ckb_IsFaulty;
        private CheckBox ckb_Abnormal;
        private CheckBox ckb_Moving;
        private CheckBox ckb_Cancel;
        private Button bt_Search;
    }
}
