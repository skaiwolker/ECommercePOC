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

        public async Task<OrderProduct> GetOrderProductById(int? id)
        {
            return await _context.OrderProducts.FindAsync(id);
        }

        public void AddOrderProduct(OrderProduct orderProduct)
        {
            _context.Add(orderProduct);
            _context.SaveChanges();
        }

        public void UpdateOrderProduct(OrderProduct orderProduct)
        {
            _context.Update(orderProduct);
            _context.SaveChanges();
        }

        public void RemoveOrderProduct(OrderProduct orderProduct)
        {
            _context.Remove(orderProduct);
            _context.SaveChanges();
        }
    }
}
