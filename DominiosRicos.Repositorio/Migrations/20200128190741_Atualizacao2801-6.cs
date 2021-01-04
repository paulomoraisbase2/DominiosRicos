using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DominiosRicos.Repositorio.Migrations
{
    public partial class Atualizacao28016 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auditorias_Usuario_UsuarioId",
                table: "Auditorias");

            migrationBuilder.DropTable(
                name: "Anamneses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Auditorias",
                table: "Auditorias");

            migrationBuilder.RenameTable(
                name: "OrcamentoDentesRemovido",
                newName: "OrcamentoDentesRemovido",
                newSchema: "dev");

            migrationBuilder.RenameTable(
                name: "Auditorias",
                newName: "Auditoria");

            migrationBuilder.RenameIndex(
                name: "IX_Auditorias_UsuarioId",
                table: "Auditoria",
                newName: "IX_Auditoria_UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Auditoria",
                table: "Auditoria",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Auditoria_Usuario_UsuarioId",
                table: "Auditoria",
                column: "UsuarioId",
                principalSchema: "public",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auditoria_Usuario_UsuarioId",
                table: "Auditoria");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Auditoria",
                table: "Auditoria");

            migrationBuilder.RenameTable(
                name: "OrcamentoDentesRemovido",
                schema: "dev",
                newName: "OrcamentoDentesRemovido");

            migrationBuilder.RenameTable(
                name: "Auditoria",
                newName: "Auditorias");

            migrationBuilder.RenameIndex(
                name: "IX_Auditoria_UsuarioId",
                table: "Auditorias",
                newName: "IX_Auditorias_UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Auditorias",
                table: "Auditorias",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Anamneses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Titulo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anamneses", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Auditorias_Usuario_UsuarioId",
                table: "Auditorias",
                column: "UsuarioId",
                principalSchema: "public",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}