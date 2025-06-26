using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DesktopApp.Database;
using DesktopApp.Database.Func;
using DesktopApp.Control.Page.Order._components;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = iTextSharp.text.Font;

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
                MessageBox.Show($"Load orders failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void BindOrdersToGrid()
        {
            var orderData = orders.Select(o => new
            {
                OrderID = o.Id,
                OrderNumber = o.OrderNumber,
                CustomerId = o.CustomerId,
                PaymentMethod = o.PaymentMethod,
                OrderDate = o.OrderDate?.ToString("yyyy-MM-dd"),
                DeliveryDate = o.DeliveryDate?.ToString("yyyy-MM-dd"),
                Status = o.Status,
                TotalAmountCents = o.TotalAmountCents.HasValue ? (o.TotalAmountCents.Value / 100.0).ToString("C") : "N/A",
                IsCustomized = o.IsCustomized ? "Y" : "N",
                ShippingAddress = o.ShippingAddress
            }).ToList();
            
            dgvOrders.DataSource = orderData;
            
            // 调整列宽
            if (dgvOrders.Columns.Count > 0)
            {
                dgvOrders.Columns["OrderID"].Width = 80;
                dgvOrders.Columns["OrderNumber"].Width = 120;
                dgvOrders.Columns["CustomerId"].Width = 80;
                dgvOrders.Columns["PaymentMethod"].Width = 100;
                dgvOrders.Columns["OrderDate"].Width = 100;
                dgvOrders.Columns["DeliveryDate"].Width = 100;
                dgvOrders.Columns["Status"].Width = 80;
                dgvOrders.Columns["TotalAmountCents"].Width = 100;
                dgvOrders.Columns["IsCustomized"].Width = 80;
                dgvOrders.Columns["ShippingAddress"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        
        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                var selectedRow = dgvOrders.SelectedRows[0];
                var orderId = (int)selectedRow.Cells["OrderID"].Value;
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
                MessageBox.Show($"Load order items failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Please select an order to edit!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            var selectedRow = dgvOrders.SelectedRows[0];
            var orderId = (int)selectedRow.Cells["OrderID"].Value;
            var selectedOrder = orders.FirstOrDefault(o => o.Id == orderId);
            
            if (selectedOrder != null)
            {
                // 创建编辑窗口
                var editForm = new Form()
                {
                    Text = $"Edit Order - {selectedOrder.OrderNumber}",
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
        
        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to export", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedOrder = orders[dgvOrders.SelectedRows[0].Index];
            
            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "PDF Files|*.pdf";
                saveDialog.Title = "Save Order PDF";
                saveDialog.FileName = $"Order_{selectedOrder.OrderNumber}_{DateTime.Now:yyyyMMdd}.pdf";
                
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExportOrderToPdf(selectedOrder, saveDialog.FileName);
                        MessageBox.Show("PDF exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // 询问是否打开文件
                        if (MessageBox.Show("Would you like to open the exported PDF file?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(saveDialog.FileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"PDF export failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        
        private void ExportOrderToPdf(SalesOrder order, string filePath)
        {
            var document = new Document(PageSize.A4, 50, 50, 50, 50);
            var writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
            
            document.Open();
            
            // 设置英文字体
            var baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            var titleFont = new Font(baseFont, 18, iTextSharp.text.Font.BOLD);
            var headerFont = new Font(baseFont, 14, iTextSharp.text.Font.BOLD);
            var normalFont = new Font(baseFont, 12, iTextSharp.text.Font.NORMAL);
            var smallFont = new Font(baseFont, 10, iTextSharp.text.Font.NORMAL);
            
            // 标题
            var title = new Paragraph("Order Details Report", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 20;
            document.Add(title);
            
            // 订单基本信息
            var orderInfoTable = new PdfPTable(2);
            orderInfoTable.WidthPercentage = 100;
            orderInfoTable.SetWidths(new float[] { 1, 2 });
            
            AddTableCell(orderInfoTable, "Order Number:", order.OrderNumber, headerFont, normalFont);
            AddTableCell(orderInfoTable, "Customer ID:", order.CustomerId.ToString(), headerFont, normalFont);
            AddTableCell(orderInfoTable, "Payment Method:", order.PaymentMethod ?? "Not Set", headerFont, normalFont);
            AddTableCell(orderInfoTable, "Order Date:", order.OrderDate?.ToString("yyyy-MM-dd HH:mm:ss") ?? "Not Set", headerFont, normalFont);
            AddTableCell(orderInfoTable, "Delivery Date:", order.DeliveryDate?.ToString("yyyy-MM-dd") ?? "Not Set", headerFont, normalFont);
            AddTableCell(orderInfoTable, "Status:", order.Status ?? "Not Set", headerFont, normalFont);
            AddTableCell(orderInfoTable, "Total Amount:", order.TotalAmountCents.HasValue ? (order.TotalAmountCents.Value / 100.0).ToString("C") : "Not Set", headerFont, normalFont);
            AddTableCell(orderInfoTable, "Is Customized:", order.IsCustomized ? "Yes" : "No", headerFont, normalFont);
            
            document.Add(orderInfoTable);
            document.Add(new Paragraph(" ", normalFont)); // 空行
            
            // 订单项标题
            var itemsTitle = new Paragraph("Order Items Details", headerFont);
            itemsTitle.SpacingBefore = 20;
            itemsTitle.SpacingAfter = 10;
            document.Add(itemsTitle);
            
            // 获取订单项和产品信息
            var orderItems = orderFunc.GetOrderItemsByOrderId(order.Id);
            var productFunc = new ProductFunc();
            
            if (orderItems.Any())
            {
                // 创建商品明细表格
                var itemsTable = new PdfPTable(6);
                itemsTable.WidthPercentage = 100;
                itemsTable.SetWidths(new float[] { 1, 3, 2, 1, 2, 2 });
                
                // 表头
                AddTableHeaderCell(itemsTable, "No.", headerFont);
                AddTableHeaderCell(itemsTable, "Product Name", headerFont);
                AddTableHeaderCell(itemsTable, "Description", headerFont);
                AddTableHeaderCell(itemsTable, "Quantity", headerFont);
                AddTableHeaderCell(itemsTable, "Unit Price", headerFont);
                AddTableHeaderCell(itemsTable, "Subtotal", headerFont);
                
                // 商品明细
                int index = 1;
                decimal totalAmount = 0;
                
                foreach (var item in orderItems)
                {
                    var product = productFunc.GetProductById(item.ProductId);
                    var productName = product?.Name ?? "Unknown Product";
                    var productDescription = product?.Description ?? "No Description";
                    var unitPrice = item.UnitPriceCents / 100.0m;
                    var subtotal = (decimal)(item.Quantity * unitPrice);
                    totalAmount += subtotal;
                    
                    AddTableCell(itemsTable, index.ToString(), normalFont);
                    AddTableCell(itemsTable, productName, normalFont);
                    AddTableCell(itemsTable, productDescription, smallFont);
                    AddTableCell(itemsTable, item.Quantity.ToString(), normalFont);
                    AddTableCell(itemsTable, unitPrice.ToString(), normalFont);
                    AddTableCell(itemsTable, subtotal.ToString(), normalFont);
                    
                    index++;
                }
                
                // 合计行
                AddTableCell(itemsTable, "", normalFont);
                AddTableCell(itemsTable, "", normalFont);
                AddTableCell(itemsTable, "", normalFont);
                AddTableCell(itemsTable, "", normalFont);
                AddTableCell(itemsTable, "Total:", headerFont);
                AddTableCell(itemsTable, totalAmount.ToString("C"), headerFont);
                
                document.Add(itemsTable);
            }
            else
            {
                document.Add(new Paragraph("No items found for this order", normalFont));
            }
            
            // 页脚信息
            var footer = new Paragraph($"\n\nExported on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}", smallFont);
            footer.Alignment = Element.ALIGN_RIGHT;
            document.Add(footer);
            
            document.Close();
            writer.Close();
        }
        
        private void AddTableCell(PdfPTable table, string label, string value, Font labelFont, Font valueFont)
        {
            var labelCell = new PdfPCell(new Phrase(label, labelFont));
            labelCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            labelCell.Padding = 5;
            table.AddCell(labelCell);
            
            var valueCell = new PdfPCell(new Phrase(value, valueFont));
            valueCell.Padding = 5;
            table.AddCell(valueCell);
        }
        
        private void AddTableCell(PdfPTable table, string text, Font font)
        {
            var cell = new PdfPCell(new Phrase(text, font));
            cell.Padding = 5;
            table.AddCell(cell);
        }
        
        private void AddTableHeaderCell(PdfPTable table, string text, Font font)
        {
            var cell = new PdfPCell(new Phrase(text, font));
            cell.BackgroundColor = BaseColor.DARK_GRAY;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Padding = 8;
            table.AddCell(cell);
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