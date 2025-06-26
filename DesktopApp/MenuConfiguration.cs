using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DesktopApp.Control.Sidebar._components;
using DesktopApp.Control.Page.Customer;
using DesktopApp.Control.Page.Dashboard;
using DesktopApp.Control.Page.Order;
using DesktopApp.Control.Page.Product;
using DesktopApp.Control.Page.SystemManage.DepartmentManage;
using DesktopApp.Control.Page.SystemManage.Permission;
using DesktopApp.Control.Page.SystemManage.RoleManage;
using DesktopApp.Control.Page.SystemManage.UserManage;
using DesktopApp.Utils;

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
                { "/order", () => new OrderManage() },
                { "/system/department/manage", () => new DepartmentManagePageControl() },
                { "/system/role/manage", () => new RoleManagePageControl() },
                { "/system/user/manage", () => new UserManagePageControl() },
                { "/system/permission/manage", () => new PermissionManagePageControl() },

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
            var allMenuConfigs = new MenuConfig[]
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
                    PageKey = "/order"
                },
                new MenuConfig
                {
                    Text = "Product",
                    PageKey = "/product",
                    Children = new MenuConfig[]
                    {
                        new MenuConfig { Text = "Product Manage", PageKey = "/product/manage" },
                        new MenuConfig { Text = "Product", PageKey = "/product/product" }
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
                        new MenuConfig { Text = "User Manage", PageKey = "/system/user/manage" },
                        new MenuConfig { Text = "Permission Manage", PageKey = "/system/permission/manage" }
                    }
                }
            };
            
            // 根据用户权限过滤菜单
            return FilterMenusByPermission(allMenuConfigs);
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
                .AddItem("Order Management", "/order")
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

        /// <summary>
        /// 根据用户权限过滤菜单配置
        /// </summary>
        /// <param name="menuConfigs">原始菜单配置</param>
        /// <returns>过滤后的菜单配置</returns>
        private static MenuConfig[] FilterMenusByPermission(MenuConfig[] menuConfigs)
        {
            if (!UserSession.IsLoggedIn())
            {
                return new MenuConfig[0];
            }

            var filteredMenus = new List<MenuConfig>();

            foreach (var menu in menuConfigs)
            {
                var filteredMenu = FilterMenuConfig(menu);
                if (filteredMenu != null)
                {
                    filteredMenus.Add(filteredMenu);
                }
            }

            return filteredMenus.ToArray();
        }

        /// <summary>
        /// 过滤单个菜单配置项
        /// </summary>
        /// <param name="menuConfig">菜单配置项</param>
        /// <returns>过滤后的菜单配置项，如果无权限则返回null</returns>
        private static MenuConfig FilterMenuConfig(MenuConfig menuConfig)
        {
            if (menuConfig == null)
            {
                return null;
            }

            // 检查当前菜单项权限
            bool hasPermission = string.IsNullOrEmpty(menuConfig.PageKey) || 
                               UserSession.HasPermission(menuConfig.PageKey);

            // 处理子菜单
            MenuConfig[] filteredChildren = null;
            if (menuConfig.Children != null && menuConfig.Children.Length > 0)
            {
                var childList = new List<MenuConfig>();
                foreach (var child in menuConfig.Children)
                {
                    var filteredChild = FilterMenuConfig(child);
                    if (filteredChild != null)
                    {
                        childList.Add(filteredChild);
                    }
                }
                filteredChildren = childList.ToArray();
            }

            // 如果当前菜单项无权限且没有可访问的子菜单，则不显示
            if (!hasPermission && (filteredChildren == null || filteredChildren.Length == 0))
            {
                return null;
            }

            // 创建过滤后的菜单项
            return new MenuConfig
            {
                Text = menuConfig.Text,
                PageKey = hasPermission ? menuConfig.PageKey : null,
                IsDefault = hasPermission && menuConfig.IsDefault,
                Children = filteredChildren,
                PageFactory = menuConfig.PageFactory
            };
        }

        /// <summary>
        /// 根据权限过滤MenuBuilder
        /// </summary>
        /// <param name="showPageAction">显示页面的回调函数</param>
        /// <returns>过滤后的MenuBuilder</returns>
        public static MenuBuilder CreateFilteredMenuBuilder(System.Action<string> showPageAction)
        {
            var menuConfigs = GetMenuConfigs();
            var builder = new MenuBuilder(showPageAction);
            return builder.FromConfig(menuConfigs);
        }
    }
}