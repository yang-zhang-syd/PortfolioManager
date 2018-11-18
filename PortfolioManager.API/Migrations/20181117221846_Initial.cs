using Microsoft.EntityFrameworkCore.Migrations;

namespace PortfolioManager.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "portfoliomanager");

            migrationBuilder.CreateSequence(
                name: "transactionseq",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "accountseq",
                schema: "portfoliomanager",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "accounts",
                schema: "portfoliomanager",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "transactiontype",
                schema: "portfoliomanager",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Id = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactiontype", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                schema: "portfoliomanager",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Symbol = table.Column<string>(nullable: false),
                    Units = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    TransactionTypeId = table.Column<int>(nullable: false),
                    AccountId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transactions_accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "portfoliomanager",
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transactions_transactiontype_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalSchema: "portfoliomanager",
                        principalTable: "transactiontype",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_transactions_AccountId",
                schema: "portfoliomanager",
                table: "transactions",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_TransactionTypeId",
                schema: "portfoliomanager",
                table: "transactions",
                column: "TransactionTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transactions",
                schema: "portfoliomanager");

            migrationBuilder.DropTable(
                name: "accounts",
                schema: "portfoliomanager");

            migrationBuilder.DropTable(
                name: "transactiontype",
                schema: "portfoliomanager");

            migrationBuilder.DropSequence(
                name: "transactionseq");

            migrationBuilder.DropSequence(
                name: "accountseq",
                schema: "portfoliomanager");
        }
    }
}
