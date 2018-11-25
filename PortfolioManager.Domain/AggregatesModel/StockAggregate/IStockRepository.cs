using System.Threading.Tasks;
using PortfolioManager.Domain.SeedWork;

namespace PortfolioManager.Domain.AggregatesModel.StockAggregate
{
    public interface IStockRepository : IRepository<Stock>
    {
        Stock Add(Stock stock);

        Task<Stock> FindAsync(string symbol);

        Task<Stock> GetAsync(int id);
    }
}
