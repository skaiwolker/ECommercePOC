using eCommerce.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Interfaces
{
    public interface IOrderProductService
    {
        Task<IEnumerable<OrderProductDTO>> GetOrderProducts();

        Task<OrderProductDTO> GetOrderProductById(int? id);

        void AddOrderProduct(OrderProductDTO orderProduct);

        void UpdateOrderProduct(OrderProductDTO orderProduct);

        void RemoveOrderProduct(int? id);
    }
}
