using DominiosRicos.Dominio.Action;
using DominiosRicos.Dominio.Enumerados;
using DominiosRicos.Helper;
using DominiosRicos.Shared.ValueObjects;
using Flunt.Validations;

namespace DominiosRicos.Dominio.ValueObjects
{
    public class Documento : ValueObject
    {
        public TipoDocumento Tipo { get; set; }
        public string NRegistro { get; set; }

        public Documento(string nRegistro)
        {
            AddNotifications(new Contract()
                .Requires()
                );
            if (Valid)
            {
                ValidaCPF.Cpf validaCPF = nRegistro;
                ValidaCPF.ValidarCPF(validaCPF);
                if (validaCPF.EhValido)
                {
                    Tipo = TipoDocumento.CPF;
                }
                else
                {
                    Tipo = TipoDocumento.Outros;
                }

                NRegistro = nRegistro;
            }
        }

        public override string ToString()
        {
            return Tipo == TipoDocumento.CPF ? $"CPF: {NRegistro.MascaraCPF()}" : $"Documento: {NRegistro.ToString()}";
        }
    }
}