using System;
using System.IO;
using System.Windows.Forms;
using DesktopApp.Utils;

namespace DesktopApp.Forms
{
    public partial class ImageSettingsForm : Form
    {
        public ImageSettingsForm()
        {
            InitializeComponent();
            LoadCurrentSettings();
        }
        
        private void LoadCurrentSettings()
        {
            // 加载当前设置
            chkUseCustomPath.Checked = ImageConfig.UseCustomPath;
            txtCustomPath.Text = ImageConfig.CustomImagePath;
            lblDefaultPath.Text = $"Default Path: {ImageConfig.DefaultImagePath}";
            lblCurrentPath.Text = $"Current path used: {ImageConfig.CurrentImagePath}";
            
            // 设置控件状态
            txtCustomPath.Enabled = chkUseCustomPath.Checked;
            btnBrowse.Enabled = chkUseCustomPath.Checked;
        }
        
        private void chkUseCustomPath_CheckedChanged(object sender, EventArgs e)
        {
            txtCustomPath.Enabled = chkUseCustomPath.Checked;
            btnBrowse.Enabled = chkUseCustomPath.Checked;
            
            if (!chkUseCustomPath.Checked)
            {
                txtCustomPath.Text = string.Empty;
            }
            
            UpdateCurrentPathLabel();
        }
        
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select the folder where the pictures are stored";
                dialog.ShowNewFolderButton = true;
                
                if (!string.IsNullOrEmpty(txtCustomPath.Text) && Directory.Exists(txtCustomPath.Text))
                {
                    dialog.SelectedPath = txtCustomPath.Text;
                }
                
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtCustomPath.Text = dialog.SelectedPath;
                    UpdateCurrentPathLabel();
                }
            }
        }
        
        private void txtCustomPath_TextChanged(object sender, EventArgs e)
        {
            UpdateCurrentPathLabel();
        }
        
        private void UpdateCurrentPathLabel()
        {
            string currentPath;
            if (chkUseCustomPath.Checked && !string.IsNullOrEmpty(txtCustomPath.Text))
            {
                currentPath = txtCustomPath.Text;
            }
            else
            {
                currentPath = ImageConfig.DefaultImagePath;
            }
            
            lblCurrentPath.Text = $"Current path used: {currentPath}";
            
            // 验证路径
            if (chkUseCustomPath.Checked && !string.IsNullOrEmpty(txtCustomPath.Text))
            {
                bool isValid = ImageConfig.IsValidPath(txtCustomPath.Text);
                lblPathStatus.Text = isValid ? "✓ Path is valid" : "✗ Invalid path or no write permission";
                lblPathStatus.ForeColor = isValid ? System.Drawing.Color.Green : System.Drawing.Color.Red;
                btnOK.Enabled = isValid;
            }
            else
            {
                lblPathStatus.Text = "";
                btnOK.Enabled = true;
            }
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                // 验证自定义路径（如果启用）
                if (chkUseCustomPath.Checked && !string.IsNullOrEmpty(txtCustomPath.Text))
                {
                    if (!ImageConfig.IsValidPath(txtCustomPath.Text))
                    {
                        MessageBox.Show("The specified path is invalid or you do not have write permission. Please select another path.", "Path Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                
                // 保存设置
                ImageConfig.UseCustomPath = chkUseCustomPath.Checked;
                ImageConfig.CustomImagePath = chkUseCustomPath.Checked ? txtCustomPath.Text : string.Empty;
                
                MessageBox.Show("The settings have been saved. The new image will be saved to the specified location。", "Settings saved successfully", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving settings: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        
        private void btnReset_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to reset to default settings?", "Confirm Reset", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                ImageConfig.ResetToDefault();
                LoadCurrentSettings();
                MessageBox.Show("Reset to default settings。", "Reset Complete", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}