using eCommerce.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Interfaces
{
    public interface IStockService
    {
        Task<IEnumerable<StockDTO>> GetStocks();

        Task<StockDTO> GetStockById(int? id);

        void AddStock(StockDTO stock);

        void UpdateStock(StockDTO stock);

        void RemoveStock(int? id);
    }
}
