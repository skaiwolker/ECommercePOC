using eCommerce.Domain.DTOs;
using eCommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace eCommerce.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreditCardController : Controller
    {
        private readonly ICreditCardService _creditCardService;

        public CreditCardController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCreditCards()
        {
            var result = await _creditCardService.GetCreditCards();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCreditCardById(int id)
        {
            var creditCard = await _creditCardService.GetCreditCardById(id);

            if (creditCard == null) return NotFound();

            return Ok(creditCard);
        }

        [HttpPost]
        public IActionResult AddCreditCard([FromBody] CreditCardDTO creditCardDTO)
        {
            try
            {
                _creditCardService.AddCreditCard(creditCardDTO);
                return Ok(creditCardDTO);
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateCreditCard([FromBody] CreditCardDTO creditCardDTO)
        {
            try
            {
                _creditCardService.UpdateCreditCard(creditCardDTO);
                return Ok(creditCardDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveCreditCard(int id)
        {
            try
            {
                _creditCardService.RemoveCreditCard(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }
    }
}
