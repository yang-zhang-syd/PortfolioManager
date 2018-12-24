using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioManager.Domain.AggregatesModel.AccountAggregate;

namespace PortfolioManager.Infrastructure.EntityConfigurations
{
    class TransactionTypeEntityTypeConfiguration : IEntityTypeConfiguration<TransactionType>
    {
        public void Configure(EntityTypeBuilder<TransactionType> builder)
        {
            builder.ToTable("transactiontype", PortfolioManagerDbContext.DEFAULT_SCHEMA);

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(t => t.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
