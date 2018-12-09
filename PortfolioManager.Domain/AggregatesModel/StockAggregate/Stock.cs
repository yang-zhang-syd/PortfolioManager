using System;
using System.Collections.Generic;
using System.Text;
using PortfolioManager.Domain.SeedWork;

namespace PortfolioManager.Domain.AggregatesModel.StockAggregate
{
    public class Stock : Entity, IAggregateRoot
    {
        private readonly List<StockPrice> _stockPrices;
        public IReadOnlyCollection<StockPrice> StockPrices => _stockPrices;

        protected Stock()
        {
            _stockPrices = new List<StockPrice>();
        }

        public Stock(string symbol) : this()
        {
            Symbol = symbol;
        }

        public string Symbol { get; set; }

        public void AddStockPrice(decimal price, DateTime dateTime)
        {
            var equityPrice = new StockPrice(Id, price, dateTime);
            _stockPrices.Add(equityPrice);
        }
    }
}
