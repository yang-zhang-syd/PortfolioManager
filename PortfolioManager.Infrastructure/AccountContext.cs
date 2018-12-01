using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PortfolioManager.Domain.AggregatesModel.AccountAggregate;
using PortfolioManager.Domain.AggregatesModel.StockAggregate;
using PortfolioManager.Domain.SeedWork;
using PortfolioManager.Infrastructure.EntityConfigurations;

namespace PortfolioManager.Infrastructure
{
    public class AccountContext: DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "portfoliomanager";
        private readonly IMediator _mediator;

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<StockHolding> StockHoldings { get; set; }
        public DbSet<TransactionType> TransactionType { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockPrice> StockPrices { get; set; }

        public AccountContext(DbContextOptions<AccountContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AccountStatusTypeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionTypeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StockEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StockPriceEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StockHoldingEntityTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await _mediator.DispatchDomainEventsAsync(this);
            var result = await base.SaveChangesAsync();

            return true;
        }
    }
}
