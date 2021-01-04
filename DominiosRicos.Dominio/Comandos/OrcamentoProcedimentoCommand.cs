using DominiosRicos.Dominio.Entidades;
using DominiosRicos.Dominio.ValueObjects;
using System;

namespace DominiosRicos.Dominio.Comandos
{
    public class OrcamentoProcedimentoCommand : OrcamentoProcedimento
    {
        public OrcamentoProcedimentoCommand(Guid id, string descricao, Guid procedimentoId, Procedimento procedimento, Guid orcamentoId, Orcamento orcamento, Periodo periodo, Dente dente, Guid dentistaId, Dentista dentista, string observacao) : base(id, descricao, procedimentoId, procedimento, orcamentoId, orcamento, periodo, dente, dentistaId, dentista, observacao)
        {
        }
    }
}