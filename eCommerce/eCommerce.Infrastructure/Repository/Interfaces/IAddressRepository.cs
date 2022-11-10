using eCommerce.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Repository.Interfaces
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAddresses();

        Task<Address> GetAddressById(int id);

        Task AddAddress(Address address);

        Task UpdateAddress(Address address);

        Task RemoveAddress(Address address);
    }
}
