using DominiosRicos.Dominio.Contratos;
using DominiosRicos.Dominio.Entidades;
using DominiosRicos.Dominio.ModelosVisualizacao;
using DominiosRicos.Dominio.ValueObjects;
using DominiosRicos.Repositorio.Contexto;

namespace DominiosRicos.Repositorio.Repositorios
{
    public class ClinicaRepositorio : BaseRepositorio<Clinica>, IClinicaRepositorio
    {
        public ClinicaRepositorio(DominiosRicosContexto DominiosRicosContexto, AuthenticatedUser user) : base(DominiosRicosContexto, user)
        {
        }

        public bool SchemaExiste(string Schema)
        {
            return this.GetSingle(u => u.Schema == Schema) != null;
        }

        public Usuario GetUsuario(Email email)
        {
            return this.Usuario(email);
        }

        public bool EmailExiste(Email Email)
        {
            return this.GetSingle(u => u.Email == Email) != null;
        }
    }
}