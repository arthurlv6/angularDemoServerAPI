using System;
using System.Collections.Generic;

namespace WebAPI.Entities
{
    public partial class Warehouse
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
}
