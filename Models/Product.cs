using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class ProductModel
    {
        public ProductModel()
        {
            this.ProductProperties = new HashSet<ProductPropertyModel>();
            this.ProductImages = new HashSet<ProductImageModel>();
        }

        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }
        public string Description { get; set; }

        public string SeriesNumber { get; set; }
        public string BarCode { get; set; }
        public string Profile { get; set; }
        public bool? ShowOn { get; set; }
        public int? ShowOrder { get; set; }
        public decimal? PerPay { get; set; }
        public string ProductCode { get; set; }
        public decimal? TotalValue { get; set; }
        public decimal? BasicPrice { get; set; }
        public decimal? RRP { get; set; }
        public string Paypal { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public virtual ProductCategoryModel ProductCategory { get; set; }
        public virtual SupplierModel Supplier { get; set; }
        public virtual ICollection<ProductPropertyModel> ProductProperties { get; set; }
        public virtual ICollection<ProductImageModel> ProductImages { get; set; }
    }
}
