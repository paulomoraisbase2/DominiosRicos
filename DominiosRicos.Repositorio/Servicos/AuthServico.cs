using DominiosRicos.Dominio.Action;
using DominiosRicos.Dominio.Contratos;
using DominiosRicos.Dominio.ModelosVisualizacao;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DominiosRicos.Repositorio.Servicos
{
    public class AuthServico : IAuthServico
    {
        public string jwtSecret { get; private set; }
        public int jwtLifespan { get; private set; }

        public AuthServico(string jwtSecret, int jwtLifespan)
        {
            this.jwtSecret = jwtSecret;
            this.jwtLifespan = jwtLifespan;
        }

        public AuthDataView GetAuthData(Guid id, string nome, string Schema)
        {
            var expirationTime = DateTime.UtcNow.AddSeconds(jwtLifespan);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Nome", nome.FDoisNomes()),
                    new Claim("Id", id.ToString()),
                    new Claim("Schema", Schema)
                }),
                Expires = expirationTime,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret)),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

            return new AuthDataView(
                token,
                ((DateTimeOffset)expirationTime).ToUnixTimeSeconds(),
                id
            );
        }
    }
}