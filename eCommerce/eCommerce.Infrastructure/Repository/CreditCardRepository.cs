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

        public async Task<CreditCard> GetCreditCardById(int id)
        {
            return await _context.CreditCards.FirstOrDefaultAsync(creditCard => creditCard.Id == id);
        }

        public async Task AddCreditCard(CreditCard creditCard)
        {
            await _context.AddAsync(creditCard);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCreditCard(CreditCard creditCard)
        {
            _context.Update(creditCard);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveCreditCard(CreditCard creditCard)
        {
            _context.Remove(creditCard);
            await _context.SaveChangesAsync();
        }
    }
}
