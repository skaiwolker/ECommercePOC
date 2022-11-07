using eCommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Interfaces
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAddresses();

        Task<Address> GetAddressById(int? id);

        void AddAddress(Address address);

        void UpdateAddress(Address address);

        void RemoveAddress(Address address);
    }
}
