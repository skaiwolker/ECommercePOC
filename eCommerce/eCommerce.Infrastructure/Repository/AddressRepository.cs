using eCommerce.Domain.Models;
using eCommerce.Infrastructure.Context;
using eCommerce.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private eCommerceContext _context;

        public AddressRepository(eCommerceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Address>> GetAddresses()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task<Address> GetAddressById(int? id)
        {
            return await _context.Addresses.FindAsync(id);
        }

        public void AddAddress(Address address)
        {
            _context.Add(address);
            _context.SaveChanges();
        }

        public void UpdateAddress(Address address)
        {
            _context.Update(address);
            _context.SaveChanges();
        }

        public void RemoveAddress(Address address)
        {
            _context.Remove(address);
            _context.SaveChanges();
        }
    }
}
