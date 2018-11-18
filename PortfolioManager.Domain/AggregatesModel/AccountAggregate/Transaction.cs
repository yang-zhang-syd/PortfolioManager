using System;
using System.Collections.Generic;
using System.Text;
using PortfolioManager.Domain.SeedWork;

namespace PortfolioManager.Domain.AggregatesModel.AccountAggregate
{
    public class Transaction : Entity
    {
        public string Symbol { get; private set; }

        public int Units { get; private set; }

        public decimal Price { get; private set; }

        public TransactionType TransactionType { get; private set; }
        private int _transactionTypeId;

        public int AccountId { get; private set; }

        protected Transaction() { }

        public Transaction(int accountId, string symbol, int units, decimal price, TransactionType transactionType)
        {
            AccountId = accountId;
            Symbol = symbol;
            Units = units;
            Price = price;
            _transactionTypeId = transactionType.Id;
        }
    }
}
