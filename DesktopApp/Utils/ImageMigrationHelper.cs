using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DesktopApp.Database;
using DesktopApp.Database.Func;

namespace DesktopApp.Utils
{
    /// <summary>
    /// 图片迁移助手，用于将旧格式的图片路径迁移到新的存储位置
    /// </summary>
    public static class ImageMigrationHelper
    {
        /// <summary>
        /// 执行图片迁移
        /// </summary>
        /// <returns>迁移结果信息</returns>
        public static MigrationResult MigrateImages()
        {
            var result = new MigrationResult();
            var productFunc = new ProductFunc();
            
            try
            {
                // 获取所有产品
                var products = productFunc.GetAllProducts();
                
                foreach (var product in products)
                {
                    if (string.IsNullOrEmpty(product.ImageUrl))
                    {
                        continue;
                    }
                    
                    // 检查是否需要迁移
                    if (NeedsMigration(product.ImageUrl))
                    {
                        try
                        {
                            string newImageUrl = MigrateProductImage(product.ImageUrl);
                            if (!string.IsNullOrEmpty(newImageUrl))
                            {
                                // 更新数据库中的图片路径
                                product.ImageUrl = newImageUrl;
                                if (productFunc.UpdateProduct(product))
                                {
                                    result.SuccessCount++;
                                    result.MigratedFiles.Add($"{product.Name}: {newImageUrl}");
                                }
                                else
                                {
                                    result.FailureCount++;
                                    result.Errors.Add($"更新产品 {product.Name} 的数据库记录失败");
                                }
                            }
                            else
                            {
                                result.SkippedCount++;
                                result.Errors.Add($"产品 {product.Name} 的图片文件不存在: {product.ImageUrl}");
                            }
                        }
                        catch (Exception ex)
                        {
                            result.FailureCount++;
                            result.Errors.Add($"迁移产品 {product.Name} 的图片时出错: {ex.Message}");
                        }
                    }
                    else
                    {
                        result.SkippedCount++;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Errors.Add($"迁移过程中发生错误: {ex.Message}");
            }
            
            return result;
        }
        
        /// <summary>
        /// 检查图片是否需要迁移
        /// </summary>
        /// <param name="imageUrl">图片URL</param>
        /// <returns>是否需要迁移</returns>
        private static bool NeedsMigration(string imageUrl)
        {
            if (string.IsNullOrEmpty(imageUrl))
            {
                return false;
            }
            
            // 如果是绝对路径或包含路径分隔符，则需要迁移
            return Path.IsPathRooted(imageUrl) || 
                   imageUrl.Contains("/") || 
                   imageUrl.Contains("\\");
        }
        
        /// <summary>
        /// 迁移单个产品图片
        /// </summary>
        /// <param name="oldImageUrl">旧的图片路径</param>
        /// <returns>新的图片文件名，如果迁移失败返回空字符串</returns>
        private static string MigrateProductImage(string oldImageUrl)
        {
            try
            {
                // 获取旧图片的完整路径
                string oldFullPath = GetOldImagePath(oldImageUrl);
                
                if (!File.Exists(oldFullPath))
                {
                    return string.Empty;
                }
                
                // 使用ImageManager保存到新位置
                string newFileName = ImageManager.SaveProductImage(oldFullPath);
                
                return newFileName;
            }
            catch
            {
                return string.Empty;
            }
        }
        
        /// <summary>
        /// 获取旧图片的完整路径
        /// </summary>
        /// <param name="imageUrl">图片URL</param>
        /// <returns>完整路径</returns>
        private static string GetOldImagePath(string imageUrl)
        {
            if (Path.IsPathRooted(imageUrl))
            {
                return imageUrl;
            }
            
            // 处理相对路径
            string appPath = Application.StartupPath;
            if (appPath.Contains("bin"))
            {
                // 开发环境，向上导航到项目根目录
                appPath = Directory.GetParent(appPath).Parent.FullName;
            }
            
            return Path.Combine(appPath, imageUrl);
        }
        
        /// <summary>
        /// 显示迁移结果对话框
        /// </summary>
        /// <param name="result">迁移结果</param>
        public static void ShowMigrationResult(MigrationResult result)
        {
            string message = $"图片迁移完成！\n\n";
            message += $"成功迁移: {result.SuccessCount} 个文件\n";
            message += $"跳过: {result.SkippedCount} 个文件\n";
            message += $"失败: {result.FailureCount} 个文件\n";
            
            if (result.Errors.Any())
            {
                message += $"\n错误详情:\n{string.Join("\n", result.Errors.Take(5))}";
                if (result.Errors.Count > 5)
                {
                    message += $"\n... 还有 {result.Errors.Count - 5} 个错误";
                }
            }
            
            MessageBoxIcon icon = result.FailureCount > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information;
            MessageBox.Show(message, "图片迁移结果", MessageBoxButtons.OK, icon);
        }
    }
    
    /// <summary>
    /// 迁移结果
    /// </summary>
    public class MigrationResult
    {
        public int SuccessCount { get; set; } = 0;
        public int FailureCount { get; set; } = 0;
        public int SkippedCount { get; set; } = 0;
        public List<string> MigratedFiles { get; set; } = new List<string>();
        public List<string> Errors { get; set; } = new List<string>();
    }
}