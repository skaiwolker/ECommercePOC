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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace eCommerce.Repository
{
    public class UserRepository : IUserRepository
    {
        private eCommerceContext _context;
        private readonly IDbConnection _connection;

        public UserRepository(eCommerceContext context, IConfiguration configuration)
        {
            _context = context;
            _connection = _connection.AddConnection(configuration);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _connection.QueryAsync<User>("SELECT * FROM Users");
        }

        public async Task<User> GetUserById(int id)
        {
            var param = new { Id = id };


            return await _connection.QueryFirstOrDefaultAsync<User>("SELECT * FROM Users WHERE Id = @Id", param);


        }

        public async Task AddUser(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveUser(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> AuthenticateUser(string username, string password)
        {
            var param = new
            {
                Username = username,
                Password = password
            };

            //var queryUser = @"SELECT * FROM Users 
            //    WHERE Username = @username
            //    AND Password = @password";

            //var queryRole = @"SELECT * FROM Role r
            //            WHERE r.Id = @Id";

            var query = @"
                SELECT * FROM Users 
                WHERE Username = @username
                AND Password = @password
            ";



            //var result = await _connection.QueryMultipleAsync(query, param);

            //var client = result.ReadFirstOrDefaultAsync<Client>();

          //  client.Result.Addresses = result.ReadAsync<Address>()?.Result?.ToList();

            //return client.Result;
            return await _connection.QueryFirstOrDefaultAsync<User>(query, param);
        }

        public async Task<Role> GetUserRole(int id)
        {
            var param = new
            {
                Id = id
            };

            var query = @"
                SELECT * FROM Role 
                WHERE Id = @Id
            ";

            return await _connection.QueryFirstOrDefaultAsync<Role>(query, param);

        }

    }
}
