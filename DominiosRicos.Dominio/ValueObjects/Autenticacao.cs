using CryptoHelper;
using DominiosRicos.Shared.ValueObjects;
using Flunt.Validations;

namespace DominiosRicos.Dominio.ValueObjects
{
    public class Autenticacao : ValueObject
    {
        public Email Email { get; set; }
        public Senha Senha { get; set; }

        public Autenticacao(Email email, Senha senha)
        {
            AddNotifications(senha, email);
            Email = email;
            Senha = senha;
        }

        public void SenhaValida(string senha)
        {
            AddNotifications(new Contract()
            .Requires()
            .IsTrue(Crypto.VerifyHashedPassword(senha, Senha.Valor), "Senha.Valor", "Senha incorreta"));
        }
    }
}