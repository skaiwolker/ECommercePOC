using eCommerce.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Repository.Interfaces
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAddresses();

        Task<Address> GetAddressById(int id);

        Task AddAddress(Address address);

        Task UpdateAddress(Address address);

        Task DeactivateAddress(Address address);
    }
}
