using eCommerce.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Interfaces
{
    public interface IAddressService
    {
        Task<IEnumerable<AddressDTO>> GetAddresses();

        Task<AddressDTO> GetAddressById(int? id);

        void AddAddress(AddressDTO address);

        void UpdateAddress(AddressDTO address);

        void RemoveAddress(int? id);
    }
}
