using eCommerce.Domain.Interfaces;
using eCommerce.Domain.Models;
using eCommerce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private eCommerceContext _context;

        public OrderRepository(eCommerceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderById(int? id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public void AddOrder(Order order)
        {
            _context.Add(order);
            _context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _context.Update(order);
            _context.SaveChanges();
        }

        public void RemoveOrder(Order order)
        {
            _context.Remove(order);
            _context.SaveChanges();
        }
    }
}
