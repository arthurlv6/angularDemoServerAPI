using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Entities
{
    public class ProductCategory
    {
        public ProductCategory()
        {
            this.Products = new HashSet<Product>();
            this.ProductCategory1 = new HashSet<ProductCategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> ParentId { get; set; }
        public Nullable<int> ShowOrder { get; set; }
        public Boolean Deleted { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedDate { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ProductCategory> ProductCategory1 { get; set; }
        public virtual ProductCategory ProductCategory2 { get; set; }
    }
}
