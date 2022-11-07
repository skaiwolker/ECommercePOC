using eCommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Interfaces
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
