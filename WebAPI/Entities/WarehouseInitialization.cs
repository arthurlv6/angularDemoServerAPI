using System;
using System.Collections.Generic;

namespace WebAPI.Entities
{
    public partial class WarehouseInitialization
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
}
