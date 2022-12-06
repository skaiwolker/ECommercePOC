using eCommerce.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<Product> GetProductById(int id);

        Task AddProduct(Product product);

        Task UpdateProduct(Product product);

        Task DeactivateProduct(Product product);

        Task<IEnumerable<Product>> GetProductsByName(string name);
    }
}
