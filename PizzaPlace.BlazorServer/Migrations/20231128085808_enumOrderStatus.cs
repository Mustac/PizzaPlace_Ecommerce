using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaPlace.BlazorServer.Migrations
{
    /// <inheritdoc />
    public partial class enumOrderStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "OrderStatus",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 8, 58, 8, 815, DateTimeKind.Utc).AddTicks(6355));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 8, 58, 8, 815, DateTimeKind.Utc).AddTicks(6361));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 8, 58, 8, 815, DateTimeKind.Utc).AddTicks(6363));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 8, 58, 8, 815, DateTimeKind.Utc).AddTicks(6364));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 8, 58, 8, 815, DateTimeKind.Utc).AddTicks(6365));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 8, 58, 8, 815, DateTimeKind.Utc).AddTicks(6368));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 8, 58, 8, 815, DateTimeKind.Utc).AddTicks(6369));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 8, 58, 8, 815, DateTimeKind.Utc).AddTicks(6370));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 8, 58, 8, 815, DateTimeKind.Utc).AddTicks(6371));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 8, 58, 8, 815, DateTimeKind.Utc).AddTicks(6373));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 8, 58, 8, 815, DateTimeKind.Utc).AddTicks(6374));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 8, 58, 8, 815, DateTimeKind.Utc).AddTicks(6375));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 8, 58, 8, 815, DateTimeKind.Utc).AddTicks(6376));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 8, 58, 8, 815, DateTimeKind.Utc).AddTicks(6377));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 8, 58, 8, 815, DateTimeKind.Utc).AddTicks(6378));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 8, 58, 8, 815, DateTimeKind.Utc).AddTicks(6379));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 8, 58, 8, 815, DateTimeKind.Utc).AddTicks(6380));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 8, 58, 8, 815, DateTimeKind.Utc).AddTicks(6381));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 8, 58, 8, 815, DateTimeKind.Utc).AddTicks(6382));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateCreated",
                value: new DateTime(2023, 11, 28, 8, 58, 8, 815, DateTimeKind.Utc).AddTicks(6383));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 11, 23, 15, 17, 42, 930, DateTimeKind.Utc).AddTicks(3369));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 11, 23, 15, 17, 42, 930, DateTimeKind.Utc).AddTicks(3375));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 11, 23, 15, 17, 42, 930, DateTimeKind.Utc).AddTicks(3377));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 11, 23, 15, 17, 42, 930, DateTimeKind.Utc).AddTicks(3378));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 11, 23, 15, 17, 42, 930, DateTimeKind.Utc).AddTicks(3379));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 11, 23, 15, 17, 42, 930, DateTimeKind.Utc).AddTicks(3382));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 11, 23, 15, 17, 42, 930, DateTimeKind.Utc).AddTicks(3383));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 11, 23, 15, 17, 42, 930, DateTimeKind.Utc).AddTicks(3384));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2023, 11, 23, 15, 17, 42, 930, DateTimeKind.Utc).AddTicks(3384));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2023, 11, 23, 15, 17, 42, 930, DateTimeKind.Utc).AddTicks(3386));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2023, 11, 23, 15, 17, 42, 930, DateTimeKind.Utc).AddTicks(3387));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2023, 11, 23, 15, 17, 42, 930, DateTimeKind.Utc).AddTicks(3388));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateCreated",
                value: new DateTime(2023, 11, 23, 15, 17, 42, 930, DateTimeKind.Utc).AddTicks(3389));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateCreated",
                value: new DateTime(2023, 11, 23, 15, 17, 42, 930, DateTimeKind.Utc).AddTicks(3390));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateCreated",
                value: new DateTime(2023, 11, 23, 15, 17, 42, 930, DateTimeKind.Utc).AddTicks(3391));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateCreated",
                value: new DateTime(2023, 11, 23, 15, 17, 42, 930, DateTimeKind.Utc).AddTicks(3391));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateCreated",
                value: new DateTime(2023, 11, 23, 15, 17, 42, 930, DateTimeKind.Utc).AddTicks(3392));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateCreated",
                value: new DateTime(2023, 11, 23, 15, 17, 42, 930, DateTimeKind.Utc).AddTicks(3394));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateCreated",
                value: new DateTime(2023, 11, 23, 15, 17, 42, 930, DateTimeKind.Utc).AddTicks(3395));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateCreated",
                value: new DateTime(2023, 11, 23, 15, 17, 42, 930, DateTimeKind.Utc).AddTicks(3396));
        }
    }
}
