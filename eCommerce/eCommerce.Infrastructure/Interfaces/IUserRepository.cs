using eCommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();

        Task<User> GetUserById(int id);

        Task AddUser(User user);

        Task UpdateUser(User user);

        Task RemoveUser(User user);

        Task<User> AuthenticateUser(string username, string password);

        Task<Role> GetUserRole(int id);
    }
}
