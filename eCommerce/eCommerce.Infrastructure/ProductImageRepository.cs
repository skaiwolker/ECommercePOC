using Dapper;
using eCommerce.Domain.Models;
using eCommerce.Repository.Context;
using eCommerce.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Repository
{
    public class ProductImageRepository : IProductImageRepository
    {
        private eCommerceContext _context;
        private readonly IDbConnection _connection;

        public ProductImageRepository(eCommerceContext context, IConfiguration configuration)
        {
            _context = context;
            _connection = _connection.AddConnection(configuration);
        }

        public async Task AddProductImage(ProductImage productImage)
        {
            await _context.AddAsync(productImage);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductImage>> GetProductImages()
        {
            return await _connection.QueryAsync<ProductImage>("SELECT * FROM ProductImages");
        }

        public async Task RemoveProductImage(ProductImage productImage)
        {
            _context.Remove(productImage);
            await _context.SaveChangesAsync();
        }
    }
}
