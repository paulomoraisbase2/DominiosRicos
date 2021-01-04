using Microsoft.EntityFrameworkCore.Migrations;

namespace DominiosRicos.Repositorio.Migrations
{
    public partial class Atualizacao28012 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                schema: "dev",
                table: "Orcamento",
                newName: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                schema: "dev",
                table: "Orcamento",
                newName: "status");
        }
    }
}