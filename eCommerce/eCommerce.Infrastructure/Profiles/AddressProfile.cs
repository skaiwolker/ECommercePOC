using AutoMapper;
using eCommerce.Domain.Models;
using eCommerce.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Profiles
{
    public class AddressProfile: Profile
    {
        public AddressProfile()
        {
            CreateMap<AddressDTO, Address>();
            CreateMap<Address, AddressDTO>();
        }
    }
}
