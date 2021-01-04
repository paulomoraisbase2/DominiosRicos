using DenteFlix.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DenteFlix.Repositorio.Config
{
    class ConvenioConfiguracao : IEntityTypeConfiguration<Convenio>
    {
        private readonly string _schema;
        public ConvenioConfiguracao(string schema)
        {
            _schema = schema;
        }
        public void Configure(EntityTypeBuilder<Convenio> builder)
        {
            if (!string.IsNullOrWhiteSpace(_schema))
                builder.ToTable(nameof(Convenio), _schema);

            builder
                .HasKey(p => p.Id);
            builder
                .Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(180);
        }
    }
}
