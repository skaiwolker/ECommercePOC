using AutoMapper;
using eCommerce.Domain.DTOs;
using eCommerce.Domain.Models;
using eCommerce.Infrastructure.Repository.Interfaces;
using eCommerce.Services.Exceptions;
using eCommerce.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Services.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task AddProduct(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            await _productRepository.AddProduct(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var result = await _productRepository.GetProducts();
            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var result = await _productRepository.GetProductById(id);
            return _mapper.Map<ProductDTO>(result);
        }

        public async Task UpdateProduct(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            await _productRepository.UpdateProduct(product);
        }

        public async Task<bool> RemoveProduct(int id)
        {
            var product = _productRepository.GetProductById(id).Result;

            if (product != null) {
                await _productRepository.RemoveProduct(product);
                return true;
            }
            throw new IdNotFoundException("Product Id Not Found");
        }
    }
}
