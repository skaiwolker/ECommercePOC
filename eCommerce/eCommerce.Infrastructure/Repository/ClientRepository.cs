using eCommerce.Domain.Models;
using eCommerce.Infrastructure.Context;
using eCommerce.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Repository
{
    public class ClientRepository : IClientRepository
    {
        private eCommerceContext _context;

        public ClientRepository(eCommerceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetClientById(int id)
        {
            return await _context.Clients.Include(client => client.Addresses).Include(creditCard => creditCard.CreditCards).Include(order => order.Orders).FirstOrDefaultAsync(client => client.Id == id);
        }

        public async Task AddClient(Client client)
        {
            await _context.AddAsync(client);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClient(Client client)
        {
            _context.Update(client);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveClient(Client client)
        {
            _context.Remove(client);
            await _context.SaveChangesAsync();
        }
    }
}
