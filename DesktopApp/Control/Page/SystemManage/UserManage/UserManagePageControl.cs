using System.Windows.Forms;
using DesktopApp.Database;

namespace DesktopApp.Control.Page.SystemManage.UserManage
{
    public partial class UserManagePageControl : UserControl
    {
        private readonly Database.Func.DepartmentFunc  _departmentFunc;
        private readonly Database.Func.RoleFunc  _roleFunc;
        private readonly Database.Func.UserFunc  _userFunc;
        public UserManagePageControl()
        {
            Engine dbEngine = Engine.Instance;
            _departmentFunc = new Database.Func.DepartmentFunc(dbEngine);
            _roleFunc = new Database.Func.RoleFunc(dbEngine);
            _userFunc = new Database.Func.UserFunc(dbEngine);
            
            InitializeComponent();
        }
    }
}