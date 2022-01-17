using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductWebApi.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2022, 1, 17, 13, 10, 15, 745, DateTimeKind.Utc).AddTicks(9738)),
                    ModifiedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2022, 1, 17, 13, 10, 15, 746, DateTimeKind.Utc).AddTicks(855)),
                    Name = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2022, 1, 17, 13, 10, 15, 731, DateTimeKind.Utc).AddTicks(736)),
                    ModifiedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2022, 1, 17, 13, 10, 15, 731, DateTimeKind.Utc).AddTicks(4244)),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    CostPrice = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    Image = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
