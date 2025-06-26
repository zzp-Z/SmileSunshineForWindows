using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DesktopApp.Control.Sidebar._components
{
    /// <summary>
    /// 菜单构建器，用于简化菜单配置
    /// </summary>
    public class MenuBuilder
    {
        private readonly List<MenuItemClass> _menuItems;
        private readonly Action<string> _showPageAction;

        public MenuBuilder(Action<string> showPageAction)
        {
            _menuItems = new List<MenuItemClass>();
            _showPageAction = showPageAction;
        }

        /// <summary>
        /// 添加简单菜单项
        /// </summary>
        /// <param name="text">显示文本</param>
        /// <param name="pageKey">页面键</param>
        /// <param name="isDefault">是否为默认选中</param>
        /// <returns></returns>
        public MenuBuilder AddItem(string text, string pageKey, bool isDefault = false)
        {
            _menuItems.Add(new MenuItemClass
            {
                Text = text,
                PageKey = pageKey,
                Default = isDefault,
                OnClick = () => _showPageAction(pageKey)
            });
            return this;
        }

        /// <summary>
        /// 添加带子菜单的菜单项
        /// </summary>
        /// <param name="text">显示文本</param>
        /// <param name="pageKey">页面键（可选）</param>
        /// <param name="childrenBuilder">子菜单构建器</param>
        /// <returns></returns>
        public MenuBuilder AddGroup(string text, string pageKey = null, Action<MenuGroupBuilder> childrenBuilder = null)
        {
            var menuItem = new MenuItemClass
            {
                Text = text,
                PageKey = pageKey
            };

            if (!string.IsNullOrEmpty(pageKey))
            {
                menuItem.OnClick = () => _showPageAction(pageKey);
            }

            if (childrenBuilder != null)
            {
                var groupBuilder = new MenuGroupBuilder(_showPageAction);
                childrenBuilder(groupBuilder);
                menuItem.Children = groupBuilder.Build();
            }

            _menuItems.Add(menuItem);
            return this;
        }

        /// <summary>
        /// 构建菜单项列表
        /// </summary>
        /// <returns></returns>
        public List<MenuItemClass> Build()
        {
            return _menuItems;
        }
    }

    /// <summary>
    /// 菜单组构建器，用于构建子菜单
    /// </summary>
    public class MenuGroupBuilder
    {
        private readonly List<MenuItemClass> _children;
        private readonly Action<string> _showPageAction;

        public MenuGroupBuilder(Action<string> showPageAction)
        {
            _children = new List<MenuItemClass>();
            _showPageAction = showPageAction;
        }

        /// <summary>
        /// 添加子菜单项
        /// </summary>
        /// <param name="text">显示文本</param>
        /// <param name="pageKey">页面键</param>
        /// <param name="isDefault">是否为默认选中</param>
        /// <returns></returns>
        public MenuGroupBuilder AddChild(string text, string pageKey, bool isDefault = false)
        {
            _children.Add(new MenuItemClass
            {
                Text = text,
                PageKey = pageKey,
                Default = isDefault,
                OnClick = () => _showPageAction(pageKey)
            });
            return this;
        }

        /// <summary>
        /// 构建子菜单列表
        /// </summary>
        /// <returns></returns>
        public List<MenuItemClass> Build()
        {
            return _children;
        }
    }

    /// <summary>
    /// 菜单配置扩展方法
    /// </summary>
    public static class MenuExtensions
    {
        /// <summary>
        /// 从配置数组创建菜单
        /// </summary>
        /// <param name="builder">菜单构建器</param>
        /// <param name="menuConfigs">菜单配置数组</param>
        /// <returns></returns>
        public static MenuBuilder FromConfig(this MenuBuilder builder, MenuConfig[] menuConfigs)
        {
            foreach (var config in menuConfigs)
            {
                if (config.Children != null && config.Children.Length > 0)
                {
                    builder.AddGroup(config.Text, config.PageKey, group =>
                    {
                        foreach (var child in config.Children)
                        {
                            group.AddChild(child.Text, child.PageKey, child.IsDefault);
                        }
                    });
                }
                else
                {
                    builder.AddItem(config.Text, config.PageKey, config.IsDefault);
                }
            }
            return builder;
        }
    }

    /// <summary>
    /// 菜单配置数据结构
    /// </summary>
    public class MenuConfig
    {
        public string Text { get; set; }
        public string PageKey { get; set; }
        public bool IsDefault { get; set; }
        public MenuConfig[] Children { get; set; }
        public Func<UserControl> PageFactory { get; set; }
    }

    /// <summary>
    /// 页面工厂管理器
    /// </summary>
    public static class PageFactory
    {
        private static readonly Dictionary<string, Func<UserControl>> _pageFactories = new Dictionary<string, Func<UserControl>>();

        /// <summary>
        /// 注册页面工厂方法
        /// </summary>
        /// <param name="pageKey">页面键</param>
        /// <param name="factory">工厂方法</param>
        public static void Register(string pageKey, Func<UserControl> factory)
        {
            _pageFactories[pageKey] = factory;
        }

        /// <summary>
        /// 批量注册页面工厂方法
        /// </summary>
        /// <param name="factories">页面工厂字典</param>
        public static void RegisterBatch(Dictionary<string, Func<UserControl>> factories)
        {
            foreach (var factory in factories)
            {
                _pageFactories[factory.Key] = factory.Value;
            }
        }

        /// <summary>
        /// 创建页面控件
        /// </summary>
        /// <param name="pageKey">页面键</param>
        /// <returns>页面控件实例</returns>
        public static UserControl CreatePage(string pageKey)
        {
            if (_pageFactories.TryGetValue(pageKey, out var factory))
            {
                return factory();
            }
            return null;
        }

        /// <summary>
        /// 检查页面是否已注册
        /// </summary>
        /// <param name="pageKey">页面键</param>
        /// <returns>是否已注册</returns>
        public static bool IsRegistered(string pageKey)
        {
            return _pageFactories.ContainsKey(pageKey);
        }

        /// <summary>
        /// 获取所有已注册的页面键
        /// </summary>
        /// <returns>页面键列表</returns>
        public static IEnumerable<string> GetRegisteredPageKeys()
        {
            return _pageFactories.Keys;
        }
    }
}