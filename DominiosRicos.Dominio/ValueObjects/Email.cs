using DominiosRicos.Shared.ValueObjects;
using Flunt.Validations;

namespace DominiosRicos.Dominio.ValueObjects
{
    public class Email : ValueObject
    {
        public string Endereco { get; private set; }

        public Email(string endereco)
        {
            AddNotifications(new Contract()
               .Requires()
               .IsEmail(endereco, "Email", "E-mail inválido")
           //.IsNotNullOrEmpty(endereco, "Email.Endereco", "E-mail não informado")
           );
            if (Valid)
                Endereco = endereco;
        }
    }
}