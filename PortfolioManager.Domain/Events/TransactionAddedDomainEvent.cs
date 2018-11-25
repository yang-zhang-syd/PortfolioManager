using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PortfolioManager.Domain.AggregatesModel.AccountAggregate;

namespace PortfolioManager.Domain.Events
{
    public class TransactionAddedDomainEvent : INotification
    {
        public Transaction Transaction { get; }

        public TransactionAddedDomainEvent(Transaction transaction)
        {
            Transaction = transaction;
        }
    }
}
