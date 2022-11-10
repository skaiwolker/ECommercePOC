using eCommerce.Domain.DTOs;
using eCommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public async Task<ActionResult<List<CreditCardDTO>>> GetCreditCards()
        {
            var result = await _creditCardService.GetCreditCards();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CreditCardDTO>> GetCreditCardById(int id)
        {
            var creditCard = await _creditCardService.GetCreditCardById(id);

            if (creditCard == null) return NotFound();

            return Ok(creditCard);
        }

        [HttpPost]
        public async Task<ActionResult<CreditCardDTO>> AddCreditCard([FromBody] CreditCardDTO creditCardDTO)
        {
            try
            {
                await _creditCardService.AddCreditCard(creditCardDTO);
                return Ok(creditCardDTO);
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<CreditCardDTO>> UpdateCreditCard([FromBody] CreditCardDTO creditCardDTO)
        {
            try
            {
                await _creditCardService.UpdateCreditCard(creditCardDTO);
                return Ok(creditCardDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> RemoveCreditCard(int id)
        {
            try
            {
                bool result = await _creditCardService.RemoveCreditCard(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }
    }
}
