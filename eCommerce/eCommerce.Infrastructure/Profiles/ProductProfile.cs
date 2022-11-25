using AutoMapper;
using eCommerce.Domain.DTOs;
using eCommerce.Domain.Models;

namespace eCommerce.Repository.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();
        }
    }
}
