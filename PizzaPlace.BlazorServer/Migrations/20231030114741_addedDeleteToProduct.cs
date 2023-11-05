using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaPlace.BlazorServer.Migrations
{
    /// <inheritdoc />
    public partial class addedDeleteToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 47, 41, 175, DateTimeKind.Utc).AddTicks(6646));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 47, 41, 175, DateTimeKind.Utc).AddTicks(6651));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 47, 41, 175, DateTimeKind.Utc).AddTicks(6652));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 47, 41, 175, DateTimeKind.Utc).AddTicks(6653));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 47, 41, 175, DateTimeKind.Utc).AddTicks(6654));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 47, 41, 175, DateTimeKind.Utc).AddTicks(6655));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 47, 41, 175, DateTimeKind.Utc).AddTicks(6655));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 47, 41, 175, DateTimeKind.Utc).AddTicks(6656));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 47, 41, 175, DateTimeKind.Utc).AddTicks(6657));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 47, 41, 175, DateTimeKind.Utc).AddTicks(6657));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 47, 41, 175, DateTimeKind.Utc).AddTicks(6658));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 47, 41, 175, DateTimeKind.Utc).AddTicks(6659));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 47, 41, 175, DateTimeKind.Utc).AddTicks(6659));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 47, 41, 175, DateTimeKind.Utc).AddTicks(6660));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 47, 41, 175, DateTimeKind.Utc).AddTicks(6661));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 47, 41, 175, DateTimeKind.Utc).AddTicks(6662));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 47, 41, 175, DateTimeKind.Utc).AddTicks(6662));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 47, 41, 175, DateTimeKind.Utc).AddTicks(6663));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 47, 41, 175, DateTimeKind.Utc).AddTicks(6664));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 47, 41, 175, DateTimeKind.Utc).AddTicks(6664));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "IsDeleted",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 32, 29, 354, DateTimeKind.Utc).AddTicks(2222));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 32, 29, 354, DateTimeKind.Utc).AddTicks(2226));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 32, 29, 354, DateTimeKind.Utc).AddTicks(2246));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 32, 29, 354, DateTimeKind.Utc).AddTicks(2247));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 32, 29, 354, DateTimeKind.Utc).AddTicks(2248));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 32, 29, 354, DateTimeKind.Utc).AddTicks(2249));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 32, 29, 354, DateTimeKind.Utc).AddTicks(2250));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 32, 29, 354, DateTimeKind.Utc).AddTicks(2250));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 32, 29, 354, DateTimeKind.Utc).AddTicks(2251));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 32, 29, 354, DateTimeKind.Utc).AddTicks(2251));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 32, 29, 354, DateTimeKind.Utc).AddTicks(2252));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 32, 29, 354, DateTimeKind.Utc).AddTicks(2253));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 32, 29, 354, DateTimeKind.Utc).AddTicks(2254));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 32, 29, 354, DateTimeKind.Utc).AddTicks(2255));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 32, 29, 354, DateTimeKind.Utc).AddTicks(2255));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 32, 29, 354, DateTimeKind.Utc).AddTicks(2256));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 32, 29, 354, DateTimeKind.Utc).AddTicks(2257));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 32, 29, 354, DateTimeKind.Utc).AddTicks(2257));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 32, 29, 354, DateTimeKind.Utc).AddTicks(2258));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 32, 29, 354, DateTimeKind.Utc).AddTicks(2259));
        }
    }
}
