using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DominiosRicos.Repositorio.Migrations
{
    public partial class Atualizacao28011 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusOrcamento",
                schema: "dev",
                table: "Orcamento");

            migrationBuilder.AddColumn<DateTime>(
                name: "Aprovado",
                schema: "dev",
                table: "Orcamento",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "status",
                schema: "dev",
                table: "Orcamento",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aprovado",
                schema: "dev",
                table: "Orcamento");

            migrationBuilder.DropColumn(
                name: "status",
                schema: "dev",
                table: "Orcamento");

            migrationBuilder.AddColumn<int>(
                name: "StatusOrcamento",
                schema: "dev",
                table: "Orcamento",
                nullable: false,
                defaultValue: 0);
        }
    }
}