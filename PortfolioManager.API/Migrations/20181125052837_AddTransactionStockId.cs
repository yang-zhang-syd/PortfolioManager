using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PortfolioManager.API.Migrations
{
    public partial class AddTransactionStockId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                schema: "portfoliomanager",
                table: "transactions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "StockId",
                schema: "portfoliomanager",
                table: "transactions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_transactions_StockId",
                schema: "portfoliomanager",
                table: "transactions",
                column: "StockId");

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_stocks_StockId",
                schema: "portfoliomanager",
                table: "transactions",
                column: "StockId",
                principalSchema: "portfoliomanager",
                principalTable: "stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactions_stocks_StockId",
                schema: "portfoliomanager",
                table: "transactions");

            migrationBuilder.DropIndex(
                name: "IX_transactions_StockId",
                schema: "portfoliomanager",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "DateTime",
                schema: "portfoliomanager",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "StockId",
                schema: "portfoliomanager",
                table: "transactions");
        }
    }
}
