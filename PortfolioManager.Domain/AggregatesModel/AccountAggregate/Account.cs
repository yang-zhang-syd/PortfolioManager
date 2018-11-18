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

        public Account()
        {
            _transactions = new List<Transaction>();
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
    }
}