using AutoMapper;
using eCommerce.Domain.DTOs;
using eCommerce.Domain.Enums;
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
            if (orderDTO.Status <= 0)
            {
                throw new eCommerceException("Status cannot be less or equal 0", HttpStatusCode.BadRequest);
            }

            var order = _mapper.Map<Order>(orderDTO);

            order.Delete = 0;

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

            if (result == null)
            {
                throw new eCommerceException("Order Not Found", HttpStatusCode.NotFound);
            }

            return _mapper.Map<OrderDTO>(result);
        }

        public async Task UpdateOrder(OrderDTO orderDTO)
        {
            if (orderDTO.Status <= 0)
            {
                throw new eCommerceException("Status cannot be less or equal 0", HttpStatusCode.BadRequest);
            }

            orderDTO.Delete = 0;

            var order = await _orderRepository.GetOrderById(orderDTO.Id);

            if (order == null)
            {
                throw new eCommerceException("Order Not Found", HttpStatusCode.NotFound);
            }

            order.Status = orderDTO.Status;
            order.Delete = 0;

            await _orderRepository.UpdateOrder(order);
        }

        public async Task<bool> DeactivateOrder(int id)
        {
            var order = _orderRepository.GetOrderById(id).Result;

            if (order != null)
            {
                order.Delete = 1;
                order.Status = (int)OrderEnum.Status.Cancelled;
                await _orderRepository.DeactivateOrder(order);
                return true;
            }
            throw new eCommerceException("Order Not Found", HttpStatusCode.NotFound);
        }
    }
}
