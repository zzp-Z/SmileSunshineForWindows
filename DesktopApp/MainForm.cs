using System.Collections.Generic;
using System;
using System.Drawing;
using System.Windows.Forms;
using DesktopApp.Control.Page.Customer;
using DesktopApp.Control.Sidebar._components;
using DesktopApp.Control.Page.Dashboard;
using DesktopApp.Control.Page.Order;
using DesktopApp.Control.Page.Product;
using DesktopApp.Control.Page.SystemManage.DepartmentManage;
using DesktopApp.Control.Page.SystemManage.RoleManage;
using DesktopApp.Control.Page.SystemManage.UserManage;
using DesktopApp.Utils;

namespace DesktopApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
            // 初始化页面工厂
            MenuConfiguration.InitializePageFactories();
            
            // 使用权限过滤的菜单配置
            var menuItems = MenuConfiguration.CreateFilteredMenuBuilder(ShowPage).Build();
            
            // 方式2：使用流式API（可选）
            // var menuItems = MenuConfiguration.CreateMenuBuilder(ShowPage).Build();
            
            // 方式3：直接使用MenuBuilder（可选）
            // var menuItems = new MenuBuilder(ShowPage)
            //     .AddItem("Dashboard", "dashboard_page", isDefault: true)
            //     .AddItem("Order Management", "order_management_page")
            //     .AddGroup("Product", "product_page", group => group
            //         .AddChild("Product Manage", "product_manage_page")
            //         .AddChild("Product", "product_page"))
            //     .Build();
            
            sidebarControl.SetMenuItems(menuItems);
            
            // 默认显示Dashboard页面
            ShowPage("/dashboard");
        }
        
        private void ShowPage(string pageKey)
        {
            // 检查用户权限
            if (!UserSession.HasPermission(pageKey))
            {
                // 显示无权限访问的提示
                mainContentPanel.Controls.Clear();
                var noPermissionLabel = new Label
                {
                    Text = $"您没有权限访问页面 '{pageKey}'",
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new System.Drawing.Font("Microsoft YaHei", 12F),
                    ForeColor = Color.Red
                };
                mainContentPanel.Controls.Add(noPermissionLabel);
                return;
            }

            // 清除当前内容
            mainContentPanel.Controls.Clear();
            
            // 使用页面工厂创建页面控件，完全消除switch语句
            var pageControl = PageFactory.CreatePage(pageKey);
            
            if (pageControl != null)
            {
                pageControl.Dock = DockStyle.Fill;
                mainContentPanel.Controls.Add(pageControl);
            }
            else
            {
                // 如果页面未注册，显示错误信息或默认页面
                var errorLabel = new Label
                {
                    Text = $"页面 '{pageKey}' 未找到",
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new System.Drawing.Font("Microsoft YaHei", 12F)
                };
                mainContentPanel.Controls.Add(errorLabel);
            }
        }
    }
}