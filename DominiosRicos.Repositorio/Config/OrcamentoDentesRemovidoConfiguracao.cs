using DominiosRicos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DominiosRicos.Repositorio.Config
{
    public class OrcamentoDentesRemovidoConfiguracao : IEntityTypeConfiguration<OrcamentoDentesRemovido>
    {
        private readonly string _schema;

        public OrcamentoDentesRemovidoConfiguracao(string schema)
        {
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<OrcamentoDentesRemovido> builder)
        {
            if (!string.IsNullOrWhiteSpace(_schema))
                builder.ToTable(nameof(OrcamentoDentesRemovido), _schema);

            builder.HasKey(p => p.Id);
        }
    }
}