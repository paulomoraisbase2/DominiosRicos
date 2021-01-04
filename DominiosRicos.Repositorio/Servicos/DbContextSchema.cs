using DominiosRicos.Dominio.ModelosVisualizacao;
using DominiosRicos.Repositorio.Contexto;

namespace DominiosRicos.Repositorio.Servicos
{
    public class DbContextSchema : IDbContextSchema
    {
        public string Schema { get; }

        public DbContextSchema(AuthenticatedUser user)
        {
            Schema = user.Schema;
        }
    }
}