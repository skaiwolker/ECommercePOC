using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using eCommerce.Domain.DTOs;
using System.Collections.Generic;
using eCommerce.Services.Services.Interfaces;
using eCommerce.Services.Exceptions;

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
            var result = await _clientService.GetClients();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDTO>> GetClientById(int id)
        {
            var client = await _clientService.GetClientById(id);

            if (client == null) return NotFound();

            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult<ClientDTO>> AddClient([FromBody] ClientDTO clientDTO)
        {
            try
            {
                await _clientService.AddClient(clientDTO);
                return Ok(clientDTO);
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
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
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
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
