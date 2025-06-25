using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DesktopApp.Database;
using DesktopApp.Database.Func;

namespace DesktopApp.Control.Page.Order
{
    public partial class OrderManage : UserControl
    {
        private OrderFunc orderFunc;
        private ProductFunc productFunc;
        private List<SalesOrder> orders;
        private List<OrderItemView> currentOrderItemViews;
        
        public OrderManage()
        {
            InitializeComponent();
            orderFunc = new OrderFunc();
            productFunc = new ProductFunc();
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
                dgvOrderItems.DataSource = null;
            }
        }
        
        private void LoadOrderItems(int orderId)
        {
            try
            {
                var orderItems = orderFunc.GetOrderItemsByOrderId(orderId);
                currentOrderItemViews = new List<OrderItemView>();
                
                foreach (var item in orderItems)
                {
                    var product = productFunc.GetProductById(item.ProductId);
                    var orderItemView = new OrderItemView
                    {
                        Id = item.Id,
                        OrderId = item.OrderId,
                        ProductId = item.ProductId,
                        ProductName = product?.Name ?? "未知产品",
                        ProductDescription = product?.Description ?? "",
                        Quantity = item.Quantity ?? 0,
                        UnitPrice = item.UnitPriceCents.HasValue ? item.UnitPriceCents.Value / 100.0m : 0,
                        TotalPrice = item.TotalPriceCents.HasValue ? item.TotalPriceCents.Value / 100.0m : 0
                    };
                    currentOrderItemViews.Add(orderItemView);
                }
                
                BindOrderItemsToGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载订单项目失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void BindOrderItemsToGrid()
        {
            dgvOrderItems.DataSource = currentOrderItemViews;
            
            // 设置列宽和列标题
            if (dgvOrderItems.Columns.Count > 0)
            {
                dgvOrderItems.Columns["Id"].HeaderText = "ID";
                dgvOrderItems.Columns["Id"].Width = 60;
                dgvOrderItems.Columns["OrderId"].HeaderText = "订单ID";
                dgvOrderItems.Columns["OrderId"].Width = 80;
                dgvOrderItems.Columns["ProductId"].HeaderText = "产品ID";
                dgvOrderItems.Columns["ProductId"].Width = 80;
                dgvOrderItems.Columns["ProductName"].HeaderText = "产品名称";
                dgvOrderItems.Columns["ProductName"].Width = 150;
                dgvOrderItems.Columns["ProductDescription"].HeaderText = "产品描述";
                dgvOrderItems.Columns["ProductDescription"].Width = 200;
                dgvOrderItems.Columns["Quantity"].HeaderText = "数量";
                dgvOrderItems.Columns["Quantity"].Width = 80;
                dgvOrderItems.Columns["UnitPrice"].HeaderText = "单价(元)";
                dgvOrderItems.Columns["UnitPrice"].Width = 100;
                dgvOrderItems.Columns["TotalPrice"].HeaderText = "总价(元)";
                dgvOrderItems.Columns["TotalPrice"].Width = 100;
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
    
    // 订单项视图模型，用于在界面上显示产品信息
    public class OrderItemView
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}