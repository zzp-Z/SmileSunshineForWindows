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

            // Dependency Injection Setup
            Database.Engine dbEngine = new Database.Engine();
            Database.Func.UserFunc userFunc = new Database.Func.UserFunc(dbEngine);
            Database.Func.DepartmentFunc departmentFunc = new Database.Func.DepartmentFunc(dbEngine);
            Database.Func.RoleFunc roleFunc = new Database.Func.RoleFunc(dbEngine);

            Application.Run(new UserManagementForm(departmentFunc, userFunc, roleFunc));
        }
    }
}
