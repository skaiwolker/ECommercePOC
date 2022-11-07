using eCommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrders();

        Task<Order> GetOrderById(int? id);

        void AddOrder(Order order);

        void UpdateOrder(Order order);

        void RemoveOrder(Order order);
    }
}
