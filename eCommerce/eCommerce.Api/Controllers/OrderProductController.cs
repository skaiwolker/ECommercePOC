using eCommerce.Domain.DTOs;
using eCommerce.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderProductController : Controller
    {
        private readonly IOrderProductService _orderProductService;

        public OrderProductController(IOrderProductService orderProductService)
        {
            _orderProductService = orderProductService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderProductDTO>>> GetOrderProducts()
        {
            var result = await _orderProductService.GetOrderProducts();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderProductDTO>> GetOrderProductById(int id)
        {
            var orderProduct = await _orderProductService.GetOrderProductById(id);

            if (orderProduct == null) return NotFound();

            return Ok(orderProduct);
        }

        [HttpPost]
        public async Task<ActionResult<OrderProductDTO>> AddOrderProduct([FromBody] OrderProductDTO orderProductDTO)
        {
            try
            {
                await _orderProductService.AddOrderProduct(orderProductDTO);
                return Ok(orderProductDTO);
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<OrderProductDTO>> UpdateOrderProduct([FromBody] OrderProductDTO orderProductDTO)
        {
            try
            {
                 await _orderProductService.UpdateOrderProduct(orderProductDTO);
                return Ok(orderProductDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> RemoveorderProduct(int id)
        {
            try
            {
                bool result = await _orderProductService.RemoveOrderProduct(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }
    }
}
