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
            lblDefaultPath.Text = $"默认路径: {ImageConfig.DefaultImagePath}";
            lblCurrentPath.Text = $"当前使用: {ImageConfig.CurrentImagePath}";
            
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
                dialog.Description = "选择图片存储文件夹";
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
            
            lblCurrentPath.Text = $"当前使用: {currentPath}";
            
            // 验证路径
            if (chkUseCustomPath.Checked && !string.IsNullOrEmpty(txtCustomPath.Text))
            {
                bool isValid = ImageConfig.IsValidPath(txtCustomPath.Text);
                lblPathStatus.Text = isValid ? "✓ 路径有效" : "✗ 路径无效或无写入权限";
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
                        MessageBox.Show("指定的路径无效或没有写入权限，请选择其他路径。", "路径错误", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                
                // 保存设置
                ImageConfig.UseCustomPath = chkUseCustomPath.Checked;
                ImageConfig.CustomImagePath = chkUseCustomPath.Checked ? txtCustomPath.Text : string.Empty;
                
                MessageBox.Show("设置已保存。新的图片将保存到指定位置。", "设置保存成功", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存设置时出错: {ex.Message}", "错误", 
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
            var result = MessageBox.Show("确定要重置为默认设置吗？", "确认重置", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                ImageConfig.ResetToDefault();
                LoadCurrentSettings();
                MessageBox.Show("已重置为默认设置。", "重置完成", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}