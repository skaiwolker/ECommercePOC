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

        public async Task DeactivateUser(User user)
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

            var query = @"SELECT * FROM Users u
                        LEFT JOIN Roles r ON u.RoleId = r.Id
                        WHERE Username = @username
                        AND Password = @password";

            var result = await _connection.QueryAsync<User, Role, User>(query, (user, role) =>
            {
                user.Role = role;
                return user;
            }, param);

            return result.FirstOrDefault();
        }

        public async Task<User> ValidateIfExists(string email, string username)
        {
            var param = new
            {
                Username = username,
                Email = email
            };

            var query = @"SELECT * FROM Users
                        WHERE Username = @username
                        OR Email = @email"
            ;

            return await _connection.QueryFirstOrDefaultAsync<User>(query, param);
        }
    }
}
