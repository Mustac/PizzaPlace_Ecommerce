using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaPlace.BlazorServer.Migrations
{
    /// <inheritdoc />
    public partial class addedIsArchivedToProductVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "ProductVersions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "IsArchived" },
                values: new object[] { new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6287), false });

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "IsArchived" },
                values: new object[] { new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6292), false });

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "IsArchived" },
                values: new object[] { new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6293), false });

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "IsArchived" },
                values: new object[] { new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6294), false });

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "IsArchived" },
                values: new object[] { new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6295), false });

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "IsArchived" },
                values: new object[] { new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6296), false });

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "IsArchived" },
                values: new object[] { new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6296), false });

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "IsArchived" },
                values: new object[] { new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6297), false });

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "IsArchived" },
                values: new object[] { new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6298), false });

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "IsArchived" },
                values: new object[] { new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6298), false });

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "IsArchived" },
                values: new object[] { new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6299), false });

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "DateCreated", "IsArchived" },
                values: new object[] { new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6300), false });

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "DateCreated", "IsArchived" },
                values: new object[] { new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6300), false });

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "DateCreated", "IsArchived" },
                values: new object[] { new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6301), false });

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "DateCreated", "IsArchived" },
                values: new object[] { new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6302), false });

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "DateCreated", "IsArchived" },
                values: new object[] { new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6302), false });

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "DateCreated", "IsArchived" },
                values: new object[] { new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6303), false });

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "DateCreated", "IsArchived" },
                values: new object[] { new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6304), false });

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "DateCreated", "IsArchived" },
                values: new object[] { new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6304), false });

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "DateCreated", "IsArchived" },
                values: new object[] { new DateTime(2023, 11, 4, 9, 51, 49, 614, DateTimeKind.Utc).AddTicks(6305), false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "ProductVersions");

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 15, 46, 37, 720, DateTimeKind.Utc).AddTicks(1123));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 15, 46, 37, 720, DateTimeKind.Utc).AddTicks(1129));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 15, 46, 37, 720, DateTimeKind.Utc).AddTicks(1130));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 15, 46, 37, 720, DateTimeKind.Utc).AddTicks(1131));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 15, 46, 37, 720, DateTimeKind.Utc).AddTicks(1132));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 15, 46, 37, 720, DateTimeKind.Utc).AddTicks(1132));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 15, 46, 37, 720, DateTimeKind.Utc).AddTicks(1133));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 15, 46, 37, 720, DateTimeKind.Utc).AddTicks(1134));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 15, 46, 37, 720, DateTimeKind.Utc).AddTicks(1135));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 15, 46, 37, 720, DateTimeKind.Utc).AddTicks(1135));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 15, 46, 37, 720, DateTimeKind.Utc).AddTicks(1136));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 15, 46, 37, 720, DateTimeKind.Utc).AddTicks(1137));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 15, 46, 37, 720, DateTimeKind.Utc).AddTicks(1137));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 15, 46, 37, 720, DateTimeKind.Utc).AddTicks(1138));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 15, 46, 37, 720, DateTimeKind.Utc).AddTicks(1139));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 15, 46, 37, 720, DateTimeKind.Utc).AddTicks(1139));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 15, 46, 37, 720, DateTimeKind.Utc).AddTicks(1140));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 15, 46, 37, 720, DateTimeKind.Utc).AddTicks(1141));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 15, 46, 37, 720, DateTimeKind.Utc).AddTicks(1142));

            migrationBuilder.UpdateData(
                table: "ProductVersions",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateCreated",
                value: new DateTime(2023, 10, 30, 15, 46, 37, 720, DateTimeKind.Utc).AddTicks(1142));
        }
    }
}
