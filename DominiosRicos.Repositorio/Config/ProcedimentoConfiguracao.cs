using DominiosRicos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DominiosRicos.Repositorio.Config
{
    internal class ProcedimentoConfiguracao : IEntityTypeConfiguration<Procedimento>
    {
        private readonly string _schema;

        public ProcedimentoConfiguracao(string schema)
        {
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<Procedimento> builder)
        {
            if (!string.IsNullOrWhiteSpace(_schema))
                builder.ToTable(nameof(Procedimento), _schema);

            builder
                .HasKey(p => p.Id);
            builder
                .Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(400);

            builder.OwnsOne(p => p.Comissao, e =>
            {
                e.Property(p => p.Tipo);
                e.Property(p => p.Valor);
            });
        }
    }
}