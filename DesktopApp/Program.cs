using System;
using System.Windows.Forms;

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

            Application.Run(new LoginForm());
        }
    }
}
