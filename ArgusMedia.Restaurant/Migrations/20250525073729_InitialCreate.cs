using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArgusMedia.Restaurant.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDrink = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "IsDrink", "Name", "Price" },
                values: new object[] { new Guid("25254a12-e89e-4eb5-8e21-a5fc38625d01"), false, "Mains", 7m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "IsDrink", "Name", "Price" },
                values: new object[] { new Guid("25254a12-e89e-4eb5-8e21-a5fc38625d02"), false, "Mains", 4m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "IsDrink", "Name", "Price" },
                values: new object[] { new Guid("25254a12-e89e-4eb5-8e21-a5fc38625d03"), true, "Mains", 2.5m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
