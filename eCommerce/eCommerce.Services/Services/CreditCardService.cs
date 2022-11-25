using AutoMapper;
using eCommerce.Domain.DTOs;
using eCommerce.Domain.Models;
using eCommerce.Repository.Interfaces;
using eCommerce.Services.Exceptions;
using eCommerce.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace eCommerce.Services.Services
{
    public class CreditCardService : ICreditCardService
    {
        private ICreditCardRepository _creditCardRepository;
        private readonly IMapper _mapper;

        public CreditCardService(IMapper mapper, ICreditCardRepository creditCardRepository)
        {
            _creditCardRepository = creditCardRepository;
            _mapper = mapper;
        }

        public async Task AddCreditCard(CreditCardDTO creditCardDTO)
        {
            if (!CreditCardValidation(creditCardDTO.Number))
            {
                throw new eCommerceException("Invalid Credit Card", HttpStatusCode.BadRequest);
            }
            else if (string.IsNullOrEmpty(creditCardDTO.Name))
            {
                creditCardDTO.Name = "Credit Card";
            }
            else if (string.IsNullOrEmpty(creditCardDTO.ExpirationDate))
            {
                throw new eCommerceException("Expiration Date cannot be null or empty", HttpStatusCode.BadRequest);
            }
            else if (string.IsNullOrEmpty(creditCardDTO.SecurityCode))
            {
                throw new eCommerceException("Security Code cannot be null or empty", HttpStatusCode.BadRequest);
            }

            var creditCard = _mapper.Map<CreditCard>(creditCardDTO);
            await _creditCardRepository.AddCreditCard(creditCard);
        }

        public async Task<IEnumerable<CreditCardDTO>> GetCreditCards()
        {
            var result = await _creditCardRepository.GetCreditCards();
            return _mapper.Map<IEnumerable<CreditCardDTO>>(result);
        }

        public async Task<CreditCardDTO> GetCreditCardById(int id)
        {
            var result = await _creditCardRepository.GetCreditCardById(id);

            if (result == null)
            {
                throw new eCommerceException("Credit Card Not Found", HttpStatusCode.NotFound);
            }

            return _mapper.Map<CreditCardDTO>(result);
        }

        public async Task UpdateCreditCard(CreditCardDTO creditCardDTO)
        {
            if (!CreditCardValidation(creditCardDTO.Number))
            {
                throw new eCommerceException("Invalid Credit Card", HttpStatusCode.BadRequest);
            }
            else if (string.IsNullOrEmpty(creditCardDTO.Name))
            {
                creditCardDTO.Name = "Credit Card";
            }
            else if (string.IsNullOrEmpty(creditCardDTO.ExpirationDate))
            {
                throw new eCommerceException("Expiration Date cannot be null or empty", HttpStatusCode.BadRequest);
            }
            else if (string.IsNullOrEmpty(creditCardDTO.SecurityCode))
            {
                throw new eCommerceException("Security Code cannot be null or empty", HttpStatusCode.BadRequest);
            }

            var creditCard = await _creditCardRepository.GetCreditCardById(creditCardDTO.Id);

            if (creditCard == null)
            {
                throw new eCommerceException("Credit Card Not Found", HttpStatusCode.NotFound);
            }

            //creditCard = _mapper.Map<CreditCard>(creditCardDTO);

            creditCard.Name = creditCardDTO.Name;
            creditCard.Number = creditCardDTO.Number;
            creditCard.ExpirationDate = creditCardDTO.ExpirationDate;
            creditCard.SecurityCode = creditCardDTO.SecurityCode;


            await _creditCardRepository.UpdateCreditCard(creditCard);
        }

        public async Task<bool> RemoveCreditCard(int id)
        {
            var creditCard = _creditCardRepository.GetCreditCardById(id).Result;

            if (creditCard != null)
            {
                await _creditCardRepository.RemoveCreditCard(creditCard);
                return true;
            }
            throw new eCommerceException("Credit Card Not Found", HttpStatusCode.NotFound);
        }

        public bool CreditCardValidation(string cNumber)
        { 
            var value = cNumber.Replace(" ", "");
            long sum = 0;
            var shouldDouble = false;
            for (var i = value.Length - 1; i >= 0; i--)
            {
                var digit = Int64.Parse(value[i..]);

                if (shouldDouble)
                {
                    if ((digit *= 2) > 9) digit -= 9;
                }

                sum += digit;
                shouldDouble = !shouldDouble;
            }
            return (sum % 10) == 0;
        }
    }
}
