using DominiosRicos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DominiosRicos.Repositorio.Config
{
    public class ClinicaTelefoneConfiguracao : IEntityTypeConfiguration<ClinicaTelefone>
    {
        public void Configure(EntityTypeBuilder<ClinicaTelefone> builder)
        {
            builder.ToTable(nameof(ClinicaTelefone), "public");
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