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
    public class ProductRepository : IProductRepository
    {
        private eCommerceContext _context;
        private IDbConnection _connection;

        public ProductRepository(eCommerceContext context)
        {
            _context = context;
            _connection = new SqlConnection(@"Data Source=DARTAGNAN\SQLEXPRESS;Initial Catalog=eCommerceDb;Integrated Security=True");
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            //return await _context.Products.ToListAsync();
            return await _connection.QueryAsync<Product>("SELECT * FROM Products");
        }

        public async Task<Product> GetProductById(int id)
        {
            //return await _context.Products.FirstOrDefaultAsync(product => product.Id == id);
            var param = new { Id = id };
            return await _connection.QueryFirstOrDefaultAsync<Product>("SELECT * FROM Products WHERE Id = @Id", param);
        }

        public async Task AddProduct(Product product)
        {
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveProduct(Product product)
        {
            _context.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
