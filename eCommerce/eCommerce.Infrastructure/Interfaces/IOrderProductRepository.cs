using eCommerce.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Repository.Interfaces
{
    public interface IOrderProductRepository
    {
        Task<IEnumerable<OrderProduct>> GetOrderProducts();

        Task<OrderProduct> GetOrderProductById(int id);

        Task AddOrderProduct(OrderProduct orderProduct);

        Task UpdateOrderProduct(OrderProduct orderProduct);

        Task RemoveOrderProduct(OrderProduct orderProduct);
    }
}
