using DominiosRicos.Dominio.Contratos;
using DominiosRicos.Dominio.Entidades;
using DominiosRicos.Dominio.Enumerados;
using DominiosRicos.Dominio.ModelosVisualizacao;
using DominiosRicos.Dominio.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;

namespace DominiosRicos.Api.Controllers.Auth
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthServico _authServico;
        private IBaseRepositorio<Clinica> _clinica;
        private IBaseRepositorio<Usuario> _usuarios;

        public AuthController(IAuthServico authServico, IBaseRepositorio<Clinica> clinica, IBaseRepositorio<Usuario> usuarios)
        {
            _authServico = authServico;
            _clinica = clinica;
            _usuarios = usuarios;
        }

        [HttpPost("login")]
        public ActionResult<AuthDataView> Post([FromBody] Autenticacao model)
        {
            if (model.Invalid) return BadRequest(model.Notifications);

            Usuario user = _usuarios.GetSingle(u => u.Email.Endereco == model.Email.Endereco, u => u.Email);
            if (user == null)
            {
                model.AddNotification("Email", "O E-mail não consta em nossa base!");
                return BadRequest(model.Notifications);
            }
            model.SenhaValida(user.Senha);
            if (model.Invalid)
            {
                return BadRequest(model.Notifications);
            }

            return Ok(_authServico.GetAuthData(user.Id, user.Nome, user.Clinica.Schema));
        }

        [HttpPost("registro")]
        public ActionResult<AuthDataView> Post([FromBody] RegistroView model)
        {
            if (model.Invalid) return BadRequest(model.Notifications);

            var emailUniq = _usuarios.Any(e => e.Email.Endereco == model.Email.Endereco);
            if (emailUniq)
            {
                model.AddNotification("Email", "O E-mail já está em nossa base!");
                return BadRequest(model.Notifications);
            }

            var clinica = new Clinica(id: Guid.NewGuid(),
                descricao: model.Nome,
                email: model.Email,
                endereco: new Endereco(string.Empty,
                                       string.Empty,
                                       string.Empty,
                                       string.Empty,
                                       string.Empty,
                                       string.Empty,
                                       string.Empty,
                                       string.Empty),
                periodo: new Periodo(DateTime.Now, default),
                schema: GerarSchema());

            var usuario = new Usuario(id: Guid.NewGuid(),
                clinicaId: clinica.Id,
                nome: model.Nome,
                email: model.Email,
                endereco: new Endereco(string.Empty,
                                       string.Empty,
                                       string.Empty,
                                       string.Empty,
                                       string.Empty,
                                       string.Empty,
                                       string.Empty,
                                       string.Empty),
                documento: new Documento(string.Empty),
                senha: model.Senha.HashPassword(),
                grupo: Grupo.Administrador
            );

            clinica.AddUsuario(usuario);

            _clinica.Add(clinica);
            _clinica.Commit();

            return Ok(_authServico.GetAuthData(clinica.Id, clinica.Descricao, clinica.Schema));
        }

        public string GerarSchema()
        {
            string validar = "qwertyuiopasdfghjklzxcvbnm";
            StringBuilder strbld = new StringBuilder(10);
            Random random = new Random();
            bool Unico = true;
            while (Unico)
            {
                int _i = 0;
                while (_i < 10)
                {
                    strbld.Append(validar[random.Next(validar.Length)]);
                    _i++;
                }
                Unico = _clinica.Any(u => u.Schema == strbld.ToString());
            }
            return strbld.ToString();
        }
    }
}