using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DesktopApp.Control.Sidebar._components;

namespace DesktopApp.Control.Sidebar
{
    public partial class SidebarControl : UserControl
    {
        private MenuControl menuControl;
        
        public event Action<string> PageChanged;
        
        public SidebarControl()
        {
            InitializeComponent();
            InitializeSidebar();
        }
        
        private void InitializeSidebar()
        {
            // 初始化Logo控件
            logoControl.SetLogoImage();
            
            // 初始化菜单控件
            InitializeMenuControl();
            
            // 设置示例菜单项
            SetupSampleMenuItems();
        }
        
        private void InitializeMenuControl()
        {
            menuControl = new MenuControl();
            menuControl.Dock = DockStyle.Fill;
            menuControl.PageChanged += OnPageChanged;
            menuPanel.Controls.Add(menuControl);
        }
        
        private void OnPageChanged(string pageKey)
        {
            PageChanged?.Invoke(pageKey);
        }
        
        private void SetupSampleMenuItems()
        {
            var menuItems = new List<MenuItemClass>
            {
                new MenuItemClass
                {
                    Text = "Dashboard",
                    PageKey = "dashboard",
                    Default = true,
                    OnClick = () => { /* 仪表板页面逻辑 */ }
                },
                new MenuItemClass
                {
                    Text = "User Management",
                    PageKey = "users",
                    Children = new List<MenuItemClass>
                    {
                        new MenuItemClass
                        {
                            Text = "User List",
                            PageKey = "user-list",
                            OnClick = () => { /* 用户列表页面逻辑 */ }
                        },
                        new MenuItemClass
                        {
                            Text = "Add User",
                            PageKey = "add-user",
                            OnClick = () => { /* 添加用户页面逻辑 */ }
                        }
                    }
                },
                new MenuItemClass
                {
                    Text = "System Settings",
                    PageKey = "settings",
                    Children = new List<MenuItemClass>
                    {
                        new MenuItemClass
                        {
                            Text = "Basic Settings",
                            PageKey = "basic-settings",
                            OnClick = () => { /* 基本设置页面逻辑 */ }
                        },
                        new MenuItemClass
                        {
                            Text = "Advanced Settings",
                            PageKey = "advanced-settings",
                            OnClick = () => { /* 高级设置页面逻辑 */ }
                        }
                    }
                },
                new MenuItemClass
                {
                    Text = "Reports",
                    PageKey = "reports",
                    OnClick = () => { /* 报表页面逻辑 */ }
                },
                new MenuItemClass
                {
                    Text = "Help",
                    PageKey = "help",
                    OnClick = () => { /* 帮助页面逻辑 */ }
                }
            };
            
            menuControl.SetMenuItems(menuItems);
        }
        
        // 公共方法用于设置菜单项
        public void SetMenuItems(List<MenuItemClass> menuItems)
        {
            menuControl?.SetMenuItems(menuItems);
        }
        
        // 公共方法用于设置用户信息
        public void SetUserInfo(string username, string position)
        {
            userInfoControl.SetUserInfo(username, position);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}