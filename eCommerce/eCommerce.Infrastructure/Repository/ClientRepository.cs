using Dapper;
using eCommerce.Domain.Models;
using eCommerce.Infrastructure.Context;
using eCommerce.Infrastructure.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Repository
{
    public class ClientRepository : IClientRepository
    {
        private eCommerceContext _context;
        private readonly IDbConnection _connection;

        public ClientRepository(eCommerceContext context, IConfiguration configuration)
        {
            _context = context;
            _connection = _connection.AddConnection(configuration);
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
                        WHERE c.Id = @Id
                        
                        SELECT * FROM Addresses A
                        WHERE a.ClientId = @Id";

            var result = await _connection.QueryMultipleAsync(query, param);

            var client = result.ReadFirstOrDefaultAsync<Client>();

            client.Result.Addresses = result.ReadAsync<Address>()?.Result?.ToList();

            return client.Result;
            
            //return _connection.QueryAsync<Client, Address, Order, Client>(
            //    query,
            //    (client, address, order) =>
            //    {
            //        Client clientEmpty;

            //        if (!clientDictionary.TryGetValue(client.Id, out clientEmpty))
            //        {
            //            clientDictionary.Add(client.Id, clientEmpty = client);
            //        }

            //        if (clientEmpty.Addresses == null)
            //        {
            //            clientEmpty.Addresses = new List<Address>();
            //        }
            //        if (address != null)
            //        {
            //            if (!clientEmpty.Addresses.Any(x => x.Id == address.Id))
            //            {
            //                clientEmpty.Addresses.Add(address);
            //            }
            //        }

            //        if (clientEmpty.Orders == null)
            //        {
            //            clientEmpty.Orders = new List<Order>();
            //        }
            //        if (order != null)
            //        {
            //            if (!clientEmpty.Orders.Any(x => x.Id == order.Id))
            //            {
            //                clientEmpty.Orders.Add(order);
            //            }
            //        }

            //        return clientEmpty;
            //    },
            //    splitOn: "a.Id, o.Id"); 

            //return _connection.Query<Client, Address, Order, Client>(query, 
            //    map: (c, a, o) =>
            //    {
            //        a.ClientId = c.Id;
            //        o.ClientId = c.Id;

            //        c.Addresses.Add(a);
            //        c.Orders.Add(o);
            //        return c;
            //    }
            //    ,param).FirstOrDefault();
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
