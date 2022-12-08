using eCommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Repository.Interfaces
{
    public interface IProductImageRepository
    {
        Task<IEnumerable<ProductImage>> GetProductImages();

        Task AddProductImage(ProductImage productImage);

        Task RemoveProductImage(ProductImage productImage);
    }
}
