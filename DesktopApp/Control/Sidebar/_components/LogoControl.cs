using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DesktopApp.Control.Sidebar._components
{
    public partial class LogoControl : UserControl
    {
        public LogoControl()
        {
            InitializeComponent();
            SetLogoImage();
        }
        
        public void SetLogoImage()
        {
            try
            {
                string logoPath = Path.Combine(Application.StartupPath, "Image", "logo-1024x1024.png");
                if (File.Exists(logoPath))
                {
                    logoPictureBox.Image = Image.FromFile(logoPath);
                }
                else
                {
                    // 如果找不到Logo文件，创建一个简单的占位符
                    Bitmap placeholder = new Bitmap(40, 40);
                    using (Graphics g = Graphics.FromImage(placeholder))
                    {
                        g.FillEllipse(Brushes.Orange, 0, 0, 40, 40);
                        g.DrawString("SS", new Font("Arial", 12, FontStyle.Bold), Brushes.White, 8, 12);
                    }
                    logoPictureBox.Image = placeholder;
                }
            }
            catch
            {
                // 如果加载失败，使用默认占位符
                Bitmap placeholder = new Bitmap(40, 40);
                using (Graphics g = Graphics.FromImage(placeholder))
                {
                    g.FillEllipse(Brushes.Orange, 0, 0, 40, 40);
                    g.DrawString("SS", new Font("Arial", 12, FontStyle.Bold), Brushes.White, 8, 12);
                }
                logoPictureBox.Image = placeholder;
            }
        }
    }
}