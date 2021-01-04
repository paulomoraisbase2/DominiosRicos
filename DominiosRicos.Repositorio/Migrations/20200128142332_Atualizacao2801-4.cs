using Microsoft.EntityFrameworkCore.Migrations;

namespace DominiosRicos.Repositorio.Migrations
{
    public partial class Atualizacao28014 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Rascunho",
                schema: "dev",
                table: "Orcamento",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rascunho",
                schema: "dev",
                table: "Orcamento");
        }
    }
}