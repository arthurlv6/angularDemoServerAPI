using AutoMapper;
using Models;
using Repositories.Entities;

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

            CreateMap<Supplier, SupplierModel>().ReverseMap();

           
        }
    }
}
