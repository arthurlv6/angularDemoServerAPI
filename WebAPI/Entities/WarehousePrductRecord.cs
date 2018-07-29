using System;
using System.Collections.Generic;

namespace WebAPI.Entities
{
    public partial class WarehousePrductRecord
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
}
