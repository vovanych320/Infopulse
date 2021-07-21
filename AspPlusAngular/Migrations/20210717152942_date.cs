using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspPlusAngular.Migrations
{
    public partial class date : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: "5e2a6fa7");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerAddress", "CustomerName", "Date", "OrdersCount", "TotalOrderCost" },
                values: new object[] { "d1a4d6f6", "Kyiv", "Vova", new DateTime(2021, 7, 17, 18, 29, 41, 783, DateTimeKind.Local).AddTicks(7766), 4L, 134.41999999999999 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: "d1a4d6f6");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerAddress", "CustomerName", "Date", "OrdersCount", "TotalOrderCost" },
                values: new object[] { "5e2a6fa7", "Kyiv", "Vova", new DateTime(2021, 7, 17, 2, 0, 20, 905, DateTimeKind.Local).AddTicks(5881), 4L, 134.41999999999999 });
        }
    }
}
