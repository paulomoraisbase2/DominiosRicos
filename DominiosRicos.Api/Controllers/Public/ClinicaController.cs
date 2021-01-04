using DominiosRicos.Dominio.Comandos;
using DominiosRicos.Dominio.Contratos;
using DominiosRicos.Dominio.Entidades;
using DominiosRicos.Dominio.ModelosVisualizacao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DominiosRicos.Api.Controllers.Public
{
    [Route("public/[controller]")]
    [Authorize]
    [ApiController]
    public class ClinicaController : Controller
    {
        private readonly IBaseRepositorio<Clinica> _clinica;
        private readonly IBaseRepositorio<ClinicaTelefone> _clinicaTelefone;
        private readonly AuthenticatedUser _user;

        public ClinicaController(IBaseRepositorio<Clinica> clinica,
            IBaseRepositorio<ClinicaTelefone> clinicaTelefone,
            AuthenticatedUser user)
        {
            _clinicaTelefone = clinicaTelefone;
            _clinica = clinica;
            _user = user;
        }

        [HttpGet]
        public ActionResult<Clinica> GetClinica()
        {
            var clinica = _clinica
                .AllIncluding(c => c.ClinicaTelefones)
                .FirstOrDefault(c => c.Schema == _user.Schema);

            return Ok(clinica);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, ClinicaCommand clinica)
        {
            if (id != clinica.Id)
            {
                return BadRequest();
            }

            if (clinica.Invalid) return BadRequest(clinica.Notifications);

            _clinica.Update(clinica);
            _clinicaTelefone.DeleteWhere(c => c.GetType() != typeof(ClinicaTelefone));
            try
            {
                _clinica.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                //_clinica.Dispose();
                if (!_clinica.Exists(id))
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
    }
}