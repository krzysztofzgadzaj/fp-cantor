using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cantor.Infrastructure.Migrations
{
    public partial class CantorAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GbpAmount = table.Column<int>(type: "integer", nullable: false),
                    EurAmount = table.Column<int>(type: "integer", nullable: false),
                    UsdAmount = table.Column<int>(type: "integer", nullable: false),
                    CzkAmount = table.Column<int>(type: "integer", nullable: false),
                    PlnAmount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Portfolios");
        }
    }
}
