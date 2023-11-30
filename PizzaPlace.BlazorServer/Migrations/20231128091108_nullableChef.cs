using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaPlace.BlazorServer.Migrations
{
    /// <inheritdoc />
    public partial class nullableChef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_ChefId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_DeliveryId",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryId",
                table: "Orders",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ChefId",
                table: "Orders",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_ChefId",
                table: "Orders",
                column: "ChefId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_DeliveryId",
                table: "Orders",
                column: "DeliveryId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_ChefId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_DeliveryId",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryId",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ChefId",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_ChefId",
                table: "Orders",
                column: "ChefId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_DeliveryId",
                table: "Orders",
                column: "DeliveryId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
