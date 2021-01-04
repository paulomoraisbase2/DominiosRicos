using DominiosRicos.Dominio.ValueObjects;
using DominiosRicos.Shared.ValueObjects;

namespace DominiosRicos.Dominio.ModelosVisualizacao
{
    public class RegistroView : ValueObject
    {
        public string Nome { get; private set; }

        public Email Email { get; private set; }

        public Senha Senha { get; private set; }

        public RegistroView(string nome, Email email, Senha senha)
        {
            AddNotifications(email, senha);
            Nome = nome;
            Email = email;
            Senha = senha;
        }
    }
}