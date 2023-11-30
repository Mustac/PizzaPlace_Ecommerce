using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaPlace.BlazorServer.Migrations
{
    /// <inheritdoc />
    public partial class addedFullAddressToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullAddress",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1877));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1887));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1889));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1890));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1891));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1894));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1895));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1896));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1897));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1898));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1900));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1901));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateCreated",
                value: new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1902));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateCreated",
                value: new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1903));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateCreated",
                value: new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1904));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateCreated",
                value: new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1905));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateCreated",
                value: new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1949));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateCreated",
                value: new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1951));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateCreated",
                value: new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1952));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateCreated",
                value: new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1954));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullAddress",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 9, 11, 8, 183, DateTimeKind.Utc).AddTicks(7003));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 9, 11, 8, 183, DateTimeKind.Utc).AddTicks(7010));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 9, 11, 8, 183, DateTimeKind.Utc).AddTicks(7012));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 9, 11, 8, 183, DateTimeKind.Utc).AddTicks(7013));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 9, 11, 8, 183, DateTimeKind.Utc).AddTicks(7014));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 9, 11, 8, 183, DateTimeKind.Utc).AddTicks(7017));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 9, 11, 8, 183, DateTimeKind.Utc).AddTicks(7018));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 9, 11, 8, 183, DateTimeKind.Utc).AddTicks(7019));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 9, 11, 8, 183, DateTimeKind.Utc).AddTicks(7020));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 9, 11, 8, 183, DateTimeKind.Utc).AddTicks(7021));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 9, 11, 8, 183, DateTimeKind.Utc).AddTicks(7022));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 9, 11, 8, 183, DateTimeKind.Utc).AddTicks(7023));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 9, 11, 8, 183, DateTimeKind.Utc).AddTicks(7024));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 9, 11, 8, 183, DateTimeKind.Utc).AddTicks(7025));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 9, 11, 8, 183, DateTimeKind.Utc).AddTicks(7026));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 9, 11, 8, 183, DateTimeKind.Utc).AddTicks(7027));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 9, 11, 8, 183, DateTimeKind.Utc).AddTicks(7027));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 9, 11, 8, 183, DateTimeKind.Utc).AddTicks(7029));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 9, 11, 8, 183, DateTimeKind.Utc).AddTicks(7030));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 9, 11, 8, 183, DateTimeKind.Utc).AddTicks(7031));
        }
    }
}
