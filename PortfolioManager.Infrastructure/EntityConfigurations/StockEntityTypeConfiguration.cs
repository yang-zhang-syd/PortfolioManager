using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioManager.Domain.AggregatesModel.StockAggregate;

namespace PortfolioManager.Infrastructure.EntityConfigurations
{
    class StockEntityTypeConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable("stocks", PortfolioManagerDbContext.DEFAULT_SCHEMA);

            builder.HasKey(t => t.Id);

            builder.Ignore(t => t.DomainEvents);

            builder.Property(o => o.Id).ForSqlServerUseSequenceHiLo("stockseq");

            builder.Property<string>("Symbol").IsRequired();
        }
    }
}
