using Microsoft.EntityFrameworkCore.Migrations;

namespace PortfolioManager.API.Migrations
{
    public partial class RemoveTransactionSymbol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Symbol",
                schema: "portfoliomanager",
                table: "transactions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Symbol",
                schema: "portfoliomanager",
                table: "transactions",
                nullable: false,
                defaultValue: "");
        }
    }
}
