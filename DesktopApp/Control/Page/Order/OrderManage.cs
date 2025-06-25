using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DesktopApp.Database;
using DesktopApp.Database.Func;
using DesktopApp.Control.Page.Order._components;

namespace DesktopApp.Control.Page.Order
{
    public partial class OrderManage : UserControl
    {
        private OrderFunc orderFunc;
        private List<SalesOrder> orders;
        private List<OrderItem> currentOrderItems;
        
        public OrderManage()
        {
            InitializeComponent();
            orderFunc = new OrderFunc();
            LoadOrders();
        }
        
        private void LoadOrders()
        {
            try
            {
                orders = orderFunc.GetAllSalesOrders();
                BindOrdersToGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载订单数据失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void BindOrdersToGrid()
        {
            var orderData = orders.Select(o => new
            {
                订单ID = o.Id,
                订单号 = o.OrderNumber,
                客户ID = o.CustomerId,
                支付方式 = o.PaymentMethod,
                订单日期 = o.OrderDate?.ToString("yyyy-MM-dd"),
                交付日期 = o.DeliveryDate?.ToString("yyyy-MM-dd"),
                状态 = o.Status,
                总金额 = o.TotalAmountCents.HasValue ? (o.TotalAmountCents.Value / 100.0).ToString("C") : "未设置",
                是否定制 = o.IsCustomized ? "是" : "否",
                配送地址 = o.ShippingAddress
            }).ToList();
            
            dgvOrders.DataSource = orderData;
            
            // 调整列宽
            if (dgvOrders.Columns.Count > 0)
            {
                dgvOrders.Columns["订单ID"].Width = 80;
                dgvOrders.Columns["订单号"].Width = 120;
                dgvOrders.Columns["客户ID"].Width = 80;
                dgvOrders.Columns["支付方式"].Width = 100;
                dgvOrders.Columns["订单日期"].Width = 100;
                dgvOrders.Columns["交付日期"].Width = 100;
                dgvOrders.Columns["状态"].Width = 80;
                dgvOrders.Columns["总金额"].Width = 100;
                dgvOrders.Columns["是否定制"].Width = 80;
                dgvOrders.Columns["配送地址"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        
        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                var selectedRow = dgvOrders.SelectedRows[0];
                var orderId = (int)selectedRow.Cells["订单ID"].Value;
                LoadOrderItems(orderId);
            }
            else
            {
                ClearOrderItems();
            }
        }
        
        private void LoadOrderItems(int orderId)
        {
            try
            {
                currentOrderItems = orderFunc.GetOrderItemsByOrderId(orderId);
                DisplayOrderItemCards();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载订单项目失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void DisplayOrderItemCards()
        {
            // 获取FlowLayoutPanel引用
            var flowPanel = this.Controls.Find("flpOrderItems", true).FirstOrDefault() as FlowLayoutPanel;
            if (flowPanel == null) return;
            
            // 清空现有控件
            flowPanel.Controls.Clear();
            
            // 为每个订单项创建卡片
            if (currentOrderItems != null)
            {
                foreach (var orderItem in currentOrderItems)
                {
                    var orderItemCard = new OrderItemInfo(orderItem);
                    flowPanel.Controls.Add(orderItemCard);
                }
            }
        }
        
        private void ClearOrderItems()
        {
            var flowPanel = this.Controls.Find("flpOrderItems", true).FirstOrDefault() as FlowLayoutPanel;
            if (flowPanel != null)
            {
                flowPanel.Controls.Clear();
            }
        }
        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择要编辑的订单", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            var selectedRow = dgvOrders.SelectedRows[0];
            var orderId = (int)selectedRow.Cells["订单ID"].Value;
            var selectedOrder = orders.FirstOrDefault(o => o.Id == orderId);
            
            if (selectedOrder != null)
            {
                // 创建编辑窗口
                var editForm = new Form()
                {
                    Text = $"编辑订单 - {selectedOrder.OrderNumber}",
                    Size = new System.Drawing.Size(800, 600),
                    StartPosition = FormStartPosition.CenterParent
                };
                
                var editControl = new EditOrder();
                editControl.Dock = DockStyle.Fill;
                editForm.Controls.Add(editControl);
                
                // 传递订单数据到编辑控件
                if (editControl is IOrderEditor editor)
                {
                    editor.LoadOrder(selectedOrder);
                }
                
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    // 刷新数据
                    LoadOrders();
                }
                
                editForm.Dispose();
            }
        }
        
        public void RefreshData()
        {
            LoadOrders();
        }
    }
    
    // 接口定义，用于编辑控件
    public interface IOrderEditor
    {
        void LoadOrder(SalesOrder order);
    }
}