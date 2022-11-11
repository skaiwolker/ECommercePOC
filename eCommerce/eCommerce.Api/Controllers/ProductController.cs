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
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetProducts()
        {
            var result = await _productService.GetProducts();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);

            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> AddProduct([FromBody] ProductDTO productDTO)
        {
            try
            {
                await _productService.AddProduct(productDTO);
                return Ok(productDTO);
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ProductDTO>> UpdateProduct([FromBody] ProductDTO productDTO)
        {
            try
            {
                await _productService.UpdateProduct(productDTO);
                return Ok(productDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> RemoveProduct(int id)
        {
            try
            {
                bool result = await _productService.RemoveProduct(id);
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
