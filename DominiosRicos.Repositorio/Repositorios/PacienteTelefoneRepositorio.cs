using DominiosRicos.Dominio.Contratos;
using DominiosRicos.Dominio.Entidades;
using DominiosRicos.Dominio.ModelosVisualizacao;
using DominiosRicos.Repositorio.Contexto;

namespace DominiosRicos.Repositorio.Repositorios
{
    public class PacienteTelefoneRepositorio : BaseRepositorio<PacienteTelefone>, IPacienteTelefoneRepositorio
    {
        public PacienteTelefoneRepositorio(DominiosRicosContexto DominiosRicosContexto, AuthenticatedUser user) : base(DominiosRicosContexto, user)
        {
        }
    }
}