using DominiosRicos.Dominio.Entidades;
using System;

namespace DominiosRicos.Dominio.Comandos
{
    public class OrcamentoDentesRemovidoCommand : OrcamentoDentesRemovido
    {
        public OrcamentoDentesRemovidoCommand(Guid id, Guid orcamentoId, int dente) : base(id, orcamentoId, dente)
        {
        }
    }
}