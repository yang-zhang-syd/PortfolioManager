﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PortfolioManager.Infrastructure;

namespace PortfolioManager.API.Migrations
{
    [DbContext(typeof(PortfolioManagerDbContext))]
    [Migration("20181117221846_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:.transactionseq", "'transactionseq', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:portfoliomanager.accountseq", "'accountseq', 'portfoliomanager', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PortfolioManager.Domain.AggregatesModel.AccountAggregate.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "accountseq")
                        .HasAnnotation("SqlServer:HiLoSequenceSchema", "portfoliomanager")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("accounts","portfoliomanager");
                });

            modelBuilder.Entity("PortfolioManager.Domain.AggregatesModel.AccountAggregate.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "transactionseq")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<int>("AccountId");

                    b.Property<decimal>("Price");

                    b.Property<string>("Symbol")
                        .IsRequired();

                    b.Property<int>("TransactionTypeId");

                    b.Property<int>("Units");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("transactions","portfoliomanager");
                });

            modelBuilder.Entity("PortfolioManager.Domain.AggregatesModel.AccountAggregate.TransactionType", b =>
                {
                    b.Property<int>("Id")
                        .HasDefaultValue(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("transactiontype","portfoliomanager");
                });

            modelBuilder.Entity("PortfolioManager.Domain.AggregatesModel.AccountAggregate.Transaction", b =>
                {
                    b.HasOne("PortfolioManager.Domain.AggregatesModel.AccountAggregate.Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PortfolioManager.Domain.AggregatesModel.AccountAggregate.TransactionType", "TransactionType")
                        .WithMany()
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
