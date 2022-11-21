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
            try
            {
                var result = await _creditCardService.GetCreditCards();
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
        public async Task<ActionResult<CreditCardDTO>> GetCreditCardById(int id)
        {
            try
            {
                var creditCard = await _creditCardService.GetCreditCardById(id);
                return Ok(creditCard);
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
        public async Task<ActionResult<CreditCardDTO>> AddCreditCard([FromBody] CreditCardDTO creditCardDTO)
        {
            try
            {
                await _creditCardService.AddCreditCard(creditCardDTO);
                return Ok(creditCardDTO);
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
        public async Task<ActionResult<CreditCardDTO>> UpdateCreditCard([FromBody] CreditCardDTO creditCardDTO)
        {
            try
            {
                await _creditCardService.UpdateCreditCard(creditCardDTO);
                return Ok(creditCardDTO);
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
        public async Task<ActionResult<bool>> RemoveCreditCard(int id)
        {
            try
            {
                bool result = await _creditCardService.RemoveCreditCard(id);
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
