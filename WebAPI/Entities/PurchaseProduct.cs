using System;
using System.Collections.Generic;

namespace WebAPI.Entities
{
    public partial class PurchaseProduct
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
}
