using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using eCommerce.Services.Interfaces;
using eCommerce.Domain.DTOs;
using System.Collections.Generic;

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
        public async Task<ActionResult<List<AddressDTO>>> GetAddresses()
        {
            var result = await _addressService.GetAddresses();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AddressDTO>> GetAddressById(int id)
        {
            var address = await _addressService.GetAddressById(id);

            if (address == null) return NotFound();

            return Ok(address);
        }

        [HttpPost]
        public async Task<ActionResult<AddressDTO>> AddAddress([FromBody] AddressDTO addressDTO)
        {
            try
            {
                await _addressService.AddAddress(addressDTO);
                return Ok(addressDTO);
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<AddressDTO>> UpdateAddress([FromBody] AddressDTO addressDTO)
        {
            try
            {
                await _addressService.UpdateAddress(addressDTO);
                return Ok(addressDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> RemoveAddress(int id)
        {
            try
            {
                bool result = await _addressService.RemoveAddress(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }
    }
}
