using DominiosRicos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DominiosRicos.Repositorio.Config
{
    public class DentistaTelefoneConfiguracao : IEntityTypeConfiguration<DentistaTelefone>
    {
        private readonly string _schema;

        public DentistaTelefoneConfiguracao(string schema)
        {
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<DentistaTelefone> builder)
        {
            if (!string.IsNullOrWhiteSpace(_schema))
                builder.ToTable(nameof(DentistaTelefone), _schema);

            builder
               .HasKey(u => u.Id);

            builder.OwnsOne(ct => ct.Telefone, t =>
            {
                t.Property(v => v.Numero);
                t.Property(v => v.Regiao);
                t.Property(v => v.Tipo);
            });
        }
    }
}