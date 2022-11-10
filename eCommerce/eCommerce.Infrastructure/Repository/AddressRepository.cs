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

        public async Task<Address> GetAddressById(int id)
        {
            return await _context.Addresses.FirstOrDefaultAsync(address => address.Id == id);
        }

        public async Task AddAddress(Address address)
        {
            await _context.AddAsync(address);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAddress(Address address)
        {
            _context.Update(address);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAddress(Address address)
        {
            _context.Remove(address);
            await _context.SaveChangesAsync();
        }
    }
}
