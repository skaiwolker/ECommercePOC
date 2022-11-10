using AutoMapper;
using eCommerce.Domain.DTOs;
using eCommerce.Domain.Models;
using eCommerce.Infrastructure.Interfaces;
using eCommerce.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Services.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IMapper mapper, IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task AddOrder(OrderDTO orderDTO)
        {
            var order = _mapper.Map<Order>(orderDTO);
            await _orderRepository.AddOrder(order);
        }

        public async Task<IEnumerable<OrderDTO>> GetOrders()
        {
            var result = await _orderRepository.GetOrders();
            return _mapper.Map<IEnumerable<OrderDTO>>(result);
        }

        public async Task<OrderDTO> GetOrderById(int id)
        {
            var result = await _orderRepository.GetOrderById(id);
            return _mapper.Map<OrderDTO>(result);
        }

        public async Task UpdateOrder(OrderDTO orderDTO)
        {
            var order = _mapper.Map<Order>(orderDTO);
            await _orderRepository.UpdateOrder(order);
        }

        public async Task<bool> RemoveOrder(int id)
        {
            var order = _orderRepository.GetOrderById(id).Result;

            if (order != null) {
                await _orderRepository.RemoveOrder(order);
                return true;
            }
            throw new Exception("Invalid Order Id");
        }
    }
}
