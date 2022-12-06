using eCommerce.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Repository.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrders();

        Task<Order> GetOrderById(int id);

        Task AddOrder(Order order);

        Task UpdateOrder(Order order);

        Task DeactivateOrder(Order order);
    }
}
