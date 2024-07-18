using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CathayBkWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateBTCPriceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BTCPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    USDRate = table.Column<double>(type: "float", nullable: false),
                    GBPRate = table.Column<double>(type: "float", nullable: false),
                    EURRate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BTCPrices", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BTCPrices");
        }
    }
}
