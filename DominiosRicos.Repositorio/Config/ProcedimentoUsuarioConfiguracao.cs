using DominiosRicos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DominiosRicos.Repositorio.Config
{
    internal class ProcedimentoUsuarioConfiguracao : IEntityTypeConfiguration<ProcedimentoUsuario>
    {
        private readonly string _schema;

        public ProcedimentoUsuarioConfiguracao(string schema)
        {
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<ProcedimentoUsuario> builder)
        {
            if (!string.IsNullOrWhiteSpace(_schema))
                builder.ToTable(nameof(ProcedimentoUsuario), _schema);

            builder
                .HasKey(p => p.Id);
        }
    }
}