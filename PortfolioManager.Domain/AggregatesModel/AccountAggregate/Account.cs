using System;
using System.Collections.Generic;
using System.Text;
using PortfolioManager.Domain.SeedWork;

namespace PortfolioManager.Domain.AggregatesModel.AccountAggregate
{
    public class Account : Entity, IAggregateRoot
    {
        public string Name { get; private set; }

        public string Email { get; private set; }

        private readonly List<Transaction> _transactions;
        public IReadOnlyCollection<Transaction> Transactions => _transactions;

        private readonly List<StockHolding> _stockHoldings;
        public IReadOnlyCollection<StockHolding> StockHoldings => _stockHoldings;

        public Account()
        {
            _transactions = new List<Transaction>();
            _stockHoldings = new List<StockHolding>();
        }

        public Account(string name, string email) : this()
        {
            Name = name;
            Email = email;
        }

        public void AddTransaction(string symbol, int units, decimal price, TransactionType type)
        {
            var transaction = new Transaction(Id, symbol, units, price, type);
            _transactions.Add(transaction);
        }

        //TODO: move this to event handler
        public void AddStockHolding(int stockId, int units, decimal boughtPrice, decimal commission,
            DateTime boughtDateTime)
        {
            var stockHoding = new StockHolding(Id, stockId, units, boughtPrice, commission, boughtDateTime);
            _stockHoldings.Add(stockHoding);
        }
    }
}