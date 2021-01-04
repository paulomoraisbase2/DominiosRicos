using DominiosRicos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DominiosRicos.Repositorio.Config
{
    public class OrcamentoProcedimentoConfiguracao : IEntityTypeConfiguration<OrcamentoProcedimento>
    {
        private readonly string _schema;

        public OrcamentoProcedimentoConfiguracao(string schema)
        {
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<OrcamentoProcedimento> builder)
        {
            if (!string.IsNullOrWhiteSpace(_schema))
                builder.ToTable(nameof(OrcamentoProcedimento), _schema);

            builder.HasKey(p => p.Id);

            builder.OwnsOne(p => p.Periodo, e =>
            {
                e.Property(p => p.Inicial);
                e.Property(p => p.Final);
            });

            builder.OwnsOne(p => p.Dente, e =>
            {
                e.Property(p => p.Quadrante);
                e.Property(p => p.Tipo);
                e.Property(p => p.Posicao);
            });
        }
    }
}