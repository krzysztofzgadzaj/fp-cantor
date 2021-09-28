using Microsoft.EntityFrameworkCore.Migrations;

namespace Cantor.Infrastructure.Migrations
{
    public partial class CurrenciesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChfAmount",
                table: "Portfolios",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RubAmount",
                table: "Portfolios",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChfAmount",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "RubAmount",
                table: "Portfolios");
        }
    }
}
