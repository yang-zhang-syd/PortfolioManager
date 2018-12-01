using System;
using System.Collections.Generic;
using System.Text;
using PortfolioManager.Domain.Events;
using PortfolioManager.Domain.SeedWork;

namespace PortfolioManager.Domain.AggregatesModel.AccountAggregate
{
    public class Account : Entity, IAggregateRoot
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public AccountStatus Status { get; set; }
        private int _statusId;

        private readonly List<Transaction> _transactions;
        public IReadOnlyCollection<Transaction> Transactions => _transactions;

        private readonly List<StockHolding> _stockHoldings;
        public IReadOnlyCollection<StockHolding> StockHoldings => _stockHoldings;

        public Account()
        {
            _transactions = new List<Transaction>();
            _stockHoldings = new List<StockHolding>();
        }

        public Account(string name, string email, AccountStatus status) : this()
        {
            Name = name;
            Email = email;
            _statusId = status.Id;
        }

        public void AddTransaction(int stockId, int units, decimal price, TransactionType type, decimal commission, DateTime dateTime)
        {
            var transaction = new Transaction(Id, stockId, units, price, type, commission, dateTime);
            _transactions.Add(transaction);

            AddDomainEvent(new TransactionAddedDomainEvent(transaction));
        }

        public void SetStatus(AccountStatus status)
        {
            this._statusId = status.Id;
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