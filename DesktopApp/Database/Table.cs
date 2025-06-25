using System;

namespace DesktopApp.Database
{
    /// <summary>
    /// 部门信息表
    /// </summary>
    public class Department
    {
        /// <summary>
        /// 部门ID，主键，自动递增
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 部门描述（可选字段）
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 创建时间，默认为当前时间
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 更新时间，自动更新
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// 重写ToString方法，返回部门名称
        /// </summary>
        /// <returns>部门名称</returns>
        public override string ToString()
        {
            return Name ?? string.Empty;
        }
    }

    /// <summary>
    /// 用户信息表
    /// </summary>
    public class User
    {
        /// <summary>
        /// 用户ID，主键，自动递增
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户名，唯一标识
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 用户密码，加密存储
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }
        
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// 用户邮箱（可选）
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 用户电话（可选）
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 创建时间，默认为当前时间
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 更新时间，自动更新
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }

    /// <summary>
    /// 角色信息表
    /// </summary>
    public class Role
    {
        /// <summary>
        /// 角色ID，主键，自动递增
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 角色名称，如管理员、普通用户等
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 所属部门ID，关联部门表  
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// 角色描述（可选字段）
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 创建时间，默认为当前时间
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 更新时间，自动更新
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }

    /// <summary>
    /// 权限信息表
    /// </summary>
    public class Permission
    {
        /// <summary>
        /// 权限ID，主键，自动递增
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 权限名称，如API访问权限
        /// </summary>
        public string PermissionName { get; set; }

        /// <summary>
        /// 对应的API路径
        /// </summary>
        public string ApiPath { get; set; }

        /// <summary>
        /// 权限描述（可选字段）
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 创建时间，默认为当前时间
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 更新时间，自动更新
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }

    /// <summary>
    /// 用户与角色的关联表
    /// </summary>
    public class UserRole
    {
        /// <summary>
        /// 用户ID，关联用户表
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 角色ID，关联角色表
        /// </summary>
        public int RoleId { get; set; }
    }

    /// <summary>
    /// 角色与权限的关联表
    /// </summary>
    public class RolePermission
    {
        /// <summary>
        /// 角色ID，关联角色表
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 权限ID，关联权限表
        /// </summary>
        public int PermissionId { get; set; }
    }

    public class Supplier
    {
        public int Id { get; set; }
        public int? ReliabilityRating { get; set; } // Nullable int
        public string Name { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }

    public class Material
    {
        public int Id { get; set; }
        public string MaterialNumber { get; set; }
        public string Description { get; set; }
        public string UnitOfMeasure { get; set; }
        public int? QuantityInStock { get; set; }
        public int? ReorderLevel { get; set; }
        public int? ReorderQuantity { get; set; }
        public DateTime? LastReceivedDate { get; set; } // Nullable DateTime
    }

    public class ProcurementOrder
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public int? UnitPriceCents { get; set; }
        public int? NumberOfUnits { get; set; }
        public int? TotalAmountCents { get; set; }
        public int SupplierId { get; set; }
        public int MaterialId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string PaymentTerms { get; set; }
        public string Status { get; set; } // Consider Enum: Pending, Completed, Cancelled
    }

    public class InventoryRecord
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public string Type { get; set; } // Consider Enum: Purchase, Used
        public string RecordNumber { get; set; }
        public int? Quantity { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
    }

    public class DesignConcept
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? Feasibility { get; set; }
        public string Status { get; set; } // Consider Enum: Pending, Approved, Rejected
    }

    public class Prototype
    {
        public int Id { get; set; }
        public int ConceptId { get; set; }
        public string Description { get; set; }
        public string PrototypeUrl { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? Feasibility { get; set; }
        public string Status { get; set; } // Consider Enum: Pending, Approved, Rejected
        public string TestResult { get; set; } // Consider Enum: Pending, Pass, Fail
        public string SafetyResult { get; set; } // Consider Enum: Pending, Pass, Fail
    }

    public class PrototypeComment
    {
        public int Id { get; set; }
        public int PrototypeId { get; set; }
        public string Comment { get; set; }
        public DateTime? CreateDate { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? PriceCents { get; set; }
        public string ImageUrl { get; set; }
        public bool? SafetyCertification { get; set; } // Nullable bool
        public DateTime? CreateDate { get; set; }
        public bool IsPublic { get; set; } = true;
        public int DesignId { get; set; }
        public int QuantityInStock { get; set; }
    }

    public class MaterialOfProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int MaterialId { get; set; }
        public int? Quantity { get; set; }
    }

    public class ProductionPlan
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime? PlanDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? NumberOfProducts { get; set; }
        public string Status { get; set; } // Consider Enum: Pending, InProgress, Completed, Cancelled
    }

    public class ProductionProcess
    {
        public int Id { get; set; }
        public int ProductionPlanId { get; set; }
        public string Name { get; set; }
        public string ProcessDescription { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; } // Consider Enum: Pending, InProgress, Completed, Cancelled
    }

    public class PrerequisiteOfProcess
    {
        public int Id { get; set; }
        public int ProcessId { get; set; }
        public int PrerequisiteProcess { get; set; }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }

    public class SalesOrder
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string OrderNumber { get; set; }
        public string PaymentMethod { get; set; } // Consider Enum: Cash, CreditCard, BankTransfer
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string PaymentTerms { get; set; }
        public string ShippingAddress { get; set; }
        public string Status { get; set; } // Consider Enum: Pending, Completed, Cancelled
        public int? ProductAmountCents { get; set; }
        public int? ShippingCostCents { get; set; }
        public int? TaxAmountCents { get; set; }
        public int? TotalAmountCents { get; set; }
        public int? DownPaymentPercent { get; set; }
        public DateTime? DownPaymentDate { get; set; }
        public bool? IsDownPaymentPaid { get; set; }
        public bool IsCustomized { get; set; } = false;
        public string SpecialRequirements { get; set; }
    }

    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int? Quantity { get; set; }
        public int? UnitPriceCents { get; set; }
        public int? TotalPriceCents { get; set; }
    }

    public class Payment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string PaymentMethod { get; set; } // Consider Enum: Cash, CreditCard, BankTransfer
        public DateTime? PaymentDate { get; set; }
        public int? AmountPaidCents { get; set; }
        public int? BalanceDueCents { get; set; }
    }

    public class ShippingMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class ShippingRecord
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public DateTime? ShippingDate { get; set; }
        public int ShippingMethodId { get; set; }
        public string TrackingNumber { get; set; }
        public string Carrier { get; set; }
        public string ShippingAddress { get; set; }
        public string Status { get; set; } // Consider Enum: Pending, InTransit, Delivered
    }

    public class CustomerServiceRequest
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime? RequestDate { get; set; }
        public string RequestDescription { get; set; }
        public string Status { get; set; } // Consider Enum: Pending, InProgress, Resolved, Closed
        public string Resolution { get; set; }
    }

    public class TechnicalSupport
    {
        public int Id { get; set; }
        public int CustomerServiceId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? SupportDate { get; set; }
        public string SupportDescription { get; set; }
    }

    public class WarrantyClaim
    {
        public int Id { get; set; }
        public int CustomerServiceId { get; set; }
        public int? WarrantyPeriod { get; set; }
        public DateTime? ClaimDate { get; set; }
        public string ClaimDescription { get; set; }
        public string Status { get; set; } // Consider Enum: Pending, InProgress, Resolved, Closed
        public string Resolution { get; set; }
    }

    public class RefundReturnRequest
    {
        public int Id { get; set; }
        public int CustomerServiceId { get; set; }
        public DateTime? RefundDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; } // Consider Enum: Pending, InProgress, Resolved, Closed
        public string Resolution { get; set; }
        public int? AmountRefundedCents { get; set; }
    }
}