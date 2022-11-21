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
    public class OrderRepository : IOrderRepository
    {
        private eCommerceContext _context;
        private IDbConnection _connection;

        public OrderRepository(eCommerceContext context)
        {
            _context = context;
            _connection = new SqlConnection(@"Data Source=DARTAGNAN\SQLEXPRESS;Initial Catalog=eCommerceDb;Integrated Security=True");
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

        public async Task RemoveOrder(Order order)
        {
            _context.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}
