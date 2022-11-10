using AutoMapper;
using eCommerce.Domain.DTOs;
using eCommerce.Domain.Models;

namespace eCommerce.Infrastructure.Profiles
{
    public class CreditCardProfile: Profile
    {
        public CreditCardProfile()
        {
            CreateMap<CreditCardDTO, CreditCard>();
            CreateMap<CreditCard, CreditCardDTO>();
        }
    }
}
