﻿using eCommerce.Domain.Models;
using eCommerce.Infrastructure.Context;
using eCommerce.Infrastructure.Interfaces;
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
            return await _context.Clients.Include(client => client.Addresses).ToListAsync();
        }

        public async Task<Client> GetClientById(int? id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public void AddClient(Client client)
        {
            _context.Add(client);
            _context.SaveChanges();
        }

        public void UpdateClient(Client client)
        {
            _context.Update(client);
            _context.SaveChanges();
        }

        public void RemoveClient(Client client)
        {
            _context.Remove(client);
            _context.SaveChanges();
        }
    }
}
