using System;
using System.Collections.Generic;

namespace WebAPI.Entities
{
    public partial class WarehouseTransfer
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
}
