using System;
using System.Collections.Generic;
using System.Text;
using PortfolioManager.Domain.SeedWork;

namespace PortfolioManager.Domain.AggregatesModel.StockAggregate
{
    public class Stock : Entity, IAggregateRoot
    {
        private readonly List<StockPrice> _equityPrices;
        public IReadOnlyCollection<StockPrice> EquityPrices => _equityPrices;

        protected Stock()
        {
            _equityPrices = new List<StockPrice>();
        }

        public Stock(string symbol) : this()
        {
            Symbol = symbol;
        }

        public string Symbol { get; private set; }

        public void AddStockPrice(decimal price, DateTime dateTime)
        {
            var equityPrice = new StockPrice(Id, price, dateTime);
            _equityPrices.Add(equityPrice);
        }
    }
}
