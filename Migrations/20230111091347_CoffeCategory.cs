using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coffe_Project.Migrations
{
    public partial class CoffeCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CoffeCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoffeID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CoffeCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoffeCategory_Coffe_CoffeID",
                        column: x => x.CoffeID,
                        principalTable: "Coffe",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoffeCategory_CategoryID",
                table: "CoffeCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_CoffeCategory_CoffeID",
                table: "CoffeCategory",
                column: "CoffeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoffeCategory");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
