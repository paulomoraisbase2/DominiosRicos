using DominiosRicos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DominiosRicos.Repositorio.Config
{
    internal class PacienteConfiguracao : IEntityTypeConfiguration<Paciente>
    {
        private readonly string _schema;

        public PacienteConfiguracao(string schema)
        {
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            if (!string.IsNullOrWhiteSpace(_schema))
                builder.ToTable(nameof(Paciente), _schema);

            builder
                .HasKey(p => p.Id);
            builder
                .Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(180);

            builder.OwnsOne(p => p.Endereco, e =>
                {
                    e.Property(p => p.Cep)
                        .HasMaxLength(10);

                    e.Property(p => p.Logradouro)
                        .HasMaxLength(180);

                    e.Property(p => p.Numero);

                    e.Property(p => p.Complemento)
                        .HasMaxLength(50);

                    e.Property(p => p.Bairro)
                        .HasMaxLength(100);

                    e.Property(p => p.Cidade)
                    .HasMaxLength(100);

                    e.Property(p => p.Estado)
                        .HasMaxLength(100);

                    e.Property(p => p.Pais)
                        .HasMaxLength(100);
                });

            builder.OwnsOne(p => p.Email, e =>
                {
                    e.Property(p => p.Endereco)
                  .HasMaxLength(180);
                });

            builder.OwnsOne(p => p.Cpf, e =>
            {
                e.Property(p => p.Tipo);
                e.Property(p => p.NRegistro);
            });
            builder.OwnsOne(p => p.RegistroGeral, e =>
            {
                e.Property(p => p.Tipo);
                e.Property(p => p.NRegistro);
            });
        }
    }
}