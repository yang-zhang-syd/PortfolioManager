using Microsoft.EntityFrameworkCore.Migrations;

namespace PortfolioManager.API.Migrations
{
    public partial class TransactionStockIdNotNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactions_stocks_StockId",
                schema: "portfoliomanager",
                table: "transactions");

            migrationBuilder.AlterColumn<int>(
                name: "StockId",
                schema: "portfoliomanager",
                table: "transactions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_stocks_StockId",
                schema: "portfoliomanager",
                table: "transactions",
                column: "StockId",
                principalSchema: "portfoliomanager",
                principalTable: "stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactions_stocks_StockId",
                schema: "portfoliomanager",
                table: "transactions");

            migrationBuilder.AlterColumn<int>(
                name: "StockId",
                schema: "portfoliomanager",
                table: "transactions",
                nullable: true,
                oldClrType: typeof(int));

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
    }
}
