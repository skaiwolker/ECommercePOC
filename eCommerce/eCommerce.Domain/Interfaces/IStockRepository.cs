using eCommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Interfaces
{
    public interface IStockRepository
    {
        Task<IEnumerable<Stock>> GetStocks();

        Task<Stock> GetStockById(int? id);

        void AddStock(Stock stock);

        void UpdateStock(Stock stock);

        void RemoveStock(Stock stock);
    }
}
