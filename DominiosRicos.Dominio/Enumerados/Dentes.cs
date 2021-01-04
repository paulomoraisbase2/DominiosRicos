using System;
using System.Collections.Generic;
using System.Linq;

namespace DominiosRicos.Dominio.Enumerados
{
    public class Dentes
    {
        public enum Tipo
        {
            Permanentes = 0,
            Deciduos = 4
        }

        public enum Quadrante
        {
            Primeiro = 1,
            Segundo = 2,
            Terceiro = 3,
            Quarto = 4
        }

        public enum Posicao
        {
            Incisivos_centrais = 1,
            Incisivos_laterais = 2,
            Caninos = 3,
            Primeiro_pre_molar = 4,
            Segundo_pre_molar = 5,
            Primeiro_molar = 6,
            Segundo_molar = 7,
            Terceiro_molar = 8
        }

        public static List<T> PosicaoDente<T>()
        {
            return ((T[])Enum.GetValues(typeof(T))).ToList();
        }
    }
}