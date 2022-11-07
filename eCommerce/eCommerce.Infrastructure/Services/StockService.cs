using AutoMapper;
using eCommerce.Domain.Interfaces;
using eCommerce.Domain.Models;
using eCommerce.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Services
{
    public class StockService : IStockService
    {
        private IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public StockService(IMapper mapper, IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public void AddStock(StockDTO stockDTO)
        {
            var stock = _mapper.Map<Stock>(stockDTO);
            _stockRepository.AddStock(stock);
        }

        public async Task<IEnumerable<StockDTO>> GetStocks()
        {
            var result = await _stockRepository.GetStocks();
            return _mapper.Map<IEnumerable<StockDTO>>(result);
        }

        public async Task<StockDTO> GetStockById(int? id)
        {
            var result = await _stockRepository.GetStockById(id);
            return _mapper.Map<StockDTO>(result);
        }

        public void UpdateStock(StockDTO stockDTO)
        {
            var stock = _mapper.Map<Stock>(stockDTO);
            _stockRepository.UpdateStock(stock);
        }

        public void RemoveStock(int? id)
        {
            var stock = _stockRepository.GetStockById(id).Result;
            _stockRepository.RemoveStock(stock);
        }
    }
}
