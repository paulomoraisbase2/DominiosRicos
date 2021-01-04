using DominiosRicos.Dominio.Entidades;
using DominiosRicos.Dominio.ValueObjects;
using System;

namespace DominiosRicos.Dominio.Comandos
{
    public class OrcamentoComentarioCommand : OrcamentoComentario
    {
        public OrcamentoComentarioCommand(Guid id,
            Guid orcamentoId,
            Orcamento orcamento,
            int dente,
            Data data,
            string comentario) : base(id, orcamentoId, orcamento, dente, data, comentario)
        {
        }
    }
}