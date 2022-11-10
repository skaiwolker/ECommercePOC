using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using eCommerce.Services.Interfaces;
using eCommerce.Domain.DTOs;

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
        public async Task<IActionResult> GetClients()
        {
            var result = await _clientService.GetClients();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientById(int id)
        {
            var client = await _clientService.GetClientById(id);

            if (client == null) return NotFound();

            return Ok(client);
        }

        [HttpPost]
        public IActionResult AddClient([FromBody] ClientDTO clientDTO)
        {
            try
            {
                _clientService.AddClient(clientDTO);
                return Ok(clientDTO);
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateClient([FromBody] ClientDTO clientDTO)
        {
            try
            {
                _clientService.UpdateClient(clientDTO);
                return Ok(clientDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveClient(int id)
        {
            try
            {
                _clientService.RemoveClient(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }
    }
}
