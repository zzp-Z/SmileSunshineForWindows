using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DesktopApp.Database;

namespace DesktopApp.Control.Page
{
    public partial class AfterSalesService : UserControl
    {
        private List<CustomerServiceRequest> customerServiceRequests;
        private List<TechnicalSupport> technicalSupports;
        private List<WarrantyClaim> warrantyClaims;
        private List<RefundReturnRequest> refundReturnRequests;
        private List<Database.Customer> customers;
        private List<SalesOrder> salesOrders;
        private List<User> users;

        public AfterSalesService()
        {
            InitializeComponent();
            InitializeData();
            LoadData();
        }

        private void InitializeData()
        {
            // 初始化客户数据
            customers = new List<Database.Customer>
            {
                new Database.Customer { Id = 1, Name = "张三", Address = "北京市朝阳区", Phone = "13800138001" },
                new Database.Customer { Id = 2, Name = "李四", Address = "上海市浦东新区", Phone = "13800138002" },
                new Database.Customer { Id = 3, Name = "王五", Address = "广州市天河区", Phone = "13800138003" },
                new Database.Customer { Id = 4, Name = "赵六", Address = "深圳市南山区", Phone = "13800138004" }
            };

            // 初始化销售订单数据
            salesOrders = new List<SalesOrder>
            {
                new SalesOrder { Id = 1, CustomerId = 1, OrderNumber = "SO001", OrderDate = DateTime.Now.AddDays(-30), Status = "已完成" },
                new SalesOrder { Id = 2, CustomerId = 2, OrderNumber = "SO002", OrderDate = DateTime.Now.AddDays(-25), Status = "已完成" },
                new SalesOrder { Id = 3, CustomerId = 3, OrderNumber = "SO003", OrderDate = DateTime.Now.AddDays(-20), Status = "已完成" },
                new SalesOrder { Id = 4, CustomerId = 4, OrderNumber = "SO004", OrderDate = DateTime.Now.AddDays(-15), Status = "已完成" }
            };

            // 初始化用户数据
            users = new List<User>
            {
                new User { Id = 1, Username = "admin", RealName = "管理员" },
                new User { Id = 2, Username = "support1", RealName = "技术支持1" },
                new User { Id = 3, Username = "support2", RealName = "技术支持2" }
            };

            // 初始化客户服务请求数据
            customerServiceRequests = new List<CustomerServiceRequest>
            {
                new CustomerServiceRequest
                {
                    Id = 1,
                    OrderId = 1,
                    CustomerId = 1,
                    RequestDate = DateTime.Now.AddDays(-5),
                    RequestDescription = "Product function abnormal",
                    Status = "In Progress",
                    Resolution = ""
                },
                new CustomerServiceRequest
                {
                    Id = 2,
                    OrderId = 2,
                    CustomerId = 2,
                    RequestDate = DateTime.Now.AddDays(-3),
                    RequestDescription = "Product quality complaint",
                    Status = "Resolved",
                    Resolution = "Replace with new product"
                },
                new CustomerServiceRequest
                {
                    Id = 3,
                    OrderId = 3,
                    CustomerId = 3,
                    RequestDate = DateTime.Now.AddDays(-1),
                    RequestDescription = "Request for return",
                    Status = "Accepted",
                    Resolution = "Agree to return"
                }
            };

            // 初始化技术支持数据
            technicalSupports = new List<TechnicalSupport>
            {
                new TechnicalSupport
                {
                    Id = 1,
                    CustomerServiceId = 1,
                    EmployeeId = 2,
                    SupportDate = DateTime.Now.AddDays(-4),
                    SupportDescription = "Remote technical support, solve software configuration issues"
                },
                new TechnicalSupport
                {
                    Id = 2,
                    CustomerServiceId = 2,
                    EmployeeId = 3,
                    SupportDate = DateTime.Now.AddDays(-2),
                    SupportDescription = "On-site inspection of product quality issues"
                }
            };

            // 初始化保修索赔数据
            warrantyClaims = new List<WarrantyClaim>
            {
                new WarrantyClaim
                {
                    Id = 1,
                    CustomerServiceId = 2,
                    WarrantyPeriod = 12,
                    ClaimDate = DateTime.Now.AddDays(-2),
                    ClaimDescription = "Product quality issues within warranty period",
                    Status = "Approved",
                    Resolution = "Free replacement with new product"
                }
            };

            // 初始化退换货请求数据
            refundReturnRequests = new List<RefundReturnRequest>
            {
                new RefundReturnRequest
                {
                    Id = 1,
                    CustomerServiceId = 3,
                    RefundDate = DateTime.Now.AddDays(-1),
                    ReturnDate = null,
                    Reason = "Product does not meet expectations",
                    Status = "In Progress",
                    Resolution = "",
                    AmountRefundedCents = null
                }
            };
        }

        private void LoadData()
        {
            LoadCustomerServiceData();
            LoadTechnicalSupportData();
            LoadWarrantyData();
            LoadRefundReturnData();
        }

        private void LoadCustomerServiceData()
        {
            var data = customerServiceRequests.Select(cs => new
            {
                ID = cs.Id,
                OrderNumber = salesOrders.FirstOrDefault(o => o.Id == cs.OrderId)?.OrderNumber ?? "",
                CustomerName = customers.FirstOrDefault(c => c.Id == cs.CustomerId)?.Name ?? "",
                RequestDate = cs.RequestDate?.ToString("yyyy-MM-dd") ?? "",
                RequestDescription = cs.RequestDescription,
                Status = cs.Status,
                Resolution = cs.Resolution
            }).ToList();

            dataGridViewCustomerService.DataSource = data;
        }

        private void LoadTechnicalSupportData()
        {
            var data = technicalSupports.Select(ts => new
            {
                ID = ts.Id,
                ServiceRequestID = ts.CustomerServiceId,
                Technician = users.FirstOrDefault(u => u.Id == ts.EmployeeId)?.RealName ?? "",
                SupportDate = ts.SupportDate?.ToString("yyyy-MM-dd") ?? "",
                SupportDescription = ts.SupportDescription
            }).ToList();

            dataGridViewTechnicalSupport.DataSource = data;
        }

        private void LoadWarrantyData()
        {
            var data = warrantyClaims.Select(wc => new
            {
                ID = wc.Id,
                ServiceRequestID = wc.CustomerServiceId,
                WarrantyPeriod_Months = wc.WarrantyPeriod,
                ClaimDate = wc.ClaimDate?.ToString("yyyy-MM-dd") ?? "",
                ClaimDescription = wc.ClaimDescription,
                Status = wc.Status,
                Resolution = wc.Resolution
            }).ToList();

            dataGridViewWarranty.DataSource = data;
        }

        private void LoadRefundReturnData()
        {
            var data = refundReturnRequests.Select(rr => new
            {
                ID = rr.Id,
                ServiceRequestID = rr.CustomerServiceId,
                RefundDate = rr.RefundDate?.ToString("yyyy-MM-dd") ?? "",
                ReturnDate = rr.ReturnDate?.ToString("yyyy-MM-dd") ?? "",
                Reason = rr.Reason,
                Status = rr.Status,
                Resolution = rr.Resolution,
                RefundAmount_Yuan = rr.AmountRefundedCents.HasValue ? (rr.AmountRefundedCents.Value / 100.0).ToString("F2") : ""
            }).ToList();

            dataGridViewRefundReturn.DataSource = data;
        }
    }
}
