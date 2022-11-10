using AutoMapper;
using eCommerce.Domain.DTOs;
using eCommerce.Domain.Models;
using eCommerce.Infrastructure.Interfaces;
using eCommerce.Services.Interfaces;
using System;
using System.Collections.Generic;
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
            return _mapper.Map<CreditCardDTO>(result);
        }

        public async Task UpdateCreditCard(CreditCardDTO creditCardDTO)
        {
            var creditCard = _mapper.Map<CreditCard>(creditCardDTO);
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
            throw new Exception("Invalid Credit Card Id");
        }
    }
}
