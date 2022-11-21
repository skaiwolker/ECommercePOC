using Dapper;
using eCommerce.Domain.Models;
using eCommerce.Infrastructure.Context;
using eCommerce.Infrastructure.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Repository
{
    public class ClientRepository : IClientRepository
    {
        private eCommerceContext _context;
        private IDbConnection _connection;

        public ClientRepository(eCommerceContext context)
        {
            _context = context;
            _connection = new SqlConnection(@"Data Source=DARTAGNAN\SQLEXPRESS;Initial Catalog=eCommerceDb;Integrated Security=True");
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            //return await _context.Clients.Include(client => client.Addresses).Include(creditCard => creditCard.CreditCards).Include(order => order.Orders).ToListAsync();
            return await _connection.QueryAsync<Client>("SELECT * FROM Clients");
        }

        public async Task<Client> GetClientById(int id)
        {
            //return await _context.Clients.Include(client => client.Addresses).Include(creditCard => creditCard.CreditCards).Include(order => order.Orders).FirstOrDefaultAsync(client => client.Id == id);
            var param = new { Id = id };

            var query = @"SELECT * FROM Clients c
                        WHERE c.Id = @Id";

            return await _connection.QueryFirstOrDefaultAsync<Client>(query, param);
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
