using eCommerce.Domain.Models;
using eCommerce.Infrastructure.Context;
using eCommerce.Infrastructure.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace eCommerce.Infrastructure.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private eCommerceContext _context;
        private readonly IDbConnection _connection;

        public AddressRepository(eCommerceContext context, IConfiguration configuration)
        {
            _context = context;
            _connection = _connection.AddConnection(configuration);
        }

        public async Task<IEnumerable<Address>> GetAddresses()
        {
            //return await _context.Addresses.ToListAsync();
            return await _connection.QueryAsync<Address>("SELECT * FROM Addresses");
        }

        public async Task<Address> GetAddressById(int id)
        {
            //return await _context.Addresses.FirstOrDefaultAsync(address => address.Id == id);
            var param = new { Id = id };
            return await _connection.QueryFirstOrDefaultAsync<Address>("SELECT * FROM Addresses WHERE Id = @Id", param);
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
