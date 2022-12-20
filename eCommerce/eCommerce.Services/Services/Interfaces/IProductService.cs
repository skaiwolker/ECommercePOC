using eCommerce.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Services.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();

        Task<ProductDTO> GetProductById(int id);

        Task AddProduct(ProductDTO product, IEnumerable<ProductImageDTO> productImageDTOs);

        Task UpdateProduct(ProductDTO product, IEnumerable<ProductImageDTO> productImageDTOs);

        Task<bool> DeactivateProduct(int id);

        Task<IEnumerable<ProductDTO>> GetProductsByName(string name);
    }
}
