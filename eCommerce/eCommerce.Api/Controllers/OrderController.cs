using eCommerce.Domain.DTOs;
using eCommerce.Services.Exceptions;
using eCommerce.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDTO>>> GetOrders()
        {
            var result = await _orderService.GetOrders();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderById(id);

            if (order == null) return NotFound();

            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<OrderDTO>> AddOrder([FromBody] OrderDTO orderDTO)
        {
            try
            {
                await _orderService.AddOrder(orderDTO);
                return Ok(orderDTO);
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<OrderDTO>> UpdateOrder([FromBody] OrderDTO orderDTO)
        {
            try
            {
                await _orderService.UpdateOrder(orderDTO);
                return Ok(orderDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> RemoveOrder(int id)
        {
            try
            {
                bool result = await _orderService.RemoveOrder(id);
                return Ok(result);
            }
            catch (IdNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }
    }
}
