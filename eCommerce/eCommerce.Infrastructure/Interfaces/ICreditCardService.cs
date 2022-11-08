using eCommerce.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Interfaces
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
