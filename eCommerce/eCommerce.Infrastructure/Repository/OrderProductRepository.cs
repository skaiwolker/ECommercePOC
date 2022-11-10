using eCommerce.Domain.Models;
using eCommerce.Infrastructure.Context;
using eCommerce.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Repository
{
    public class OrderProductRepository : IOrderProductRepository
    {
        private eCommerceContext _context;

        public OrderProductRepository(eCommerceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderProduct>> GetOrderProducts()
        {
            return await _context.OrderProducts.ToListAsync();
        }

        public async Task<OrderProduct> GetOrderProductById(int id)
        {
            return await _context.OrderProducts.Include(orderProduct => orderProduct.Product).FirstOrDefaultAsync(orderProduct => orderProduct.Id == id);
        }

        public async Task AddOrderProduct(OrderProduct orderProduct)
        {
            await _context.AddAsync(orderProduct);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderProduct(OrderProduct orderProduct)
        {
            _context.Update(orderProduct);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveOrderProduct(OrderProduct orderProduct)
        {
            _context.Remove(orderProduct);
            await _context.SaveChangesAsync();
        }
    }
}
