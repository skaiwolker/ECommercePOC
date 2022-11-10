using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using eCommerce.Services.Interfaces;
using eCommerce.Domain.DTOs;

namespace eCommerce.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAddresses()
        {
            var result = await _addressService.GetAddresses();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            var address = await _addressService.GetAddressById(id);

            if (address == null) return NotFound();

            return Ok(address);
        }

        [HttpPost]
        public IActionResult AddAddress([FromBody] AddressDTO addressDTO)
        {
            try
            {
                _addressService.AddAddress(addressDTO);
                return Ok(addressDTO);
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateAddress([FromBody] AddressDTO addressDTO)
        {
            try
            {
                _addressService.UpdateAddress(addressDTO);
                return Ok(addressDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveAddress(int id)
        {
            try
            {
                _addressService.RemoveAddress(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }
    }
}
