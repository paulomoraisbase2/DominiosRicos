using Microsoft.EntityFrameworkCore.Migrations;

namespace DominiosRicos.Repositorio.Migrations
{
    public partial class Atualizacao29013 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dente_Posicao",
                schema: "dev",
                table: "OrcamentoComentario");

            migrationBuilder.DropColumn(
                name: "Dente_Quadrante",
                schema: "dev",
                table: "OrcamentoComentario");

            migrationBuilder.RenameColumn(
                name: "Dente_Tipo",
                schema: "dev",
                table: "OrcamentoComentario",
                newName: "Dente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Dente",
                schema: "dev",
                table: "OrcamentoComentario",
                newName: "Dente_Tipo");

            migrationBuilder.AddColumn<int>(
                name: "Dente_Posicao",
                schema: "dev",
                table: "OrcamentoComentario",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Dente_Quadrante",
                schema: "dev",
                table: "OrcamentoComentario",
                nullable: false,
                defaultValue: 0);
        }
    }
}