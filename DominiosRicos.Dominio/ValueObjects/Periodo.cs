using DominiosRicos.Shared.ValueObjects;
using Flunt.Validations;
using System;

namespace DominiosRicos.Dominio.ValueObjects
{
    public class Periodo : ValueObject
    {
        public DateTime Inicial { get; private set; }
        public DateTime? Final { get; private set; }

        public Periodo(DateTime inicial, DateTime? final)
        {
            AddNotifications(new Contract().Requires().IsNotNull(inicial, "Periodo.Inicial", "Informe a dataInicial"));
            Inicial = inicial;
            Final = final;
        }
    }
}