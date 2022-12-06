using Dapper;
using eCommerce.Domain.Models;
using eCommerce.Repository.Context;
using eCommerce.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace eCommerce.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private eCommerceContext _context;
        private readonly IDbConnection _connection;

        public OrderRepository(eCommerceContext context, IConfiguration configuration)
        {
            _context = context;
            _connection = _connection.AddConnection(configuration);
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            //return await _context.Orders.ToListAsync();
            return await _connection.QueryAsync<Order>("SELECT * FROM Orders");
        }

        public async Task<Order> GetOrderById(int id)
        {
            //return await _context.Orders.Include(order => order.OrderProducts).FirstOrDefaultAsync(order => order.Id == id);
            var param = new { Id = id };
            return await _connection.QueryFirstOrDefaultAsync<Order>("SELECT * FROM Orders WHERE Id = @Id", param);
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

        public async Task DeactivateOrder(Order order)
        {
            _context.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}
