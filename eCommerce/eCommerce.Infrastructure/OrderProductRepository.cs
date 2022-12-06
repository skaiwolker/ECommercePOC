using Dapper;
using eCommerce.Domain.Models;
using eCommerce.Repository.Context;
using eCommerce.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Repository
{
    public class OrderProductRepository : IOrderProductRepository
    {
        private eCommerceContext _context;
        private readonly IDbConnection _connection;

        public OrderProductRepository(eCommerceContext context, IConfiguration configuration)
        {
            _context = context;
            _connection = _connection.AddConnection(configuration);
        }

        public async Task<IEnumerable<OrderProduct>> GetOrderProducts()
        {
            //return await _context.OrderProducts.Include(orderProduct => orderProduct.Product).Include(orderProduct => orderProduct.Order).ThenInclude(order => order.Client).ToListAsync();
            return await _connection.QueryAsync<OrderProduct>("SELECT * FROM OrderProducts");
        }

        public async Task<OrderProduct> GetOrderProductById(int id)
        {
            //return await _context.OrderProducts.Include(orderProduct => orderProduct.Product).Include(orderProduct => orderProduct.Order).ThenInclude(order => order.Client).FirstOrDefaultAsync(orderProduct => orderProduct.Id == id);
            var param = new { Id = id };


            var query = @"SELECT * FROM OrderProducts op
                          LEFT JOIN Orders o ON op.OrderId = o.Id
                          LEFT JOIN Products p ON op.ProductId = p.Id
                          WHERE op.Id = @Id";

            var result = await _connection.QueryAsync<OrderProduct, Order, Product, OrderProduct>(query, (orderProduct, order, product) =>
            {
                orderProduct.Order = order;
                orderProduct.Product = product;

                return orderProduct;

            }, param);


            return result.FirstOrDefault();
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

        public async Task DeactivateOrderProduct(OrderProduct orderProduct)
        {
            _context.Remove(orderProduct);
            await _context.SaveChangesAsync();
        }
    }
}
