using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using eCommerce.Domain.DTOs;
using System.Collections.Generic;
using eCommerce.Services.Services.Interfaces;
using eCommerce.Services.Exceptions;
using Microsoft.AspNetCore.Http;

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
            try
            {
                var result = await _addressService.GetAddresses();
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
        public async Task<ActionResult<AddressDTO>> GetAddressById(int id)
        {
            try
            {
                var address = await _addressService.GetAddressById(id);
                return Ok(address);
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
        public async Task<ActionResult<AddressDTO>> AddAddress([FromBody] AddressDTO addressDTO)
        {
            try
            {
                await _addressService.AddAddress(addressDTO);
                return Ok(addressDTO);
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
        public async Task<ActionResult<AddressDTO>> UpdateAddress([FromBody] AddressDTO addressDTO)
        {
            try
            {
                await _addressService.UpdateAddress(addressDTO);
                return Ok(addressDTO);
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
        public async Task<ActionResult<bool>> RemoveAddress(int id)
        {
            try
            {
                bool result = await _addressService.RemoveAddress(id);
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
