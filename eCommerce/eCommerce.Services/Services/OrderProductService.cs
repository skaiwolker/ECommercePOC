using AutoMapper;
using eCommerce.Domain.DTOs;
using eCommerce.Domain.Models;
using eCommerce.Infrastructure.Repository.Interfaces;
using eCommerce.Services.Exceptions;
using eCommerce.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace eCommerce.Services.Services
{
    public class OrderProductService : IOrderProductService
    {
        private IOrderProductRepository _orderProductRepository;
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public OrderProductService(IMapper mapper, IOrderProductRepository orderProductRepository, IProductRepository productRepository)
        {
            _orderProductRepository = orderProductRepository;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task AddOrderProduct(OrderProductDTO orderProductDTO)
        {
            if (orderProductDTO.Amount <= 0)
            {
                throw new eCommerceException("Amount cannot be less or equal 0", HttpStatusCode.BadRequest);
            }

            var orderProduct = _mapper.Map<OrderProduct>(orderProductDTO);

            var product = await _productRepository.GetProductById(orderProductDTO.ProductId);
            product.Amount -= orderProductDTO.Amount;

            if (product.Amount < 0)
            {
                throw new eCommerceException("Not enough products", HttpStatusCode.BadRequest);
            }

            await _orderProductRepository.AddOrderProduct(orderProduct);
            await _productRepository.UpdateProduct(product);
        }

        public async Task<IEnumerable<OrderProductDTO>> GetOrderProducts()
        {
            var result = await _orderProductRepository.GetOrderProducts();
            return _mapper.Map<IEnumerable<OrderProductDTO>>(result);
        }

        public async Task<OrderProductDTO> GetOrderProductById(int id)
        {
            var result = await _orderProductRepository.GetOrderProductById(id);

            if (result == null)
            {
                throw new eCommerceException("OrderProduct Not Found", HttpStatusCode.NotFound);
            }

            return _mapper.Map<OrderProductDTO>(result);
        }

        public async Task UpdateOrderProduct(OrderProductDTO orderProductDTO)
        {
            if (orderProductDTO.Amount <= 0)
            {
                throw new eCommerceException("Amount cannot be less or equal 0", HttpStatusCode.BadRequest);
            }

            var oldOrderProduct = await _orderProductRepository.GetOrderProductById(orderProductDTO.Id);

            if (oldOrderProduct == null)
            {
                throw new eCommerceException("OrderProduct Not Found", HttpStatusCode.NotFound);
            }

            var amountDifferece = oldOrderProduct.Amount - orderProductDTO.Amount;

            oldOrderProduct.Product.Amount += amountDifferece;
            oldOrderProduct.Amount = orderProductDTO.Amount;

            if (oldOrderProduct.Product.Amount < 0)
            {
                throw new eCommerceException("Not enough products", HttpStatusCode.BadRequest);
            }

            await _orderProductRepository.UpdateOrderProduct(oldOrderProduct);
            await _productRepository.UpdateProduct(oldOrderProduct.Product);
        }

        public async Task<bool> RemoveOrderProduct(int id)
        {
            var orderProduct = _orderProductRepository.GetOrderProductById(id).Result;

            if (orderProduct != null)
            {
                await _orderProductRepository.RemoveOrderProduct(orderProduct);
                return true;
            }
            throw new eCommerceException("OrderProduct Not Found", HttpStatusCode.NotFound);
        }
    }
}
