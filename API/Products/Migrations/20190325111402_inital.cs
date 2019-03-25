using Microsoft.EntityFrameworkCore.Migrations;

namespace Products.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BrandEntry",
                columns: table => new
                {
                    BrandName = table.Column<string>(nullable: false),
                    Value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandEntry", x => x.BrandName);
                });

            migrationBuilder.CreateTable(
                name: "ProductEntry",
                columns: table => new
                {
                    Number = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    BrandNameFK = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductEntry", x => x.Number);
                    table.ForeignKey(
                        name: "FK_ProductEntry_BrandEntry_BrandNameFK",
                        column: x => x.BrandNameFK,
                        principalTable: "BrandEntry",
                        principalColumn: "BrandName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntry_BrandNameFK",
                table: "ProductEntry",
                column: "BrandNameFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductEntry");

            migrationBuilder.DropTable(
                name: "BrandEntry");
        }
    }
}
