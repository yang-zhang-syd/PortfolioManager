using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PortfolioManager.Domain.AggregatesModel.AccountAggregate;
using PortfolioManager.Domain.AggregatesModel.StockAggregate;
using PortfolioManager.Domain.Events;

namespace PortfolioManager.API.Application.DomainEventHandlers.TransactionAdded
{
    public class CreateStockWhenTransactionAddedDomainEventHandler
        : INotificationHandler<TransactionAddedDomainEvent>
    {
        private readonly IStockRepository _stockRepository;
        private readonly IAccountRepository _accountRepository;

        public CreateStockWhenTransactionAddedDomainEventHandler(IStockRepository stockRepository, IAccountRepository accountRepository)
        {
            _stockRepository = stockRepository;
            _accountRepository = accountRepository;
        }

        public async Task Handle(TransactionAddedDomainEvent transactionAddedEvent, CancellationToken cancellationToken)
        {

            var transaction = transactionAddedEvent.Transaction;
            _accountRepository.AddStockHolding(new StockHolding(transaction.AccountId, transaction.Stock.Id,
                transaction.Units, transaction.Price, transaction.Commission, transaction.DateTime));
        }
    }
}
