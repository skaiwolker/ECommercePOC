using eCommerce.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Services.Interfaces
{
    public interface IOrderProductService
    {
        Task<IEnumerable<OrderProductDTO>> GetOrderProducts();

        Task<OrderProductDTO> GetOrderProductById(int id);

        Task AddOrderProduct(OrderProductDTO orderProduct);

        Task UpdateOrderProduct(OrderProductDTO orderProduct);

        void RemoveOrderProduct(int id);
    }
}

