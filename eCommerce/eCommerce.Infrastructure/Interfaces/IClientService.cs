using eCommerce.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Interfaces
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
