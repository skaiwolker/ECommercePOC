using eCommerce.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();

        Task<ProductDTO> GetProductById(int id);

        void AddProduct(ProductDTO product);

        void UpdateProduct(ProductDTO product);

        void RemoveProduct(int id);
    }
}
