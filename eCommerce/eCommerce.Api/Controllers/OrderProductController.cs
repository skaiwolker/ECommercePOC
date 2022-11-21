using eCommerce.Domain.DTOs;
using eCommerce.Services.Exceptions;
using eCommerce.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
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
            try
            {
                var result = await _orderProductService.GetOrderProducts();
                return Ok(result);
            }
            catch (eCommerceException ex)
            {
                return StatusCode(Convert.ToInt32(ex.StatusCode), new
                {
                    eCommerceEx = ex.Message
                });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    exception = e.Message
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderProductDTO>> GetOrderProductById(int id)
        {
            try
            {
                var orderProduct = await _orderProductService.GetOrderProductById(id);
                return Ok(orderProduct);
            }
            catch (eCommerceException ex)
            {
                return StatusCode(Convert.ToInt32(ex.StatusCode), new
                {
                    eCommerceEx = ex.Message
                });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    exception = e.Message
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult<OrderProductDTO>> AddOrderProduct([FromBody] OrderProductDTO orderProductDTO)
        {
            try
            {
                await _orderProductService.AddOrderProduct(orderProductDTO);
                return Ok(orderProductDTO);
            }
            catch (eCommerceException ex)
            {
                return StatusCode(Convert.ToInt32(ex.StatusCode), new
                {
                    eCommerceEx = ex.Message
                });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    exception = e.Message
                });
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
            catch (eCommerceException ex)
            {
                return StatusCode(Convert.ToInt32(ex.StatusCode), new
                {
                    eCommerceEx = ex.Message
                });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    exception = e.Message
                });
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
            catch (eCommerceException ex)
            {
                return StatusCode(Convert.ToInt32(ex.StatusCode), new
                {
                    eCommerceEx = ex.Message
                });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    exception = e.Message
                });
            }

        }
    }
}
