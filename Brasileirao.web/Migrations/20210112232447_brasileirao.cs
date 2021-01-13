using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Brasileirao.web.Migrations
{
    public partial class brasileirao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Jornadas = table.Column<string>(nullable: true),
                    Clube = table.Column<string>(nullable: true),
                    Pontos = table.Column<int>(nullable: false),
                    Posicao = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    ultimoJogo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jogos");
        }
    }
}
