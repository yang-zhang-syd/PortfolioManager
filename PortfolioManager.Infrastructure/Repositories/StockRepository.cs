using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortfolioManager.Domain.AggregatesModel.StockAggregate;
using PortfolioManager.Domain.SeedWork;

namespace PortfolioManager.Infrastructure.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly AccountContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public StockRepository(AccountContext context)
        {
            _context = context;
        }

        public Stock Add(Stock stock)
        {
            return _context.Stocks.Add(stock).Entity;
        }

        public async Task<Stock> GetAsync(int id)
        {
            var stock = await _context.Stocks
                .Include(s => s.StockPrices)
                .Where(s => s.Id == id)
                .SingleOrDefaultAsync();

            return stock;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var stock = await _context.Stocks.SingleOrDefaultAsync(s => s.Id == id);
            if (stock == null)
            {
                return false;
            }

            _context.Stocks.Remove(stock);
            return true;
        }

        public async Task<bool> UpdateAsync(Stock stock)
        {
            var stockToUpdate = await _context.Stocks.SingleOrDefaultAsync(s => s.Id == stock.Id);
            if (stockToUpdate == null)
            {
                return false;
            }

            stockToUpdate.Symbol = stock.Symbol;

            return true;
        }

        public async Task<Stock> FindAsync(string symbol)
        {
            var stock = await _context.Stocks
                .Include(s => s.StockPrices)
                .Where(s => s.Symbol == symbol)
                .SingleOrDefaultAsync();

            return stock;
        }
    }
}
