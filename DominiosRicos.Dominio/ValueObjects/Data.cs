using DominiosRicos.Shared.ValueObjects;
using Flunt.Validations;
using System;

namespace DominiosRicos.Dominio.ValueObjects
{
    public class Data : ValueObject
    {
        public DateTime? Date { get; private set; }

        public Data(DateTime? date)
        {
            validaData(date);
        }

        public Data(string date)
        {
            validaData(DateTime.TryParse(date, out DateTime data) ? data : default);
        }

        private void validaData(DateTime? date)
        {
            AddNotifications(new Contract()
               .Requires()
               .IsNotNull(date, "Data.Date", "A data está vazia")
               );
            if (Valid)
            {
                AddNotifications(new Contract()
                    .Requires()
                    .IsBetween(date.Value, new DateTime(2000, 1, 1), new DateTime(2030, 1, 1), "Data.Date", "A data está fora dos periodo permitido")
                );
                Date = date.Value;
            }
        }

        public override string ToString()
        {
            return Date.HasValue ? Date.Value.ToString("dd/MM/yyyy") : "";
        }
    }
}