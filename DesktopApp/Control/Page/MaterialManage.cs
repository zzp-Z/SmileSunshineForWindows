using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DesktopApp.Database;

namespace SmileSunshine.DesktopApp.Control.Page
{
    public partial class MaterialManage : UserControl
    {
        private List<Material> materials;
        private List<Supplier> suppliers;
        private List<ProcurementOrder> procurementOrders;
        private List<InventoryRecord> inventoryRecords;

        public MaterialManage()
        {
            InitializeComponent();
            InitializeData();
            LoadData();
        }

        private void InitializeData()
        {
            // 初始化材料数据
            materials = new List<Material>
            {
                new Material
                {
                    Id = 1,
                    MaterialNumber = "M001",
                    Description = "钢材 Q235B",
                    UnitOfMeasure = "吨",
                    QuantityInStock = 100,
                    ReorderLevel = 20,
                    ReorderQuantity = 50,
                    LastReceivedDate = DateTime.Now.AddDays(-5)
                },
                new Material
                {
                    Id = 2,
                    MaterialNumber = "M002",
                    Description = "水泥 P.O 42.5",
                    UnitOfMeasure = "吨",
                    QuantityInStock = 200,
                    ReorderLevel = 30,
                    ReorderQuantity = 100,
                    LastReceivedDate = DateTime.Now.AddDays(-3)
                },
                new Material
                {
                    Id = 3,
                    MaterialNumber = "M003",
                    Description = "铝合金 6061-T6",
                    UnitOfMeasure = "公斤",
                    QuantityInStock = 500,
                    ReorderLevel = 100,
                    ReorderQuantity = 300,
                    LastReceivedDate = DateTime.Now.AddDays(-2)
                }
            };

            // 初始化供应商数据
            suppliers = new List<Supplier>
            {
                new Supplier
                {
                    Id = 1,
                    ReliabilityRating = 5,
                    Name = "钢铁集团有限公司",
                    ContactName = "张经理",
                    Phone = "021-12345678",
                    Address = "上海市浦东新区钢铁路123号",
                    Email = "zhang@steel.com"
                },
                new Supplier
                {
                    Id = 2,
                    ReliabilityRating = 4,
                    Name = "建材供应商",
                    ContactName = "李总",
                    Phone = "010-87654321",
                    Address = "北京市朝阳区建材街456号",
                    Email = "li@building.com"
                },
                new Supplier
                {
                    Id = 3,
                    ReliabilityRating = null,
                    Name = "有色金属公司",
                    ContactName = "王主任",
                    Phone = "0755-11223344",
                    Address = "深圳市南山区金属大道789号",
                    Email = "wang@metal.com"
                }
            };

            // 初始化采购订单数据
            procurementOrders = new List<ProcurementOrder>
            {
                new ProcurementOrder
                {
                    Id = 1,
                    OrderNumber = "PO2024001",
                    UnitPriceCents = 50000, // 500.00元转换为分
                    NumberOfUnits = 100,
                    TotalAmountCents = 5000000, // 50000元转换为分
                    SupplierId = 1,
                    MaterialId = 1,
                    OrderDate = DateTime.Now.AddDays(-15),
                    DeliveryDate = DateTime.Now.AddDays(-5),
                    PaymentTerms = "30 days payment",
                    Status = "Completed"
                },
                new ProcurementOrder
                {
                    Id = 2,
                    OrderNumber = "PO2024002",
                    UnitPriceCents = 30000, // 300.00元转换为分
                    NumberOfUnits = 200,
                    TotalAmountCents = 6000000, // 60000元转换为分
                    SupplierId = 2,
                    MaterialId = 2,
                    OrderDate = DateTime.Now.AddDays(-10),
                    DeliveryDate = null,
                    PaymentTerms = "Cash on delivery",
                    Status = "Pending"
                },
                new ProcurementOrder
                {
                    Id = 3,
                    OrderNumber = "PO2024003",
                    UnitPriceCents = 20000, // 200.00元转换为分
                    NumberOfUnits = 500,
                    TotalAmountCents = 10000000, // 100000元转换为分
                    SupplierId = 3,
                    MaterialId = 3,
                    OrderDate = DateTime.Now.AddDays(-8),
                    DeliveryDate = DateTime.Now.AddDays(-2),
                    PaymentTerms = "50% prepayment",
                    Status = "Completed"
                }
            };

            // 初始化库存记录数据
            inventoryRecords = new List<InventoryRecord>
            {
                new InventoryRecord
                {
                    Id = 1,
                    MaterialId = 1,
                    Type = "Purchase",
                    RecordNumber = "PO2024001",
                    Quantity = 50,
                    Date = DateTime.Now.AddDays(-10),
                    Description = "Purchase receipt"
                },
                new InventoryRecord
                {
                    Id = 2,
                    MaterialId = 2,
                    Type = "采购入库",
                    RecordNumber = "PO2024002",
                    Quantity = 100,
                    Date = DateTime.Now.AddDays(-8),
                    Description = "采购入库"
                },
                new InventoryRecord
                {
                    Id = 3,
                    MaterialId = 1,
                    Type = "Production",
                    RecordNumber = "SO2024001",
                    Quantity = 10,
                    Date = DateTime.Now.AddDays(-5),
                    Description = "Production usage"
                }
            };
        }

        private void LoadData()
        {
            LoadMaterialsData();
            LoadSuppliersData();
            LoadProcurementData();
            LoadInventoryData();
        }

        private void LoadMaterialsData()
        {
            var materialData = materials.Select(m => new
            {
                MaterialID = m.Id,
                MaterialNumber = m.MaterialNumber ?? "Not set",
                Description = m.Description ?? "No description",
                UnitOfMeasure = m.UnitOfMeasure ?? "Not set",
                QuantityInStock = m.QuantityInStock?.ToString() ?? "Not set",
                ReorderLevel = m.ReorderLevel?.ToString() ?? "Not set",
                ReorderQuantity = m.ReorderQuantity?.ToString() ?? "Not set",
                LastReceivedDate = m.LastReceivedDate?.ToString("yyyy-MM-dd") ?? "Not received"
            }).ToList();

            dataGridViewMaterials.DataSource = materialData;
        }

        private void LoadSuppliersData()
        {
            var supplierData = suppliers.Select(s => new
            {
                SupplierID = s.Id,
                SupplierName = s.Name,
                ContactName = s.ContactName,
                Phone = s.Phone,
                Email = s.Email,
                Address = s.Address,
                ReliabilityRating = s.ReliabilityRating?.ToString() ?? "Not rated"
            }).ToList();

            dataGridViewSuppliers.DataSource = supplierData;
        }

        private void LoadProcurementData()
        {
            var procurementData = procurementOrders.Select(p => new
            {
                ProcurementOrderID = p.Id,
                OrderNumber = p.OrderNumber,
                SupplierID = p.SupplierId,
                MaterialID = p.MaterialId,
                Quantity = p.NumberOfUnits?.ToString() ?? "Not set",
                UnitPrice = p.UnitPriceCents.HasValue ? (p.UnitPriceCents.Value / 100.0m).ToString("C") : "Not set",
                TotalAmount = p.TotalAmountCents.HasValue ? (p.TotalAmountCents.Value / 100.0m).ToString("C") : "Not set",
                OrderDate = p.OrderDate?.ToString("yyyy-MM-dd") ?? "Not set",
                DeliveryDate = p.DeliveryDate?.ToString("yyyy-MM-dd") ?? "Not delivered",
                PaymentTerms = p.PaymentTerms ?? "Not set",
                Status = p.Status ?? "Unknown"
            }).ToList();

            dataGridViewProcurement.DataSource = procurementData;
        }

        private void LoadInventoryData()
        {
            var inventoryData = inventoryRecords.Select(i => new
            {
                InventoryRecordID = i.Id,
                MaterialID = i.MaterialId,
                Type = i.Type ?? "Not set",
                RecordNumber = i.RecordNumber ?? "Not set",
                Quantity = i.Quantity?.ToString() ?? "Not set",
                Date = i.Date?.ToString("yyyy-MM-dd") ?? "Not set",
                Description = i.Description ?? "No description"
            }).ToList();

            dataGridViewInventory.DataSource = inventoryData;
        }
    }
}