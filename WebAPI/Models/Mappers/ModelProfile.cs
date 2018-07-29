using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.Models.Mappers
{
    public class ModelProfile:Profile
    {
        public ModelProfile()
        {
            CreateMap<Product, ProductModel>()
            .ReverseMap();

            CreateMap<ProductCategory, ProductCategoryModel>()
            .ReverseMap();

            CreateMap<ProductImage, ProductImageModel>()
            .ReverseMap();

            CreateMap<Supplier, SupplierModel>()
            .ReverseMap();
        }
    }
}
