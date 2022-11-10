using eCommerce.Domain.Models;
using eCommerce.Infrastructure.Context;
using eCommerce.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Repository
{
    public class CreditCardRepository : ICreditCardRepository
    {
        private eCommerceContext _context;

        public CreditCardRepository(eCommerceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CreditCard>> GetCreditCards()
        {
            return await _context.CreditCards.ToListAsync();
        }

        public async Task<CreditCard> GetCreditCardById(int? id)
        {
            return await _context.CreditCards.FindAsync(id);
        }

        public void AddCreditCard(CreditCard creditCard)
        {
            _context.Add(creditCard);
            _context.SaveChanges();
        }

        public void UpdateCreditCard(CreditCard creditCard)
        {
            _context.Update(creditCard);
            _context.SaveChanges();
        }

        public void RemoveCreditCard(CreditCard creditCard)
        {
            _context.Remove(creditCard);
            _context.SaveChanges();
        }
    }
}
