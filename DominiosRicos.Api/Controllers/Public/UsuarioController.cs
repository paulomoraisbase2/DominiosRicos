using DominiosRicos.Dominio.Action;
using DominiosRicos.Dominio.Comandos;
using DominiosRicos.Dominio.Contratos;
using DominiosRicos.Dominio.Entidades;
using DominiosRicos.Dominio.ModelosVisualizacao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominiosRicos.Api.Controllers.Public
{
    [Route("public/[controller]")]
    [Authorize]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IBaseRepositorio<Usuario> _usuarioRepositorio;
        private readonly AuthenticatedUser _user;

        public UsuarioController(IBaseRepositorio<Usuario> usuarioRepositorio, AuthenticatedUser user)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _user = user;
        }

        [HttpGet]
        public ActionResult<IEnumerable<object>> GetUsuarios()
        {
            var usuariosView = _usuarioRepositorio.AllIncluding(u => u.Clinica)
                .Where(u => u.Clinica.Schema == _user.Schema).Select(u => new
                {
                    u.Id,
                    u.Nome,
                    Email = u.Email.Endereco,
                    Telefone = u.UsuarioTelefones.FirstOrDefault() != null ? u.UsuarioTelefones.FirstOrDefault().Telefone : null,
                    PrimeiroNome = u.Nome.QuebraTexto().PrimeiroNome(),
                    SegundoNome = u.Nome.QuebraTexto().PrimeiroNome() == u.Nome.QuebraTexto().UltimoNome() ? "" : u.Nome.QuebraTexto().UltimoNome()
                }); ;
            return Ok(usuariosView.ToList());
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public ActionResult<Usuario> GetUsuario(Guid id)
        {
            var Usuario = _usuarioRepositorio
                .GetSingle(u => u.Clinica.Schema == _user.Schema && u.Id == id);

            if (Usuario == null)
            {
                return NotFound();
            }

            return Usuario;
        }

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        public IActionResult PutUsuario(Guid id, UsuarioCommand Usuario)
        {
            if (id != Usuario.Id)
            {
                return BadRequest();
            }
            //Usuario.Senha = _usuarioRepositorio.GetId(Usuario.Id).Senha;
            _usuarioRepositorio.Update(Usuario);
            _usuarioRepositorio.DeleteWhere(c => c.GetType() != typeof(UsuarioTelefone));
            try
            {
                _usuarioRepositorio.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Usuarios
        [HttpPost]
        public ActionResult<Usuario> PostUsuario(UsuarioCommand Usuario)
        {
            //if (!_usuarioRepositorio.isEmailUniq(Usuario.Email)) Usuario.AdicionarCritica("email", "erro.public.duplicado");
            if (Usuario.Invalid) return BadRequest(Usuario.Notifications);

            //Usuario.Senha = _authServico.HashPassword(Usuario.Senha);
            //Usuario.ClinicaId = _usuarioRepositorio.GetClinica;
            _usuarioRepositorio.Add(Usuario);
            _usuarioRepositorio.Commit();
            return CreatedAtAction("GetUsuario", new { id = Usuario.Id }, Usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuarioAsync(Guid id)
        {
            var Usuario = await _usuarioRepositorio.GetIdAsync(id);
            if (Usuario == null)
            {
                return NotFound();
            }

            _usuarioRepositorio.Delete(Usuario);
            return Usuario;
        }

        private bool UsuarioExists(Guid id)
        {
            return _usuarioRepositorio.GetIdAsync(id) == null;
        }
    }
}