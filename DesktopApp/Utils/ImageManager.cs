using System;
using System.IO;
using System.Windows.Forms;

namespace DesktopApp.Utils
{
    public static class ImageManager
    {
        private static readonly string ImageDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "SmileSunshine", "ProductImages");
        
        /// <summary>
        /// 保存产品图片到标准位置
        /// </summary>
        /// <param name="sourcePath">源图片路径</param>
        /// <returns>保存后的文件名（仅文件名，不包含路径）</returns>
        public static string SaveProductImage(string sourcePath)
        {
            if (string.IsNullOrEmpty(sourcePath) || !File.Exists(sourcePath))
            {
                throw new ArgumentException("源图片文件不存在");
            }
            
            // 确保目标目录存在
            string targetDirectory = GetImageDirectory();
            Directory.CreateDirectory(targetDirectory);
            
            // 生成新的文件名（时间戳 + 原文件名）
            string originalFileName = Path.GetFileName(sourcePath);
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string newFileName = $"{timestamp}_{originalFileName}";
            string targetPath = Path.Combine(targetDirectory, newFileName);
            
            // 如果目标文件已存在，添加序号
            int counter = 1;
            while (File.Exists(targetPath))
            {
                string nameWithoutExt = Path.GetFileNameWithoutExtension(originalFileName);
                string extension = Path.GetExtension(originalFileName);
                newFileName = $"{timestamp}_{nameWithoutExt}_{counter}{extension}";
                targetPath = Path.Combine(targetDirectory, newFileName);
                counter++;
            }
            
            // 复制文件到目标位置
            File.Copy(sourcePath, targetPath, true);
            
            return newFileName;
        }
        
        /// <summary>
        /// 获取产品图片的完整路径
        /// </summary>
        /// <param name="fileName">图片文件名</param>
        /// <returns>完整路径</returns>
        public static string GetImagePath(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return string.Empty;
            }
            
            return Path.Combine(ImageDirectory, fileName);
        }
        
        /// <summary>
        /// 检查图片文件是否存在
        /// </summary>
        /// <param name="fileName">图片文件名</param>
        /// <returns>是否存在</returns>
        public static bool ImageExists(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return false;
            }
            
            string fullPath = GetImagePath(fileName);
            return File.Exists(fullPath);
        }
        
        /// <summary>
        /// 删除产品图片
        /// </summary>
        /// <param name="fileName">图片文件名</param>
        /// <returns>是否删除成功</returns>
        public static bool DeleteProductImage(string fileName)
        {
            try
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    return false;
                }
                
                string fullPath = GetImagePath(fileName);
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    return true;
                }
                
                return false;
            }
            catch
            {
                return false;
            }
        }
        
        /// <summary>
        /// 获取图片存储目录
        /// </summary>
        /// <returns>图片存储目录路径</returns>
        private static string GetImageDirectory()
        {
            return ImageConfig.CurrentImagePath;
        }
        
        /// <summary>
        /// 兼容性方法：处理旧的相对路径格式
        /// </summary>
        /// <param name="imageUrl">可能是旧格式的图片路径</param>
        /// <returns>完整路径</returns>
        public static string GetCompatibleImagePath(string imageUrl)
        {
            if (string.IsNullOrEmpty(imageUrl))
            {
                return string.Empty;
            }
            
            // 如果是绝对路径，直接返回
            if (Path.IsPathRooted(imageUrl))
            {
                return imageUrl;
            }
            
            // 如果是新格式（仅文件名），使用新的存储位置
            if (!imageUrl.Contains("/") && !imageUrl.Contains("\\"))
            {
                return GetImagePath(imageUrl);
            }
            
            // 处理旧格式的相对路径（如 "Image/product/filename.jpg"）
            // 尝试在应用程序目录中查找
            string appPath = Application.StartupPath;
            if (appPath.Contains("bin"))
            {
                // 开发环境，向上导航到项目根目录
                appPath = Directory.GetParent(appPath).Parent.FullName;
            }
            
            string oldFormatPath = Path.Combine(appPath, imageUrl);
            if (File.Exists(oldFormatPath))
            {
                return oldFormatPath;
            }
            
            // 如果旧路径不存在，尝试提取文件名并在新位置查找
            string fileName = Path.GetFileName(imageUrl);
            return GetImagePath(fileName);
        }
    }
}