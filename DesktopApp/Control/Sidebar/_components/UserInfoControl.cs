using System;
using System.Windows.Forms;

namespace DesktopApp.Control.Sidebar._components
{
    public partial class UserInfoControl : UserControl
    {
        private Timer timeTimer;
        
        public UserInfoControl()
        {
            InitializeComponent();
            InitializeUserInfo();
            InitializeTimer();
        }
        
        private void InitializeUserInfo()
        {
            // 设置默认用户信息，实际应用中应该从登录信息获取
            usernameLabel.Text = "Administrator";
            positionLabel.Text = "System Administrator";
            UpdateSystemTime();
        }
        
        private void InitializeTimer()
        {
            timeTimer = new Timer();
            timeTimer.Interval = 1000; // 每秒更新一次
            timeTimer.Tick += TimeTimer_Tick;
            timeTimer.Start();
        }
        
        private void TimeTimer_Tick(object sender, EventArgs e)
        {
            UpdateSystemTime();
        }
        
        private void UpdateSystemTime()
        {
            timeLabel.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        
        // 公共方法用于设置用户信息
        public void SetUserInfo(string username, string position)
        {
            usernameLabel.Text = username;
            positionLabel.Text = position;
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                timeTimer?.Stop();
                timeTimer?.Dispose();
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}