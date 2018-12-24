using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioManager.Domain.AggregatesModel.StockAggregate;

namespace PortfolioManager.Infrastructure.EntityConfigurations
{
    class StockPriceEntityTypeConfiguration : IEntityTypeConfiguration<StockPrice>
    {
        public void Configure(EntityTypeBuilder<StockPrice> builder)
        {
            builder.ToTable("stockprices", PortfolioManagerDbContext.DEFAULT_SCHEMA);

            builder.HasKey(s => s.Id);

            builder.Ignore(t => t.DomainEvents);

            builder.Property(o => o.Id)
                .ForSqlServerUseSequenceHiLo("stockpriceseq");

            builder.Property<decimal>("Price").IsRequired();
            builder.Property<DateTime>("DateTime").IsRequired();
        }
    }
}
