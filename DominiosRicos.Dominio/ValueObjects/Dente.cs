using DominiosRicos.Dominio.Enumerados;
using DominiosRicos.Shared.ValueObjects;

namespace DominiosRicos.Dominio.ValueObjects
{
    public class Dente : ValueObject
    {
        public Dentes.Quadrante Quadrante { get; private set; }
        public Dentes.Posicao Posicao { get; private set; }
        public Dentes.Tipo Tipo { get; private set; }

        public Dente(Dentes.Quadrante quadrante, Dentes.Posicao posicao, Dentes.Tipo tipo)
        {
            Quadrante = quadrante;
            Posicao = posicao;
            Tipo = tipo;
        }

        public override string ToString()
        {
            return $"{(int)Quadrante + (int)Tipo}{(int)Posicao}";
        }
    }
}