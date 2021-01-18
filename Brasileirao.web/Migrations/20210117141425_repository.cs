using Microsoft.EntityFrameworkCore.Migrations;

namespace Brasileirao.web.Migrations
{
    public partial class repository : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_clubes",
                table: "clubes");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "clubes");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "clubes");

            migrationBuilder.DropColumn(
                name: "Nome_campo",
                table: "clubes");

            migrationBuilder.RenameTable(
                name: "clubes",
                newName: "Clubes");

            migrationBuilder.RenameColumn(
                name: "cidade",
                table: "Clubes",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clubes",
                table: "Clubes",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Clubes",
                table: "Clubes");

            migrationBuilder.RenameTable(
                name: "Clubes",
                newName: "clubes");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "clubes",
                newName: "cidade");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "clubes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "clubes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome_campo",
                table: "clubes",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_clubes",
                table: "clubes",
                column: "Id");
        }
    }
}
