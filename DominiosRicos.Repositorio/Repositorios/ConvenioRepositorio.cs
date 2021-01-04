using DenteFlix.Dominio.Contratos;
using DenteFlix.Dominio.Entidades;
using DenteFlix.Dominio.ModelosVisualizacao;
using DenteFlix.Repositorio.Contexto;
using Microsoft.EntityFrameworkCore;

namespace DenteFlix.Repositorio.Repositorios
{
    public class ConvenioRepositorio : BaseRepositorio<Convenio>, IConvenioRepositorio
    {
        public ConvenioRepositorio(DenteFlixContexto denteFlixContexto, AuthenticatedUser user) : base(denteFlixContexto, user)
        {
        }
    }
}
