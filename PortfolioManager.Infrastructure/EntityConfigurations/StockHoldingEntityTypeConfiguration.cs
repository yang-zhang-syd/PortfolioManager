using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioManager.Domain.AggregatesModel.AccountAggregate;
using PortfolioManager.Domain.AggregatesModel.StockAggregate;

namespace PortfolioManager.Infrastructure.EntityConfigurations
{
    class StockHoldingEntityTypeConfiguration : IEntityTypeConfiguration<StockHolding>
    {
        public void Configure(EntityTypeBuilder<StockHolding> builder)
        {
            builder.ToTable("stockholdings", AccountContext.DEFAULT_SCHEMA);

            builder.HasKey(s => s.Id);

            builder.Ignore(s => s.DomainEvents);

            builder.Property(s => s.Id).ForSqlServerUseSequenceHiLo("stockholdingseq");

            builder.Property("StockId").IsRequired();
            builder.Property("AccountId").IsRequired();
            builder.Property("Units").IsRequired();
            builder.Property("BoughtPrice").IsRequired();
            builder.Property("Commission").IsRequired();
            builder.Property("BoughtDateTime").IsRequired();

            builder.HasOne<Stock>()
                .WithMany()
                .HasForeignKey("StockId")
                .IsRequired();
        }
    }
}
