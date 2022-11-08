using AutoMapper;
using eCommerce.Domain.Interfaces;
using eCommerce.Domain.Models;
using eCommerce.Infrastructure.DTOs;
using eCommerce.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Services
{
    public class OrderProductService : IOrderProductService
    {
        private IOrderProductRepository _orderProductRepository;
        private readonly IMapper _mapper;

        public OrderProductService(IMapper mapper, IOrderProductRepository orderProductRepository)
        {
            _orderProductRepository = orderProductRepository;
            _mapper = mapper;
        }

        public void AddOrderProduct(OrderProductDTO orderProductDTO)
        {
            var orderProduct = _mapper.Map<OrderProduct>(orderProductDTO);
            _orderProductRepository.AddOrderProduct(orderProduct);
        }

        public async Task<IEnumerable<OrderProductDTO>> GetOrderProducts()
        {
            var result = await _orderProductRepository.GetOrderProducts();
            return _mapper.Map<IEnumerable<OrderProductDTO>>(result);
        }

        public async Task<OrderProductDTO> GetOrderProductById(int? id)
        {
            var result = await _orderProductRepository.GetOrderProductById(id);
            return _mapper.Map<OrderProductDTO>(result);
        }

        public void UpdateOrderProduct(OrderProductDTO orderProductDTO)
        {
            var orderProduct = _mapper.Map<OrderProduct>(orderProductDTO);
            _orderProductRepository.UpdateOrderProduct(orderProduct);
        }

        public void RemoveOrderProduct(int? id)
        {
            var orderProduct = _orderProductRepository.GetOrderProductById(id).Result;
            _orderProductRepository.RemoveOrderProduct(orderProduct);
        }
    }
}
