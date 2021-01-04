using DominiosRicos.Repositorio.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DominiosRicos.Repositorio.Servicos
{
    public class ChaveSchema : IModelCacheKeyFactory
    {
        public object Create(DbContext context)
        {
            return new
            {
                Type = context.GetType(),
                Schema = context is DominiosRicosContexto schema ? schema.Schema : "dev"
            };
        }
    }
}