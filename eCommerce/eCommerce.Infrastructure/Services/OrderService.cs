using AutoMapper;
using eCommerce.Domain.Interfaces;
using eCommerce.Domain.Models;
using eCommerce.Infrastructure.DTOs;
using eCommerce.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Services
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

        public void AddOrder(OrderDTO orderDTO)
        {
            var order = _mapper.Map<Order>(orderDTO);
            _orderRepository.AddOrder(order);
        }

        public async Task<IEnumerable<OrderDTO>> GetOrders()
        {
            var result = await _orderRepository.GetOrders();
            return _mapper.Map<IEnumerable<OrderDTO>>(result);
        }

        public async Task<OrderDTO> GetOrderById(int? id)
        {
            var result = await _orderRepository.GetOrderById(id);
            return _mapper.Map<OrderDTO>(result);
        }

        public void UpdateOrder(OrderDTO orderDTO)
        {
            var order = _mapper.Map<Order>(orderDTO);
            _orderRepository.UpdateOrder(order);
        }

        public void RemoveOrder(int? id)
        {
            var order = _orderRepository.GetOrderById(id).Result;
            _orderRepository.RemoveOrder(order);
        }
    }
}
