using DominiosRicos.Dominio.Enumerados;
using DominiosRicos.Shared.ValueObjects;

namespace DominiosRicos.Dominio.ValueObjects
{
    public class Comissao : ValueObject
    {
        public decimal Valor { get; private set; }
        public TipoComissao Tipo { get; private set; }

        public Comissao(decimal valor, TipoComissao tipo)
        {
            Valor = valor;
            Tipo = tipo;
        }

        public override string ToString()
        {
            return Tipo == TipoComissao.Valor ? $"R$ {Valor.ToString("d")}" : $"{Valor.ToString("d")}%";
        }
    }
}