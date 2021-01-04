using DominiosRicos.Dominio.ValueObjects;
using DominiosRicos.Shared.Entities;
using System;

namespace DominiosRicos.Dominio.Entidades
{
    public class OrcamentoProcedimento : Entity
    {
        public string Descricao { get; set; }
        public Guid ProcedimentoId { get; set; }
        public virtual Procedimento Procedimento { get; set; }
        public Guid OrcamentoId { get; set; }
        public virtual Orcamento Orcamento { get; set; }
        public virtual Periodo Periodo { get; set; }
        public virtual Dente Dente { get; set; }
        public Guid DentistaId { get; set; }
        public virtual Dentista Dentista { get; set; }
        public string Observacao { get; set; }

        public OrcamentoProcedimento() : base(default)
        {
        }

        public OrcamentoProcedimento(Guid id,
            string descricao,
            Guid procedimentoId,
            Procedimento procedimento,
            Guid orcamentoId,
            Orcamento orcamento,
            Periodo periodo,
            Dente dente,
            Guid dentistaId,
            Dentista dentista,
            string observacao) : base(id)
        {
            Descricao = descricao;
            ProcedimentoId = procedimentoId;
            Procedimento = procedimento;
            OrcamentoId = orcamentoId;
            Orcamento = orcamento;
            Periodo = periodo;
            Dente = dente;
            DentistaId = dentistaId;
            Dentista = dentista;
            Observacao = observacao;
        }
    }
}