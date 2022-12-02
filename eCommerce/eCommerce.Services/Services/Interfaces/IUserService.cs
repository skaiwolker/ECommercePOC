using eCommerce.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        Task<UserDTO> Login(LoginDTO loginDTO);

        string GenerateToken(ClaimsIdentity claimsIdentity);
    }
}
