using DominiosRicos.Shared.ValueObjects;
using Flunt.Validations;

namespace DominiosRicos.Dominio.ValueObjects
{
    public class Imagem : ValueObject
    {
        public string Base64 { get; private set; }

        public Imagem(string base64)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(base64, "Imagem.Base64", "A Imagem não foi Reconhecida"));
            if (Valid)
                Base64 = base64;
        }
    }
}