using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PizzaPlace.BlazorServer.Migrations
{
    /// <inheritdoc />
    public partial class fixedroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "602ea918-0940-464b-941c-eb5214ef258d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82302099-151b-4af3-99c2-a53bac98358c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9eb3ad7f-f363-4b54-9667-bfe3bfacaa9d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a18af76-8333-4d3f-89be-a1b6e1630c4e", null, "Manager", "MANAGER" },
                    { "195c6e53-5a36-4602-bdf3-13e6085b6ec9", null, "Delivery", "DELIVERY" },
                    { "99ef4292-185d-456e-b69c-3f25e2aee812", null, "Customer", "CUSTOMER" },
                    { "e4f72d5f-edf2-4825-8fc0-ba00a310b32e", null, "Chef", "CHEF" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a18af76-8333-4d3f-89be-a1b6e1630c4e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "195c6e53-5a36-4602-bdf3-13e6085b6ec9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99ef4292-185d-456e-b69c-3f25e2aee812");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4f72d5f-edf2-4825-8fc0-ba00a310b32e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "602ea918-0940-464b-941c-eb5214ef258d", null, "Chef", "CHEF" },
                    { "82302099-151b-4af3-99c2-a53bac98358c", null, "Delivery", "DELIVERY" },
                    { "9eb3ad7f-f363-4b54-9667-bfe3bfacaa9d", null, "Manager", "MANAGER" }
                });
        }
    }
}
