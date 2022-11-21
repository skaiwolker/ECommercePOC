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
    public class OrderProductRepository : IOrderProductRepository
    {
        private eCommerceContext _context;
        private IDbConnection _connection;

        public OrderProductRepository(eCommerceContext context)
        {
            _context = context;
            _connection = new SqlConnection(@"Data Source=DARTAGNAN\SQLEXPRESS;Initial Catalog=eCommerceDb;Integrated Security=True");
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
            return await _connection.QueryFirstOrDefaultAsync<OrderProduct>("SELECT * FROM OrderProducts WHERE Id = @Id", param);
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
