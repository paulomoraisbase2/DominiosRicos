using DominiosRicos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DominiosRicos.Repositorio.Config
{
    internal class PacienteTelefoneConfiguracao : IEntityTypeConfiguration<PacienteTelefone>
    {
        private readonly string _schema;

        public PacienteTelefoneConfiguracao(string schema)
        {
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<PacienteTelefone> builder)
        {
            if (!string.IsNullOrWhiteSpace(_schema))
                builder.ToTable(nameof(PacienteTelefone), _schema);

            builder
                .HasKey(p => p.Id);
            builder
                .Property(p => p.PacienteId)
                .IsRequired();

            builder.OwnsOne(p => p.Telefone, e =>
            {
                e.Property(p => p.Regiao);
                e.Property(p => p.Numero);
                e.Property(p => p.Tipo);
            });
        }
    }
}