using System;
using System.Collections.Generic;
using System.Text;
using PortfolioManager.Domain.AggregatesModel.StockAggregate;
using PortfolioManager.Domain.SeedWork;

namespace PortfolioManager.Domain.AggregatesModel.AccountAggregate
{
    public class Transaction : Entity
    {
        public Stock Stock { get; private set; }
        private int _stockId;

        public int Units { get; private set; }

        public decimal Price { get; private set; }

        public decimal Commission { get; private set; }

        public DateTime DateTime { get; private set; }

        public TransactionType TransactionType { get; private set; }
        private int _transactionTypeId;

        public int AccountId { get; private set; }

        protected Transaction() { }

        public Transaction(int accountId, int stockId, int units, decimal price, TransactionType transactionType, decimal commission, DateTime dateTime)
        {
            AccountId = accountId;
            Units = units;
            Price = price;
            Commission = commission;
            DateTime = dateTime;
            _stockId = stockId;
            _transactionTypeId = transactionType.Id;
        }
    }
}
