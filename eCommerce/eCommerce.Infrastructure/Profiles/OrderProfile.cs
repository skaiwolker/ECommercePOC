using AutoMapper;
using eCommerce.Domain.DTOs;
using eCommerce.Domain.Models;

namespace eCommerce.Repository.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDTO, Order>();
            CreateMap<Order, OrderDTO>();
        }
    }
}
