using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DominiosRicos.Repositorio.Migrations
{
    public partial class ACargaInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.EnsureSchema(
                name: "dev");

            migrationBuilder.CreateTable(
                name: "Anamneses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Titulo = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anamneses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dentista",
                schema: "dev",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 180, nullable: false),
                    Documento_Tipo = table.Column<int>(nullable: false),
                    Documento_NRegistro = table.Column<string>(maxLength: 180, nullable: true),
                    Email_Endereco = table.Column<string>(maxLength: 180, nullable: true),
                    Endereco_Cep = table.Column<string>(maxLength: 20, nullable: true),
                    Endereco_Logradouro = table.Column<string>(maxLength: 200, nullable: true),
                    Endereco_Numero = table.Column<string>(nullable: true),
                    Endereco_Complemento = table.Column<string>(maxLength: 50, nullable: true),
                    Endereco_Bairro = table.Column<string>(maxLength: 100, nullable: true),
                    Endereco_Cidade = table.Column<string>(maxLength: 100, nullable: true),
                    Endereco_Estado = table.Column<string>(maxLength: 100, nullable: true),
                    Endereco_Pais = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dentista", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                schema: "dev",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 180, nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: true),
                    Genero = table.Column<int>(nullable: false),
                    Endereco_Cep = table.Column<string>(maxLength: 10, nullable: true),
                    Endereco_Logradouro = table.Column<string>(maxLength: 180, nullable: true),
                    Endereco_Numero = table.Column<string>(nullable: true),
                    Endereco_Complemento = table.Column<string>(maxLength: 50, nullable: true),
                    Endereco_Bairro = table.Column<string>(maxLength: 100, nullable: true),
                    Endereco_Cidade = table.Column<string>(maxLength: 100, nullable: true),
                    Endereco_Estado = table.Column<string>(maxLength: 100, nullable: true),
                    Endereco_Pais = table.Column<string>(maxLength: 100, nullable: true),
                    Email_Endereco = table.Column<string>(maxLength: 180, nullable: true),
                    RegistroGeral_Tipo = table.Column<int>(nullable: false),
                    RegistroGeral_NRegistro = table.Column<string>(nullable: true),
                    Cpf_Tipo = table.Column<int>(nullable: false),
                    Cpf_NRegistro = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Procedimento",
                schema: "dev",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 400, nullable: false),
                    Categoria = table.Column<string>(nullable: true),
                    Valor = table.Column<decimal>(nullable: false),
                    Imagem = table.Column<string>(nullable: true),
                    Comissao_Valor = table.Column<decimal>(nullable: false),
                    Comissao_Tipo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedimento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clinica",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 180, nullable: false),
                    Schema = table.Column<string>(nullable: true),
                    InicioUso = table.Column<DateTime>(nullable: false),
                    FinalUso = table.Column<DateTime>(nullable: true),
                    Email_Endereco = table.Column<string>(maxLength: 180, nullable: true),
                    Endereco_Cep = table.Column<string>(maxLength: 20, nullable: true),
                    Endereco_Logradouro = table.Column<string>(maxLength: 200, nullable: true),
                    Endereco_Numero = table.Column<string>(nullable: true),
                    Endereco_Complemento = table.Column<string>(maxLength: 50, nullable: true),
                    Endereco_Bairro = table.Column<string>(maxLength: 100, nullable: true),
                    Endereco_Cidade = table.Column<string>(maxLength: 100, nullable: true),
                    Endereco_Estado = table.Column<string>(maxLength: 100, nullable: true),
                    Endereco_Pais = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DentistaTelefone",
                schema: "dev",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DentistaId = table.Column<Guid>(nullable: false),
                    Telefone_Regiao = table.Column<string>(nullable: true),
                    Telefone_Numero = table.Column<string>(nullable: true),
                    Telefone_Tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DentistaTelefone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DentistaTelefone_Dentista_DentistaId",
                        column: x => x.DentistaId,
                        principalSchema: "dev",
                        principalTable: "Dentista",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orcamento",
                schema: "dev",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PacienteId = table.Column<Guid>(nullable: false),
                    Tratamento = table.Column<string>(nullable: true),
                    Periodo_Inicial = table.Column<DateTime>(nullable: false),
                    Periodo_Final = table.Column<DateTime>(nullable: true),
                    StatusOrcamento = table.Column<int>(nullable: false),
                    DentistaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orcamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orcamento_Dentista_DentistaId",
                        column: x => x.DentistaId,
                        principalSchema: "dev",
                        principalTable: "Dentista",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orcamento_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalSchema: "dev",
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PacienteTelefone",
                schema: "dev",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PacienteId = table.Column<Guid>(nullable: false),
                    Telefone_Regiao = table.Column<string>(nullable: true),
                    Telefone_Numero = table.Column<string>(nullable: true),
                    Telefone_Tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteTelefone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PacienteTelefone_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalSchema: "dev",
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClinicaTelefone",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClinicaId = table.Column<Guid>(nullable: false),
                    Telefone_Regiao = table.Column<string>(nullable: true),
                    Telefone_Numero = table.Column<string>(nullable: true),
                    Telefone_Tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicaTelefone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClinicaTelefone_Clinica_ClinicaId",
                        column: x => x.ClinicaId,
                        principalSchema: "public",
                        principalTable: "Clinica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClinicaId = table.Column<Guid>(nullable: false),
                    Grupo = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 180, nullable: false),
                    Senha = table.Column<string>(maxLength: 180, nullable: true),
                    Documento_Tipo = table.Column<int>(nullable: false),
                    Documento_NRegistro = table.Column<string>(maxLength: 180, nullable: true),
                    Email_Endereco = table.Column<string>(maxLength: 180, nullable: true),
                    Endereco_Cep = table.Column<string>(maxLength: 20, nullable: true),
                    Endereco_Logradouro = table.Column<string>(maxLength: 200, nullable: true),
                    Endereco_Numero = table.Column<string>(nullable: true),
                    Endereco_Complemento = table.Column<string>(maxLength: 50, nullable: true),
                    Endereco_Bairro = table.Column<string>(maxLength: 100, nullable: true),
                    Endereco_Cidade = table.Column<string>(maxLength: 100, nullable: true),
                    Endereco_Estado = table.Column<string>(maxLength: 100, nullable: true),
                    Endereco_Pais = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Clinica_ClinicaId",
                        column: x => x.ClinicaId,
                        principalSchema: "public",
                        principalTable: "Clinica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrcamentoComentario",
                schema: "dev",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrcamentoId = table.Column<Guid>(nullable: false),
                    Dente_Quadrante = table.Column<int>(nullable: false),
                    Dente_Posicao = table.Column<int>(nullable: false),
                    Dente_Tipo = table.Column<int>(nullable: false),
                    DataComentario = table.Column<DateTime>(nullable: true),
                    Comentario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrcamentoComentario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrcamentoComentario_Orcamento_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalSchema: "dev",
                        principalTable: "Orcamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrcamentoProcedimento",
                schema: "dev",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    ProcedimentoId = table.Column<Guid>(nullable: false),
                    OrcamentoId = table.Column<Guid>(nullable: false),
                    Periodo_Inicial = table.Column<DateTime>(nullable: false),
                    Periodo_Final = table.Column<DateTime>(nullable: true),
                    Dente_Quadrante = table.Column<int>(nullable: false),
                    Dente_Posicao = table.Column<int>(nullable: false),
                    Dente_Tipo = table.Column<int>(nullable: false),
                    DentistaId = table.Column<Guid>(nullable: false),
                    Observacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrcamentoProcedimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrcamentoProcedimento_Dentista_DentistaId",
                        column: x => x.DentistaId,
                        principalSchema: "dev",
                        principalTable: "Dentista",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrcamentoProcedimento_Orcamento_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalSchema: "dev",
                        principalTable: "Orcamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrcamentoProcedimento_Procedimento_ProcedimentoId",
                        column: x => x.ProcedimentoId,
                        principalSchema: "dev",
                        principalTable: "Procedimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Auditorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Acao = table.Column<string>(nullable: true),
                    NovoValor = table.Column<string>(nullable: true),
                    DataExecucao = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    RegistroId = table.Column<Guid>(nullable: false),
                    RegistroTabela = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auditorias_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "public",
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcedimentoUsuario",
                schema: "dev",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    VigenciaInicial = table.Column<DateTime>(nullable: false),
                    VigenciaFinal = table.Column<DateTime>(nullable: true),
                    Valor = table.Column<decimal>(nullable: false),
                    TipoComissao = table.Column<int>(nullable: false),
                    ProcedimentoId = table.Column<Guid>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedimentoUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcedimentoUsuario_Procedimento_ProcedimentoId",
                        column: x => x.ProcedimentoId,
                        principalSchema: "dev",
                        principalTable: "Procedimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcedimentoUsuario_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "public",
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioTelefone",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    Telefone_Regiao = table.Column<string>(nullable: true),
                    Telefone_Numero = table.Column<string>(nullable: true),
                    Telefone_Tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioTelefone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioTelefone_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "public",
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auditorias_UsuarioId",
                table: "Auditorias",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DentistaTelefone_DentistaId",
                schema: "dev",
                table: "DentistaTelefone",
                column: "DentistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamento_DentistaId",
                schema: "dev",
                table: "Orcamento",
                column: "DentistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamento_PacienteId",
                schema: "dev",
                table: "Orcamento",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrcamentoComentario_OrcamentoId",
                schema: "dev",
                table: "OrcamentoComentario",
                column: "OrcamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrcamentoProcedimento_DentistaId",
                schema: "dev",
                table: "OrcamentoProcedimento",
                column: "DentistaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrcamentoProcedimento_OrcamentoId",
                schema: "dev",
                table: "OrcamentoProcedimento",
                column: "OrcamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrcamentoProcedimento_ProcedimentoId",
                schema: "dev",
                table: "OrcamentoProcedimento",
                column: "ProcedimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteTelefone_PacienteId",
                schema: "dev",
                table: "PacienteTelefone",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcedimentoUsuario_ProcedimentoId",
                schema: "dev",
                table: "ProcedimentoUsuario",
                column: "ProcedimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcedimentoUsuario_UsuarioId",
                schema: "dev",
                table: "ProcedimentoUsuario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicaTelefone_ClinicaId",
                schema: "public",
                table: "ClinicaTelefone",
                column: "ClinicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_ClinicaId",
                schema: "public",
                table: "Usuario",
                column: "ClinicaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioTelefone_UsuarioId",
                schema: "public",
                table: "UsuarioTelefone",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anamneses");

            migrationBuilder.DropTable(
                name: "Auditorias");

            migrationBuilder.DropTable(
                name: "DentistaTelefone",
                schema: "dev");

            migrationBuilder.DropTable(
                name: "OrcamentoComentario",
                schema: "dev");

            migrationBuilder.DropTable(
                name: "OrcamentoProcedimento",
                schema: "dev");

            migrationBuilder.DropTable(
                name: "PacienteTelefone",
                schema: "dev");

            migrationBuilder.DropTable(
                name: "ProcedimentoUsuario",
                schema: "dev");

            migrationBuilder.DropTable(
                name: "ClinicaTelefone",
                schema: "public");

            migrationBuilder.DropTable(
                name: "UsuarioTelefone",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Orcamento",
                schema: "dev");

            migrationBuilder.DropTable(
                name: "Procedimento",
                schema: "dev");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Dentista",
                schema: "dev");

            migrationBuilder.DropTable(
                name: "Paciente",
                schema: "dev");

            migrationBuilder.DropTable(
                name: "Clinica",
                schema: "public");
        }
    }
}