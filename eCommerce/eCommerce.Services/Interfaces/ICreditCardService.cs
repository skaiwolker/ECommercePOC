using eCommerce.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Services.Interfaces
{
    public interface ICreditCardService
    {
        Task<IEnumerable<CreditCardDTO>> GetCreditCards();

        Task<CreditCardDTO> GetCreditCardById(int? id);

        void AddCreditCard(CreditCardDTO creditCard);

        void UpdateCreditCard(CreditCardDTO creditCard);

        void RemoveCreditCard(int? id);
    }
}
