using System;
using System.Collections.Generic;

namespace WebAPI.Entities
{
    public partial class WarehouseTransferDetail
    {
        public long Id { get; set; }
        public long WarehouseTransferId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }

        public Product Product { get; set; }
        public WarehouseTransfer WarehouseTransfer { get; set; }
    }
}
