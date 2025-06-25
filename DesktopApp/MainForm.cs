using System.Collections.Generic;
using System.Windows.Forms;
using DesktopApp.Control.Page.Customer;
using DesktopApp.Control.Sidebar._components;
using DesktopApp.Control.Page.Dashboard;
using DesktopApp.Control.Page.Order;
using DesktopApp.Control.Page.Product;
using DesktopApp.Control.Page.SystemManage.DepartmentManage;
using DesktopApp.Control.Page.SystemManage.RoleManage;
using DesktopApp.Control.Page.SystemManage.UserManage;

namespace DesktopApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            var menuItems = new List<MenuItemClass>()
            {
                new MenuItemClass()
                {
                    Text = "Dashboard",
                    PageKey = "dashboard_page",
                    Default = true,
                    OnClick = () =>
                    {
                        ShowPage("dashboard_page");
                    }
                },
                new MenuItemClass()
                {
                    Text = "Order Management",
                    PageKey = "order_management_page",
                    OnClick = () =>
                    {
                        ShowPage("order_management_page");
                    },
                },
                new MenuItemClass()
                {
                    Text = "Product",
                    PageKey = "product_page",
                    Children = new List<MenuItemClass>()
                    {
                        new MenuItemClass()
                        {
                            Text = "Product Manage",
                            PageKey = "product_manage_page",
                            OnClick = () => ShowPage("product_manage_page")
                        },
                        new MenuItemClass()
                        {
                            Text = "Product",
                            PageKey = "product_page",
                            OnClick = () => ShowPage("product_page")
                        }
                    }
                },
                new MenuItemClass()
                {
                    Text = "Dispatch Processing",
                    PageKey = "dispatch_processing_page",
                    OnClick = () =>
                    {
                        ShowPage("dispatch_processing_page");
                    },
                    Children = new List<MenuItemClass>()
                    {
                        new MenuItemClass()
                        {
                            Text = "Generate Delivery Notes (PDF)",
                            PageKey = "generate_delivery_notes_page",
                            OnClick = () => ShowPage("generate_delivery_notes_page")
                        },
                        new MenuItemClass()
                        {
                            Text = "Handling Goods received",
                            PageKey = "handling_goods_received_page",
                            OnClick = () => ShowPage("handling_goods_received_page")
                        }
                    }
                },
                new MenuItemClass()
                {
                    Text = "Customer Manage",  
                    PageKey = "customer_manage_page",
                    OnClick = () => ShowPage("customer_manage_page")
                },
                new MenuItemClass()
                {
                    Text = "Inventory Control",
                    PageKey = "inventory_control_page",
                    OnClick = () =>
                    {
                        ShowPage("inventory_control_page");
                    },
                    Children = new List<MenuItemClass>()
                    {
                        new MenuItemClass()
                        {
                            Text = "Record of inward goods",
                            PageKey = "record_inward_goods_page",
                            OnClick = () => ShowPage("record_inward_goods_page")
                        },
                        new MenuItemClass()
                        {
                            Text = "Product Catalog",
                            PageKey = "product_catalog_page",
                            OnClick = () => ShowPage("product_catalog_page")
                        },
                        new MenuItemClass()
                        {
                            Text = "Product Addition",
                            PageKey = "product_addition_page",
                            OnClick = () => ShowPage("product_addition_page")
                        }
                    }
                },
                new MenuItemClass()
                {
                    Text = "After-service Management",
                    PageKey = "after_service_management_page",
                    OnClick = () =>
                    {
                        ShowPage("after_service_management_page");
                    },
                    Children = new List<MenuItemClass>()
                    {
                        new MenuItemClass()
                        {
                            Text = "Refund Processing",
                            PageKey = "refund_processing_page",
                            OnClick = () => ShowPage("refund_processing_page")
                        },
                        new MenuItemClass()
                        {
                            Text = "Return Processing",
                            PageKey = "return_processing_page",
                            OnClick = () => ShowPage("return_processing_page")
                        },
                        new MenuItemClass()
                        {
                            Text = "Repair Processing",
                            PageKey = "repair_processing_page",
                            OnClick = () => ShowPage("repair_processing_page")
                        }
                    }
                },
                new MenuItemClass()
                {
                    Text = "System Manage",
                    PageKey = "system_manage_page",
                    OnClick = () =>
                    {
                        ShowPage("product_page");
                    },
                    Children = new List<MenuItemClass>()
                    {
                        new MenuItemClass()
                        {
                            Text = "Department Manage",
                            PageKey = "department_manage_page",
                            OnClick = ()=> ShowPage("department_manage_page")
                        },
                        new MenuItemClass()
                        {
                            Text = "Role Manage",
                            PageKey = "role_manage_page",
                            OnClick = () =>
                            {
                                ShowPage("role_manage_page");
                            }
                        },
                        new MenuItemClass()
                        {
                            Text = "User Manage",
                            PageKey = "user_manage_page",
                            OnClick = () =>
                            {
                                ShowPage("user_manage_page");
                            }
                        }
                    }
                },
            };
            
            sidebarControl.SetMenuItems(menuItems);
            
            // 默认显示Dashboard页面
            ShowPage("dashboard_page");
        }
        
        private void ShowPage(string pageKey)
        {
            // 清除当前内容
            mainContentPanel.Controls.Clear();
            
            UserControl pageControl = null;
            
            switch (pageKey)
            {
                case "dashboard_page":
                    pageControl = new DashboardPageControl();
                    break;
                case "product_page":
                    pageControl = new ProductPageControl();
                    break;
                case "customer_manage_page":
                    pageControl = new CustomerManagerPageControl(); // 临时使用Dashboard页面
                    break;
                case "product_manage_page":
                    pageControl = new ProductManagePageControl();
                    break;
                case "order_management_page":
                    // 可以创建一个默认的订单管理页面，或者显示提示信息
                    pageControl = new OrderManage(); // 临时使用Dashboard页面
                    break;
                case "create_edit_order_page":
                    pageControl = new DashboardPageControl(); // 临时使用Dashboard页面
                    break;
                case "review_order_page":
                    pageControl = new DashboardPageControl(); // 临时使用Dashboard页面
                    break;
                case "dispatch_processing_page":
                    pageControl = new DashboardPageControl(); // 临时使用Dashboard页面
                    break;
                case "generate_delivery_notes_page":
                    pageControl = new DashboardPageControl();
                    break;
                case "handling_goods_received_page":
                    pageControl = new DashboardPageControl(); // 临时使用Dashboard页面
                    break;
                case "inventory_control_page":
                    pageControl = new DashboardPageControl(); // 临时使用Dashboard页面
                    break;
                case "record_inward_goods_page":
                    pageControl = new DashboardPageControl(); // 临时使用Dashboard页面
                    break;
                case "product_catalog_page":
                    pageControl = new DashboardPageControl(); // 临时使用Dashboard页面
                    break;
                case "product_addition_page":
                    pageControl = new DashboardPageControl(); // 临时使用Dashboard页面
                    break;
                case "after_service_management_page":
                    pageControl = new DashboardPageControl(); // 临时使用Dashboard页面
                    break;
                case "refund_processing_page":
                    pageControl = new DashboardPageControl(); // 临时使用Dashboard页面
                    break;
                case "return_processing_page":
                    pageControl = new DashboardPageControl(); // 临时使用Dashboard页面
                    break;
                case "repair_processing_page":
                    pageControl = new DashboardPageControl(); // 临时使用Dashboard页面
                    break;
                case "department_manage_page":
                    pageControl = new DepartmentManagePageControl();
                    break;
                case "role_manage_page":
                    pageControl = new RoleManagePageControl();
                    break;
                case "user_manage_page":
                    pageControl = new UserManagePageControl();
                    break;
            }
            
            if (pageControl != null)
            {
                pageControl.Dock = DockStyle.Fill;
                mainContentPanel.Controls.Add(pageControl);
            }
        }
    }
}