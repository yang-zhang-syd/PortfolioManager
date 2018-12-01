using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioManager.Domain.AggregatesModel.AccountAggregate;

namespace PortfolioManager.Infrastructure.EntityConfigurations
{
    class AccountEntityTypeConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("accounts", AccountContext.DEFAULT_SCHEMA);

            builder.HasKey(a => a.Id);

            builder.Ignore(a => a.DomainEvents);

            builder.Property(o => o.Id)
                .ForSqlServerUseSequenceHiLo("accountseq", AccountContext.DEFAULT_SCHEMA);

            builder.Property<string>("Name").IsRequired();
            builder.Property<string>("Email").IsRequired();
            builder.Property<int>("StatusId").IsRequired().HasDefaultValue(AccountStatus.Created.Id);

            builder.HasOne(t => t.Status)
                .WithMany()
                .HasForeignKey("StatusId");

            var transactionNavigation = builder.Metadata.FindNavigation(nameof(Account.Transactions));

            // DDD Patterns comment:
            //Set as field (New since EF 1.1) to access the OrderItem collection property through its field
            transactionNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            var holdingNavigation = builder.Metadata.FindNavigation(nameof(Account.StockHoldings));
            holdingNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
