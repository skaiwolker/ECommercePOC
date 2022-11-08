using eCommerce.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();

        Task<ProductDTO> GetProductById(int? id);

        void AddProduct(ProductDTO product);

        void UpdateProduct(ProductDTO product);

        void RemoveProduct(int? id);
    }
}
