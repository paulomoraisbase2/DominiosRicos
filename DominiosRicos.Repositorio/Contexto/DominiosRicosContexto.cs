using DominiosRicos.Dominio.ModelosVisualizacao;
using DominiosRicos.Repositorio.Config;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace DominiosRicos.Repositorio.Contexto
{
    public interface IDbContextSchema
    {
        string Schema { get; }
    }

    public class DominiosRicosContexto : DbContext
    {
        public string Schema { get; set; }

        //public DbSet<Usuario> Usuarios { get; set; }
        //public DbSet<Auditoria> Auditorias { get; set; }
        //public DbSet<Clinica> Clinicas { get; set; }
        //public DbSet<ClinicaTelefone> ClinicaTelefones { get; set; }
        //public DbSet<Paciente> Pacientes { get; set; }
        //public DbSet<PacienteTelefone> PacienteTelefones { get; set; }
        //public DbSet<UsuarioTelefone> UsuarioTelefones { get; set; }
        //public DbSet<Orcamento> Orcamentos { get; set; }
        //public DbSet<Anamnese> Anamneses { get; set; }
        //public DbSet<Procedimento> Procedimentos { get; set; }
        //public DbSet<ProcedimentoUsuario> ProcedimentoDentistas { get; set; }
        //public DbSet<Dentista> Dentistas { get; set; }
        //public DbSet<DentistaTelefone> DentistaTelefones { get; set; }
        //public DbSet<DentistaTelefone> DentistaTelefones { get; set; }
        //public DominiosRicosContexto(DbContextOptions options, IDbContextSchema schema = null, AuthenticatedUser user = null) : base(options)
        public DominiosRicosContexto(DbContextOptions options, AuthenticatedUser user = null) : base(options)
        {
            try
            {
                Schema = user.Schema;
            }
            catch
            {
                Schema = "dev";
            }
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            modelBuilder.ApplyConfiguration(new ClinicaConfiguracao());
            modelBuilder.ApplyConfiguration(new ClinicaTelefoneConfiguracao());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguracao());
            modelBuilder.ApplyConfiguration(new UsuarioTelefoneConfiguracao());

            modelBuilder.ApplyConfiguration(new PacienteConfiguracao(Schema));
            modelBuilder.ApplyConfiguration(new PacienteTelefoneConfiguracao(Schema));
            modelBuilder.ApplyConfiguration(new ProcedimentoConfiguracao(Schema));
            modelBuilder.ApplyConfiguration(new ProcedimentoUsuarioConfiguracao(Schema));
            modelBuilder.ApplyConfiguration(new OrcamentoConfiguracao(Schema));
            modelBuilder.ApplyConfiguration(new DentistaConfiguracao(Schema));
            modelBuilder.ApplyConfiguration(new DentistaTelefoneConfiguracao(Schema));
            modelBuilder.ApplyConfiguration(new OrcamentoProcedimentoConfiguracao(Schema));
            modelBuilder.ApplyConfiguration(new OrcamentoComentarioConfiguracao(Schema));
            modelBuilder.ApplyConfiguration(new OrcamentoDentesRemovidoConfiguracao(Schema));

            base.OnModelCreating(modelBuilder);
        }
    }
}