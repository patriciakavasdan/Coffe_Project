using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coffe_Project.Migrations
{
    public partial class Distribuitor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coffe_Arome_AromeID",
                table: "Coffe");

            migrationBuilder.DropTable(
                name: "Arome");

            migrationBuilder.RenameColumn(
                name: "AromeID",
                table: "Coffe",
                newName: "DistribuitorID");

            migrationBuilder.RenameIndex(
                name: "IX_Coffe_AromeID",
                table: "Coffe",
                newName: "IX_Coffe_DistribuitorID");

            migrationBuilder.CreateTable(
                name: "Distribuitor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistribuitorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distribuitor", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Coffe_Distribuitor_DistribuitorID",
                table: "Coffe",
                column: "DistribuitorID",
                principalTable: "Distribuitor",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coffe_Distribuitor_DistribuitorID",
                table: "Coffe");

            migrationBuilder.DropTable(
                name: "Distribuitor");

            migrationBuilder.RenameColumn(
                name: "DistribuitorID",
                table: "Coffe",
                newName: "AromeID");

            migrationBuilder.RenameIndex(
                name: "IX_Coffe_DistribuitorID",
                table: "Coffe",
                newName: "IX_Coffe_AromeID");

            migrationBuilder.CreateTable(
                name: "Arome",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AromeText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arome", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Coffe_Arome_AromeID",
                table: "Coffe",
                column: "AromeID",
                principalTable: "Arome",
                principalColumn: "ID");
        }
    }
}
