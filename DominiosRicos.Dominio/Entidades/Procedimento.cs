using DominiosRicos.Dominio.ValueObjects;
using DominiosRicos.Shared.Entities;
using System;

namespace DominiosRicos.Dominio.Entidades
{
    public class Procedimento : Entity
    {
        public string Descricao { get; private set; }
        public string Categoria { get; private set; }
        public decimal Valor { get; private set; }
        public string Imagem { get; private set; }
        public virtual Comissao Comissao { get; private set; }

        public Procedimento() : base(default)
        {
        }

        public Procedimento(Guid id, string descricao, string categoria, decimal valor, string imagem, Comissao comissao) : base(id)
        {
            Descricao = descricao;
            Categoria = categoria;
            Valor = valor;
            Imagem = imagem;
            Comissao = comissao;
        }
    }
}