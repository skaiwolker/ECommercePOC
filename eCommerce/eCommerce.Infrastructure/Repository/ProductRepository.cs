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
    public class ProductRepository : IProductRepository
    {
        private eCommerceContext _context;

        public ProductRepository(eCommerceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int? id)
        {
            return await _context.Products.FindAsync(id);
        }

        public void AddProduct(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();
        }

        public void RemoveProduct(Product product)
        {
            _context.Remove(product);
            _context.SaveChanges();
        }
    }
}
