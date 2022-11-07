using eCommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Interfaces
{
    public interface ICreditCardRepository
    {
        Task<IEnumerable<CreditCard>> GetCreditCards();

        Task<CreditCard> GetCreditCardById(int? id);

        void AddCreditCard(CreditCard creditCard);

        void UpdateCreditCard(CreditCard creditCard);

        void RemoveCreditCard(CreditCard creditCard);
    }
}
