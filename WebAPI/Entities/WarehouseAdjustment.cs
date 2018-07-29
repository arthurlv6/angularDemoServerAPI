using System;
using System.Collections.Generic;

namespace WebAPI.Entities
{
    public partial class WarehouseAdjustment
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
}
