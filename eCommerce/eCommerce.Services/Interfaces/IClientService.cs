using eCommerce.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Services.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDTO>> GetClients();

        Task<ClientDTO> GetClientById(int? id);

        void AddClient(ClientDTO client);

        void UpdateClient(ClientDTO client);

        void RemoveClient(int? id);
    }
}
