using AutoMapper;
using eCommerce.Domain.DTOs;
using eCommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Repository.Profiles
{
    public class ProductImageProfile : Profile
    {
        public ProductImageProfile()
        {
            CreateMap<ProductImageDTO, ProductImage>();
            CreateMap<ProductImage, ProductImageDTO>();
        }
    }
}
