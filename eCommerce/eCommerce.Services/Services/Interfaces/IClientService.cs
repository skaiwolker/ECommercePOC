using eCommerce.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Services.Services.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDTO>> GetClients();

        Task<ClientDTO> GetClientById(int id);

        Task AddClient(ClientDTO client);

        Task UpdateClient(ClientDTO client);

        Task<bool> RemoveClient(int id);
    }
}
