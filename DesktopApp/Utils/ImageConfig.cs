using System;
using System.IO;
using System.Configuration;
using Microsoft.Win32;

namespace DesktopApp.Utils
{
    /// <summary>
    /// 图片存储配置管理
    /// </summary>
    public static class ImageConfig
    {
        private const string REGISTRY_KEY = @"SOFTWARE\SmileSunshine\ImageSettings";
        private const string CUSTOM_PATH_VALUE = "CustomImagePath";
        private const string USE_CUSTOM_PATH_VALUE = "UseCustomPath";
        
        /// <summary>
        /// 获取是否使用自定义图片存储路径
        /// </summary>
        public static bool UseCustomPath
        {
            get
            {
                try
                {
                    using (var key = Registry.CurrentUser.OpenSubKey(REGISTRY_KEY))
                    {
                        if (key != null)
                        {
                            var value = key.GetValue(USE_CUSTOM_PATH_VALUE);
                            if (value != null && bool.TryParse(value.ToString(), out bool result))
                            {
                                return result;
                            }
                        }
                    }
                }
                catch
                {
                    // 忽略注册表访问错误
                }
                return false;
            }
            set
            {
                try
                {
                    using (var key = Registry.CurrentUser.CreateSubKey(REGISTRY_KEY))
                    {
                        key?.SetValue(USE_CUSTOM_PATH_VALUE, value.ToString());
                    }
                }
                catch
                {
                    // 忽略注册表写入错误
                }
            }
        }
        
        /// <summary>
        /// 获取或设置自定义图片存储路径
        /// </summary>
        public static string CustomImagePath
        {
            get
            {
                try
                {
                    using (var key = Registry.CurrentUser.OpenSubKey(REGISTRY_KEY))
                    {
                        if (key != null)
                        {
                            var value = key.GetValue(CUSTOM_PATH_VALUE);
                            if (value != null)
                            {
                                string path = value.ToString();
                                if (!string.IsNullOrEmpty(path) && Directory.Exists(path))
                                {
                                    return path;
                                }
                            }
                        }
                    }
                }
                catch
                {
                    // 忽略注册表访问错误
                }
                return string.Empty;
            }
            set
            {
                try
                {
                    using (var key = Registry.CurrentUser.CreateSubKey(REGISTRY_KEY))
                    {
                        key?.SetValue(CUSTOM_PATH_VALUE, value ?? string.Empty);
                    }
                }
                catch
                {
                    // 忽略注册表写入错误
                }
            }
        }
        
        /// <summary>
        /// 获取默认图片存储路径（用户数据目录）
        /// </summary>
        public static string DefaultImagePath
        {
            get
            {
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                return Path.Combine(appDataPath, "SmileSunshine", "ProductImages");
            }
        }
        
        /// <summary>
        /// 获取当前有效的图片存储路径
        /// </summary>
        public static string CurrentImagePath
        {
            get
            {
                if (UseCustomPath && !string.IsNullOrEmpty(CustomImagePath))
                {
                    return CustomImagePath;
                }
                return DefaultImagePath;
            }
        }
        
        /// <summary>
        /// 验证路径是否有效
        /// </summary>
        /// <param name="path">要验证的路径</param>
        /// <returns>路径是否有效</returns>
        public static bool IsValidPath(string path)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(path))
                    return false;
                    
                // 检查路径格式是否有效
                Path.GetFullPath(path);
                
                // 尝试创建目录（如果不存在）
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                
                // 测试写入权限
                string testFile = Path.Combine(path, "test_write_permission.tmp");
                File.WriteAllText(testFile, "test");
                File.Delete(testFile);
                
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        /// <summary>
        /// 重置为默认设置
        /// </summary>
        public static void ResetToDefault()
        {
            UseCustomPath = false;
            CustomImagePath = string.Empty;
        }
    }
}