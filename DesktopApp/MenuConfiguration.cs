using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DesktopApp.Control.Sidebar._components;
using DesktopApp.Control.Page.Customer;
using DesktopApp.Control.Page.Dashboard;
using DesktopApp.Control.Page.Order;
using DesktopApp.Control.Page.Product;
using DesktopApp.Control.Page.SystemManage.DepartmentManage;
using DesktopApp.Control.Page.SystemManage.RoleManage;
using DesktopApp.Control.Page.SystemManage.UserManage;

namespace DesktopApp
{
    /// <summary>
    /// 菜单配置类，提供多种配置菜单的方式
    /// </summary>
    public static class MenuConfiguration
    {
        /// <summary>
        /// 初始化页面工厂注册
        /// </summary>
        public static void InitializePageFactories()
        {
            var pageFactories = new Dictionary<string, Func<UserControl>>
            {
                { "/dashboard", () => new DashboardPageControl() },
                { "/product", () => new ProductPageControl() },
                { "/customer/manage", () => new CustomerManagerPageControl() },
                { "/product/manage", () => new ProductManagePageControl() },
                { "/order/management", () => new OrderManage() },
                { "/system/department/manage", () => new DepartmentManagePageControl() },
                { "/system/role/manage", () => new RoleManagePageControl() },
                { "/system/user/manage", () => new UserManagePageControl() },

                // 临时使用Dashboard页面的其他页面
                { "/order/create_edit", () => new DashboardPageControl() },
                { "/order/review", () => new DashboardPageControl() },
                { "/dispatch/processing", () => new DashboardPageControl() },
                { "/dispatch/delivery_notes", () => new DashboardPageControl() },
                { "/dispatch/goods_received", () => new DashboardPageControl() },
                { "/inventory/control", () => new DashboardPageControl() },
                { "/inventory/inward_goods", () => new DashboardPageControl() },
                { "/product/catalog", () => new DashboardPageControl() },
                { "/product/addition", () => new DashboardPageControl() },
                { "/service/management", () => new DashboardPageControl() },
                { "/service/refund", () => new DashboardPageControl() },
                { "/service/return", () => new DashboardPageControl() },
                { "/service/repair", () => new DashboardPageControl() }
            };

            PageFactory.RegisterBatch(pageFactories);
        }

        /// <summary>
        /// 使用配置数组的方式定义菜单（最简洁的方式）
        /// </summary>
        public static MenuConfig[] GetMenuConfigs()
        {
            return new MenuConfig[]
            {
                new MenuConfig
                {
                    Text = "Dashboard",
                    PageKey = "/dashboard",
                    IsDefault = true
                },
                new MenuConfig
                {
                    Text = "Order Management",
                    PageKey = "/order/management"
                },
                new MenuConfig
                {
                    Text = "Product",
                    PageKey = "/product",
                    Children = new MenuConfig[]
                    {
                        new MenuConfig { Text = "Product Manage", PageKey = "/product/manage" },
                        new MenuConfig { Text = "Product", PageKey = "/product" }
                    }
                },
                new MenuConfig
                {
                    Text = "Dispatch Processing",
                    PageKey = "/dispatch/processing",
                    Children = new MenuConfig[]
                    {
                        new MenuConfig
                            { Text = "Generate Delivery Notes (PDF)", PageKey = "/dispatch/delivery_notes" },
                        new MenuConfig { Text = "Handling Goods received", PageKey = "/dispatch/goods_received" }
                    }
                },
                new MenuConfig
                {
                    Text = "Customer Manage",
                    PageKey = "/customer/manage"
                },
                new MenuConfig
                {
                    Text = "Inventory Control",
                    PageKey = "/inventory/control",
                    Children = new MenuConfig[]
                    {
                        new MenuConfig { Text = "Record of inward goods", PageKey = "/inventory/inward_goods" },
                        new MenuConfig { Text = "Product Catalog", PageKey = "/product/catalog" },
                        new MenuConfig { Text = "Product Addition", PageKey = "/product/addition" }
                    }
                },
                new MenuConfig
                {
                    Text = "After-service Management",
                    PageKey = "/service/management",
                    Children = new MenuConfig[]
                    {
                        new MenuConfig { Text = "Refund Processing", PageKey = "/service/refund" },
                        new MenuConfig { Text = "Return Processing", PageKey = "/service/return" },
                        new MenuConfig { Text = "Repair Processing", PageKey = "/service/repair" }
                    }
                },
                new MenuConfig
                {
                    Text = "System Manage",
                    PageKey = "/system/manage",
                    Children = new MenuConfig[]
                    {
                        new MenuConfig { Text = "Department Manage", PageKey = "/system/department/manage" },
                        new MenuConfig { Text = "Role Manage", PageKey = "/system/role/manage" },
                        new MenuConfig { Text = "User Manage", PageKey = "/system/user/manage" }
                    }
                }
            };
        }

        /// <summary>
        /// 使用MenuBuilder的流式API配置菜单
        /// </summary>
        /// <param name="showPageAction">显示页面的回调函数</param>
        /// <returns></returns>
        public static MenuBuilder CreateMenuBuilder(System.Action<string> showPageAction)
        {
            return new MenuBuilder(showPageAction)
                .AddItem("Dashboard", "/dashboard", isDefault: true)
                .AddItem("Order Management", "/order/management")
                .AddGroup("Product", "/product", group => group
                    .AddChild("Product Manage", "/product/manage")
                    .AddChild("Product", "/product"))
                .AddGroup("Dispatch Processing", "/dispatch/processing", group => group
                    .AddChild("Generate Delivery Notes (PDF)", "/dispatch/delivery_notes")
                    .AddChild("Handling Goods received", "/dispatch/goods_received"))
                .AddItem("Customer Manage", "/customer/manage")
                .AddGroup("Inventory Control", "/inventory/control", group => group
                    .AddChild("Record of inward goods", "/inventory/inward_goods")
                    .AddChild("Product Catalog", "/product/catalog")
                    .AddChild("Product Addition", "/product/addition"))
                .AddGroup("After-service Management", "/service/management", group => group
                    .AddChild("Refund Processing", "/service/refund")
                    .AddChild("Return Processing", "/service/return")
                    .AddChild("Repair Processing", "/service/repair"))
                .AddGroup("System Manage", "/system/manage", group => group
                    .AddChild("Department Manage", "/system/department/manage")
                    .AddChild("Role Manage", "/system/role/manage")
                    .AddChild("User Manage", "/system/user/manage"));
        }
    }
}