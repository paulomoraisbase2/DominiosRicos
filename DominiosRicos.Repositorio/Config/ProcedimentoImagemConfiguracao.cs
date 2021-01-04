using DominiosRicos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DominiosRicos.Repositorio.Config
{
    public class ProcedimentoImagemConfiguracao : IEntityTypeConfiguration<ProcedimentoImagem>
    {
        private readonly string _schema;

        public ProcedimentoImagemConfiguracao(string schema)
        {
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<ProcedimentoImagem> builder)
        {
            if (!string.IsNullOrWhiteSpace(_schema))
                builder.ToTable(nameof(ProcedimentoImagem), _schema);

            builder
                .HasKey(p => p.Id);
            builder
                .OwnsOne(pi => pi.Imagem, i => { i.Property(b => b.Base64); });
        }
    }
}