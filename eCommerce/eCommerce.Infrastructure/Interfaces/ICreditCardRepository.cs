using eCommerce.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Interfaces
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
