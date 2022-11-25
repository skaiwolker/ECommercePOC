using AutoMapper;
using eCommerce.Domain.DTOs;
using eCommerce.Domain.Models;

namespace eCommerce.Repository.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<AddressDTO, Address>();
            CreateMap<Address, AddressDTO>();
        }
    }
}
