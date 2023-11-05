using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaPlace.BlazorServer.Migrations
{
    /// <inheritdoc />
    public partial class AddedDateCreatedProductVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "ProductVersions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 15, 18, 569, DateTimeKind.Utc).AddTicks(4710));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 15, 18, 569, DateTimeKind.Utc).AddTicks(4718));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 15, 18, 569, DateTimeKind.Utc).AddTicks(4719));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 15, 18, 569, DateTimeKind.Utc).AddTicks(4720));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 15, 18, 569, DateTimeKind.Utc).AddTicks(4720));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 15, 18, 569, DateTimeKind.Utc).AddTicks(4721));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 15, 18, 569, DateTimeKind.Utc).AddTicks(4722));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 15, 18, 569, DateTimeKind.Utc).AddTicks(4722));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 15, 18, 569, DateTimeKind.Utc).AddTicks(4723));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 15, 18, 569, DateTimeKind.Utc).AddTicks(4724));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 15, 18, 569, DateTimeKind.Utc).AddTicks(4725));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 15, 18, 569, DateTimeKind.Utc).AddTicks(4725));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 15, 18, 569, DateTimeKind.Utc).AddTicks(4726));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 15, 18, 569, DateTimeKind.Utc).AddTicks(4726));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 15, 18, 569, DateTimeKind.Utc).AddTicks(4727));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 15, 18, 569, DateTimeKind.Utc).AddTicks(4728));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 15, 18, 569, DateTimeKind.Utc).AddTicks(4728));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 15, 18, 569, DateTimeKind.Utc).AddTicks(4729));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 15, 18, 569, DateTimeKind.Utc).AddTicks(4729));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 11, 15, 18, 569, DateTimeKind.Utc).AddTicks(4730));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "ProductVersions");
        }
    }
}
