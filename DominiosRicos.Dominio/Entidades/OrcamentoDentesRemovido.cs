using DominiosRicos.Shared.Entities;
using System;

namespace DominiosRicos.Dominio.Entidades
{
    public class OrcamentoDentesRemovido : Entity
    {
        public Guid OrcamentoId { get; private set; }
        public virtual Orcamento Orcamento { get; private set; }
        public int Dente { get; private set; }

        public OrcamentoDentesRemovido() : base(default)
        {
        }

        public OrcamentoDentesRemovido(Guid id, Guid orcamentoId, int dente) : base(id)
        {
            OrcamentoId = orcamentoId;
            Dente = dente;
        }
    }
}