using DominiosRicos.Dominio.Entidades;
using DominiosRicos.Dominio.ValueObjects;
using System;

namespace DominiosRicos.Dominio.Comandos
{
    public class ProcedimentoCommand : Procedimento
    {
        public ProcedimentoCommand(Guid id,
            string descricao,
            string categoria,
            decimal valor,
            string imagem,
            Comissao comissao) :
            base(id,
                descricao,
                categoria,
                valor,
                imagem,
                comissao)
        {
        }
    }
}