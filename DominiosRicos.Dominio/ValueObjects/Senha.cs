using CryptoHelper;
using DominiosRicos.Shared.ValueObjects;
using Flunt.Validations;

namespace DominiosRicos.Dominio.ValueObjects
{
    public class Senha : ValueObject
    {
        public string Valor { get; private set; }

        public Senha(string valor)
        {
            var propriedade = "Senha";
            AddNotifications(new Contract()
            .Requires()
            .IsNotNullOrEmpty(valor, propriedade, "Senha inválida")
            .HasMinLen(valor, 6, propriedade, "A Senha deve conter mais de seis Digitos"));

            if (Valid)
                Valor = valor;
        }

        public string HashPassword()
        {
            return Crypto.HashPassword(Valor);
        }
    }
}