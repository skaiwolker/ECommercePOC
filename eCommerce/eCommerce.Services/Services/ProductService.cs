﻿using AutoMapper;
using eCommerce.Domain.DTOs;
using eCommerce.Domain.Models;
using eCommerce.Repository.Interfaces;
using eCommerce.Services.Exceptions;
using eCommerce.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace eCommerce.Services.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private IProductImageService _imageService;

        public ProductService(IMapper mapper, IProductRepository productRepository, IProductImageService imageService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _imageService = imageService;
        }

        public async Task AddProduct(ProductDTO productDTO, IEnumerable<ProductImageDTO> productImageDTOs)
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

            product.Delete = 0;

            await _productRepository.AddProduct(product);

            //if (productImageDTOs != null)
            //{
            //    //var getNewProductId = GetProducts().Result.LastOrDefault().Id;

            //    for (int i = 0; i < productImageDTOs.Count(); i++)
            //    {
            //        productImageDTOs.Cast<ProductImageDTO>().ElementAt(i).ProductId = 15;//getNewProductId;
            //        await _imageService.AddProductImage(productImageDTOs.Cast<ProductImageDTO>().ElementAt(i));
            //    }
            //}
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            //var productImagesDTO = await _imageService.GetProductImages();
           // var productImages = _mapper.Map<IEnumerable<ProductImage>>(productImagesDTO);

            var result = await _productRepository.GetProducts();//(productImages);
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

        public async Task UpdateProduct(ProductDTO productDTO, IEnumerable<ProductImageDTO> productImageDTOs)
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
            product.Amount = productDTO.Amount;
            product.Price = productDTO.Price;
            product.Delete = 0;

            await _productRepository.UpdateProduct(product);

        }

        public async Task<bool> DeactivateProduct(int id)
        {
            var product =  await _productRepository.GetProductById(id);

            if (product != null)
            {
                product.Delete = 1;
                await _productRepository.DeactivateProduct(product);
                return true;
            }
            throw new eCommerceException("Product Not Found", HttpStatusCode.NotFound);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsByName(string name)
        {
            var products = await _productRepository.GetProductsByName(name);

            if (products is null) throw new eCommerceException("No results for " + name, HttpStatusCode.NotFound);

            return _mapper.Map<IEnumerable<ProductDTO>>(products);

        }
    }
}
