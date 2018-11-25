using Microsoft.EntityFrameworkCore.Migrations;

namespace PortfolioManager.API.Migrations
{
    public partial class AddTransactionCommission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Commission",
                schema: "portfoliomanager",
                table: "transactions",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Commission",
                schema: "portfoliomanager",
                table: "transactions");
        }
    }
}
