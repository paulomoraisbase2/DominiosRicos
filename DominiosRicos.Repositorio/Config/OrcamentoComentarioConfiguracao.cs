using DominiosRicos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DominiosRicos.Repositorio.Config
{
    public class OrcamentoComentarioConfiguracao : IEntityTypeConfiguration<OrcamentoComentario>
    {
        private readonly string _schema;

        public OrcamentoComentarioConfiguracao(string schema)
        {
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<OrcamentoComentario> builder)
        {
            if (!string.IsNullOrWhiteSpace(_schema))
                builder.ToTable(nameof(OrcamentoComentario), _schema);

            builder.HasKey(p => p.Id);

            builder.OwnsOne(p => p.Data, e =>
            {
                e.Property(p => p.Date).HasColumnName("DataComentario");
            });
        }
    }
}