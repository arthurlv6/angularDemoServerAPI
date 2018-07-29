using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Entities
{
    public class Product
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
}
