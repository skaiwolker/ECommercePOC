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
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClientDTO>>> GetClients()
        {
            try
            {
                var result = await _clientService.GetClients();
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
        public async Task<ActionResult<ClientDTO>> GetClientById(int id)
        {
            try
            {
                var client = await _clientService.GetClientById(id);
                return Ok(client);
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
        public async Task<ActionResult<ClientDTO>> AddClient([FromBody] ClientDTO clientDTO)
        {
            try
            {
                await _clientService.AddClient(clientDTO);
                return Ok(clientDTO);
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
        public async Task<ActionResult<ClientDTO>> UpdateClient([FromBody] ClientDTO clientDTO)
        {
            try
            {
                await _clientService.UpdateClient(clientDTO);
                return Ok(clientDTO);
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
        public async Task<ActionResult<bool>> RemoveClient(int id)
        {
            try
            {
                bool result = await _clientService.RemoveClient(id);
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
