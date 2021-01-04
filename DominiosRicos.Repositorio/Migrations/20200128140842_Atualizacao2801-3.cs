using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DominiosRicos.Repositorio.Migrations
{
    public partial class Atualizacao28013 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orcamento_Dentista_DentistaId",
                schema: "dev",
                table: "Orcamento");

            migrationBuilder.AlterColumn<Guid>(
                name: "DentistaId",
                schema: "dev",
                table: "Orcamento",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Orcamento_Dentista_DentistaId",
                schema: "dev",
                table: "Orcamento",
                column: "DentistaId",
                principalSchema: "dev",
                principalTable: "Dentista",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orcamento_Dentista_DentistaId",
                schema: "dev",
                table: "Orcamento");

            migrationBuilder.AlterColumn<Guid>(
                name: "DentistaId",
                schema: "dev",
                table: "Orcamento",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orcamento_Dentista_DentistaId",
                schema: "dev",
                table: "Orcamento",
                column: "DentistaId",
                principalSchema: "dev",
                principalTable: "Dentista",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}