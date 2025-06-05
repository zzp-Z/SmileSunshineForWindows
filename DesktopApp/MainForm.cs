using System.Collections.Generic;
using System.Windows.Forms;
using DesktopApp.Control.Sidebar._components;
using DesktopApp.Control.Page.Dashboard;
using DesktopApp.Control.Page.Product;

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
                    Text = "Product",
                    PageKey = "product_page",
                    OnClick = () =>
                    {
                        ShowPage("product_page");
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
                            OnClick = () =>
                            {
                                ShowPage("department_manage_page");
                            }
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
            }
            
            if (pageControl != null)
            {
                pageControl.Dock = DockStyle.Fill;
                mainContentPanel.Controls.Add(pageControl);
            }
        }
    }
}