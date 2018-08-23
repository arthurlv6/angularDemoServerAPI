using System;


namespace WebAPI.Models
{
    public class ProductCategoryModel
    {
        public ProductCategoryModel()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public int? ShowOrder { get; set; }
    }
}
