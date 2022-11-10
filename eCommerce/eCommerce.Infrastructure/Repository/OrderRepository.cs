using eCommerce.Domain.Models;
using eCommerce.Infrastructure.Context;
using eCommerce.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<Order> GetOrderById(int id)
        {
            return await _context.Orders.Include(order => order.OrderProducts).FirstOrDefaultAsync(order => order.Id == id);
        }

        public async Task AddOrder(Order order)
        {
            await _context.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrder(Order order)
        {
            _context.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveOrder(Order order)
        {
            _context.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}
