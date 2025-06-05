using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DesktopApp.Control.Sidebar._components
{
    public class MenuItemClass
    {
        public string Text { get; set; }
        public string PageKey { get; set; }
        public bool Default { get; set; }
        public Action OnClick { get; set; }
        public List<MenuItemClass> Children { get; set; }
        public bool IsExpanded { get; set; }
        public bool IsSelected { get; set; }
        
        public MenuItemClass()
        {
            Children = new List<MenuItemClass>();
            Default = false;
            IsExpanded = false;
            IsSelected = false;
        }
        
        public bool HasChildren => Children != null && Children.Count > 0;
    }
    
    public partial class MenuControl : UserControl
    {
        private List<MenuItemClass> _menuItems;
        private MenuItemClass _selectedItem;
        private const int ItemHeight = 40;
        private const int IndentWidth = 20;
        
        public event Action<string> PageChanged;
        
        public MenuControl()
        {
            InitializeComponent();
            _menuItems = new List<MenuItemClass>();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
        }
        
        public void SetMenuItems(List<MenuItemClass> menuItems)
        {
            _menuItems = menuItems;
            
            // 设置默认选中项
            var defaultItem = FindDefaultItem(_menuItems);
            if (defaultItem != null)
            {
                SetSelectedItem(defaultItem);
            }
            
            Invalidate();
        }
        
        private MenuItemClass FindDefaultItem(List<MenuItemClass> items)
        {
            foreach (var item in items)
            {
                if (item.Default && !item.HasChildren)
                    return item;
                    
                if (item.HasChildren)
                {
                    var defaultChild = FindDefaultItem(item.Children);
                    if (defaultChild != null)
                        return defaultChild;
                }
            }
            return null;
        }
        
        private void SetSelectedItem(MenuItemClass item)
        {
            if (_selectedItem != null)
                _selectedItem.IsSelected = false;
                
            _selectedItem = item;
            if (item != null)
            {
                item.IsSelected = true;
                PageChanged?.Invoke(item.PageKey);
            }
            
            Invalidate();
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            var g = e.Graphics;
            g.Clear(Color.FromArgb(35, 35, 35));
            
            int yOffset = 0;
            DrawMenuItems(g, _menuItems, 0, ref yOffset);
        }
        
        private void DrawMenuItems(Graphics g, List<MenuItemClass> items, int level, ref int yOffset)
        {
            foreach (var item in items)
            {
                DrawMenuItem(g, item, level, yOffset);
                yOffset += ItemHeight;
                
                if (item.HasChildren && item.IsExpanded)
                {
                    DrawMenuItems(g, item.Children, level + 1, ref yOffset);
                }
            }
        }
        
        private void DrawMenuItem(Graphics g, MenuItemClass item, int level, int yOffset)
        {
            var rect = new Rectangle(level * IndentWidth, yOffset, Width - level * IndentWidth, ItemHeight);
            
            // 绘制背景
            if (item.IsSelected && !item.HasChildren)
            {
                using (var brush = new SolidBrush(Color.FromArgb(70, 130, 180)))
                {
                    g.FillRectangle(brush, rect);
                }
            }
            else if (item.HasChildren && item.IsExpanded)
            {
                using (var brush = new SolidBrush(Color.FromArgb(50, 50, 50)))
                {
                    g.FillRectangle(brush, rect);
                }
            }
            
            // 绘制文本
            var textColor = item.IsSelected && !item.HasChildren ? Color.White : Color.LightGray;
            using (var brush = new SolidBrush(textColor))
            {
                var textRect = new Rectangle(rect.X + 10, rect.Y, rect.Width - 20, rect.Height);
                var format = new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center
                };
                
                g.DrawString(item.Text, Font, brush, textRect, format);
            }
            
            // 绘制展开/收起图标
            if (item.HasChildren)
            {
                var iconRect = new Rectangle(rect.Right - 30, rect.Y + 10, 20, 20);
                var iconColor = Color.LightGray;
                using (var pen = new Pen(iconColor, 2))
                {
                    if (item.IsExpanded)
                    {
                        // 绘制向下箭头
                        g.DrawLine(pen, iconRect.X + 5, iconRect.Y + 7, iconRect.X + 10, iconRect.Y + 13);
                        g.DrawLine(pen, iconRect.X + 10, iconRect.Y + 13, iconRect.X + 15, iconRect.Y + 7);
                    }
                    else
                    {
                        // 绘制向右箭头
                        g.DrawLine(pen, iconRect.X + 7, iconRect.Y + 5, iconRect.X + 13, iconRect.Y + 10);
                        g.DrawLine(pen, iconRect.X + 13, iconRect.Y + 10, iconRect.X + 7, iconRect.Y + 15);
                    }
                }
            }
        }
        
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            
            var clickedItem = GetItemAtPoint(e.Location);
            if (clickedItem != null)
            {
                if (clickedItem.HasChildren)
                {
                    // 切换展开状态
                    clickedItem.IsExpanded = !clickedItem.IsExpanded;
                    Invalidate();
                }
                else
                {
                    // 选中项目并执行点击事件
                    SetSelectedItem(clickedItem);
                    clickedItem.OnClick?.Invoke();
                }
            }
        }
        
        private MenuItemClass GetItemAtPoint(Point point)
        {
            int yOffset = 0;
            return FindItemAtPoint(_menuItems, point, 0, ref yOffset);
        }
        
        private MenuItemClass FindItemAtPoint(List<MenuItemClass> items, Point point, int level, ref int yOffset)
        {
            foreach (var item in items)
            {
                var rect = new Rectangle(level * IndentWidth, yOffset, Width - level * IndentWidth, ItemHeight);
                if (rect.Contains(point))
                {
                    return item;
                }
                
                yOffset += ItemHeight;
                
                if (item.HasChildren && item.IsExpanded)
                {
                    var childItem = FindItemAtPoint(item.Children, point, level + 1, ref yOffset);
                    if (childItem != null)
                        return childItem;
                }
            }
            
            return null;
        }
        
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }
    }
}