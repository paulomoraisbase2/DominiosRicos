using DominiosRicos.Dominio.ValueObjects;
using DominiosRicos.Shared.Entities;
using System;

namespace DominiosRicos.Dominio.Entidades
{
    public class OrcamentoComentario : Entity
    {
        public Guid OrcamentoId { get; set; }
        public virtual Orcamento Orcamento { get; set; }
        public int Dente { get; set; }
        public virtual Data Data { get; set; }
        public string Comentario { get; set; }

        public OrcamentoComentario() : base(default)
        {
        }

        public OrcamentoComentario(Guid id, Guid orcamentoId, Orcamento orcamento, int dente, Data data, string comentario) : base(id)
        {
            OrcamentoId = orcamentoId;
            Orcamento = orcamento;
            Dente = dente;
            Data = data;
            Comentario = comentario;
        }
    }
}