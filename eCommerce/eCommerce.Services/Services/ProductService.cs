using AutoMapper;
using eCommerce.Domain.DTOs;
using eCommerce.Domain.Models;
using eCommerce.Repository.Interfaces;
using eCommerce.Services.Exceptions;
using eCommerce.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
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
            if (string.IsNullOrEmpty(productDTO.Name))
            {
                throw new eCommerceException("Name cannot be null or empty", HttpStatusCode.BadRequest);
            }
            if (productDTO.Amount < 0)
            {
                throw new eCommerceException("Amount cannot be less than 0", HttpStatusCode.BadRequest);
            }
            else if (productDTO.Price <= 0)
            {
                throw new eCommerceException("Price cannot be equal or less than 0", HttpStatusCode.BadRequest);
            }
            else if (productDTO.Department <= 0)
            {
                throw new eCommerceException("Department cannot be equal or less than 0", HttpStatusCode.BadRequest);
            }

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

            if (result == null)
            {
                throw new eCommerceException("Product Not Found", HttpStatusCode.NotFound);
            }
            else
            {
                return _mapper.Map<ProductDTO>(result);
            }

        }

        public async Task UpdateProduct(ProductDTO productDTO)
        {
            if (string.IsNullOrEmpty(productDTO.Name))
            {
                throw new eCommerceException("Name cannot be null or empty", HttpStatusCode.BadRequest);
            }
            if (productDTO.Amount < 0)
            {
                throw new eCommerceException("Amount cannot be less than 0", HttpStatusCode.BadRequest);
            }
            else if (productDTO.Price <= 0)
            {
                throw new eCommerceException("Price cannot be equal or less than 0", HttpStatusCode.BadRequest);
            }
            else if (productDTO.Department <= 0)
            {
                throw new eCommerceException("Department cannot be equal or less than 0", HttpStatusCode.BadRequest);
            }

            var product = await _productRepository.GetProductById(productDTO.Id);

            if (product == null)
            {
                throw new eCommerceException("Product Not Found", HttpStatusCode.NotFound);
            }

            //var newProduct = _mapper.Map<Product>(productDTO);
            //product = newProduct;

            product.Name = productDTO.Name;
            product.Description = productDTO.Description;
            product.Department = productDTO.Department;
            product.Seller = productDTO.Seller;
            product.Amount = productDTO.Amount;
            product.Price = productDTO.Price;

            await _productRepository.UpdateProduct(product);

        }

        public async Task<bool> RemoveProduct(int id)
        {
            var product = _productRepository.GetProductById(id).Result;

            if (product != null)
            {
                await _productRepository.RemoveProduct(product);
                return true;
            }
            throw new eCommerceException("Product Not Found", HttpStatusCode.NotFound);
        }
    }
}
