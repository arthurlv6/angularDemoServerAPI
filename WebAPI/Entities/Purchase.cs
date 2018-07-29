using System;
using System.Collections.Generic;

namespace WebAPI.Entities
{
    public partial class Purchase
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
}
