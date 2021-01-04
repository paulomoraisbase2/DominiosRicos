using DominiosRicos.Dominio.Action;
using DominiosRicos.Shared.ValueObjects;

namespace DominiosRicos.Dominio.ValueObjects
{
    public class Telefone : ValueObject
    {
        public string Regiao { get; private set; }
        public string Numero { get; private set; }
        public string Tipo { get; private set; }

        public Telefone(string regiao, string numero, string tipo)
        {
            Regiao = regiao;
            Numero = numero;
            Tipo = tipo;
        }

        public override string ToString()
        {
            return $"{Numero.MascaraTelefone()} ({Tipo})";
        }
    }
}