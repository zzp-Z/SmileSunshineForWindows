using System;
using System.Windows.Forms;
using DesktopApp.Utils;
using DesktopApp.Database.Func;
using DesktopApp.Database;

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
            // 从UserSession获取当前用户信息
            if (UserSession.IsLoggedIn())
            {
                var currentUser = UserSession.GetCurrentUser();
                if (currentUser != null)
                {
                    usernameLabel.Text = currentUser.RealName ?? currentUser.Username;
                    
                    // 获取用户角色信息
                    if (currentUser.Username == "Admin")
                    {
                        positionLabel.Text = "系统管理员";
                    }
                    else
                    {
                        var userFunc = new UserFunc();
                        var userRoles = userFunc.GetUserRoles(currentUser.Id);
                        if (userRoles != null && userRoles.Count > 0)
                        {
                            positionLabel.Text = userRoles[0].RoleName;
                        }
                        else
                        {
                            positionLabel.Text = "用户";
                        }
                    }
                }
                else
                {
                    usernameLabel.Text = "未知用户";
                    positionLabel.Text = "";
                }
            }
            else
            {
                usernameLabel.Text = "未登录";
                positionLabel.Text = "";
            }
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
        
        // 退出登录按钮点击事件
        private void LogoutButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("确定要退出登录吗？", "确认退出", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // 清除用户会话
                UserSession.ClearSession();
                
                // 关闭主窗体
                var mainForm = this.FindForm();
                mainForm?.Hide();
                
                // 显示登录窗体
                var loginForm = new LoginForm();
                loginForm.ShowDialog();
                
                // 如果登录窗体关闭，退出应用程序
                Application.Exit();
            }
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