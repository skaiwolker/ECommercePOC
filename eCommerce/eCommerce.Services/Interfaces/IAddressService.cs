
using eCommerce.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Services.Interfaces
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
