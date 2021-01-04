using Microsoft.EntityFrameworkCore.Migrations;

namespace DominiosRicos.Repositorio.Migrations
{
    public partial class Atualizacao29012 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TipoDenticao",
                schema: "dev",
                table: "Orcamento",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoDenticao",
                schema: "dev",
                table: "Orcamento");
        }
    }
}