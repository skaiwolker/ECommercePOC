using AutoMapper;
using eCommerce.Domain.DTOs;
using eCommerce.Domain.Models;

namespace eCommerce.Repository.Profiles
{
    public class OrderProductProfile : Profile
    {
        public OrderProductProfile()
        {
            CreateMap<OrderProductDTO, OrderProduct>();
            CreateMap<OrderProduct, OrderProductDTO>();
        }
    }
}
