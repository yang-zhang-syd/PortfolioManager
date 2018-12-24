using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioManager.Domain.AggregatesModel.AccountAggregate;

namespace PortfolioManager.Infrastructure.EntityConfigurations
{
    class TransactionEntityTypeConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("transactions", PortfolioManagerDbContext.DEFAULT_SCHEMA);

            builder.HasKey(t => t.Id);

            builder.Ignore(t => t.DomainEvents);

            builder.Property(o => o.Id)
                .ForSqlServerUseSequenceHiLo("transactionseq");
            
            builder.Property<int>("Units").IsRequired();
            builder.Property<decimal>("Price").IsRequired();
            builder.Property<decimal>("Commission").IsRequired();
            builder.Property<int>("TransactionTypeId").IsRequired();
            builder.Property<int>("StockId").IsRequired();
            builder.Property<int>("AccountId").IsRequired();

            builder.HasOne(t => t.TransactionType)
                .WithMany()
                .HasForeignKey("TransactionTypeId");

            builder.HasOne(t => t.Stock)
                .WithMany()
                .HasForeignKey("StockId");
        }
    }
}
