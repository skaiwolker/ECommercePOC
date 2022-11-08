using AutoMapper;
using eCommerce.Domain.Interfaces;
using eCommerce.Domain.Models;
using eCommerce.Infrastructure.DTOs;
using eCommerce.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Services
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

        public void AddCreditCard(CreditCardDTO creditCardDTO)
        {
            var creditCard = _mapper.Map<CreditCard>(creditCardDTO);
            _creditCardRepository.AddCreditCard(creditCard);
        }

        public async Task<IEnumerable<CreditCardDTO>> GetCreditCards()
        {
            var result = await _creditCardRepository.GetCreditCards();
            return _mapper.Map<IEnumerable<CreditCardDTO>>(result);
        }

        public async Task<CreditCardDTO> GetCreditCardById(int? id)
        {
            var result = await _creditCardRepository.GetCreditCardById(id);
            return _mapper.Map<CreditCardDTO>(result);
        }

        public void UpdateCreditCard(CreditCardDTO creditCardDTO)
        {
            var creditCard = _mapper.Map<CreditCard>(creditCardDTO);
            _creditCardRepository.UpdateCreditCard(creditCard);
        }

        public void RemoveCreditCard(int? id)
        {
            var creditCard = _creditCardRepository.GetCreditCardById(id).Result;
            _creditCardRepository.RemoveCreditCard(creditCard);
        }
    }
}
