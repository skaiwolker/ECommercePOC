using Dapper;
using eCommerce.Domain.Models;
using eCommerce.Infrastructure.Context;
using eCommerce.Infrastructure.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Repository
{
    public class CreditCardRepository : ICreditCardRepository
    {
        private eCommerceContext _context;
        private IDbConnection _connection;

        public CreditCardRepository(eCommerceContext context)
        {
            _context = context;
            _connection = new SqlConnection(@"Data Source=DARTAGNAN\SQLEXPRESS;Initial Catalog=eCommerceDb;Integrated Security=True");
        }

        public async Task<IEnumerable<CreditCard>> GetCreditCards()
        {
            //return await _context.CreditCards.ToListAsync();
            return await _connection.QueryAsync<CreditCard>("SELECT * FROM CreditCards");
        }

        public async Task<CreditCard> GetCreditCardById(int id)
        {
            //return await _context.CreditCards.FirstOrDefaultAsync(creditCard => creditCard.Id == id);
            var param = new { Id = id };
            return await _connection.QueryFirstOrDefaultAsync<CreditCard>("SELECT * FROM CreditCards WHERE Id = @Id", param);
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
