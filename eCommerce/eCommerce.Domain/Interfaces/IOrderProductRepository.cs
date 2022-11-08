using eCommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Interfaces
{
    public interface IOrderProductRepository
    {
        Task<IEnumerable<OrderProduct>> GetOrderProducts();

        Task<OrderProduct> GetOrderProductById(int? id);

        void AddOrderProduct(OrderProduct orderProduct);

        void UpdateOrderProduct(OrderProduct orderProduct);

        void RemoveOrderProduct(OrderProduct orderProduct);
    }
}
