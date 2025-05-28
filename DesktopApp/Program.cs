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
            Application.Run(new LoginForm());

            // Dependency Injection Setup
            Database.Engine dbEngine = new Database.Engine();
            Database.Func.UserFunc userFunc = new Database.Func.UserFunc(dbEngine);

        }
    }
}
