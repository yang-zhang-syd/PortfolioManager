using Microsoft.EntityFrameworkCore.Migrations;

namespace PortfolioManager.API.Migrations
{
    public partial class AddAccountStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                schema: "portfoliomanager",
                table: "accounts",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateTable(
                name: "accountstatus",
                schema: "portfoliomanager",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Id = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accountstatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_accounts_StatusId",
                schema: "portfoliomanager",
                table: "accounts",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_accountstatus_StatusId",
                schema: "portfoliomanager",
                table: "accounts",
                column: "StatusId",
                principalSchema: "portfoliomanager",
                principalTable: "accountstatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accounts_accountstatus_StatusId",
                schema: "portfoliomanager",
                table: "accounts");

            migrationBuilder.DropTable(
                name: "accountstatus",
                schema: "portfoliomanager");

            migrationBuilder.DropIndex(
                name: "IX_accounts_StatusId",
                schema: "portfoliomanager",
                table: "accounts");

            migrationBuilder.DropColumn(
                name: "StatusId",
                schema: "portfoliomanager",
                table: "accounts");
        }
    }
}
