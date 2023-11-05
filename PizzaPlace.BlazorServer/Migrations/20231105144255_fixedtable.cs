using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PizzaPlace.BlazorServer.Migrations
{
    /// <inheritdoc />
    public partial class fixedtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_ProductVersions_ProductVersionId",
                table: "OrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductVersions_ActiveProductVersionId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductVersions");

            migrationBuilder.DropIndex(
                name: "IX_Products_ActiveProductVersionId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ActiveProductVersionId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductVersionId",
                table: "OrderProducts",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProducts_ProductVersionId",
                table: "OrderProducts",
                newName: "IX_OrderProducts_ProductId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "IsDeleted" },
                values: new object[] { new DateTime(2023, 11, 5, 14, 42, 55, 165, DateTimeKind.Utc).AddTicks(271), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "IsDeleted" },
                values: new object[] { new DateTime(2023, 11, 5, 14, 42, 55, 165, DateTimeKind.Utc).AddTicks(278), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "IsDeleted" },
                values: new object[] { new DateTime(2023, 11, 5, 14, 42, 55, 165, DateTimeKind.Utc).AddTicks(280), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "IsDeleted" },
                values: new object[] { new DateTime(2023, 11, 5, 14, 42, 55, 165, DateTimeKind.Utc).AddTicks(281), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "IsDeleted" },
                values: new object[] { new DateTime(2023, 11, 5, 14, 42, 55, 165, DateTimeKind.Utc).AddTicks(282), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "IsDeleted" },
                values: new object[] { new DateTime(2023, 11, 5, 14, 42, 55, 165, DateTimeKind.Utc).AddTicks(285), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "IsDeleted" },
                values: new object[] { new DateTime(2023, 11, 5, 14, 42, 55, 165, DateTimeKind.Utc).AddTicks(286), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "IsDeleted" },
                values: new object[] { new DateTime(2023, 11, 5, 14, 42, 55, 165, DateTimeKind.Utc).AddTicks(287), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "IsDeleted" },
                values: new object[] { new DateTime(2023, 11, 5, 14, 42, 55, 165, DateTimeKind.Utc).AddTicks(288), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "IsDeleted" },
                values: new object[] { new DateTime(2023, 11, 5, 14, 42, 55, 165, DateTimeKind.Utc).AddTicks(290), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "IsDeleted" },
                values: new object[] { new DateTime(2023, 11, 5, 14, 42, 55, 165, DateTimeKind.Utc).AddTicks(291), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "DateCreated", "IsDeleted" },
                values: new object[] { new DateTime(2023, 11, 5, 14, 42, 55, 165, DateTimeKind.Utc).AddTicks(292), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "DateCreated", "IsDeleted" },
                values: new object[] { new DateTime(2023, 11, 5, 14, 42, 55, 165, DateTimeKind.Utc).AddTicks(293), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "DateCreated", "IsDeleted" },
                values: new object[] { new DateTime(2023, 11, 5, 14, 42, 55, 165, DateTimeKind.Utc).AddTicks(294), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "DateCreated", "IsDeleted" },
                values: new object[] { new DateTime(2023, 11, 5, 14, 42, 55, 165, DateTimeKind.Utc).AddTicks(295), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "DateCreated", "IsDeleted" },
                values: new object[] { new DateTime(2023, 11, 5, 14, 42, 55, 165, DateTimeKind.Utc).AddTicks(296), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "DateCreated", "IsDeleted" },
                values: new object[] { new DateTime(2023, 11, 5, 14, 42, 55, 165, DateTimeKind.Utc).AddTicks(297), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "DateCreated", "IsDeleted" },
                values: new object[] { new DateTime(2023, 11, 5, 14, 42, 55, 165, DateTimeKind.Utc).AddTicks(299), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "DateCreated", "IsDeleted" },
                values: new object[] { new DateTime(2023, 11, 5, 14, 42, 55, 165, DateTimeKind.Utc).AddTicks(300), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "DateCreated", "IsDeleted" },
                values: new object[] { new DateTime(2023, 11, 5, 14, 42, 55, 165, DateTimeKind.Utc).AddTicks(301), false });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Products_ProductId",
                table: "OrderProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Products_ProductId",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderProducts",
                newName: "ProductVersionId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts",
                newName: "IX_OrderProducts_ProductVersionId");

            migrationBuilder.AddColumn<int>(
                name: "ActiveProductVersionId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductVersions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DiscountedPrice = table.Column<float>(type: "real", nullable: false),
                    Ingredients = table.Column<string>(type: "text", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVersions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductVersions",
                columns: new[] { "Id", "DateCreated", "DiscountedPrice", "Ingredients", "IsArchived", "Name", "Price", "ProductId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6287), 0f, "Tomato, Mozzarella, Basil", false, "Margherita", 10f, 1 },
                    { 2, new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6292), 0f, "Tomato, Mozzarella, Pepperoni", false, "Pepperoni", 12f, 2 },
                    { 3, new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6293), 0f, "Tomato, Mozzarella, Ham, Pineapple", false, "Hawaiian", 13f, 3 },
                    { 4, new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6294), 0f, "BBQ Sauce, Mozzarella, Chicken, Red Onion", false, "BBQ Chicken", 14f, 4 },
                    { 5, new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6295), 0f, "Tomato, Mozzarella, Pepperoni, Ham, Bacon, Sausage", false, "Meat Lover", 15f, 5 },
                    { 6, new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6296), 0f, "Tomato, Mozzarella, Bell Pepper, Onion, Mushroom, Olives", false, "Veggie", 13f, 6 },
                    { 7, new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6296), 0f, "Tomato, Mozzarella, Mushroom", false, "Mushroom", 12f, 7 },
                    { 8, new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6297), 0f, "Tomato, Mozzarella, Cheddar, Feta, Parmesan", false, "Four Cheese", 14f, 8 },
                    { 9, new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6298), 0f, "Buffalo Sauce, Mozzarella, Chicken, Celery", false, "Buffalo Chicken", 14f, 9 },
                    { 10, new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6298), 0f, "Tomato, Mozzarella, Pepperoni, Bell Pepper, Onion, Mushroom, Olives, Sausage", false, "Supreme", 16f, 10 },
                    { 11, new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6299), 0f, "Alfredo Sauce, Mozzarella, Chicken", false, "Chicken Alfredo", 14f, 11 },
                    { 12, new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6300), 0f, "Olive Oil, Mozzarella, Tomato, Basil", false, "White Pizza", 13f, 12 },
                    { 13, new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6300), 0f, "Olive Oil, Mozzarella, Shrimp, Garlic", false, "Shrimp Scampi", 16f, 13 },
                    { 14, new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6301), 0f, "Tomato, Mozzarella, Steak, Bell Pepper, Onion", false, "Philly Cheesesteak", 15f, 14 },
                    { 15, new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6302), 0f, "Tomato, Mozzarella, Ground Beef, Tomato, Lettuce, Cheddar", false, "Taco Pizza", 14f, 15 },
                    { 16, new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6302), 0f, "Tomato, Mozzarella, Sausage", false, "Sausage", 12f, 16 },
                    { 17, new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6303), 0f, "Tomato, Mozzarella, Chicken, Garlic", false, "Garlic Chicken", 14f, 17 },
                    { 18, new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6304), 0f, "Tomato, Mozzarella, Spinach, Feta", false, "Spinach and Feta", 13f, 18 },
                    { 19, new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6304), 0f, "Pesto Sauce, Mozzarella, Bell Pepper, Onion, Mushroom, Olives", false, "Pesto Veggie", 14f, 19 },
                    { 20, new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6305), 0f, "Ranch Sauce, Mozzarella, Bacon, Chicken", false, "Bacon Ranch", 14f, 20 }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ActiveProductVersionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ActiveProductVersionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ActiveProductVersionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ActiveProductVersionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ActiveProductVersionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "ActiveProductVersionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "ActiveProductVersionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "ActiveProductVersionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "ActiveProductVersionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "ActiveProductVersionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "ActiveProductVersionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "ActiveProductVersionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "ActiveProductVersionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "ActiveProductVersionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "ActiveProductVersionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "ActiveProductVersionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "ActiveProductVersionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "ActiveProductVersionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "ActiveProductVersionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "ActiveProductVersionId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ActiveProductVersionId",
                table: "Products",
                column: "ActiveProductVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVersions_ProductId",
                table: "ProductVersions",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_ProductVersions_ProductVersionId",
                table: "OrderProducts",
                column: "ProductVersionId",
                principalTable: "ProductVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductVersions_ActiveProductVersionId",
                table: "Products",
                column: "ActiveProductVersionId",
                principalTable: "ProductVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
