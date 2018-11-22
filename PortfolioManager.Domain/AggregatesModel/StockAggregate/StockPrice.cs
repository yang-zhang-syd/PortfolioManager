using System;
using System.Collections.Generic;
using System.Text;
using PortfolioManager.Domain.SeedWork;

namespace PortfolioManager.Domain.AggregatesModel.StockAggregate
{
    public class StockPrice : Entity
    {
        protected StockPrice() { }

        public StockPrice(int stockId, decimal price, DateTime dateTime)
        {
            StockId = stockId;
            Price = price;
            DateTime = dateTime;
        }

        public int StockId { get; private set; }

        public decimal Price { get; private set; }

        public DateTime DateTime { get; private set; }
    }
}
