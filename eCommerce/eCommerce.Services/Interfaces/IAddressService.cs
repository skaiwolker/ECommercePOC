
using eCommerce.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Services.Interfaces
{
    public interface IAddressService
    {
        Task<IEnumerable<AddressDTO>> GetAddresses();

        Task<AddressDTO> GetAddressById(int id);

        Task AddAddress(AddressDTO address);

        Task UpdateAddress(AddressDTO address);

        Task<bool> RemoveAddress(int id);
    }
}
