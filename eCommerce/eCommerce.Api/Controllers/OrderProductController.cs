using eCommerce.Infrastructure.DTOs;
using eCommerce.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<IActionResult> GetOrderProducts()
        {
            var result = await _orderProductService.GetOrderProducts();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderProductById(int id)
        {
            var orderProduct = await _orderProductService.GetOrderProductById(id);

            if (orderProduct == null) return NotFound();

            return Ok(orderProduct);
        }

        [HttpPost]
        public IActionResult AddOrderProduct([FromBody] OrderProductDTO orderProductDTO)
        {
            try
            {
                _orderProductService.AddOrderProduct(orderProductDTO);
                return Ok(orderProductDTO);
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateOrderProduct([FromBody] OrderProductDTO orderProductDTO)
        {
            try
            {
                _orderProductService.UpdateOrderProduct(orderProductDTO);
                return Ok(orderProductDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveorderProduct(int id)
        {
            try
            {
                _orderProductService.RemoveOrderProduct(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }
    }
}
