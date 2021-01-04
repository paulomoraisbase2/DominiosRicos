using DominiosRicos.Shared.ValueObjects;
using System;

namespace DominiosRicos.Dominio.ModelosVisualizacao
{
    public class AuthDataView : ValueObject
    {
        public string Token { get; private set; }
        public long TokenExpirationTime { get; private set; }
        public Guid Id { get; private set; }

        public AuthDataView(string token, long tokenExpirationTime, Guid id)
        {
            Token = token;
            TokenExpirationTime = tokenExpirationTime;
            Id = id;
        }
    }
}