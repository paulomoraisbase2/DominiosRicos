using DominiosRicos.Shared.ValueObjects;
using System;

namespace DominiosRicos.Dominio.ValueObjects
{
    public class DataNull : ValueObject
    {
        public DateTime? Data { get; private set; }

        public DataNull(DateTime? data)
        {
            Data = data;
        }
    }
}