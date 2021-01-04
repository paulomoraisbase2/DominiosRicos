using DominiosRicos.Dominio.Contratos;
using DominiosRicos.Dominio.Entidades;
using DominiosRicos.Dominio.ModelosVisualizacao;
using DominiosRicos.Repositorio.Contexto;

namespace DominiosRicos.Repositorio.Repositorios
{
    public class UsuarioTelefoneRepositorio : BaseRepositorio<UsuarioTelefone>, IUsuarioTelefoneRepositorio
    {
        public UsuarioTelefoneRepositorio(DominiosRicosContexto DominiosRicosContexto, AuthenticatedUser user) : base(DominiosRicosContexto, user)
        {
        }
    }
}