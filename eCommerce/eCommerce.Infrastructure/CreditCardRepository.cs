using Dapper;
using eCommerce.Domain.Models;
using eCommerce.Repository.Context;
using eCommerce.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace eCommerce.Repository
{
    public class CreditCardRepository : ICreditCardRepository
    {
        private eCommerceContext _context;
        private readonly IDbConnection _connection;

        public CreditCardRepository(eCommerceContext context, IConfiguration configuration)
        {
            _context = context;
            _connection = _connection.AddConnection(configuration);
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
            _context.Update(creditCard);
            await _context.SaveChangesAsync();
        }
    }
}
