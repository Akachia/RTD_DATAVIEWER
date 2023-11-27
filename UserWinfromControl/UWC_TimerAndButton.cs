namespace UserWinfromControl
{

    public partial class UWC_TimerAndBtn : UserControl
    {
        public System.Windows.Forms.Timer timer = new();

        public int Interval
        {
            get { return decimal.ToInt32(nud_Timer.Value); }
            set { timer.Interval = value; }
        }

        public bool IsUseTimer
        {
            get { return cb_IsTimer.Checked; }
            set { cb_IsTimer.Checked = value; }
        }


        public UWC_TimerAndBtn()
        {
            InitializeComponent();
        }

        private void bt_Search_Click(object sender, EventArgs e)
        {

        }
    }
}
