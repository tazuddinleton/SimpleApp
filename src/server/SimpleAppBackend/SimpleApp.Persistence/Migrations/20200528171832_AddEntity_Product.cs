using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleApp.Persistence.Migrations
{
    public partial class AddEntity_Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "ProductName", "UnitPrice" },
                values: new object[,]
                {
                    { 1, "Product Description 1", "Product 1", 145.55m },
                    { 2, "Product Description 2", "Product 2", 145.55m },
                    { 3, "Product Description 3", "Product 3", 145.55m },
                    { 4, "Product Description 4", "Product 4", 145.55m },
                    { 5, "Product Description 5", "Product 5", 145.55m },
                    { 6, "Product Description 6", "Product 6", 145.55m },
                    { 7, "Product Description 7", "Product 7", 145.55m },
                    { 8, "Product Description 8", "Product 8", 145.55m },
                    { 9, "Product Description 9", "Product 9", 145.55m },
                    { 10, "Product Description 10", "Product 10", 145.55m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
