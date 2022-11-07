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
    public class ClientProfile: Profile
    {
        public ClientProfile()
        {
            CreateMap<ClientDTO, Client>();
            CreateMap<Client, ClientDTO>();
        }
    }
}
