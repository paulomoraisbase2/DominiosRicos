using DominiosRicos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DominiosRicos.Repositorio.Config
{
    public class OrcamentoConfiguracao : IEntityTypeConfiguration<Orcamento>
    {
        private readonly string _schema;

        public OrcamentoConfiguracao(string schema)
        {
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<Orcamento> builder)
        {
            if (!string.IsNullOrWhiteSpace(_schema))
                builder.ToTable(nameof(Orcamento), _schema);

            builder.HasKey(p => p.Id);

            builder.OwnsOne(p => p.Periodo, e =>
            {
                e.Property(p => p.Inicial);
                e.Property(p => p.Final);
            });
        }
    }
}