using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_7.Migrations
{
    public partial class SeedProductData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "ImagePath", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 24, 16, 51, 34, 409, DateTimeKind.Local).AddTicks(9208), null, "Computer", 3500m, 100 },
                    { 2, new DateTime(2024, 8, 24, 16, 51, 34, 410, DateTimeKind.Local).AddTicks(6525), null, "Phone", 500m, 10 },
                    { 3, new DateTime(2024, 8, 24, 16, 51, 34, 410, DateTimeKind.Local).AddTicks(6537), null, "Mouse", 150m, 3 },
                    { 4, new DateTime(2024, 8, 24, 16, 51, 34, 410, DateTimeKind.Local).AddTicks(6539), null, "Keyboard", 350m, 30 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
