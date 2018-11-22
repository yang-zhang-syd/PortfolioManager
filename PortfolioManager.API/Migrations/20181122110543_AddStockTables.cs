using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PortfolioManager.API.Migrations
{
    public partial class AddStockTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "stockholdingseq",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "stockpriceseq",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "stockseq",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "stocks",
                schema: "portfoliomanager",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Symbol = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "stockholdings",
                schema: "portfoliomanager",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    StockId = table.Column<int>(nullable: false),
                    AccountId = table.Column<int>(nullable: false),
                    Units = table.Column<int>(nullable: false),
                    BoughtPrice = table.Column<decimal>(nullable: false),
                    Commission = table.Column<decimal>(nullable: false),
                    BoughtDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stockholdings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_stockholdings_accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "portfoliomanager",
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_stockholdings_stocks_StockId",
                        column: x => x.StockId,
                        principalSchema: "portfoliomanager",
                        principalTable: "stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stockprices",
                schema: "portfoliomanager",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    StockId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stockprices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_stockprices_stocks_StockId",
                        column: x => x.StockId,
                        principalSchema: "portfoliomanager",
                        principalTable: "stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_stockholdings_AccountId",
                schema: "portfoliomanager",
                table: "stockholdings",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_stockholdings_StockId",
                schema: "portfoliomanager",
                table: "stockholdings",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_stockprices_StockId",
                schema: "portfoliomanager",
                table: "stockprices",
                column: "StockId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stockholdings",
                schema: "portfoliomanager");

            migrationBuilder.DropTable(
                name: "stockprices",
                schema: "portfoliomanager");

            migrationBuilder.DropTable(
                name: "stocks",
                schema: "portfoliomanager");

            migrationBuilder.DropSequence(
                name: "stockholdingseq");

            migrationBuilder.DropSequence(
                name: "stockpriceseq");

            migrationBuilder.DropSequence(
                name: "stockseq");
        }
    }
}
