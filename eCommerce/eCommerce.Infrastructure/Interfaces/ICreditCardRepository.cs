using eCommerce.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Repository.Interfaces
{
    public interface ICreditCardRepository
    {
        Task<IEnumerable<CreditCard>> GetCreditCards();

        Task<CreditCard> GetCreditCardById(int id);

        Task AddCreditCard(CreditCard creditCard);

        Task UpdateCreditCard(CreditCard creditCard);

        Task RemoveCreditCard(CreditCard creditCard);
    }
}
