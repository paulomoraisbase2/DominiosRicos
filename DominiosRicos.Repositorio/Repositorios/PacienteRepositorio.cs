using DominiosRicos.Dominio.Contratos;
using DominiosRicos.Dominio.Entidades;
using DominiosRicos.Dominio.ModelosVisualizacao;
using DominiosRicos.Dominio.ValueObjects;
using DominiosRicos.Repositorio.Contexto;

namespace DominiosRicos.Repositorio.Repositorios
{
    public class PacienteRepositorio : BaseRepositorio<Paciente>, IPacienteRepositorio
    {
        public PacienteRepositorio(DominiosRicosContexto DominiosRicosContexto, AuthenticatedUser user) : base(DominiosRicosContexto, user)
        {
        }

        public bool isEmailUniq(Email email)
        {
            var user = this.GetSingle(p => p.Email.Endereco == email.Endereco);
            return user == null;
        }
    }
}