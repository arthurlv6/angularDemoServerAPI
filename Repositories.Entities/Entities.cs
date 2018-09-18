using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repositories.Entities
{
    #region entities
    public class Company : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TradingName { get; set; }
        public String Industry { get; set; }
        public String OrganisationType { get; set; }
        public string GST { get; set; }
        public string Website { get; set; }
        public String Timezone { get; set; }
        public string Logo { get; set; }
        public string Address { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OfficePhone { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public DateTime? ValidDate { get; set; }
        public bool Initialized { get; set; }
    }
    public partial class Customer : BaseEntity
    {
        public Customer()
        {
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string SurName { get; set; }
        public string OtherName { get; set; }
        public string ResidentalDetail { get; set; }
        public string HouseNum { get; set; }
        public string StreetName { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string LivePeriod { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public string Dob { get; set; }
        public string NumOfDependant { get; set; }
        public string SalesReferenceNo { get; set; }
        public string CompanyReferenceNo { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Remark { get; set; }
        public string CustomerReference { get; set; }
        public decimal? TrustBalanceCl { get; set; }
        public decimal? Credit { get; set; }
        public int? BlacklistId { get; set; }
        public bool? IsInBlacklist { get; set; }
        public int? UserId { get; set; }
        public decimal? TrustBalanceCp { get; set; }
        public string Comment { get; set; }
        public int? SettingId { get; set; }
        public bool? Deleted { get; set; }
    }
    public class NumberRange : BaseEntity
    {
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "Description - Please enter no more than 50 characters.")]
        public string Description
        {
            get; set;
        }

        [Required]
        public int EndNumber
        {
            get; set;
        }

        [Required]
        public int LastNumber
        {
            get; set;
        }

        [Required]
        [StringLength(100, ErrorMessage = "Number Range Code - Please enter no more than 100 characters.")]
        public string NumberRangeCode
        {
            get; set;
        }

        [Required]
        [StringLength(7, ErrorMessage = "Prefix - Please enter no more than 7 characters.")]
        public string Prefix
        {
            get; set;
        }

        [Required]
        public int StartNumber
        {
            get; set;
        }
        public DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
    public partial class Order : BaseEntity
    {
        public Order()
        {
            ContractProduct = new HashSet<OrderProduct>();
        }

        public long Id { get; set; }
        public string Sid { get; set; }
        public string RefType { get; set; }
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public DateTime? ContractSignDate { get; set; }
        public int? SalesId { get; set; }
        public decimal BookingFee { get; set; }
        public decimal OthersFee { get; set; }
        public int? DeliveryAfterPayment { get; set; }
        public string BankInfo { get; set; }
        public string Status { get; set; }
        public DateTime? DebitStartDate { get; set; }
        public decimal? DebitPerAmount { get; set; }
        public string DebitFrequency { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Note { get; set; }
        public int? DeliveryId { get; set; }
        public int? AgreeId { get; set; }
        public DateTime? DeliverDate { get; set; }
        public string DeliverComment { get; set; }
        public decimal AccountFee { get; set; }
        public decimal DeliveryFee { get; set; }
        public int SettingId { get; set; }
        public int WarehouseId { get; set; }
        public bool IsContract { get; set; }
        public string CompleteStatus { get; set; }
        public int? ChannelId { get; set; }
        public string CustomerEmail { get; set; }

        public Warehouse Warehouse { get; set; }
        public ICollection<OrderProduct> ContractProduct { get; set; }
    }
    public partial class OrderProduct : BaseEntity
    {
        public int Id { get; set; }
        public long ContractId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string SeriesNumber { get; set; }
        public decimal? TaxRate { get; set; }
        public string Comment { get; set; }
        public decimal? BasicPrice { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
    public class Product : BaseEntity
    {
        public Product()
        {
            this.ProductProperties = new HashSet<ProductProperty>();
            this.ProductImages = new HashSet<ProductImage>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }
        public string Description { get; set; }

        public string SeriesNumber { get; set; }
        public string BarCode { get; set; }
        public string Profile { get; set; }
        public int? ProductCategoryId { get; set; }
        public bool? ShowOn { get; set; }
        public int? ShowOrder { get; set; }
        public decimal? PerPay { get; set; }
        public string ProductCode { get; set; }
        public decimal? TotalValue { get; set; }
        public Boolean Deleted { get; set; }
        public int? SupplierId { get; set; }
        public decimal? BasicPrice { get; set; }
        public decimal? RRP { get; set; }
        public string Paypal { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<ProductProperty> ProductProperties { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
    public class ProductCategory : BaseEntity
    {
        public ProductCategory()
        {
            this.Products = new HashSet<Product>();
            this.ProductCategory1 = new HashSet<ProductCategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> ParentId { get; set; }
        public Nullable<int> ShowOrder { get; set; }
        public Boolean Deleted { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedDate { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ProductCategory> ProductCategory1 { get; set; }
        public virtual ProductCategory ProductCategory2 { get; set; }
    }
    public class ProductImage : BaseEntity
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string Profile { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public virtual Product Product { get; set; }
    }
    public class ProductProperty : BaseEntity
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public virtual Product Product { get; set; }
    }
    public partial class Purchase : BaseEntity
    {
        public Purchase()
        {
            PurchaseProduct = new HashSet<PurchaseProduct>();
        }

        public int Id { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierReference { get; set; }
        public int WareHouseId { get; set; }
        public string DeliveryName { get; set; }
        public string StreetAddress { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int? SettingId { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? SUserId { get; set; }
        public string CompleteStatus { get; set; }
        public string Status { get; set; }
        public decimal? DeliveryFee { get; set; }
        public decimal? OtherFee { get; set; }

        public Warehouse WareHouse { get; set; }
        public ICollection<PurchaseProduct> PurchaseProduct { get; set; }
    }
    public partial class PurchaseProduct : BaseEntity
    {
        public int Id { get; set; }
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string Unit { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal? TaxRate { get; set; }
        public string Comment { get; set; }

        public Product Product { get; set; }
        public Purchase Purchase { get; set; }
    }

    public class Supplier : BaseEntity
    {
        public Supplier()
        {
            this.Products = new HashSet<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string GSTNumber { get; set; }
        public string Note { get; set; }
        public string TaxRate { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }
        public string PaymentTerm { get; set; }
        public string PhysicalName { get; set; }
        public string PhysicalStreetAddress { get; set; }
        public string PhysicalSuburb { get; set; }
        public string PhysicalCity { get; set; }
        public string PhysicalState { get; set; }
        public string PhysicalCountry { get; set; }
        public string PhysicalPostalCode { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactOfficePhone { get; set; }
        public string ContactWebsite { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactMobileNumber { get; set; }
        public string ContactDDINumber { get; set; }
        public string ContactTollFreeNumber { get; set; }
        public string Profile { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Boolean Deleted { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
    public partial class Warehouse : BaseEntity
    {
        public Warehouse()
        {
            Order = new HashSet<Order>();
            Purchase = new HashSet<Purchase>();
            WarehouseAdjustment = new HashSet<WarehouseAdjustment>();
            WarehouseInitialization = new HashSet<WarehouseInitialization>();
            WarehouseProduct = new HashSet<WarehouseProduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }

        public ICollection<Order> Order { get; set; }
        public ICollection<Purchase> Purchase { get; set; }
        public ICollection<WarehouseAdjustment> WarehouseAdjustment { get; set; }
        public ICollection<WarehouseInitialization> WarehouseInitialization { get; set; }
        public ICollection<WarehouseProduct> WarehouseProduct { get; set; }
    }
    public partial class WarehouseAdjustment : BaseEntity
    {
        public long Id { get; set; }
        public int WarehouseId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal ActualQuantity { get; set; }
        public DateTime OperationDate { get; set; }
        public int SUserId { get; set; }
        public string Reason { get; set; }

        public Warehouse Warehouse { get; set; }
    }

    public partial class WarehouseInitialization : BaseEntity
    {
        public long Id { get; set; }
        public int WarehouseId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public DateTime OperationDate { get; set; }
        public int SUserId { get; set; }

        public Product Product { get; set; }
        public Warehouse Warehouse { get; set; }
    }
    public partial class WarehousePrductRecord : BaseEntity
    {
        public long Id { get; set; }
        public long WarehouseProductId { get; set; }
        public string Operation { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public int? OperationId { get; set; }
        public DateTime OperationDate { get; set; }
        public int SUserId { get; set; }

        public WarehouseProduct WarehouseProduct { get; set; }
    }
    public partial class WarehouseProduct : BaseEntity
    {
        public WarehouseProduct()
        {
            WarehousePrductRecord = new HashSet<WarehousePrductRecord>();
        }

        public long Id { get; set; }
        public int WarehouseId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public decimal? Low { get; set; }
        public decimal? High { get; set; }

        public Product Product { get; set; }
        public Warehouse Warehouse { get; set; }
        public ICollection<WarehousePrductRecord> WarehousePrductRecord { get; set; }
    }
    public partial class WarehouseTransfer : BaseEntity
    {
        public WarehouseTransfer()
        {
            WarehouseTransferDetail = new HashSet<WarehouseTransferDetail>();
        }

        public long Id { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
        public DateTime OperationDate { get; set; }

        //public Warehouse From { get; set; }
        //public Warehouse To { get; set; }
        public ICollection<WarehouseTransferDetail> WarehouseTransferDetail { get; set; }
    }
    public partial class WarehouseTransferDetail : BaseEntity
    {
        public long Id { get; set; }
        public long WarehouseTransferId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }

        public Product Product { get; set; }
        public WarehouseTransfer WarehouseTransfer { get; set; }
    }
    #endregion
}
