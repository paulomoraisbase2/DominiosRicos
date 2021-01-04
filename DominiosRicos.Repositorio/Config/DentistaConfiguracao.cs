using DominiosRicos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DominiosRicos.Repositorio.Config
{
    public class DentistaConfiguracao : IEntityTypeConfiguration<Dentista>
    {
        private readonly string _schema;

        public DentistaConfiguracao(string schema)
        {
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<Dentista> builder)
        {
            if (!string.IsNullOrWhiteSpace(_schema))
                builder.ToTable(nameof(Dentista), _schema);

            builder
                .HasKey(u => u.Id);

            builder
                .Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(180);
            builder
                .OwnsOne(u => u.Documento, d =>
                {
                    d.Property(u => u.Tipo);
                    d.Property(u => u.NRegistro)
                        .HasMaxLength(180);
                });

            builder
                .OwnsOne(u => u.Endereco, e =>
                {
                    e.Property(u => u.Cep)
                        .HasMaxLength(20);
                    e.Property(u => u.Logradouro)
                        .HasMaxLength(200);
                    e.Property(u => u.Numero);
                    e.Property(u => u.Complemento)
                        .HasMaxLength(50);
                    e.Property(u => u.Bairro)
                        .HasMaxLength(100);
                    e.Property(u => u.Cidade)
                        .HasMaxLength(100);
                    e.Property(u => u.Estado)
                        .HasMaxLength(100);
                    e.Property(u => u.Pais)
                        .HasMaxLength(100);
                });

            builder.OwnsOne(u => u.Email, e =>
            {
                e.Property(p => p.Endereco)
                    .HasMaxLength(180);
            });
        }
    }
}