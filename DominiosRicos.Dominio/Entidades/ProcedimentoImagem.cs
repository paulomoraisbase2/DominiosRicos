using DominiosRicos.Dominio.ValueObjects;
using DominiosRicos.Shared.Entities;
using System;

namespace DominiosRicos.Dominio.Entidades
{
    public class ProcedimentoImagem : Entity
    {
        public Guid ProcedimentoId { get; private set; }
        public virtual Procedimento Procedimento { get; private set; }
        public virtual Imagem Imagem { get; private set; }

        public ProcedimentoImagem() : base(default)
        {
        }

        public ProcedimentoImagem(Guid procedimentoId, Imagem imagem) : base(default)
        {
            ProcedimentoId = procedimentoId;
            Imagem = imagem;
        }

        public void AtualizaImagem(string imagem)
        {
            Imagem = new Imagem(imagem);
        }
    }
}