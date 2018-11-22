using System;
using System.Collections.Generic;
using System.Text;
using PortfolioManager.Domain.AggregatesModel.StockAggregate;
using PortfolioManager.Domain.SeedWork;

namespace PortfolioManager.Domain.AggregatesModel.AccountAggregate
{
    public class StockHolding : Entity
    {
        protected StockHolding()
        {
        }

        public StockHolding(int accountId, int stockId, int units, decimal boughtPrice, decimal commission, DateTime dateTime) : this()
        {
            StockId = stockId;
            AccountId = accountId;
            BoughtPrice = boughtPrice;
            Commission = commission;
            Units = units;
            BoughtDateTime = dateTime;
        }

        public int StockId { get; private set; }

        public int AccountId { get; private set; }

        public int Units { get; private set; }

        public decimal BoughtPrice { get; private set; }

        public decimal Commission { get; private set; }

        public DateTime BoughtDateTime { get; private set; }
    }
}
