using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PortfolioManager.Domain.AggregatesModel.AccountAggregate;
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
        public DbSet<TransactionType> TransactionType { get; set; }

        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {
            //_mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionTypeEntityTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await base.SaveChangesAsync();

            return true;
        }
    }
}
