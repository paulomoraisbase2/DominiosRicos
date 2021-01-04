using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DominiosRicos.Repositorio.Migrations
{
    public partial class Atualizacao28015 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrcamentoDentesRemovido",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrcamentoId = table.Column<Guid>(nullable: false),
                    Dente = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrcamentoDentesRemovido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrcamentoDentesRemovido_Orcamento_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalSchema: "dev",
                        principalTable: "Orcamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrcamentoDentesRemovido_OrcamentoId",
                table: "OrcamentoDentesRemovido",
                column: "OrcamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrcamentoDentesRemovido");
        }
    }
}