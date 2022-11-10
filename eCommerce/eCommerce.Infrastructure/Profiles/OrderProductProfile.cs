using AutoMapper;
using eCommerce.Domain.DTOs;
using eCommerce.Domain.Models;

namespace eCommerce.Infrastructure.Profiles
{
    public class OrderProductProfile: Profile
    {
        public OrderProductProfile()
        {
            CreateMap<OrderProductDTO, OrderProduct>();
            CreateMap<OrderProduct, OrderProductDTO>();
        }
    }
}
