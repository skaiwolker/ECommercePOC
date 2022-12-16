using Dapper;
using eCommerce.Domain.Models;
using eCommerce.Repository.Context;
using eCommerce.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Repository
{
    public class ProductRepository : IProductRepository
    {
        private eCommerceContext _context;
        private readonly IDbConnection _connection;

        public ProductRepository(eCommerceContext context, IConfiguration configuration)
        {
            _context = context;
            _connection = _connection.AddConnection(configuration);
        }

        public async Task<IEnumerable<Product>> GetProducts()//(IEnumerable<ProductImage> productImages)
        {
            //return await _context.Products.ToListAsync();
            var query = @"SELECT * FROM Products p
            WHERE p.[Delete] != 1";

            var result = await _connection.QueryAsync<Product>(query);

            var query2 = @"SELECT * FROM ProductImages pi WHERE ProductId = @productId";

            
            foreach (var product in result)
            {
                product.ProductImages = (await _connection.QueryAsync<ProductImage>(query2, new  {productId = product.Id})).ToList();
            }
           // var result = await _connection.QueryAsync<Product>(query);

            return result;
        }

        public async Task<Product> GetProductById(int id)
        {
            //return await _context.Products.FirstOrDefaultAsync(product => product.Id == id);
            var param = new { Id = id };

            var query = @"SELECT * FROM Products p 
                          WHERE p.Id = @Id"
            ;

            var result = await _connection.QueryAsync<Product>(query, param);

            return result.FirstOrDefault();
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

        public async Task DeactivateProduct(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByName(string name)
        {

            var param = new
            {
                Name = name
            };

            var query = @"SELECT * FROM Products 
                          WHERE Name LIKE '%@Name%'
                          OR Description LIKE '%@Name%'";

            var result = await _connection.QueryAsync<Product>(query, param);

            return result;
        }
    }
}
