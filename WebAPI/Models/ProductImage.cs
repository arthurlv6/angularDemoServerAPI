using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ProductImageModel
    {
        public int Id { get; set; }
        public string Profile { get; set; }
        public string Description { get; set; }
        public virtual ProductModel Product { get; set; }
    }
}
