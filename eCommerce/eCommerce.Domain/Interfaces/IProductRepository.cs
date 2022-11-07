using eCommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<Product> GetProductById(int? id);

        void AddProduct(Product product);

        void UpdateProduct(Product product);

        void RemoveProduct(Product product);
    }
}
