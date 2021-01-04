using DominiosRicos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DominiosRicos.Repositorio.Config
{
    internal class UsuarioTelefoneConfiguracao : IEntityTypeConfiguration<UsuarioTelefone>
    {
        public void Configure(EntityTypeBuilder<UsuarioTelefone> builder)
        {
            builder.ToTable(nameof(UsuarioTelefone), "public");

            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.UsuarioId)
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