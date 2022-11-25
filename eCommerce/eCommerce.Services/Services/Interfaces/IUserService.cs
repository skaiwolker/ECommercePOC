using eCommerce.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetUsers();

        Task<UserDTO> GetUserById(int id);

        Task AddUser(UserDTO user);

        Task UpdateUser(UserDTO user);

        Task<bool> RemoveUser(int id);

        Task<string> Login(LoginDTO loginDTO);
    }
}
