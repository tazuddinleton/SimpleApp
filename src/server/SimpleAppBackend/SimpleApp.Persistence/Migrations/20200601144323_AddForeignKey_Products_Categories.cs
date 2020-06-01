using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleApp.Persistence.Migrations
{
    public partial class AddForeignKey_Products_Categories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "CategoryId", "CreatedBy", "DateCreated" },
                values: new object[] { 2, "tazuddin", new DateTime(2020, 6, 1, 20, 43, 22, 917, DateTimeKind.Local).AddTicks(1166) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "CategoryId", "CreatedBy", "DateCreated" },
                values: new object[] { 3, "tazuddin", new DateTime(2020, 6, 1, 20, 43, 22, 918, DateTimeKind.Local).AddTicks(1682) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "CategoryId", "CreatedBy", "DateCreated" },
                values: new object[] { 4, "tazuddin", new DateTime(2020, 6, 1, 20, 43, 22, 918, DateTimeKind.Local).AddTicks(1722) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "CategoryId", "CreatedBy", "DateCreated" },
                values: new object[] { 1, "tazuddin", new DateTime(2020, 6, 1, 20, 43, 22, 918, DateTimeKind.Local).AddTicks(1730) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "CategoryId", "CreatedBy", "DateCreated" },
                values: new object[] { 2, "tazuddin", new DateTime(2020, 6, 1, 20, 43, 22, 918, DateTimeKind.Local).AddTicks(1736) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "CategoryId", "CreatedBy", "DateCreated" },
                values: new object[] { 3, "tazuddin", new DateTime(2020, 6, 1, 20, 43, 22, 918, DateTimeKind.Local).AddTicks(1745) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7,
                columns: new[] { "CategoryId", "CreatedBy", "DateCreated" },
                values: new object[] { 4, "tazuddin", new DateTime(2020, 6, 1, 20, 43, 22, 918, DateTimeKind.Local).AddTicks(1751) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8,
                columns: new[] { "CategoryId", "CreatedBy", "DateCreated" },
                values: new object[] { 1, "tazuddin", new DateTime(2020, 6, 1, 20, 43, 22, 918, DateTimeKind.Local).AddTicks(1757) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9,
                columns: new[] { "CategoryId", "CreatedBy", "DateCreated" },
                values: new object[] { 2, "tazuddin", new DateTime(2020, 6, 1, 20, 43, 22, 918, DateTimeKind.Local).AddTicks(1762) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10,
                columns: new[] { "CategoryId", "CreatedBy", "DateCreated" },
                values: new object[] { 3, "tazuddin", new DateTime(2020, 6, 1, 20, 43, 22, 918, DateTimeKind.Local).AddTicks(1771) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "CreatedBy", "DateCreated", "Description", "LastUpdated", "ProductName", "UnitPrice", "UpdatedBy" },
                values: new object[,]
                {
                    { 11, 4, "tazuddin", new DateTime(2020, 6, 1, 20, 43, 22, 918, DateTimeKind.Local).AddTicks(1849), "Product Description 11", null, "Product 11", 145.55m, null },
                    { 12, 1, "tazuddin", new DateTime(2020, 6, 1, 20, 43, 22, 918, DateTimeKind.Local).AddTicks(1857), "Product Description 12", null, "Product 12", 145.55m, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12);

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "CreatedBy", "DateCreated" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "CreatedBy", "DateCreated" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "CreatedBy", "DateCreated" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "CreatedBy", "DateCreated" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "CreatedBy", "DateCreated" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "CreatedBy", "DateCreated" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7,
                columns: new[] { "CreatedBy", "DateCreated" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8,
                columns: new[] { "CreatedBy", "DateCreated" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9,
                columns: new[] { "CreatedBy", "DateCreated" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10,
                columns: new[] { "CreatedBy", "DateCreated" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
