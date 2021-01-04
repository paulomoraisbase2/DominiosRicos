using DominiosRicos.Dominio.Entidades;
using DominiosRicos.Dominio.Enumerados;
using DominiosRicos.Dominio.ValueObjects;
using System;
using System.Collections.Generic;

namespace DominiosRicos.Dominio.Comandos
{
    public class OrcamentoCommand : Orcamento
    {
        public OrcamentoCommand(Guid id,
            Guid pacienteId,
            string tratamento,
            Periodo periodo,
            DateTime? aprovado,
            Status status,
            Guid? dentistaId,
             string tipoDenticao,
            bool rascunho,
            ICollection<OrcamentoProcedimentoCommand> orcamentoProcedimentos,
            ICollection<OrcamentoComentarioCommand> orcamentoComentarios,
            ICollection<OrcamentoDentesRemovidoCommand> orcamentoDentesRemovidos) :
            base(id,
                pacienteId,
                tratamento,
                periodo,
                aprovado,
                status,
                dentistaId,
                tipoDenticao,
                rascunho)
        {
            foreach (var item in orcamentoDentesRemovidos)
            {
                AddDentesRemovidos(item);
            }
            //foreach (var item in orcamentoProcedimentos)
            //{
            //    AddProcedimentos(item);
            //}
            //foreach (var item in orcamentoComentarios)
            //{
            //    AddComentarios(item);
            //}
        }
    }
}