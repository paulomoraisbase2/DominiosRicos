using DenteFlix.Dominio.Enumerados;
using System;

namespace DenteFlix.Dominio.Entidades
{
    public class Dente
    {
        public Guid Id { get; set; }
        public Dentes.TipoDenticao Tipo { get; set; }
        public Dentes.Quadrante Quadrante { get; set; }
        public Dentes.Posicao Posicao { get; set; }

    }
}
