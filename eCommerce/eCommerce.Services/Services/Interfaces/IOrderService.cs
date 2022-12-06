using eCommerce.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Services.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetOrders();

        Task<OrderDTO> GetOrderById(int id);

        Task AddOrder(OrderDTO order);

        Task UpdateOrder(OrderDTO order);

        Task<bool> DeactivateOrder(int id);
    }
}
