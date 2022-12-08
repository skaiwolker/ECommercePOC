using AutoMapper;
using eCommerce.Domain.DTOs;
using eCommerce.Domain.Models;
using eCommerce.Repository.Interfaces;
using eCommerce.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services.Services
{
    public class ProductImageService : IProductImageService
    {
        private IProductImageRepository _productImageRepository;
        private readonly IMapper _mapper;

        public ProductImageService(IMapper mapper, IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
            _mapper = mapper;
        }


        public async Task AddProductImage(ProductImageDTO productImageDTO)
        {
            byte[] image = ConvertToByte(productImageDTO.ImagePath);

            var productImage = _mapper.Map<ProductImage>(productImageDTO);

            productImage.Image = image;

            await _productImageRepository.AddProductImage(productImage);
        }

        public Task<IEnumerable<ProductImageDTO>> GetProductImages()
        {
            throw new NotImplementedException();
        }

        public Task RemoveProductImage(int id)
        {
            throw new NotImplementedException();
        }

        public byte[] ConvertToByte(string path)
        {
            byte[] image;

            var stream = new FileStream(path, FileMode.Open, FileAccess.Read);

            var reader = new BinaryReader(stream);

            image = reader.ReadBytes((int)stream.Length);

            return image;
        }
    }
}
