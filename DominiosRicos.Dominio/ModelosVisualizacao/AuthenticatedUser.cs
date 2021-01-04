using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace DominiosRicos.Dominio.ModelosVisualizacao
{
    public class AuthenticatedUser
    {
        private readonly IHttpContextAccessor _accessor;

        public AuthenticatedUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public Guid UsuarioId => Guid.TryParse(GetClaimsIdentity().FirstOrDefault(a => a.Type == "Id")?.Value, out Guid id) ? id : Guid.NewGuid();
        public string Name => GetClaimsIdentity().FirstOrDefault(a => a.Type == "Nome")?.Value;
        public string Schema => GetClaimsIdentity().FirstOrDefault(a => a.Type == "Schema")?.Value ?? "dev";

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }
    }
}