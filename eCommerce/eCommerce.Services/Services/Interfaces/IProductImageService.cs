using eCommerce.Domain.DTOs;
using eCommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services.Services.Interfaces
{
    public interface IProductImageService
    {
        Task<IEnumerable<ProductImageDTO>> GetProductImages();

        Task AddProductImage(ProductImageDTO productImageDTO);

        Task RemoveProductImage(int id);

        byte[] ConvertToByte(string path);
    }
}
