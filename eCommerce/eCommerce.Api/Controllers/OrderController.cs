using eCommerce.Domain.DTOs;
using eCommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<IActionResult> GetOrders()
        {
            var result = await _orderService.GetOrders();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderById(id);

            if (order == null) return NotFound();

            return Ok(order);
        }

        [HttpPost]
        public IActionResult AddOrder([FromBody] OrderDTO orderDTO)
        {
            try
            {
                _orderService.AddOrder(orderDTO);
                return Ok(orderDTO);
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateOrder([FromBody] OrderDTO orderDTO)
        {
            try
            {
                _orderService.UpdateOrder(orderDTO);
                return Ok(orderDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveOrder(int id)
        {
            try
            {
                _orderService.RemoveOrder(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }
    }
}
