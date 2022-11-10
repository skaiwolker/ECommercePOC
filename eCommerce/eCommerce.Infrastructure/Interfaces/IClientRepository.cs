using eCommerce.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClients();

        Task<Client> GetClientById(int id);

        Task AddClient(Client client);

        Task UpdateClient(Client client);

        Task RemoveClient(Client client);
    }
}
