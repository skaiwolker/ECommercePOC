using eCommerce.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClients();

        Task<Client> GetClientById(int? id);

        void AddClient(Client client);

        void UpdateClient(Client client);

        void RemoveClient(Client client);
    }
}
