using System;
using System.Windows.Forms;
using DesktopApp.Properties;

namespace DesktopApp
{
    public partial class LoginForm : Form
    {
        private readonly Database.Func.UserFunc _userFunc;

        public LoginForm()
        {
            InitializeComponent();
            Database.Engine dbEngine = Database.Engine.Instance;
            _userFunc = new Database.Func.UserFunc(dbEngine);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show(Resources.LoginForm_btnLogin_Click_Username_and_password_cannot_be_empty_, Resources.LoginForm_btnLogin_Click_login_error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_userFunc.ValidateUser(username, password))
            {
                if (chkRememberMe.Checked)
                {
                    Settings.Default.RememberUsername = true;
                    Settings.Default.Username = username;
                    Settings.Default.Save();
                }
                else
                {
                    Settings.Default.RememberUsername = false;
                    Settings.Default.Username = "";
                    Settings.Default.Save();
                }

                // Open the common dashboard after login
                MainForm mainForm = new MainForm();
                this.Hide();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show(Resources.LoginForm_btnLogin_Click_Username_or_password_error_, Resources.LoginForm_btnLogin_Click_login_error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (Settings.Default.RememberUsername)
            {
                txtUsername.Text = Settings.Default.Username;
                chkRememberMe.Checked = true;
            }
        }
        
        private void linkForgotPassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Resources.LoginForm_linkForgotPassword_Click_Please_contact_the_administrator_or_use_the_password_recovery_function_, Resources.LoginForm_linkForgotPassword_Click_Recover_your_password, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
