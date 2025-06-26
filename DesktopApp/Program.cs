using System;
using System.Windows.Forms;
using DesktopApp.Control.Page.Product;
using DesktopApp.Utils;

namespace DesktopApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Dependency Injection Setup - Using Singleton Database Engine

            // 启动登录窗口
            Application.Run(new LoginForm());
            
            // 程序退出时清除用户会话
            UserSession.ClearSession();
        }
    }
}
