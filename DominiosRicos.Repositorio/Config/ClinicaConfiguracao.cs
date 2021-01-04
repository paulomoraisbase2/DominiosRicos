using DominiosRicos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DominiosRicos.Repositorio.Config
{
    internal class ClinicaConfiguracao : IEntityTypeConfiguration<Clinica>
    {
        public void Configure(EntityTypeBuilder<Clinica> builder)
        {
            builder.ToTable(nameof(Clinica), "public");

            builder
              .HasKey(c => c.Id);

            builder
                .Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(180);

            builder
                          .OwnsOne(c => c.Periodo, p =>
                          {
                              p
                               .Property(i => i.Inicial)
                               .HasColumnName("InicioUso");

                              p
                               .Property(f => f.Final)
                               .HasColumnName("FinalUso");
                          });

            builder
               .OwnsOne(p => p.Email, od =>
               {
                   od
                    .Property(p => p.Endereco)
                    .HasMaxLength(180);
               });

            builder
               .OwnsOne(p => p.Endereco, e =>
              {
                  e
                  .Property(c => c.Cep)
                  .HasMaxLength(20);
                  e
                      .Property(c => c.Logradouro)
                      .HasMaxLength(200);
                  e
                      .Property(c => c.Numero);
                  e
                      .Property(c => c.Complemento)
                      .HasMaxLength(50);
                  e
                      .Property(c => c.Bairro)
                      .HasMaxLength(100);
                  e
                      .Property(c => c.Cidade)
                      .HasMaxLength(100);
                  e
                      .Property(c => c.Estado)
                      .HasMaxLength(100);
                  e
                      .Property(c => c.Pais)
                      .HasMaxLength(100);
              });
        }
    }
}