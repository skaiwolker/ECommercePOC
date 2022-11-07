using eCommerce.Domain.Interfaces;
using eCommerce.Domain.Models;
using eCommerce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Repository
{
    public class StockRepository : IStockRepository
    {
        private eCommerceContext _context;

        public StockRepository(eCommerceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Stock>> GetStocks()
        {
            return await _context.Stocks.ToListAsync();
        }

        public async Task<Stock> GetStockById(int? id)
        {
            return await _context.Stocks.FindAsync(id);
        }

        public void AddStock(Stock stock)
        {
            _context.Add(stock);
            _context.SaveChanges();
        }

        public void UpdateStock(Stock stock)
        {
            _context.Update(stock);
            _context.SaveChanges();
        }

        public void RemoveStock(Stock stock)
        {
            _context.Remove(stock);
            _context.SaveChanges();
        }
    }
}
