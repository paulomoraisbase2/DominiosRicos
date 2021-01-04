using DominiosRicos.Dominio.Contratos;
using DominiosRicos.Dominio.Entidades;
using DominiosRicos.Dominio.ModelosVisualizacao;
using DominiosRicos.Dominio.ValueObjects;
using DominiosRicos.Repositorio.Contexto;

namespace DominiosRicos.Repositorio.Repositorios
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(DominiosRicosContexto DominiosRicosContexto, AuthenticatedUser user) : base(DominiosRicosContexto, user)
        {
        }

        public bool isEmailUniq(Email email)
        {
            var user = this.GetSingle(u => u.Email == email);
            return user == null;
        }

        public bool IsUsernameUniq(string nome)
        {
            var user = this.GetSingle(u => u.Nome == nome);
            return user == null;
        }

        public bool isSchemaUniq(string Schema)
        {
            var user = this.GetSingle(u => u.Clinica.Schema == Schema);
            return user == null;
        }
    }
}