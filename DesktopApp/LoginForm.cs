using System;
using System.Windows.Forms;
using DesktopApp.Properties;

namespace DesktopApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
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
            
            if (username == "admin" && password == "password")
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

                Form1 mainForm = new Form1();
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
    }
}