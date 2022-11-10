using eCommerce.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetOrders();

        Task<OrderDTO> GetOrderById(int? id);

        void AddOrder(OrderDTO order);

        void UpdateOrder(OrderDTO order);

        void RemoveOrder(int? id);
    }
}
