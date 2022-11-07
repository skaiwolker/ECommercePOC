using eCommerce.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Interfaces
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
