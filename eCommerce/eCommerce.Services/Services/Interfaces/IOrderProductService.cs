using eCommerce.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Services.Services.Interfaces
{
    public interface IOrderProductService
    {
        Task<IEnumerable<OrderProductDTO>> GetOrderProducts();

        Task<OrderProductDTO> GetOrderProductById(int id);

        Task AddOrderProduct(OrderProductDTO orderProduct);

        Task UpdateOrderProduct(OrderProductDTO orderProduct);

        Task<bool> DeactivateOrderProduct(int id);
    }
}

